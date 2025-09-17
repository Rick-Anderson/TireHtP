using System;

namespace TireHtP
{

    public static class Methods
    {
        public static double Lift(double Height, double Weight, double PSI, double Width)
        {
            // b is tire patch length/2. See tire image a bottom of file.
            var b = B(Weight, PSI, Width);
            return Math.Round(Math.Sqrt(Height * Height / 4.0 - b * b), 2);
        }

        public static double PatchLength(double Weight, double PSI, double Width)
        {
            var pl = Weight / PSI / Width;
            var diff = pl - 25.287356321839081;
            return pl;
            // return Weight / PSI / Width;
        }
        public static double B(double Weight, double PSI, double Width)
        {
            // Divide by 2 to get the right triangle B of the tire patch lenghth.
            return PatchLength(Weight, PSI, Width) / 2;
        }

        public static string PatchArea(double Weight, double PSI)
        {
            return string.Format("{0:0.0}", Weight / PSI);
        }

        public static (string lift, string strDiff, double diff, string patchLen)
            LiftAndDiff(double Height, double Weight, double PSI, double Width, double WheelDiameter)
        {
            var lift = Lift(Height, Weight, PSI, Width);
            var diff = Math.Round(Height / 2.0 - lift, 2);
            //string patchLen = (2 * B(Weight, PSI, Weight)).ToString();
            string patchLen = string.Format("{0:0.0}", PatchLength(Weight, PSI, Width));
            return StrLiftAndDiff(diff, lift, WheelDiameter, patchLen);
        }

        public static (string strLift, string strDiff, double diff, string patchLen)
            StrLiftAndDiff(double Diff, double Lift, double WheelDiameter, string PatchLen)
        {
            string str_Diff = Diff.ToString();
            string str_Lift = (Lift > (WheelDiameter / 2.0 - .5) || Lift.ToString().Equals("NaN") != true)
                ? Lift.ToString() : "Rim";

            if (str_Lift.Equals("Rim"))
            {
                str_Diff = "X";
                PatchLen = "X";
            }
            return (str_Lift, str_Diff, Diff, PatchLen);
        }

        public static (string lift, string strDiff, double diff, string patchLen, string sfootPrint)
        LiftAndDiffPA(double Height, double Weight, double PSI, double Width, double WheelDiameter)
        {
            var lift = Lift(Height, Weight, PSI, Width);
            var diff = Math.Round(Height / 2.0 - lift, 2);
            var liftdiff = Methods.LiftAndDiff(Height, Weight, PSI, Width, WheelDiameter);

            return (liftdiff.lift, liftdiff.strDiff, diff, liftdiff.patchLen, PatchArea(Weight, PSI));
        }
    }

    public static class SpeedCalc
    {
        public static string MPH(double RPM, double TransRatio, double DiffRatio, double XferRatio,
                                 double TireDiameter, double PortalRatio)
        {
            var three36 = 60.0 / 63360.0 * Math.PI;         // Really 1/336 rounded.
            return (three36 * RPM * TireDiameter / TransRatio / XferRatio / DiffRatio/ PortalRatio).ToString("0.0");
        }
    }
    public static class ECRx
    {
        private static double BaseRatio(double first, double tc, double portal, double diff)
            => first * tc * portal * diff;

        public static string CR(double first, double tc, double portal, double diff)
        {
            return BaseRatio(first, tc, portal, diff).ToString("0.0");
        }

        public static string TireSz(double first, double tc, double portal, double diff, double tireSize)
        {
            return (BaseRatio(first, tc, portal, diff)
                      / tireSize / 2.0).ToString("0.00");
        }

        public static string TqTrCR(double first, double tc, double portal, double diff, double tireSize, double tq)
        {
            return (BaseRatio(first, tc, portal, diff) / tireSize / 2.0
                      * tq).ToString("0.0");
        }

        public static string TqTr_wtCR(double first, double tc, double portal, double diff, double tireSize, double tq, double wt)
        {
            return (BaseRatio(first, tc, portal, diff) / tireSize / 2.0 * tq 
                     / wt * 1000.0).ToString("0.0");
        }
    }

    /*
    public static class ECRx
    {
        // CR
        private static double BaseRatio(double first, double tc, double portal, double diff)
            => first * tc * portal * diff;

        // Tire adjustment factor
        private static double TireAdjusted(double baseRatio, double tireSize)
            => baseRatio / (tireSize / 2.0);

        // Previous + Torque adjustment
        private static double TorqueAdjusted(double tireAdjusted, double tq)
            => tireAdjusted * tq;

        // Previous + Weight adjustment
        private static double WeightAdjusted(double torqueAdjusted, double wt)
            => torqueAdjusted / wt * 1000.0;

        // String API for Razor Pages

        public static string CR(double first, double tc, double portal, double diff)
            => BaseRatio(first, tc, portal, diff).ToString("0.0");

        public static string TireSz(double first, double tc, double portal, double diff, double tireSize)
            => TireAdjusted(BaseRatio(first, tc, portal, diff), tireSize).ToString("0.00");

        public static string TqTrCR(double first, double tc, double portal, double diff, double tireSize, double tq)
            => TorqueAdjusted(TireAdjusted(BaseRatio(first, tc, portal, diff), tireSize), tq).ToString("0.0");

        public static string TqTr_wtCR(double first, double tc, double portal, double diff, double tireSize, double tq, double wt)
            => WeightAdjusted(TorqueAdjusted(TireAdjusted(BaseRatio(first, tc, portal, diff), tireSize), tq), wt).ToString("0.0");
    } */


}

/*
     , - ~ ~ ~ - ,
 , '               ' ,
,                       ,
,                         ,
,                           ,
,            /|             ,
,  Height /   |            ,
,      /     |Lift        ,
,   /       |           ,
 ,------B------------ '
   ' - , _ _ _ ,  '
*/

/*
=((($B$2/(B11*$C$6))*$E$2*PI())*60)/63360

MPH = (((RPM/(gearRatio*diffRatio*transRatio)*tireDiameter*PI)*60/63360;
* */