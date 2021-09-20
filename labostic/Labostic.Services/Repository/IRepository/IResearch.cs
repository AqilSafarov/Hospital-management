using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IResearch
    {
        List<Models.Research> GetResearchs();
        List<Models.Research> GetResearchesPrm(string searchData);
        Models.Research GetResearch();
        Models.Research CreateResearch(Models.Research model);
        Models.Research UpdateResearch(Models.Research model);
        bool DeleteResearch(int id);
        Models.Research GetResearch(int? id);
        Models.Research Save(Models.Research model);

    }
}
