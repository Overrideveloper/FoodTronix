using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Entities
{
    public class OrderGroup
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Input amount!")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Tag is required!")]
        public string Tag { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
