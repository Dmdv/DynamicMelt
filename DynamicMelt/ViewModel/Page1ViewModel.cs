using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Common.Contracts;
using Common.Extensions;
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
			_meltDataMdb = new MeltDataMdb();
		}

		public ImageSource ImageIznos
		{
			get { return _imageIznos; }
			set
			{
				_imageIznos = value;
				RaisePropertyChanged("ImageIznos");
			}
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

		public void ConvDiameter_Recalculate(double iznosValue)
		{
			ConverterSize.D = ConverterSize.DNew * (1 + 0.25 * iznosValue / 100.0);
		}

		public void Data_Params_Load()
		{
			Guard.CheckFalse(
				Params.SelectedPlant <= 0,
				"SelectedPlant should be greater than 0");

			var nums = _paramsMdb
				.CountData
				.SelectRowRange(Params.SelectedPlant - 1)
				.Select(x => x.ToDoubleOrZero())
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
			Продувка.Dkr = nums[31] / 1000.0;

			Vars.Fkr = Math.PI * Math.Pow(Продувка.Dkr, 2) / 4.0;

			Продувка.Dexit = nums[32] / 1000.0;
			Продувка.Fexit = Math.PI * Math.Pow(Продувка.Dexit, 2) / 4.0;
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
			Fakel.Load(Params.SelectedPlant);
		}

		public void FutChem_Load()
		{
			Tube.Футеровка.Load(Params.FutTypeSelected);
		}

		/// <summary>
		/// Refresh image.
		/// </summary>
		public void Iznos_Refresh(double newValue, int intervals)
		{
			var bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			bitmapImage.UriSource = new Uri(@"Images/image{0}.png".FormatString(newValue % intervals), UriKind.Relative);
			bitmapImage.EndInit();

			ImageIznos = bitmapImage;
		}

		/// <summary>
		/// Создание массива зашумления.
		/// </summary>
		public void LoadNornRasp()
		{
			new RaspredelenieMdb().NormRasp
				.SelectAllRows()
				.ForEach(row =>
				{
					var index = row[0].ToInt();
					var value = row[1].ToInt();

					Vars.Raspredelenie[index] = value;
				});
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
			return _meltDataMdb.MeltNumberExists(meltNumber);
		}

		public void NeededData_Load(int meltNumber)
		{
			var nums = _meltDataMdb.FindMeltRange(meltNumber);

			Tube.Футеровка.G = nums[45].ToDouble();

			Params.FutTypeSelected = nums[46].ToInt();
			Params.SelectedPlant = nums[47].ToInt();

			Tube.Дутье.O2 = nums[48].ToDouble();
			Tube.Дутье.Ar = nums[49].ToDouble();
			Tube.Дутье.N2 = nums[50].ToDouble();
		}

		public void OxyChargeStart()
		{
			MessageBox.Show(
				"Расчет oxycharge в данной версии приложения отсутствует.",
				"OxyCharge",
				MessageBoxButton.OK,
				MessageBoxImage.Information);
		}

		private readonly MeltDataMdb _meltDataMdb;
		private readonly ParamsMdb _paramsMdb;
		private ImageSource _imageIznos;
		private int _meltNumber;
	}
}