using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class ResearchSquar : IResearchSquar
    {
        private readonly AppDbContext _context;

        public ResearchSquar(AppDbContext context)
        {
            _context = context;
        }
        public Models.ResearchSquar CreateResearchSquar(Models.ResearchSquar model)
        {
            _context.ResearchSquar.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteResearchSquar(int id)
        {
            Models.ResearchSquar researchSquar = _context.ResearchSquar.Find(id);
            _context.ResearchSquar.Remove(researchSquar);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Models.ResearchSquar GetResearchSquar(int? squareid)
        {
            return _context.ResearchSquar.Find(squareid);

        }

        public List<Models.ResearchSquar> GetResearchSquars()
        {
            return _context.ResearchSquar.ToList();
        }

        public Models.ResearchSquar UpdateResearchSquar(Models.ResearchSquar model)
        {
            _context.ResearchSquar.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
