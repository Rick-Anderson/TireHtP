namespace TireHtP.Models
{
    public class Tire
    {
        public string Id { get; set; }
        public string Model { get; set; }

        public string SessionID { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public double WheelDiameter { get; set; }
        public double MaxPSI { get; set; }
    }
}
