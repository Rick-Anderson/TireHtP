﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TireHtP.Models;

namespace TireHtP.Pages.TireHt
{
    public class EditModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public EditModel(TireHtP.Models.TireHtPContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TireExists(Tire.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TireExists(string id)
        {
            return _context.Tire.Any(e => e.Id == id);
        }
    }
}
