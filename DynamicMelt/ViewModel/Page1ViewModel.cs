using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DynamicMelt.Chemistry;
using DynamicMelt.Extensions;
using DynamicMelt.Model;
using DynamicMelt.Shell;
using GalaSoft.MvvmLight;
using Net.Common.Contracts;
using Net.Common.Extensions;

namespace DynamicMelt.ViewModel
{
	// TODO: Sync operation should be parallel if an execution order in not important.
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
				Params.MeltNumber = value;
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

		public void ExecuteNext()
		{
			if (MeltNumber <= 0)
			{
				const string Message = "Плавка не может иметь порядковый номер: '{0}'.";

				MessageBox.Show(
					Message.FormatString(MeltNumber),
					"Ошибка в номере плавки");

				return;
			}

			if (!MeltNumber_Exists(MeltNumber))
			{
				const string Message = "Плавки с номером '{0}' в базе данных не существует. \r\n" +
				                       "Скорее всего, для неё не производился расчёт шихты или результаты не были сохранены. \r\n" +
				                       "Запустить систему расчёта шихты OxyCharge?";

				var result = MessageBox.Show(
					Message.FormatString(MeltNumber),
					"Внимание!",
					MessageBoxButton.YesNo,
					MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					Run.OxyCharge();
				}

				MeltNumber_Detect();
			}

			NeededData_Load(MeltNumber);

			if (Params.SelectedPlant == 0)
			{
				const string Msg = "Для плавки, номер которой Вы ввели, был произведен расчет шихты в ручном режиме.\r\n" +
				                   "Повторите расчет шихты для этой плавки в автоматическом режиме.\r\n" +
				                   "Запустить систему расчета шихты OxyCharge?";

				if (MessageBox.Show(Msg, "Продолжение расчета невозможно") == MessageBoxResult.Yes)
				{
					OxyChargeStart();
				}
				return;
			}

			Data_Params_Load();
			FutChem_Load();
			ConvDiameter_Recalculate(_iznos);
			Fakel_Load();
			LoadNornRasp();
			LoadData();
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
			_iznos = newValue;
		}

		public void Load(double newValue, int intervals)
		{
			MeltNumber_Detect();
			Iznos_Refresh(newValue, intervals);
		}

		public void LoadData()
		{
			DataLoad.Run();

			var range = _meltDataMdb
				.FindMeltRange(MeltNumber)
				.Select(x => x.ToDouble())
				.ToArray();

			Tube.Чугун.C = range[2];
			Tube.Чугун.Si = range[3];
			Tube.Чугун.Mn = range[4];
			Tube.Чугун.P = range[5];
			Tube.Чугун.S = range[6];

			Tube.Лом.C = range[7];
			Tube.Лом.Si = range[8];
			Tube.Лом.Mn = range[9];
			Tube.Лом.P = range[10];
			Tube.Лом.S = range[11];

			Tube.Чугун.GEstimated = range[12];
			Tube.Лом.GEstimated = range[13];

			Tube.ОставленныйШлак.G = range[14] * 1000;
			Tube.МиксерныйШлак.G = range[15] * 1000;
			Tube.Шлак.GEnd = range[16] * 1000;

			Tube.Сталь.GYield = range[17] * 1000;
			Tube.Сталь.C = range[18];
			Tube.Сталь.Si = range[19];
			Tube.Сталь.Mn = range[20];
			Tube.Сталь.P = range[21];
			Tube.Сталь.S = range[22];

			Tube.Шлак.FeOEnd = range[23];
			Tube.Шлак.MnOEnd = range[24];
			Tube.Шлак.P2O5End = range[25];
			Tube.Шлак.BEnd = range[26];

			Tube.Известь.G = range[27] * 1000;
			Tube.Известняк.G = range[28] * 1000;

			Tube.Доломит.G = range[29] * 1000;
			Tube.ВлажныйДоломит.G = range[30] * 1000;
			Tube.Имф.G = range[31] * 1000;
			Tube.Песок.G = range[32] * 1000;
			Tube.Кокс.G = range[33] * 1000;
			Tube.Окатыши.G = range[34] * 1000;
			Tube.Руда.G = range[35] * 1000;
			Tube.Окалина.G = range[36] * 1000;
			Tube.Агломерат.G = range[37] * 1000;
			Tube.Шпат.G = range[38] * 1000;

			Tube.Дутье.V = range[39];

			Params.AirTemp = Convert.ToInt32(range[40]) + 273;
			Tube.Чугун.T = range[41] + 273;
			Tube.Сталь.T = range[42] + 273;
			Tube.Дутье.VArBlow[0] = range[43];
			Tube.Лом.DolyaLegkovesa = range[51];

			Regress.Load();
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

		private static void OxyChargeStart()
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
		private double _iznos;
		private int _meltNumber;
	}
}