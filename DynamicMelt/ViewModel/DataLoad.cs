using System;
using DynamicMelt.Chemistry;

namespace DynamicMelt.ViewModel
{
	public class DataLoad
	{
		public static void LoadContants()
		{
			Load_Constants();
			Load_Data();
			RegressLoad();
		}

		public static void Run()
		{
			Tube.Известь.Load();
			Tube.Известняк.Load();
			Tube.Доломит.Load();
			Tube.ВлажныйДоломит.Load();
			Tube.Имф.Load();
			Tube.Песок.Load();
			Tube.Кокс.Load();
			Tube.Окатыши.Load();
			Tube.Руда.Load();
			Tube.Окалина.Load();
			Tube.Агломерат.Load();
			Tube.Шпат.Load();

			Tube.Известняк.CaO = (56.0 / 100.0) * Tube.Известняк.CaCO3;
			Tube.Известняк.CO2 = (44.0 / 100.0) * Tube.Известняк.CaCO3;

			Tube.Окалина.FeO = 72.0 / 232.0 * Tube.Окалина.Fe3O4;
			Tube.Окалина.Fe2O3 = 160.0 / 232.0 * Tube.Окалина.Fe3O4;
			Tube.Шпат.CaO = 56.0 / 72.0 * Tube.Шпат.CaF2;

			Tube.ОставленныйШлак.Load();
			Tube.МиксерныйШлак.Load();

			LoadContants();
		}

		private static void Load_Constants()
		{
			Cp.Init();
			Hp.Init();
		}

		private static void Load_Data()
		{
			throw new NotImplementedException();
		}

		private static void RegressLoad()
		{
			throw new NotImplementedException();
		}
	}
}