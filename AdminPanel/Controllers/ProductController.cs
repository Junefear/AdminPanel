using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models;
using System.IO;


namespace AdminPanel.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        #region Ürün Grupları

        public ActionResult Product_Group_List()
        {
            MasterContext mContext = new MasterContext();
            var Product_Group = mContext.Product_Gruop.ToList();
            return View(Product_Group);
        }
        public ActionResult Product_GroupAddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                HotProduct_Group Product_Group = new HotProduct_Group();

                return View(Product_Group);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var Product_Group = dbContext.Product_Gruop.First(q => q.Id == id);

                return View(Product_Group);
            }

        }

        [HttpPost]
        public ActionResult Product_GroupAddOrEdit(HotProduct_Group model)
        {

            try
            {
                //if (model.ImageFile.ContentLength > 0)
                //{
                //    string _filename = Path.GetFileName(model.ImageFile.FileName);
                //    string _path = Path.Combine(Server.MapPath("/assets/Uploads/"), _filename);
                //    model.ImageFile.SaveAs(_path);
                //    model.Image = _filename;
                //}

                if (model.Id == 0)
                {
                    MasterContext Product_GroupAdd = new MasterContext();

                    HotProduct_Group hotProduct_group = new HotProduct_Group()
                    {
                        Code = model.Code,
                        Name = model.Name,
                        Info = model.Info,

                    };

                    Product_GroupAdd.Product_Gruop.Add(hotProduct_group);
                    Product_GroupAdd.SaveChanges();
                    ViewBag.message = "Yeni Haber Eklendi";
                    ModelState.Clear();
                    return Redirect("/Product/Product_Group_List");

                }
                else
                {
                    MasterContext Product_Group = new MasterContext();

                    Product_Group.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    Product_Group.SaveChanges();

                    return Redirect("/Product/Product_Group_List");

                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        public ActionResult Product_Group_Delete(int id = 0)
        {
            MasterContext dbContext = new MasterContext();

            var DeleteVal = dbContext.Product_Gruop.Where(q => q.Id == id).FirstOrDefault();
            dbContext.Product_Gruop.Remove(DeleteVal);
            dbContext.SaveChanges();
            return Redirect("/Product/Product_Group_List");

        }

        #endregion

        #region Ürünler

        public ActionResult Product_List()
        {
            MasterContext mContext = new MasterContext();
            var Product = mContext.Product.ToList();
            return View(Product);
        }
        public ActionResult Product_AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                HotProduct Product = new HotProduct();

                return View(Product);
            }
            else
            {
                MasterContext dbContext = new MasterContext();
                var Product = dbContext.Product.First(q => q.Id == id);

                return View(Product);
            }

        }

        [HttpPost]
        public ActionResult Product_AddOrEdit(HotProduct model)
        {

            try
            {

                if (model.Id == 0)
                {
                    MasterContext Product_Add = new MasterContext();

                    HotProduct hotProduct = new HotProduct()
                    {
                        Code = model.Code,
                        Name = model.Name,
                        Stok_No = model.Stok_No,
                        Fiyat_No = model.Fiyat_No,
                        Adet_No = model.Adet_No,
                        Info = model.Info,
                        rlt_Product_Group_Id = model.rlt_Product_Group_Id,


                    };

                    Product_Add.Product.Add(hotProduct);
                    Product_Add.SaveChanges();
                    ViewBag.message = "Yeni Ürün Eklendi";
                    ModelState.Clear();
                    return Redirect("/Product/Product_List");

                }
                else
                {
                    MasterContext Product = new MasterContext();

                    Product.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    Product.SaveChanges();

                    return Redirect("/Product/Product_List");

                }

            }
            catch (Exception)
            {

                throw;
            }


        }
        public ActionResult Product_Delete(int id = 0)
        {
            MasterContext dbContext = new MasterContext();

            var DeleteVal = dbContext.Product.Where(q => q.Id == id).FirstOrDefault();
            dbContext.Product.Remove(DeleteVal);
            dbContext.SaveChanges();
            return Redirect("/Product/Product_List");

        }

        #endregion
    }
}