using System.Linq;
using DynamicMelt.Model;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	public class Page1ViewModel : ViewModelBase
	{
		private const int ColumnNumberOfMelt = 1;
		private const string StraightCountTable = "straightcount";

		public int MeltNumber
		{
			get { return _meltNumber; }
			set
			{
				_meltNumber = value;
				RaisePropertyChanged("MeltNumber");
			}
		}

		/// <summary>
		/// Refresh image.
		/// </summary>
		public void Iznos_Refresh()
		{
		}

		public int MeltNumber_Detect()
		{
			MeltNumber = _meltDataMdb
				.Reader
				.SelectColumnRange<int>(StraightCountTable, ColumnNumberOfMelt)
				.Max();

			return MeltNumber;
		}

		public bool MeltNumber_Exists(int meltNumber)
		{
			return _meltDataMdb
				.Reader
				.SelectColumnRange<int>(StraightCountTable, meltNumber)
				.Contains(meltNumber);
		}

		private readonly MeltDataMdb _meltDataMdb = new MeltDataMdb();
		private int _meltNumber;
	}
}