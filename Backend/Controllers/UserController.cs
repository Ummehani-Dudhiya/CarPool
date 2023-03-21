using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        //  public ActionResult UserProfile()
        // {
        //     if (Session["Username"] == null)
        //     {
        //         return RedirectToAction("Login", "UserAuth");
        //     }
        //     return View(uah.GetProfile());
        // }

        [HttpPost]
        public ActionResult UserProfile(t_User data)
        {            
            int result = uah.ChangeProfile(data);
            ViewBag.result = result;
            return View();
        }

        // public ActionResult ChangePassword()
        // {
        //     if (Session["Username"] == null)
        //     {
        //         return RedirectToAction("Login", "UserAuth");
        //     }
        //     return View();
        // }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword data)
        {
            int result = uah.ChangePassword(data);
            ViewBag.result = result;
            return View();
        }
    }
}