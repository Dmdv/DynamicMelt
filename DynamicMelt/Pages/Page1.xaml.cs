using System.Windows;
using System.Windows.Input;
using Common.Extensions;
using DynamicMelt.Chemistry;
using DynamicMelt.Shell;
using DynamicMelt.ViewModel;

namespace DynamicMelt.Pages
{
	public partial class Page1
	{
		public Page1()
		{
			InitializeComponent();

			Loaded += OnLoad;
		}

		private void NextCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void NextExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (_model.MeltNumber <= 0)
			{
				const string Message = "Плавка не может иметь порядковый номер: '{0}'.";

				MessageBox.Show(
					Message.FormatString(_model.MeltNumber),
					"Ошибка в номере плавки");

				return;
			}

			if (!_model.MeltNumber_Exists(_model.MeltNumber))
			{
				const string Message = "Плавки с номером '{0}' в базе данных не существует. \r\n" +
				                       "Скорее всего, для неё не производился расчёт шихты или результаты не были сохранены. \r\n" +
				                       "Запустить систему расчёта шихты OxyCharge?";

				var result = MessageBox.Show(
					Message.FormatString(_model.MeltNumber),
					"Внимание!",
					MessageBoxButton.YesNo,
					MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					Run.OxyCharge();
				}

				_model.MeltNumber_Detect();
			}

			_model.NeededData_Load();

			if (Params.SelectedPlant == 0)
			{
				const string Msg = "Для плавки, номер которой Вы ввели, был произведен расчет шихты в ручном режиме.\r\n" +
				                   "Повторите расчет шихты для этой плавки в автоматическом режиме.\r\n" +
				                   "Запустить систему расчета шихты OxyCharge?";

				if (MessageBox.Show(Msg, "Продолжение расчета невозможно") == MessageBoxResult.Yes)
				{
				}
				return;
			}

			_model.Data_Params_Load();
			_model.FutChem_Load();
			_model.ConvDiameter_Recalculate();
			_model.Fakel_Load();
			_model.LoadNornRasp();

			DataLoad1.Run();

			//_model.
		}

		private void OnLoad(object sender, RoutedEventArgs e)
		{
			_model.MeltNumber_Detect();
			_model.Iznos_Refresh();
		}

		private readonly Page1ViewModel _model = new Page1ViewModel();
	}
}