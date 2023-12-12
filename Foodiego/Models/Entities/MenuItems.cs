using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Foodiego.Models
{
    public class MenuItems
    {
        public int MenuItemsId { get; set; }
        public int MenuId { get; set; }
        public required string ItemName { get; set; }
        public required string Description { get; set; }
        [Required]
        [Range(0, double.MaxValue,ErrorMessage = "Price must be a positive value.")]
        public double Price { get; set; }
        public required string ImageUrl { get; set; }

        public virtual Menu? Menu{get; set;}
    }
}