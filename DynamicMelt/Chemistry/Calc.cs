namespace DynamicMelt.Chemistry
{
	public static class Calc
	{
		public static string MapMode, MapName;
		public static int MapStroka, MapBaseLenth;
		public static double Okislitel, Basis;
		public static int columnCounter, rowCounter;
		public static int i, counter;
		public static int[] jMAX;
		public static double[] Vog;
		public static double[,,] Lgr;
		public static double Estr, EstrBezDissip, LstrDissip, Impuls, W0, Fkr, Eco;
		public static double NperStr, NperStrBezDissip, NperCO, RoMet, RoMetRZ, Wpriv, Rkonv, FrudMet, FrudShl;
		public static double[] Ggidk, VmetRZ, VmetRZestimated, Hvanna, dhVanna, dH_H0;
		public static double EperCO, EperAr;
		public static double rRZ, rRZduga, ReX, KinVyaz, DinVyaz, Vme, Nco, Delta;
		public static double[] Hlunki, GmeRZ, GmeRZexit, VmetCirc, VmetCircEstimated;
		public static double aFeOravn, Rmax, fPrMaier, q0, Mi, M1, n, Psop, Ptor, GazoDinParam, Croc;
		public static double[] VcShlEstimated, Trz, pm;
		public static double Tsopla, TstrMin, JcoRZ, Jco2RZ;
		public static double[] Tstr;
		// Активности компонентов шлака по Пономаренко.

		// -------

		public static int iWhenBlowChange, VcShlStartMoment;

		static Calc()
		{
			jMAX = new int[3001];
			Vog = new double[3001];
			Lgr = new double[7, 3, 999];
			Ggidk = new double[5001];
			VmetRZ = new double[5001];
			VmetRZestimated = new double[3001];
			Hvanna = new double[5001];
			dhVanna = new double[5001];
			dH_H0 = new double[3001];
			Hlunki = new double[5001];
			GmeRZ = new double[5001];
			VmetCirc = new double[3001];
			VmetCircEstimated = new double[3001];
			GmeRZexit = new double[3001];
			VcShlEstimated = new double[3001];
			Trz = new double[5001];
			pm = new double[5001];
			Tstr = new double[5001];
		}
	}
}