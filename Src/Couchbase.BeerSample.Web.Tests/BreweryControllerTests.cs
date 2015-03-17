﻿using System.Collections.Generic;
using System.Web.Mvc;
using Couchbase.BeerSample.Web.Controllers;
using NUnit.Framework;

namespace Couchbase.BeerSample.Web.Tests
{
    [TestFixture]
    public class BreweryControllerTests
    {
        [Test]
        public void Test_GetIndex()
        {
            using (var cluster = new Cluster())
            {
                using (var bucket = cluster.OpenBucket("beer-sample"))
                {
                    var controller = new BreweryController2(bucket);
                    var result = (ViewResult)controller.Index();
                    var breweries = result.Model as List<dynamic>;
                    Assert.AreEqual(10, breweries.Count);
                }
            }
        }
    }
}
