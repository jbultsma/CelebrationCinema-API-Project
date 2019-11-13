using CelebrationCinema.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CelebrationCinema.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext()
        {

        }

        public virtual DbSet<Movies> Movie { get; set; }
        public object Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-95NNO4H\SQLEXPRESS;Initial Catalog=Movies;Trusted_Connection=True;");
        }
    }

}