using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPNETCore.Cache.Models;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;

namespace ASPNETCore.Cache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache memoryCache;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache,
            IMapper mapper
            )
        {
            _logger = logger;
            this.memoryCache = memoryCache;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var patientInfoService = new PatientInfo();

            var patientList = new List<PatientInfo>();

            if (!memoryCache.TryGetValue("PatientInfoCache", out patientList))
            {
                if (patientList == null || !patientList.Any())
                {
                    patientList = patientInfoService.GetPatientInfos();
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions();
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromSeconds(7));

                // here we need to set the value for cache memory
                memoryCache.Set("PatientInfoCache", patientList, cacheEntryOptions);

                //to remove 
                memoryCache.Remove("PatientInfoCache");
            }

            var model = new PatientListViewModel
            {
                PatientInfos = patientList
            };

            return View(model);
        }

        public IActionResult PatientProfile()
        {
            var patientInfo = new PatientInfo().GetPatientInfos().FirstOrDefault();

            var model = mapper.Map<PatientInfoViewModel>(patientInfo);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
