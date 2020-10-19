using ASPNETCore.Cache.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Cache
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<PatientInfo, PatientInfoViewModel>();
            CreateMap<PatientInfoViewModel,PatientInfo>();
        }

    }
}
