using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using net.middlemind.MmgGameApiCs.MmgBase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace net.middlemind.MmgGameApiCs.MmgUnitTests
{
    /// <summary>
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    [TestClass]
    public class MmgTextBlockUnitTest_2
    {
        public MmgTextBlockUnitTest_2()
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
            MmgTextBlock b1, b2, b3 = null;
            List<MmgFont> a = null;
            MmgFont f1 = null;
            MmgVector2 v = null;
            SpriteFont bf1 = null;

            b1 = new MmgTextBlock();
            b3 = new MmgTextBlock();

            Assert.AreEqual(true, b1.GetPaddingX() == MmgHelper.ScaleValue(4));
            Assert.AreEqual(true, b1.GetPaddingY() == MmgHelper.ScaleValue(4));
            Assert.AreEqual(true, b1.GetLineHeight() == MmgHelper.ScaleValue(16));
            Assert.AreEqual(true, b1.GetHeight() == MmgHelper.ScaleValue(100));
            Assert.AreEqual(true, b1.GetWidth() == MmgHelper.ScaleValue(100));
            Assert.AreEqual(0, b1.GetLines().Count);
            Assert.AreEqual(false, b1.GetLines() == null);
            Assert.AreEqual(0, b1.GetTxt().Count);
            Assert.AreEqual(false, b1.GetTxt() == null);
            Assert.AreEqual(true, b1.GetColor().ApiEquals(MmgColor.GetBlack()));

            b1.SetColor(MmgColor.GetGrayCloud());

            Assert.AreEqual(true, b1.GetColor().ApiEquals(MmgColor.GetGrayCloud()));

            b1.SetHeight(200);
            b1.SetLineHeight(20);

            Assert.AreEqual(true, b1.GetHeight() == 200);
            Assert.AreEqual(true, b1.GetLineHeight() == 20);

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            b1.SetLines(a);

            Assert.AreEqual(true, b1.GetLines().Equals(a));
            Assert.AreEqual(true, b1.GetLines().Count == 1);

            b1.SetPaddingX(16);
            b1.SetPaddingY(16);

            Assert.AreEqual(true, b1.GetPaddingX() == 16);
            Assert.AreEqual(true, b1.GetPaddingY() == 16);

            b1.SetPages(5);

            Assert.AreEqual(true, b1.GetPages() == 5);

            v = new MmgVector2(50, 50);
            b1.SetPosition(v);

            Assert.AreEqual(true, b1.GetPosition().ApiEquals(v));

            b1.SetPosition(100, 100);

            Assert.AreEqual(true, b1.GetX() == 100);
            Assert.AreEqual(true, b1.GetY() == 100);

            bf1 = MmgFontData.CreateDefaultItalicFontLg();
            b1.SetSpriteFont(bf1);

            Assert.AreEqual(true, b1.GetSpriteFont().Equals(bf1));

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 2");
            a.Add(f1);
            b1.SetTxt(a);

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 2");
            a.Add(f1);
            b1.SetLines(a);

            f1 = MmgFontData.CreateDefaultMmgFontSm();
            b1.SetText(0, f1);

            Assert.AreEqual(true, b1.GetText(0).ApiEquals(f1));
            Assert.AreEqual(true, b1.GetText(0).Equals(f1));
            Assert.AreEqual(true, b1.GetLines().Equals(a));
            Assert.AreEqual(true, b1.GetLines().Count == 2);

            b1.SetWidth(200);
            b1.SetWordCount(20);
            b1.SetX(50);
            b1.SetY(50);

            Assert.AreEqual(true, b1.GetWidth() == 200);
            Assert.AreEqual(true, b1.GetWordCount() == 20);
            Assert.AreEqual(true, b1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }

        [TestMethod]
        public void test2()
        {
            MmgTextBlock b1, b2, b3, b4 = null;
            List<MmgFont> a = null;
            MmgFont f1 = null;
            MmgVector2 v = null;
            SpriteFont bf1 = null;

            b4 = new MmgTextBlock();
            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 2");
            a.Add(f1);
            b4.SetTxt(a);

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 2");
            a.Add(f1);
            b4.SetLines(a);

            b1 = new MmgTextBlock(b4);
            b3 = new MmgTextBlock();

            Assert.AreEqual(true, b1.GetPaddingX() == MmgHelper.ScaleValue(4));
            Assert.AreEqual(true, b1.GetPaddingY() == MmgHelper.ScaleValue(4));
            Assert.AreEqual(true, b1.GetLineHeight() == MmgHelper.ScaleValue(16));
            Assert.AreEqual(true, b1.GetHeight() == MmgHelper.ScaleValue(100));
            Assert.AreEqual(true, b1.GetWidth() == MmgHelper.ScaleValue(100));
            Assert.AreEqual(2, b1.GetLines().Count);
            Assert.AreEqual(false, b1.GetLines() == null);
            Assert.AreEqual(2, b1.GetTxt().Count);
            Assert.AreEqual(false, b1.GetTxt() == null);
            Assert.AreEqual(true, b1.GetColor().ApiEquals(MmgColor.GetBlack()));

            b1.SetColor(MmgColor.GetGrayCloud());

            Assert.AreEqual(true, b1.GetColor().ApiEquals(MmgColor.GetGrayCloud()));

            b1.SetHeight(200);
            b1.SetLineHeight(20);

            Assert.AreEqual(true, b1.GetHeight() == 200);
            Assert.AreEqual(true, b1.GetLineHeight() == 20);

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            b1.SetLines(a);

            Assert.AreEqual(true, b1.GetLines().Equals(a));
            Assert.AreEqual(true, b1.GetLines().Count == 1);

            b1.SetPaddingX(16);
            b1.SetPaddingY(16);

            Assert.AreEqual(true, b1.GetPaddingX() == 16);
            Assert.AreEqual(true, b1.GetPaddingY() == 16);

            b1.SetPages(5);

            Assert.AreEqual(true, b1.GetPages() == 5);

            v = new MmgVector2(50, 50);
            b1.SetPosition(v);

            Assert.AreEqual(true, b1.GetPosition().ApiEquals(v));

            b1.SetPosition(100, 100);

            Assert.AreEqual(true, b1.GetX() == 100);
            Assert.AreEqual(true, b1.GetY() == 100);

            bf1 = MmgFontData.CreateDefaultItalicFontLg();
            b1.SetSpriteFont(bf1);

            Assert.AreEqual(true, b1.GetSpriteFont().Equals(bf1));

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 2");
            a.Add(f1);
            b1.SetTxt(a);

            a = new List<MmgFont>();
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 1");
            a.Add(f1);
            f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            f1.SetText("Line 2");
            a.Add(f1);
            b1.SetLines(a);

            f1 = MmgFontData.CreateDefaultMmgFontSm();
            b1.SetText(0, f1);

            Assert.AreEqual(true, b1.GetText(0).ApiEquals(f1));
            Assert.AreEqual(true, b1.GetText(0).Equals(f1));
            Assert.AreEqual(true, b1.GetLines().Equals(a));
            Assert.AreEqual(true, b1.GetLines().Count == 2);

            b1.SetWidth(200);
            b1.SetWordCount(20);
            b1.SetX(50);
            b1.SetY(50);

            Assert.AreEqual(true, b1.GetWidth() == 200);
            Assert.AreEqual(true, b1.GetWordCount() == 20);
            Assert.AreEqual(true, b1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

            b2 = b1.CloneTyped();

            Assert.AreEqual(true, b1.ApiEquals(b1));
            Assert.AreEqual(true, b1.ApiEquals(b2));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(true, b2.ApiEquals(b1));
            Assert.AreEqual(false, b3.ApiEquals(b1));
            Assert.AreEqual(false, b1.ApiEquals(b3));
        }
    }
}
