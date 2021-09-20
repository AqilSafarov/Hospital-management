using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
    public class AboutStatistic
    {
        [Key]
        public int Id { get; set; }
        public int Number { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        [MaxLength(100)]

        public string Subtitle { get; set; }

    }
}
