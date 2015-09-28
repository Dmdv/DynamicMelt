using System;
using DynamicMelt.Chemistry;
using DynamicMelt.Model;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
    // ReSharper disable InconsistentNaming

    public class Page4ViewModel : ViewModelBase
	{
		private readonly DebuViewModel _debugViewModel;
        public static double[, ,] Vj;
        public const int Fe = 1, Mn = 2, C = 3, Si = 4, P = 5, S = 6, O2 = 1, CO2 = 2;

        static Page4ViewModel()
        {
            Vj = new double[6, 2, 998];
        }

		public Page4ViewModel(DebuViewModel debugViewModel)
		{
			_debugViewModel = debugViewModel;
			// Test
		}

		private void DebugValuesLoad()
		{
			var misc = new MiscellaneousMdb();
			var doubles = misc.Reader.SelectColumnRange<double>("Adapt", 2);
		}

		private void RZ_New()
		{
			// TODO: delete;
			var i = 0;

			var j = 0;
			var rzCmetMid = new double[4000];
			Calc.rzGmet[0] = Calc.GmeRZ[i];

			// Доля металла, поступающего в РЗ

			Calc.rzK[i] = _debugViewModel.slrzK / 100.0;
			Calc.rzGmetEff[i, 0] = Calc.rzGmet[0] * Calc.rzK[i];

			// Доля шлака, поступающего в РЗ.
			// 100% это не весь шлак, а его масса к массе Gmerz равна соотношениям масс шлака и Ме в ванне

			Calc.AdaptK[32] = _debugViewModel.slrzGshl / 100.0;

			Calc.rzGshl[0] = Calc.AdaptK[32] * Calc.rzGmet[0] * (Tube.Шлаки[i - 6].G / Calc.Ggidk[i - 6]);

			// Парциальные давления газов.

			Calc.Po2COMMON[0] = Calc.nUl +
			                    (Calc.Jo2str2[i]) / (Calc.Jcostr2[i] + Calc.Jco2str2[i] + Calc.Jn2str2[i] + Calc.Jo2str2[i]);
			Calc.Pco2COMMON[0] = Calc.nUl +
			                     (Calc.Jco2str2[i]) / (Calc.Jcostr2[i] + Calc.Jco2str2[i] + Calc.Jn2str2[i] + Calc.Jo2str2[i]);
			Calc.PcoCOMMON[0] = Calc.nUl +
			                    (Calc.Jcostr2[i]) / (Calc.Jcostr2[i] + Calc.Jco2str2[i] + Calc.Jn2str2[i] + Calc.Jo2str2[i]);
			Calc.Pso2COMMON[0] = Calc.nUl;
			Calc.Pn2COMMON[0] = Calc.nUl +
			                    (Calc.Jn2str2[i]) / (Calc.Jcostr2[i] + Calc.Jco2str2[i] + Calc.Jn2str2[i] + Calc.Jo2str2[i]);

			var metall = Converter.Metall;

			Calc.rzTmet[0] = metall.T[i - 6];
			Calc.rzTgas[0] = Calc.Tstr[i];

			Calc.rzCmet[0] = metall.C[i - 6];
			Calc.rzSimet[0] = metall.Si[i - 6];
			Calc.rzMnmet[0] = metall.Mn[i - 6];
			Calc.rzPmet[0] = metall.P[i - 6];
			Calc.rzSmet[0] = metall.S[i - 6];
			Calc.rzFemet[0] = metall.Fe[i - 6];

			var шлак = Tube.Шлаки[i - 6];

			Calc.rzFeOshl[0] = шлак.FeO;
			Calc.rzFe2O3shl[0] = шлак.Fe2O3;
			Calc.rzTOTALFeOshl[0] = шлак.TOTALFeO;
			Calc.rzCaOshl[0] = шлак.CaO;
			Calc.rzSiO2shl[0] = шлак.SiO2;
			Calc.rzMnOshl[0] = шлак.MnO;
			Calc.rzP2O5shl[0] = шлак.P2O5;
			Calc.rzMgOshl[0] = шлак.MgO;

			// Количество газа в РЗ в начале расчета.

			Calc.rzjO2summ[0] = Calc.Jo2str2[i] - Params.ValfaFe[i] / 56 * 0.5 * 0.7;
			Calc.rzjCOsumm[0] = Calc.Jcostr2[i];
			Calc.rzjCO2summ[0] = Calc.Jco2str2[i];
			Calc.rzjN2summ[0] = Calc.Jn2str2[i];
			Calc.rzjSO2summ[0] = Calc.nUl;

			j = 0;

			// а - элемент
			// В - окислитель
			// NotValid - 0 или 1, показывающая невозможность протекания реакции

			int a, B, StoppP;

			var NotValid = new int[6, 2];

			Calc.Basis = Fe;
			Calc.Okislitel = O2;
			StoppP = 0;

			if (metall.Si[i - 6] <= Tube.Сталь.Si)
			{
				NotValid[Si, O2] = 1;
				NotValid[Si, CO2] = 1;
			}

			// Do Until StoppP = 1
			// Равновесная константа

            // По Явойскому стр. 259 здесь и ниже.
			Calc.KFe_O2[j] = Math.Exp(-(Hp.dHfe_O2_mol - Hp.dSfe_O2_mol * Calc.rzTmet[j]) / Calc.rzTmet[j] / 8.31);
			Calc.KMn_O2[j] = Math.Exp(-(Hp.dHmn_O2_mol - Hp.dSmn_O2_mol * Calc.rzTmet[j]) / Calc.rzTmet[j] / 8.31);
			Calc.KC_O2[j] = Math.Exp(-(Hp.dHc_O2_mol - Hp.dSc_O2_mol * Calc.rzTmet[j]) / Calc.rzTmet[j] / 8.31);
			Calc.KSi_O2[j] = Math.Exp(-(Hp.dHsi_O2_mol - Hp.dSsi_O2_mol * Calc.rzTmet[j]) / Calc.rzTmet[j] / 8.31);
			Calc.KP_O2[j] = Math.Exp(-5.0 / 4.0 * (Hp.dHp_O2_mol - Hp.dSp_O2_mol * Calc.rzTmet[j]) / Calc.rzTmet[j] / 8.31);
			// Посчитано по Явойскому с газообразным кислородом.ы
			Calc.KS_O2[j] = Math.Exp(-(Hp.dHs_O2_mol - Hp.dSs_O2_mol * Calc.rzTmet[j]) / Calc.rzTmet[j] / 8.31);


            Calc.KFe_CO2[j] = frmDebug.slKfe_co2 / 100.0 *
                              Math.Exp(
                                  -(Hp.dHfe_O2_mol - Hp.dHco_co2_mol - (Hp.dSfe_O2_mol - Hp.dSco_co2_mol) * Calc.rzTmet[j]) /
                                  Calc.rzTmet[j] / 8.31);
			Calc.KMn_CO2[j] =
				Math.Exp(-(Hp.dHmn_O2_mol - Hp.dHco_co2_mol - (Hp.dSmn_O2_mol - Hp.dSco_co2_mol) * Calc.rzTmet[j]) / Calc.rzTmet[j] /
				         8.31);
			Calc.KC_CO2[j] =
				Math.Exp(-(Hp.dHc_O2_mol - Hp.dHco_co2_mol - (Hp.dSc_O2_mol - Hp.dSco_co2_mol) * Calc.rzTmet[j]) / Calc.rzTmet[j] /
				         8.31);
			Calc.KSi_CO2[j] =
				Math.Exp(-(Hp.dHsi_O2_mol + 2 * -Hp.dHco_co2_mol - (Hp.dSsi_O2_mol - 2.0 * Hp.dSco_co2_mol) * Calc.rzTmet[j]) /
				         Calc.rzTmet[j] / 8.31);
			Calc.kP_CO2[j] =
				Math.Exp(
					-(5.0 / 4.0 * (Hp.dHp_O2_mol - Hp.dSp_O2_mol * Calc.rzTmet[j]) -
					  5.0 / 2.0 * (Hp.dHco_co2_mol - Hp.dSco_co2_mol * Calc.rzTmet[j])) /
					Calc.rzTmet[j] / 8.31);
			Calc.kS_CO2[j] =
				Math.Exp(
					-(Hp.dHs_O2_mol - Hp.dSs_O2_mol * Calc.rzTmet[j] - 2.0 * (Hp.dHco_co2_mol - Hp.dSco_co2_mol * Calc.rzTmet[j])) /
					Calc.rzTmet[j] / 8.31);

            // TODO: Check precedense of Math.Pow over division.
            // логарифмы соотношений констант (движущая сила)

            // Железо + О2, равновесная на фактическую.

            // O2
		    Calc.Lgr[Fe, O2, j] =
                Math.Log(Calc.KFe_O2[j] / (Calc.rzTOTALFeOshl[j] / Math.Pow(Calc.Po2COMMON[j], 0.5)));

		    Calc.Lgr[Mn, O2, j] =
		        Math.Log(Calc.KMn_O2[j] / (Calc.rzMnOshl[j] / Calc.rzMnmet[j] / Math.Pow(Calc.Po2COMMON[j], 0.5)));

            Calc.Lgr[C, O2, j] =
                Math.Log(Calc.KC_O2[j] / (Calc.PcoCOMMON[j] / Calc.rzCmet[j] / Math.Pow(Calc.Po2COMMON[j], 0.5)));

            Calc.Lgr[Si, O2, j] =
                Math.Log(Calc.KSi_O2[j] / (Calc.rzSiO2shl[j] / Calc.rzSimet[j] / Calc.Po2COMMON[j]));

		    Calc.Lgr[P, O2, j] =
		        Math.Log(Calc.KP_O2[j] / (Math.Pow(Calc.rzP2O5shl[j], 0.5) / Calc.rzPmet[j] / Math.Pow(Calc.Po2COMMON[j], 1.25)));

		    Calc.Lgr[S, O2, j] = 
                Math.Log(Calc.KS_O2[j] / (Calc.Pso2COMMON[j] / Calc.rzSmet[j] / Calc.Po2COMMON[j]));

            // CO2

            Calc.Lgr[Fe, CO2, j] =
                Math.Log(Calc.KFe_CO2[j] / (Calc.rzTOTALFeOshl[j] * Calc.PcoCOMMON[j] / Calc.Pco2COMMON[j]));

            Calc.Lgr[Mn, CO2, j] =
                Math.Log(Calc.KMn_CO2[j] / (Calc.rzMnOshl[j] * Calc.PcoCOMMON[j] / Calc.rzMnmet[j] / Calc.Pco2COMMON[j]));

		    Calc.Lgr[C, CO2, j] =
		        Math.Log(Calc.KC_CO2[j] / (Math.Pow(Calc.PcoCOMMON[j], 2) / Calc.rzCmet[j] / Calc.Pco2COMMON[j]));

		    Calc.Lgr[Si, CO2, j] =
		        Math.Log(Calc.KSi_CO2[j] /
		                 (Calc.rzSiO2shl[j] * Math.Pow(Calc.PcoCOMMON[j], 2) / Calc.rzSimet[j] /
		                  Math.Pow(Calc.Pco2COMMON[j], 2)));

		    Calc.Lgr[P, CO2, j] =
		        Math.Log(Calc.kP_CO2[j] /
		                 (Math.Pow(Calc.rzP2O5shl[j], 0.5) * Math.Pow(Calc.PcoCOMMON[j], 2.5) / Calc.rzPmet[j] /
		                  Math.Pow(Calc.Pco2COMMON[j], 2.5)));

		    Calc.Lgr[S, CO2, j] = 0;

            // Блокировка реакций, невозможных термодинамически.

		    for (var v = 1; v <= 6; v++)
		    {
		        for (var n = 1; n <= 2; n++)
		        {
                    if (Calc.Lgr[v, n, j] <= 1)
                        NotValid[v, n] = 1;
		        }
		    }

            // Поиск нового базисного компонента расплава, если реакция прежнего базиса невозможна.
		    if (NotValid[Calc.Basis, Calc.Okislitel] == 1)
		    {
		        var temp02 = 0.0d;

		        for (var v = 1; v <= 6; v++)
		        {
                    for (var n = Calc.Okislitel; n <= 2; n++)
		            {
		                if (NotValid[v, n] == 0 && Calc.Lgr[v, n, j] > temp02)
		                {
		                    temp02 = Calc.Lgr[v, n, j];
		                    Calc.Basis = v;
		                }
		            }    
		        }
		    }

            // кмоль/сек - шаг скнирования
		    Vj[Calc.Basis, Calc.Okislitel, j] = 0.1 / 20.0;

            // Скорость окисления компонентов засчет кислорода, кмоль/сек
		    for (var v = 1; v <= 6; v++)
		    {
		        for (var n = Calc.Okislitel; n <= 2; n++)
		        {
		            Vj[v, n, j] = (1 - NotValid[v, n]) *
		                               Vj[Calc.Basis, Calc.Okislitel, j] *
		                               Calc.Lgr[v, n, j] /
		                               Calc.Lgr[Calc.Basis, Calc.Okislitel, j];

		            if (Vj[v, n, j] < 0)
		                Vj[v, n, j] = 0;
		        }
		    }

		    var temp01 = 0.0d;

            // Проверка того, что скорость не больше, чем запас.
		    while (true)
		    {
		        if (Vj[C, O2, j] + Vj[C, CO2, j] <
		            Calc.rzCmet[j] / 100 * Calc.rzGmetEff[i, j] / 12)
		        {
                    // Если сумма скоростей меньше запаса
		            break;
		        }

                Vj[C, O2, j] = 0.9 * Vj[C, O2, j];
                Vj[C, CO2, j] = 0.9 * Vj[C, CO2, j];

                if (Vj[C, O2, j] + Vj[C, CO2, j] < 1.0 / 1000000.0)
		        {
                    Vj[C, O2, j] = 0;
                    Vj[C, CO2, j] = 0;
		        }
		    }

		    while (true)
		    {
		        if (Vj[Mn, O2, j] + Vj[Mn, CO2, j] <
		            Calc.rzMnmet[j] / 100 * Calc.rzGmetEff[i, j] / 55.0)
		        {
		            break;
		        }

                Vj[Mn, O2, j] = 0.9 * Vj[Mn, O2, j];
                Vj[Mn, CO2, j] = 0.9 * Vj[Mn, CO2, j];
		    }

		    while (true)
		    {
		        if (Vj[Si, O2, j] + Vj[Si, CO2, j] <
		            Calc.rzSimet[j] / 100 * Calc.rzGmetEff[i, j] / 28.0)
		        {
		            break;
		        }

		        Vj[Si, O2, j] = 0.9 * Vj[Si, O2, j];
		        Vj[Si, CO2, j] = 0.9 * Vj[Si, CO2, j];
		    }

		    while (true)
		    {
		        if (Vj[P, O2, j] + Vj[P, CO2, j] <
		            Calc.rzPmet[j] / 100 * Calc.rzGmetEff[i, j] / 31.0)
		        {
		            break;
		        }

		        Vj[P, O2, j] = 0.9 * Vj[P, O2, j];
		        Vj[P, CO2, j] = 0.9 * Vj[P, CO2, j];
		    }

		    while (true)
		    {
		        if (Vj[S, O2, j] + Vj[S, CO2, j] <
		            Calc.rzSmet[j] / 100 * Calc.rzGmetEff[i, j] / 32.0)
		        {
		            break;
		        }

		        Vj[S, O2, j] = 0.9 * Vj[S, O2, j];
		        Vj[S, CO2, j] = 0.9 * Vj[S, CO2, j];
		    }

            // Баланс газовой фазы (кмоль)
		    Calc.rzjO2income[j] =
		        -(0.5 * Vj[Fe, O2, j] + Vj[Si, O2, j] + 0.5 * Vj[Mn, O2, j] + 0.5 * Vj[C, O2, j] + 5.0 / 4.0 * Vj[P, O2, j] +
		          Vj[S, O2, j]);

		    Calc.rzjCOincome[j] = Vj[C, O2, j] + Vj[Fe, CO2, j] + 2 * Vj[Si, CO2, j] + Vj[Mn, CO2, j] + 2 * Vj[C, CO2, j] +
		                          5.0 / 2.0 * Vj[P, CO2, j] + 2 * Vj[S, CO2, j];

		    Calc.rzjCO2income[j] =
		        -(Vj[Fe, CO2, j] + Vj[C, CO2, j] + 2 * Vj[Si, CO2, j] + Vj[Mn, CO2, j] + 5.0 / 2.0 * Vj[P, CO2, j] +
		          2 * Vj[S, CO2, j]);

		    Calc.rzjCOsumm[j + 1] = Calc.rzjCOsumm[j] + Calc.rzjCOincome[j];
            Calc.rzjN2summ[j + 1] = Calc.rzjN2summ[j];
            Calc.rzjSO2summ[j + 1] = Calc.rzjSO2summ[j] + Vj[S, O2, j] + Vj[S, CO2, j];
            Calc.rzjO2summ[j + 1] = Calc.rzjO2summ[j] + Calc.rzjO2income[j];

            // Баланс металла и шлака
		}

		private void Tepl_Balans()
		{
			// TODO: delete;
			var i = 0;

			var Prop = 1.0 / 1000000.0;

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
			// TODO: delete;
			var i = 0;

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

			Calc.dHfec = Calc.Qfec * Calc.nC[i - 6] *
			             (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Math.Pow(Calc.SummNj, 2);

			Calc.dHfesi = Calc.Qfesi * Calc.nSi[i - 6] *
                          (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Math.Pow(Calc.SummNj, 2);

			Calc.dHfemn = Calc.Qfemn * Calc.nMn[i - 6] *
                          (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Math.Pow(Calc.SummNj, 2);

			Calc.dHfep = Calc.Qfep * Calc.nP[i - 6] *
                         (Calc.nC[i - 6] + Calc.nSi[i - 6] + Calc.nMn[i - 6] + Calc.nP[i - 6] + Calc.nS[i - 6]) / Math.Pow(Calc.SummNj, 2);

			Calc.dHFe = Calc.dHfec + Calc.dHfesi + Calc.dHfemn + Calc.dHfep;

			Calc.GammaFe = Math.Exp(1 / Calc.R / metall.T[i - 6] * Calc.dHFe);
			Calc.AdaptK[33] = 1;
			Calc.aFe[i] = Calc.AdaptK[33] * metall.Fe[i - 6] * Calc.GammaFe;
		}
	}
}