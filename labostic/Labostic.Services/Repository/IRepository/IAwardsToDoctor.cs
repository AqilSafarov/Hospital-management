using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IAwardsToDoctor
    {
        List<Models.AwardsToDoctor> GetAwardsToDoctors();
        Models.AwardsToDoctor CreateAwardsToDoctor(Models.AwardsToDoctor model);
        Models.AwardsToDoctor UpdateAwardsToDoctor(Models.AwardsToDoctor model);
        bool DeleteAwardsToDoctor(int id);
    }
}
