using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class MiscellaneousMdb : MdbProvider
	{
		public MiscellaneousMdb()
			: base(Settings.Default.MiscellaneousMdb)
		{
		}
	}
}