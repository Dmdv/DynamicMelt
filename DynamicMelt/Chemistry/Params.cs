namespace DynamicMelt.Chemistry
{
	public static class Params
	{
		public const int IterationNumber = 6;

		public static double alfaFe;
		public static double L;
		public static double StAndShlLoss;
		public static double TAUprost;
		public static double TAUprostREAL;
		public static double TeplFutLoss;
		public static double TAPtime;
		public static double Lp;
		public static double[] Tog;
		public static int SelectedPlant;
		public static int SelectedAdaptedPlant;
		public static int FutTypeSelected;
		public static int LomTypeSelected;
		public static int AirTemp;
		public static int FutDurability;
		public static int BlowingTime;
		public static bool BottomBlowUse;
		public static double TplavChug;
		// ���������� ��� ���������, ����� 4 ����.
		public static int Round;
		// ����������, ������ �� �� P, � ����� ����������� �� ����������.
		public static bool OkPst;
		// ����������, ������������� �� �������� ������������� ��������.
		public static bool LessThanZero;
		public static string InputForm;
		public static bool IsDuplex;
		public static double[] GchugSolid;
		public static double SummGloose;
		public static int Prirost;
		public static double tK;

		public static double Q1;
		public static double Q2;
		public static double Q3;
		public static double Q4;
		public static double Q5;
		public static double Q6;

		static Params()
		{
			��������� = new ���������();
			���������� = new ����������();
			���������� = new ����������();
			Tog = new double[3001];
			GchugSolid = new double[3001];
		}

		public static ���������� ���������� { get; set; }

		public static ��������� ��������� { get; set; }

		public static ���������� ���������� { get; set; }
	}
}