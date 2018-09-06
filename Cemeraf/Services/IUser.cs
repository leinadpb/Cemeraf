using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.Services
{
    public interface IUser
    {
        Task<IEnumerable<CemerafUser>> GetAll();
        Task<CemerafUser> GetByEmail(string email);
    }
}
