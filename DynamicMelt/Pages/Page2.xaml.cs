﻿using System.Windows.Input;
using DynamicMelt.ViewModel;

namespace DynamicMelt.Pages
{
	/// <summary>
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class Page2
	{
		public Page2()
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
				ViewModelLocator.Page2Model.ExecuteNext();
				NavigationService.Navigate(new Page3());
			}
		}
	}
}