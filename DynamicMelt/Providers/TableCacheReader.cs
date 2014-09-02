using System;
using System.Collections.Generic;
using System.Data;
using Common.Contracts;
using DynamicMelt.Extensions;

namespace DynamicMelt.Providers
{
	public class TableCacheReader : TableReader
	{
		public TableCacheReader(string file)
			: base(file)
		{
		}

		public override DataTable FetchTable(string table)
		{
			Guard.CheckContainsText(table, "table");

			var datatable = TableCache.Get(new TableKey(table, SubKey));
			if (datatable == null)
			{
				datatable = base.FetchTable(table);
				TableCache.Put(new TableKey(table, SubKey), datatable);
			}
			return datatable;
		}

		public IEnumerable<string[]> SelectAllRows(string table)
		{
			Guard.CheckContainsText(table, "table");

			return FetchTableSafe(table).SelectAllRows();
		}

		public EnumerableRowCollection<T> SelectColumnRange<T>(string table, string column)
		{
			Guard.CheckContainsText(table, "table");
			Guard.CheckContainsText(column, "column");

			return FetchTableSafe(table).SelectColumnRange<T>(column);
		}

		public EnumerableRowCollection<T> SelectColumnRange<T>(string table, int columnIndex)
		{
			Guard.CheckContainsText(table, "table");

			return FetchTableSafe(table).SelectColumnRange<T>(columnIndex);
		}

		public Dictionary<string, string> SelectRowDictionary(string table, int index)
		{
			Guard.CheckContainsText(table, "table");

			return FetchTableSafe(table).SelectRowStringDictionary(index);
		}

		public string[] SelectRowRange(string table, int index)
		{
			Guard.CheckContainsText(table, "table");

			return FetchTableSafe(table).SelectRowRange(index);
		}

		private DataTable FetchTableSafe(string table)
		{
			Guard.CheckContainsText(table, "table");

			var dataTable = FetchTable(table);
			if (dataTable == null)
			{
				throw new Exception(string.Format("Table '{0}' was  not found", table));
			}
			return dataTable;
		}
	}
}