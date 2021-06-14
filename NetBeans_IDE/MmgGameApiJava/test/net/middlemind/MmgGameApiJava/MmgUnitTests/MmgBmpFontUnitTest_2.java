package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
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
public class MmgBmpFontUnitTest_2 {
    
    public MmgBmpFontUnitTest_2() {
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
        MmgBmp b1, b2 = null;
        MmgBmpFont f1, f2, f3 = null;
       
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());       
       
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_black.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_white.png");       
        f1 = new MmgBmpFont(b1);
        f3 = new MmgBmpFont(b2);             
       
        Assert.assertEquals(true, b1.equals(f1.GetSrc()));
        Assert.assertEquals(true, " ".equals(f1.GetText()));

        f1.SetHeight(64);
        f1.SetWidth(64);       

        Assert.assertEquals(f1.GetHeight(), 64);
        Assert.assertEquals(f1.GetWidth(), 64);
       
        f1.SetPosition(MmgVector2.GetUnitVec());

        Assert.assertEquals(true, MmgVector2.GetUnitVec().ApiEquals(f1.GetPosition()));

        f1.SetMmgColor(MmgColor.GetBlueGray());

        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

        f2 = f1.CloneTyped();
        
        Assert.assertEquals(true, f1.ApiEquals(f1));        
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));       

        MmgBmp[] crs = f1.GetChars();
        crs[0] = crs[crs.length - 1];
        f1.SetChars(crs);

        Assert.assertEquals(true, crs.equals(f1.GetChars()));
        Assert.assertEquals(true, crs[0].equals(f1.GetChar(crs.length - 1)));
        Assert.assertEquals(false, f1.GetDst() == null);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgBmp b1, b2 = null;
        MmgBmpFont f1, f2, f3 = null;
       
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());       
       
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_black.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_white.png");       
        f1 = new MmgBmpFont(b1, "Test 1");
        f3 = new MmgBmpFont(b2, "Test 2");
       
        Assert.assertEquals(true, b1.equals(f1.GetSrc()));
        Assert.assertEquals(true, "Test 1".equals(f1.GetText()));

        f1.SetHeight(64);
        f1.SetWidth(64);       

        Assert.assertEquals(f1.GetHeight(), 64);
        Assert.assertEquals(f1.GetWidth(), 64);
       
        f1.SetPosition(MmgVector2.GetUnitVec());

        Assert.assertEquals(true, MmgVector2.GetUnitVec().ApiEquals(f1.GetPosition()));

        f1.SetMmgColor(MmgColor.GetBlueGray());

        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

        f2 = f1.CloneTyped();

        Assert.assertEquals(true, f1.ApiEquals(f1));                
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));       

        MmgBmp[] crs = f1.GetChars();
        crs[0] = crs[crs.length - 1];
        f1.SetChars(crs);

        Assert.assertEquals(true, crs.equals(f1.GetChars()));
        Assert.assertEquals(true, crs[0].equals(f1.GetChar(crs.length - 1)));
        Assert.assertEquals(false, f1.GetDst() == null);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgBmp b1, b2 = null;
        MmgBmpFont f1, f2, f3, f4 = null;
       
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());       
       
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_black.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/Caeldera_22pt_white.png");       
        f4 = new MmgBmpFont(b1, "Test 1");
        f1 = new MmgBmpFont(f4);
        f3 = new MmgBmpFont(b2, "Test 2");
       
        Assert.assertEquals(true, b1.ApiEquals(f1.GetSrc()));
        Assert.assertEquals(true, "Test 1".equals(f1.GetText()));

        f1.SetHeight(64);
        f1.SetWidth(64);       

        Assert.assertEquals(f1.GetHeight(), 64);
        Assert.assertEquals(f1.GetWidth(), 64);
       
        f1.SetPosition(MmgVector2.GetUnitVec());

        Assert.assertEquals(true, MmgVector2.GetUnitVec().ApiEquals(f1.GetPosition()));

        f1.SetMmgColor(MmgColor.GetBlueGray());

        Assert.assertEquals(true, f1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));

        f2 = f1.CloneTyped();

        Assert.assertEquals(true, f1.ApiEquals(f1));                
        Assert.assertEquals(true, f1.ApiEquals(f2));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(true, f2.ApiEquals(f1));
        Assert.assertEquals(false, f3.ApiEquals(f1));
        Assert.assertEquals(false, f1.ApiEquals(f3));       

        MmgBmp[] crs = f1.GetChars();
        crs[0] = crs[crs.length - 1];
        f1.SetChars(crs);

        Assert.assertEquals(true, crs.equals(f1.GetChars()));
        Assert.assertEquals(true, crs[0].equals(f1.GetChar(crs.length - 1)));
        Assert.assertEquals(false, f1.GetDst() == null);
    }     
}