using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string Question { get; set; }

        [Required,MaxLength(500)]
        public string Answer { get; set; }
    }
}
