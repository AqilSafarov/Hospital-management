using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmTeamTwo
    {
        public Doctor Doctor { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Social> Social { get; set; }
        public List<Skill> Skill { get; set; }
        public List<SkillToDoctor> SkillToDoctor { get; set; }
        public List<Awards> Awards { get; set; }
        public List<Experience> Experience { get; set; }
        public List<SocialToDoctor> SocialToDoctor { get; set; }


    }
}
