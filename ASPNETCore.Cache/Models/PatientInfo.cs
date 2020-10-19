using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Cache.Models
{
    public class PatientInfo
    {
        public string PatientSerialNo { get; set; }
        public string FullName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public List<PatientInfo> GetPatientInfos()
        {
            var listing = new List<PatientInfo>()
            { 
                new PatientInfo
                { 
                    PatientSerialNo="PTS-00001",
                    FullName="Rejwanul Reja",
                    Cellphone="01718055626",
                    Email="rezaice07@gmail.com",
                    Address="Mirpur 01, Dhaka, Bangladesh",
                },
                new PatientInfo
                {
                    PatientSerialNo="PTS-00002",
                    FullName="Devid Solomon",
                    Cellphone="01718055600",
                    Email="devidsolomon@gmail.com",
                    Address="Mirpur 10, Dhaka, Bangladesh",
                },

                new PatientInfo
                {
                    PatientSerialNo="PTS-00003",
                    FullName="Richard Packwood",
                    Cellphone="01718055699",
                    Email="richardpackwood@gmail.com",
                    Address="Dhanmondi, Dhaka, Bangladesh",
                }
            };

            return listing;
        }
    }
}
