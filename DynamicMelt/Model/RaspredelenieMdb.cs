using System.Data;
using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class RaspredelenieMdb : MdbProvider
	{
		public RaspredelenieMdb()
			: base(Settings.Default.RaspredelenieMdb)
		{
		}

		public DataTable NormRasp
		{
			get { return Reader.FetchTable("normrasp"); }
		}
	}
}