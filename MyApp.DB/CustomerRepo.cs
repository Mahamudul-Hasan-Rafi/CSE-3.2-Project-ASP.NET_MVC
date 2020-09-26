using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Model;

namespace MyApp.DB
{
    public class CustomerRepo
    {
        public int AddEmployee(CustomerModel model)
        {
            using(var context=new MobileBazaarDBEntities())
            {
                tbl_Customer cs = new tbl_Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Password = model.Password
                };

                context.tbl_Customer.Add(cs);
                context.SaveChanges();

                return cs.CustomerID;
            }
            
        }

        public int CheckAuthenticity(String email, String password)
        {
            using(var context=new MobileBazaarDBEntities())
            {
                tbl_Customer customer = context.tbl_Customer.Where(x => x.Email == email && x.Password == password).FirstOrDefault();

                if (customer != null)
                    return customer.CustomerID;
                else
                    return 0;
            }
  
        }

        public CustomerModel GetCustomer(int id)
        {
            using(var context = new MobileBazaarDBEntities())
            {
                tbl_Customer customer=context.tbl_Customer.Where(x => x.CustomerID == id).FirstOrDefault();

                CustomerModel cm = new CustomerModel()
                {
                    CustomerID = customer.CustomerID,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Password = customer.Password
                };

                return cm;
            }
        }

        public CustomerModel UpdateModel(int id, CustomerModel cm)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var user_profile = context.tbl_Customer.FirstOrDefault(x=>x.CustomerID==id);

                user_profile.Email = cm.Email;
                user_profile.FirstName = cm.FirstName;
                user_profile.LastName = cm.LastName;
                user_profile.Phone = cm.Phone;
                user_profile.Password = cm.Password;

                context.SaveChanges();

                CustomerModel customerModel = new CustomerModel()
                {
                    FirstName = user_profile.FirstName,
                    LastName = user_profile.LastName,
                    Phone = user_profile.Phone,
                    Email = user_profile.Email,
                    Password = user_profile.Password
                };

                return customerModel;
            }
        }
    }
}
