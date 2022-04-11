using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Classifieds.Data;
using Classifieds.Data.Entities;

namespace Classifieds.Web.Pages.Advertisements
{
    public class DeleteModel : PageModel
    {
        private readonly Classifieds.Data.ApplicationDbContext _context;

        public DeleteModel(Classifieds.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = await _context.Advertisements
                .Include(a => a.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Advertisement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = await _context.Advertisements.FindAsync(id);

            if (Advertisement != null)
            {
                _context.Advertisements.Remove(Advertisement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
