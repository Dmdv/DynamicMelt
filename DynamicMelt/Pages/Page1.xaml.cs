using System.Windows;
using System.Windows.Input;
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
		}

		private void OnLoad(object sender, RoutedEventArgs e)
		{
			_model.MeltNumber_Detect();
			_model.Iznos_Refresh();
		}

		private readonly Page1ViewModel _model = new Page1ViewModel();
	}
}