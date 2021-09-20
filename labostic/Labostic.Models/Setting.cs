using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string LogoNav { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(250)]
        public string LogoFooter { get; set; }
        [NotMapped]
        public IFormFile ImageFileFooter { get; set; }
        [MaxLength(500)]
        public string About { get; set; }
        [MaxLength(50)]

        public string PhoneNumOne { get; set; }
        [MaxLength(50)]

        public string PhoneNumTwo { get; set; }
        [MaxLength(100)]

        public string Address { get; set; }

        [MaxLength(100)]

        public string WorkHours { get; set; }
        [Required,MaxLength(100)]

        public string EmailNav { get; set; }
        [MaxLength(100)]

        public string EmailFooter { get; set; }
        [Required,MaxLength(200)]

        public string AboutTitle { get; set; }
        [Required,MaxLength(500)]

        public string AboutDesc { get; set; }
        [MaxLength(250)]
        public string ImageAbout { get; set; }
        [NotMapped]
        public IFormFile ImageFileAbout { get; set; }

        [MaxLength(250)]
        public string ImageAboutSign { get; set; }
        [NotMapped]
        public IFormFile ImageFileAboutSign { get; set; }

        [MaxLength(200)]
        public string HomeTitle { get; set; }
        [MaxLength(500)]

        public string HomeDesc { get; set; }

        [MaxLength(250)]
        public string ImageHome { get; set; }
        [NotMapped]
        public IFormFile ImageFileHome { get; set; }

        [MaxLength(200)]

        public string HomeLeftSTitle { get; set; }
        [MaxLength(500)]

        public string HomeLeftSDesc { get; set; }
        [MaxLength(250)]
        public string HomeLeftSIamge { get; set; }
        [NotMapped]
        public IFormFile ImageFileHomeLeftS { get; set; }

        public string HomeRighttSTitle { get; set; }
        [MaxLength(500)]

        public string HomeRightSDesc { get; set; }
        [MaxLength(250)]
        public string HomeRightSIamge { get; set; }
        [NotMapped]
        public IFormFile ImageFileHomeRightS { get; set; }


    }
}
