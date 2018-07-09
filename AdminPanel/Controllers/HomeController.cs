using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models;
using System.IO;

namespace AdminPanel.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["user"] == null) 
            {
                return Redirect("~/Homw/Index");
            }
            else
            {
                return View();
            }
        }     

        #region Home Slider
        public ActionResult SlidersList()
        {
            MasterContext mContext = new MasterContext();
            var slidersList = mContext.HomeSlider.ToList();
            return View(slidersList);
        }
        public ActionResult SliderAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                owl_HomeSlider slider = new owl_HomeSlider();

                return View(slider);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var sliderModel = dbContext.HomeSlider.First(q => q.Id == id);

                return View(sliderModel);
            }

        }

        [HttpPost]
        public ActionResult SliderAddOrEdit(owl_HomeSlider model)
        {

            try
            {
                if (model.ImageFile.ContentLength > 0)
                {
                    string _filename = Path.GetFileName(model.ImageFile.FileName);
                    string _path = Path.Combine(Server.MapPath("/assets/Uploads/"), _filename);
                    model.ImageFile.SaveAs(_path);
                    model.Image = _filename;
                }

                if (model.Id == 0)
                {
                    MasterContext slideradd = new MasterContext();

                    owl_HomeSlider homeSlider = new owl_HomeSlider()
                    {
                        SliderName = model.SliderName,
                        SliderInfo = model.SliderInfo,
                        Image= model.Image,

                        

                    };

                    slideradd.HomeSlider.Add(homeSlider);
                    slideradd.SaveChanges();
                    ViewBag.message = "Yeni Slider Eklendi";
                    ModelState.Clear();
                    return Redirect("/Home/SlidersList");

                }
                else
                {
                    MasterContext slideradd = new MasterContext();

                    slideradd.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    slideradd.SaveChanges();

                    return Redirect("/Home/SlidersList");

                }

            }
            catch (Exception)
            {

                throw;
            }


        }
       
        #endregion
        

    }

}