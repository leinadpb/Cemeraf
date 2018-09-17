using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.Services
{
    public interface ISpecialty
    {
        Task<IEnumerable<Specialty>> GetAll();
        Task<Specialty> Add(Specialty specialty);
        Task<Specialty> Delete(int id);
        Task<Specialty> Modify(Specialty newSpecialty, int specialtyId);
    }
}
