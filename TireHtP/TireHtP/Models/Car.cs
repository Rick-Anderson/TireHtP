using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TireHtP.Models
{
    public class Car1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Model { get; set; }

        public string SessionID { get; set; }

        [Display(Name = "Tire Diameter")]
        public double TireDiameter { get; set; }
        public double RPM { get; set; }
        public double[] TransRatio;
        public double DiffRatio { get; set; }
        public double XferRatio { get; set; }
    }
    public class Car
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Model { get; set; }

        public string SessionID { get; set; }

        [Display(Name = "Tire Diameter")]
        public double TireDiameter { get; set; }
        public double RPM { get; set; }
        public double first { get; set; }
        public double second { get; set; }
        public double third { get; set; }
        public double forth { get; set; }
        public double fifth { get; set; }
        public double sixth { get; set; }
        public double seventh { get; set; }
        public double eigth { get; set; }
        public double nineth { get; set; }
        public double tenth { get; set; }
        public double reverse { get; set; }
        public double DiffRatio { get; set; }
        public double XferRatio { get; set; }
    }
}
