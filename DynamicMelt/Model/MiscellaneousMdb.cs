using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class MiscellaneousMdb : MdbReader
	{
		public MiscellaneousMdb()
			: base(Settings.Default.MiscellaneousMdb)
		{
		}
	}
}