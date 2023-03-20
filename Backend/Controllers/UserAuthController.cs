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
        public ActionResult Register(t_User data)
        {
            uah.Register(data);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(vm_Login data)
        {
            if(uah.Login(data))
            {
                return RedirectToAction("Index", "Car");
            }
            return RedirectToAction("Login", "UserAuth");
        }
    }
}