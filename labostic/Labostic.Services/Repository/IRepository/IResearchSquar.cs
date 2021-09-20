using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface IResearchSquar
    {
        List<Models.ResearchSquar> GetResearchSquars();
        Models.ResearchSquar GetResearchSquar(int? squareid);
        Models.ResearchSquar CreateResearchSquar(Models.ResearchSquar model);
        Models.ResearchSquar UpdateResearchSquar(Models.ResearchSquar model);
        bool DeleteResearchSquar(int id);
    }
}
