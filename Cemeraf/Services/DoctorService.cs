using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;

namespace Cemeraf.Services
{
    public class DoctorService : IDoctor
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public Doctor Create(Doctor doctor)
        {
            try
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Error saving doctor: {exp}");
                return null;
            }
            return doctor;
        }

        public Task<IEnumerable<Doctor>> GetAll()
        {
            return Task.Run(() => {
                return _context.Doctors.AsEnumerable();
            });
        }

        public Task<Doctor> GetById(int? id)
        {
            return Task.Run(() => {
                return _context.Doctors.Where(d => d.DoctorId == id).FirstOrDefault();
            });
        }
    }
}
