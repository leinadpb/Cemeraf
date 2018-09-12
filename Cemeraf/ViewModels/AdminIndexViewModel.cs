using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemeraf.ViewModels
{
    public class AdminIndexViewModel
    {
        public int TotalCitasByCurrentUser { get; set; }
        public int TotalDoctorsAdded { get; set; }
        public int TotalSpecialties { get; set; }

        //Temporal - Esto va en AdminAdminIndexViewModel
        public int TotalUsers { get; set; }

        //Personal data
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Sexo { get; set; }
        public string ProfilePicture { get; set; }
        public string Nacionalidad { get; set; }


    }
}
