using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Subscribe:ISubscribe
    {

        private readonly AppDbContext _context;

        public Subscribe(AppDbContext context)
        {
            _context = context;
        }
        public Models.Subscribe CreateSubscribe(Models.Subscribe model)
        {
            _context.Subscribe.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSubscribe(int id)
        {
            Models.Subscribe Subscribe = _context.Subscribe.Find(id);
            _context.Subscribe.Remove(Subscribe);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Subscribe> GetSubscribe()
        {
            return _context.Subscribe.ToList();
        }

        public Models.Subscribe GetSubscribe(int id)
        {
            return _context.Subscribe.Find(id);
        }

        public bool GetSubscribe(string email)
        {
            return _context.Subscribe.Any(e => e.Email == email);
        }

        public Models.Subscribe UpdateSubscribe(Models.Subscribe model)
        {
            _context.Subscribe.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
