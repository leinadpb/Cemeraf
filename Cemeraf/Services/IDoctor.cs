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
        Doctor Create(Doctor doctor);
        
    }
}
