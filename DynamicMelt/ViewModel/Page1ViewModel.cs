using System;
using System.Linq;
using DynamicMelt.Chemistry;
using DynamicMelt.Extensions;
using DynamicMelt.Model;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	public class Page1ViewModel : ViewModelBase
	{
		private const int ColumnNumberOfMelt = 1;
		private const string StraightCountTable = "straightcount";

		public Page1ViewModel()
		{
			_paramsMdb = new ParamsMdb();
		}

		public int MeltNumber
		{
			get { return _meltNumber; }
			set
			{
				_meltNumber = value;
				RaisePropertyChanged("MeltNumber");
			}
		}

		public void ConvDiameter_Recalculate()
		{
			throw new NotImplementedException();
		}

		public void Data_Params_Load()
		{
			var nums = _paramsMdb
				.CountData
				.SelectRowRange(Params.SelectedPlant)
				.Skip(2)
				.Select(x => x.ToDouble())
				.ToArray();

			Params.alfaFe = nums[3];
			Params.L = nums[5];
			Params.StAndShlLoss = nums[18];
			Params.TeplLoss = nums[22];

			ConverterSize.H1 = nums[24];
			ConverterSize.H2 = nums[25];
			ConverterSize.D1 = nums[26];
			ConverterSize.DNew = nums[27];

			Продувка.Nsop = nums[28];
			Продувка.SoploVerticalAngle = nums[29];
			Продувка.SoploOpenHalfAngle = nums[30];
			Продувка.Dkr = nums[31]/1000.0;

			Vars.Fkr = Math.PI*Math.Pow(Продувка.Dkr, 2)/4.0;

			Продувка.Dexit = nums[32]/1000.0;
			Продувка.Fexit = Math.PI * Math.Pow(Продувка.Dexit, 2)/4.0;
			Продувка.Hfur[0] = nums[33];
			Продувка.Qstandart = nums[34];

			Vars.pmZERO = nums[35];
			Vars.dTchugPlavl = nums[36];
			Vars.BlowFinishPoint = nums[37];

			ConverterSize.Hmain = nums[38];
			ConverterSize.HUpperConus = nums[39];
			ConverterSize.Dgorl = nums[40];
		}

		public void Fakel_Load()
		{
			throw new NotImplementedException();
		}

		public void FutChem_Load()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Refresh image.
		/// </summary>
		public void Iznos_Refresh()
		{
		}

		public void LoadNornRasp()
		{
			throw new NotImplementedException();
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

		public void NeededData_Load()
		{
			var nums = _meltDataMdb
				.FindMeltRange(MeltNumber)
				.Select(x => x.ToDouble())
				.ToArray();

			Tube.Футеровка.G = nums[45];
		}

		public void OxyChargeStart()
		{
		}

		private readonly MeltDataMdb _meltDataMdb = new MeltDataMdb();
		private readonly ParamsMdb _paramsMdb;
		private int _meltNumber;
	}
}