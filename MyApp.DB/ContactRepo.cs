using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DB
{
    public class ContactRepo
    {
        public Boolean AddContact(String email, String message)
        {
            using (var context = new MobileBazaarDBEntities())
            {
                tbl_Contact cs = new tbl_Contact()
                {
                    Email = email,
                    Message = message
              
                };

                context.tbl_Contact.Add(cs);
                context.SaveChanges();

                return true;
            }

        }

        public List<ContactModel> GetAllContacts()
        {
            using (var context = new MobileBazaarDBEntities())
            {
                var list = context.tbl_Contact.
                    Select(x => new ContactModel()
                    {
                            ContactID = x.ContactID,
                            Email = x.Email,
                            Message = x.Message
                    }).ToList();

                return list;
            }
        }

        public void DeleteContact(int id)
        {
            using(var context = new MobileBazaarDBEntities())
            {
                var p = context.tbl_Contact.FirstOrDefault(x => x.ContactID == id);
                context.tbl_Contact.Remove(p);
                context.SaveChanges();
            }
        }

        /*public List<ContactModel> GetContact()
        {

        }*/


    }
}
