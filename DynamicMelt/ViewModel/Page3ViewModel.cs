using System;
using DynamicMelt.Chemistry;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	public class Page3ViewModel : ViewModelBase
	{
		public void ExecuteNext()
		{
			Converter.GizvPortion[0] = Tube.Известь.GOnHand;
			Converter.GizkPortion[0] = Tube.Известняк.GOnHand;
			Converter.GdolPortion[0] = Tube.Доломит.GOnHand;
			Converter.GvldolPortion[0] = Tube.ВлажныйДоломит.GOnHand;
			Converter.GimfPortion[0] = Tube.Имф.GOnHand;
			Converter.GkoksPortion[0] = Tube.Кокс.GOnHand;
			Converter.GrudaPortion[0] = Tube.Руда.GOnHand;
			Converter.GokalPortion[0] = Tube.Окалина.GOnHand;
			Converter.GokatPortion[0] = Tube.Окатыши.GOnHand;
			Converter.GaglPortion[0] = Tube.Агломерат.GOnHand;
			Converter.GshpPortion[0] = Tube.Шпат.GOnHand;
			Converter.GpesPortion[0] = Tube.Песок.GOnHand;

			PrecountStep3();
		}

		private static void PrecountStep3()
		{
			Cp.izv = 4.1868 * 1000 * (11.86 + 0.00108 * Params.AirTemp - 166000 / Math.Pow(Params.AirTemp, 2)) * 1 / 44.0;
			Cp.izk = 4.1868 * 1000 * (24.98 + 0.00524 * Params.AirTemp - 620000 / Math.Pow(Params.AirTemp, 2)) * 1 / 100.0;
			Cp.ruda = 4.1868 * 1000 * (31.7 + 0.00176 * Params.AirTemp) * 1 / 160.0;
			Cp.shp = 4.1868 * 1000 * (25.81 + 0.0025 * Params.AirTemp) * 1 / 78.0;
			Cp.okal = 4.1868 * 1000 * 48 * 1 / 232.0;
			Cp.okat = 4.1868 * 1000 * 48 * 1 / 232.0;
			Cp.agl = 4.1868 * 1000 * (31.7 + 0.00176 * Params.AirTemp) * 1 / 160.0;
			Cp.koks = 930;
			Cp.pes = 930;
			Cp.dol = 930;
			Cp.vldol = 930;
			Cp.IMF = 930;
			Cp.Densing = 930;

			Tube.Лом.Nsov = 1.5 * Tube.Лом.DolyaLegkovesa + 1;

			Volumes.Vm = Tube.Лом.G / 7800.0 + Tube.Чугун.GChug[0] / 7000;

			Volumes.Vk = 3.14 * ConverterSize.H1 / 6 *
						 (3.0 / 4.0 * Math.Pow(ConverterSize.D1, 2) + Math.Pow(ConverterSize.H1, 2)) +
						 3.14 * ConverterSize.H2 / 12 *
						 (Math.Pow(ConverterSize.D, 2) + ConverterSize.D * ConverterSize.D1 + Math.Pow(ConverterSize.D1, 2));

			Volumes.Vshl = (Tube.ОставленныйШлак.G + Tube.МиксерныйШлак.G) / 3000.0;

			// Расчет уровня металла

			if (Volumes.Vm >= Volumes.Vk)
			{
				Levels.H0 = ConverterSize.H1 + ConverterSize.H2 +
							(Volumes.Vm - Volumes.Vk) * 4 / 3.14 / Math.Pow(ConverterSize.D, 2);
			}
			else
			{
				Levels.H0 = ConverterSize.H1 + ConverterSize.H2 +
							(Volumes.Vm - Volumes.Vk) * 12 / 3.14 / (Math.Pow(ConverterSize.D, 2)
																	 + ConverterSize.D * ConverterSize.D1 +
																	 Math.Pow(ConverterSize.D1, 2));
			}

			// Расчет толщины шлака

			if (Volumes.Vm + Volumes.Vshl >= Volumes.Vk)
			{
				Tube.Шлак.Hshl[0] = ConverterSize.H1 + ConverterSize.H2 +
									(Volumes.Vm + Volumes.Vshl - Volumes.Vk) * 4 / 3.14 /
									Math.Pow(ConverterSize.D, 2) - Levels.H0;
			}
			else
			{
				Tube.Шлак.Hshl[0] = ConverterSize.H1 + ConverterSize.H2 +
									(Volumes.Vm + Volumes.Vshl - Volumes.Vk) * 12 / 3.14 /
									(Math.Pow(ConverterSize.D, 2) + ConverterSize.D * ConverterSize.D1 +
									 Math.Pow(ConverterSize.D1, 2)) - Levels.H0;
			}

			Vars.Hpuz = 0.5 * Levels.H0;
			Tube.Шлаки[0].G = Tube.ОставленныйШлак.G + Tube.МиксерныйШлак.G;
			Converter.Gscrap[0] = Tube.Лом.G;

			Calc.VmetCirc[0] = 0;
			Calc.VmetRZ[0] = 0;
			Calc.iWhenBlowChange = 0;

			Params.alfaFeSUMM = 0;
			Calc.VcShlStartMoment = 0;
			Converter.Metall.T[0] = Tube.Чугун.T - Tube.Чугун.TCool;

			Calc.Trz[0] = Converter.Metall.T[0];
			Calc.Tstr[0] = Converter.Metall.T[0];
			Params.Tog[0] = Converter.Metall.T[0];

			Params.GchugSolid[0] = 32000 +
								   30334 * (Converter.Gscrap[0] * Tube.Лом.Nsov * Math.Pow(Converter.Gscrap[0], 0.66)) /
								   (Tube.Чугун.GChug[0] * Converter.Metall.T[0]);

			Calc.Ggidk[0] = Tube.Чугун.GChug[0] - Params.GchugSolid[0];

			Converter.Metall.C[0] = Tube.Чугун.C;
			Converter.Metall.Si[0] = Tube.Чугун.Si;
			Converter.Metall.Mn[0] = Tube.Чугун.Mn;
			Converter.Metall.P[0] = Tube.Чугун.P;
			Converter.Metall.O[0] = 0.0025 / Tube.Чугун.C;
			Converter.Metall.S[0] = Tube.Чугун.S;

			Converter.Metall.Fe[0] =
				100
				- Converter.Metall.C[0]
				- Converter.Metall.Si[0]
				- Converter.Metall.Mn[0]
				- Converter.Metall.P[0]
				- Converter.Metall.S[0];

			// Расчет температуры твердой фазы на момент начала продувки (тепловой баланс)

			Tube.Чугун.Tlom = 273 +
							  (Tube.Лом.G * Cp.LomSolid * (Params.AirTemp - 273) +
							   Tube.Чугун.GChug[0] * Cp.ChugLiquid * (Tube.Чугун.T - 273) + Hp.dHchugPlavl * Params.GchugSolid[0] -
							   Calc.Ggidk[0] * Cp.ChugLiquid * (Tube.Чугун.T - 273 - Tube.Чугун.TCool)) /
							  (Params.GchugSolid[0] * Cp.ChugSolid + Tube.Лом.G * Cp.LomSolid);

			// Объем газовой полости конвертера.

			ConverterSize.Vpolost[0] = 1.0 / 3.0 * 3.1415 * ConverterSize.HUpperConus *
									   (Math.Pow((ConverterSize.D / 2.0), 2) + ConverterSize.D / 2.0 * ConverterSize.Dgorl / 2.0 + Math.Pow((ConverterSize.Dgorl / 2), 2)) +
									   3.1415 * (Math.Pow(ConverterSize.D / 2.0, 2) * (ConverterSize.Hmain + ConverterSize.H1 + ConverterSize.H2 - Levels.H0));

			// кмоль

			Calc.Jso2_GAS[0] = Calc.nUl;
			Calc.Jco_GAS[0] = Calc.nUl;
			Calc.Jco2_GAS[0] = Calc.nUl;
			Calc.Jn2_GAS[0] = 0.79 * ConverterSize.Vpolost[0] / 24.8 * 298 / Params.Tog[0];
			Calc.Jo2_GAS[0] = 0.21 * ConverterSize.Vpolost[0] / 24.8 * 298 / Params.Tog[0];

			// Состав газовой фазы в нулевой момент времени.

			Calc.COgas[0] = Calc.nUl;
			Calc.CO2gas[0] = Calc.nUl;
			Calc.O2gas[0] = 21;

			Calc.N2gas[0] = 79;
			Calc.pCOgas[0] = Calc.COgas[0] / 100.0;

			// XC шлака

			Tube.Шлаки[0].FeO = (Tube.ОставленныйШлак.FeO * Tube.ОставленныйШлак.G +
			                     Tube.МиксерныйШлак.FeO * Tube.МиксерныйШлак.G) / Tube.Шлаки[0].G;

			Tube.Шлаки[0].Fe2O3 = (Tube.ОставленныйШлак.Fe2O3 * Tube.ОставленныйШлак.G +
			                       Tube.МиксерныйШлак.Fe2O3 * Tube.МиксерныйШлак.G) / Tube.Шлаки[0].G;

			Tube.Шлаки[0].TOTALFeO = Tube.Шлаки[0].FeO + Tube.Шлаки[0].Fe2O3;


			Tube.Шлаки[0].SiO2 = (Tube.ОставленныйШлак.SiO2 * Tube.ОставленныйШлак.G +
			                      Tube.МиксерныйШлак.SiO2 * Tube.МиксерныйШлак.G) / Tube.Шлаки[0].G;

			Tube.Шлаки[0].MnO = (Tube.ОставленныйШлак.MnO * Tube.ОставленныйШлак.G +
			                     Tube.МиксерныйШлак.MnO * Tube.МиксерныйШлак.G) / Tube.Шлаки[0].G;

			Tube.Шлаки[0].MgO = (Tube.ОставленныйШлак.MgO * Tube.ОставленныйШлак.G +
			                     Tube.МиксерныйШлак.MgO * Tube.МиксерныйШлак.G) / Tube.Шлаки[0].G;

			Tube.Шлаки[0].P2O5 = (Tube.ОставленныйШлак.P2O5 * Tube.ОставленныйШлак.G +
			                      Tube.МиксерныйШлак.P2O5 * Tube.МиксерныйШлак.G) / Tube.Шлаки[0].G;

			Tube.Шлаки[0].CaO = 100 -
			                    Tube.Шлаки[0].TOTALFeO -
			                    Tube.Шлаки[0].SiO2 -
			                    Tube.Шлаки[0].MnO -
			                    Tube.Шлаки[0].MgO -
			                    Tube.Шлаки[0].P2O5;

			Calc.GTOTALFeOshl[0] = Tube.Шлаки[0].TOTALFeO * Tube.Шлаки[0].G / 100.0;

			Calc.GcaoShl[0] = Tube.Шлаки[0].CaO * Tube.Шлаки[0].G / 100.0;
			Calc.Gsio2Shl[0] = Tube.Шлаки[0].SiO2 * Tube.Шлаки[0].G / 100.0;
			Calc.GmnoShl[0] = Tube.Шлаки[0].MnO * Tube.Шлаки[0].G / 100.0;
			Calc.GmgoShl[0] = Tube.Шлаки[0].MgO * Tube.Шлаки[0].G / 100.0;
			Calc.Gp2o5Shl[0] = Tube.Шлаки[0].P2O5 * Tube.Шлаки[0].G / 100.0;


			// Мольные доли компонентов расплава

			Calc.nFe[0] = (Converter.Metall.Fe[0] * Calc.Ggidk[0] / 100) / 0.056;
			Calc.nC[0] = (Converter.Metall.C[0] * Calc.Ggidk[0] / 100) / 0.012;
			Calc.nSi[0] = (Converter.Metall.Si[0] * Calc.Ggidk[0] / 100) / 0.028;
			Calc.nMn[0] = (Converter.Metall.Mn[0] * Calc.Ggidk[0] / 100) / 0.055;
			Calc.nP[0] = (Converter.Metall.P[0] * Calc.Ggidk[0] / 100) / 0.03;

			// Температура исходящего из сопла кислорода
			Calc.Tsopla = 150;


			Tube.Лом.Fe = 100 - (Tube.Лом.C + Tube.Лом.Si + Tube.Лом.Mn + Tube.Лом.P + Tube.Лом.S);

			Calc.nFeLom = (Tube.Лом.Fe / 56.0) /
			              (Tube.Лом.Fe / 56.0 + Tube.Лом.C / 12.0 + Tube.Лом.Si / 28.0 + Tube.Лом.Mn / 55.0 + Tube.Лом.P / 32.0 +
			               Tube.Лом.S / 16.0);

			Calc.CmetCRITICAL = 0.13;
		}
	}
}