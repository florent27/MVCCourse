using BulkyDonetCore30.Data;
using BulkyDonetCore30.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulkyDonetCore30.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext mDb;
        public CategoryController(ApplicationDBContext db)
        {
            mDb = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> lCategoryList = mDb.Categories;
            return View(lCategoryList);
        }
    }
}
