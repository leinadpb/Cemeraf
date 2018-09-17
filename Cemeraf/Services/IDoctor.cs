using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.Services
{
    public interface IDoctor
    {
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetById(int? id);
        Task<Doctor> Create(Doctor doctor);
        Task<Doctor> Delete(Doctor doctor);
        Task<Doctor> Modify(Doctor newDoctor, int doctorId);
    }
}
