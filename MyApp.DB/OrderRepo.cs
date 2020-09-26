using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DB
{
    public class OrderRepo
    {
        public Boolean AddOrder(OrderModel model)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                tbl_Order od = new tbl_Order()
                {
                    CustomerID = model.CustomerID,
                    ProductID = model.ProductID,
                    ProductName = model.ProductName,
                    Quantity = model.Quantity,
                    TotalPrice = model.TotalPrice,
                    OrderDate = DateTime.Now.ToString()
                };

                context.tbl_Order.Add(od);
                context.SaveChanges();

                return true;
            }

        }

        /*public List<OrderModel> GetAllOrders()
        {
            using(var context = new MobileBazaarDBEntities())
            {
                var list = context.tbl_Order.
                    Select(x => new OrderModel()
                    {
                        OrderID = x.OrderID,
                        CustomerID = x.CustomerID,
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        Quantity = x.Quantity,
                        TotalPrice = x.TotalPrice,
                        OrderDate = x.OrderDate

                    }).ToList();

                return list;
            }*/

        public List<OrderModel> GetAll(int id)
        {
            using(var context = new MobileBazaarDBEntities())
            {
                var l = context.tbl_Order.
                    Select(y => new OrderModel()
                    {
                        OrderID = y.OrderID,
                        CustomerID = y.CustomerID,
                        ProductID = y.ProductID,
                        ProductName = y.ProductName,
                        Quantity = y.Quantity,
                        TotalPrice = y.TotalPrice,
                        OrderDate = y.OrderDate
                    }).Where(x=>x.CustomerID==id).ToList();

                return l;
            }
        }

        public List<OrderModel> GetAllOrders()
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var l = context.tbl_Order.
                    Select(y => new OrderModel()
                    {
                        OrderID = y.OrderID,
                        CustomerID = y.CustomerID,
                        ProductID = y.ProductID,
                        ProductName = y.ProductName,
                        Quantity = y.Quantity,
                        TotalPrice = y.TotalPrice,
                        OrderDate = y.OrderDate
                    }).ToList();

                return l;
            }
        }
    }
}
