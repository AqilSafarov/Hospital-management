using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IAwards
    {
        List<Models.Awards> GetAwardses();
        Models.Awards CreateAwards(Models.Awards model);
        Models.Awards UpdateAwards(Models.Awards model);
        bool DeleteAwards(int id);
    }
}
