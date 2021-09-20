using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmAbout
    {
        public Setting Setting { get; set; }
        public List<AboutSign> AboutSign { get; set; }
        public List<WorkProcess> WorkProcess { get; set; }
        public List<AboutStatistic> AboutStatistic { get; set; }
        public List<WhyChoose> WhyChoose { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<Social> Social { get; set; }

    }
}
