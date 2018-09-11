using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;
namespace Cemeraf.ViewModels
{
    public class UpdateCitaViewModel
    {
        public string PacienteFullName { get; set; }
        public DateTime DateProposed { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAssigned { get; set; }
        public string Description { get; set; }
        public Doctor Doctor { get; set; }
        public string DocName { get; set; }
    }
}
