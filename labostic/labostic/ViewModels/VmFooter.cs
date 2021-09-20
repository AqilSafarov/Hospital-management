using Labostic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmFooter
    {
       public Social Social { get; set; }
       public List<SocialToDoctor> SocialToDoctor { get; set; }
        public Setting Setting { get; set; }
        public List<Research> Research { get; set; }
        public Message Message { get; set; }
      



    }
}
