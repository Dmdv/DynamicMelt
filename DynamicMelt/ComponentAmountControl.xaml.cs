using System.Windows;

namespace DynamicMelt
{
	/// <summary>
	/// Component, responsible for each component.
	/// </summary>
	public partial class ComponentAmountControl
	{
		public static readonly DependencyProperty ComponentNameProperty =
			DependencyProperty.Register(
				"ComponentName",
				typeof (string),
				typeof (ComponentAmountControl),
				new PropertyMetadata(
					default(string),
					OnPropertyChangedCallback));

		public static readonly DependencyProperty MassFullProperty =
			DependencyProperty.Register(
				"MassFull",
				typeof (double),
				typeof (ComponentAmountControl),
				new PropertyMetadata(default(double)));

		public static readonly DependencyProperty MassProperty =
			DependencyProperty.Register(
				"Mass",
				typeof (double),
				typeof (ComponentAmountControl),
				new PropertyMetadata(default(double)));

		public ComponentAmountControl()
		{
			InitializeComponent();
		}

		public double Mass
		{
			get { return (double) GetValue(MassProperty); }
			set { SetValue(MassProperty, value); }
		}

		public double MassFull
		{
			get { return (double) GetValue(MassFullProperty); }
			set { SetValue(MassFullProperty, value); }
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