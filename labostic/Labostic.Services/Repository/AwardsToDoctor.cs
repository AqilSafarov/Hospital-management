using Labostic.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labostic.Services.Repository
{

    public class AwardsToDoctor : IAwardsToDoctor
    {
        private readonly AppDbContext _context;

        public AwardsToDoctor(AppDbContext context)
        {
            _context = context;
        }
        public Models.AwardsToDoctor CreateAwardsToDoctor(Models.AwardsToDoctor model)
        {
            _context.AwardsToDoctor.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteAwardsToDoctor(int id)
        {
            Models.AwardsToDoctor awardsToDoctor = _context.AwardsToDoctor.Find(id);
            _context.AwardsToDoctor.Remove(awardsToDoctor);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public List<Models.AwardsToDoctor> GetAwardsToDoctors()
        {
            return _context.AwardsToDoctor.ToList();

        }

        public Models.AwardsToDoctor UpdateAwardsToDoctor(Models.AwardsToDoctor model)
        {
            _context.AwardsToDoctor.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
