using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;

namespace Cemeraf.Services
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public Task<IEnumerable<CemerafUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CemerafUser> GetByEmail(string email)
        {
            return Task.Run(() => {
                return _context.CemerafUsers.Where(u => u.Email.Equals(email)).FirstOrDefault();
            });
        }
    }
}
