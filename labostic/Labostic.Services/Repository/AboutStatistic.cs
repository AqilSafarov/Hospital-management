using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{
    public class AboutStatistic : IAboutStatistic
    {
        private readonly AppDbContext _context;

        public AboutStatistic(AppDbContext context)
        {
            _context = context;
        }
        public Models.AboutStatistic CreateAboutStatistic(Models.AboutStatistic model)
        {
            _context.AboutStatistic.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteAboutStatistic(int id)
        {
            Models.AboutStatistic aboutStatistic = _context.AboutStatistic.Find(id);
            _context.AboutStatistic.Remove(aboutStatistic);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.AboutStatistic GetAboutStatistic(int? id)
        {
            return _context.AboutStatistic.Find(id);
        }

        public List<Models.AboutStatistic> GetAboutStatistics()
        {
            return _context.AboutStatistic.ToList();

        }

        public Models.AboutStatistic UpdateAboutStatistic(Models.AboutStatistic model)
        {
            _context.AboutStatistic.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
