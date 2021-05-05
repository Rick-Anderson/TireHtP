using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;

namespace TireHtP.Pages
{
    public class HelpModel : PageModel
    {
        private readonly IConfiguration Configuration;
        public double DynMult { get; set; }

        public HelpModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnGet()
        {
            double Width = 14.5;
            double Weight = 1100.0;
            double PSI = 3.0;

            var pl = Methods.PatchLength(Weight, PSI, Width);
            var diff = pl - 25.287356321839081;

            DynMult = Convert.ToDouble(Configuration["DynamicMultiplier"] ?? "2.5");

            ViewData["diff"] = diff;
        }
    }
}