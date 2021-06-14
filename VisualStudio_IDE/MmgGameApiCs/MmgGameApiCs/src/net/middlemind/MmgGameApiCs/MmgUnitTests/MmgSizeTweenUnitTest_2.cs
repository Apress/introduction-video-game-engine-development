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
    public class MmgSizeTweenUnitTest_2
    {
        public MmgSizeTweenUnitTest_2()
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
            MmgObj o1, o2, o3 = null;
            float f1, f2, f3 = 0.0f;
            MmgVector2 vs1, vs2, vs3 = null;
            MmgVector2 ve1, ve2, ve3 = null;
            MmgSizeTween p1, p2, p3 = null;
            MmgVector2 v = null;

            o1 = new MmgObj(10, 10);
            o2 = new MmgObj(20, 20);
            o3 = new MmgObj(30, 30);

            f1 = 1000.0f;
            f2 = 1500.0f;
            f3 = 2000.0f;

            vs1 = new MmgVector2(10, 10);
            vs2 = new MmgVector2(20, 20);
            vs3 = new MmgVector2(30, 30);

            ve1 = new MmgVector2(110, 110);
            ve2 = new MmgVector2(120, 120);
            ve3 = new MmgVector2(130, 130);

            p1 = new MmgSizeTween(o1, f1, vs1, ve1);
            p3 = new MmgSizeTween(o3, f3, vs3, ve3);

            Assert.AreEqual(true, p1.GetSubj().ApiEquals(o1));
            Assert.AreEqual(true, p1.GetSubj().Equals(o1));

            v = new MmgVector2(110 - 10, 110 - 10);
            Assert.AreEqual(true, p1.GetPixelSizeToChange().ApiEquals(v));
            Assert.AreEqual(true, p1.GetMsTimeToChange() == f1);

            float iX = (100 / f1);
            float iY = (100 / f1);

            Assert.AreEqual(true, p1.GetPixelsPerMsToChangeX() == iX);
            Assert.AreEqual(true, p1.GetPixelsPerMsToChangeY() == iY);
            Assert.AreEqual(true, p1.GetStartSize().ApiEquals(vs1));
            Assert.AreEqual(true, p1.GetStartSize().Equals(vs1));
            Assert.AreEqual(true, p1.GetFinishSize().ApiEquals(ve1));
            Assert.AreEqual(true, p1.GetFinishSize().Equals(ve1));
            Assert.AreEqual(false, p1.GetPosition().ApiEquals(vs1));
            Assert.AreEqual(false, p1.GetPosition().Equals(vs1));
            Assert.AreEqual(true, p1.GetDirStartToFinish() == true);
            Assert.AreEqual(true, p1.GetAtStart() == true);
            Assert.AreEqual(true, p1.GetAtFinish() == false);
            Assert.AreEqual(true, p1.GetChanging() == false);

            p1.SetAtFinish(true);
            p1.SetAtStart(false);
            p1.SetDirStartToFinish(false);
            p1.SetFinishEventId(3);

            Assert.AreEqual(true, p1.GetAtFinish() == true);
            Assert.AreEqual(true, p1.GetAtStart() == false);
            Assert.AreEqual(true, p1.GetDirStartToFinish() == false);
            Assert.AreEqual(true, p1.GetFinishEventId() == 3);

            p1.SetFinishSize(ve2);

            Assert.AreEqual(true, p1.GetFinishSize().ApiEquals(ve2));
            Assert.AreEqual(true, p1.GetFinishSize().Equals(ve2));

            p1.SetHeight(250);
            p1.SetChanging(true);
            p1.SetMsStartChange(333L);
            p1.SetMsTimeToChange(5.0f);

            Assert.AreEqual(true, p1.GetHeight() == 250);
            Assert.AreEqual(true, p1.GetChanging() == true);
            Assert.AreEqual(true, p1.GetMsStartChange() == 333L);
            Assert.AreEqual(true, p1.GetMsTimeToChange() == 5.0f);

            v = new MmgVector2(175, 175);
            p1.SetPixelSizeToChange(v);
            p1.SetPixelsPerMsToChangeX(222f);
            p1.SetPixelsPerMsToChangeY(111f);

            Assert.AreEqual(true, p1.GetPixelSizeToChange().ApiEquals(v));
            Assert.AreEqual(true, p1.GetPixelSizeToChange().Equals(v));
            Assert.AreEqual(p1.GetPixelsPerMsToChangeX(), 222f, 0.01f);
            Assert.AreEqual(p1.GetPixelsPerMsToChangeY(), 111f, 0.01f);

            v = new MmgVector2(150, 150);
            p1.SetPosition(v);

            Assert.AreEqual(true, p1.GetPosition().ApiEquals(v));
            Assert.AreEqual(true, p1.GetPosition().Equals(v));

            p1.SetStartEventId(5);

            Assert.AreEqual(true, p1.GetStartEventId() == 5);

            p1.SetStartSize(v);

            Assert.AreEqual(true, p1.GetStartSize().ApiEquals(v));
            Assert.AreEqual(true, p1.GetStartSize().Equals(v));

            p1.SetSubj(o3);

            Assert.AreEqual(true, p1.GetSubj().ApiEquals(o3));
            Assert.AreEqual(true, p1.GetSubj().Equals(o3));

            p1.SetWidth(200);

            Assert.AreEqual(true, p1.GetWidth() == 200);

            p1.SetX(32);
            p1.SetY(64);

            Assert.AreEqual(true, p1.GetX() == 32);
            Assert.AreEqual(true, p1.GetY() == 64);

            p2 = p1.CloneTyped();

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
            MmgObj o1, o2, o3 = null;
            float f1, f2, f3 = 0.0f;
            MmgVector2 vs1, vs2, vs3 = null;
            MmgVector2 ve1, ve2, ve3 = null;
            MmgSizeTween p1, p2, p3 = null;
            MmgVector2 v = null;

            o1 = new MmgObj(10, 10);
            o2 = new MmgObj(20, 20);
            o3 = new MmgObj(30, 30);

            f1 = 1000.0f;
            f2 = 1500.0f;
            f3 = 2000.0f;

            vs1 = new MmgVector2(10, 10);
            vs2 = new MmgVector2(20, 20);
            vs3 = new MmgVector2(30, 30);

            ve1 = new MmgVector2(110, 110);
            ve2 = new MmgVector2(120, 120);
            ve3 = new MmgVector2(130, 130);

            p1 = new MmgSizeTween(new MmgSizeTween(o1, f1, vs1, ve1));
            p3 = new MmgSizeTween(o3, f3, vs3, ve3);

            Assert.AreEqual(true, p1.GetSubj().ApiEquals(o1));
            Assert.AreEqual(false, p1.GetSubj().Equals(o1));

            v = new MmgVector2(110 - 10, 110 - 10);
            Assert.AreEqual(true, p1.GetPixelSizeToChange().ApiEquals(v));
            Assert.AreEqual(true, p1.GetMsTimeToChange() == f1);

            float iX = (100 / f1);
            float iY = (100 / f1);

            Assert.AreEqual(true, p1.GetPixelsPerMsToChangeX() == iX);
            Assert.AreEqual(true, p1.GetPixelsPerMsToChangeY() == iY);
            Assert.AreEqual(true, p1.GetStartSize().ApiEquals(vs1));
            Assert.AreEqual(false, p1.GetStartSize().Equals(vs1));
            Assert.AreEqual(true, p1.GetFinishSize().ApiEquals(ve1));
            Assert.AreEqual(false, p1.GetFinishSize().Equals(ve1));
            Assert.AreEqual(false, p1.GetPosition().ApiEquals(vs1));
            Assert.AreEqual(false, p1.GetPosition().Equals(vs1));
            Assert.AreEqual(true, p1.GetDirStartToFinish() == true);
            Assert.AreEqual(true, p1.GetAtStart() == true);
            Assert.AreEqual(true, p1.GetAtFinish() == false);
            Assert.AreEqual(true, p1.GetChanging() == false);

            p1.SetAtFinish(true);
            p1.SetAtStart(false);
            p1.SetDirStartToFinish(false);
            p1.SetFinishEventId(3);

            Assert.AreEqual(true, p1.GetAtFinish() == true);
            Assert.AreEqual(true, p1.GetAtStart() == false);
            Assert.AreEqual(true, p1.GetDirStartToFinish() == false);
            Assert.AreEqual(true, p1.GetFinishEventId() == 3);

            p1.SetFinishSize(ve2);

            Assert.AreEqual(true, p1.GetFinishSize().ApiEquals(ve2));
            Assert.AreEqual(true, p1.GetFinishSize().Equals(ve2));

            p1.SetHeight(250);
            p1.SetChanging(true);
            p1.SetMsStartChange(333L);
            p1.SetMsTimeToChange(5.0f);

            Assert.AreEqual(true, p1.GetHeight() == 250);
            Assert.AreEqual(true, p1.GetChanging() == true);
            Assert.AreEqual(true, p1.GetMsStartChange() == 333L);
            Assert.AreEqual(true, p1.GetMsTimeToChange() == 5.0f);

            v = new MmgVector2(175, 175);
            p1.SetPixelSizeToChange(v);
            p1.SetPixelsPerMsToChangeX(222f);
            p1.SetPixelsPerMsToChangeY(111f);

            Assert.AreEqual(true, p1.GetPixelSizeToChange().ApiEquals(v));
            Assert.AreEqual(true, p1.GetPixelSizeToChange().Equals(v));
            Assert.AreEqual(p1.GetPixelsPerMsToChangeX(), 222f, 0.01f);
            Assert.AreEqual(p1.GetPixelsPerMsToChangeY(), 111f, 0.01f);

            v = new MmgVector2(150, 150);
            p1.SetPosition(v);

            Assert.AreEqual(true, p1.GetPosition().ApiEquals(v));
            Assert.AreEqual(true, p1.GetPosition().Equals(v));

            p1.SetStartEventId(5);

            Assert.AreEqual(true, p1.GetStartEventId() == 5);

            p1.SetStartSize(v);

            Assert.AreEqual(true, p1.GetStartSize().ApiEquals(v));
            Assert.AreEqual(true, p1.GetStartSize().Equals(v));

            p1.SetSubj(o3);

            Assert.AreEqual(true, p1.GetSubj().ApiEquals(o3));
            Assert.AreEqual(true, p1.GetSubj().Equals(o3));

            p1.SetWidth(200);

            Assert.AreEqual(true, p1.GetWidth() == 200);

            p1.SetX(32);
            p1.SetY(64);

            Assert.AreEqual(true, p1.GetX() == 32);
            Assert.AreEqual(true, p1.GetY() == 64);

            p2 = p1.CloneTyped();

            Assert.AreEqual(true, p1.ApiEquals(p1));
            Assert.AreEqual(true, p1.ApiEquals(p2));
            Assert.AreEqual(true, p2.ApiEquals(p1));
            Assert.AreEqual(true, p2.ApiEquals(p1));
            Assert.AreEqual(false, p3.ApiEquals(p1));
            Assert.AreEqual(false, p1.ApiEquals(p3));
        }
    }
}
