using System.ComponentModel.DataAnnotations;
using API_Project_For_Flutter.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_Project_For_Flutter.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Initials).HasMaxLength(5);
        }

        public DbSet<Furniture> Furnitures { get; set; }


    }
    public class furniture
    {
        public Guid Id { get; set; }
        public required decimal Price { get; set; }
        public required decimal Quantity { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
