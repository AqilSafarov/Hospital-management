using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface IDoctor
    {
        List<Models.Doctor> GetDoctors(int? id);
        List<Models.Doctor> GetDoctorses();
        Models.Doctor GetDoctor(int? id);
        Models.Doctor GetDoctorSingle();

        Models.Doctor CreateDoctor(Models.Doctor model);
        Models.Doctor UpdateDoctor(Models.Doctor model);
        bool DeleteDoctor(int id);
    }
}
