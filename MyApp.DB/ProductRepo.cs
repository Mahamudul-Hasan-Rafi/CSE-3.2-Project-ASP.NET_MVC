using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Model;
using System.IO;
using System.Web;
using System.Data.Entity.Validation;

namespace MyApp.DB
{
    public class ProductRepo
    {
        public int AddProduct(ProductModel model)
        {
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
            string extension = Path.GetExtension(model.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
            model.ImagePath = "~/Product_Images/" + fileName;

            fileName = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Product_Images/"), fileName);

            model.ImageFile.SaveAs(fileName);
            
            using (var context = new MobileBazaarDBEntities())
            {
                tbl_Product pd = new tbl_Product()
                {
                    ProductName = model.ProductName,
                    Brand = model.Brand,
                    Warranty = model.Warranty,
                    Quantity = model.Quantity,
                    SoldItems = 0,
                    Price = model.Price,
                    ImagePath = model.ImagePath,
                    DisplayType = model.DisplayType,
                    DisplaySize = model.DisplaySize,
                    Resolution = model.Resolution,
                    SelfieCamera = model.SelfieCamera,
                    MainCamera = model.MainCamera,
                    OperatingSystem = model.OperatingSystem,
                    Chipset = model.Chipset,
                    CPU = model.CPU,
                    GPU = model.GPU,
                    ROM = model.ROM,
                    RAM = model.RAM,
                    Weight = model.Weight,
                    Color = model.Color,
                    Dimension = model.Dimension,
                    WLAN = model.WLAN,
                    Bluetooth = model.Bluetooth,
                    GPS = model.GPS,
                    USB = model.USB,
                    BatteryType = model.BatteryType,
                    Sensors = model.Sensors,
                    Video = model.Video,
                    NetworkTechnology = model.NetworkTechnology,
                    SIM = model.SIM,
                    ReleaseYear = model.ReleaseYear
                };

                context.tbl_Product.Add(pd);
                context.SaveChanges();

                return pd.ProductID;
            }

        }

        public List<ProductModel> GetAllProducts()
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var list = context.tbl_Product.
                    Select(x => new ProductModel()
                    {
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        Brand = x.Brand,
                        Warranty = x.Warranty,
                        Quantity = x.Quantity,
                        SoldItems = x.SoldItems,
                        Price = x.Price,
                        ImagePath = x.ImagePath,
                        DisplayType = x.DisplayType,
                        DisplaySize = x.DisplaySize,
                        Resolution = x.Resolution,
                        SelfieCamera = x.SelfieCamera,
                        MainCamera = x.MainCamera,
                        OperatingSystem = x.OperatingSystem,
                        Chipset = x.Chipset,
                        CPU = x.CPU,
                        GPU = x.GPU,
                        ROM = x.ROM,
                        RAM = x.RAM,
                        Weight = x.Weight,
                        Color = x.Color,
                        Dimension = x.Dimension,
                        WLAN = x.WLAN,
                        Bluetooth = x.Bluetooth,
                        GPS = x.GPS,
                        USB = x.USB,
                        BatteryType = x.BatteryType,
                        Sensors = x.Sensors,
                        Video = x.Video,
                        NetworkTechnology = x.NetworkTechnology

                    }).ToList();
                
                return list;
            }
        }

        public ProductModel GetProduct(int id)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var product = context.tbl_Product.FirstOrDefault(x => x.ProductID == id);

