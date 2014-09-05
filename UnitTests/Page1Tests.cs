using System.Linq;
using DynamicMelt.Chemistry;
using DynamicMelt.Model;
using DynamicMelt.ViewModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	[DeploymentItem(@"Database", @"Database")]
	public class Page1Tests
	{
		[TestMethod]
		public void ConvDiameter_Recalculate()
		{
			ConverterSize.DNew = 1;

			_page1ViewModel.ConvDiameter_Recalculate(3.33);

			ConverterSize.D.Should().Be(1.008325);
		}

		[TestMethod]
		public void Data_Params_Load()
		{
			Params.SelectedPlant = 1;

			_page1ViewModel.Data_Params_Load();

			Params.alfaFe.Should().Be(0.021);
			Params.L.Should().Be(0.22);
			Params.StAndShlLoss.Should().Be(0.013);
			Params.TeplLoss.Should().Be(11700000);

			ConverterSize.H1.Should().Be(0.2);
			ConverterSize.H2.Should().Be(2.5);
			ConverterSize.D1.Should().Be(6.5);
			ConverterSize.DNew.Should().Be(7);

			Продувка.Nsop.Should().Be(6.0);
			Продувка.SoploVerticalAngle.Should().Be(14.0);
			Продувка.SoploOpenHalfAngle.Should().Be(4.11);
			Продувка.Dkr.Should().Be(38.0/1000);

			Продувка.Dexit.Should().Be(56.0/1000);

			Продувка.Hfur[0].Should().Be(4.0);
			Продувка.Qstandart.Should().Be(1270.0);

			Vars.pmZERO.Should().Be(0.8);
			Vars.dTchugPlavl.Should().Be(1.8);
			Vars.BlowFinishPoint.Should().Be(100.0);

			ConverterSize.Hmain.Should().Be(3.5);
			ConverterSize.HUpperConus.Should().Be(2.7);
			ConverterSize.Dgorl.Should().Be(4);
		}

		[TestMethod]
		public void Fakel_Load()
		{
			Params.SelectedPlant = 1;

			_page1ViewModel.Fakel_Load();

			Fakel.pmIntercept.Should().Be(1.505872);
			Fakel.pmQ.Should().Be(-0.001060718);
			Fakel.pmTog.Should().Be(0);
			Fakel.pmHfur.Should().Be(0.7997618);
			Fakel.pmN2.Should().Be(0);
			Fakel.pmCOkCO2.Should().Be(0);

			Fakel.rRZIntercept.Should().Be(0.3841469);
			Fakel.rRZQ.Should().Be(8.851127E-05);
			Fakel.rRZTog.Should().Be(0);
			Fakel.rRZHfur.Should().Be(0.3355117);
			Fakel.rRZN2.Should().Be(0);
			Fakel.rRZCOkCO2.Should().Be(0);
		}

		[TestMethod]
		public void FutChem_Load()
		{
			Params.FutTypeSelected = 1;

			_page1ViewModel.FutChem_Load();

			Tube.Футеровка.GTotal.Should().Be(0);
			Tube.Футеровка.Al2O3.Should().Be(0.1);
			Tube.Футеровка.C.Should().Be(2.0);
			Tube.Футеровка.CaO.Should().Be(57.0);
			Tube.Футеровка.MgO.Should().Be(38.0);
			Tube.Футеровка.P2O5.Should().Be(2.5);
			Tube.Футеровка.SiO2.Should().Be(1.0);
		}

		[TestInitialize]
		public void InitTest()
		{
			_page1ViewModel = new Page1ViewModel();
		}

		[TestMethod]
		public void LoadNornRasp()
		{
			_page1ViewModel.LoadNornRasp();
			Vars.Raspredelenie[0].Should().Be(0);
			Vars.Raspredelenie[1].Should().Be(-9536);
			Vars.Raspredelenie[2000].Should().Be(16180);
			Vars.Raspredelenie[1989].Should().Be(-15516);
			Vars.Raspredelenie[700].Should().Be(-11288);
		}

		[TestMethod]
		public void MeltNumber_Detect()
		{
			const int ColumnNumberOfMelt = 1;

			new MeltDataMdb()
				.Reader
				.SelectColumnRange<int>("straightcount", ColumnNumberOfMelt)
				.Max()
				.Should().BeGreaterOrEqualTo(_page1ViewModel.MeltNumber_Detect());
		}

		[TestMethod]
		public void MeltNumber_ExistsCheck()
		{
			const int ColumnNumberOfMelt = 1;

			new MeltDataMdb()
				.Reader
				.SelectColumnRange<int>("straightcount", ColumnNumberOfMelt)
				.Should()
				.Contain(220024);

			_page1ViewModel.MeltNumber_Exists(220024).Should().BeTrue();
			_page1ViewModel.MeltNumber_Exists(3504460).Should().BeTrue();
			_page1ViewModel.MeltNumber_Exists(3504).Should().BeFalse();
		}

		[TestMethod]
		public void NeededData_Load()
		{
			_page1ViewModel.NeededData_Load(3504461);

			Tube.Футеровка.G.Should().Be(0);

			Params.FutTypeSelected.Should().Be(1);
			Params.SelectedPlant.Should().Be(1);

			Tube.Дутье.O2.Should().Be(99.732);
			Tube.Дутье.Ar.Should().Be(0.226);
			Tube.Дутье.N2.Should().Be(0.042);

		}

		[TestMethod]
		private void AssumeStraightCountTableIsValid()
		{
			var meltData = new MeltDataMdb();

			meltData.Tables.Count.Should().BeGreaterThan(0);

			const int ColumnNumberOfMelt = 1;

			var columnRange = meltData.Reader
				.SelectColumnRange<int>("straightcount", ColumnNumberOfMelt)
				.ToArray();

			columnRange.Length.Should().BeGreaterThan(0, "Массив количества плавок");

			var max = columnRange.Max();
			max.Should().BeGreaterThan(0, "Номер плавки");
		}

		private Page1ViewModel _page1ViewModel;
	}
}