using Newtonsoft.Json;
using OnlineShopingStore.DAL;
using OnlineShopingStore.Models;
using OnlineShopingStore.Repository;
using System;
using System.Collections.Generic;
//using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopingStore.Controllers
{
    public class AdminController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        //list category added
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();

            foreach(var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            return list;
            
        }

        // GET: Admin click droit sur la méthode
        public ActionResult Dashboard()
        {
            return View();
        }

        
        public ActionResult Categories()
        {
            //List<Tbl_Category> allCategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecordsIQueryable().Where(i => i.IsDelete == false).ToList();
            //return View(allCategories);
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetCaegory());
        }
        public ActionResult CategorieEdit(int categoryId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstOrDefault(categoryId));
        }


        public ActionResult UpdateCategory(int categoryId)
        {
            CategoryDetail cd;
            if (categoryId != null)
            {
                cd = JsonConvert.DeserializeObject<CategoryDetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Tbl_Category>().GetFirstOrDefault(categoryId)));
            }
            else
            {
                cd = new CategoryDetail();
            }
            return View("UpdateCategory",cd);
        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }

        public ActionResult Product()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetProduct());
        }

        public ActionResult ProductEtdit(int productId)
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Product>().GetFirstOrDefault(productId));
        }

        //to save in databases
        [HttpPost]
        public ActionResult ProductEtdit(Tbl_Product tbl, HttpPostedFileBase file)
        {
            //to upload file in database
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/PrductImg/"), pic);
                //file is upload
                file.SaveAs(path);
            }
            //just save file is pass from "Productedit"
            tbl.ProductImage = file != null? pic: tbl.ProductImage;

            tbl.ModifierDate = DateTime.Now;
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Update(tbl);
            return RedirectToAction("Product");
       
        }
        [HttpPost]
        public ActionResult CategorieEdit(Tbl_Category tbl)
        {
            _unitOfWork.GetRepositoryInstance<Tbl_Category>().Update(tbl);
            return RedirectToAction("Categories");
        }


        //Add product
        public ActionResult ProductAdd()
        {
            //use method getcategoy() in product
            ViewBag.CategoryList = GetCategory();
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Tbl_Product tbl, HttpPostedFileBase file)
        {
            //to upload file in database
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/PrductImg/"), pic);
                //file is upload
                file.SaveAs(path);
            }
            tbl.ProductImage = pic;

            //create date in database
            tbl.CreateDate = DateTime.Now;
            //add new product in database
            _unitOfWork.GetRepositoryInstance<Tbl_Product>().Add(tbl);
            //redirected page
            return RedirectToAction("Product");
        }

    }
}