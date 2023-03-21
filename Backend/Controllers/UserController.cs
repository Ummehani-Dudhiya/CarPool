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
    public class UserController : ControllerBase
    {
        UserAuthRepository uah = new UserAuthRepository();
        [HttpGet("{id}")]
        public t_User Profile(int id)
        {
            return uah.GetProfile(id);
        }

        [HttpPost("{id}")]
        public ActionResult ChangeProfile(t_User u,int id)
        {
            uah.ChangeProfile(u,id);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult ChangePassword(ChangePassword cp, int id)
        {
            int result = uah.ChangePassword(cp, id);
            return Ok();
        }
    }
}