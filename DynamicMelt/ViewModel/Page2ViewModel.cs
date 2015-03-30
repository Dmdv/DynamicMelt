using System;
using System.ComponentModel;
using Common.Annotations;
using DynamicMelt.Chemistry;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DynamicMelt.ViewModel
{
	// ReSharper disable InconsistentNaming
	// ReSharper disable UnusedMember.Local

	[UsedImplicitly]
	public class Page2ViewModel : ViewModelBase, IDataErrorInfo
	{
		private readonly Random _random = new Random();
		private double _aglomeratNoise;
		private double _dolomitNoise;
		private double _dolomitVlagaNoise;
		private double _imfNoise;
		private double _izvestNoise;
		private double _izvestnyakNoise;
		private double _koksNoise;
		private double _okalinaNoise;
		private double _okatyshiNoise;
		private double _pesokNoise;
		private double _plavShpatNoise;
		private double _rudaNoise;

		public Page2ViewModel()
		{
			if (IsInDesignMode)
			{
				ChugunEstimated = 0.0;
				ChugunFact = 0.0;
				LomEstimated = 0.0;
				LomFact = 0.0;
			}

			TСhugCool = 150;

			MakeNoiseChugunCommand = new RelayCommand(MakeNoiseChugun, () => true);

			MakeNoiseLomCommand = new RelayCommand(MakeNoiseLom, () => true);
		}

		public RelayCommand MakeNoiseChugunCommand { get; set; }

		public RelayCommand MakeNoiseLomCommand { get; set; }

		public double Aglomerat
		{
			get { return Tube.Агломерат.G; }
			private set
			{
				Tube.Агломерат.G = value;
				RaisePropertyChanged();
			}
		}

		public double AglomeratNoise
		{
			get { return _aglomeratNoise; }
			set
			{
				_aglomeratNoise = value;
				RaisePropertyChanged();
			}
		}

		public double ChugunEstimated
		{
			get { return Tube.Чугун.GEstimated; }
			set
			{
				Tube.Чугун.GEstimated = value;
				RaisePropertyChanged();
			}
		}

		public double ChugunFact
		{
			get { return Tube.Чугун.GChug[0]; }
			set
			{
				Tube.Чугун.GChug[0] = value;
				RaisePropertyChanged();
			}
		}

		public double Dolomit
		{
			get { return Tube.Доломит.G / 1000; }
			private set
			{
				Tube.Доломит.G = value;
				RaisePropertyChanged();
			}
		}

		public double DolomitNoise
		{
			get { return _dolomitNoise; }
			set
			{
				_dolomitNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Dutie
		{
			get { return Tube.Дутье.V; }
			private set
			{
				Tube.Дутье.V = value;
				RaisePropertyChanged();
			}
		}

		public double Imf
		{
			get { return Tube.Имф.G; }
			private set
			{
				Tube.Имф.G = value;
				RaisePropertyChanged();
			}
		}

		public double ImfNoise
		{
			get { return _imfNoise; }
			set
			{
				_imfNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Izvest
		{
			get { return Tube.Известь.G / 1000.0; }
			private set
			{
				Tube.Известь.G = value;
				RaisePropertyChanged();
			}
		}

		public double IzvestNoise
		{
			get { return _izvestNoise; }
			set
			{
				_izvestNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Izvestnyak
		{
			get { return Tube.Известняк.G / 1000.0; }
			private set
			{
				Tube.Известняк.G = value;
				RaisePropertyChanged();
			}
		}

		public double IzvestnyakNoise
		{
			get { return _izvestnyakNoise; }
			set
			{
				_izvestnyakNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Koks
		{
			get { return Tube.Кокс.G; }
			private set
			{
				Tube.Кокс.G = value;
				RaisePropertyChanged();
			}
		}

		public double KoksNoise
		{
			get { return _koksNoise; }
			set
			{
				_koksNoise = value;
				RaisePropertyChanged();
			}
		}

		public double LomEstimated
		{
			get { return Tube.Лом.GEstimated; }
			private set
			{
				Tube.Лом.GEstimated = value;
				RaisePropertyChanged();
			}
		}

		public double LomFact
		{
			get { return Tube.Лом.G; }
			set
			{
				Tube.Лом.G = value;
				RaisePropertyChanged();
			}
		}

		public double Okalina
		{
			get { return Tube.Окалина.G; }
			private set
			{
				Tube.Окалина.G = value;
				RaisePropertyChanged();
			}
		}

		public double OkalinaNoise
		{
			get { return _okalinaNoise; }
			set
			{
				_okalinaNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Okatyshi
		{
			get { return Tube.Окатыши.G; }
			private set
			{
				Tube.Окатыши.G = value;
				RaisePropertyChanged();
			}
		}

		public double OkatyshiNoise
		{
			get { return _okatyshiNoise; }
			set
			{
				_okatyshiNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Pesok
		{
			get { return Tube.Песок.G; }
			private set
			{
				Tube.Песок.G = value;
				RaisePropertyChanged();
			}
		}

		public double PesokNoise
		{
			get { return _pesokNoise; }
			set
			{
				_pesokNoise = value;
				RaisePropertyChanged();
			}
		}

		public double PlavShpat
		{
			get { return Tube.Шпат.G; }
			private set
			{
				Tube.Шпат.G = value;
				RaisePropertyChanged();
			}
		}

		public double PlavShpatNoise
		{
			get { return _plavShpatNoise; }
			set
			{
				_plavShpatNoise = value;
				RaisePropertyChanged();
			}
		}

		public double Ruda
		{
			get { return Tube.Руда.G; }
			private set
			{
				Tube.Руда.G = value;
				RaisePropertyChanged();
			}
		}

		public double RudaNoise
		{
			get { return _rudaNoise; }
			set
			{
				_rudaNoise = value;
				RaisePropertyChanged();
			}
		}

		public double DolomitVlaga
		{
			get { return Tube.ВлажныйДоломит.G / 1000.0; }
			private set
			{
				Tube.ВлажныйДоломит.G = value;
				RaisePropertyChanged();
			}
		}

		public double DolomitVlagaNoise
		{
			get { return _dolomitVlagaNoise; }
			set
			{
				_dolomitVlagaNoise = value;
				RaisePropertyChanged();
			}
		}

		public double SteelCarbon
		{
			get { return Tube.Сталь.C; }
			private set
			{
				Tube.Сталь.C = value;
				RaisePropertyChanged();
			}
		}

		public double SteelPhosphor
		{
			get { return Tube.Сталь.P; }
			private set
			{
				Tube.Сталь.P = value;
				RaisePropertyChanged();
			}
		}

		public double SteelTemperature
		{
			get { return Tube.Сталь.T - 273; }
			private set
			{
				Tube.Сталь.T = value + 273;
				RaisePropertyChanged();
			}
		}

		public double TСhugCool
		{
			get { return Tube.Чугун.TCool; }
			set
			{
				Tube.Чугун.TCool = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// Provides the functionality to offer custom error information that a user interface can bind to.
		/// Gets the error message for the property with the given name.
		/// The error message for the property. The default is an empty string ("").
		/// </summary>
		/// <param name="columnName">The name of the property whose error message to get.</param>
		public string this[string columnName]
		{
			get
			{
				if (columnName == "ChugunFact")
				{
					var division = (ChugunEstimated - ChugunFact) / ChugunEstimated;
					var pow = Math.Pow(division, 2);
					var sqrt = Math.Sqrt(pow);

					if (sqrt < 5.0 / 100.0 || (int) ChugunFact == 0)
					{
						if ((int) ChugunFact == 0)
						{
							ChugunFact = ChugunEstimated;
						}

						return null;
					}

					return "Вы ввели недопустимое значение массы чугуна, " +
					       "слишком велико отклонение от рассчитанной величины." +
					       "Расчёт не может быть продолжен.";
				}

				if (columnName == "LomFact")
				{
					var division = (LomEstimated - LomFact) / LomEstimated;
					var pow = Math.Pow(division, 2);
					var sqrt = Math.Sqrt(pow);

					if (sqrt < 10.0 / 100.0 || (int) LomFact == 0)
					{
						if ((int) LomFact == 0)
						{
							LomFact = LomEstimated;
						}

						return null;
					}

					return "Вы ввели недопустимое значение массы лома, " +
					       "слишком велико отклонение от рассчитанной величины." +
					       "Расчёт не может быть продолжен.";
				}

				return null;
			}
		}

		public string Error { get; private set; }

		public void ExecuteNext()
		{
			Tube.Чугун.GChug[0] = ChugunFact * 1000;
			Tube.Лом.G = LomFact * 1000;
		}

		private void MakeNoiseLom()
		{
			var rasprIdx = Vars.Raspredelenie[_random.Next(1, 2000)] / 10000;
			LomFact = Tube.Лом.GEstimated + Tube.Лом.GEstimated * 0.015 * rasprIdx;
		}

		private void MakeNoiseChugun()
		{
			var rasprIdx = Vars.Raspredelenie[_random.Next(1, 2000)] / 10000.0;
			ChugunFact = Tube.Чугун.GEstimated + Tube.Чугун.GEstimated * 0.015 * rasprIdx;
		}
	}
}