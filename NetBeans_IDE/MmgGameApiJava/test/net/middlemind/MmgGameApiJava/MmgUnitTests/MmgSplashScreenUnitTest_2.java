package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSplashScreen;
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
public class MmgSplashScreenUnitTest_2 {
    
    public MmgSplashScreenUnitTest_2() {
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
        MmgSplashScreen s1, s2, s3 = null;
        
        s1 = new MmgSplashScreen();
        s3 = new MmgSplashScreen(2000);
        
        Assert.assertEquals(s1.GetDisplayTime(), 3000);
        Assert.assertEquals(MmgSplashScreen.DEFAULT_DISPLAY_TIME_MS, 3000);
        
        s1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

        s1.SetHeight(64);
        s1.SetWidth(64);       

        Assert.assertEquals(s1.GetHeight(), 64);
        Assert.assertEquals(s1.GetWidth(), 64);
       
        s1.SetMmgColor(MmgColor.GetBlueGray());

        Assert.assertEquals(true, s1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));
        
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgSplashScreen s1, s2, s3 = null;
        
        s1 = new MmgSplashScreen(1000);
        s3 = new MmgSplashScreen(2000);
        
        Assert.assertEquals(s1.GetDisplayTime(), 1000);
        Assert.assertEquals(MmgSplashScreen.DEFAULT_DISPLAY_TIME_MS, 3000);
        
        s1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

        s1.SetHeight(64);
        s1.SetWidth(64);       

        Assert.assertEquals(s1.GetHeight(), 64);
        Assert.assertEquals(s1.GetWidth(), 64);
       
        s1.SetMmgColor(MmgColor.GetBlueGray());

        Assert.assertEquals(true, s1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));
        
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));                
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgSplashScreen s1, s2, s3, s4 = null;
        
        s4 = new MmgSplashScreen(1000);
        s1 = new MmgSplashScreen(s4);
        s3 = new MmgSplashScreen(2000);
        
        Assert.assertEquals(s1.GetDisplayTime(), 1000);
        Assert.assertEquals(MmgSplashScreen.DEFAULT_DISPLAY_TIME_MS, 3000);
        
        s1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

        s1.SetHeight(64);
        s1.SetWidth(64);       

        Assert.assertEquals(s1.GetHeight(), 64);
        Assert.assertEquals(s1.GetWidth(), 64);
       
        s1.SetMmgColor(MmgColor.GetBlueGray());

        Assert.assertEquals(true, s1.GetMmgColor().ApiEquals(MmgColor.GetBlueGray()));
        
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));                
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));
    }    
}