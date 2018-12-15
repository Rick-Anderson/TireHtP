﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TireHtP.Models
{
    public class TireHtPContext : DbContext
    {
        public TireHtPContext (DbContextOptions<TireHtPContext> options)
            : base(options)
        {
        }

        public DbSet<TireHtP.Models.Tire> Tire { get; set; }
    }
}
