using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TireHtP.Pages
{
    public class HelpModel : PageModel
    {
        public void OnGet()
        {
            double Width = 14.5;
            double Weight = 1100.0;
            double PSI = 3.0;

            var pl = Methods.PatchLength(Weight, PSI, Width);
            var diff = pl - 25.287356321839081;

            ViewData["diff"] = diff;
        }
    }
}