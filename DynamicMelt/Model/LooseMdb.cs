using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class LooseMdb : MdbProvider
	{
		public LooseMdb()
			: base(Settings.Default.LooseMdb)
		{
		}
	}
}