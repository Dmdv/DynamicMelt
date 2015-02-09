using System.Data;
using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class ParamsMdb : MdbProvider
	{
		public ParamsMdb()
			: base(Settings.Default.ParamsMdb)
		{
		}

		public DataTable CountData
		{
			get { return Reader.FetchTable("CountData"); }
		}

		public DataTable Fakel
		{
			get { return Reader.FetchTable("Fakel"); }
		}

		public DataTable FutData
		{
			get { return Reader.FetchTable("FutData"); }
		}

		public DataTable Regressions
		{
			get { return Reader.FetchTable("Regressions"); }
		}
	}
}