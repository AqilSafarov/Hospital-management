using Labostic.Models;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class SettingController : Controller
    {
        private readonly ISetting _setting;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingController(ISetting setting, IWebHostEnvironment webHostEnvironment)
        {
            _setting = setting;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Setting";

            List<Setting> setting1 = _setting.GetSettings();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(setting1.Count / dataPage);

           List<Setting> setting2 = setting1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = setting1.Count;
            return View(setting2);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Setting model)
        {
            if (ModelState.IsValid)
            {

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");

                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");

                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.LogoNav = fileName;
                }



                _setting.CreateSetting(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? settingId)
        {
            if (settingId == null && settingId <= 0)
            {
                return NotFound();
            }
            Setting setting = _setting.GetSettingPrm(settingId);
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (!((model.ImageFile.ContentType == "image/png")))
                    {
                        ModelState.AddModelError("", "You can upload only png file");
                        return View(model);
                    }
                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload 2mb file");
                        return View(model);
                    }
                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.LogoNav = fileName;
                }
                _setting.UpdateSetting(model);


                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Delete(int settingId)
        {
            _setting.DeleteSetting(settingId);

            return RedirectToAction("Index");
        }
    }
}
