using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;

namespace Cemeraf.Services
{
    public class SpecialtiesService : ISpecialty
    {
        private readonly ApplicationDbContext _context;
        public SpecialtiesService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        public Task<IEnumerable<Specialty>> GetAll()
        {
            return Task.Run(() => {
                return _context.Specialties.AsEnumerable();
            });
        }
    }
}
