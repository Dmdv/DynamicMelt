using System;
using System.Data;
using System.Linq;
using DynamicMelt.Extensions;
using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class MeltDataMdb : MdbReader
	{
		public MeltDataMdb()
			: base(Settings.Default.MeltDataMdb)
		{
		}

		public static int MeltNumberColumn
		{
			get { return 1; }
		}

		public DataTable AdaptationData
		{
			get { return Reader.FetchTable("AdaptationDATA"); }
		}

		public DataTable StraightCount
		{
			get { return Reader.FetchTable("StraightCount"); }
		}

		public string[] FindMeltRange(int meltNumber)
		{
			var columnRange = StraightCount.SelectColumnRange<int>(MeltNumberColumn);
			var strings = columnRange.ToArray();

			var index = Array.FindIndex(strings, value => value == meltNumber);
			return index == -1 ? null : StraightCount.SelectRowRange(index);
		}

		public bool MeltNumberExists(int meltNumber)
		{
			return
				StraightCount
					.SelectColumnRange<int>(MeltNumberColumn)
					.Contains(meltNumber);
		}
	}
}