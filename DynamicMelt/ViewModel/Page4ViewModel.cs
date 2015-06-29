using System;
using DynamicMelt.Chemistry;

namespace DynamicMelt.ViewModel
{
	public class Page4ViewModel
	{
		private void RZ_New()
		{
			var j = 0;
			var rzCmetMid = new double[4000];
			Calc.rzGmet[0] = Calc.GmeRZ[i];
		}

		private void Tepl_Balans()
		{
			double Prop = 1.0 / 1000000.0;

			// тепло жидкого металла

			Calc.LeftTepl[1] = Prop * Calc.Ggidk[i - 6] * Calc.CpMet * Converter.Metall.T[i - 6];

			Hp.dHshl = 4.1868 * (0.289 * (Converter.Metall.T[i - 6] - 273) + 50);

			// Тепло шлака

			Calc.LeftTepl[2] = Prop * Tube.Шлаки[i - 6].G * Hp.dHshl;
			Calc.LeftTepl[3] = Prop * 6 * (Calc.VSi[i] / 28 * -Hp.dHsi_O2_mol + Calc.VP[i] / 31 * -Hp.dHp_O2_mol);
			Calc.tK = Calc.Tsopla;
			CpCalc();
			Calc.LeftTepl[4] = Prop * 6 * Calc.CpO2 * Calc.Tsopla * Продувка.Q[i] / 60 * 1.42;

			Calc.LeftTepl[5] = Prop *
							   (Tube.Шлаки[i].G *
								(Tube.Шлаки[i].FeO / 100.0 * -Hp.dHfe_O2_mol / 72.0 +
								 Tube.Шлаки[i].Fe2O3 / 100.0 * -Hp.dHfe_fe2o3_o2_mol / 160.0 * 2 +
								 Tube.Шлаки[i].MnO / 100.0 * -Hp.dHmn_O2_mol / 71.0) -
								Tube.Шлаки[i - 6].G *
								(Tube.Шлаки[i - 6].FeO / 100.0 * -Hp.dHfe_O2_mol / 72.0 +
								 Tube.Шлаки[i - 6].Fe2O3 / 100.0 * -Hp.dHfe_fe2o3_o2_mol / 160.0 * 2 +
								 Tube.Шлаки[i - 6].MnO / 100.0 * -Hp.dHmn_O2_mol / 71.0));

			// Поступающие сыпучие.

			Calc.LeftTepl[6] = 0;

			for (var counter = 0; counter < Calc.NOfLooseAdded; counter++)
			{
				Calc.LeftTepl[6] = Calc.LeftTepl[6] + Prop * 6 * (
					Tube.Известь.ALFA * Calc.Vizv[counter] * Cp.izv * Params.AirTemp
					+ Tube.Известняк.ALFA * Calc.Vizk[counter] * Cp.izk * Params.AirTemp
					+ Tube.Доломит.ALFA * Calc.Vdol[counter] * Cp.dol * Params.AirTemp
					+ Tube.ВлажныйДоломит.ALFA * Calc.Vvldol[counter] * Cp.vldol * Params.AirTemp
					+ Tube.Имф.ALFA * Calc.Vimf[counter] * Cp.IMF * Params.AirTemp
					+ Tube.Окатыши.ALFA * Calc.Vokat[counter] * Cp.okat * Params.AirTemp
					+ Tube.Руда.ALFA * Calc.Vruda[counter] * Cp.ruda * Params.AirTemp
					+ Tube.Окалина.ALFA * Calc.Vokal[counter] * Cp.okal * Params.AirTemp
					+ Tube.Агломерат.ALFA * Calc.Vagl[counter] * Cp.agl * Params.AirTemp
					+ Tube.Шпат.ALFA * Calc.Vshp[counter] * Cp.shp * Params.AirTemp
					+ Tube.Песок.ALFA * Calc.Vpes[counter] * Cp.pes * Params.AirTemp);
			}

			Calc.LeftTepl[7] = Prop * 6 * (-Hp.dHc_O2_mol * (Calc.Jco_MET[i] - Calc.Jco_PODM[i]) +
			                               -Hp.dHc_co2_mol * (Calc.Jco2_RZ[i] - Calc.Jco2_PODM[i]));

			// Эффекты указаны на кмоль оксида кремния и фосфора.

			Calc.LeftTepl[8] = Prop * 6 * (-Hp.dHsio2_2caosio2 * Calc.VSi[i] / 28 + -Hp.dHp2o5_3caop2o5 * Calc.VP[i] / 31 * 0.5);

			Calc.LeftTepl[9] = Prop * 6 * ((Cp.ChugSolid * Calc.Vchug[i] + Cp.LomSolid * Calc.Vlom[i]) * Tube.Чугун.Tlom
									  - (Hp.dHchugPlavl * Calc.Vchug[i] + Hp.dHlomPlavl * Calc.Vlom[i]));

			// Суммарно левая часть баланса

			Calc.LeftTeplSUMM[i] = 1 / Prop *
			                       (Calc.LeftTepl[1] + Calc.LeftTepl[2] + Calc.LeftTepl[3] + Calc.LeftTepl[4] + Calc.LeftTepl[5] +
			                        Calc.LeftTepl[6] + Calc.LeftTepl[7] + Calc.LeftTepl[8] + Calc.LeftTepl[9]);

			// Тепло жидкого металла
			Calc.RightTepl[1] = Prop * Calc.Ggidk[i] * Cp.Met * Converter.Metall.T[i];

			Hp.dHshl = 4.1868 * (0.289 * (Converter.Metall.T[i] - 273) + 50);

			// Тепло шлака

			Calc.RightTepl[2] = Prop * Tube.Шлаки[i].G * Hp.dHshl;
			Calc.tK = Params.Tog[i];
			CpCalc();
			Calc.RightTepl[3] = Prop * 6 * Params.Tog[i] *
			                    (Calc.CpCO * 28 * (Calc.Jco_MET[i] - Calc.Jco_PODM[i]) +
			                     Calc.CpCO2 * 44 * (Calc.Jco2_MET[i] - Calc.Jco2_PODM[i]));
			
			// Потери тепла на футеровку и нагрев Ar продувки

			Calc.RightTepl[4] = Prop * 6 *
			                    (Params.TeplLoss * Продувка.Q[i] / 60 / Tube.Дутье.V +
								 Tube.Дутье.VarBlow[i] / 60 * 1.784 * Cp.Ar * (Converter.Metall.T[i] - Params.AirTemp));

			// Потери тепла с угаром железа

			// Теплосодержание пиирофорного железа
			Calc.Q_aFe_vix = Params.ValfaFe[i] * Cp.Fe * Converter.Metall.T[i];

			// Теплосодержание FeO в дыме.
			Calc.Q_aFe_FeO_vix = Calc.VO2aFe[i] * 72 / 16 * Cp.FeORZ * Converter.Metall.T[i];


			Calc.RightTepl[5] = Prop * 6 * (Calc.Q_aFe_vix + Calc.Q_aFe_FeO_vix);

			// Суммарно правая часть баланса

			Calc.RightTeplSumm[i] = 1 / Prop *
			                        (Calc.RightTepl[1] + Calc.RightTepl[2] + Calc.RightTepl[3] + Calc.RightTepl[4] +
			                         Calc.RightTepl[5] + Calc.RightTepl[6]);

		}

