using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.RazorPagesMovieContext _context;
               
        /// <summary>
        /// Constructor for IndexModel
        /// </summary>
        /// <note>
        /// Razor Pages are derived from PageModel. 
        /// By convention, the PageModel-derived class is called <PageName>Model. 
        /// The constructor uses dependency injection to add the RazorPagesMovieContext to the page.
        /// </note>
        /// <param name="context"></param>
        public IndexModel(RazorPagesMovie.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        /// <summary>
        /// Handles requests asynchronously and reutrns a list movies to the Razor Page
        /// </summary>
        /// <note>
        /// When a request is made for the page, the OnGetAsync method returns a list of movies to the Razor Page.
        /// OnGetAsync or OnGet is called on a Razor Page to initialize the state for the page.
        /// In this case, OnGetAsync gets a list of movies and displays them.
        /// </note>
        /// <returns><see cref="Task"/></returns>
        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
