using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class PackageController : Controller
    {
        PackageService service;

        public PackageController(PackageService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var data = service.Get();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var obj = new PackageDTO();

            obj.TrainerId = id;

            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(PackageDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = service.Create(obj);

                if (res)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = service.Get(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PackageDTO obj)
        {
            if (ModelState.IsValid)
            {
                var res = service.Update(obj);

                if (res)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = service.Get(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(int id, string Decision)
        {
            if (Decision.Equals("Yes"))
            {
                service.Delete(id);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}