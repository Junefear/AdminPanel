using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models;
using System.IO;

namespace AdminPanel.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["user"] != null) return Redirect("/");
            return View();

        }

        [HttpPost]
        public ActionResult Index( owl_Account user)
        {
            MasterContext dbContext = new MasterContext();


            if (user.UserName == "admin" && user.Password == "2651344")
            {
                Session["user"] = user.UserName;
                Session.Timeout = 10;
                return RedirectToAction("Index", "Home");
            }

            if (string.IsNullOrEmpty(user.UserName)) { ViewBag.returnMessageRegister = "Kullanıcı Adı Giriniz"; return View(); }
            if (user.Password.Length < 6) { ViewBag.returnMessageRegister = "Şifreniz en az 6 haneli olmalıdır !"; return View(); }
            if (Session["user"] != null) return Redirect("/");

            owl_Account dbUser = dbContext.Account.Where(q => q.UserName == user.UserName && q.Password == user.Password).FirstOrDefault();

            if (dbUser == null && dbUser.Password == null )
            {              

                ViewBag.returnMessageLogin =  "Kullanıcı Adı veya Şifre Yanlış";
                ModelState.Clear();

                return View();

            }
            else
            {
                Session["userId"] = dbUser.Id;
                Session["user"] = dbUser.UserName;
                
                return RedirectToAction("Index", "Home");
               
            }

          


        }

        public ActionResult LogOut()
        {
            Session["id"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Index", "Account");           
        }



        public ActionResult AccountList()
        {
            MasterContext mContext = new MasterContext();
            var accountList = mContext.Account.ToList();
            return View(accountList);
        }
        public ActionResult AccountAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                owl_Account account = new owl_Account();

                return View(account);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var accountModel = dbContext.Account.First(q => q.Id == id);

                return View(accountModel);
            }
        }

        [HttpPost]
        public ActionResult AccountAddOrEdit(owl_Account model)
        {
            try
            {

                if (model.Id == 0)
                {
                    MasterContext accountadd = new MasterContext();

                    owl_Account account = new owl_Account()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        UserName = model.UserName,
                        Password = model.Password,

                    };

                    accountadd.Account.Add(account);
                    accountadd.SaveChanges();
                    ViewBag.message = "Kullanıcı Bilgisi Eklendi";
                    ModelState.Clear();
                    return Redirect("/Account/AccountList");

                }
                else
                {
                    MasterContext accountadd = new MasterContext();

                    accountadd.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    accountadd.SaveChanges();

                    return Redirect("/Account/AccountList");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}




