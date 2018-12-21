using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TireHtP.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Redirect("/TireHt");
        }
    }
}