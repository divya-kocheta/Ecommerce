using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce.Controllers
{
    public class productListController : Controller
    {
        // GET: productList
        EcommEntities2 db = new EcommEntities2();
     

        public ActionResult Index()
        {
            var products = db.Product_table.ToList();
        
            return View(products);
        }
        [HttpPost]

        public ActionResult AddToCart(int productID)
        {
            List<int> cartProductIDs = Session["cartProductIDs"] as List<int>;
            if(cartProductIDs==null)
            {
                cartProductIDs = new List<int>();
                Session["cartProductIDs"]=cartProductIDs;
            }


            if ( cartProductIDs!=null && cartProductIDs.Contains(productID))
            {
                TempData["Message"] = "Product is already in the cart.";
            }
            else
            {
              

                
                var product = db.Product_table.FirstOrDefault(x => x.P_ID == productID);
                if (product != null)
                {


                    var newCartItem = new Cart_item
                    {
                        Product_image = product.P_Image,
                        Product_name = product.P_Name,
                        Product_quantity = 1,

                        Product_price = product.P_Price ?? 0,
                        FK_productID = product.P_ID
                    };
                    db.Cart_item.Add(newCartItem);
                    db.SaveChanges();
                    //if(cartProductIDs==null)
                    //{
                    //    cartProductIDs = new List<int>();
                    //}
                    //return Json(new { success = true, message = "Product added to cart" });
                    cartProductIDs = cartProductIDs ?? new List<int>();
                    cartProductIDs.Add(productID);
                        Session["cartProductIDs"] = cartProductIDs;
                        TempData["Message"] = "Product added to the cart.";
                        //return RedirectToAction("Index", "Cart");
                    }
                else
                {
                    TempData["Message"] = "Product Not Found.";

                    //return Json(new { success = true, message = "Product not found" });
                    //return HttpNotFound();

                }

            
        }
            return RedirectToAction("Index", "productList");



        }

    }
}