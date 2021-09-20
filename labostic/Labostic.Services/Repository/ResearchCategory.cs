using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class ResearchCategory : IResearchCategory
    {
        private readonly AppDbContext _context;

        public ResearchCategory(AppDbContext context)
        {
            _context = context;
        }
        public Models.ResearchCategory CreateResearchCategory(Models.ResearchCategory model)
        {
            _context.ResearchCategory.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteResearchCategory(int id)
        {
            Models.ResearchCategory researchCategory = _context.ResearchCategory.Find(id);
            _context.ResearchCategory.Remove(researchCategory);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public List<Models.ResearchCategory> GetResearchCategorys()
        {
            return _context.ResearchCategory.Include(r => r.Research).ToList();

        }

        public Models.ResearchCategory GetResearchCategory(int? id)
        {
            return _context.ResearchCategory.Include(r=>r.Research).FirstOrDefault(p => p.Id == id);

        }

        public Models.ResearchCategory UpdateResearchCategory(Models.ResearchCategory model)
        {
            _context.ResearchCategory.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
