using API_Project_For_Flutter.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Project_For_Flutter.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Furniture> Furnitures { get; set; }
    }
}
