using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceExampleAPI.Models.Order
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public string OrderNumber { get; set; }        
        public OrderStatus OrderStatus { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
