using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
namespace Cemeraf.Services
{
    public interface ICitas
    {
        Task<IEnumerable<Cita>> GetAll();
        Task<Cita> GetById(int id);
        Task<Cita> ChangeStatus(string newStatus, Cita cita);
        Task<Cita> Delete(Cita cita);
        Task<Cita> Add(Cita cita);
        Task<Cita> Modify(Cita cita);
    }
}
