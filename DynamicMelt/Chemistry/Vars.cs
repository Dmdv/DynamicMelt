namespace DynamicMelt.Chemistry
{
	public static class Vars
	{

		static Vars()
		{
			Raspredelenie = new int[2002];
		}

		/// <summary>
		/// Энергия перемешивания струёй.
		/// </summary>
		public static double Estr;

		/// <summary>
		/// Импульс струй.
		/// </summary>
		public static double EstrBezDissip;

		/// <summary>
		/// Скорость истечения струй.
		/// </summary>
		public static double LstrDissip;
		public static double Impuls;
		public static double W0;

		/// <summary>
		/// Площадь критического сечения сопла.
		/// </summary>
		public static double Fkr;

		/// <summary>
		/// Энергия перемешивания засчет СО.
		/// </summary>
		public static double Eco;

		public static double pmZERO;

		/// <summary>
		/// Скорость прогрева ванны, пока не расплавился намороженный чугун.
		/// </summary>
		public static double dTchugPlavl;

		/// <summary>
		/// Процент интегрального расхода продувки, с которого начинается учет модели конца продувки.
		/// </summary>
		public static double BlowFinishPoint;

		/// <summary>
		/// Массив нормального распределения.
		/// </summary>
		public static int[] Raspredelenie;
	}
}