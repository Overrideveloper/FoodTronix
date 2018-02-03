using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTronix.Models.Context;
using FoodTronix.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodTronix.Controllers
{
    public class AccountController : Controller
    {
        private readonly FoodTronixContext _foodtronix;
        public AccountController(FoodTronixContext foodTronix)
        {
            _foodtronix = foodTronix;
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _user = new User
                    {
                        Username = user.Username,
                        Hash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.Hash)
                    };
                    _foodtronix.User.Add(_user);
                    _foodtronix.SaveChanges();
                    var userObj = JsonConvert.SerializeObject(_user);
                    HttpContext.Session.SetString("User", userObj);
                    ModelState.Clear();
                    return RedirectToAction("Index", "Restaurant");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _user = _foodtronix.User.Where(u => u.Username == user.Username).SingleOrDefault();
                    var hash = BCrypt.Net.BCrypt.EnhancedVerify(user.Hash, _user.Hash);
                    if (hash == true)
                    {
                        var userObj = JsonConvert.SerializeObject(_user);
                        HttpContext.Session.SetString("User", userObj);
                        ModelState.Clear();
                        return RedirectToAction("Index", "Restaurant");
                    }
                    else
                    {
                        ModelState.AddModelError("hash_err", "Username or password incorrect!");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}