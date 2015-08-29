using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMelt.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	[DeploymentItem(@"Database", @"Database")]
	public class MiscellaneousTests
	{
		[TestMethod]
		public void TestLoadParams()
		{
			var misc = new MiscellaneousMdb();
			var numbers = misc.Reader.SelectColumnRange<string>("Adapt", 2);
		}
	}
}
