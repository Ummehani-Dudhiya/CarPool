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
    public class UserAuthController : ControllerBase
    {
        UserAuthRepository uah = new UserAuthRepository();
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(t_User data)
        {
            uah.Register(data);
            return RedirectToAction("Login");
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(vm_Login data)
        {
            if(uah.Login(data))
            {
                return RedirectToAction("Register");
            }
            return RedirectToAction("Login", "UserAuth");
        }
    }
}