using AdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class DynamicController : Controller
    {
        // GET: Dynamic
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DynamicList()
        {
            MasterContext mContext = new MasterContext();
            var dynamicList = mContext.DynamicPage.ToList();
            return View(dynamicList);
        }
        public ActionResult DynamicAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                owl_DynamicPage dynamicPage = new owl_DynamicPage();

                return View(dynamicPage);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var dynamicModel = dbContext.DynamicPage.First(q => q.Id == id);

                return View(dynamicModel);
            }
        }

        [HttpPost]
        public ActionResult DynamicAddOrEdit(owl_DynamicPage model)
        {
            try
            {

                if (model.Id == 0)
                {
                    MasterContext dynamicadd = new MasterContext();

                    owl_DynamicPage dynamicPages = new owl_DynamicPage()
                    {
                        Name = model.Name,
                        Info = model.Info,      

                    };

                    dynamicadd.DynamicPage.Add(dynamicPages);
                    dynamicadd.SaveChanges();
                    ViewBag.message = "Dynamic Sayfa Eklendi";
                    ModelState.Clear();
                    return Redirect("/Dynamic/DynamicList");

                }
                else
                {
                    MasterContext synamicadd = new MasterContext();

                    synamicadd.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    synamicadd.SaveChanges();

                    return Redirect("/Dynamic/DynamicList");

                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}