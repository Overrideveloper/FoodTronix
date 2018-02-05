using FoodTronix.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTronix.Models.Context
{
    public class FoodTronixContext: DbContext
    {
        public FoodTronixContext(DbContextOptions<FoodTronixContext> options)
            : base(options)
        {
        } 
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Meal> Meal { get; set; }
        public virtual DbSet<Dish> Dish { get; set; }
        public virtual DbSet<OrderGroup> OrderGroup { get; set; }
        public virtual DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
