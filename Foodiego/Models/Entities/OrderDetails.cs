using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiego.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int MenuItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }

        public virtual required Orders Orders { get; set; }
        public virtual required ICollection<MenuItems> MenuItems { get; set; }
        
    }
}