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
            return View(lCategoryDTO);
        }
    }
}