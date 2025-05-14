using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TireHtP.Models;

namespace TireHtP.Pages.ECR
{
    public class DetailsModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public DetailsModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        public Tecr TECR { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TECR = await _context.Tecr.FirstOrDefaultAsync(m => m.Id == id);

            if (TECR == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
