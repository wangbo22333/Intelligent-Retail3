using Intelligent_Retail3.Data;
using Intelligent_Retail3.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Intelligent_Retail3.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    public class WXDeviceProductAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WXDeviceProductAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WXDeviceProductAPI
        [HttpGet]
        public ActionResult<List<WXDeviceProductAPI>> GetWXDeviceProduct(string id)
        {

            List<WXDeviceProductAPI> list = new List<WXDeviceProductAPI>();

            return list;
        }


    }
}
