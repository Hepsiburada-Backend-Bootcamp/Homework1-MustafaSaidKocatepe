using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceExampleAPI.Models.Order
{
    public class CreateOrderDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
    }
}
