using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class LooseMdb : MdbReader
	{
		public LooseMdb()
			: base(Settings.Default.LooseMdb)
		{
		}
	}
}