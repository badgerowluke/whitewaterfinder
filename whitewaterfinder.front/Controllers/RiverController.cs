using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using whitewaterfinder.Core;

namespace whitewaterfinder.Controllers
{
    [Route("api/[controller]")]
    public class RiverController : Controller
    {
        private readonly IRiverService riverServ;
        public RiverController(IRiverService service)
        {
            riverServ = service;
        }

        [HttpGet]
        public IActionResult GetRivers(string partName)
        {
            return Ok(riverServ.GetRivers(partName));
        }
        [HttpGet("{riverCode}")]
        public IActionResult GetRiverDetails(string riverCode)
        {
            return Ok(riverServ.GetRiverDetails(riverCode));
        }
    
    }
}