using System;

namespace TireHtP
{
    public static class Methods
    {
        public static double Lift(double Height, double Weight, double PSI, double Width)
        {
            var b = B(Weight, PSI, Width);
            return Math.Round(Math.Sqrt(Height * Height / 4.0 - b*b ), 2);
        }

        public static double B(double Weight, double PSI, double Width)
        {
            return Weight / PSI / Width / 2.0;
        }

        public static (string lift, string strDiff, double diff) LiftAndDiff(double Height, double Weight, double PSI, double Width, 
            double WheelDiameter)
        {
            var lift = Methods.Lift(Height, Weight, PSI, Width);
            var diff = Math.Round(Height / 2.0 - lift, 2);

            return StrLiftAndDiff(diff, lift, WheelDiameter);
        }

        public static (string strLift, string strDiff, double diff) StrLiftAndDiff(double Diff, double Lift, double WheelDiameter)
        {
            string str_Diff = Diff.ToString();
            string str_Lift = (Lift > (WheelDiameter / 2.0 - .5) || Lift.ToString().Equals("NaN") != true)
                ? Lift.ToString() : "Rim";

            if (str_Lift.Equals("Rim"))
            {
                str_Diff = "X";
            }
            return (str_Lift, str_Diff, Diff);
        }
    }
}
