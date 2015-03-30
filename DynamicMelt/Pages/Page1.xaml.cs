using System;
using System.Windows;
using System.Windows.Input;
using DynamicMelt.ViewModel;

namespace DynamicMelt.Pages
{
	// TODO: Здесь напрямую используется ViewModel. Это неправильно.
	// Необходимо перенести все отсюда в модель.

	public partial class Page1
	{
		private readonly Page1ViewModel _model;

		public Page1()
		{
			_model = ViewModelLocator.Page1Model;

			InitializeComponent();

			Loaded += (o, args) => _model.Load(_sliderControl.Value, Intervals);
		}

		private int Intervals
		{
			get
			{
				var intervals = (_sliderControl.Maximum - _sliderControl.Minimum) / _sliderControl.TickFrequency;
				return Convert.ToInt32(intervals);
			}
		}

		private void NextCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void NextExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (NavigationService != null)
			{
				_model.ExecuteNext();
				NavigationService.Navigate(new Page2());
			}
		}

		private void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			_model.Iznos_Refresh(e.NewValue, Intervals);
		}
	}
}