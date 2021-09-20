using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labostic.Models
{
    public class TrustedExp
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Percent { get; set; }
      
    }
}
