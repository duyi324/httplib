﻿using JumpKick.HttpLib.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JumpKick.HttpLib.Tests.Provider
{
    [TestClass]
    public class SettableActionProviderTest
    {
        Mock<Action<WebHeaderCollection, Stream>> success;
        Mock<Action<WebException>> fail;


        [TestInitialize]
        public void SetUp()
        {
            success = new Mock<Action<WebHeaderCollection, Stream>>();
            fail = new Mock<Action<WebException>>();
        }

        [TestMethod]
        public void TestGetSuccess()
        {

            SettableActionProvider sap = new SettableActionProvider(success.Object, fail.Object);
            Assert.AreEqual(success.Object, sap.Success);
        }

        [TestMethod]
        public void TestGetFail()
        {
            SettableActionProvider sap = new SettableActionProvider(success.Object, fail.Object);
            Assert.AreEqual(fail.Object, sap.Fail);
        }
        
    }
}
