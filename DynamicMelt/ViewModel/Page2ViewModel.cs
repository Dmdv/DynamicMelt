using Common.Annotations;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	[UsedImplicitly]
	public class Page2ViewModel : ViewModelBase
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
		}

		public double Aglomerat
		{
			get { return _aglomerat; }
			set
			{
				_aglomerat = value;
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
			get { return _chugunEstimated; }
			set
			{
				_chugunEstimated = value;
				RaisePropertyChanged("ChugunEstimated");
			}
		}

		public double ChugunFact
		{
			get { return _chugunFact; }
			set
			{
				_chugunFact = value;
				RaisePropertyChanged("ChugunFact");
			}
		}

		public double Dolomit
		{
			get { return _dolomit; }
			set
			{
				_dolomit = value;
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

		public double Imf
		{
			get { return _imf; }
			set
			{
				_imf = value;
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
			get { return _izvest; }
			set
			{
				_izvest = value;
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
			get { return _izvestnyak; }
			set
			{
				_izvestnyak = value;
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
			get { return _koks; }
			set
			{
				_koks = value;
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
			get { return _lomEstimated; }
			set
			{
				_lomEstimated = value;
				RaisePropertyChanged("LomEstimated");
			}
		}

		public double LomFact
		{
			get { return _lomFact; }
			set
			{
				_lomFact = value;
				RaisePropertyChanged("LomFact");
			}
		}

		public double Okalina
		{
			get { return _okalina; }
			set
			{
				_okalina = value;
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
			get { return _okatyshi; }
			set
			{
				_okatyshi = value;
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

		public double Oxygen
		{
			get { return _oxygen; }
			set
			{
				_oxygen = value;
				RaisePropertyChanged("Oxygen");
			}
		}

		public double PParam
		{
			get { return _pParam; }
			set
			{
				RaisePropertyChanged("PParam");
				_pParam = value;
			}
		}

		public double Pesok
		{
			get { return _pesok; }
			set
			{
				_pesok = value;
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
			get { return _plavShpat; }
			set
			{
				_plavShpat = value;
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
			get { return _ruda; }
			set
			{
				_ruda = value;
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

		public double SrDolomit
		{
			get { return _srDolomit; }
			set
			{
				_srDolomit = value;
				RaisePropertyChanged("SrDolomit");
			}
		}

		public double SrDolomitNoise
		{
			get { return _srDolomitNoise; }
			set
			{
				_srDolomitNoise = value;
				RaisePropertyChanged("SrDolomitNoise");
			}
		}

		public double TempDelta
		{
			get { return _tempDelta; }
			set
			{
				_tempDelta = value;
				RaisePropertyChanged("TempDelta");
			}
		}

		public double Temperature
		{
			get { return _temperature; }
			set
			{
				_temperature = value;
				RaisePropertyChanged("Temperature");
			}
		}

		public double TemperatureSet
		{
			get { return _temperatureSet; }
			set
			{
				_temperatureSet = value;
				RaisePropertyChanged("TemperatureSet");
			}
		}

		private double _aglomerat;
		private double _aglomeratNoise;
		private double _chugunEstimated;
		private double _chugunFact;
		private double _dolomit;
		private double _dolomitNoise;
		private double _imf;
		private double _imfNoise;
		private double _izvest;
		private double _izvestNoise;
		private double _izvestnyak;
		private double _izvestnyakNoise;
		private double _koks;
		private double _koksNoise;
		private double _lomEstimated;
		private double _lomFact;
		private double _okalina;
		private double _okalinaNoise;
		private double _okatyshi;
		private double _okatyshiNoise;
		private double _oxygen;
		private double _pParam;
		private double _pesok;
		private double _pesokNoise;
		private double _plavShpat;
		private double _plavShpatNoise;
		private double _ruda;
		private double _rudaNoise;
		private double _srDolomit;
		private double _srDolomitNoise;
		private double _tempDelta;
		private double _temperature;
		private double _temperatureSet;
	}
}