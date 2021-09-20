using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Fullname { get; set; }
        public List<WriterToResearch> WriterToResearch { get; set; }

    }
}
