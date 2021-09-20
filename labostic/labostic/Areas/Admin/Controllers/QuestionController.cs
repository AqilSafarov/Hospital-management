using Labostic.Models;
using Labostic.Services;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class QuestionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IQuestion _question;

        public QuestionController(AppDbContext context, IQuestion question)
        {
            _context = context;
            _question = question;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Question";
            List<Question> question1 = _question.GetQuestions();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(question1.Count / dataPage);

            List<Question> question2 = question1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = question1.Count;
            return View(question2);
        }
        public IActionResult Delete(int questionId)
        {
            _question.DeleteQuestion(questionId);

            return RedirectToAction("Index");
        }
    }
}
