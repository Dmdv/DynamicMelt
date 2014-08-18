using System.Collections.Generic;
using System.Linq;

namespace DynamicMelt.Providers
{
	public abstract class MdbReader
	{
		public string Path { get; private set; }

		public TableCacheReader Reader
		{
			get { return _cacheReader; }
		}

		public IReadOnlyList<string> Tables { get; set; }

		public int RowCount(string table)
		{
			return Reader.FetchTable(table).Rows.Count;
		}

		protected MdbReader(string path)
		{
			_cacheReader = new TableCacheReader(path);
			Path = _cacheReader.MdbFile;
			Tables = new TablesSchema(Path).GetTableNames().ToList();
		}

		private readonly TableCacheReader _cacheReader;
	}
}