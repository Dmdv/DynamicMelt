using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class TeploPhysConstantsMdb : MdbReader
	{
		public TeploPhysConstantsMdb()
			: base(Settings.Default.TeploPhisConstsMdb)
		{
		}
	}
}