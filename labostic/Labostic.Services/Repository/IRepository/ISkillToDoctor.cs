using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Services.Repository.IRepository
{
    public interface ISkillToDoctor
    {
        List<Models.SkillToDoctor> GetSkillToDoctors();
        Models.SkillToDoctor GetSkillToDoctor(int id);
        Models.SkillToDoctor GetSkillToDoctorSing();
        Models.SkillToDoctor CreateSkillToDoctor(Models.SkillToDoctor model);
        Models.SkillToDoctor UpdateSkillToDoctor(Models.SkillToDoctor model);
        bool DeleteSkillToDoctor(int id);
    }
}
