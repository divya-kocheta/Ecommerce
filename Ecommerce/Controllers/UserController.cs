using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        EcommEntities2 db = new EcommEntities2();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Login(UserReg_Table u)
        {
            var user = db.UserReg_Table.Where(model => model.Email == u.Email && model.Ur_Pass == u.Ur_Pass).FirstOrDefault();
            //var ID=db.UserReg_Table.Where(m=>m.userID==u.userID).FirstOrDefault();
           
            if (user != null)
            {
                Session["UserEmail"] = user.Email;
                Session["MainID"] = user.userID;
                TempData["MainID"] = user.userID;

                System.Web.Security.FormsAuthentication.SetAuthCookie(user.userID.ToString(), false);
                TempData["LoginSuccessMSG"] = "<script>alert('Login Successfully')</script>";
                return RedirectToAction("Index", "Home");
               
  
            }   
            else
            {
                TempData["LoginSuccessMSG"] = "<script>alert('Username or password is incorrect')</script>";
                return View();
            }
            
           
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(UserReg_Table u)
        {
            //if (ModelState.IsValid == true)
            //{
            //    db.UserReg_Table.Add(u);
            //    db.SaveChanges();
            //    return RedirectToAction(nameof(Login));
            //}

            //return View(u);
            if (ModelState.IsValid == true)
            {
                db.UserReg_Table.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMSG"] = "<script>alert('Inserted!!!')</script>";
                    return RedirectToAction("Login","User");
                }
                else
                {
                    TempData["InsertMSG"] = "<script>alert('Not inserted!!!')</script>";
                }
            }
            return View();


        }

    }
}