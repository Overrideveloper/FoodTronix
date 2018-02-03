using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Entities
{
    public class Dish
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public double Amount { get; set; }

        // Entity r/ship
        public int MealID { get; set; }
        public virtual Meal Meal { get; set; }
    }
}
