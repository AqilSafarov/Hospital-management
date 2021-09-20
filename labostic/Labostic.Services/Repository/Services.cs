using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class Services : IServices
    {
        private readonly AppDbContext _context;

        public Services(AppDbContext context)
        {
            _context = context;
        }
        public Models.Services CreateServices(Models.Services model)
        {
            _context.Services.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteServices(int id)
        {
            Models.Services services = _context.Services.Find(id);
            _context.Services.Remove(services);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public List<Models.Services> GetServiceses()
        {
            return _context.Services.ToList();
        }

        public Models.Services GetServicesesPrm(int? id)
        {
            return _context.Services.Find(id);
        }

        public Models.Services UpdateServices(Models.Services model)
        {
            _context.Services.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
