using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiego.Models
{
    public class Reviews
    {
        public int ReviewsId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public required string ReviewText { get; set; }

        public virtual required Orders Orders { get; set; }
        public virtual required User User { get; set; }
    }
}