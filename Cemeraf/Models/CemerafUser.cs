using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Cemeraf.Models
{
    public class CemerafUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
        public string Sex { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsAdmin { get; set; }

        public List<Cita> Citas { get; set; }


    }
}
