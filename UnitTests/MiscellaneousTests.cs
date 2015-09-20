using System;
using System.Linq;
using DynamicMelt.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	[DeploymentItem(@"Database", @"Database")]
	public class MiscellaneousTests
	{
        /// <summary>
        /// In step 4 there is debug form to load some params from 2 column.
        /// </summary>
		[TestMethod]
		public void TestLoadParams()
		{
			var misc = new MiscellaneousMdb();
			var numbers = misc.Reader
                .SelectColumnRange<string>("Adapt", 2)
                .Select(Convert.ToDouble)
                .ToList();
		    numbers[0].Should().Be(-74);
		    numbers.Count.Should().Be(9);
		}
	}
}
