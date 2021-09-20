using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class WorkProcess : IWorkProcess
    {

        private readonly AppDbContext _context;

        public WorkProcess(AppDbContext context)
        {
            _context = context;
        }
        public Models.WorkProcess CreateWorkProcess(Models.WorkProcess model)
        {
            _context.WorkProcess.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteWorkProcess(int id)
        {
            Models.WorkProcess workProcess = _context.WorkProcess.Find(id);
            _context.WorkProcess.Remove(workProcess);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Models.WorkProcess GetWorkProcess(int? id)
        {
            return _context.WorkProcess.Find(id);

        }

        public List<Models.WorkProcess> GetWorkProcesss()
        {
            return _context.WorkProcess.ToList();
        }

        public Models.WorkProcess UpdateWorkProcess(Models.WorkProcess model)
        {
            _context.WorkProcess.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
