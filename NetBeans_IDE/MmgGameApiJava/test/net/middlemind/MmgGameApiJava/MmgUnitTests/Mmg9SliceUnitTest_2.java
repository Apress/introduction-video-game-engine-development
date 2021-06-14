package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
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
public class Mmg9SliceUnitTest_2 {
    
    public Mmg9SliceUnitTest_2() {
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
        Mmg9Slice n1, n2, n3 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");        

        n1 = new Mmg9Slice(10, b1, 200, 200);
        n3 = new Mmg9Slice(12, b2, 300, 300);        
        
        Assert.assertEquals(n1.GetOffset(), 10);
        Assert.assertEquals(true, n1.GetSrc().ApiEquals(b1));
        Assert.assertEquals(true, n1.GetSrc().equals(b1));        
        Assert.assertEquals(n1.GetWidth(), 200);
        Assert.assertEquals(n1.GetHeight(), 200);
        Assert.assertEquals(true, n1.GetIsVisible());
        Assert.assertEquals(true, n1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));

        n1.SetDest(b2);
        n1.SetOffset(12);
        n1.SetSrc(b2);
        
        Assert.assertEquals(true, n1.GetDest().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetDest().equals(b2));        
        Assert.assertEquals(true, n1.GetSrc().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetSrc().equals(b2));
        Assert.assertEquals(true, n1.GetDest().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetOffset() == 12);
        
        n2 = n1.CloneTyped();
        
        Assert.assertEquals(true, n1.ApiEquals(n1));                
        Assert.assertEquals(true, n1.ApiEquals(n2));
        Assert.assertEquals(true, n2.ApiEquals(n1));
        Assert.assertEquals(true, n2.ApiEquals(n1));
        Assert.assertEquals(false, n3.ApiEquals(n1));
        Assert.assertEquals(false, n1.ApiEquals(n3));        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgBmp b1, b2 = null;
        Mmg9Slice n1, n2, n3 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");        

        n1 = new Mmg9Slice(10, b1, 200, 200, MmgVector2.GetUnitVec());
        n3 = new Mmg9Slice(12, b2, 300, 300);        
        
        Assert.assertEquals(n1.GetOffset(), 10);
        Assert.assertEquals(true, n1.GetSrc().ApiEquals(b1));
        Assert.assertEquals(true, n1.GetSrc().equals(b1));        
        Assert.assertEquals(n1.GetWidth(), 200);
        Assert.assertEquals(n1.GetHeight(), 200);
        Assert.assertEquals(true, n1.GetIsVisible());
        Assert.assertEquals(true, n1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

        n1.SetDest(b2);
        n1.SetOffset(12);
        n1.SetSrc(b2);
        
        Assert.assertEquals(true, n1.GetDest().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetDest().equals(b2));        
        Assert.assertEquals(true, n1.GetSrc().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetSrc().equals(b2));
        Assert.assertEquals(true, n1.GetDest().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetOffset() == 12);
        
        n2 = n1.CloneTyped();
        
        Assert.assertEquals(true, n1.ApiEquals(n1));                
        Assert.assertEquals(true, n1.ApiEquals(n2));
        Assert.assertEquals(true, n2.ApiEquals(n1));
        Assert.assertEquals(true, n2.ApiEquals(n1));
        Assert.assertEquals(false, n3.ApiEquals(n1));
        Assert.assertEquals(false, n1.ApiEquals(n3));        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgBmp b1, b2 = null;
        Mmg9Slice n1, n2, n3 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");        

        n1 = new Mmg9Slice(new Mmg9Slice(10, b1, 200, 200, MmgVector2.GetUnitVec()));
        n3 = new Mmg9Slice(12, b2, 300, 300);        
        
        Assert.assertEquals(n1.GetOffset(), 10);
        Assert.assertEquals(true, n1.GetSrc().ApiEquals(b1));
        Assert.assertEquals(false, n1.GetSrc().equals(b1));        
        Assert.assertEquals(n1.GetWidth(), 200);
        Assert.assertEquals(n1.GetHeight(), 200);
        Assert.assertEquals(true, n1.GetIsVisible());
        Assert.assertEquals(true, n1.GetPosition().ApiEquals(MmgVector2.GetUnitVec()));

        n1.SetDest(b2);
        n1.SetOffset(12);
        n1.SetSrc(b2);
        
        Assert.assertEquals(true, n1.GetDest().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetDest().equals(b2));        
        Assert.assertEquals(true, n1.GetSrc().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetSrc().equals(b2));
        Assert.assertEquals(true, n1.GetDest().ApiEquals(b2));
        Assert.assertEquals(true, n1.GetOffset() == 12);
        
        n1.SetX(2);
        n1.SetY(2);

        Assert.assertEquals(true, n1.GetPosition().ApiEquals(new MmgVector2(2, 2)));
        
        n2 = n1.CloneTyped();
        
        Assert.assertEquals(true, n1.ApiEquals(n1));                
        Assert.assertEquals(true, n1.ApiEquals(n2));
        Assert.assertEquals(true, n2.ApiEquals(n1));
        Assert.assertEquals(true, n2.ApiEquals(n1));
        Assert.assertEquals(false, n3.ApiEquals(n1));
        Assert.assertEquals(false, n1.ApiEquals(n3));        
    }       
}