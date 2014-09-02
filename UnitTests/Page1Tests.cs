using System.Linq;
using DynamicMelt.Chemistry;
using DynamicMelt.Model;
using DynamicMelt.ViewModel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class Page1Tests
	{
		[TestMethod]
		public void ConvDiameter_Recalculate()
		{
		}

		[TestMethod]
		public void Data_Params_Load()
		{
			_page1ViewModel.Data_Params_Load();
		}

		[TestMethod]
		public void Fakel_Load()
		{
		}

		[TestMethod]
		public void FutChem_Load()
		{
		}

		[TestInitialize]
		public void InitTest()
		{
			_page1ViewModel = new Page1ViewModel();
		}

		[TestMethod]
		public void LoadNornRasp()
		{
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