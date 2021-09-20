using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmHome
    {
       public Setting Setting { get; set; }
        public List<HomeCircle> HomeCircle { get; set; }
        public List<LabTech> LabTech { get; set; }
        public List<TrustedExp> TrustedExp { get; set; }
        public List<Testimonial> Testimonial { get; set; }
        public List<Partner> Partner { get; set; }
        public List<Slider> Slider { get; set; }
        public List<Research> Researche { get; set; }
        public List<Services> Services { get; set; }
        public List<ResearchCategory> ResearchCategory { get; set; }

    }
}
