using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_DBFirst_Demo.Models;

namespace MVC_DBFirst_Demo.Controllers
{
    public class CategoryController:Controller
    {

        private readonly AppDbContext _context;
        public CategoryController( AppDbContext context)
        {
            _context=context;

        }

        public IActionResult Index()
        {

            var data=_context.categories;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Category newcategory)
        {
            if(ModelState.IsValid)
            {
                _context.categories.Add(newcategory);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data=_context.categories.Find(id);
    return View(data); 
        }

        [HttpPost]
        public IActionResult Edit(int id, Category updatecat)

        {

            var data=_context.categories.FirstOrDefault(c=>c.CatId==id);
            if(data==null)
            {
                return BadRequest();
            }
           

    

             if(ModelState.IsValid)
            {
                 _context.categories.Update(updatecat);
                _context.SaveChanges();

                return RedirectToAction("Index");
                
            }

            return View(updatecat);

        }


        public IActionResult Details(int id)
        {
            var data=_context.categories.Find(id);

            return View(data);
        }

[HttpGet]
        public IActionResult Delete(int id)
        {
            var data=_context.categories.Find(id);
            return View(data);

        }


        [HttpPost]
        public IActionResult Delete( Category category)
        {
            if(ModelState.IsValid)
            {   System.Console.WriteLine(category.CatId);
                _context.categories.Remove(category);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(category);
        }
    }
}