using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemeraf.Models
{
    public class EmailToSend
    {
        public string From { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Body { get; set; }

        
    }
}
