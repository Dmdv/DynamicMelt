using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class MapsMdb : MdbReader
	{
		public MapsMdb()
			: base(Settings.Default.MapsMdb)
		{
		}
	}
}