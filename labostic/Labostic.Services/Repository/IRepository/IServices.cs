using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IServices
    {
        List<Models.Services> GetServiceses();
        Models.Services GetServicesesPrm(int? id);
        Models.Services CreateServices(Models.Services model);
        Models.Services UpdateServices(Models.Services model);
        bool DeleteServices(int id);
    }
}
