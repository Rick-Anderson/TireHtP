using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TireHtP.Models;
using TireHtP.Pages.TireHt;

namespace TireHtP.Pages
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
            Tire = new Tire
            {
                Model = "any",
                Height = 35.0,
                Width = 12.5,
                Weight = 1100,
                WheelDiameter = 17,
                MaxPSI = 36
            };
            return Page();
        }

        [BindProperty]
        public Tire Tire { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Tire.SessionID = GetSessionID();

            _context.Tire.Add(Tire);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}