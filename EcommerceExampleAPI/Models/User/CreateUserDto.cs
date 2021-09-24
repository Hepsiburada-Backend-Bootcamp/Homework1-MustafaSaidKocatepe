using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceExampleAPI.Models
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+"
+                           @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
+                           @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
+                           @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
+                           @"[a-zA-Z]{2,}))$", ErrorMessage = "Please enter a valid email")]

        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(05)([0-9]{2})\s?([0-9]{3})\s?([0-9]{2})\s?([0-9]{2})$", ErrorMessage = "Please enter a valid telephone")]
        public string Telephone { get; set; }
    }
}
