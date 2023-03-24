using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelController : ControllerBase
    {
          TravelRepository tr = new TravelRepository();
        
        [HttpGet]
        public IEnumerable<t_Travel> Get()
        {
            
            return tr.GetAll();
          
        }
         [HttpGet("{id}")]
        // GET: api/TaskApi/5
         public t_Travel Get(int id)
        {
            return tr.GetOne(id);
           // return th.GetOne(id);
        }
         [HttpPost]
        public void Post(t_Travel value)
        {
            tr.Insert(value);
            //th.Insert(value);
        }
         [HttpPut("{id}")]
        // PUT: api/TaskApi/5
        public void Put(int id,t_Travel value)
        {
            tr.Update(value);
         
        }
    }
}