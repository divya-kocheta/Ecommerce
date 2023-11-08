using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
     
        EcommEntities2 db = new EcommEntities2();
       
        public ActionResult Index()
        {
            List<int> cartProductIDs = Session["cartProductIDs"] as List<int>;
            var cartItems=db.Cart_item.ToList();
            cartProductIDs=cartItems.Select(item=>item.FK_productID).ToList();
            //decimal totalPrice = CalculateTotalPrice(cartItems);
            //ViewBag.TotalPrice = totalPrice;
            return View(cartItems);
        }

        //private decimal CalculateTotalPrice(List<Cart_item> cart_Items)
        //{
        //    decimal totalPrice = 0;
        //    foreach (var item in cart_Items)
        //    {
        //        totalPrice += item.Product_price * item.Product_quantity;
        //    }
        //    return totalPrice;
        //}

        [HttpPost]
      
        public ActionResult UpdateCartItem(int cartItemId, int newQuantity)
        {
            // Retrieve the cart item from the database
            var cartItem = db.Cart_item.FirstOrDefault(c => c.Cart_ID == cartItemId);

            if (cartItem != null)
            {
                cartItem.Product_quantity = newQuantity;

                cartItem.Cart_total_price = cartItem.Product_price * newQuantity;

                db.SaveChanges(); // Save changes to the database
                //return Json(new{success=true,updatedTotalPrice=cartItem.Cart_total_price});
                return RedirectToAction("Index", "Cart");
            }

            //return Json(new{ success = false, message = "Not found" });
            return HttpNotFound();
          
        }
        [HttpPost]
        
        public ActionResult RemoveCartItem(int cartItemId)
        {
            // Retrieve the cart item from the database
            var cartItem = db.Cart_item.FirstOrDefault(c => c.Cart_ID == cartItemId);

            if (cartItem != null)
            {
                db.Cart_item.Remove(cartItem);
                db.SaveChanges(); // Save changes to the database
            }

            return RedirectToAction("Index", "Cart"); // Redirect back to the cart page
        }
    }
}
