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
                return RedirectToAction("Index");
            }
           
            return View(c);
        }
    }
}
