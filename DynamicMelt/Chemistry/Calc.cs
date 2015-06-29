using System;

namespace DynamicMelt.Chemistry
{
	public static class Calc
	{
		public const double nUl = 0.000001;

		public static double Q_aFe_vix, Q_aFe_FeO_vix;
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

		public static double[] aFeOfact, aCaOfact, aSiO2fact, aMnOfact, aMgOfact, aP2O5fact, aAl2O3fact, aTiO2fact, aK2Ofact;

		public static double[] KizbitokGaza;

		public static double[] VfeoSUMM, VfeCO2, VC, VSi, VMn, VP, VS, Vchug;

		public static double VfeRastv, Vo2Str, Jco2Str, Gfeo, Gsio2, Go2Shl, Go2Si, deltaQchug;

		public static double[] VfeRZ, VmnRZ, VpRZ, VsiRZ, VsRZ;

		public static double dTchugPlavl;

		public static double QshlObr, GchugTv, dMuShl, SumN, Q10, Q11, Q12, Q13, Q14;

		public static double[] VcRZ, Vlom;

		public static double[] VcRZ_o2,
		                       VcRZ_co2,
		                       VfeRZ_o2,
		                       VfeRZ_co2,
		                       VmnRZ_o2,
		                       VmnRZ_co2,
		                       VsiRZ_o2,
		                       VsiRZ_co2,
		                       VpRZ_o2,
		                       VpRZ_co2,
		                       VsRZ_o2,
		                       VsRZ_co2;

		public const double P0 = 110000, R = 8.31;

		public static double Hpuz;

		public static double dolyaO2naFe, dolyaO2naSi, dolyaO2naMn, dolyaO2naP, dolyaO2naC;

		public static double Sigma;

		public static double QmeTme, Qco2Tstr, Qo2Tstr, QmeTmeRZ, QfeoRZ, QcoTrz, Qco2Trz;

		public static double[] GcaoShl, Gsio2Shl, GTOTALFeOshl, GmgoShl, GmnoShl, Gp2o5Shl;


		// -------

		public static int iWhenBlowChange, VcShlStartMoment;

		public static double[] SO2Gas, COgas, CO2gas, O2gas, N2gas, pCOgas;

		public static double[] Jo2str1, Jco_PODM, Jco2_PODM, Jn2_PODM, Jo2_PODM, Jso2_PODM, JcoX;

		public static double Jco_PODMCount, Jco2_PODMCount, Jn2_PODMCount, Jo2_PODMCount, JcoXCount;

		public static double[] Jso2_GAS, Jco_GAS, Jco2_GAS, Jn2_GAS, Jo2_GAS;

		public static double D10, D20, D30, DALL, DALLSAVE, D40;

		public static double[] Jco2str2, Jcostr2, Jn2str2, Jo2str2, SummJstr2;

		public static double[] VcShl, VmnShl, VsiShl, VpShl, VsShl, VcMnO;

		public static int NOfLooseAdded;

		public static double[] Vizv, Vizk, Vdol, Vvldol, Vimf, Vpes, Vruda, Vokat, Vokal, Vagl, Vshp;

		public static double SummNj, nFeLom, nFeLiq;

		public static double[] nFe, nC, nMn, nP, nSi, nS;

		public static double Qfec, Qfesi, Qfemn, Qfep;

		public static double dHFe, dHfec, dHfesi, dHfemn, dHfep;

		public static double GammaFe, dMUfeSL;

		public static double[] aFe;

		public static double GammaMn, GammaCa, GammaSi, GammaP;

		public static double[] aC, aMn, aSi, aP;

		public static double ecC, ecSi, fC, fMn, fSi, fP;

		public static double CmetCRITICAL, CmetRZexit;

		public static double[] Jo2_RZ, Jco_RZ, Jco2_RZ, Jso2_RZ, Jn2_RZ;

		public static double[] Jco_MET, Jco2_MET, Jo2_MET, Jn2_MET, Jso2_MET, Jo2_ATM, Jn2_ATM;

		public static double[] Jco_OUT, Jco2_OUT, Jo2_OUT, Jn2_OUT, Jso2_OUT;

		public static double deltaQ;

		public static double[] ChugLeft, ChugRight;

		public static double[] ChugLeftSumm, ChugRightSumm;

		public static double[] LeftTepl, RightTepl;

		public static double[] LeftTeplSUMM, RightTeplSumm;

		public const double Cm = 0.09;

		public const double CCC = 0.537;

		public static double VyZT, EEE, MuT, ENERG;

		public const double dHcaco3 = 4839940.8 / 1000.0;

		public const double dH2caosio2 = -1879873.2 / 1000.0;

		public const double dSfe_co2_mol = 17.369;

		public static double dGfe_co2, Kfe_co2Ravn;

