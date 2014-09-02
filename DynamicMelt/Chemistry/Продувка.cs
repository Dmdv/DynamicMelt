namespace DynamicMelt.Chemistry
{
	public static class Продувка
	{
		public static double Nsop;
		public static double Dkr;
		public static double Dexit;
		public static double Fexit;
		public static double SoploVerticalAngle;
		public static double SoploOpenHalfAngle;
		public static double Qstandart;
		public static double Qo2SUMM;

		public static double[] Hfur;
		public static double[] Q;

		static Продувка()
		{
			Hfur = new double[5001];
			Q = new double[5001];
		}
	}
}