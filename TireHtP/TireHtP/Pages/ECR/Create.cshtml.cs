using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TireHtP.Models;

namespace TireHtP.Pages.ECR
{
    public class CreateModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public CreateModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TECR TECR { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TECR.Add(TECR);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
