using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using System.Collections.Generic;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgMenuContainerUnitTest_2
    {
        public MmgMenuContainerUnitTest_2()
        {
        }

        [TestInitialize]
        public static void setUpClass()
        {
        }

        [TestCleanup]
        public static void tearDownClass()
        {
        }

        public void setUp()
        {
        }

        public void tearDown()
        {
        }

        [TestMethod]
        public void test1()
        {
            MmgMenuContainer m1, m2, m3 = null;

            m1 = new MmgMenuContainer();
            m3 = new MmgMenuContainer(new MmgObj(10, 10));

            Assert.AreEqual(true, m1.GetContainer() != null);
            Assert.AreEqual(true, m1.GetContainer().Count == 0);

            m2 = m1.CloneTyped();

            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(false, m1.ApiEquals(m3));
        }

        [TestMethod]
        public void test2()
        {
            MmgMenuContainer m1, m2, m3 = null;

            m1 = new MmgMenuContainer(new MmgObj(20, 20));
            m3 = new MmgMenuContainer(new MmgObj(10, 10));

            Assert.AreEqual(true, m1.GetContainer() != null);
            Assert.AreEqual(true, m1.GetContainer().Count == 0);

            m2 = m1.CloneTyped();

            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(false, m1.ApiEquals(m3));
        }

        [TestMethod]
        public void test3()
        {
            MmgMenuContainer m1, m2, m3 = null;
            List<MmgMenuItem> a = null;

            a = new List<MmgMenuItem>();
            a.Add(new MmgMenuItem());
            a.Add(new MmgMenuItem());
            a.Add(new MmgMenuItem());

            m1 = new MmgMenuContainer(new MmgObj(20, 20));
            m3 = new MmgMenuContainer(new MmgObj(10, 10));

            Assert.AreEqual(true, m1.GetContainer() != null);
            Assert.AreEqual(true, m1.GetContainer().Count == 0);

            m1.SetContainer(a);
            Assert.AreEqual(true, m1.GetContainer().Count == 3);

            m2 = m1.CloneTyped();

            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(false, m1.ApiEquals(m3));
        }

        [TestMethod]
        public void test4()
        {
            MmgMenuContainer m1, m2, m3 = null;
            List<MmgMenuItem> a = null;

            a = new List<MmgMenuItem>();
            a.Add(new MmgMenuItem());
            a.Add(new MmgMenuItem());
            a.Add(new MmgMenuItem());

            m1 = new MmgMenuContainer(new MmgMenuContainer(new MmgObj(20, 20)));
            m3 = new MmgMenuContainer(new MmgObj(10, 10));

            Assert.AreEqual(true, m1.GetContainer() != null);
            Assert.AreEqual(true, m1.GetContainer().Count == 0);

            m1.SetContainer(a);
            Assert.AreEqual(true, m1.GetContainer().Count == 3);

            m2 = m1.CloneTyped();

            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(false, m1.ApiEquals(m3));
        }
    }
}