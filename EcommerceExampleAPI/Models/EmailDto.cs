using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceExampleAPI.Models
{
    public class EmailDto
    {
        [Required(ErrorMessage = "Lütfen Email adresini giriniz.")]
        public string Email { get; set; }
    }
}
