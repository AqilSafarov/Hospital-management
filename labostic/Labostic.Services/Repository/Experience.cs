using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Experience : IExperience
    {
        private readonly AppDbContext _context;

        public Experience(AppDbContext context)
        {
            _context = context;
        }
        public Models.Experience CreateExperience(Models.Experience model)
        {
            _context.Experience.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteExperience(int id)
        {
            Models.Experience experience = _context.Experience.Find(id);
            _context.Experience.Remove(experience);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Experience GetExperience()
        {
            return _context.Experience.FirstOrDefault();
        }

        public Models.Experience GetExperience(int? id)
        {
            return _context.Experience.Find(id);
        }

        public List<Models.Experience> GetExperiences()
        {
            return _context.Experience.ToList();

        }

        public Models.Experience UpdateExperience(Models.Experience model)
        {
            _context.Experience.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
