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

        public IActionResult Index()
        {
            ViewData["meals"] = foodTronix.Meal.ToArray().Length;
            return View();
        }
    }
}