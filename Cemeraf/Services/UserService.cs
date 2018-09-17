using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;
using Microsoft.AspNetCore.Identity;

namespace Cemeraf.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<CemerafUser> SignInManager;
        private readonly UserManager<CemerafUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public UserService(ApplicationDbContext ctx,
            SignInManager<CemerafUser> signInManager,
            UserManager<CemerafUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = ctx;
            SignInManager = signInManager;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public Task<bool> AddToRolAsync(CemerafUser user, string role)
        {
            return Task.Run(async () => {

                if(user != null && !role.Equals(""))
                {
                    role = role.Trim().ToUpper();

                    if (!RoleManager.RoleExistsAsync(role).Result)
                    {
                        var Role = new IdentityRole
                        {
                            Name = role
                        };
                        try
                        {
                            await RoleManager.CreateAsync(Role);
                            _context.SaveChanges();
                        }catch(Exception exp)
                        {
                            Console.WriteLine($"Error: {exp}");
                            return false;
                        }
                    }

                    try
                    {
                        var result = await UserManager.AddToRoleAsync(user, role);
                        _context.SaveChanges();
                        return true;
                    }catch(Exception exp)
                    {
                        Console.WriteLine($"Error: {exp}");
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            });
            
        }

        public Task<IQueryable<CemerafUser>> GetAll()
        {
            return Task.Run(() => {
                return _context.CemerafUsers.Select(a => a);
            });
        }

        public Task<CemerafUser> GetByEmail(string email)
        {
            return Task.Run(() => {
                return _context.CemerafUsers.Where(u => u.Email.Equals(email)).FirstOrDefault();
            });
        }

        public Task<CemerafUser> GetById(string id)
        {
            return Task.Run(() => {
                CemerafUser user = null;
                try
                {
                    user = _context.CemerafUsers.Where(u => u.Id.Equals(id)).First();
                    if (user != null)
                        return user;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error: {exp}");
                }
                return user;
            });
        }

        public Task<bool> RemoveFromRolAsync(CemerafUser user, string role)
        {
            return Task.Run(async () => {

                if (user != null || !role.Equals(""))
                {
                    role = role.Trim().ToUpper();

                    if (RoleManager.RoleExistsAsync(role).Result)
                    {
                        try
                        {
                            await UserManager.RemoveFromRoleAsync(user, role);
                            _context.SaveChanges();
                            return true;
                        }
                        catch (Exception exp)
                        {
                            Console.WriteLine($"Error: {exp}");
                        }
                    }
                    
                }

                return false;
            });
        }
    }
}
