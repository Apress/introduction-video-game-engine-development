using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgCfgFileEntry;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgCfgFileEntryUnitTest_2
    {
        public MmgCfgFileEntryUnitTest_2()
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
            MmgCfgFileEntry m1;
            MmgCfgFileEntry m2;
            MmgCfgFileEntry m3;

            m3 = new MmgCfgFileEntry();
            m3.cfgType = CfgEntryType.TYPE_DOUBLE;
            m1 = new MmgCfgFileEntry();

            Assert.AreEqual(m1.name, null);
            Assert.AreEqual(m1.cfgType, CfgEntryType.NONE);
            Assert.AreEqual(m1.str, null);
            Assert.AreEqual(m1.number, (double)0);

            m2 = m1.Clone();
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(m1.ApiToString(), "");
        }

        [TestMethod]
        public void test2()
        {
            MmgCfgFileEntry m1;
            MmgCfgFileEntry m2;
            MmgCfgFileEntry m3;

            m3 = new MmgCfgFileEntry();
            m3.cfgType = CfgEntryType.TYPE_DOUBLE;
            m1 = new MmgCfgFileEntry(new MmgCfgFileEntry());

            Assert.AreEqual(m1.name, null);
            Assert.AreEqual(m1.cfgType, CfgEntryType.NONE);
            Assert.AreEqual(m1.str, null);
            Assert.AreEqual(m1.number, (double)0);

            m2 = m1.Clone();
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(m1.ApiToString(), "");
        }

        [TestMethod]
        public void test3()
        {
            MmgCfgFileEntry m1;
            MmgCfgFileEntry m2;
            MmgCfgFileEntry m3;

            m3 = new MmgCfgFileEntry();
            m3.cfgType = CfgEntryType.TYPE_DOUBLE;
            m1 = new MmgCfgFileEntry();
            m1.name = "Test";
            m1.cfgType = CfgEntryType.TYPE_STRING;
            m1.str = "test_string";

            Assert.AreEqual(m1.name, "Test");
            Assert.AreEqual(m1.cfgType, CfgEntryType.TYPE_STRING);
            Assert.AreEqual(m1.str, "test_string");
            Assert.AreEqual(m1.number, (double)0);

            m2 = m1.Clone();
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(m1.ApiToString(), "Test->test_string");
        }

        [TestMethod]
        public void test4()
        {
            MmgCfgFileEntry m1;
            MmgCfgFileEntry m2;
            MmgCfgFileEntry m3;

            m3 = new MmgCfgFileEntry();
            m3.cfgType = CfgEntryType.TYPE_DOUBLE;
            m1 = new MmgCfgFileEntry();
            m1.name = "Test";
            m1.cfgType = CfgEntryType.TYPE_DOUBLE;
            m1.str = null;
            m1.number = (double)(1.234);

            Assert.AreEqual(m1.name, "Test");
            Assert.AreEqual(m1.cfgType, CfgEntryType.TYPE_DOUBLE);
            Assert.AreEqual(m1.str, null);
            Assert.AreEqual(m1.number, (double)(1.234));
            Assert.AreEqual((double)m1.number, (double)1.234, 0.001);
            Assert.AreEqual((int)m1.number, (int)1);

            m2 = m1.Clone();
            Assert.AreEqual(true, m1.ApiEquals(m2));
            Assert.AreEqual(true, m2.ApiEquals(m1));
            Assert.AreEqual(true, m1.ApiEquals(m1));
            Assert.AreEqual(false, m3.ApiEquals(m1));
            Assert.AreEqual(m1.ApiToString(), "Test=1.234");
        }
    }
}