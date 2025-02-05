using ApiFilm.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiFilm.DataBaseContext
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
    }
}
