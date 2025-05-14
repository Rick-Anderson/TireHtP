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
    public class IndexModel : PageModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public IndexModel(TireHtP.Models.TireHtPContext context)
        {
            _context = context;
        }

        public IList<TECR> TECR { get;set; }

        public async Task OnGetAsync()
        {
            TECR = await _context.TECR.ToListAsync();
        }
    }
}
