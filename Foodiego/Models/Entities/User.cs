using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodiego.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public required string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string PasswordHash { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber {get; set;}
        [RegularExpression(@"^/d{10}$")]
        public string Address { get; set; }
        [Required]

        public virtual ICollection<Orders> Orders {get; set;}
    }
}