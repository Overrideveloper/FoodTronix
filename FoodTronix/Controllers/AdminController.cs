using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTronix.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace FoodTronix.Controllers
{
    public class AdminController : Controller
    {
        public readonly FoodTronixContext foodTronix;
        public AdminController(FoodTronixContext _foodTronix)
        {
            foodTronix = _foodTronix;
        }

        [Route("admin")]
        public IActionResult Index()
        {
            ViewData["meals"] = foodTronix.Meal.ToArray().Length;
            ViewData["dishes"] = foodTronix.Dish.ToArray().Length;
            ViewData["users"] = foodTronix.User.ToArray().Length;
            return View();
        }
    }
}