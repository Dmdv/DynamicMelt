using System;
using System.ComponentModel;
using Common.Annotations;
using DynamicMelt.Chemistry;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	// ReSharper disable InconsistentNaming
	// ReSharper disable UnusedMember.Local

	[UsedImplicitly]
	public class Page2ViewModel : ViewModelBase, IDataErrorInfo
	{
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
		}

		public double Aglomerat
		{
			get { return Tube.Агломерат.G; }
			private set
			{
				Tube.Агломерат.G = value;
				RaisePropertyChanged("Aglomerat");
			}
		}

		public double AglomeratNoise
		{
			get { return _aglomeratNoise; }
			set
			{
				_aglomeratNoise = value;
				RaisePropertyChanged("AglomeratNoise");
			}
		}

		public double ChugunEstimated
		{
			get { return Tube.Чугун.GEstimated; }
			private set
			{
				Tube.Чугун.GEstimated = value;
				RaisePropertyChanged("ChugunEstimated");
			}
		}

		public double ChugunFact
		{
			get { return Tube.Чугун.GChug[0]; }
			set
			{
				Tube.Чугун.GChug[0] = value;
				RaisePropertyChanged("ChugunFact");
			}
		}

		public double Dolomit
		{
			get { return Tube.Доломит.G / 1000; }
			private set
			{
				Tube.Доломит.G = value;
				RaisePropertyChanged("Dolomit");
			}
		}

		public double DolomitNoise
		{
			get { return _dolomitNoise; }
			set
			{
				_dolomitNoise = value;
				RaisePropertyChanged("DolomitNoise");
			}
		}

		public double Dutie
		{
			get { return Tube.Дутье.V; }
			private set
			{
				Tube.Дутье.V = value;
				RaisePropertyChanged("Dutie");
			}
		}

		public double Imf
		{
			get { return Tube.Имф.G; }
			private set
			{
				Tube.Имф.G = value;
				RaisePropertyChanged("Imf");
			}
		}

		public double ImfNoise
		{
			get { return _imfNoise; }
			set
			{
				_imfNoise = value;
				RaisePropertyChanged("ImfNoise");
			}
		}

		public double Izvest
		{
			get { return Tube.Известь.G / 1000; }
			private set
			{
				Tube.Известь.G = value;
				RaisePropertyChanged("Izvest");
			}
		}

		public double IzvestNoise
		{
			get { return _izvestNoise; }
			set
			{
				_izvestNoise = value;
				RaisePropertyChanged("IzvestNoise");
			}
		}

		public double Izvestnyak
		{
			get { return Tube.Известняк.G / 1000; }
			private set
			{
				Tube.Известняк.G = value;
				RaisePropertyChanged("Izvestnyak");
			}
		}

		public double IzvestnyakNoise
		{
			get { return _izvestnyakNoise; }
			set
			{
				_izvestnyakNoise = value;
				RaisePropertyChanged("IzvestnyakNoise");
			}
		}

		public double Koks
		{
			get { return Tube.Кокс.G; }
			private set
			{
				Tube.Кокс.G = value;
				RaisePropertyChanged("Koks");
			}
		}

		public double KoksNoise
		{
			get { return _koksNoise; }
			set
			{
				_koksNoise = value;
				RaisePropertyChanged("KoksNoise");
			}
		}

		public double LomEstimated
		{
			get { return Tube.Лом.GEstimated; }
			private set
			{
				Tube.Лом.GEstimated = value;
				RaisePropertyChanged("LomEstimated");
			}
		}

		public double LomFact
		{
			get { return Tube.Лом.G; }
			set
			{
				Tube.Лом.G = value;
				RaisePropertyChanged("LomFact");
			}
		}

		public double Okalina
		{
			get { return Tube.Окалина.G; }
			private set
			{
				Tube.Окалина.G = value;
				RaisePropertyChanged("Okalina");
			}
		}

		public double OkalinaNoise
		{
			get { return _okalinaNoise; }
			set
			{
				_okalinaNoise = value;
				RaisePropertyChanged("OkalinaNoise");
			}
		}

		public double Okatyshi
		{
			get { return Tube.Окатыши.G; }
			private set
			{
				Tube.Окатыши.G = value;
				RaisePropertyChanged("Okatyshi");
			}
		}

		public double OkatyshiNoise
		{
			get { return _okatyshiNoise; }
			set
			{
				_okatyshiNoise = value;
				RaisePropertyChanged("OkatyshiNoise");
			}
		}

		public double Pesok
		{
			get { return Tube.Песок.G; }
			private set
			{
				Tube.Песок.G = value;
				RaisePropertyChanged("Pesok");
			}
		}

		public double PesokNoise
		{
			get { return _pesokNoise; }
			set
			{
				_pesokNoise = value;
				RaisePropertyChanged("PesokNoise");
			}
		}

		public double PlavShpat
		{
			get { return Tube.Шпат.G; }
			private set
			{
				Tube.Шпат.G = value;
				RaisePropertyChanged("PlavShpat");
			}
		}

		public double PlavShpatNoise
		{
			get { return _plavShpatNoise; }
			set
			{
				_plavShpatNoise = value;
				RaisePropertyChanged("PlavShpatNoise");
			}
		}

		public double Ruda
		{
			get { return Tube.Руда.G; }
			private set
			{
				Tube.Руда.G = value;
				RaisePropertyChanged("Ruda");
			}
		}

		public double RudaNoise
		{
			get { return _rudaNoise; }
			set
			{
				_rudaNoise = value;
				RaisePropertyChanged("RudaNoise");
			}
		}

		public double DolomitVlaga
		{
			get { return Tube.ВлажныйДоломит.G / 1000; }
			private set
			{
				Tube.ВлажныйДоломит.G = value;
				RaisePropertyChanged("DolomitVlaga");
			}
		}

		public double DolomitVlagaNoise
		{
			get { return _dolomitVlagaNoise; }
			set
			{
				_dolomitVlagaNoise = value;
				RaisePropertyChanged("DolomitVlagaNoise");
			}
		}

		public double SteelCarbon
		{
			get { return Tube.Сталь.C; }
			private set
			{
				Tube.Сталь.C = value;
				RaisePropertyChanged("SteelCarbon");
			}
		}

		public double SteelPhosphor
		{
			get { return Tube.Сталь.P; }
			private set
			{
				Tube.Сталь.P = value;
				RaisePropertyChanged("SteelPhosphor");
				
			}
		}

		public double SteelTemperature
		{
			get { return Tube.Сталь.T - 273; }
			private set
			{
				Tube.Сталь.T = value + 273;
				RaisePropertyChanged("SteelTemperature");
			}
		}

		public double TСhugCool
		{
			get { return Tube.Чугун.TCool; }
			set
			{
				Tube.Чугун.TCool = value;
				RaisePropertyChanged("TСhugCool");
			}
		}

		private double _aglomeratNoise;
		private double _dolomitNoise;
		private double _imfNoise;
		private double _izvestNoise;
		private double _izvestnyakNoise;
		private double _koksNoise;
		private double _okalinaNoise;
		private double _okatyshiNoise;
		private double _pesokNoise;
		private double _plavShpatNoise;
		private double _rudaNoise;
		private double _dolomitVlagaNoise;

		public string this[string columnName]
		{
			get
			{
				if (columnName == "ChugunFact")
				{
					var sqrt = Math.Sqrt(Math.Pow((LomEstimated - LomFact) / LomEstimated, 2));

					if (sqrt < 10 / 100 || Math.Abs(LomFact) < 0.0)
					{
						
					}
				}

				if (columnName == "LomFact")
				{
					
				}

				return "Error prop";
			}
		}

		public string Error { get; private set; }
	}
}