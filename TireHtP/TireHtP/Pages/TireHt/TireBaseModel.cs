using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using TireHtP.Models;

namespace TireHtP.Pages.TireHt
{
    public class TireBaseModel : PageModel
    {
        public const string SessionKeyName = "_Name";

        public string GetSessionID()
        {
            var name = HttpContext.Session.GetString(SessionKeyName);
            if (string.IsNullOrEmpty(name))
            {
                HttpContext.Session.SetString(SessionKeyName, Guid.NewGuid().ToString());
            }
            return HttpContext.Session.GetString(SessionKeyName);
        }

        public double Lift(double radius, double psi, double width, double weight)
        {
            var b = weight / psi / width / 2.0;
            return Math.Sqrt(radius * radius - b * b);
        }
    }
}
