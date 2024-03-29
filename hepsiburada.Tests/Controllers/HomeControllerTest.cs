﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using hepsiburada;
using hepsiburada.Controllers;

namespace hepsiburada.Tests
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void Index ()
		{
			// Arrange
			var controller = new HomeController ();

			// Act
			var result = (ViewResult)controller.Index ();

			var expectedResult = "";

			// Assert
			Assert.AreEqual (expectedResult, result.ViewData ["RoutesString"]);
		}
	}
}
