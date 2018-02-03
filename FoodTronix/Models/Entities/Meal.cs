using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Entities
{
    public class Meal
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
