using Labostic.Models;
using Labostic.Services;
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

    public class ResearchController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IResearch _research;
        private readonly IResearchCategory _researchCategory;
        private readonly IResearchSquar _researchSquar;
        private readonly ISocial _social;
        private readonly IWriter _writer;
        private readonly IWriterToResearch _writerToResearch;

        public ResearchController(AppDbContext context, IWebHostEnvironment webHostEnvironment,IResearch research, IResearchCategory researchCategory, IResearchSquar researchSquar,ISocial social,IWriter writer,IWriterToResearch writerToResearch)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _research = research;
            _researchCategory = researchCategory;
            _researchSquar = researchSquar;
            _social = social;
            _writer = writer;
            _writerToResearch = writerToResearch;
        }
        public IActionResult Index(int page = 1)
        {

            ViewBag.Active = "Research";
            List<Research> research1 = _research.GetResearchs();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(research1.Count / dataPage);

            List<Research> research2 = research1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = research1.Count;
            return View(research2);
        }

        public IActionResult Create()
        {
            ViewBag.Writer = _writer.GetWriters();
            ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Research model)
        {
            if (ModelState.IsValid)
            {
                List<WriterToResearch> newWriterToResearch = model.WriterToResearch;
                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif" ))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.Writer = _writer.GetWriters();
                        ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();
                        return View(model);
                    }
                  
                    if (model.ImageFile.Length > 2097152 )
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.Writer = _writer.GetWriters();
                        ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();
                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    model.Image = fileName;
                }
             

                //model.WriterToResearch = null;
                _research.CreateResearch(model);
                await _context.SaveChangesAsync();
                foreach (var item in newWriterToResearch)
                {
                    if (item.WriterId > 0 && item.Writer != null)
                    {
                        WriterToResearch writerToResearch = new WriterToResearch()
                        {
                            ResearchId = model.Id,
                            WriterId = item.WriterId

                        };
                        _writerToResearch.CreateWriterToResearch(writerToResearch);
                    }
                }

                _research.Save(model);
                return RedirectToAction("Index");
            }

            ViewBag.Writer = _writer.GetWriters();
            ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();
            return View(model);
        }
        public IActionResult Update(int? researchId)
        {
            if (researchId == null && researchId <= 0)
            {
                return NotFound();
            }

            ViewBag.Writer = _writer.GetWriters();
            ViewBag.Research = _research.GetResearchs();
            ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();

            Research research = _research.GetResearch(researchId);


            return View(research);
        }
        [HttpPost]
        public IActionResult Update(Research model)
        {
            if (ModelState.IsValid)
            {
                List<WriterToResearch> newResearch = model.WriterToResearch;
                List<WriterToResearch> oldResearch = _context.WriterToResearch.Where(s => s.ResearchId == model.Id).ToList();

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" ))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.Writer = _writer.GetWriters();
                        ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();
                        return View(model);
                    }

                    

                    string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", model.Image);
                    System.IO.File.Delete(oldFilePath);

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    model.Image = fileName;
                }


                model.WriterToResearch = null;
                _context.Research.Update(model);
                _context.SaveChanges();

                _context.WriterToResearch.RemoveRange(oldResearch);

                foreach (var item in newResearch)
                {
                    if (item.WriterId > 0)
                    {
                        WriterToResearch writer = new WriterToResearch()
                        {
                            ResearchId = model.Id,
                            WriterId = item.WriterId

                        };
                        _context.WriterToResearch.Add(writer);
                    }
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Writer = _writer.GetWriters();
            ViewBag.ResearchCategory = _researchCategory.GetResearchCategorys();
            return View(model);
        }

        public IActionResult Delete(int researchId)
        {
            _research.DeleteResearch(researchId);

            return RedirectToAction("Index");
        }
        public JsonResult GetWriters()
        {
            List<Writer> writers = _context.Writer.ToList();
            return Json(writers);
        }

    }
}
