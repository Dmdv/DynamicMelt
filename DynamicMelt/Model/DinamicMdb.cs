using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class DinamicMdb : MdbProvider
	{
		public DinamicMdb()
			: base(Settings.Default.DinamicMdb)
		{
		}
	}
}