using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IWorkProcess
    {
        List<Models.WorkProcess> GetWorkProcesss();
        Models.WorkProcess GetWorkProcess(int? id);
        Models.WorkProcess CreateWorkProcess(Models.WorkProcess model);
        Models.WorkProcess UpdateWorkProcess(Models.WorkProcess model);
        bool DeleteWorkProcess(int id);
    }
}