		public static double dGsi_feo, Ksi_feoFact, Ksi_feoRavn, SLsi_feo;

		public static double dGc_feo, Kc_feoFact, Kc_feoRavn, SLc_feo;

		public static double dGmn_feo, Kmn_feoFact, Kmn_feoRavn, SLmn_feo;

		public static double dGp_feo, Kp_feoFact, Kp_feoRavn, SLp_feo;

		public static double dGc_mno, Kc_mnoFact, Kc_mnoRavn, SLc_mno;

		public static double CpMet, CpMetRZ, CpLomSolid, CpChugSolid, CpChugLiquid, CpFeORZ;

		public static double Int1, Int2;

		public static double[] VcRZestim, VfeRZestim;

		public static double AdaptP, AdaptSi, AdaptMn, AdaptC_FeO, GpodsosSAVE;

		public static double[] AdaptK, Gpodsos, GpodsosATM;

		public static double[] O2fakel, N2fakel, COfakel, CO2fakel;

		public static double Egas, Fme, Fkladki, Epr;

		public static double[] JcoFe_Feo, Jco2Fe_Feo, Jso2S_O2, Vo2C_CO, VO2aFe, SimetRavn, vSi_TEST;

		public static double Qrz0, Qrz1, Qrz2, Qrz3, Qrz4, Qrz5, Qrz6, Qrz7, Qrz8, Qrz9, pmZERO;

		public static int MapEntry;

		public static double CpH2O, CpCO, CpCO2, CpAr, CpFeO, CpFe, CpO2, CpN2, tK;

		// Далее из файла komolova

		public static double[] Po2COMMON, Pco2COMMON, PcoCOMMON, Pn2COMMON, Pso2COMMON;

		public static double Gfe_O2_ostatok;

		public static double[] rzCmet, rzSimet, rzMnmet, rzPmet, rzSmet, rzFemet;

		public static double[] rzTmet, rzTgas, rzGshl, rzGmet;

		public static double[] rzFeOshl, rzFe2O3shl, rzTOTALFeOshl, rzCaOshl, rzSiO2shl, rzMnOshl, rzP2O5shl, rzMgOshl;

		// Образование РЗ в рез-те О-В реакций.

		public static double[] rzjCOincome, rzjCO2income, rzjO2income;

		public static double[] rzjCOsumm, rzjCO2summ, rzjO2summ, rzjN2summ, rzjSO2summ, rzjGASsumm, ln_KFe_fakt_ravn;

		public static double v_Fe_O2, v_C_O2, v_Mn_O2, v_Si_O2, v_P_O2, v_S_O2;

		public static double[,,] Vj;

		// Эффективная доля массы РЗ.

		public static double[] rzK;

		// Эффективная масса РЗ по i и j

		public static double[,] rzGmetEff;

		public static double[] Dlunki;

		public static double[] KFe_CO2, KMn_CO2, KC_CO2, KSi_CO2, kP_CO2, kS_CO2;

		public static double V_Fe_CO2, v_C_CO2, v_Mn_CO2, v_Si_CO2, v_P_CO2, v_S_CO2;

		public static double[] Q_aFe_O2;

		public static double Q_CO_prixod, Q_CO2_prixod, Q_O2_prixod, Q_N2_prixod, Q_SO2_prixod;

		public static double Q_Fe_O2, Q_C_O2, Q_Mn_O2, Q_Si_O2, Q_P_O2, Q_S_O2;

		public static double[] Q_metRZ_prihod,
		                       Q_shlRZ_prihod,
		                       Q_metRZ_exit,
		                       Q_shlRZ_exit,
		                       QgasRZ_prihod,
		                       QgasRZ_exit,
		                       Prihod_Tepla,
		                       Rashod_Tepla;

		public static double Q_CO_exit, Q_CO2_exit, Q_O2_exit, Q_N2_exit, Q_SO2_exit;

		public static double Q_Fe_CO2, Q_C_CO2, Q_Mn_CO2, Q_Si_CO2, Q_P_CO2, Q_S_CO2;

		public static double[] Q_REAKCII;

		public static double[,] OSHIBKA_TEPLA;

		public static double OSHIBKA_SAVE;

		public static double[] QsummRZ, QsummRZExit;

		public static double[] rzGmet_Loose, rzGshlak_Income;

		public static double[] KFe_O2, KMn_O2, KSi_O2, KC_O2, KP_O2, KS_O2;

		public static double[] summ_v_c_rz, summ_v_fe_rz, summ_v_si_rz, summ_v_mn_rz, summ_v_s_rz, summ_v_p_rz;

