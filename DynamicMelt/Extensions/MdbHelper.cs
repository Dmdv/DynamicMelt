using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DynamicMelt.Providers;

namespace DynamicMelt.Extensions
{
	public static class MdbHelper
	{
		public static void FillBoxes(
			this MdbProvider provider,
			string tableName,
			int rowindex,
			IList<TextBox> boxes,
			int shift = 0)
		{
			var values = provider.Reader.SelectRowRange(tableName, rowindex);
			if (boxes.Count + shift > values.Length)
			{
				throw new Exception("shift");
			}
			for (var idx = 0; idx < boxes.Count; idx++)
			{
				boxes[idx].Text = values[idx + shift];
			}
		}

		public static void FillComboBox(this MdbProvider provider, string tablename, string columnname, ComboBox comboBox)
		{
			try
			{
				foreach (var name in provider.Reader.SelectColumnRange<string>(tablename, columnname))
				{
					comboBox.Items.Add(name);
				}

				comboBox.SelectedIndex = 0;
			}
			catch (Exception)
			{
				MessageBox.Show(string.Format("Ошибка при чтении из таблицы '{0}' и колонки '{1}'",
					tablename,
					columnname),
					"Ошибка чтения",
					MessageBoxButton.OK,
					MessageBoxImage.Error);
			}
		}
	}
}