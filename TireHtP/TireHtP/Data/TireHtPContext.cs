using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TireHtP.Models;

namespace TireHtP.Models
{
    public class TireHtPContext : DbContext
    {
        public TireHtPContext (DbContextOptions<TireHtPContext> options)
            : base(options)
        {
        }

        public DbSet<TireHtP.Models.Tire> Tire { get; set; }

        public DbSet<TireHtP.Models.Car> Car { get; set; }
    }
}
