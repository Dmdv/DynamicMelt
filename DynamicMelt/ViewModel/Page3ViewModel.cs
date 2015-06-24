using DynamicMelt.Chemistry;
using GalaSoft.MvvmLight;

namespace DynamicMelt.ViewModel
{
	public class Page3ViewModel : ViewModelBase
	{
		public void ExecuteNext()
		{
			Converter.GizvPortion[0] = Tube.Известь.GOnHand;
			Converter.GizkPortion[0] = Tube.Известняк.GOnHand;
			Converter.GdolPortion[0] = Tube.Доломит.GOnHand;
			Converter.GvldolPortion[0] = Tube.ВлажныйДоломит.GOnHand;
			Converter.GimfPortion[0] = Tube.Имф.GOnHand;
			Converter.GkoksPortion[0] = Tube.Кокс.GOnHand;
			Converter.GrudaPortion[0] = Tube.Руда.GOnHand;
			Converter.GokalPortion[0] = Tube.Окалина.GOnHand;
			Converter.GokatPortion[0] = Tube.Окатыши.GOnHand;
			Converter.GaglPortion[0] = Tube.Агломерат.GOnHand;
			Converter.GshpPortion[0] = Tube.Шпат.GOnHand;
			Converter.GpesPortion[0] = Tube.Песок.GOnHand;
		}
	}
}