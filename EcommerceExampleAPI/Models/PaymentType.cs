using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceExampleAPI.Models
{
    public enum PaymentType
    {
        [Display(Name = "Online Ödeme")]
        Online = 0,
        [Display(Name = "Kapıda Ödeme")]
        CashOnDelivery = 1,
    }
}
