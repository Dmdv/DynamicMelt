using System;
using Common.Extensions;
using DynamicMelt.Extensions;
using DynamicMelt.Model;
using DynamicMelt.Providers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	[DeploymentItem(@"Database", @"Database")]
	public class MeltDataMdbTests
	{
		[TestMethod]
		public void TestAllMdbExist()
		{
			MdbReaderTestDataShouldExist(new MeltDataMdb(), "StraightCount");
		}

		[TestMethod]
		public void TestMeltDataMeltNumber()
		{
			var meltDataMdb = new MeltDataMdb();

			meltDataMdb.AdaptationData.Should().NotBeNull();
			meltDataMdb.StraightCount.Should().NotBeNull();

			var selectRowDictionary = meltDataMdb.StraightCount.SelectRowDictionary(0);
			selectRowDictionary.Count.Should().BeGreaterThan(0);

			const int MeltColumnIndex = 1;

			var selectRowRange = meltDataMdb.StraightCount.SelectRowRange(MeltColumnIndex);
			Array.FindIndex(selectRowRange, value => value == "220024").Should().Be(MeltColumnIndex);

			const int MeltNumber = 220025;
			var meltRange = meltDataMdb.FindMeltRange(MeltNumber);
			meltRange[MeltColumnIndex].Should().Be(MeltNumber.ToStringWithInvariantCulture());

			meltRange[45].Should().Be("0,1333333");
			meltRange[48].Should().Be("99,732");
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