using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmTeam
    {
        public List<Doctor> Doctor { get; set; }
        public List< Social> Social { get; set; }
        public List<SocialToDoctor> SocialToDoctor { get; set; }
        public Position  Position { get; set; }





    }
}