		private void CpCalc()
		{
			Calc.CpCO = 0.0000823 * Calc.tK + 1.0277021;
			Calc.CpCO2 = 0.0001254 * Calc.tK + 0.9673658;
			Calc.CpO2 = 0.0000698 * Calc.tK + 0.9478846;
			Calc.CpN2 = 0.0000829 * Calc.tK + 1.0136983;
		}

		private void Vagner()
		{
			// Активности компонентов металла

			var metall = Converter.Metall;

			Calc.fC = Math.Pow(10,
				((0.0581 + 158 / metall.T[i - 6]) * metall.C[i - 6]
				 - 0.012 * metall.Mn[i - 6]
				 + (0.008 + 162 / metall.T[i - 6]) * metall.Si[i - 6]
				 + 0.051 * metall.P[i - 6]
				 + 0.046 * metall.S[i - 6]
				 - 0.34 * metall.O[i - 6]));

			Calc.aC[i] = Calc.fC * metall.C[i - 6];

			Calc.fMn = Math.Pow(10,
				(
					-0.07 * metall.C[i - 6]
					- 0.0035 * metall.P[i - 6]
					- 0.048 * metall.S[i - 6]
					- 0.083 * metall.O[i - 6]));

			Calc.aMn[i] = Calc.fMn * metall.Mn[i - 6];

			Calc.fSi = Math.Pow(10,
				((-0.023 + 380 / metall.T[i - 6])
				 * metall.C[i - 6]
				 + 0.002 * metall.Mn[i - 6]
				 + (0.089 - 34.5 / metall.T[i - 6]) * metall.Si[i - 6]
				 + 0.11 * metall.P[i - 6]
				 + 0.056 * metall.S[i - 6]
				 - 0.23 * metall.O[i - 6]));

			Calc.aSi[i] = Calc.fSi * metall.Si[i - 6];

			Calc.fP = Math.Pow(10,
				(0.13 * metall.C[i - 6]
				 + 0.12 * metall.Si[i - 6]
				 + 0.062 * metall.P[i - 6]
				 + 0.028 * metall.S[i - 6]
				 + 0.13 * metall.O[i - 6]));

			Calc.aP[i] = Calc.fP * metall.P[i - 6];

			// Железо

			Calc.Qfec = (5100 - 10 * metall.T[i - 6]) / 4.1868;
			Calc.Qfesi = (-28500 - 6.09 * metall.T[i - 6]) / 4.1868;
			Calc.Qfemn = -9.11 * metall.T[i - 6] / 4.1868;
			Calc.Qfep = (-29200 - 4.6 * metall.T[i - 6]) / 4.1868;

			Calc.SummNj = Calc.nFe[i - 6] + Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6];

			Calc.dHfec = Calc.Qfec * Calc.nC[i - 6] * (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Calc.SummNj ^ 2;
			Calc.dHfesi = Calc.Qfesi * Calc.nSi[i - 6] * (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Calc.SummNj ^ 2;
			Calc.dHfemn = Calc.Qfemn * Calc.nMn[i - 6] * (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Calc.SummNj ^ 2;
			Calc.dHfep = Calc.Qfep * Calc.nP[i - 6] * (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Calc.SummNj ^ 2;
			Calc.dHFe = Calc.dHfec + Calc.dHfesi + Calc.dHfemn + Calc.dHfep;

			Calc.GammaFe = Math.Exp(1 / Calc.R / metall.T[i - 6] * Calc.dHFe);
			Calc.AdaptK[33] = 1;
			Calc.aFe[i] = Calc.AdaptK[33] * metall.Fe[i - 6] * Calc.GammaFe;

		}
	}
}
