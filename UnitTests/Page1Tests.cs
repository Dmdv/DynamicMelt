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
		}

		[TestMethod]
		public void MeltNumber_ExistsCheck()
		{
			_page1ViewModel.MeltNumber_ExistsCheck(1).Should().BeTrue();
			_page1ViewModel.MeltNumber_ExistsCheck(2).Should().BeFalse();
		}

		[TestMethod]
		public void NeededData_Load()
		{
		}

		private Page1ViewModel _page1ViewModel;
	}
}