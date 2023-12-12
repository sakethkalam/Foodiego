using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Foodiego.Models
{
    public class Orders
    {
        public int OrdersId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RestaurentId { get; set; }
        [Required]
        public required DateTime Orderdate { get; set; }
        [Required]
        public required string OrderStatus { get; set; }
        [Required]
        public required string DeliveryAddress {get; set;}
        [Required]
        public float TotalPrice {get; set;}
        [Required]
        public required string PaymentMethod { get; set; }
        [Required]

        public required User User { get; set; }
        [Required]

        public required Restaurents Restaurents {get; set;}
    }
}