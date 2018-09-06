using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cemeraf.Models
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAssigned { get; set; }
        public bool Approved { get; set; }

        // Optional: In this case, the secretary will have to assign a doctor before it's approval.
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public CemerafUser CemerafUser { get; set; }

        public List<Cita> Citas { get; set; }



    }
}
