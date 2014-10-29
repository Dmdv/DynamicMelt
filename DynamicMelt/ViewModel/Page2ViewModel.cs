using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	public class Page2ViewModel : ViewModelBase
	{
		public Page2ViewModel()
		{
			if (IsInDesignMode)
			{
				ChugunEstimated = "0.0";
				ChugunFact = "0.0";
				LomEstimated = "0.0";
				LomFact = "0.0";
			}
		}

		public string ChugunEstimated
		{
			get { return _chugunEstimated; }
			set
			{
				_chugunEstimated = value;
				RaisePropertyChanged("ChugunEstimated");
			}
		}

		public string ChugunFact
		{
			get { return _chugunFact; }
			set
			{
				_chugunFact = value;
				RaisePropertyChanged("ChugunFact");
			}
		}

		public string LomEstimated
		{
			get { return _lomEstimated; }
			set
			{
				_lomEstimated = value;
				RaisePropertyChanged("LomEstimated");
			}
		}

		public string LomFact
		{
			get { return _lomFact; }
			set
			{
				_lomFact = value;
				RaisePropertyChanged("LomFact");
			}
		}

		public string Oxygen
		{
			get { return _oxygen; }
			set
			{
				_oxygen = value;
				RaisePropertyChanged("Oxygen");
			}
		}

		public string PParam
		{
			get { return _pParam; }
			set
			{
				RaisePropertyChanged("PParam");
				_pParam = value;
			}
		}

		public string TempDelta
		{
			get { return _tempDelta; }
			set
			{
				_tempDelta = value;
				RaisePropertyChanged("TempDelta");
			}
		}

		public string Temperature
		{
			get { return _temperature; }
			set
			{
				_temperature = value;
				RaisePropertyChanged("Temperature");
			}
		}

		public string TemperatureSet
		{
			get { return _temperatureSet; }
			set
			{
				_temperatureSet = value;
				RaisePropertyChanged("TemperatureSet");
			}
		}

		private string _chugunEstimated;
		private string _chugunFact;
		private string _lomEstimated;
		private string _lomFact;
		private string _oxygen;
		private string _pParam;
		private string _tempDelta;
		private string _temperature;
		private string _temperatureSet;
	}
}