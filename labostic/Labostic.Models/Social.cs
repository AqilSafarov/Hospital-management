using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
   public class Social
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        [MaxLength(50)]

        public string Name { get; set; }

        public List<SocialToDoctor> SocialToDoctor { get; set; }
    }
}
