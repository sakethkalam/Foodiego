using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiego.Models
{
    public class PaymentDetails
    {
        public Guid PaymentDetailsID { get; set; }
        public int UserId{get; set;}
        public required string CardNumber { get; set; }
        public required string ExpirationDate {get; set;}

        [Required]
        [MinLength(3)]
        public required string CVV {get; set;}

        public virtual required User User { get; set; }
    }
}