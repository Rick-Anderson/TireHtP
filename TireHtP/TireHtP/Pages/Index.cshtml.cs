﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TireHtP.Models;
using TireHtP.Pages.TireHt;

namespace TireHtP.Pages
{
    public class IndexModel : TireBaseModel
    {
        private readonly TireHtP.Models.TireHtPContext _context;

        public IndexModel(TireHtPContext context)
        {
            _context = context;
        }

        public IList<Tire> Tire { get; set; }

        public async Task OnGetAsync()
        {
            var sessionID = GetSessionID();

            var tires = from t in _context.Tire
                        where t.SessionID == sessionID
                        select t;

            if (tires.Count() == 0)
            {
                AddTires();
            }

            Tire = await tires.ToListAsync();
        }

        private void AddTires()
        {
            var tires = new Tire[]
            {
                new Tire {
                    Model = "Toyo OC",
                    Height = 37.0,
                    Width = 14.5,
                    WheelDiameter = 17.0,
                    MaxPSI=36,
                    Weight = 1110,
                    SessionID = GetSessionID()
                },
                 new Tire {
                    Model = "Generic",
                    Height = 37,
                    Width = 12.5,
                    WheelDiameter = 17.0,
                    MaxPSI=36.0,
                    Weight = 1110,
                    SessionID = GetSessionID()
                }
                // ,
                //new Tire {
                //    Model = "KO2",
                //    Height = 36.5,
                //    Width = 12.5,
                //    WheelDiameter = 17.0,
                //    MaxPSI=36.0,
                //    Weight = 1110,
                //    SessionID = GetSessionID()
                //}
                //,
                //new Tire {
                //    Height = 37.8,
                //    Width = 13.6,
                //    WheelDiameter = 17.0,
                //    MaxPSI=36.0,
                //    SessionID = GetSessionID()
                //}
            };

            foreach (Tire t in tires)
            {
                _context.Tire.Add(t);
            }

            _context.SaveChanges();
        }
    }
}