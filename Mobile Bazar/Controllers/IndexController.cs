using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Model;
using MyApp.DB;

namespace Mobile_Bazar.Controllers
{
    [Authorize]
    public class IndexController : Controller
    {

        CustomerRepo cs = null;
        ProductRepo pr = null;
        CartRepo cr = null;
        ContactRepo cp = null;
        OrderRepo op = null;
        OrderModel orderModel = null;
       
        public IndexController()
        {
            cs = new CustomerRepo();
            pr = new ProductRepo();
            cr = new CartRepo();
            cp = new ContactRepo();
            op = new OrderRepo();
        }

        // GET: Index
        public ActionResult CustomerIndex(int CustomerId=0)
        {
            if (Session["MyID"] == null) {
                Session["MyID"] = CustomerId;
            }
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.GetAllProducts().Take(12);

            if (TempData["check"] != null)
                ViewBag.checkAuthentic = "No";
            else
                ViewBag.checkAuthentic = null;

            return View(list);
           
        }

        public ActionResult MyProfile()
        {
            if (TempData["i"]!=null)
            {
                ViewData["Updated"] = "True";
            }
            CustomerModel model = cs.GetCustomer((int)Session["MyID"]);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateInfo(CustomerModel csm)
        {
            CustomerModel cm = cs.UpdateModel((int)Session["MyID"],csm);
           
            if (cm != null)
            {
                TempData["i"] = "true";
                return RedirectToAction("MyProfile");
            }
            return View();
        }

        public ActionResult ShowProductDetails_Customer(int id)
        {
            pr = new ProductRepo();
            ProductModel productModel = pr.GetProduct(id);

            if (TempData["Cart"]!=null)
            {
                ViewData["cart"] = "True";
            }

            return View(productModel);
        }

        public ActionResult ShoppingPanel_Customer()
        {
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.GetAllProducts();

            ViewData["mobiles"] = list;

            if (TempData["result"] != null)
            {
                list = (List<ProductModel>)TempData["result"];
            }

            

            return View(list);
        }

        public ActionResult SearchBrand_Customer(String Brand)
        {
            pr = new ProductRepo();
            var list = pr.SearchProducts(Brand);

            TempData["result"] = list;

            return RedirectToAction("ShoppingPanel_Customer");
        }

        public ActionResult Add_Cart(int selected, int pid)
        {
            pr = new ProductRepo();
            ProductModel productModel = pr.GetProduct(pid);

            CartModel cartModel = new CartModel()
            {
                CustomerID = (int)Session["MyID"],
                ProductID = productModel.ProductID,
                Price = productModel.Price,
                Quantity = selected,
                TotalPrice = selected * productModel.Price
            };

            bool b = cr.AddToCart(cartModel);

            TempData["Cart"] = "True";
          
            return RedirectToAction("ViewCart");
        }

        public ActionResult ViewCart()
        {
            CartRepo cr1 = new CartRepo();
            var list = cr1.GetAllCarts();
            return View(list);
        }

        public ActionResult DeleteCart(int id)
        {
            CartRepo cr1 = new CartRepo();
            cr1.DeleteProduct(id);
          
            return RedirectToAction("ViewCart");
        }

        public ActionResult ContactAdmin_Customer(String email, String message)
        {
            Boolean n = cp.AddContact(email, message);
            return RedirectToAction("CustomerIndex");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderProduct(int id)
        {
            CartRepo cr1 = new CartRepo();
            CartModel cart2 = cr1.GetCart(id);

            int pId = (int)cart2.ProductID;
            int q = (int)cart2.Quantity;
            int c = (int)cart2.CustomerID;
            int tp = (int)cart2.TotalPrice;
            String pname = cart2.Product.ProductName;

            //orderModel = new OrderModel(15001, c, pId, pname, q, tp, null);
            orderModel = new OrderModel()
            {
                OrderID = 15001,
                CustomerID = c,
                ProductID = pId,
                ProductName = pname,
                Quantity = q,
                TotalPrice = tp,
                OrderDate = null
            };

            Boolean b = op.AddOrder(orderModel);

            if (b == true)
            {
                cr1.DeleteProduct(cart2.CartID);

                pr = new ProductRepo();
                pr.EditProductQuantity(pId, q);
            }
            
            return RedirectToAction("ShowOrders");
        }

        public ActionResult ShowOrders()
        {
            var lst = op.GetAll((int)Session["MyID"]);
            return View(lst);
        }

    }
}