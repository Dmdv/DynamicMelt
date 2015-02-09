using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class MapsMdb : MdbProvider
	{
		public MapsMdb()
			: base(Settings.Default.MapsMdb)
		{
		}
	}
}