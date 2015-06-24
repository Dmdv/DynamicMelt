using System.Windows.Input;
using DynamicMelt.ViewModel;

namespace DynamicMelt.Pages
{
	public partial class Page3
	{
		public Page3()
		{
			InitializeComponent();
		}

		private void NextCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void NextExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (NavigationService != null)
			{
				ViewModelLocator.Page3Model.ExecuteNext();
				NavigationService.Navigate(new Page3());
			}
		}
	}
}