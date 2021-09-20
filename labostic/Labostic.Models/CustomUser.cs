using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class CustomUser: IdentityUser
    {

        [MaxLength(50), Required]
        public string Name { get; set; }
        [MaxLength(50), Required]
        public string Surname { get; set; }
        [MaxLength(500),]
        public string Addres { get; set; }
        [Column(TypeName = "bit")]
        public bool Gender { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(15)]
        public string PostCode { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
