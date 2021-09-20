using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labostic.Models
{
   public  class Message
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Fullname { get; set; }
        [Required,MaxLength(100)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required,MaxLength(100)]
        public string Subject { get; set; }
        [Required, MaxLength(500)]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
