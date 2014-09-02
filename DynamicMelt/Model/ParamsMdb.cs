using System.Data;
using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class ParamsMdb : MdbReader
	{
		public ParamsMdb()
			: base(Settings.Default.ParamsMdb)
		{
		}

		public DataTable CountData
		{
			get { return Reader.FetchTable("CountData"); }
		}
	}
}