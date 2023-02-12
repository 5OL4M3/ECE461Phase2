﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECE461Project1;
using System.Collections.Generic;
using System;

namespace UnitTestsProj
{
    [TestClass]
    public class BusFactorUnitTests
    {
        // Tests based on repo commits as of 2/12/23
        
        // Basic run
        [TestMethod]
        public void BasicRunTest()
        {
            // Stale for ~1 year
            string url = "https://github.com/browserify/browserify";
            BusFactor busFactor = new BusFactor();
            float result = busFactor.GetScore(url);

            // 0.186 = health_percentage score, RSE < 0.50 so should be above 0.186
            Assert.AreEqual(true, result > 0.186);
        }

        // Single committer run
        [TestMethod]
        public void LoneCommitterTest()
        {
            // Stale for ~8 years
            string url = "https://github.com/jonschlinkert/even";
            BusFactor busFactor = new BusFactor();
            float result = busFactor.GetScore(url);

            // 0.126 = health_percentage score; graphScore should be 0
            Assert.AreEqual(0.126, result);
        }

        // Negative score run
        [TestMethod]
        public void VeryHighRseTest()
        {
            // Stale for ~2 years
            string url = " https://github.com/lodash/lodash";
            BusFactor busFactor = new BusFactor();
            float result = busFactor.GetScore(url);

            // 0.186 = health_percentage score; RSE is 83.05%
            Assert.AreEqual(0.186, result);
        }
    }
}
