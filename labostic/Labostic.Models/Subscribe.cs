using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Email { get; set; }   
        public DateTime CreatedDate { get; set; }


    }
}
