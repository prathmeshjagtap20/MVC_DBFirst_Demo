using System;
using Microsoft.EntityFrameworkCore;


namespace MVC_DBFirst_Demo.Models
{

    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }

        public DbSet<Category>categories {get;set;}
        public DbSet<Product> products{ get; set; }
    }
    
} 
