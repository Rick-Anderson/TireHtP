﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TireHtP.Models;

namespace TireHtP.Pages.TireHt
{
    public class CreateModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public CreateModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tire Tire { get; set; }

        public IActionResult OnGet()
        {
            Tire = new Tire
            {
                Height = 38.0,
                Width = 14.5
            };
            return Page();
    }



    public async Task<IActionResult> OnPostAsync()
    {

            //Tire = new Tire {
            //    Height = 38.0,
            //    Width = 14.5 };

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Tire.Add(Tire);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
}