using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using DynamicMelt.Model;

namespace DynamicMelt.ViewModel
{
    /// <summary>
    /// This is just a copy from VB code.
    /// </summary>
    internal class frmDebug
    {
        public static double slKmn;
        public static double slKcmno;
        public static double slKp;
        public static double slKc_feo;
        public static double slGmerz;
        public static double slrzK;
        public static double slKsi;
        public static double slrzGshl;
        public static double slKfe_co2;

        static frmDebug()
        {
            var misc = new MiscellaneousMdb();
            var numbers = misc.Reader
                .SelectColumnRange<string>("Adapt", 2)
                .Select(Convert.ToDouble)
                .ToArray();

            Debug.Assert(numbers.Length >= 9);

            slKmn = numbers[0];
            slKcmno = numbers[1];
            slKp = numbers[2];
            slKc_feo = numbers[3];
            slGmerz = numbers[4];
            slrzK = numbers[5];
            slKsi = numbers[6];
            slrzGshl = numbers[7];
            slKfe_co2 = numbers[8];
        }
    }
}