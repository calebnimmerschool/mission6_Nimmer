using Microsoft.EntityFrameworkCore;

namespace mission6_Nimmer.Models
{
    public class NewMovieContext : DbContext
    {
        public NewMovieContext(DbContextOptions<NewMovieContext> options) : base (options) { }
        public NewMovieContext() { }
        public DbSet<NewMovie> NewMovies { get; set; }
    }
}
