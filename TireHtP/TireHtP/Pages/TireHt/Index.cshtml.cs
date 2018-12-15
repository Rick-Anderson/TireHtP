using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TireHtP.Models;

namespace TireHtP.Pages.TireHt
{
    public class IndexModel : TireBaseModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public IndexModel(TireHtPContext context)
        {
            _context = context;
        }

        public IList<Tire> Tire { get;set; }

        public async Task OnGetAsync()
        {
            var name = GetSessionID();


            Tire = await _context.Tire.ToListAsync();
        }
    }
}
