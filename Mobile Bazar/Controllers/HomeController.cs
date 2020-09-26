using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Model;
using MyApp.DB;
using System.Web.Security;

namespace Mobile_Bazar.Controllers
{
    
    public class HomeController : Controller
    {
        CustomerRepo cs = null;
        ProductRepo pr = null;
        CartRepo cr = null;
        ContactRepo cp = null;

        public HomeController()
        {
            cs = new CustomerRepo();
            pr = new ProductRepo();
            cr = new CartRepo();
            cp = new ContactRepo();
        }
        // GET: Home
        public ActionResult Index()
        {
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.GetAllProducts().Take(12);

            if (TempData["check"]!=null)
                ViewBag.checkAuthentic = "No";
            else
                ViewBag.checkAuthentic = null;

            return View(list);
        }

        public ActionResult SignUp()
        {
            
            ViewBag.confirm = null;
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                int id = cs.AddEmployee(model);

                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.confirm = "Registration Succesful";
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(String email, String password)
        {
            int id = cs.CheckAuthenticity(email, password);

            if (id!=0)
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("CustomerIndex", "Index", new { CustomerId = id });
            }
            else
            {
                TempData["check"] = "Failed";
                return RedirectToAction("Index");
            }
        }

        public ActionResult ShoppingPanel()
        {
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.GetAllProducts();

            ViewData["mobiles"] = list;
            
            if (TempData["result"]!=null)
            {
                list = (List<ProductModel>)TempData["result"];
            }

            return View(list);
        }

        public ActionResult SearchBrand(String Brand)
        {
            pr = new ProductRepo();
            var list = pr.SearchProducts(Brand);

            TempData["result"] = list;

            return RedirectToAction("ShoppingPanel");
        }

        public ActionResult ShowProductDetails(int id)
        {
            pr = new ProductRepo();
            ProductModel productModel = pr.GetProduct(id);

            return View(productModel);
        }

        
       /* public ActionResult View_Cart(int selected, int pid)
        {
            pr = new ProductRepo();
            ProductModel productModel = pr.GetProduct(pid);

            CartModel cartModel = new CartModel()
            {
                CustomerID = 1,
                ProductID = productModel.ProductID,
                Price = productModel.Price,
                Quantity = selected,
                TotalPrice = selected * productModel.Price
            };

            bool b = cr.AddToCart(cartModel);

            return View("ViewCart");
        }*/

        public ActionResult ContactAdmin(String email, String message)
        {
            Boolean n = cp.AddContact(email, message);
            return RedirectToAction("Index");
        }
    }
}