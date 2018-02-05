using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FoodTronix.Models.Context;
using FoodTronix.Models.Entities;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FoodTronix.Controllers
{
    public class MealController : Controller
    {
        private readonly FoodTronixContext foodTronix;
        private readonly IHostingEnvironment environment;

        public MealController(FoodTronixContext _foodTronix, IHostingEnvironment _environment)
        {
            foodTronix = _foodTronix;
            environment = _environment;
        }

        [Route("meal")]
        // GET: Meal
        public ActionResult Index()
        {
            var meal = foodTronix.Meal.ToList().OrderBy(s => s.Name);
            return View(meal);
        }

        [Route("meal/details/{id:int}")]
        // GET: Meal/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var meal = await foodTronix.Meal.FindAsync(id);
            return View(meal);
        }
        
        // GET: Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Meal meal, IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                ModelState.AddModelError("null_img", "File not selected");
            }
            else
            {
                var fileinfo = new FileInfo(file.FileName);
                var filename = DateTime.Now.ToFileTime() + fileinfo.Extension;
                var uploads = Path.Combine(environment.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                if (ModelState.IsValid)
                {
                    meal.Image = filename;
                    foodTronix.Meal.Add(meal);
                    foodTronix.SaveChanges();
                    TempData["success"] = "Meal added!";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        
        // GET: Meal/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await foodTronix.Meal.FindAsync(id));
        }

        // POST: Meal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Meal meal, IFormFile file)
        {
            if(id != meal.ID)
            {
                return NotFound();
            }
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("null_img", "File not selected");
            }
            else
            {
                var fileinfo = new FileInfo(file.FileName);
                var filename = DateTime.Now.ToFileTime() + fileinfo.Extension;
                var uploads = Path.Combine(environment.WebRootPath, "uploads");
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        meal.Image = filename;
                        foodTronix.Update(meal);
                        await foodTronix.SaveChangesAsync();
                    }
                    catch(DbUpdateConcurrencyException)
                    {
                        if (!MealExists(meal.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    TempData["success"] = "Meal modified!";
                    return RedirectToAction("Index");
                }
            }
            return View(meal);
        }
        
        // GET: Meal/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var meal = await foodTronix.Meal.FindAsync(id);
            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var meal = await foodTronix.Meal.FindAsync(id);
                foodTronix.Meal.Remove(meal);
                await foodTronix.SaveChangesAsync();
                TempData["success"] = "Meal removed!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private bool MealExists(int id)
        {
            return foodTronix.Meal.Any(e => e.ID == id);
        }
    }
}