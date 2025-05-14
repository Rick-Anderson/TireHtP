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
                                 double TireDiameter)
        {
            var three36 = 60.0 / 63360.0 * Math.PI;         // Really 1/336 rounded.
            return (three36 * RPM * TireDiameter / TransRatio / XferRatio / DiffRatio).ToString("0.0");
        }
    }
    public static class ECR
    {
        public static string CR(double first, double tc, double diff)
        {
            return (first + tc * diff).ToString("0.0");
        }
    }
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