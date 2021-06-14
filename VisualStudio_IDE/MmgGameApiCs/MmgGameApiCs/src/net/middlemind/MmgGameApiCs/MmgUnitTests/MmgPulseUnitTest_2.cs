using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgPulseUnitTest_2
    {

        public MmgPulseUnitTest_2()
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
        #pragma warning disable CS0219 // Variable is assigned but its value is never used
        public void test1()
        {
            int i1, i2, i3, i4 = 0;
            long l1, l2, l3, l4 = 0;
            double d1, d2, d3, d4 = 0.0d;

            MmgVector2 v1, v2, v3 = null;
            MmgPulse p1, p2, p3 = null;

            i1 = 1;
            i2 = -1;
            i3 = 1;
            i4 = -1;

            l1 = 5000;
            l2 = 10000;
            l3 = 7000;
            l4 = 12000;

            d1 = 0.75d;
            d2 = 0.80d;
            d3 = 0.85d;
            d4 = 0.90d;

            v1 = new MmgVector2(200, 200);
            v2 = new MmgVector2(300, 300);
            v3 = new MmgVector2(400, 400);

            p1 = new MmgPulse(i1, l1, d1, v1);
            p3 = new MmgPulse(i3, l3, d3, v3);

            Assert.AreEqual(true, p1.GetDirection() == i1);
            Assert.AreEqual(true, p1.GetTimeTotal() == l1);
            Assert.AreEqual(true, p1.GetTimeFlip() == l1 / 2);
            Assert.AreEqual(true, p1.GetTimeStart() == 0);
            Assert.AreEqual(true, p1.GetChange() == d1);
            Assert.AreEqual(true, p1.GetBaseLineScaling().ApiEquals(v1));
            Assert.AreEqual(true, p1.GetBaseLineScaling().Equals(v1));
            Assert.AreEqual(true, p1.GetAdjScaling().ApiEquals(new MmgVector2(350.0, 350.0)));
            Assert.AreEqual(true, p1.GetChangePerMs() == 0.06);

            p1.SetAdjScaling(v3);

            Assert.AreEqual(true, p1.GetAdjScaling().ApiEquals(v3));
            Assert.AreEqual(true, p1.GetAdjScaling().Equals(v3));

            p1.SetBaseLineScaling(v3);

            Assert.AreEqual(true, p1.GetBaseLineScaling().ApiEquals(v3));
            Assert.AreEqual(true, p1.GetBaseLineScaling().Equals(v3));

            p1.SetChange(0.90);

            Assert.AreEqual(true, p1.GetChange() == 0.90);

            p1.SetChangePerMs(0.10);

            Assert.AreEqual(true, p1.GetChangePerMs() == 0.10);

            p1.SetDirection(-1);

            Assert.AreEqual(true, p1.GetDirection() == -1);

            p1.SetTimeFlip(3000);
            p1.SetTimeStart(100);
            p1.SetTimeTotal(5000);

            Assert.AreEqual(true, p1.GetTimeFlip() == 3000);
            Assert.AreEqual(true, p1.GetTimeStart() == 100);
            Assert.AreEqual(true, p1.GetTimeTotal() == 5000);

            p2 = p1.Clone();

            Assert.AreEqual(true, p1.ApiEquals(p1));
            Assert.AreEqual(true, p1.ApiEquals(p2));
            Assert.AreEqual(true, p2.ApiEquals(p1));
            Assert.AreEqual(true, p2.ApiEquals(p1));
            Assert.AreEqual(false, p3.ApiEquals(p1));
            Assert.AreEqual(false, p1.ApiEquals(p3));
        }

        [TestMethod]
        #pragma warning disable CS0219 // Variable is assigned but its value is never used
        public void test2()
        {
            int i1, i2, i3, i4 = 0;
            long l1, l2, l3, l4 = 0;
            double d1, d2, d3, d4 = 0.0d;
            MmgVector2 v1, v2, v3 = null;
            MmgPulse p1, p2, p3 = null;

            i1 = 1;
            i2 = -1;
            i3 = 1;
            i4 = -1;

            l1 = 5000;
            l2 = 10000;
            l3 = 7000;
            l4 = 12000;

            d1 = 0.75d;
            d2 = 0.80d;
            d3 = 0.85d;
            d4 = 0.90d;

            v1 = new MmgVector2(200, 200);
            v2 = new MmgVector2(300, 300);
            v3 = new MmgVector2(400, 400);

            p1 = new MmgPulse(new MmgPulse(i1, l1, d1, v1));
            p3 = new MmgPulse(i3, l3, d3, v3);

            Assert.AreEqual(true, p1.GetDirection() == i1);
            Assert.AreEqual(true, p1.GetTimeTotal() == l1);
            Assert.AreEqual(true, p1.GetTimeFlip() == l1 / 2);
            Assert.AreEqual(true, p1.GetTimeStart() == 0);
            Assert.AreEqual(true, p1.GetChange() == d1);
            Assert.AreEqual(true, p1.GetBaseLineScaling().ApiEquals(v1));
            Assert.AreEqual(false, p1.GetBaseLineScaling().Equals(v1));
            Assert.AreEqual(true, p1.GetAdjScaling().ApiEquals(new MmgVector2(350.0, 350.0)));
            Assert.AreEqual(true, p1.GetChangePerMs() == 0.06);

            p1.SetAdjScaling(v3);

            Assert.AreEqual(true, p1.GetAdjScaling().ApiEquals(v3));
            Assert.AreEqual(true, p1.GetAdjScaling().Equals(v3));

            p1.SetBaseLineScaling(v3);

            Assert.AreEqual(true, p1.GetBaseLineScaling().ApiEquals(v3));
            Assert.AreEqual(true, p1.GetBaseLineScaling().Equals(v3));

            p1.SetChange(0.90);

            Assert.AreEqual(true, p1.GetChange() == 0.90);

            p1.SetChangePerMs(0.10);

            Assert.AreEqual(true, p1.GetChangePerMs() == 0.10);

            p1.SetDirection(-1);

            Assert.AreEqual(true, p1.GetDirection() == -1);

            p1.SetTimeFlip(3000);
            p1.SetTimeStart(100);
            p1.SetTimeTotal(5000);

            Assert.AreEqual(true, p1.GetTimeFlip() == 3000);
            Assert.AreEqual(true, p1.GetTimeStart() == 100);
            Assert.AreEqual(true, p1.GetTimeTotal() == 5000);

            p2 = p1.Clone();

            Assert.AreEqual(true, p1.ApiEquals(p1));
            Assert.AreEqual(true, p1.ApiEquals(p2));
            Assert.AreEqual(true, p2.ApiEquals(p1));
            Assert.AreEqual(true, p2.ApiEquals(p1));
            Assert.AreEqual(false, p3.ApiEquals(p1));
            Assert.AreEqual(false, p1.ApiEquals(p3));
        }
    }
}