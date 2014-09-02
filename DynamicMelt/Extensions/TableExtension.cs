using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Contracts;

namespace DynamicMelt.Extensions
{
	public static class TableExtension
	{
		public static int RowCount(this DataTable table)
		{
			Guard.CheckNotNull(table, "table");

			return table.Rows.Count;
		}

		public static IEnumerable<string[]> SelectAllRows(this DataTable table)
		{
			Guard.CheckNotNull(table, "table");

			return
				table.Rows
					.Cast<DataRow>()
					.Select(row => row.ItemArray.Select(item => item.ToString()).ToArray())
					.ToList();
		}

		public static EnumerableRowCollection<T> SelectColumnRange<T>(this DataTable table, string column)
		{
			Guard.CheckNotNull(table, "table");
			Guard.CheckContainsText(column, "column");

			return table.AsEnumerable().Select(row => row.Field<T>(column));
		}

		public static EnumerableRowCollection<T> SelectColumnRange<T>(this DataTable table, int columnIndex)
		{
			Guard.CheckNotNull(table, "table");

			return table.AsEnumerable().Select(row => row.Field<T>(columnIndex));
		}


		public static string[] SelectRowRange(this DataTable table, int index)
		{
			Guard.CheckNotNull(table, "table");

			return table.Rows[index].ItemArray.Select(item => item.ToString()).ToArray();
		}

		public static double[] SelectRowNumbers(this DataTable table, int index)
		{
			return table.SelectRowRange(index).Select(x => x.ToDouble()).ToArray();
		}

		public static Dictionary<string, string> SelectRowStringDictionary(this DataTable table, int index)
		{
			Guard.CheckNotNull(table, "table");

			var dataRow = table.Rows[index];

			return
				table.Columns.OfType<DataColumn>()
					.ToDictionary(column => column.ColumnName,
						column => dataRow[column.ColumnName].ToString());
		}

		public static Dictionary<int, string> SelectRowDictionary(this DataTable table, int index)
		{
			Guard.CheckNotNull(table, "table");

			var dataRow = table.Rows[index];

			return
				table.Columns.OfType<DataColumn>()
					.ToDictionary(column => column.Ordinal,
						column => dataRow[column.Ordinal].ToString());
		}
	}
}