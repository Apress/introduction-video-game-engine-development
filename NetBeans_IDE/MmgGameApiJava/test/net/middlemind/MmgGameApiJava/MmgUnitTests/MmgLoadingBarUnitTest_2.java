package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgLoadingBar;
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
public class MmgLoadingBarUnitTest_2 {
    
    public MmgLoadingBarUnitTest_2() {
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
        MmgLoadingBar l1, l2, l3 = null;
        
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());        
        
        b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");
        
        l1 = new MmgLoadingBar();
        l3 = new MmgLoadingBar();        
        
        l1.SetFillAmt(0.25f);
        l1.SetFillHeight(20);
        l1.SetFillWidth(40);
        
        Assert.assertEquals(l1.GetFillAmt(), 0.25, 0.001);
        Assert.assertEquals(l1.GetFillHeight(), 20);
        Assert.assertEquals(l1.GetFillWidth(), 40);
        
        l1.SetLoadingBarBack(b1);
        l1.SetLoadingBarFront(b2);
        l1.SetPaddingX(12);
        l1.SetPaddingY(12);
        
        Assert.assertEquals(true, l1.GetLoadingBarBack().equals(b1));
        Assert.assertEquals(true, l1.GetLoadingBarBack().ApiEquals(b1));
        Assert.assertEquals(l1.GetPaddingX(), 12);
        Assert.assertEquals(l1.GetPaddingY(), 12);
        
        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertEquals(l1.GetX(), 1);
        Assert.assertEquals(l1.GetY(), 1);
        
        l1.SetX(2);
        l1.SetY(2);        
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
        Assert.assertEquals(l1.GetX(), 2);
        Assert.assertEquals(l1.GetY(), 2);
        
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
        MmgBmp b1, b2 = null;
        MmgLoadingBar l1, l2, l3 = null;
        
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());        
        
        b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");
        
        l1 = new MmgLoadingBar(b1, b2);
        l3 = new MmgLoadingBar(b2, b1);    
        
        l1.SetFillAmt(0.25f);
        l1.SetFillHeight(20);
        l1.SetFillWidth(40);
        
        Assert.assertEquals(l1.GetFillAmt(), 0.25, 0.001);
        Assert.assertEquals(l1.GetFillHeight(), 20);
        Assert.assertEquals(l1.GetFillWidth(), 40);
        
        l1.SetLoadingBarBack(b1);
        l1.SetLoadingBarFront(b2);
        l1.SetPaddingX(12);
        l1.SetPaddingY(12);
        
        Assert.assertEquals(true, l1.GetLoadingBarBack().equals(b1));
        Assert.assertEquals(true, l1.GetLoadingBarBack().ApiEquals(b1));
        Assert.assertEquals(l1.GetPaddingX(), 12);
        Assert.assertEquals(l1.GetPaddingY(), 12);
        
        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertEquals(l1.GetX(), 1);
        Assert.assertEquals(l1.GetY(), 1);
        
        l1.SetX(2);
        l1.SetY(2);        
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
        Assert.assertEquals(l1.GetX(), 2);
        Assert.assertEquals(l1.GetY(), 2);
        
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
        MmgBmp b1, b2 = null;
        MmgLoadingBar l1, l2, l3, l4 = null;
        
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());        
        
        b1 = MmgHelper.CreateFilledBmp(6, 6, MmgColor.GetCalmBlue());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/loading_bar.png");
        
        l4 = new MmgLoadingBar(b1, b2);
        l1 = new MmgLoadingBar(l4);
        l3 = new MmgLoadingBar(b2, b1);    
        
        l1.SetFillAmt(0.25f);
        l1.SetFillHeight(20);
        l1.SetFillWidth(40);
        
        Assert.assertEquals(l1.GetFillAmt(), 0.25, 0.001);
        Assert.assertEquals(l1.GetFillHeight(), 20);
        Assert.assertEquals(l1.GetFillWidth(), 40);
        
        l1.SetLoadingBarBack(b1);
        l1.SetLoadingBarFront(b2);
        l1.SetPaddingX(12);
        l1.SetPaddingY(12);
        
        Assert.assertEquals(true, l1.GetLoadingBarBack().equals(b1));
        Assert.assertEquals(true, l1.GetLoadingBarBack().ApiEquals(b1));
        Assert.assertEquals(l1.GetPaddingX(), 12);
        Assert.assertEquals(l1.GetPaddingY(), 12);
        
        l1.SetPosition(MmgVector2.GetUnitVec());
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertEquals(l1.GetX(), 1);
        Assert.assertEquals(l1.GetY(), 1);
        
        l1.SetX(2);
        l1.SetY(2);        
        
        Assert.assertEquals(true, l1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
        Assert.assertEquals(l1.GetX(), 2);
        Assert.assertEquals(l1.GetY(), 2);
        
        l2 = l1.CloneTyped();
        
        Assert.assertEquals(true, l1.ApiEquals(l1));                
        Assert.assertEquals(true, l1.ApiEquals(l2));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(true, l2.ApiEquals(l1));
        Assert.assertEquals(false, l3.ApiEquals(l1));
        Assert.assertEquals(false, l1.ApiEquals(l3));        
    }    
}