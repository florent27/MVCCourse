using BulkyDonetCore30.Data;
using BulkyDonetCore30.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyDonetCore30.CategoryDTO;

namespace BulkyDonetCore30.Controllers
{
    public class CategoryController : Controller
    {
        // private
        private readonly ApplicationDBContext mDb;

        public CategoryController(ApplicationDBContext db)
        {
            mDb = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> lCategoryList = mDb.Categories;
            List<CategoryDTO.CategoryDTO> lCategoryDTO = new List<CategoryDTO.CategoryDTO>();
            foreach (var item in lCategoryList.ToList())
            {
                lCategoryDTO.Add(new CategoryDTO.CategoryDTO(item.Name, item.DisplayOrder));
            }
            lCategoryDTO.Clear();
            lCategoryDTO = lCategoryList.Select(c => new CategoryDTO.CategoryDTO(c.Name, c.DisplayOrder)).ToList();

            return View(lCategoryList);
        }

        // Get
        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Cannot Match Name");
            }
            if (ModelState.IsValid)
            {
                mDb.Categories.Add(obj);
                // Post to db
                mDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var lCategory = mDb.Categories.Find(id);
            //var lCategorye = mDb.Categories.FirstOrDefault(i => i.Id == id);
            if (lCategory == null)
            {
                return NotFound();
            }
            return View(lCategory);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Cannot Match Name");
            }
            if (ModelState.IsValid)
            {
                mDb.Categories.Add(obj);
                // Post to db
                mDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}