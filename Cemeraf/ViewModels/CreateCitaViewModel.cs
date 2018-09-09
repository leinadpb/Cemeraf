using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.ViewModels
{
    public class CreateCitaViewModel
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Description { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateRegistered { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
