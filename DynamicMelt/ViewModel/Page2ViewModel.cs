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

		private string _chugunEstimated;
		private string _chugunFact;
		private string _lomEstimated;
		private string _lomFact;
	}
}