using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }
        


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var orderEntityBuilder = modelBuilder.Entity<Tutorial>();
        //    orderEntityBuilder.HasIndex(t => t.SourceId).IsUnique(false);
        //}
       
    }
}
