using Labostic.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Writer : IWriter
    {
        private readonly AppDbContext _context;

        public Writer(AppDbContext context)
        {
            _context = context;
        }
        public Models.Writer CreateWriter(Models.Writer model)
        {
            _context.Writer.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteWriter(int id)
        {
            Models.Writer writer = _context.Writer.Find(id);
            _context.Writer.Remove(writer);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Models.Writer FindWriter(int? id)
        {
            return _context.Writer.Find(id);
        }

        public Models.Writer GetWriter()
        {
            return _context.Writer.Include(r=>r.WriterToResearch).ThenInclude(t=>t.Writer).FirstOrDefault();
        }

        public List<Models.Writer> GetWriters()
        {
            return _context.Writer.Include(r=>r.WriterToResearch).ThenInclude(t=>t.Writer).ToList();
        }

        public Models.Writer Save(Models.Writer model)
        {
            _context.SaveChanges();
            return model;
        }

        public Models.Writer UpdateWriter(Models.Writer model)
        {
            _context.Writer.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
