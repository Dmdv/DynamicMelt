﻿using System;
using DynamicMelt.Chemistry;
using DynamicMelt.Extensions;
using DynamicMelt.Model;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
	[TestClass]
	public class ParamsMdbTests
	{
		[TestMethod]
		public void TestLoadParams()
		{
			var paramsMdb = new ParamsMdb();
			var numbers = paramsMdb.CountData.SelectRowRange(Params.SelectedPlant);
			numbers[3].Should().Be("0,021");
		}
	}
}