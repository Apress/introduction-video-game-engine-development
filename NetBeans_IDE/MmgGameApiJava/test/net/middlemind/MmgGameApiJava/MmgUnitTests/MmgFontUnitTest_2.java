package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.awt.Font;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont.FontType;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
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
public class MmgFontUnitTest_2 {
    
    public MmgFontUnitTest_2() {
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
    public void test1() {
        Font bf1 = null;
        MmgFont f1, f2, f3 = null;
        
        f1 = new MmgFont();
        f3 = new MmgFont(new MmgObj(20, 20));
        
        Assert.assertEquals(true, f1.GetText().equals(""));
        Assert.assertEquals(true, f1.GetFont() == null);
        Assert.assertEquals(true, f1.GetWidth() == 0);
        Assert.assertEquals(true, f1.GetHeight() == 0);
        
        bf1 = MmgFontData.CreateDefaultBoldFontLg();
        f1.SetFont(bf1);
        
        Assert.assertEquals(true, f1.GetFont().equals(bf1));  
        
        f1.SetFontSize(15);
        
        Assert.assertEquals(true, f1.GetFontSize() == 15);
        
        f1.SetText("Test String");
        
        Assert.assertEquals(true, f1.GetText().equals("Test String"));

        f1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
    
        f1.SetMmgColor(MmgColor.GetBrown());
        
        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

        f1.SetHeight(50);
        f1.SetWidth(100);
        
        Assert.assertEquals(true, f1.GetHeight() == 50);
        Assert.assertEquals(true, f1.GetWidth() == 100);
        
        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));        
    }
    
    @Test
    public void test2() {
        Font bf1 = null;
        MmgFont f1, f2, f3 = null;
        
        f1 = new MmgFont(new MmgObj(10, 10));
        f3 = new MmgFont(new MmgObj(20, 20));
        
        Assert.assertEquals(true, f1.GetText().equals(""));
        Assert.assertEquals(true, f1.GetFont() == null);
        Assert.assertEquals(true, f1.GetWidth() == 0);
        Assert.assertEquals(true, f1.GetHeight() == 0);
        
        bf1 = MmgFontData.CreateDefaultBoldFontLg();
        f1.SetFont(bf1);
        
        Assert.assertEquals(true, f1.GetFont().equals(bf1));  
        
        f1.SetFontSize(15);
        
        Assert.assertEquals(true, f1.GetFontSize() == 15);
        
        f1.SetText("Test String");
        
        Assert.assertEquals(true, f1.GetText().equals("Test String"));

        f1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
    
        f1.SetMmgColor(MmgColor.GetBrown());
        
        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

        f1.SetHeight(50);
        f1.SetWidth(100);
        
        Assert.assertEquals(true, f1.GetHeight() == 50);
        Assert.assertEquals(true, f1.GetWidth() == 100);
        
        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));        
    } 
    
    @Test
    public void test3() {
        Font bf1 = null;
        MmgFont f1, f2, f3 = null;
        
        f1 = new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), MmgFontData.GetFontSize() + 2, FontType.BOLD);
        f3 = new MmgFont(new MmgObj(20, 20));
        
        Assert.assertEquals(true, f1.GetText().equals(""));
        Assert.assertEquals(true, f1.GetFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
        Assert.assertEquals(true, f1.GetWidth() == 0);
        Assert.assertEquals(true, f1.GetHeight() == 0);
        
        bf1 = MmgFontData.CreateDefaultBoldFontLg();
        f1.SetFont(bf1);
        
        Assert.assertEquals(true, f1.GetFont().equals(bf1));  
        
        f1.SetFontSize(15);
        
        Assert.assertEquals(true, f1.GetFontSize() == 15);
        
        f1.SetText("Test String");
        
        Assert.assertEquals(true, f1.GetText().equals("Test String"));

        f1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
    
        f1.SetMmgColor(MmgColor.GetBrown());
        
        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

        f1.SetHeight(50);
        f1.SetWidth(100);
        
        Assert.assertEquals(true, f1.GetHeight() == 50);
        Assert.assertEquals(true, f1.GetWidth() == 100);
        
        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));        
    }
    
    @Test
    public void test4() {
        Font bf1 = null;
        MmgFont f1, f2, f3 = null;
        
        f1 = new MmgFont(new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), MmgFontData.GetFontSize() + 2, FontType.BOLD));
        f3 = new MmgFont(new MmgObj(20, 20));
        
        Assert.assertEquals(true, f1.GetText().equals(""));
        Assert.assertEquals(true, f1.GetFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
        Assert.assertEquals(true, f1.GetWidth() == 0);
        Assert.assertEquals(true, f1.GetHeight() == 0);
        
        bf1 = MmgFontData.CreateDefaultBoldFontLg();
        f1.SetFont(bf1);
        
        Assert.assertEquals(true, f1.GetFont().equals(bf1));  
        
        f1.SetFontSize(15);
        
        Assert.assertEquals(true, f1.GetFontSize() == 15);
        
        f1.SetText("Test String");
        
        Assert.assertEquals(true, f1.GetText().equals("Test String"));

        f1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
    
        f1.SetMmgColor(MmgColor.GetBrown());
        
        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

        f1.SetHeight(50);
        f1.SetWidth(100);
        
        Assert.assertEquals(true, f1.GetHeight() == 50);
        Assert.assertEquals(true, f1.GetWidth() == 100);
        
        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));        
    } 
    
    @Test
    public void test5() {
        Font bf1 = null;
        MmgFont f1, f2, f3 = null;
        
        f1 = new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), "Test String", MmgVector2.GetUnitVec(), MmgColor.GetDarkRed());
        f3 = new MmgFont(new MmgObj(20, 20));
                
        Assert.assertEquals(true, f1.GetText().equals("Test String"));
        Assert.assertEquals(true, f1.GetFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
        Assert.assertEquals(true, f1.GetWidth() == 95);
        Assert.assertEquals(true, f1.GetHeight() == 20);
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        
        bf1 = MmgFontData.CreateDefaultBoldFontLg();
        f1.SetFont(bf1);
        
        Assert.assertEquals(true, f1.GetFont().equals(bf1));  
        
        f1.SetFontSize(15);
        
        Assert.assertEquals(true, f1.GetFontSize() == 15);
        
        f1.SetText("Test String");
        
        Assert.assertEquals(true, f1.GetText().equals("Test String"));

        f1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
    
        f1.SetMmgColor(MmgColor.GetBrown());
        
        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

        f1.SetHeight(50);
        f1.SetWidth(100);
        
        Assert.assertEquals(true, f1.GetHeight() == 50);
        Assert.assertEquals(true, f1.GetWidth() == 100);
        
        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));        
    }

    @Test
    public void test6() {
        Font bf1 = null;
        MmgFont f1, f2, f3 = null;
        
        f1 = new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), "Test String", 1, 1, MmgColor.GetDarkRed());
        f3 = new MmgFont(new MmgObj(20, 20));
                
        Assert.assertEquals(true, f1.GetText().equals("Test String"));
        Assert.assertEquals(true, f1.GetFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
        Assert.assertEquals(true, f1.GetWidth() == 95);
        Assert.assertEquals(true, f1.GetHeight() == 20);
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        
        bf1 = MmgFontData.CreateDefaultBoldFontLg();
        f1.SetFont(bf1);
        
        Assert.assertEquals(true, f1.GetFont().equals(bf1));  
        
        f1.SetFontSize(15);
        
        Assert.assertEquals(true, f1.GetFontSize() == 15);
        
        f1.SetText("Test String");
        
        Assert.assertEquals(true, f1.GetText().equals("Test String"));

        f1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, f1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
    
        f1.SetMmgColor(MmgColor.GetBrown());
        
        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBrown()));

        f1.SetHeight(50);
        f1.SetWidth(100);
        
        Assert.assertEquals(true, f1.GetHeight() == 50);
        Assert.assertEquals(true, f1.GetWidth() == 100);
        
        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));        
    }     
}