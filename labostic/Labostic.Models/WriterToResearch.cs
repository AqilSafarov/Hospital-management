using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class WriterToResearch
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Writer")]
        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        [ForeignKey("Research")]
        public int ResearchId { get; set; }
        public Research Research { get; set; }
    }
}
