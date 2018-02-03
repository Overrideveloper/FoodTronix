using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Entities
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Input name!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /*public virtual ICollection<User> User { get; set; }*/
    }
}
