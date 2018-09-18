using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cemeraf.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public List<Specialty> Specialties { get; set; }

    }
}
