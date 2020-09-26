using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public string OrderDate { get; set; }
        /*public OrderModel(int id, int cid, int pidm, string p_name, int q, int tp, string d)
        {
            this.OrderID = id;
            this.CustomerID = cid;
            this.ProductID = pidm;
            this.ProductName = p_name;
            this.Quantity = q;
            this.TotalPrice = tp;
            this.OrderDate = d;
        }*/
       
    }
}
