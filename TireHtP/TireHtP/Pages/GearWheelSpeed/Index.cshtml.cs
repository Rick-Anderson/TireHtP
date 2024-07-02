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

            Car = await cars.ToListAsync();
        }

        private void AddCars()
        {
            var cars = new Car[]
            {
            new Car
            {
                Model = "JLR-auto",
                ModelShort = "JLR-a",
                 DiffRatio = 4.1,
                  RPM = 5000,
                   TireDiameter = 32.8,
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
                     reverse = -3.53,
                SessionID = GetSessionID()
            },
            new Car
            {
                Model = "JLR-38",
                 ModelShort = "JL38",
                 DiffRatio = 4.1,
                  RPM = 5000,
                   TireDiameter = 37.5,
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
                     reverse = -3.53,
                SessionID = GetSessionID()
            },
             new Car
            {
               Model = "LJR",
                ModelShort = "LJR",
                 DiffRatio = 5.38,
                  RPM = 5000,
                   TireDiameter = 42.9,
                    XferRatio = 4,
                     first = 2.84,
                     second = 1.57,
                     third = 1,
                     forth = .69,
                     fifth = 0,
                     sixth = 0,
                     seventh = 0,
                     eigth = 0,
                     nineth = 0,
                     tenth = 0,
                     reverse = -2.21,
                SessionID = GetSessionID()
            },
            new Car
            {
                Model = "JL-auto",
                 ModelShort = "JL-a",
                 DiffRatio = 3.45,
                  RPM = 5000,
                   TireDiameter = 31.5,
                    XferRatio = 2.72,
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
                     reverse = -3.53,
                SessionID = GetSessionID()
            },
            new Car
            {
                Model = "XR",
                 ModelShort = "XR",
                 DiffRatio = 4.56,
                  RPM = 5000,
                   TireDiameter = 34.5,
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
                     reverse = -3.53,
                SessionID = GetSessionID()
            },
            new Car
            {
               Model = "JLR-6sp",
                ModelShort = "JLR-6",
                 DiffRatio = 4.1,
                  RPM = 5000,
                   TireDiameter = 31.5,
                    XferRatio = 4,
                     first = 5.13,
                     second = 2.63,
                     third = 1.53,
                     forth = 1,
                     fifth = .81,
                     sixth = .72,
                     seventh = 0,
                     eigth = 0,
                     nineth = 0,
                     tenth = 0,
                     reverse = -4.49,
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