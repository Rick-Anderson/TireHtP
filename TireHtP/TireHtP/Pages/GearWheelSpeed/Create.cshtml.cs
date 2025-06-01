using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TireHtP.Models;
using TireHtP.Pages.TireHt;

namespace TireHtP.Pages.GearWheelSpeed
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
            Car = new Car
            {
                Model = "any",
                ModelShort = "any",
                TireDiameter = 35.0,
                RPM = 1000,
                first = 3.0,
                second = 2.0,
                third = 1.5,
                forth = 1.2,
                fifth = 1.0,
                sixth = 0.8,
                seventh = 0.7,
                eigth = 0.6,
                nineth = 0.5,
                tenth = 0.4,
                reverse = -3.0,
                DiffRatio = 4.10,
                XferRatio = 1.0,
                PortalRatio = 1.0
            };
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Car.SessionID = GetSessionID();

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
