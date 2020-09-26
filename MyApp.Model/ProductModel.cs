

namespace MyApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Warranty { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> SoldItems { get; set; }
        public Nullable<int> Price { get; set; }
        public string ImagePath { get; set; }

        public string DisplayType { get; set; }
        public string DisplaySize { get; set; }
        public string Resolution { get; set; }
        public string SelfieCamera { get; set; }
        public string MainCamera { get; set; }
        public string ROM { get; set; }
        public string RAM { get; set; }
        public string OperatingSystem { get; set; }
        public string Chipset { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }
        public string Dimension { get; set; }
        public string SIM { get; set; }
        public string WLAN { get; set; }
        public string Bluetooth { get; set; }
        public string GPS { get; set; }
        public string USB { get; set; }
        public string BatteryType { get; set; }
        public string Sensors { get; set; }
        public string Video { get; set; }
        public string NetworkTechnology { get; set; }

        public Nullable<int> ReleaseYear { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }

    }
}
