using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AuthController : Controller
    {
        UserService service;
        PackageService packageService;

        public AuthController(UserService service,
                      PackageService packageService)
        {
            this.service = service;

            this.packageService = packageService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new RegDTO() { });
        }

        [HttpPost]
        public IActionResult Registration(RegDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = service.Create(obj);

                if (res)
                {
                    return RedirectToAction("Login");
                }
            }

            return View(obj);
        }

        public IActionResult Dashboard()
        {
            ViewBag.Uname = HttpContext.Session.GetString("uname");

            var data = packageService.Get();

            return View(data);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDTO() { });
        }

        [HttpPost]
        public IActionResult Login(LoginDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = service.Authenticate(obj);

                if (res)
                {
                    HttpContext.Session.SetString("uname", obj.Username);

                    return RedirectToAction("Dashboard");
                }

                TempData["Msg"] = "Username or Password Invalid";
            }

            return View(obj);
        }





        public IActionResult Profile()
        {
            var uname = HttpContext.Session.GetString("uname");

            if (uname == null)
            {
                return RedirectToAction("Login");
            }

            var user = service.Get(uname);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }


        [HttpGet]
        public IActionResult EditProfile()
        {
            var uname = HttpContext.Session.GetString("uname");

            var data = service.Get(uname);

            var obj = new UserDTO()
            {
                UserId = data.UserId,
                Name = data.Name,
                Phone = data.Phone,
                Email = data.Email,
                Username = data.Username,
                Password = data.Password
            };

            return View(obj);
        }


        [HttpPost]
        public IActionResult EditProfile(UserDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = service.Update(obj);

                if (res)
                {
                    HttpContext.Session.SetString("uname", obj.Username);

                    return RedirectToAction("Profile");
                }
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult DeleteProfile()
        {
            var uname = HttpContext.Session.GetString("uname");

            var user = service.Get(uname);

            return View(user);
        }



        [HttpPost]
        public IActionResult DeleteProfile(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                service.Delete(id);

                HttpContext.Session.Clear();

                return RedirectToAction("Login");
            }

            return RedirectToAction("Profile");
        }


     






        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}