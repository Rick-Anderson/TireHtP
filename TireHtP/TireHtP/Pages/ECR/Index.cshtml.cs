using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireHtP.Models;
using TireHtP.Pages.TireHt;

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
                new() {
                    Name = "JHF-TF904",
                    diff = 5.38,
                    First = 2.74,
                    Portal = 1.92,
                    TC = 2.62,
                    TireRadius = 42.9,
                    Tq = 260,
                    Weight = 3800,
                    SessionID = GetSessionID()
                },
                new() {
                    Name = "LJR-RubiCrawler",
                    diff = 5.38,
                    First = 2.84,
                    Portal = 2.0,
                    TC = 4.0,
                    TireRadius = 42.9,
                    Tq = 230,
                    Weight = 6300,
                    SessionID = GetSessionID()
                },
                 new() {
                    Name = "LJR",
                    diff = 5.38,
                    First = 2.84,
                    Portal = 1.0,
                    TC = 4.0,
                    TireRadius = 42.9,
                    Tq = 230,
                    Weight = 6300,
                    SessionID = GetSessionID()
                },
                new() {
                    Name = "JLR",
                    diff = 4.1,
                    First = 2.84,
                    Portal = 1.0,
                    TC = 4.0,
                    TireRadius = 38.0,
                    Tq = 275,
                    Weight = 4700,
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
