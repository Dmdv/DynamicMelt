using DynamicMelt.Model;
using DynamicMelt.Providers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	[DeploymentItem(@"Database", @"Database")]
	public class UnitTests
	{
		[TestMethod]
		public void TestAllMdbExist()
		{
			MdbReaderTestDataShouldExist(new MeltDataMdb(), "StraightCount");
		}

		[TestMethod]
		public void TestStraightCountExists()
		{
			var meltDataMdb = new MeltDataMdb();

			meltDataMdb
				.Reader
				.FetchTable("StraightCount")
				.Should()
				.NotBeNull("The table 'StraightCount' should exist");
		}

		private static void MdbReaderTestDataShouldExist(MdbReader reader, string tableName)
		{
			reader
				.Reader
				.SelectAllRows(tableName)
				.Should()
				.NotBeEmpty("The table " + tableName + "should contain data");
		}
	}
}