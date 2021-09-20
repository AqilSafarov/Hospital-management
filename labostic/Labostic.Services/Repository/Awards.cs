using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Awards : IAwards
    {
        private readonly AppDbContext _context;

        public Awards(AppDbContext context)
        {
            _context = context;
        }
        public Models.Awards CreateAwards(Models.Awards model)
        {
            _context.Awards.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteAwards(int id)
        {
            Models.Awards awards = _context.Awards.Find(id);
            _context.Awards.Remove(awards);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Models.Awards> GetAwardses()
        {
            return _context.Awards.ToList();
        }

        public Models.Awards UpdateAwards(Models.Awards model)
        {
            _context.Awards.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
