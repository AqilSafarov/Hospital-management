using Labostic.Services;
using Labostic.Services.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Labostic.Models;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace labostic.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class MessageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMessage _message;

        public MessageController(AppDbContext context, IMessage message)
        {
            _context = context;
            _message = message;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Message";

            List<Message> message1 = _message.GetMessages();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(message1.Count / dataPage);

            List<Message> message2 = message1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = message1.Count;
            return View(message2);
        }
        public IActionResult Delete(int messageId)
        {
            _message.DeleteMessage(messageId);

            return RedirectToAction("Index");
        }
    }
}
