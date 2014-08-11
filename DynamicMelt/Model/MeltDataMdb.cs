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
	}
}