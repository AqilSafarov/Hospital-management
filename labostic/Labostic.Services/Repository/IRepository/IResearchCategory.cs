using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IResearchCategory
    {
        List<Models.ResearchCategory> GetResearchCategorys();
        Models.ResearchCategory GetResearchCategory(int? id);
        Models.ResearchCategory CreateResearchCategory(Models.ResearchCategory model);
        Models.ResearchCategory UpdateResearchCategory(Models.ResearchCategory model);
        bool DeleteResearchCategory(int id);
    }
}
