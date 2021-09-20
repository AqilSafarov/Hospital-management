using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace labostic.ViewModels
{
    public class VmLogin
    {
        [MaxLength(50), Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(50), Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
