using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
    public class ResearchSquar
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Icon { get; set; }
        [Required,MaxLength(500)]

        public string Desc { get; set; }
    }
}
