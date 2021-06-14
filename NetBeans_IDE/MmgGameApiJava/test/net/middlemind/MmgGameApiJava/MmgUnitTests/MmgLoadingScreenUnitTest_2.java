package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgLoadingBar;
import net.middlemind.MmgGameApiJava.MmgBase.MmgLoadingScreen;
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
public class MmgLoadingScreenUnitTest_2 {
    
    public MmgLoadingScreenUnitTest_2() {
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
        MmgBmp b1, b2, b3, b4 = null;
        MmgLoadingBar l1, l2, l3 = null;
        MmgLoadingScreen s1, s2, s3 = null;
        
        b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");
        
        b3 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetBlue());
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");        
        
        l1 = new MmgLoadingBar(b1, b2);
        l2 = new MmgLoadingBar(b3, b4);
        l3 = new MmgLoadingBar(b2, b1);
        
        s1 = new MmgLoadingScreen();        
        s1.SetLoadingBar(l1, 5.0f);
        s3 = new MmgLoadingScreen(l3, 10.0f);        
        
        Assert.assertEquals(true, s1.GetLoadingBar().ApiEquals(l1));
        Assert.assertEquals(true, s1.GetLoadingBar().equals(l1));        
        Assert.assertEquals(false, s1.GetLoadingBar().ApiEquals(l2));
        Assert.assertEquals(false, s1.GetLoadingBar().equals(l2));                
        
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3)); 
        
        Assert.assertEquals(s1.GetLoadingBarOffsetBottom(), 5.0f, 0.001);
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgBmp b1, b2, b3, b4 = null;
        MmgLoadingBar l1, l2, l3 = null;
        MmgLoadingScreen s1, s2, s3 = null;
        
        b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");
        
        b3 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetBlue());
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");        
        
        l1 = new MmgLoadingBar(b1, b2);
        l2 = new MmgLoadingBar(b3, b4);
        l3 = new MmgLoadingBar(b2, b1);
        
        s1 = new MmgLoadingScreen(l1, 10.0f);        
        s1.SetLoadingBar(l1, 5);
        s3 = new MmgLoadingScreen(l3, 10.0f);        
        
        Assert.assertEquals(true, s1.GetLoadingBar().ApiEquals(l1));
        Assert.assertEquals(true, s1.GetLoadingBar().equals(l1));        
        Assert.assertEquals(false, s1.GetLoadingBar().ApiEquals(l2));
        Assert.assertEquals(false, s1.GetLoadingBar().equals(l2));                
        
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3)); 
        
        Assert.assertEquals(s1.GetLoadingBarOffsetBottom(), 5.0f, 0.001);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgBmp b1, b2, b3, b4 = null;
        MmgLoadingBar l1, l2, l3 = null;
        MmgLoadingScreen s1, s2, s3 = null;
        
        b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");
        
        b3 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetBlue());
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");        
        
        l1 = new MmgLoadingBar(b1, b2);
        l2 = new MmgLoadingBar(b3, b4);
        l3 = new MmgLoadingBar(b2, b1);
        
        s1 = new MmgLoadingScreen(new MmgLoadingScreen(l1, 10.0f));        
        s1.SetLoadingBar(l1, 5);
        s3 = new MmgLoadingScreen(l3, 10.0f);        
        
        Assert.assertEquals(true, s1.GetLoadingBar().ApiEquals(l1));
        Assert.assertEquals(true, s1.GetLoadingBar().equals(l1));        
        Assert.assertEquals(false, s1.GetLoadingBar().ApiEquals(l2));
        Assert.assertEquals(false, s1.GetLoadingBar().equals(l2));                
        
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3)); 
        
        Assert.assertEquals(s1.GetLoadingBarOffsetBottom(), 5.0f, 0.001);
    }
}