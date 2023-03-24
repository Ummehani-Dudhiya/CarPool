using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

using Backend.Repositories;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
          CityRepository cr = new CityRepository();
        
        [HttpGet]
        public IEnumerable<t_City> Get()
        {
            
            return cr.GetAll();
          
        }
    }
}