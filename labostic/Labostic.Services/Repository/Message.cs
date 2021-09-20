using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Message : IMessage
    {
        private readonly AppDbContext _context;

        public Message(AppDbContext context)
        {
            _context = context;
        }
        public Models.Message CreateMessage(Models.Message model)
        {
            _context.Message.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteMessage(int id)
        {
            Models.Message Message = _context.Message.Find(id);
            _context.Message.Remove(Message);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Message GetMessage()
        {
            return _context.Message.FirstOrDefault();
        }

        public List<Models.Message> GetMessages()
        {
            return _context.Message.ToList();

        }

        public Models.Message UpdateMessage(Models.Message model)
        {
            _context.Message.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
