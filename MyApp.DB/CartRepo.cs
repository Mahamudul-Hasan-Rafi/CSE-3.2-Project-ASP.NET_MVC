using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DB
{
    public class CartRepo
    {
        public Boolean AddToCart(CartModel model)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                tbl_Cart cs = new tbl_Cart()
                {
                    CustomerID = model.CustomerID,
                    ProductID = model.ProductID,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    TotalPrice = model.TotalPrice,
                };

                context.tbl_Cart.Add(cs);
                context.SaveChanges();

                return true;
            }

        }

        public List<CartModel> GetAllCarts()
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var list = context.tbl_Cart.
                    Select(x => new CartModel()
                    {
                       CartID = x.CartID,
                       CustomerID = x.CustomerID,
                       ProductID = x.ProductID,
                       Quantity = x.Quantity,
                       Price = x.Price,
                       TotalPrice = x.TotalPrice,
                       Product = new ProductModel()
                       {
                           ProductName = x.tbl_Product.ProductName
                       }

                    }).ToList();

                return list;
            }
        }

        public Boolean DeleteProduct(int id)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var cart = context.tbl_Cart.FirstOrDefault(x => x.CartID == id);

                if (cart != null)
                {
                    context.tbl_Cart.Remove(cart);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public CartModel GetCart(int id)
        {
            using(var context = new MobileBazaarDBEntities())
            {
                var item = context.tbl_Cart.FirstOrDefault(x => x.CartID == id);
                CartModel cartModel = new CartModel()
                {
                    CartID = item.CartID,
                    CustomerID = item.CustomerID,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    TotalPrice = item.TotalPrice,
                    Product = new ProductModel()
                    {
                        ProductName = item.tbl_Product.ProductName
                    }
                };

                return cartModel;
            }
        }

    }
}
