using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cemeraf.Models;

namespace Cemeraf.ViewModels
{
    public class AllDoctorsViewModel
    {
        public IEnumerable<Specialty> Specialties { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }

    }
}
