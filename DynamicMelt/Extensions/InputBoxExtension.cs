using System.Globalization;
using DynamicMelt.Controls;

namespace DynamicMelt.Extensions
{
	public class InputWindow
	{
		public InputWindow(string title)
		{
			_dialog = new InputBox
			{
				Caption = string.Format(title),
				ShowInTaskbar = false,
				Topmost = true
			};
		}

		public static double ReadDouble(string title)
		{
			var inputWindow = new InputWindow(title);
			var value = inputWindow.ReadValue();

			double readDouble;
			var result = double.TryParse(value, NumberStyles.Number, CultureInfo.InstalledUICulture, out readDouble);
			return result ? readDouble : 0.0;
		}

		public static string ReadValue(string title)
		{
			var inputWindow = new InputWindow(title);
			return inputWindow.ReadValue();
		}

		public string ReadValue()
		{
			var showDialog = _dialog.ShowDialog();
			return showDialog.HasValue && showDialog.Value ? _dialog.ResponseText : string.Empty;
		}

		private readonly InputBox _dialog;
	}
}