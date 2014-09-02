namespace DynamicMelt.Chemistry
{
	public static class ConverterSize
	{
		public static double H1;
		public static double H2;
		public static double D1;
		public static double D;
		public static double DNew;

		/// <summary>
		/// Высота цилиндрической части конвертера.
		/// </summary>
		public static double Hmain;

		/// <summary>
		/// Высота верхнего конуса.
		/// </summary>
		public static double HUpperConus;

		/// <summary>
		/// Диаметр горловины.
		/// </summary>
		public static double Dgorl;

		public static double minHfur;
		public static double[] Vpolost;

		static ConverterSize()
		{
			Vpolost = new double[3001];
		}
	}
}