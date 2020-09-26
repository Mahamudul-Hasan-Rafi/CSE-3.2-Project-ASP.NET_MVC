using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Model;
using MyApp.DB;

namespace Mobile_Bazar.Controllers
{
    public class AdminController : Controller
    {
        ProductModel productModel;
        ContactModel contactModel;
        ContactRepo cp;
        // GET: Admin

        public AdminController()
        {
            productModel = null;
            cp = new ContactRepo();
        }
        public ActionResult Admin_Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin_index(String name, String pass)
        {
            if(name.Equals("admin") && pass.Equals("admin"))
            {
                return RedirectToAction("Product_Details");
            }
            else
            {
                ViewData["check"] = "False";
                return View();
            }
        }

        public ActionResult Product_Dashboard()
        {
            return View();
        }

        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(ProductModel model)
        {
            ProductRepo productRepo = new ProductRepo();

            int id = productRepo.AddProduct(model);

            if (id > 0)
            {
                ViewData["Added"] = "True";
                ModelState.Clear();
            }
            else
            {
                ViewData["Added"] = "False";
            }
            
            return View();
        }

        public ActionResult ProductDetails()
        {
            ProductRepo productRepo = new ProductRepo();

            var list = productRepo.GetAllProducts();

            if (TempData["result"] != null)
            {
                list = (List<ProductModel>)TempData["result"];
            }

            return View(list);
        }
        
        public ActionResult ProductEdit(int id)
        {
            ProductRepo productRepo = new ProductRepo();

            var product = productRepo.GetProduct(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult ProductEdit(int id, ProductModel productModel)
        {
            ProductRepo productRepo = new ProductRepo();
            Boolean b = productRepo.EditProduct(id, productModel);

            return RedirectToAction("ProductDetails");
        }

        public ActionResult DeleteProduct(int id)
        {
            ProductRepo productRepo = new ProductRepo();
            Boolean b = productRepo.DeleteProduct(id);

            if (b == true)
            {
                ViewData["Deleted"] = "True";
            }

            else
            {
                ViewData["Deleted"] = "False";
            }

            return RedirectToAction("ProductDetails");
        }

        public ActionResult SearchResult(String searchText)
        {
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.SearchProducts(searchText);

            if (list != null)
            {
                TempData["result"] = list;
            }
           
            return RedirectToAction("ProductDetails");
        }

        public ActionResult ShowDetails(int id)
        {
            ProductRepo productRepo = new ProductRepo();
            var product = productRepo.GetProduct(id);

            return View(product);
        }

        public ActionResult ShowQuantity()
        {
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.GetAllProducts();

            return View(list);
        }

        [HttpPost]
        public ActionResult ShowQuantity(String searchText)
        {
            ProductRepo productRepo = new ProductRepo();
            var list = productRepo.SearchProducts(searchText);
            return View(list);
        }

        public ActionResult ShowMessage()
        {
            var list = cp.GetAllContacts();
            return View(list);
        }

        public ActionResult DeleteMessage(int id)
        {
            cp.DeleteContact(id);
            return RedirectToAction("ShowMessage");
        }

        public ActionResult ShowAllOrders()
        {
            OrderRepo op = new OrderRepo();

            var lst = op.GetAllOrders();
            return View(lst);
        }

    }
}