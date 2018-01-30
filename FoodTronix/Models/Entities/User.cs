using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Input email address!")]
        [Display(Name = "Email Address")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Input password!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Hash { get; set; }

        [Required(ErrorMessage = "Input password again!")]
        [Compare("Hash", ErrorMessage = "Passwords don't match!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmHash { get; set; }

        //Entity r/ship
        public int RoleID { get; set; }

        public virtual Role Role { get; set; }
    }
}
