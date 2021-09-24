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
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@\""]+"
+                          @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
+                          @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
+                          @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
+                          @"[a-zA-Z]{2,}))$", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
    }
}
