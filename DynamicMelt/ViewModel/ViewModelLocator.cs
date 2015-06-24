using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace DynamicMelt.ViewModel
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<Page1ViewModel>();
			SimpleIoc.Default.Register<Page2ViewModel>();
			SimpleIoc.Default.Register<Page3ViewModel>();
		}

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			if (ViewModelBase.IsInDesignModeStatic)
			{
				// Create design time view services and models
				// SimpleIoc.Default.Register<IDataService, DesignDataService>();
			}
		}

		public static MainViewModel Main
		{
			get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
		}

		public static Page1ViewModel Page1Model
		{
			get { return ServiceLocator.Current.GetInstance<Page1ViewModel>(); }
		}

		public static Page2ViewModel Page2Model
		{
			get { return ServiceLocator.Current.GetInstance<Page2ViewModel>(); }
		}

		public static Page3ViewModel Page3Model
		{
			get { return ServiceLocator.Current.GetInstance<Page3ViewModel>(); }
		}

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}
	}
}