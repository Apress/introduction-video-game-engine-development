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
    public class MmgObjUnitTest_2
    {
        public MmgObjUnitTest_2()
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
            MmgObj o1, o2, o3 = null;

            o1 = new MmgObj();
            o3 = new MmgObj();

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, o1.GetWidth() == 0);
            Assert.AreEqual(true, o1.GetHeight() == 0);
            Assert.AreEqual(true, o1.GetIsVisible() == true);
            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
            Assert.AreEqual(true, o1.GetHasParent() == false);
            Assert.AreEqual(true, o1.GetParent() == null);
            Assert.AreEqual(true, o1.GetName().Equals(""));
            Assert.AreEqual(true, o1.GetId().Equals(""));

            o1.SetHasParent(true);
            o1.SetHeight(100);
            o1.SetId("Test String");
            o1.SetIsVisible(false);

            Assert.AreEqual(true, o1.GetHasParent() == true);
            Assert.AreEqual(true, o1.GetHeight() == 100);
            Assert.AreEqual(true, o1.GetId().Equals("Test String"));
            Assert.AreEqual(true, o1.GetIsVisible() == false);

            o1.SetMmgColor(MmgColor.GetBlackCat());
            o1.SetName("Test Name");
            o1.SetParent(new MmgObj());

            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetParent().ApiEquals(new MmgObj()));

            o1.SetPosition(50, 50);
            o1.SetWidth(100);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
            Assert.AreEqual(true, o1.GetWidth() == 100);

            o1.SetX(75);
            o1.SetY(75);

            Assert.AreEqual(true, o1.GetX() == 75);
            Assert.AreEqual(true, o1.GetY() == 75);

            o2 = o1.CloneTyped();

            Assert.AreEqual(true, o1.ApiEquals(o1));
            Assert.AreEqual(true, o1.ApiEquals(o2));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(false, o3.ApiEquals(o1));
            Assert.AreEqual(false, o1.ApiEquals(o3));
        }

        [TestMethod]
        public void test2()
        {
            MmgObj o1, o2, o3 = null;

            o1 = new MmgObj("Test Name", "Test Id");
            o3 = new MmgObj();

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, o1.GetWidth() == 0);
            Assert.AreEqual(true, o1.GetHeight() == 0);
            Assert.AreEqual(true, o1.GetIsVisible() == true);
            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
            Assert.AreEqual(true, o1.GetHasParent() == false);
            Assert.AreEqual(true, o1.GetParent() == null);
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetId().Equals("Test Id"));

            o1.SetHasParent(true);
            o1.SetHeight(100);
            o1.SetId("Test String");
            o1.SetIsVisible(false);

            Assert.AreEqual(true, o1.GetHasParent() == true);
            Assert.AreEqual(true, o1.GetHeight() == 100);
            Assert.AreEqual(true, o1.GetId().Equals("Test String"));
            Assert.AreEqual(true, o1.GetIsVisible() == false);

            o1.SetMmgColor(MmgColor.GetBlackCat());
            o1.SetName("Test Name");
            o1.SetParent(new MmgObj());

            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetParent().ApiEquals(new MmgObj()));

            o1.SetPosition(50, 50);
            o1.SetWidth(100);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
            Assert.AreEqual(true, o1.GetWidth() == 100);

            o1.SetX(75);
            o1.SetY(75);

            Assert.AreEqual(true, o1.GetX() == 75);
            Assert.AreEqual(true, o1.GetY() == 75);

            o2 = o1.CloneTyped();

            Assert.AreEqual(true, o1.ApiEquals(o1));
            Assert.AreEqual(true, o1.ApiEquals(o2));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(false, o3.ApiEquals(o1));
            Assert.AreEqual(false, o1.ApiEquals(o3));
        }

        [TestMethod]
        public void test3()
        {
            MmgObj o1, o2, o3 = null;

            o1 = new MmgObj(3, 3, 30, 30, true, MmgColor.GetCyan());
            o3 = new MmgObj();

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(3, 3)));
            Assert.AreEqual(true, o1.GetWidth() == 30);
            Assert.AreEqual(true, o1.GetHeight() == 30);
            Assert.AreEqual(true, o1.GetIsVisible() == true);
            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetCyan()));
            Assert.AreEqual(true, o1.GetHasParent() == false);
            Assert.AreEqual(true, o1.GetParent() == null);
            Assert.AreEqual(true, o1.GetName().Equals(""));
            Assert.AreEqual(true, o1.GetId().Equals(""));

            o1.SetHasParent(true);
            o1.SetHeight(100);
            o1.SetId("Test String");
            o1.SetIsVisible(false);

            Assert.AreEqual(true, o1.GetHasParent() == true);
            Assert.AreEqual(true, o1.GetHeight() == 100);
            Assert.AreEqual(true, o1.GetId().Equals("Test String"));
            Assert.AreEqual(true, o1.GetIsVisible() == false);

            o1.SetMmgColor(MmgColor.GetBlackCat());
            o1.SetName("Test Name");
            o1.SetParent(new MmgObj());

            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetParent().ApiEquals(new MmgObj()));

            o1.SetPosition(50, 50);
            o1.SetWidth(100);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
            Assert.AreEqual(true, o1.GetWidth() == 100);

            o1.SetX(75);
            o1.SetY(75);

            Assert.AreEqual(true, o1.GetX() == 75);
            Assert.AreEqual(true, o1.GetY() == 75);

            o2 = o1.CloneTyped();

            Assert.AreEqual(true, o1.ApiEquals(o1));
            Assert.AreEqual(true, o1.ApiEquals(o2));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(false, o3.ApiEquals(o1));
            Assert.AreEqual(false, o1.ApiEquals(o3));
        }

        [TestMethod]
        public void test4()
        {
            MmgObj o1, o2, o3 = null;

            o1 = new MmgObj(25, 25);
            o3 = new MmgObj(15, 15);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
            Assert.AreEqual(true, o1.GetWidth() == 25);
            Assert.AreEqual(true, o1.GetHeight() == 25);
            Assert.AreEqual(true, o1.GetIsVisible() == true);
            Assert.AreEqual(true, o1.GetMmgColor() == null);
            Assert.AreEqual(true, o1.GetHasParent() == false);
            Assert.AreEqual(true, o1.GetParent() == null);
            Assert.AreEqual(true, o1.GetName().Equals(""));
            Assert.AreEqual(true, o1.GetId().Equals(""));

            o1.SetHasParent(true);
            o1.SetHeight(100);
            o1.SetId("Test String");
            o1.SetIsVisible(false);

            Assert.AreEqual(true, o1.GetHasParent() == true);
            Assert.AreEqual(true, o1.GetHeight() == 100);
            Assert.AreEqual(true, o1.GetId().Equals("Test String"));
            Assert.AreEqual(true, o1.GetIsVisible() == false);

            o1.SetMmgColor(MmgColor.GetBlackCat());
            o1.SetName("Test Name");
            o1.SetParent(new MmgObj());

            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetParent().ApiEquals(new MmgObj()));

            o1.SetPosition(50, 50);
            o1.SetWidth(100);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
            Assert.AreEqual(true, o1.GetWidth() == 100);

            o1.SetX(75);
            o1.SetY(75);

            Assert.AreEqual(true, o1.GetX() == 75);
            Assert.AreEqual(true, o1.GetY() == 75);

            o2 = o1.CloneTyped();

            Assert.AreEqual(true, o1.ApiEquals(o1));
            Assert.AreEqual(true, o1.ApiEquals(o2));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(false, o3.ApiEquals(o1));
            Assert.AreEqual(false, o1.ApiEquals(o3));
        }

        [TestMethod]
        public void test5()
        {
            MmgObj o1, o2, o3 = null;

            o1 = new MmgObj(4, 4, 25, 25, true, MmgColor.GetGray(), "Test Name", "Test Id");
            o3 = new MmgObj(15, 15);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2Int(4, 4)));
            Assert.AreEqual(true, o1.GetWidth() == 25);
            Assert.AreEqual(true, o1.GetHeight() == 25);
            Assert.AreEqual(true, o1.GetIsVisible() == true);
            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetGray()));
            Assert.AreEqual(true, o1.GetHasParent() == false);
            Assert.AreEqual(true, o1.GetParent() == null);
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetId().Equals("Test Id"));

            o1.SetHasParent(true);
            o1.SetHeight(100);
            o1.SetId("Test String");
            o1.SetIsVisible(false);

            Assert.AreEqual(true, o1.GetHasParent() == true);
            Assert.AreEqual(true, o1.GetHeight() == 100);
            Assert.AreEqual(true, o1.GetId().Equals("Test String"));
            Assert.AreEqual(true, o1.GetIsVisible() == false);

            o1.SetMmgColor(MmgColor.GetBlackCat());
            o1.SetName("Test Name");
            o1.SetParent(new MmgObj());

            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetParent().ApiEquals(new MmgObj()));

            o1.SetPosition(50, 50);
            o1.SetWidth(100);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
            Assert.AreEqual(true, o1.GetWidth() == 100);

            o1.SetX(75);
            o1.SetY(75);

            Assert.AreEqual(true, o1.GetX() == 75);
            Assert.AreEqual(true, o1.GetY() == 75);

            o2 = o1.CloneTyped();

            Assert.AreEqual(true, o1.ApiEquals(o1));
            Assert.AreEqual(true, o1.ApiEquals(o2));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(false, o3.ApiEquals(o1));
            Assert.AreEqual(false, o1.ApiEquals(o3));
        }

        [TestMethod]
        public void test6()
        {
            MmgObj o1, o2, o3 = null;

            o1 = new MmgObj(new MmgVector2(4, 4), 25, 25, true, MmgColor.GetGray(), "Test Name", "Test Id");
            o3 = new MmgObj(15, 15);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2Int(4, 4)));
            Assert.AreEqual(true, o1.GetWidth() == 25);
            Assert.AreEqual(true, o1.GetHeight() == 25);
            Assert.AreEqual(true, o1.GetIsVisible() == true);
            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetGray()));
            Assert.AreEqual(true, o1.GetHasParent() == false);
            Assert.AreEqual(true, o1.GetParent() == null);
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetId().Equals("Test Id"));

            o1.SetHasParent(true);
            o1.SetHeight(100);
            o1.SetId("Test String");
            o1.SetIsVisible(false);

            Assert.AreEqual(true, o1.GetHasParent() == true);
            Assert.AreEqual(true, o1.GetHeight() == 100);
            Assert.AreEqual(true, o1.GetId().Equals("Test String"));
            Assert.AreEqual(true, o1.GetIsVisible() == false);

            o1.SetMmgColor(MmgColor.GetBlackCat());
            o1.SetName("Test Name");
            o1.SetParent(new MmgObj());

            Assert.AreEqual(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
            Assert.AreEqual(true, o1.GetName().Equals("Test Name"));
            Assert.AreEqual(true, o1.GetParent().ApiEquals(new MmgObj()));

            o1.SetPosition(50, 50);
            o1.SetWidth(100);

            Assert.AreEqual(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
            Assert.AreEqual(true, o1.GetWidth() == 100);

            o1.SetX(75);
            o1.SetY(75);

            Assert.AreEqual(true, o1.GetX() == 75);
            Assert.AreEqual(true, o1.GetY() == 75);

            o2 = o1.CloneTyped();

            Assert.AreEqual(true, o1.ApiEquals(o1));
            Assert.AreEqual(true, o1.ApiEquals(o2));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(true, o2.ApiEquals(o1));
            Assert.AreEqual(false, o3.ApiEquals(o1));
            Assert.AreEqual(false, o1.ApiEquals(o3));
        }
    }
}