using System.Collections.Generic;
using DynamicMelt.Extensions;
using DynamicMelt.Model;

namespace DynamicMelt.Chemistry
{
	public static class Fakel
	{
		public static double pmIntercept;
		public static double pmQ;
		public static double pmTog;
		public static double pmHfur;
		public static double pmN2;
		public static double pmCOkCO2;

		public static double rRZIntercept;
		public static double rRZQ;
		public static double rRZTog;
		public static double rRZHfur;
		public static double rRZN2;
		public static double rRZCOkCO2;

		public static void Load(int selectedPlant)
		{
			Init(new ParamsMdb().Fakel.SelectRowNumbers(selectedPlant - 1));
		}

		private static void Init(IList<double> row)
		{
			pmIntercept = row[3];
			pmQ = row[4];
			pmTog = row[5];
			pmHfur = row[6];
			pmN2 = row[7];
			pmCOkCO2 = row[8];
			rRZIntercept = row[10];
			rRZQ = row[11];
			rRZTog = row[12];
			rRZHfur = row[13];
			rRZN2 = row[14];
			rRZCOkCO2 = row[15];
		}
	}
}