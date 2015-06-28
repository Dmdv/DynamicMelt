using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMelt.Chemistry;

namespace DynamicMelt.ViewModel
{
	public class Page4ViewModel
	{

		private void Vagner()
		{
			// Активности компонентов металла

			Calc.fC = Math.Pow(10,
			          ((0.0581 + 158 / Converter.Metall.T(i - 6)) * Converter.Metall.C(i - 6)
			           - 0.012 * Converter.Metall.Mn(i - 6)
			           + (0.008 + 162 / Converter.Metall.T(i - 6)) * Converter.Metall.Si(i - 6)
			           + 0.051 * Converter.Metall.P(i - 6)
			           + 0.046 * Converter.Metall.S(i - 6)
			           - 0.34 * Converter.Metall.O(i - 6)));

			Calc.aC(i) = Calc.fC * Converter.Metall.C(i - 6);

			Calc.fMn = Math.Pow(10, (
				-0.07 * Converter.Metall.C(i - 6)
				- 0.0035 * Converter.Metall.P(i - 6)
				- 0.048 * Converter.Metall.S(i - 6)
				- 0.083 * Converter.Metall.O(i - 6)));

			Calc.aMn(i) = Calc.fMn * Converter.Metall.Mn(i - 6);

			Calc.fSi = Math.Pow(10,
			           ((-0.023 + 380 / Converter.Metall.T(i - 6))
			            * Converter.Metall.C(i - 6)
			            + 0.002 * Converter.Metall.Mn(i - 6)
			            + (0.089 - 34.5 / Converter.Metall.T(i - 6)) * Converter.Metall.Si(i - 6)
			            + 0.11 * Converter.Metall.P(i - 6)
			            + 0.056 * Converter.Metall.S(i - 6)
			            - 0.23 * Converter.Metall.O(i - 6)));

			Calc.aSi(i) = Calc.fSi * Converter.Metall.Si(i - 6);

			Calc.fP = Math.Pow(10,
					  (0.13 * Converter.Metall.C(i - 6) 
					  + 0.12 * Converter.Metall.Si(i - 6) 
					  + 0.062 * Converter.Metall.P(i - 6) 
					  + 0.028 * Converter.Metall.S(i - 6) 
					  + 0.13 * Converter.Metall.O(i - 6)));

			Calc.aP(i) = Calc.fP * Converter.Metall.P(i - 6);

			// Железо

			Calc.Qfec = (5100 - 10 * Converter.Metall.T(i - 6)) / 4.1868;
			Calc.Qfesi = (-28500 - 6.09 * Converter.Metall.T(i - 6)) / 4.1868;
			Calc.Qfemn = -9.11 * Converter.Metall.T(i - 6) / 4.1868;
			Calc.Qfep = (-29200 - 4.6 * Converter.Metall.T(i - 6)) / 4.1868;

			Calc.SummNj = Calc.nFe(i - 6) + Calc.nC(i - 6) + Calc.nSi(i - 6) + Calc.nMn(i - 6) + Calc.nP(i - 6);

			Calc.dHfec = Calc.Qfec * Calc.nC(i - 6) * (Calc.nC(i - 6) + Calc.nSi(i - 6) + Calc.nMn(i - 6) + Calc.nP(i - 6) + Calc.nS(i - 6)) / Calc.SummNj ^ 2;
			Calc.dHfesi = Calc.Qfesi * Calc.nSi(i - 6) * (Calc.nC(i - 6) + Calc.nSi(i - 6) + Calc.nMn(i - 6) + Calc.nP(i - 6) + Calc.nS(i - 6)) / Calc.SummNj ^ 2;
			Calc.dHfemn = Calc.Qfemn * Calc.nMn(i - 6) * (Calc.nC(i - 6) + Calc.nSi(i - 6) + Calc.nMn(i - 6) + Calc.nP(i - 6) + Calc.nS(i - 6)) / Calc.SummNj ^ 2;
			Calc.dHfep = Calc.Qfep * Calc.nP(i - 6) * (Calc.nC(i - 6) + Calc.nSi(i - 6) + Calc.nMn(i - 6) + Calc.nP(i - 6) + Calc.nS(i - 6)) / Calc.SummNj ^ 2;
			Calc.dHFe = Calc.dHfec + Calc.dHfesi + Calc.dHfemn + Calc.dHfep;

			Calc.GammaFe = Math.Exp(1 / Calc.R / Converter.Metall.T(i - 6) * Calc.dHFe);
			Calc.AdaptK(33) = 1;
			Calc.aFe(i) = Calc.AdaptK(33) * Converter.Metall.Fe(i - 6) * Calc.GammaFe;

		}
	}
}
