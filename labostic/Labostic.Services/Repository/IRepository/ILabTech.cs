using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
   public interface ILabTech
    {
        List<Models.LabTech> GetLabTechs();
        Models.LabTech GetLabTech(int? id);
        Models.LabTech CreateLabTech(Models.LabTech model);
        Models.LabTech UpdateLabTech(Models.LabTech model);
        bool DeleteLabTech(int id);
    }
}
