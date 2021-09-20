using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labostic.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Fullname { get; set; }
        [ MaxLength(50)]

        public string PhoneNumber { get; set; }
        [MaxLength(100)]

        public string Email { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
