using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemeraf.ViewModels
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public int TotalCitas { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }
    public class AllUsersViewModel
    {
        public List<Usuario> Administrators { get; set; }
        public List<Usuario> Users { get; set; }
    }
}
