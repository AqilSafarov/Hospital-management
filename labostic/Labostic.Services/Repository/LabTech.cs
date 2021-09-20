using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class LabTech : ILabTech
    {
        private readonly AppDbContext _context;

        public LabTech(AppDbContext context)
        {
            _context = context;
        }
        public Models.LabTech CreateLabTech(Models.LabTech model)
        {
            _context.LabTech.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteLabTech(int id)
        {
            Models.LabTech labTech = _context.LabTech.Find(id);
            _context.LabTech.Remove(labTech);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.LabTech GetLabTech(int? id)
        {
            return _context.LabTech.Find(id);
        }

        public List<Models.LabTech> GetLabTechs()
        {
            return _context.LabTech.ToList();
        }

        public Models.LabTech UpdateLabTech(Models.LabTech model)
        {
            _context.LabTech.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
