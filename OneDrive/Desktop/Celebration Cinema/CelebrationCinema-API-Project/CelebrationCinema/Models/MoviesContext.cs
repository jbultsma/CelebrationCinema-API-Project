using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CelebrationCinema.Models
{
    public class MoviesContext : DbContext
    {
        public DbSet<Movies> Movie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2TSRG7K\SQLEXPRESS01;Trusted_Connection=True;Initial Catalog=MoviesDb;");
        }
    }

}