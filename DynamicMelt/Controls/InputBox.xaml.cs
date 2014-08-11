using System.Windows;

namespace DynamicMelt.Controls
{
	/// <summary>
	/// Interaction logic for InputBox.xaml
	/// </summary>
	public partial class InputBox
	{
		public InputBox()
		{
			InitializeComponent();
		}

		public string ResponseText
		{
			get { return ResponseTextBox.Text; }
			set { ResponseTextBox.Text = value; }
		}

		public string Caption
		{
			get { return CaptionText.Text; }
			set { CaptionText.Text = value; }
		}

		private void OnClick(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Close();
		}
	}
}