                ProductModel productModel = new ProductModel()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    Brand = product.Brand,
                    Warranty = product.Warranty,
                    Quantity = product.Quantity,
                    SoldItems = product.SoldItems,
                    Price = product.Price,
                    ImagePath = product.ImagePath,
                    DisplayType = product.DisplayType,
                    DisplaySize = product.DisplaySize,
                    Resolution = product.Resolution,
                    SelfieCamera = product.SelfieCamera,
                    MainCamera = product.MainCamera,
                    OperatingSystem = product.OperatingSystem,
                    Chipset = product.Chipset,
                    CPU = product.CPU,
                    GPU = product.GPU,
                    ROM = product.ROM,
                    RAM = product.RAM,
                    Weight = product.Weight,
                    Color = product.Color,
                    Dimension = product.Dimension,
                    WLAN = product.WLAN,
                    Bluetooth = product.Bluetooth,
                    GPS = product.GPS,
                    USB = product.USB,
                    BatteryType = product.BatteryType,
                    Sensors = product.Sensors,
                    Video = product.Video,
                    NetworkTechnology = product.NetworkTechnology,
                    SIM = product.SIM,
                    ReleaseYear = product.ReleaseYear
                };

                return productModel;
            }
        }

        public Boolean EditProduct(int id, ProductModel productModel)
        {
            String filename = Path.GetFileNameWithoutExtension(productModel.ImageFile.FileName);
            String extension = Path.GetExtension(productModel.ImageFile.FileName);

            filename = filename + DateTime.Now.ToString("yymmssff") + extension;

            productModel.ImagePath = "~/Product_Images/" + filename;

            filename = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Product_Images/"), filename);

            productModel.ImageFile.SaveAs(filename);

            using (var context = new MobileBazaarDBEntities())
            {
                var product = context.tbl_Product.FirstOrDefault(x => x.ProductID == id);

                product.ProductName = productModel.ProductName;
                product.Brand = productModel.Brand;
                product.Warranty = productModel.Warranty;
                product.Quantity = productModel.Quantity;
                product.Price = productModel.Price;
                product.ImagePath = productModel.ImagePath;
                product.DisplayType = productModel.DisplayType;
                product.DisplaySize = productModel.DisplaySize;
                product.Resolution = productModel.Resolution;
                product.SelfieCamera = productModel.SelfieCamera;
                product.MainCamera = productModel.MainCamera;
                product.OperatingSystem = productModel.OperatingSystem;
                product.Chipset = productModel.Chipset;
                product.CPU = productModel.CPU;
                product.GPU = productModel.GPU;
                product.ROM = productModel.ROM;
                product.RAM = productModel.RAM;
                product.Weight = productModel.Weight;
                product.Color = productModel.Color;
                product.Dimension = productModel.Dimension;
                product.WLAN = productModel.WLAN;
                product.Bluetooth = productModel.Bluetooth;
                product.GPS = productModel.GPS;
                product.USB = productModel.USB;
                product.BatteryType = productModel.BatteryType;
                product.Sensors = productModel.Sensors;
                product.Video = productModel.Video;
                product.NetworkTechnology = productModel.NetworkTechnology;
                product.SIM = productModel.SIM;
                product.ReleaseYear = productModel.ReleaseYear;
                product.SoldItems = 0;
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

                //context.SaveChanges();

                return true;
            }
        }

        public Boolean DeleteProduct(int id)
        {
            using(var context = new MobileBazaarDBEntities())
            {
                var product=context.tbl_Product.FirstOrDefault(x => x.ProductID == id);

                if (product != null)
                {
                    context.tbl_Product.Remove(product);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<ProductModel> SearchProducts(String text)
        {
            using(var context = new MobileBazaarDBEntities())
            {
                var list = context.tbl_Product.
                    Select(x => new ProductModel()
                    {
                        ProductID = x.ProductID,
                        ProductName = x.ProductName,
                        Brand = x.Brand,
                        Warranty = x.Warranty,
                        Quantity = x.Quantity,
                        SoldItems = x.SoldItems,
                        Price = x.Price,
                        ImagePath = x.ImagePath,
                        DisplayType = x.DisplayType,
                        DisplaySize = x.DisplaySize,
                        Resolution = x.Resolution,
                        SelfieCamera = x.SelfieCamera,
                        MainCamera = x.MainCamera,
                        OperatingSystem = x.OperatingSystem,
                        Chipset = x.Chipset,
                        CPU = x.CPU,
                        GPU = x.GPU,
                        ROM = x.ROM,
                        RAM = x.RAM,
                        Weight = x.Weight,
                        Color = x.Color,
                        Dimension = x.Dimension,
                        WLAN = x.WLAN,
                        Bluetooth = x.Bluetooth,
                        GPS = x.GPS,
                        USB = x.USB,
                        BatteryType = x.BatteryType,
                        Sensors = x.Sensors,
                        Video = x.Video,
                        NetworkTechnology = x.NetworkTechnology

                    }).Where(x=>x.ProductName.Contains(text)||x.Brand.Contains(text)).ToList();

                return list;

            }
        }

        public void EditProductQuantity(int pId, int quantity)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var product = context.tbl_Product.FirstOrDefault(x => x.ProductID == pId);
                product.SoldItems += quantity;
                context.SaveChanges();
            }
        }
    }
}
