using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class MeltMdb : MdbReader
	{
		public MeltMdb()
			: base(Settings.Default.MelpMdb)
		{
		}
	}
}