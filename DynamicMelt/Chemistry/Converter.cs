namespace DynamicMelt.Chemistry
{
	public class Converter
	{
		static Converter()
		{
			GportionSumm = new double[21];
			Gscrap = new double[5001];
			GizvPortion = new double[21];
			GizkPortion = new double[21];
			GdolPortion = new double[21];
			GvldolPortion = new double[21];
			GimfPortion = new double[21];
			GkoksPortion = new double[21];
			GpesPortion = new double[21];
			GrudaPortion = new double[21];
			GokalPortion = new double[21];
			GokatPortion = new double[21];
			GaglPortion = new double[21];
			GshpPortion = new double[21];
			Metall = new Metall();
		}

		public static double[] GaglPortion { get; set; }

		public static double[] GdolPortion { get; set; }

		public static double[] GimfPortion { get; set; }

		public static double[] GizkPortion { get; set; }

		public static double[] GizvPortion { get; set; }

		public static double[] GkoksPortion { get; set; }

		public static double[] GokalPortion { get; set; }

		public static double[] GokatPortion { get; set; }

		public static double[] GpesPortion { get; set; }

		public static double[] GportionSumm { get; set; }

		public static double[] GrudaPortion { get; set; }

		/// <summary>
		/// Лом в конвертере (при продувке.)
		/// </summary>
		public static double[] Gscrap { get; set; }

		public static double[] GshpPortion { get; set; }

		public static double[] GvldolPortion { get; set; }

		public static Metall Metall { get; set; }
	}
}