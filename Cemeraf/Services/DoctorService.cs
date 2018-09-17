using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
using Cemeraf.Data;
using Microsoft.EntityFrameworkCore;

namespace Cemeraf.Services
{
    public class DoctorService : IDoctor
    {
        private readonly ApplicationDbContext _context;

        public DoctorService(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public Task<Doctor> Create(Doctor doctor)
        {
            return Task.Run(() => {
                if (doctor != null)
                {
                    try
                    {
                        _context.Doctors.Add(doctor);
                        _context.SaveChanges();

                        return doctor;
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine($"Error saving doctor: {exp}");
                    }
                }

                return null;
            });
        }

        public Task<Doctor> Delete(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Doctor>> GetAll()
        {
            return Task.Run(() => {
                return _context.Doctors
                    .Include(d => d.Specialties)
                    .AsEnumerable();
            });
        }

        public Task<Doctor> GetById(int? id)
        {
            return Task.Run(() => {

                if(id != null)
                {
                    try
                    {
                        Doctor doc = _context.Doctors.Where(d => d.DoctorId == id).FirstOrDefault();
                        if (doc != null)
                        {
                            return doc;
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine($"Error getting doctor: {exp}");
                    }
                }
                return null;
                
            });
        }

        public Task<Doctor> Modify(Doctor newDoctor, int doctorId)
        {
            throw new NotImplementedException();
        }
    }
}
