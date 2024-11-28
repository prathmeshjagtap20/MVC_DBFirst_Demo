using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_DBFirst_Demo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MVC_DBFirst_Demo.Controllers
{
    public class ProductController:Controller
    {

        private readonly AppDbContext _context;
        public ProductController( AppDbContext context)
        {
            _context=context;

        }

        public IActionResult Index()
        {

            var data=_context.products;
            return View(data);
        }

        [HttpGet]

        public IActionResult Create()
        {
            var categories=_context.categories.ToList().Select(x=>new SelectListItem{
                Value=x.CatId.ToString(),
                Text=x.CatName
            });
            ViewBag.category=categories;
            return View();
        }

        [HttpPost]

        public IActionResult Create(Product newcategory)
        {
            if(ModelState.IsValid)
            {
                _context.products.Add(newcategory);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data=_context.products.Find(id);
    return View(data); 
        }

        [HttpPost]
        public IActionResult Edit(int id, Product updatecat)

        {

            // var data=_context.products.FirstOrDefault(c=>c.ProdId==id);
            // if(data==null)
            // {
            //     return BadRequest();
            // }
           

    

             if(ModelState.IsValid)
            {
                 _context.products.Update(updatecat);
                _context.SaveChanges();

                return RedirectToAction("Index");
                
            }

            return View(updatecat);

        }


        public IActionResult Details(int id)
        {
            var data=_context.products.Find(id);

            return View(data);
        }

[HttpGet]
        public IActionResult Delete(int id)
        {
            var data=_context.products.Find(id);
            return View(data);

        }


        // [HttpPost]
        // public IActionResult Delete( Product pro)
        // {
        //     if(ModelState.IsValid)
        //     {   System.Console.WriteLine(pro.ProdId);
        //         _context.categories.Remove(pro);
        //         _context.SaveChanges();

        //         return RedirectToAction("Index");
        //     }


        //     return View(pro);
        // }
    }
}