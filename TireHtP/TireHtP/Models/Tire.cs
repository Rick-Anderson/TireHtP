﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TireHtP.Models
{
    public class Tire
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Model { get; set; }

        public string SessionID { get; set; }

        [Display(Name = "Diameter")]
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        [Display(Name = "Wheel Dia.")]
        public double WheelDiameter { get; set; }
        public double MaxPSI { get; set; }
    }
}
