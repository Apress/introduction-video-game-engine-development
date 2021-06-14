package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
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
public class MmgBmpUnitTest_2 {
    
    public MmgBmpUnitTest_2() {
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
        MmgBmp b1, b2, b3 = null;
        MmgRect r1 = null;
        MmgVector2 v1 = null;
        
        b1 = new MmgBmp();
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetImage() == null);
        Assert.assertEquals(true, b1.GetRotation() == 0f);

        b1.SetBmpIdStr("Test String");
        
        Assert.assertEquals(true, b1.GetBmpIdStr().equals("Test String"));
        
        r1 = new MmgRect(0, 0, 10, 10);
        b1.SetDstRect(r1);
        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetDstRect().equals(r1));
        
        b1.SetImage(b2.GetImage());
        
        Assert.assertEquals(true, b1.GetImage().equals(b2.GetImage()));
        
        v1 = new MmgVector2(20, 20);
        b1.SetOrigin(v1);
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetOrigin().equals(v1));

        b1.SetRotation(90.0f);
        
        Assert.assertEquals(true, b1.GetRotation() == 90.0f);
        
        v1 = new MmgVector2(24, 24);
        b1.SetScaling(v1);
        
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetScaling().equals(v1)); 
        
        r1 = new MmgRect(0, 0, 12, 12);
        b1.SetSrcRect(r1);
        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetSrcRect().equals(r1));     
        
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
        MmgBmp b1, b2, b3 = null;
        MmgRect r1 = null;
        MmgVector2 v1 = null;
        
        b1 = new MmgBmp(new MmgObj(10, 10));
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetImage() == null);
        Assert.assertEquals(true, b1.GetRotation() == 0f);

        b1.SetBmpIdStr("Test String");
        
        Assert.assertEquals(true, b1.GetBmpIdStr().equals("Test String"));
        
        r1 = new MmgRect(0, 0, 10, 10);
        b1.SetDstRect(r1);
        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetDstRect().equals(r1));
        
        b1.SetImage(b2.GetImage());
        
        Assert.assertEquals(true, b1.GetImage().equals(b2.GetImage()));
        
        v1 = new MmgVector2(20, 20);
        b1.SetOrigin(v1);
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetOrigin().equals(v1));

        b1.SetRotation(90.0f);
        
        Assert.assertEquals(true, b1.GetRotation() == 90.0f);
        
        v1 = new MmgVector2(24, 24);
        b1.SetScaling(v1);
        
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetScaling().equals(v1)); 
        
        r1 = new MmgRect(0, 0, 12, 12);
        b1.SetSrcRect(r1);
        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetSrcRect().equals(r1));     
        
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
    public void test3() {
        MmgBmp b1, b2, b3 = null;
        MmgRect r1 = null;
        MmgVector2 v1 = null;
        
        b1 = new MmgBmp(new MmgBmp(new MmgObj(10, 10)));
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetImage() == null);
        Assert.assertEquals(true, b1.GetRotation() == 0f);

        b1.SetBmpIdStr("Test String");
        
        Assert.assertEquals(true, b1.GetBmpIdStr().equals("Test String"));
        
        r1 = new MmgRect(0, 0, 10, 10);
        b1.SetDstRect(r1);
        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetDstRect().equals(r1));
        
        b1.SetImage(b2.GetImage());
        
        Assert.assertEquals(true, b1.GetImage().equals(b2.GetImage()));
        
        v1 = new MmgVector2(20, 20);
        b1.SetOrigin(v1);
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetOrigin().equals(v1));

        b1.SetRotation(90.0f);
        
        Assert.assertEquals(true, b1.GetRotation() == 90.0f);
        
        v1 = new MmgVector2(24, 24);
        b1.SetScaling(v1);
        
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetScaling().equals(v1)); 
        
        r1 = new MmgRect(0, 0, 12, 12);
        b1.SetSrcRect(r1);
        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetSrcRect().equals(r1));     
        
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
    public void test4() {
        MmgBmp b1, b2, b3 = null;
        MmgRect r1 = null;
        MmgVector2 v1 = null;
        
        b1 = new MmgBmp(MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png").GetImage());
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertEquals(false, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetDstRect() == null);        
        Assert.assertEquals(false, b1.GetImage() == null);
        Assert.assertEquals(true, b1.GetRotation() == 0f);

        b1.SetBmpIdStr("Test String");
        
        Assert.assertEquals(true, b1.GetBmpIdStr().equals("Test String"));
        
        r1 = new MmgRect(0, 0, 10, 10);
        b1.SetDstRect(r1);
        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetDstRect().equals(r1));
        
        b1.SetImage(b2.GetImage());
        
        Assert.assertEquals(true, b1.GetImage().equals(b2.GetImage()));
        
        v1 = new MmgVector2(20, 20);
        b1.SetOrigin(v1);
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetOrigin().equals(v1));

        b1.SetRotation(90.0f);
        
        Assert.assertEquals(true, b1.GetRotation() == 90.0f);
        
        v1 = new MmgVector2(24, 24);
        b1.SetScaling(v1);
        
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetScaling().equals(v1)); 
        
        r1 = new MmgRect(0, 0, 12, 12);
        b1.SetSrcRect(r1);
        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetSrcRect().equals(r1));     
        
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
    public void test5() {
        MmgBmp b1, b2, b3 = null;
        MmgRect r1 = null;
        MmgVector2 v1 = null;
        
        b1 = new MmgBmp(MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png").GetImage(), MmgRect.GetUnitRect(), MmgRect.GetUnitRect(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(false, b1.GetDstRect() == null);        
        Assert.assertEquals(false, b1.GetImage() == null);
        Assert.assertEquals(true, b1.GetRotation() == 0f);

        b1.SetBmpIdStr("Test String");
        
        Assert.assertEquals(true, b1.GetBmpIdStr().equals("Test String"));
        
        r1 = new MmgRect(0, 0, 10, 10);
        b1.SetDstRect(r1);
        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetDstRect().equals(r1));
        
        b1.SetImage(b2.GetImage());
        
        Assert.assertEquals(true, b1.GetImage().equals(b2.GetImage()));
        
        v1 = new MmgVector2(20, 20);
        b1.SetOrigin(v1);
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetOrigin().equals(v1));

        b1.SetRotation(90.0f);
        
        Assert.assertEquals(true, b1.GetRotation() == 90.0f);
        
        v1 = new MmgVector2(24, 24);
        b1.SetScaling(v1);
        
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetScaling().equals(v1)); 
        
        r1 = new MmgRect(0, 0, 12, 12);
        b1.SetSrcRect(r1);
        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetSrcRect().equals(r1));     
        
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
    public void test6() {
        MmgBmp b1, b2, b3 = null;
        MmgRect r1 = null;
        MmgVector2 v1 = null;
        
        b1 = new MmgBmp(MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png").GetImage(), MmgVector2.GetOriginVec(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertEquals(false, b1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));        
        Assert.assertEquals(true, b1.GetDstRect() == null);        
        Assert.assertEquals(false, b1.GetImage() == null);
        Assert.assertEquals(true, b1.GetRotation() == 0f);

        b1.SetBmpIdStr("Test String");
        
        Assert.assertEquals(true, b1.GetBmpIdStr().equals("Test String"));
        
        r1 = new MmgRect(0, 0, 10, 10);
        b1.SetDstRect(r1);
        
        Assert.assertEquals(true, b1.GetDstRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetDstRect().equals(r1));
        
        b1.SetImage(b2.GetImage());
        
        Assert.assertEquals(true, b1.GetImage().equals(b2.GetImage()));
        
        v1 = new MmgVector2(20, 20);
        b1.SetOrigin(v1);
        
        Assert.assertEquals(true, b1.GetOrigin().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetOrigin().equals(v1));

        b1.SetRotation(90.0f);
        
        Assert.assertEquals(true, b1.GetRotation() == 90.0f);
        
        v1 = new MmgVector2(24, 24);
        b1.SetScaling(v1);
        
        Assert.assertEquals(true, b1.GetScaling().ApiEquals(v1));
        Assert.assertEquals(true, b1.GetScaling().equals(v1)); 
        
        r1 = new MmgRect(0, 0, 12, 12);
        b1.SetSrcRect(r1);
        
        Assert.assertEquals(true, b1.GetSrcRect().ApiEquals(r1));
        Assert.assertEquals(true, b1.GetSrcRect().equals(r1));     
        
        b2 = b1.CloneTyped();
        
        Assert.assertEquals(true, b1.ApiEquals(b1));                
        Assert.assertEquals(true, b1.ApiEquals(b2));
        Assert.assertEquals(true, b2.ApiEquals(b1));
        Assert.assertEquals(true, b2.ApiEquals(b1));
        Assert.assertEquals(false, b3.ApiEquals(b1));
        Assert.assertEquals(false, b1.ApiEquals(b3));               
    }     
}