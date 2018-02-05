using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTronix.Models.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodTronix.Controllers.Shop
{
    public class ShopController : Controller
    {
        public FoodTronixContext foodTronix;

        public ShopController(FoodTronixContext _foodTronix)
        {
            foodTronix = _foodTronix;
        }

        [Route("shop")]
        public IActionResult Index()
        {
            return View(foodTronix.Meal.OrderBy(s => s.Name).ToList());
        }

        [Route("shop/dishes/{id}")]
        public IActionResult Dishes(int id)
        {
            ViewData["Meal"] = GetMealName(id);
            return View(foodTronix.Dish.Where(s => s.MealID == id).OrderBy(s => s.Name).ToList());
        }

        public string GetMealName(int id)
        {
            var model = foodTronix.Meal.Find(id);
            return model.Name.ToUpper();
        }

        [Route("shop/add/{id}")]
        public IActionResult AddPage(int id)
        {
            ViewData["uid"] = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
            return View(foodTronix.Dish.Find(id));
        }
    }
}