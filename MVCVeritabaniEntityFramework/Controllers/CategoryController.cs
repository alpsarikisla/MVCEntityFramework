using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCVeritabaniEntityFramework.Models;

namespace MVCVeritabaniEntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        // GET: Category
        public ActionResult Index()
        {
            List<Categories> categories = db.Categories.ToList();
            //List<Categories> categories = (from c in db.Categories select c).ToList();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        
       [HttpPost]
        public ActionResult Create(Categories cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Add(cat);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult Create(string CategoryName, string description)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Categories cat = new Categories();
        //            cat.CategoryName = CategoryName;
        //            cat.Description = description;
        //            db.Categories.Add(cat);
        //            db.SaveChanges();
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id ==  null)
            {
                return RedirectToAction("Index");
            }

            Categories cat = db.Categories.Find(id);
            if (cat == null)
            {
                return RedirectToAction("Index");
            }

            return View(cat);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Categories cat)
        {
            try
            {
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Categories cat = db.Categories.Find(id);
            if (cat == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
        
    }
}
