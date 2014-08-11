using System;
using System.Windows;

namespace DynamicMelt
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		public App()
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
		}

		private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			MessageBox.Show(string.Format("Unhandled exception: '{0}'", e.ExceptionObject));
		}
	}
}