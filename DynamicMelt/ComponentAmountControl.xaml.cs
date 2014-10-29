using System.Windows;
using System.Windows.Controls;

namespace DynamicMelt
{
	/// <summary>
	/// Component, responsible for each component.
	/// </summary>
	public partial class ComponentAmountControl : UserControl
	{
		public static readonly DependencyProperty ComponentNameProperty = DependencyProperty.Register(
			"ComponentName",
			typeof (string),
			typeof (ComponentAmountControl),
			new PropertyMetadata(default(string),
				OnPropertyChangedCallback));

		public ComponentAmountControl()
		{
			InitializeComponent();
		}

		public string ComponentName
		{
			get { return (string) GetValue(ComponentNameProperty); }
			set { SetValue(ComponentNameProperty, value); }
		}

		public string Header
		{
			get { return _groupBoxControl.Header.ToString(); }
			set { _groupBoxControl.Header = value ?? "GenericName"; }
		}

		private static void OnPropertyChangedCallback(
			DependencyObject o,
			DependencyPropertyChangedEventArgs args)
		{
			var control = (ComponentAmountControl) o;
			control.Header = args.NewValue.ToString();
		}
	}
}