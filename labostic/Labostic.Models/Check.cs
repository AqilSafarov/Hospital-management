using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class Check
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FinCode { get; set; }

        public List<Answer> Answers { get; set;}


    }
}
