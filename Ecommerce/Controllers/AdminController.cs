using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        EcommEntities2 db = new EcommEntities2();

        public ActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Login(AdminDetails_Table a)
        {
           
            var admin=db.AdminDetails_Table.Where(x => x.Email ==a.Email && x.Ad_Pass==a.Ad_Pass ).FirstOrDefault();

            if (admin != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["AdminLoginSuccessMSG"] = "<script>alert('Username or password is incorrect')</script>";
                ModelState.Clear();
                return View();
            }
            
        }

    }
}