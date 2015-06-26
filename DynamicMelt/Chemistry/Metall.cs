namespace DynamicMelt.Chemistry
{
	public class Metall
	{
		public Metall()
		{
			G = new double[5001];
			Fe = new double[5001];
			C = new double[5001];
			Si = new double[5001];
			Mn = new double[5001];
			P = new double[5001];
			S = new double[5001];
			O = new double[5001];
			T = new double[5001];
			TPlav = new double[5001];
		}

		public double[] G { get; set; }

		public double[] Fe { get; set; }

		public double[] C { get; set; }

		public double[] Si { get; set; }

		public double[] Mn { get; set; }

		public double[] P { get; set; }

		public double[] S { get; set; }

		public double[] O { get; set; }

		public double[] T { get; set; }

		public double[] TPlav { get; set; }
	}
}