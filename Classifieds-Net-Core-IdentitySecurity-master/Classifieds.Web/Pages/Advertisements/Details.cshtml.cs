using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Classifieds.Data;
using Classifieds.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Classifieds.Web.Pages.Advertisements
{
    [AllowAnonymous]
    public class DetailsModel : PageModel
    {
        private readonly Classifieds.Data.ApplicationDbContext _context;

        public DetailsModel(Classifieds.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