		public static double[] summ_v_c_rz_o2,
		                       summ_v_c_rz_co2,
		                       summ_v_fe_rz_o2,
		                       summ_v_fe_rz_co2,
		                       summ_v_mn_rz_o2,
		                       summ_v_mn_rz_co2,
		                       summ_v_si_rz_o2,
		                       summ_v_si_rz_co2,
		                       summ_v_s_rz_o2,
		                       summ_v_s_rz_co2,
		                       summ_v_p_rz_o2,
		                       summ_v_p_rz_co2;

		public static double[] feo_rz, mn_rz, sio2_rz, p2o5_rz;

		public static double[] SLDfe, SLDc, SLDmn, SLDsi, SLDfe1;

		static Calc()
		{
			SLDfe = new double[1000];
			SLDc = new double[1000];
			SLDmn = new double[1000];
			SLDsi = new double[1000];
			SLDfe1 = new double[1000];

			feo_rz = new double[1000];
			mn_rz = new double[1000];
			sio2_rz = new double[1000];
			p2o5_rz = new double[1000];

			summ_v_c_rz_o2 = new double[1000];
			summ_v_c_rz_co2 = new double[1000];
			summ_v_fe_rz_o2 = new double[1000];
			summ_v_fe_rz_co2 = new double[1000];
			summ_v_mn_rz_o2 = new double[1000];
			summ_v_mn_rz_co2 = new double[1000];
			summ_v_si_rz_o2 = new double[1000];
			summ_v_si_rz_co2 = new double[1000];
			summ_v_s_rz_o2 = new double[1000];
			summ_v_s_rz_co2 = new double[1000];
			summ_v_p_rz_o2 = new double[1000];
			summ_v_p_rz_co2 = new double[1000];

			summ_v_c_rz = new double[1000];
			summ_v_fe_rz = new double[1000];
			summ_v_si_rz = new double[1000];
			summ_v_mn_rz = new double[1000];
			summ_v_s_rz = new double[1000];
			summ_v_p_rz = new double[1000];

			KFe_O2 = new double[1000];
			KMn_O2 = new double[1000];
			KSi_O2 = new double[1000];
			KC_O2 = new double[1000];
			KP_O2 = new double[1000];
			KS_O2 = new double[1000];

			rzGmet_Loose = new double[1000];
			rzGshlak_Income = new double[1000];

			QsummRZ = new double[3000];
			QsummRZExit = new double[3000];

			OSHIBKA_TEPLA = new double[1000, 1000];

			Q_REAKCII = new double[1000];

			Q_metRZ_prihod = new double[1000];
			Q_shlRZ_prihod = new double[1000];
			Q_metRZ_exit = new double[1000];
			Q_shlRZ_exit = new double[1000];
			QgasRZ_prihod = new double[1000];
			QgasRZ_exit = new double[1000];
			Prihod_Tepla = new double[1000];
			Rashod_Tepla = new double[1000];

			Q_aFe_O2 = new double[1000];

			KFe_CO2 = new double[1000];
			KMn_CO2 = new double[1000];
			KC_CO2 = new double[1000];
			KSi_CO2 = new double[1000];
			kP_CO2 = new double[1000];
			kS_CO2 = new double[1000];

			Dlunki = new double[3993];

			rzGmetEff = new double[3000,998];

			rzK = new double[3000];

			Vj = new double[6, 2, 998];

			ln_KFe_fakt_ravn = new double[1000];

			rzjCOsumm = new double[1000];
			rzjCO2summ = new double[1000];
			rzjO2summ = new double[1000];
			rzjN2summ = new double[1000];
			rzjSO2summ = new double[1000];
			rzjGASsumm = new double[1000];

			rzjCOincome = new double[1000];
			rzjCO2income = new double[1000];
			rzjO2income = new double[1000];

			rzFeOshl = new double[1000];
			rzFe2O3shl = new double[1000];
			rzTOTALFeOshl = new double[1000];
			rzCaOshl = new double[1000];
			rzSiO2shl = new double[1000];
			rzMnOshl = new double[1000];
			rzP2O5shl = new double[1000];
			rzMgOshl = new double[1000];

			rzTmet = new double[1000];
			rzTgas = new double[1000];
			rzGshl = new double[1000];
			rzGmet = new double[1000];

			rzCmet = new double[1000];
			rzSimet = new double[1000];
			rzMnmet = new double[1000];
			rzPmet = new double[1000];
			rzSmet = new double[1000];
			rzFemet = new double[1000];

			Po2COMMON = new double[1000];
			Pco2COMMON = new double[1000];
			PcoCOMMON = new double[1000];
			Pn2COMMON = new double[1000];
			Pso2COMMON = new double[1000];

			SimetRavn = new double[3001];
			vSi_TEST = new double[3001];

			Vo2C_CO = new double[3001];
			VO2aFe = new double[3001];

			JcoFe_Feo = new double[3001];
			Jco2Fe_Feo = new double[3001];
			Jso2S_O2 = new double[3001];

			O2fakel = new double[3001];
			N2fakel = new double[3001];
			COfakel = new double[3001];
			CO2fakel = new double[3001];

			AdaptK = new double[50];
			Gpodsos = new double[5001];
			GpodsosATM = new double[3001];

			VcRZestim = new double[5001];
			VfeRZestim = new double[5001];

			LeftTeplSUMM = new double[3001];
			RightTeplSumm = new double[3001];

			LeftTepl = new double[21];
			RightTepl = new double[21];

			ChugLeftSumm = new double[3001];
			ChugRightSumm = new double[3001];

			ChugLeft = new double[21];
			ChugRight = new double[21];

			Jco_OUT = new double[3001];
			Jco2_OUT = new double[3001]; 
			Jo2_OUT = new double[3001];
			Jn2_OUT = new double[3001];
			Jso2_OUT = new double[3001];

			Jo2_ATM = new double[3001];
			Jn2_ATM = new double[3001];

			Jco_MET = new double[3001];
			Jco2_MET = new double[3001];
			Jo2_MET = new double[3001];
			Jn2_MET = new double[3001];
			Jso2_MET = new double[3001];

			Jo2_RZ = new double[3001];
			Jco_RZ = new double[3001];
			Jco2_RZ = new double[3001];
			Jso2_RZ = new double[3001];
			Jn2_RZ = new double[3001];

			aC = new double[3001];
			aMn = new double[3001];
			aSi = new double[3001];
			aP = new double[3001];

			aFe = new double[3001];

			nFe = new double[3001];
			nC = new double[3001];
			nMn = new double[3001];
			nP = new double[3001];
			nSi = new double[3001];
			nS = new double[3001];

			Vizv = new double[21];
			Vizk = new double[21];
			Vdol = new double[21];
			Vvldol = new double[21];
			Vimf = new double[21];
			Vpes = new double[21];
			Vruda = new double[21];
			Vokat = new double[21];
			Vokal = new double[21];
			Vagl = new double[21];
			Vshp = new double[21];

			GcaoShl = new double[3001];
			Gsio2Shl = new double[3001];
			GTOTALFeOshl = new double[3001];
			GmgoShl = new double[3001];
			GmnoShl = new double[3001];
			Gp2o5Shl = new double[3001];

			VcRZ_o2 = new double[5001];
			VcRZ_co2 = new double[5001];
			VfeRZ_o2 = new double[5001];
			VfeRZ_co2 = new double[5001];
			VmnRZ_o2 = new double[5001];
			VmnRZ_co2 = new double[5001];
			VsiRZ_o2 = new double[5001];
			VsiRZ_co2 = new double[5001];
			VpRZ_o2 = new double[5001];
			VpRZ_co2 = new double[5001];
			VsRZ_o2 = new double[5001];
			VsRZ_co2 = new double[5001];

			VcRZ = new double[5001];
			Vlom = new double[5001];

			VcShl = new double[5001];
			VmnShl = new double[5001];
			VsiShl = new double[5001];
			VpShl = new double[5001];
			VsShl = new double[5001];
			VcMnO = new double[5001];

			VfeRZ = new double[10001];
			VmnRZ = new double[10001];
			VpRZ = new double[10001];
			VsiRZ = new double[10001];
			VsRZ = new double[10001];

			VfeoSUMM = new double[5001];
			VfeCO2 = new double[5001];
			VC = new double[5001];
			VSi = new double[5001];
			VMn = new double[5001];
			VP = new double[5001];
			VS = new double[5001];
			Vchug = new double[5001];

			KizbitokGaza = new double[3001];

			aFeOfact = new double[3001];
			aCaOfact = new double[3001];
			aSiO2fact = new double[3001];
			aMnOfact = new double[3001];
			aMgOfact = new double[3001];
			aP2O5fact = new double[3001];
			aAl2O3fact = new double[3001];
			aTiO2fact = new double[3001];
			aK2Ofact = new double[3001];

			Jco2str2 = new double[3001];
			Jcostr2 = new double[3001];
			Jn2str2 = new double[3001];
			Jo2str2 = new double[3001];
			SummJstr2 = new double[3001];

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

			SO2Gas = new double[5001];
			COgas = new double[5001];
			CO2gas = new double[5001];
			O2gas = new double[5001];
			N2gas = new double[5001];
			pCOgas = new double[5001];

			Jo2str1 = new double[3001];
			Jco_PODM = new double[3001];
			Jco2_PODM = new double[3001];
			Jn2_PODM = new double[3001];
			Jo2_PODM = new double[3001];
			Jso2_PODM = new double[3001];
			JcoX = new double[3001];

			Jso2_GAS = new double[3001];
			Jco_GAS = new double[3001];
			Jco2_GAS = new double[3001];
			Jn2_GAS = new double[3001];
			Jo2_GAS = new double[3001];
		}
	}
}