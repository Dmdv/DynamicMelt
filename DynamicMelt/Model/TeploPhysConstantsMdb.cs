using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class TeploPhysConstantsMdb : MdbProvider
	{
		public TeploPhysConstantsMdb()
			: base(Settings.Default.TeploPhisConstsMdb)
		{
		}
	}
}