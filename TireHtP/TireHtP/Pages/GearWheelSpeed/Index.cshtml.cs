using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireHtP.Models;
using TireHtP.Pages.TireHt;

namespace TireHtP.Pages.GearWheelSpeed
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

        public IList<Car> Car { get; set; }

        public async Task OnGetAsync()
        {
            var sessionID = GetSessionID();

            var cars = from t in _context.Car
                       where t.SessionID == sessionID
                       select t;

            if (cars.Count() == 0)
            {
                AddCars();
            }

            Car = await _context.Car.ToListAsync();
        }

        private void AddCars()
        {
            var cars = new Car[]
            {
                new Car
                {
                    Model = "JLR-a",
                     DiffRatio = 4.1,
                      RPM = 5500,
                       TireDiameter = 31.5,
                        XferRatio = 4,
                         first = 4.71,
                         second = 3.13,
                         third = 2.1,
                         forth = 1.67,
                         fifth = 1.28,
                         sixth = 1,
                         seventh = .84,
                         eigth = .69,
                         nineth = 0,
                         tenth = 0,
                         reverse = 3.53,
                    SessionID = GetSessionID()
                }
            };

            foreach (Car t in cars)
            {
                _context.Car.Add(t);
            }

            _context.SaveChanges();
        }
    }
}
