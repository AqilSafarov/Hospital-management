using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class WorkProcess
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Icon { get; set; }
        
        [MaxLength(200)]

        public string Title { get; set; }
        [MaxLength(500)]

        public string Desc { get; set; }
        [Column(TypeName = "tinyint")]


        public byte Numb { get; set; }
    }
}
