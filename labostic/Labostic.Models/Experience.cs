using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        [MaxLength(100)]

        public string Title { get; set; }
        [MaxLength(500)]

        public string Desc { get; set; }

    }
}
