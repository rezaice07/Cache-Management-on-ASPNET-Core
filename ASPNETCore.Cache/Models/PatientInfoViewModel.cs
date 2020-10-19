using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Cache.Models
{
    public class PatientInfoViewModel
    {
        public string PatientSerialNo { get; set; }
        public string FullName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }       
    }
}
