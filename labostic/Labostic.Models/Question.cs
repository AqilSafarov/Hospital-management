using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
   public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string  Fullname { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(1000)]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
