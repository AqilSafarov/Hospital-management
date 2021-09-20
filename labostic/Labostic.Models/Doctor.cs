using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]

        public string Specialty { get; set; }
        [MaxLength(100)]
        public string Fullname { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(250)]
        public string ImagecDesc { get; set; }
        [NotMapped]
        public IFormFile ImageFileDesc { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Experience { get; set; }
        [MaxLength(200)]
        public string MedicalEdu { get; set; }
        [MaxLength(200)]
        public string Residency { get; set; }
        [MaxLength(200)]
        public string Certification { get; set; }

        [MaxLength(200)]
        public string PraticArea { get; set; }

        [Column(TypeName = "ntext")]

        public string BiographyDesc { get; set; }

        [Column(TypeName = "ntext")]

        public string AchievementDesc { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public List<Appointment> Appointment { get; set; }

        public List<SocialToDoctor> SocialToDoctor { get; set; }
        public List<SkillToDoctor> SkillToDoctor { get; set; }
        public List<AwardsToDoctor> AwardsToDoctor { get; set; }




    }
}
