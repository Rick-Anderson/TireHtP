using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TireHtP.Models
{
    public class Tecr
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string SessionID { get; set; }

        public string Name { get; set; }

        public double First { get; set; }
        public double TC { get; set; }
        public double diff { get; set; }
        public double Portal { get; set; }
        public double TireRadius { get; set; }
        public double Tq { get; set; }
        public double Weight { get; set; }

    }
}
 