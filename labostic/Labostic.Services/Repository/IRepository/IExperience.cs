using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IExperience
    {
        List<Models.Experience> GetExperiences();
        Models.Experience GetExperience();
        Models.Experience GetExperience(int? id);
        Models.Experience CreateExperience(Models.Experience model);
        Models.Experience UpdateExperience(Models.Experience model);
        bool DeleteExperience(int id);
    }
}
