using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        EcommEntities2 db=new EcommEntities2();
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult GenerateBill()
        {
            List<Cart_item>cartItems=db.Cart_item.ToList();
            decimal totalAmount = CalculateTotalAmount(cartItems);
            int productCount =cartItems.Count();

                ViewBag.cartItems = cartItems;
                ViewBag.TotalAmount = totalAmount;
                ViewBag.ProductCount = productCount;
            return View();

        }
        private decimal CalculateTotalAmount(List<Cart_item> cartItems)
        {
            decimal totalAmount = 0;
            foreach (var item in cartItems)
            {
                totalAmount += item.Product_price * item.Product_quantity;
            }
            return totalAmount;
        }
       
    }
}