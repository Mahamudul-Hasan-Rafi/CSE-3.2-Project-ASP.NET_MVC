using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public class CartModel
    {
        public int CartID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> TotalPrice { get; set; }

        public CustomerModel Customer { get; set; }
        public ProductModel  Product { get; set; }
    }
}
