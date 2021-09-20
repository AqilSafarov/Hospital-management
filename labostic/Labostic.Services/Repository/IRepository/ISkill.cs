using System;
using System.Collections.Generic;
using System.Text;

namespace Labostic.Skill.Repository.IRepository
{
    public interface ISkill
    {
        List<Models.Skill> GetSkillsPm(int? sid);
        Models.Skill GetSkillsParm(int? sid);
        List<Models.Skill> GetSkills();
        Models.Skill CreateSkill(Models.Skill model);
        Models.Skill UpdateSkill(Models.Skill model);
        bool DeleteSkill(int id);
    }
}
