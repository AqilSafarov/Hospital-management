using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Analysis { get; set; }
        [ForeignKey("Check")]
        public int CheckId { get; set; }
        public Check Check { get; set; }
    }
}
