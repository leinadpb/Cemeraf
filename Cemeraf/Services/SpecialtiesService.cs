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

        public Task<Specialty> Add(Specialty specialty)
        {
            throw new NotImplementedException();
        }

        public Task<Specialty> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Specialty>> GetAll()
        {
            return Task.Run(() => {
                return _context.Specialties.AsEnumerable();
            });
        }

        public Task<Specialty> Modify(Specialty newSpecialty, int specialtyId)
        {
            throw new NotImplementedException();
        }
    }
}
