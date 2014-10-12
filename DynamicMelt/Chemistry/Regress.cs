using System.Linq;
using DynamicMelt.Extensions;
using DynamicMelt.Model;

namespace DynamicMelt.Chemistry
{
	public static class Regress
	{
		public static double a0;
		public static double a1;
		public static double a2;
		public static double a3;
		public static double a4;
		public static double a5;
		public static double a6;

		public static double c0;
		public static double c1;
		public static double c2;
		public static double c3;
		public static double c4;
		public static double c5;

		public static double b0;
		public static double b1;
		public static double b2;
		public static double b3;
		public static double b4;

		private static readonly ParamsMdb _paramsMdb;

		static Regress()
		{
			MnREGR = new double[3001];
			LpREGR = new double[3001];
			TOTALFeOshlREGR = new double[3001];
			FeOshlREGR = new double[3001];
			Fe2O3shlREGR = new double[3001];

			_paramsMdb = new ParamsMdb();
		}

		public static double[] Fe2O3shlREGR { get; set; }

		public static double[] FeOshlREGR { get; set; }

		public static double[] LpREGR { get; set; }

		public static double[] MnREGR { get; set; }

		public static double[] TOTALFeOshlREGR { get; set; }

		public static void Load()
		{
			var range = LoadRange(0);

			a0 = range[2];
			a1 = range[3];
			a2 = range[4];
			a3 = range[5];
			a4 = range[6];
			a5 = range[7];
			a6 = range[8];

			range = LoadRange(1);

			c0 = range[2];
			c1 = range[3];
			c2 = range[4];
			c3 = range[5];
			c4 = range[6];
			c5 = range[7];

			range = LoadRange(2);

			b0 = range[2];
			b1 = range[3];
			b2 = range[4];
			b3 = range[5];
			b4 = range[6];
		}

		private static double[] LoadRange(int row)
		{
			return _paramsMdb.Regressions
				.SelectRowRange(row)
				.Select(x => x.ToDoubleOrZero())
				.ToArray();
		}
	}
}