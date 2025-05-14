using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TireHtP.Models;
using TireHtP.Pages.TireHt;
using System.Linq;

namespace TireHtP.Pages.ECR
{
    public class IndexModel : TireBaseModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;
        private readonly IConfiguration Configuration;


        public IndexModel(TireHtP.Models.TireHtPContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IList<Tecr> tecrList { get; set; }

        public async Task OnGetAsync()
        {
            var sessionID = GetSessionID();

            var crVals = from t in _context.Tecr
                         where t.SessionID == sessionID
                         select t;

            if (crVals.Count() == 0)
            {
                AddCRs();
            }

            tecrList = await crVals.ToListAsync();
        }

        private void AddCRs()
        {
            var tecr = new Tecr[]
            {
                new Tecr
                {
                    Name = "Name",
                    diff = 5.38,
                    First = 2.1,
                    Portal = 1.2,
                    TC = 2.62,
                    TireRadius = 42.9,
                    Tq = 2000,
                    Weight = 3800,
                    SessionID = GetSessionID()

                }
            };

            foreach (var t in tecr)
            {
                _context.Tecr.Add(t);
            }
            _context.SaveChanges();


        }
    }
}
