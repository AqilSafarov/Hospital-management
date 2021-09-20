using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class HomeCircle : IHomeCircle
    {
        private readonly AppDbContext _context;

        public HomeCircle(AppDbContext context)
        {
            _context = context;
        }
        public Models.HomeCircle CreateHomeCircle(Models.HomeCircle model)
        {

            _context.HomeCircle.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteHomeCircle(int id)
        {
            Models.HomeCircle homeCircle = _context.HomeCircle.Find(id);
            _context.HomeCircle.Remove(homeCircle);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Models.HomeCircle> GetHomeCircles()
        {
            return _context.HomeCircle.ToList();
        }

        public Models.HomeCircle GetHomeCircle(int? id)
        {
            return _context.HomeCircle.Find(id);
        }

        public Models.HomeCircle UpdateHomeCircle(Models.HomeCircle model)
        {
            _context.HomeCircle.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
