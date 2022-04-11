using Classifieds.Data.Entities;
using Classifieds.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Classifieds.Web.Pages.Advertisements
{
    [Authorize(Policy = Policies.IsMinimumAge)]
    public class CreateModel : PageModel
    {
        private readonly Classifieds.Data.ApplicationDbContext _context;

        public CreateModel(Classifieds.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Advertisements.Add(Advertisement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
