package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont.FontType;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgLabelValuePair;
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
public class MmgLabelValuePairUnitTest_2 {
    
    public MmgLabelValuePairUnitTest_2() {
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
        MmgLabelValuePair l1, l2, l3 = null;
        
        l1 = new MmgLabelValuePair();
        l3 = new MmgLabelValuePair();
        
        MmgHelper.wr("l1.GetValue: " + l1.GetValue().ApiToString());
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(new MmgFont(MmgFontData.GetFontBold(), MmgFontData.GetFontSize(), FontType.BOLD)));
        Assert.assertEquals(true, l1.GetValue().ApiEquals(new MmgFont(MmgFontData.GetFontNorm(), MmgFontData.GetFontSize(), FontType.NORMAL)));        
        Assert.assertEquals(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
        Assert.assertEquals(true, l1.GetHeight() == 0);
        Assert.assertEquals(true, l1.GetWidth() == 0);

        l1.SetFontSize(15);
        Assert.assertEquals(true, l1.GetFontSize() == 15);

        l1.SetLabel(MmgFontData.GetMmgFontNorm());
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));
        
        l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());
        
        Assert.assertEquals(true, l1.GetLabelFont().equals(MmgFontData.CreateDefaultNormalFontLg()));

        l1.SetMmgColor(MmgColor.GetBlue());
        l1.SetPaddingX(24);
        
        Assert.assertEquals(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
        Assert.assertEquals(true, l1.GetPaddingX() == 24);

        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        
        l1.SetPosition(50, 50);
        
        Assert.assertEquals(true, l1.GetX() == 50);
        Assert.assertEquals(true, l1.GetY() == 50);

        l1.SetSkipReset(true);
        l1.SetValue(MmgFontData.GetMmgFontItalic());
        
        Assert.assertEquals(true, l1.GetSkipReset() == true);
        Assert.assertEquals(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));
    
        l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());
        
        Assert.assertEquals(true, l1.GetValueFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
    
        l1.SetValueText("Test String");
        
        Assert.assertEquals(true, l1.GetValueText().equals("Test String"));
        
        l2 = l1.CloneTyped();
        
        Assert.assertEquals(true, l1.ApiEquals(l1)); 
        Assert.assertEquals(true, l1.ApiEquals(l2));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(false, l3.ApiEquals(l1));
        Assert.assertEquals(false, l1.ApiEquals(l3));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgLabelValuePair l1, l2, l3 = null;
        
        l1 = new MmgLabelValuePair(MmgFontData.CreateDefaultBoldFontLg(), MmgFontData.CreateDefaultNormalFontLg(), FontType.BOLD, FontType.NORMAL);
        l3 = new MmgLabelValuePair(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.CreateDefaultNormalFontLg(), FontType.BOLD, FontType.NORMAL);
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(new MmgFont(MmgFontData.CreateDefaultBoldFontLg(), MmgFontData.GetFontSize() + 2, FontType.BOLD)));
        Assert.assertEquals(true, l1.GetValue().ApiEquals(new MmgFont(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.GetFontSize() + 2, FontType.NORMAL)));        
        Assert.assertEquals(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
        Assert.assertEquals(true, l1.GetHeight() == 0);
        Assert.assertEquals(true, l1.GetWidth() == 0);

        l1.SetFontSize(15);
        Assert.assertEquals(true, l1.GetFontSize() == 15);

        l1.SetLabel(MmgFontData.GetMmgFontNorm());
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));
        
        l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());
        
        Assert.assertEquals(true, l1.GetLabelFont().equals(MmgFontData.CreateDefaultNormalFontLg()));

        l1.SetMmgColor(MmgColor.GetBlue());
        l1.SetPaddingX(24);
        
        Assert.assertEquals(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
        Assert.assertEquals(true, l1.GetPaddingX() == 24);

        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        
        l1.SetPosition(50, 50);
        
        Assert.assertEquals(true, l1.GetX() == 50);
        Assert.assertEquals(true, l1.GetY() == 50);

        l1.SetSkipReset(true);
        l1.SetValue(MmgFontData.GetMmgFontItalic());
        
        Assert.assertEquals(true, l1.GetSkipReset() == true);
        Assert.assertEquals(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));
    
        l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());
        
        Assert.assertEquals(true, l1.GetValueFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
    
        l1.SetValueText("Test String");
        
        Assert.assertEquals(true, l1.GetValueText().equals("Test String"));
        
        l2 = l1.CloneTyped();
        
        Assert.assertEquals(true, l1.ApiEquals(l1)); 
        Assert.assertEquals(true, l1.ApiEquals(l2));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(false, l3.ApiEquals(l1));
        Assert.assertEquals(false, l1.ApiEquals(l3));               
    }    
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgLabelValuePair l1, l2, l3 = null;
        
        l1 = new MmgLabelValuePair(MmgFontData.CreateDefaultBoldMmgFontLg(), MmgFontData.CreateDefaultNormalMmgFontLg());
        l3 = new MmgLabelValuePair(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.CreateDefaultNormalFontLg(), FontType.NORMAL, FontType.NORMAL);
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(MmgFontData.CreateDefaultBoldMmgFontLg()));
        Assert.assertEquals(true, l1.GetValue().ApiEquals(MmgFontData.CreateDefaultNormalMmgFontLg()));        
        Assert.assertEquals(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
        Assert.assertEquals(true, l1.GetHeight() == 0);
        Assert.assertEquals(true, l1.GetWidth() == 0);

        l1.SetFontSize(15);
        Assert.assertEquals(true, l1.GetFontSize() == 15);

        l1.SetLabel(MmgFontData.GetMmgFontNorm());
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));
        
        l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());
        
        Assert.assertEquals(true, l1.GetLabelFont().equals(MmgFontData.CreateDefaultNormalFontLg()));

        l1.SetMmgColor(MmgColor.GetBlue());
        l1.SetPaddingX(24);
        
        Assert.assertEquals(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
        Assert.assertEquals(true, l1.GetPaddingX() == 24);

        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        
        l1.SetPosition(50, 50);
        
        Assert.assertEquals(true, l1.GetX() == 50);
        Assert.assertEquals(true, l1.GetY() == 50);

        l1.SetSkipReset(true);
        l1.SetValue(MmgFontData.GetMmgFontItalic());
        
        Assert.assertEquals(true, l1.GetSkipReset() == true);
        Assert.assertEquals(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));
    
        l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());
        
        Assert.assertEquals(true, l1.GetValueFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
    
        l1.SetValueText("Test String");
        
        Assert.assertEquals(true, l1.GetValueText().equals("Test String"));
        
        l2 = l1.CloneTyped();
        
        Assert.assertEquals(true, l1.ApiEquals(l1)); 
        Assert.assertEquals(true, l1.ApiEquals(l2));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(false, l3.ApiEquals(l1));
        Assert.assertEquals(false, l1.ApiEquals(l3));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test4() {
        MmgLabelValuePair l1, l2, l3 = null;
        
        l1 = new MmgLabelValuePair(new MmgLabelValuePair(MmgFontData.CreateDefaultBoldMmgFontLg(), MmgFontData.CreateDefaultNormalMmgFontLg()));
        l3 = new MmgLabelValuePair(MmgFontData.CreateDefaultNormalFontLg(), MmgFontData.CreateDefaultNormalFontLg(), FontType.NORMAL, FontType.NORMAL);
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(MmgFontData.CreateDefaultBoldMmgFontLg()));
        Assert.assertEquals(true, l1.GetValue().ApiEquals(MmgFontData.CreateDefaultNormalMmgFontLg()));        
        Assert.assertEquals(true, l1.GetPaddingX() == MmgLabelValuePair.DEFAULT_PADDING_X);
        Assert.assertEquals(true, l1.GetHeight() == 0);
        Assert.assertEquals(true, l1.GetWidth() == 0);

        l1.SetFontSize(15);
        Assert.assertEquals(true, l1.GetFontSize() == 15);

        l1.SetLabel(MmgFontData.GetMmgFontNorm());
        
        Assert.assertEquals(true, l1.GetLabel().ApiEquals(MmgFontData.GetMmgFontNorm()));
        
        l1.SetLabelFont(MmgFontData.CreateDefaultNormalFontLg());
        
        Assert.assertEquals(true, l1.GetLabelFont().equals(MmgFontData.CreateDefaultNormalFontLg()));

        l1.SetMmgColor(MmgColor.GetBlue());
        l1.SetPaddingX(24);
        
        Assert.assertEquals(true, l1.GetMmgColor().ApiEquals(MmgColor.GetBlue()));
        Assert.assertEquals(true, l1.GetPaddingX() == 24);

        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        
        l1.SetPosition(50, 50);
        
        Assert.assertEquals(true, l1.GetX() == 50);
        Assert.assertEquals(true, l1.GetY() == 50);

        l1.SetSkipReset(true);
        l1.SetValue(MmgFontData.GetMmgFontItalic());
        
        Assert.assertEquals(true, l1.GetSkipReset() == true);
        Assert.assertEquals(true, l1.GetValue().ApiEquals(MmgFontData.GetMmgFontItalic()));
    
        l1.SetValueFont(MmgFontData.CreateDefaultBoldFontLg());
        
        Assert.assertEquals(true, l1.GetValueFont().equals(MmgFontData.CreateDefaultBoldFontLg()));
    
        l1.SetValueText("Test String");
        
        Assert.assertEquals(true, l1.GetValueText().equals("Test String"));
        
        l2 = l1.CloneTyped();
        
        Assert.assertEquals(true, l1.ApiEquals(l1)); 
        Assert.assertEquals(true, l1.ApiEquals(l2));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(false, l3.ApiEquals(l1));
        Assert.assertEquals(false, l1.ApiEquals(l3));               
    }    
}