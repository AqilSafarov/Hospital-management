using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
   public class Research
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]

        public string Title { get; set; }
        [Column(TypeName = "ntext")]

        public string Desc { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }



        [MaxLength(250)]
        public string ImageResDet { get; set; }
        [NotMapped]
        public IFormFile ImageFileResDet { get; set; }

        [ForeignKey("ResearchCategory")]
        public int ResearchCategoryId { get; set; }
        public ResearchCategory ResearchCategory { get; set; }

      
        public DateTime Date { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        [MaxLength(100)]

        public string PunkTitle { get; set; }
        [Column(TypeName = "ntext")]
        public string PunkDesc { get; set; }
        [MaxLength(250)]
        public string ImageResDesImg { get; set; }
        [NotMapped]
        public IFormFile ImageFileResDescImg { get; set; }

        [Column(TypeName = "ntext")]

        public string ResearchAdvDesc { get; set; }
        [MaxLength(100)]

        public string ResearchAdvTitle { get; set; }

        public List<WriterToResearch> WriterToResearch { get; set; }


    }
}
