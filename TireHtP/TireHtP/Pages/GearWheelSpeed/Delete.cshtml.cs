using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TireHtP.Models;

namespace TireHtP.Pages.GearWheelSpeed
{
    public class DeleteModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public DeleteModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FindAsync(id);

            if (Car != null)
            {
                _context.Car.Remove(Car);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
