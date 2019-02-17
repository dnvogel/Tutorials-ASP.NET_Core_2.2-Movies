using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// The Movie property uses the BindProperty attribute to opt-in to model binding. 
        /// When the Create form posts the form values, the ASP.NET Core runtime binds the posted values to the Movie model.
        /// </summary>
        [BindProperty]
        public Movie Movie { get; set; }

        /// <summary>
        /// The OnPostAsync method is run when the page posts form data.
        /// </summary>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}