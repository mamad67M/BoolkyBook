using BoolkyBook_app_web.Data;
using BoolkyBook_app_web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoolkyBook_app_web.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategorieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> list = _db.Categories;
            return View(list);
        }

        // Get
        [HttpGet]
        public IActionResult Create()
        {  
            return View();
        }
        // post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category c)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(c);
                _db.SaveChanges();
                TempData["success"] = "Catégorie créée avec succès";
                return RedirectToAction("Index");
            }
           
            return View(c);
        }
        // Get Edit
        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category c)
        {    
            if (ModelState.IsValid)
            {
                _db.Categories.Update(c);
                _db.SaveChanges();
                TempData["success"] = "Catégorie modifiée avec succès";

                return RedirectToAction("Index");
            }
            return View(c);
        }

        // Get Edit
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePost(int ? id)
        {
            var obj = _db.Categories.Find(id);
            if ( obj == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Catégorie supprimée avec succès";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
