using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;
using Microsoft.EntityFrameworkCore;

namespace Cemeraf.Services
{
    public class CitasService : ICitas
    {
        private readonly ApplicationDbContext _context;

        public CitasService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public Task<Cita> Add(Cita cita, string userId)
        {
            // a user cannot add more than 3 citas with PENDING status!
            return Task.Run(() => {
                try
                {
                    //Get user total dates in PENDING status
                    var user = _context.CemerafUsers.Where(u => u.Id.Equals(userId))
                            .Include(u => u.Citas)
                            .First();
                    int c = 0;
                    foreach(Cita ct in user.Citas)
                    {
                        if (ct.Status.Equals("PENDING"))
                        {
                            c++;
                        }
                    }
                    int totalCitas = c;
                    if(!(totalCitas >= 3))
                    {
                        _context.Citas.Add(cita);
                        _context.SaveChanges();
                        return cita;
                    }
                    return null;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error saving cita: {exp}");
                }
                return null;
            });
        }

        public Task<Cita> ChangeStatus(string newStatus, Cita cita)
        {
            throw new NotImplementedException();
        }

        public Task<Cita> Delete(Cita cita)
        {
            return Task.Run(() => {

                try
                {
                    _context.Citas.Remove(cita);
                    _context.SaveChanges();
                    return cita;
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error deleting cita: {exp}");
                }

                return null;
            });
        }

        public Task<IEnumerable<Cita>> GetAll()
        {
            return Task.Run(() => {
                return _context.Citas.AsEnumerable();
            });
        }

        public Task<IEnumerable<Cita>> GetAllByUser(string id)
        {
            return Task.Run(() => {
                //CemerafUser user = _context.CemerafUsers.Where(cu => cu.Email.Equals(id)).FirstOrDefault();
                return _context.Citas.Where(c => c.CemerafUserId.Equals(id)).AsEnumerable();
            });
        }

        public Task<Cita> GetById(int id)
        {
            return Task.Run(() => {
                return _context.Citas.Where(c => c.CitaId == id).First();
            });
        }

        public Task<Cita> Modify(Cita cita)
        {
            throw new NotImplementedException();
        }
    }
}
