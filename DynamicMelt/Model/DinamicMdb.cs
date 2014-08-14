using DynamicMelt.Properties;
using DynamicMelt.Providers;

namespace DynamicMelt.Model
{
	public class DinamicMdb : MdbReader
	{
		public DinamicMdb()
			: base(Settings.Default.DinamicMdb)
		{
		}
	}
}