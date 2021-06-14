package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.awt.Font;
import java.util.ArrayList;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgTextBlock;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import org.junit.Assert;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author Victor G. Brusca, Middlemind Games
 */
public class MmgTextBlockUnitTest_2 {
    
    public MmgTextBlockUnitTest_2() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test1() {
        MmgTextBlock b1, b2, b3 = null;
        ArrayList<MmgFont> a = null;
        MmgFont f1 = null;
        MmgVector2 v = null;
        Font bf1 = null;
        
        b1 = new MmgTextBlock();
        b3 = new MmgTextBlock();
        
        Assert.assertEquals(true, b1.GetPaddingX() == MmgHelper.ScaleValue(4));
        Assert.assertEquals(true, b1.GetPaddingY() == MmgHelper.ScaleValue(4));
        Assert.assertEquals(true, b1.GetLineHeight() == MmgHelper.ScaleValue(16));
        Assert.assertEquals(true, b1.GetHeight() == MmgHelper.ScaleValue(100));
        Assert.assertEquals(true, b1.GetWidth() == MmgHelper.ScaleValue(100));
        Assert.assertEquals(0, b1.GetLines().size());
        Assert.assertEquals(false, b1.GetLines() == null);
        Assert.assertEquals(0, b1.GetTxt().size());
        Assert.assertEquals(false, b1.GetTxt() == null);           
        Assert.assertEquals(true, b1.GetColor().ApiEquals(MmgColor.GetBlack()));

        b1.SetColor(MmgColor.GetGrayCloud());
        
        Assert.assertEquals(true, b1.GetColor().ApiEquals(MmgColor.GetGrayCloud()));
        
        b1.SetHeight(200);
        b1.SetLineHeight(20);

        Assert.assertEquals(true, b1.GetHeight() == 200);
        Assert.assertEquals(true, b1.GetLineHeight() == 20);
        
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);        
        b1.SetLines(a);
        
        Assert.assertEquals(true, b1.GetLines().equals(a));
        Assert.assertEquals(true, b1.GetLines().size() == 1);        
        
        b1.SetPaddingX(16);
        b1.SetPaddingY(16);

        Assert.assertEquals(true, b1.GetPaddingX() == 16);
        Assert.assertEquals(true, b1.GetPaddingY() == 16);
        
        b1.SetPages(5);
        
        Assert.assertEquals(true, b1.GetPages() == 5);
        
        v = new MmgVector2(50, 50);
        b1.SetPosition(v);
        
        Assert.assertEquals(true, b1.GetPosition().ApiEquals(v));
    
        b1.SetPosition(100, 100);
        
        Assert.assertEquals(true, b1.GetX() == 100);
        Assert.assertEquals(true, b1.GetY() == 100);
        
        bf1 = MmgFontData.CreateDefaultItalicFontLg();
        b1.SetSpriteFont(bf1);
        
        Assert.assertEquals(true, b1.GetSpriteFont().equals(bf1));
    
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 2");
        a.add(f1);        
        b1.SetTxt(a);
        
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 2");
        a.add(f1);        
        b1.SetLines(a);             
        
        f1 = MmgFontData.CreateDefaultMmgFontSm();
        b1.SetText(0, f1);
        
        Assert.assertEquals(true, b1.GetText(0).ApiEquals(f1));
        Assert.assertEquals(true, b1.GetText(0).equals(f1));
        Assert.assertEquals(true, b1.GetLines().equals(a));
        Assert.assertEquals(true, b1.GetLines().size() == 2);
    
        b1.SetWidth(200);
        b1.SetWordCount(20);
        b1.SetX(50);
        b1.SetY(50);
        
