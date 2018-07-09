using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models;
using System.IO;

namespace AdminPanel.Controllers
{
    public class MediaController : Controller
    {
        // GET: Media
        public ActionResult Index()
        {
            return View();
        }

        #region PhotoGallery

        public ActionResult PhotosList()
        {
            MasterContext mContext = new MasterContext();
            var photosList = mContext.PhotoGallery.ToList();
            return View(photosList);
        }
        public ActionResult PhotosAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                owl_PhotoGallery photoGallety = new owl_PhotoGallery();

                return View(photoGallety);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var photoGalletyModel = dbContext.PhotoGallery.First(q => q.Id == id);

                return View(photoGalletyModel);
            }

        }

        [HttpPost]
        public ActionResult PhotosAddOrEdit(owl_PhotoGallery model)
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
                    MasterContext photoGalleryadd = new MasterContext();

                    owl_PhotoGallery photoGallety = new owl_PhotoGallery()
                    {
                        Name = model.Name,
                        Info = model.Info,
                        Image = model.Image,



                    };

                    photoGalleryadd.PhotoGallery.Add(photoGallety);
                    photoGalleryadd.SaveChanges();
                    ViewBag.message = "Resim Eklendi Eklendi";
                    ModelState.Clear();
                    return Redirect("/Media/PhotosList");

                }
                else
                {
                    MasterContext photoGalleryadd = new MasterContext();

                    photoGalleryadd.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    photoGalleryadd.SaveChanges();

                    return Redirect("/Media/PhotosList");

                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion

        #region Haberler
        public ActionResult NewsList()
        {
            MasterContext mContext = new MasterContext();
            var newsList = mContext.News.ToList();
            return View(newsList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                News haber = new News();

                return View(haber);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var newsModel = dbContext.News.First(q => q.Id == id);

                return View(newsModel);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(News model)
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
                    MasterContext newsadd = new MasterContext();

                    News haber = new News()
                    {
                        Name = model.Name,
                        Image = model.Image,
                        Info = model.Info,
                        ShortDescription = model.ShortDescription,

                    };

                    newsadd.News.Add(haber);
                    newsadd.SaveChanges();
                    ViewBag.message = "Yeni Haber Eklendi";
                    ModelState.Clear();
                    return Redirect("/Media/NewsList");

                }
                else
                {
                    MasterContext newsadd = new MasterContext();

                    newsadd.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    newsadd.SaveChanges();

                    return Redirect("/Media/NewsList");

                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        public ActionResult NewsDelete(int id = 0)
        {
            MasterContext dbContext = new MasterContext();

            var DeleteVal = dbContext.News.Where(q => q.Id == id).FirstOrDefault();
            dbContext.News.Remove(DeleteVal);
            dbContext.SaveChanges();
            return Redirect("/Media/NewsList");

        }
        #endregion

    }
}