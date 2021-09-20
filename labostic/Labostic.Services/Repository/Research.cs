using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Research : IResearch
    {
        private readonly AppDbContext _context;

        public Research(AppDbContext context)
        {
            _context = context;
        }
        public Models.Research CreateResearch(Models.Research model)
        {
            _context.Research.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteResearch(int id)
        {
            Models.Research research = _context.Research.Find(id);
            _context.Research.Remove(research);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Models.Research GetResearch()
        {
            return _context.Research.Include(z=>z.ResearchCategory).Include(n=>n.WriterToResearch).ThenInclude(p=>p.Writer).FirstOrDefault();
        }

        public Models.Research GetResearch(int? id)
        {
            return _context.Research.Where(n => n.Id == id).Include(r=>r.ResearchCategory).Include(y=>y.WriterToResearch).ThenInclude(u=>u.Writer).FirstOrDefault(); ;

        }

        public List<Models.Research> GetResearchesPrm(string searchData)
        {
            return _context.Research.Include(r => r.ResearchCategory).Include(y => y.WriterToResearch).ThenInclude(u => u.Writer).Where(p => (!string.IsNullOrEmpty(searchData) ? p.Title.Contains(searchData) : true) ||
                                              (!string.IsNullOrEmpty(searchData) ? p.Desc.Contains(searchData) : true)).ToList();
        }

        public List<Models.Research> GetResearchs()
        {
            return _context.Research.Include(r => r.ResearchCategory).Include(y => y.WriterToResearch).ThenInclude(u => u.Writer).ToList();
        }

        public Models.Research Save(Models.Research model)
        {
            _context.SaveChanges();
            return model;
        }

        public Models.Research UpdateResearch(Models.Research model)
        {
            _context.Research.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
