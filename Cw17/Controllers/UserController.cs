using Cw17.Models.Contract;
using Cw17.Models.Entities;
using Cw17.Models.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Cw17.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public IActionResult List()
        {
            string fullName = HttpContext.Session.GetString("FullName");
            ViewData["FullName"] = fullName;

            List<User> users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(string fullName, string userName, string password, string email)
        {
            _userService.Register(fullName, userName, password, email);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            User user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(int id, string fullName, string userName, string email, string password)
        {
            _userService.Update(id, fullName, userName, email, password);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var user = _userService.Login(username, password);

                HttpContext.Session.SetString("Username", user.UserName);

                HttpContext.Session.SetString("FullName", user.FullName);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); 
            HttpContext.Session.Clear(); 
            return RedirectToAction("Login");
        }

    }
}
