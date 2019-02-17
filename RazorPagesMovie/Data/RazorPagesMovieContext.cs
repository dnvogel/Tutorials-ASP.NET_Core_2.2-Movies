using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class RazorPagesMovieContext : DbContext
    {
        // The connection string is passed in the options
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }
        
        // An Entity Set typically corresponds to a database table. An entity corresponds to a row in the table.
        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
    }
}
