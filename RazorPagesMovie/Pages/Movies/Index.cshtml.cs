using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        /// Search String
        /// </summary>
        /// <note>
        /// For security reasons, you must opt in to binding GET request data to page model properties.
        /// Verify user input before mapping it to properties. 
        /// Opting in to GET binding is useful when addressing scenarios which rely on query string or route values.
        /// To bind a property on GET requests, set the [BindProperty] attribute's SupportsGet property to true:
        /// </note>        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

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

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie

                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            // The SlectList of genres is created by projecting the distinct genres.
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            
            Movie = await movies.ToListAsync();
        }
    }
}
