using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;
namespace Cemeraf.Services
{
    public class CitasService : ICitas
    {
        private readonly ApplicationDbContext _context;

        public CitasService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public Task<Cita> Add(Cita cita)
        {
            return Task.Run(() => {
                try
                {
                    _context.Citas.Add(cita);
                    _context.SaveChanges();
                    return cita;
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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cita>> GetAll()
        {
            return Task.Run(() => {
                return _context.Citas.AsEnumerable();
            });
        }

        public Task<Cita> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cita> Modify(Cita cita)
        {
            throw new NotImplementedException();
        }
    }
}
