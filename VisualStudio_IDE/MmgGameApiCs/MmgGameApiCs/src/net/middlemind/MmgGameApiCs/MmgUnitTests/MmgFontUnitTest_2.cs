using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgFont;

//Converted
namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgFontUnitTest_2
    {
        public MmgFontUnitTest_2()
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
            SpriteFont bf1 = null;
            MmgFont f1, f2, f3 = null;

            f1 = new MmgFont();
            f3 = new MmgFont(new MmgObj(20, 20));

            Assert.AreEqual(true, f1.GetText().Equals(""));
            Assert.AreEqual(true, f1.GetFont() == null);
            Assert.AreEqual(true, f1.GetWidth() == 0);
            Assert.AreEqual(true, f1.GetHeight() == 0);

            bf1 = MmgFontData.CreateDefaultBoldFontLg();
            f1.SetFont(bf1);

            Assert.AreEqual(true, f1.GetFont().Equals(bf1));

            f1.SetFontSize(15);

            Assert.AreEqual(true, f1.GetFontSize() == 15);

            f1.SetText("Test String");

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            f1.SetMmgColor(MmgColor.GetBrown());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

            f1.SetHeight(50);
            f1.SetWidth(100);

            Assert.AreEqual(true, f1.GetHeight() == 50);
            Assert.AreEqual(true, f1.GetWidth() == 100);

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));
        }

        [TestMethod]
        public void test2()
        {
            SpriteFont bf1 = null;
            MmgFont f1, f2, f3 = null;

            f1 = new MmgFont(new MmgObj(10, 10));
            f3 = new MmgFont(new MmgObj(20, 20));

            Assert.AreEqual(true, f1.GetText().Equals(""));
            Assert.AreEqual(true, f1.GetFont() == null);
            Assert.AreEqual(true, f1.GetWidth() == 0);
            Assert.AreEqual(true, f1.GetHeight() == 0);

            bf1 = MmgFontData.CreateDefaultBoldFontLg();
            f1.SetFont(bf1);

            Assert.AreEqual(true, f1.GetFont().Equals(bf1));

            f1.SetFontSize(15);

            Assert.AreEqual(true, f1.GetFontSize() == 15);

            f1.SetText("Test String");

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            f1.SetMmgColor(MmgColor.GetBrown());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

            f1.SetHeight(50);
            f1.SetWidth(100);

            Assert.AreEqual(true, f1.GetHeight() == 50);
            Assert.AreEqual(true, f1.GetWidth() == 100);

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));
        }

        [TestMethod]
        public void test3()
        {
            SpriteFont bf1 = null;
            MmgFont f1, f2, f3 = null;

            f1 = new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), FontType.BOLD);
            f3 = new MmgFont(new MmgObj(20, 20));

            Assert.AreEqual(true, f1.GetText().Equals(""));
            Assert.AreEqual(true, f1.GetFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));
            Assert.AreEqual(true, f1.GetWidth() == 0);
            Assert.AreEqual(true, f1.GetHeight() == 0);

            bf1 = MmgFontData.CreateDefaultBoldFontLg();
            f1.SetFont(bf1);

            Assert.AreEqual(true, f1.GetFont().Equals(bf1));

            f1.SetFontSize(15);

            Assert.AreEqual(true, f1.GetFontSize() == 15);

            f1.SetText("Test String");

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            f1.SetMmgColor(MmgColor.GetBrown());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

            f1.SetHeight(50);
            f1.SetWidth(100);

            Assert.AreEqual(true, f1.GetHeight() == 50);
            Assert.AreEqual(true, f1.GetWidth() == 100);

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));
        }

        [TestMethod]
        public void test4()
        {
            SpriteFont bf1 = null;
            MmgFont f1, f2, f3 = null;

            f1 = new MmgFont(new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), FontType.BOLD));
            f3 = new MmgFont(new MmgObj(20, 20));

            Assert.AreEqual(true, f1.GetText().Equals(""));
            Assert.AreEqual(true, f1.GetFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));
            Assert.AreEqual(true, f1.GetWidth() == 0);
            Assert.AreEqual(true, f1.GetHeight() == 0);

            bf1 = MmgFontData.CreateDefaultBoldFontLg();
            f1.SetFont(bf1);

            Assert.AreEqual(true, f1.GetFont().Equals(bf1));

            f1.SetFontSize(15);

            Assert.AreEqual(true, f1.GetFontSize() == 15);

            f1.SetText("Test String");

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            f1.SetMmgColor(MmgColor.GetBrown());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

            f1.SetHeight(50);
            f1.SetWidth(100);

            Assert.AreEqual(true, f1.GetHeight() == 50);
            Assert.AreEqual(true, f1.GetWidth() == 100);

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));
        }

        [TestMethod]
        public void test5()
        {
            SpriteFont bf1 = null;
            MmgFont f1, f2, f3 = null;

            f1 = new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), "Test String", MmgVector2.GetUnitVec(), MmgColor.GetDarkRed(), FontType.BOLD);
            f3 = new MmgFont(new MmgObj(20, 20));

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));
            Assert.AreEqual(true, f1.GetFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));
            Assert.AreEqual(true, f1.GetWidth() == 107);
            Assert.AreEqual(true, f1.GetHeight() == 28);
            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            bf1 = MmgFontData.CreateDefaultBoldFontLg();
            f1.SetFont(bf1);

            Assert.AreEqual(true, f1.GetFont().Equals(bf1));

            f1.SetFontSize(15);

            Assert.AreEqual(true, f1.GetFontSize() == 15);

            f1.SetText("Test String");

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            f1.SetMmgColor(MmgColor.GetBrown());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

            f1.SetHeight(50);
            f1.SetWidth(100);

            Assert.AreEqual(true, f1.GetHeight() == 50);
            Assert.AreEqual(true, f1.GetWidth() == 100);

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));
        }

        [TestMethod]
        public void test6()
        {
            SpriteFont bf1 = null;
            MmgFont f1, f2, f3 = null;

            f1 = new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), "Test String", 1, 1, MmgColor.GetDarkRed(), FontType.BOLD);
            f3 = new MmgFont(new MmgObj(20, 20));

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));
            Assert.AreEqual(true, f1.GetFont().Equals(MmgFontData.CreateDefaultBoldFontLg()));
            Assert.AreEqual(true, f1.GetWidth() == 107);
            Assert.AreEqual(true, f1.GetHeight() == 28);
            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            bf1 = MmgFontData.CreateDefaultBoldFontLg();
            f1.SetFont(bf1);

            Assert.AreEqual(true, f1.GetFont().Equals(bf1));

            f1.SetFontSize(15);

            Assert.AreEqual(true, f1.GetFontSize() == 15);

            f1.SetText("Test String");

            Assert.AreEqual(true, f1.GetText().Equals("Test String"));

            f1.SetPosition(MmgVector2.GetUnitVec());

            Assert.AreEqual(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

            f1.SetMmgColor(MmgColor.GetBrown());

            Assert.AreEqual(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

            f1.SetHeight(50);
            f1.SetWidth(100);

            Assert.AreEqual(true, f1.GetHeight() == 50);
            Assert.AreEqual(true, f1.GetWidth() == 100);

            f2 = f1.CloneTyped();

            Assert.AreEqual(true, f1.ApiEquals(f1));
            Assert.AreEqual(true, f1.ApiEquals(f2));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(true, f2.ApiEquals(f1));
            Assert.AreEqual(false, f3.ApiEquals(f1));
            Assert.AreEqual(false, f1.ApiEquals(f3));
        }
    }
}