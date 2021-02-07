
using Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapDatabaseContext: DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localDb)\mssqllocaldb; Database=ReCapDatabase; Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; } 
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DtoCarDetail> DtoCarDetails { get; set; }
    }
}
