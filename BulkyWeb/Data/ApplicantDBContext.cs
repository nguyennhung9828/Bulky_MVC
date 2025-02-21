using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BulkyWeb.Data
{
    public class ApplicantDBContext : DbContext
    {
        public ApplicantDBContext(DbContextOptions<ApplicantDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Category 1", DisplayOrder = 1 },
                new Category { CategoryId = 2, Name = "Category 2", DisplayOrder = 2 },
                new Category { CategoryId = 3, Name = "Category 3", DisplayOrder = 3 });
        }
    }
}
