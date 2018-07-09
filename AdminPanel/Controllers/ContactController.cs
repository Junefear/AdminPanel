using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models;
using System.IO;

namespace AdminPanel.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactList()
        {
            MasterContext mContext = new MasterContext();
            var contactList = mContext.Contact.ToList();
            return View(contactList);
        }
        public ActionResult ContactAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                owl_ContactInformations contactInformations = new owl_ContactInformations();

                return View(contactInformations);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var contactModel = dbContext.Contact.First(q => q.Id == id);

                return View(contactModel);
            }
        }

        [HttpPost]
        public ActionResult ContactAddOrEdit(owl_ContactInformations model)
        {
            try
            {             

                if (model.Id == 0)
                {
                    MasterContext contactadd = new MasterContext();

                    owl_ContactInformations contactInformations = new owl_ContactInformations()
                    {
                        Info= model.Info,
                        Address=model.Address,
                        Phone_Name=model.Phone_Name,
                        Phone_No=model.Phone_No,
                        Fax=model.Fax,                       
                        Mail_Name=model.Mail_Name,
                        Mail_Address = model.Mail_Address,


                    };

                    contactadd.Contact.Add(contactInformations);
                    contactadd.SaveChanges();
                    ViewBag.message = "İletişim Bilgisi Eklendi";
                    ModelState.Clear();
                    return Redirect("/Contact/ContactList");

                }
                else
                {
                    MasterContext contactadd = new MasterContext();

                    contactadd.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    contactadd.SaveChanges();

                    return Redirect("/Contact/ContactList");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}