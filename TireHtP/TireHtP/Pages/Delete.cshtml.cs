﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TireHtP.Models;

namespace TireHtP.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public DeleteModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tire Tire { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tire = await _context.Tire.FirstOrDefaultAsync(m => m.Id == id);

            if (Tire == null)
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

            Tire = await _context.Tire.FindAsync(id);

            if (Tire != null)
            {
                _context.Tire.Remove(Tire);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index2");
        }
    }
}
