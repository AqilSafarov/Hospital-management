using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class SocialToDoctor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Social")]
        public int SocialId { get; set; }
        public Social Social { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [MaxLength(250)]

        public string Link { get; set; }
    }
}
