using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class HomeCircle
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public byte CircleNum { get; set; }
        [Required,MaxLength(200)]
        public string CircleTitle { get; set; }
        [MaxLength(500)]

        public string CircleDesc{ get; set; }

    }
}
