using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiego.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int RestaurentId { get; set; }
        public string Menuname { get; set; }
        public string Description { get; set; }

        public virtual Restaurents Restaurents {get; set;}

        public virtual ICollection<MenuItems> MenuItems{get; set;}
    }
}