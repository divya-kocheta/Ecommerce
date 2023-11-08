using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;


namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        EcommEntities2 db = new EcommEntities2();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmedOrder()
        {

            int ID = Convert.ToInt32(Session["MainID"]);
            var user = db.UserReg_Table.SingleOrDefault(u => u.userID == ID);
            if (user != null)
            {
                ViewBag.UserId = user.userID;
                ViewBag.Address = user.Addres;
                ViewBag.MobNo = user.MobNo;
                var orderDetail = new order_Details
                {
                    userid = user.userID,
                    Address = user.Addres,
                    Mobno = user.MobNo.ToString(),

                };
                return View(orderDetail);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Submit(order_Details order)
        {
            //ViewBag.ConfirmationMessage = "Address Details submitted successfully";
            if (ModelState.IsValid)
            {
                TempData["FormSubmitted"] = "Form";
                //using(var db= new EcommEntities2())
                //{
                int userID = Convert.ToInt32(Session["MainID"]);
                var user = db.UserReg_Table.SingleOrDefault(u => u.userID == userID);
                if (user != null)
                {
                    var newOrder = new order_Details
                    {
                        userid = userID,
                        Address = user.Addres,
                        Mobno = user.MobNo.ToString(),
                        City = order.City,
                        Zipcode = order.Zipcode,
                        paymentstatus= "Success"
                    };

                    
                    db.order_Details.Add(newOrder);
                    db.SaveChanges();
                   
                    //if (ModelState.IsValid)
                    //{

                    TempData["SubmittedCity"] = order.City;
                    TempData["SubmittedZipcode"] = order.Zipcode;
                    TempData["ConfirmSuccessMSG"] = "<script>alert('Details Submitted Successfully')</script>";
                    //ModelState.Remove("City");
                    //ModelState.Remove("Zipcode");
                    //ModelState.SetModelValue("City", new ValueProviderResult(order.City, order.City, System.Globalization.CultureInfo.InvariantCulture));
                    //ModelState.SetModelValue("Zipcode", new ValueProviderResult(order.Zipcode, order.Zipcode, System.Globalization.CultureInfo.InvariantCulture));
                    //return RedirectToAction("ConfirmedOrder", order);
                       
                    //}
                }

               
            }
           
            return View("ConfirmedOrder", order);
          
        }

        public ActionResult thankyou()
        {
            return View();
        }

    }
}