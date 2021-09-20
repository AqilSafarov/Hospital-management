using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(200)]

        public string ImageDownTitle{get; set; }
        [MaxLength(100)]

        public string Fullname { get; set; }
        [MaxLength(500)]
        public string Desc { get; set; }

        [MaxLength(100)]
        public string PositionName { get; set; }
    }
}
