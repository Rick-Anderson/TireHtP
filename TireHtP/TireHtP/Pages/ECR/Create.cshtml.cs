using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireHtP.Models;
using TireHtP.Pages.TireHt;

namespace TireHtP.Pages.ECR
{
    public class CreateModel : TireBaseModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public CreateModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            TECR = new Tecr
            {
                Name = "Copy-JHF",
                First = 2.74,
                Portal = 1.92,
                TC = 2.62,
                TireRadius = 42.9,
                Tq = 260,
                Weight = 3800
            };

            return Page();
        }

        [BindProperty]
        public Tecr TECR { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        { 
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TECR.SessionID = GetSessionID();
            _context.Tecr.Add(TECR);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
