using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class WriterToResearch : IWriterToResearch
    {
        private readonly AppDbContext _context;

        public WriterToResearch(AppDbContext context)
        {
            _context = context;
        }
        public Models.WriterToResearch CreateWriterToResearch(Models.WriterToResearch model)
        {
            _context.WriterToResearch.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteWriterToResearch(int id)
        {
            Models.WriterToResearch writerToResearch = _context.WriterToResearch.Find(id);
            _context.WriterToResearch.Remove(writerToResearch);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Models.WriterToResearch GetWriterToResearch()
        {
            return _context.WriterToResearch.Include(r=>r.Research).Include(a=>a.Writer).FirstOrDefault();
        }

        public List<Models.WriterToResearch> GetWriterToResearchs()
        {
            return _context.WriterToResearch.Include(r => r.Research).Include(a => a.Writer).ToList();
        }

        public Models.WriterToResearch UpdateWriterToResearch(Models.WriterToResearch model)
        {
            _context.WriterToResearch.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
