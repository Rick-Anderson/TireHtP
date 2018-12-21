using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TireHtP.Models;

namespace TireHtP.Pages.TireHt
{
    public class DetailsModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public DetailsModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        public Tire Tire { get; set; }
        public double Ht { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ht = 3.14159;

            Tire = await _context.Tire.FirstOrDefaultAsync(m => m.Id == id);

            if (Tire == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
