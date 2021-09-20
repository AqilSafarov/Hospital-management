using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmFaq
    {
        public List<Faq> Faq { get; set; }
        public Question Question { get; set; }
    }
}
