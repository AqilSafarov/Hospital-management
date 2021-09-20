using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
   public class Services
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [MaxLength(250)]
        public string ImageTwo { get; set; }
        [NotMapped]
        public IFormFile ImageFileTwo { get; set; }

        [MaxLength(250)]
        public string ImageThree { get; set; }
        [NotMapped]
        public IFormFile ImageFileThree { get; set; }

        [MaxLength(250)]
        public string ImageFour { get; set; }
        [NotMapped]
        public IFormFile ImageFileFour { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string TitleTwo { get; set; }

        [MaxLength(200)]
        public string TitleThree { get; set; }

        [MaxLength(200)]
        public string TitleFour { get; set; }

        [Column(TypeName = "ntext")]
        public string Desc { get; set; }

        [Column(TypeName = "ntext")]
        public string DescTwo { get; set; }

        [Column(TypeName = "ntext")]
        public string DescThree { get; set; }


        [Column(TypeName = "ntext")]
        public string DescFour { get; set; }

        [MaxLength(100)]
        public string Icon { get; set; }

        [MaxLength(100)]
        public string IconTwo { get; set; }

        [MaxLength(100)]
        public string IconThree { get; set; }

        [MaxLength(100)]
        public string IconFour { get; set; }


        [MaxLength(200)]
        public string IconDesc { get; set; }

        [MaxLength(200)]
        public string IconDescTwo { get; set; }

        [MaxLength(200)]
        public string IconDescThree { get; set; }

        [MaxLength(200)]
        public string IconDescFour { get; set; }

        [MaxLength(100)]
        public string IconTitle { get; set; }

        [MaxLength(100)]
        public string IconTitleTwo { get; set; }

        [MaxLength(100)]
        public string IconTitleThree { get; set; }

        [MaxLength(100)]
        public string IconTitleFour { get; set; }


    }
}
