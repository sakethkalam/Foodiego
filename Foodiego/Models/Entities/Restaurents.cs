using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiego.Models
{
    public class Restaurents
    {
        public int RestaurentsId { get; set; }
        public string? RestaurentName { get; set; }
        [Required]
        public string? Cusinie { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? PhoneNumber{get; set;}
        [RegularExpression(@"^/d{10}$")]
        public string? DeliveryArea { get; set; }
        [Required]
        public float Rating { get; set; }

        public virtual ICollection<Orders>? Orders {get; set;}

        public required ICollection<Menu>? Menus {get; set;}
        
    }
}