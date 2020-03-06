using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.DAL;
using SessionCart.Web.Models;
using Newtonsoft.Json;

namespace SessionCart.Web.Controllers
{
    public class StoreController : Controller
    {
        /* Steps
           TODO 02. (StoreController)    Create Index Action for store/index
           TODO 03. (Index View)         Create Index View for store/index
           TODO 04. (StoreController)    Add a call to Session to store the last access time
                                         On next access, get the last access time and compare it to current time.
                                         Display "It has been NN seconds since you have been here" (use ViewData for now)
                                         Toy around with the session timeout.
           TEST
           TODO 05. (StoreController)    Update Index Action to read (from DAO) and pass products
           TODO 06. (Index View)         Display Products
           TEST

           TODO 07. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                         Pass Product Id in Form
           TODO 08. (StoreController)    Create POST Index Action for store/index, accept product id
           
           TODO 09. (StoreController)    Create GetShoppingCart
                                            Reads cart from session and de-serializes
                                            Guarantee ShoppingCart is in session, create if not
                                         Create SaveShoppingCart 
                                            Serializes the cart and sets it in Session.

           TODO 10. (StoreController)    In POST Index: Retrieve Product, Add it to the shopping cart, 
                                         Save shoppingCart and redirect to store/viewcart     
                                         
           TODO 11. (StoreController)    Create ViewCart action for store/viewcart
                                         Retrieve the shoopping cart and pass to the view
           TODO 12. (ViewCart View)      Display shopping cart
           TEST
       */
        private IProductDAO productDAO;
        public StoreController(IProductDAO productDAO)
        {
            this.productDAO = productDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string lastTimeHere = HttpContext.Session.GetString("LastAccess");

            if (String.IsNullOrEmpty(lastTimeHere))
            {
                // Say Welcome to the user
                ViewData["Message"] = "Welcome!";
            }
            else
            {
                // Convert from a string back to a DateTime
                DateTime last = DateTime.Parse(lastTimeHere);

                // Calculate the time since I was last here and display to the user
                double secondsSinceLastAccess = (DateTime.Now - last).TotalSeconds;
                ViewData["Message"] = $"Welcome back! You were last here {secondsSinceLastAccess:N2} ago.";
            }

            // Write the NEW LastAccess time to session so we can get it next time
            HttpContext.Session.SetString("LastAccess", DateTime.Now.ToString());



            // Get the catalog of product
            IList<Product> products = productDAO.GetProducts();

            return View(products);
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            product = productDAO.GetProduct(product.Id);

            if (product == null)
            {
                return NotFound();
            }


            // Get the cart from session, if it exists
            ShoppingCart cart;
            string json1 = HttpContext.Session.GetString("cart");
            if (String.IsNullOrEmpty(json1))
            {
                // Need a new cart
                cart = new ShoppingCart();
            }
            else
            {
                cart = JsonConvert.DeserializeObject<ShoppingCart>(json1);
                //cart = (ShoppingCart)JsonConvert.DeserializeObject(json1, typeof(ShoppingCart));
                //cart = JsonConvert.DeserializeObject(json1, typeof(ShoppingCart)) as ShoppingCart;
            }

            cart.AddToCart(product, 1);

            // Save the cart to Session, so we can get it next time.
            string json2 = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", json2);


            return RedirectToAction("Index");
        }
    }
}