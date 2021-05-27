using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace lab6_kpi
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Furniture> furniture { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=lab6;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

 
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
   
                var categories = db.categories.ToList();
                Console.WriteLine("categories list:");
                foreach (Category u in categories)
                {
                    Console.WriteLine($"{u.Name}.{u.Id} ");
                }
            }

        }
    }
}