        Assert.assertEquals(true, b1.GetWidth() == 200);
        Assert.assertEquals(true, b1.GetWordCount() == 20);
        Assert.assertEquals(true, b1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

        b2 = b1.CloneTyped();
        
        Assert.assertEquals(true, b1.ApiEquals(b1));        
        Assert.assertEquals(true, b1.ApiEquals(b2));
        Assert.assertEquals(true, b2.ApiEquals(b1));
        Assert.assertEquals(true, b2.ApiEquals(b1));
        Assert.assertEquals(false, b3.ApiEquals(b1));
        Assert.assertEquals(false, b1.ApiEquals(b3));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgTextBlock b1, b2, b3, b4 = null;
        ArrayList<MmgFont> a = null;
        MmgFont f1 = null;
        MmgVector2 v = null;
        Font bf1 = null;
        
        b4 = new MmgTextBlock();
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 2");
        a.add(f1);        
        b4.SetTxt(a);
        
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 2");
        a.add(f1);        
        b4.SetLines(a);        
        
        b1 = new MmgTextBlock(b4);
        b3 = new MmgTextBlock();
        
        Assert.assertEquals(true, b1.GetPaddingX() == MmgHelper.ScaleValue(4));
        Assert.assertEquals(true, b1.GetPaddingY() == MmgHelper.ScaleValue(4));
        Assert.assertEquals(true, b1.GetLineHeight() == MmgHelper.ScaleValue(16));
        Assert.assertEquals(true, b1.GetHeight() == MmgHelper.ScaleValue(100));
        Assert.assertEquals(true, b1.GetWidth() == MmgHelper.ScaleValue(100));
        Assert.assertEquals(2, b1.GetLines().size());
        Assert.assertEquals(false, b1.GetLines() == null);
        Assert.assertEquals(2, b1.GetTxt().size());
        Assert.assertEquals(false, b1.GetTxt() == null);           
        Assert.assertEquals(true, b1.GetColor().ApiEquals(MmgColor.GetBlack()));

        b1.SetColor(MmgColor.GetGrayCloud());
        
        Assert.assertEquals(true, b1.GetColor().ApiEquals(MmgColor.GetGrayCloud()));
        
        b1.SetHeight(200);
        b1.SetLineHeight(20);

        Assert.assertEquals(true, b1.GetHeight() == 200);
        Assert.assertEquals(true, b1.GetLineHeight() == 20);
        
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);        
        b1.SetLines(a);
        
        Assert.assertEquals(true, b1.GetLines().equals(a));
        Assert.assertEquals(true, b1.GetLines().size() == 1);        
        
        b1.SetPaddingX(16);
        b1.SetPaddingY(16);

        Assert.assertEquals(true, b1.GetPaddingX() == 16);
        Assert.assertEquals(true, b1.GetPaddingY() == 16);
        
        b1.SetPages(5);
        
        Assert.assertEquals(true, b1.GetPages() == 5);
        
        v = new MmgVector2(50, 50);
        b1.SetPosition(v);
        
        Assert.assertEquals(true, b1.GetPosition().ApiEquals(v));
    
        b1.SetPosition(100, 100);
        
        Assert.assertEquals(true, b1.GetX() == 100);
        Assert.assertEquals(true, b1.GetY() == 100);
        
        bf1 = MmgFontData.CreateDefaultItalicFontLg();
        b1.SetSpriteFont(bf1);
        
        Assert.assertEquals(true, b1.GetSpriteFont().equals(bf1));
    
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 2");
        a.add(f1);        
        b1.SetTxt(a);
        
        a = new ArrayList();
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 1");
        a.add(f1);
        f1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        f1.SetText("Line 2");
        a.add(f1);        
        b1.SetLines(a);             
        
        f1 = MmgFontData.CreateDefaultMmgFontSm();
        b1.SetText(0, f1);
        
        Assert.assertEquals(true, b1.GetText(0).ApiEquals(f1));
        Assert.assertEquals(true, b1.GetText(0).equals(f1));
        Assert.assertEquals(true, b1.GetLines().equals(a));
        Assert.assertEquals(true, b1.GetLines().size() == 2);
    
        b1.SetWidth(200);
        b1.SetWordCount(20);
        b1.SetX(50);
        b1.SetY(50);
        
        Assert.assertEquals(true, b1.GetWidth() == 200);
        Assert.assertEquals(true, b1.GetWordCount() == 20);
        Assert.assertEquals(true, b1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

        b2 = b1.CloneTyped();
        
        Assert.assertEquals(true, b1.ApiEquals(b1));        
        Assert.assertEquals(true, b1.ApiEquals(b2));
        Assert.assertEquals(true, b2.ApiEquals(b1));
        Assert.assertEquals(true, b2.ApiEquals(b1));
        Assert.assertEquals(false, b3.ApiEquals(b1));
        Assert.assertEquals(false, b1.ApiEquals(b3));               
    }    
}