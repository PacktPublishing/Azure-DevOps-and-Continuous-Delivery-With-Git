using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Classifieds.Data;
using Classifieds.Data.Entities;

namespace Classifieds.Web.Pages.Advertisements
{
    public class EditModel : PageModel
    {
        private readonly Classifieds.Data.ApplicationDbContext _context;

        public EditModel(Classifieds.Data.ApplicationDbContext context)
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
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Advertisement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(Advertisement.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisements.Any(e => e.Id == id);
        }
    }
}
