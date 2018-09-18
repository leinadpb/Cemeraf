using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.Services
{
    public interface IUser
    {
        Task<IQueryable<CemerafUser>> GetAll();
        Task<CemerafUser> GetByEmail(string email);
        Task<CemerafUser> GetById(string id);
        Task<bool> AddToRolAsync(CemerafUser user, string role);
        Task<bool> RemoveFromRolAsync(CemerafUser user, string role);
        Task<IQueryable<CemerafUser>> GetGeneralUsers();
    }
}
