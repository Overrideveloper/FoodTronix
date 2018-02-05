using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Entities
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        
        [Required(ErrorMessage = "Input amount!")]
        public int Amount { get; set; }

        //Entity R/ship
        [Required]
        public int DishID { get; set; }
        public virtual Dish Dish { get; set; }

        [Required]
        public int OrderGroupID { get; set; }
        public virtual OrderGroup OrderGroup { get; set; }
    }
}
