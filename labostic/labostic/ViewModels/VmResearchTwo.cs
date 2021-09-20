using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmResearchTwo
    {
        public List<ResearchSquar> ResearchSquar { get; set; }
        public Research Research { get; set; }
        public ResearchCategory ResearchCategory { get; set; }
        public List<Social> Social { get; set; }
        public List<Research> Researches { get; set; }
        public  Writer Writer { get; set; }
        public List< WriterToResearch >WriterToResearche { get; set; }


    }
}
