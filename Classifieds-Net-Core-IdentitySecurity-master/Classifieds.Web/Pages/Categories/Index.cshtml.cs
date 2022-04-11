using Classifieds.Data.Constants;
using Classifieds.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Classifieds.Web.Pages.Categories
{
    [Authorize(Roles = Roles.Administrator)]
    public class IndexModel : PageModel
    {
        private readonly Classifieds.Data.ApplicationDbContext _context;

        public IndexModel(Classifieds.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
