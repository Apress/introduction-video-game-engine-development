package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
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
public class MmgGameScreenUnitTest_2 {
    
    public MmgGameScreenUnitTest_2() {
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
        MmgGameScreen s1, s2, s3 = null;
        MmgBmp b1, b2, b3 = null;
        MmgMenuContainer mm1 = null;
        MmgObj o1 = null;
        MmgContainer c1 = null;
        
        s1 = new MmgGameScreen();
        s3 = new MmgGameScreen();
        
        Assert.assertEquals(true, s1.GetObjects() != null);
        Assert.assertEquals(true, s1.GetMenu() != null);
        Assert.assertEquals(true, s1.GetBackground() == null);
        Assert.assertEquals(true, s1.GetForeground() == null);
        Assert.assertEquals(true, s1.GetHeader() == null);
        Assert.assertEquals(true, s1.GetFooter() == null);
        Assert.assertEquals(true, s1.GetLeftCursor() == null);
        Assert.assertEquals(true, s1.GetRightCursor() == null);
        Assert.assertEquals(true, s1.GetMessage() == null);
        Assert.assertEquals(true, s1.GetMenuIdx() == 0);
        Assert.assertEquals(true, s1.GetMenuStart() == 0);
        Assert.assertEquals(true, s1.GetMenuStop() == 0);
        Assert.assertEquals(true, s1.GetMenuOn() == false);
        Assert.assertEquals(true, s1.GetWidth() == MmgScreenData.GetGameWidth());
        Assert.assertEquals(true, s1.GetHeight() == MmgScreenData.GetGameHeight());
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));        

        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        s1.SetBackground(b1);
        
        Assert.assertEquals(true, s1.GetBackground().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetBackground().equals(b1));        
        
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");        
        s1.SetForeground(b2);
        
        Assert.assertEquals(true, s1.GetForeground().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetForeground().equals(b2));        
    
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");        
        s1.SetHeader(b3);
        
        Assert.assertEquals(true, s1.GetHeader().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetHeader().equals(b3));        
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        s1.SetFooter(b1);
        
        Assert.assertEquals(true, s1.GetFooter().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetFooter().equals(b1));                
    
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "loading_bar.png");        
        s1.SetLeftCursor(b2);

        Assert.assertEquals(true, s1.GetLeftCursor().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetLeftCursor().equals(b2));

        mm1 = new MmgMenuContainer();
        s1.SetMenu(mm1);
        
        Assert.assertEquals(true, s1.GetMenu().ApiEquals(mm1));
        Assert.assertEquals(true, s1.GetMenu().equals(mm1));
        
        s1.SetMenuCursorLeftOffsetX(12);
        s1.SetMenuCursorLeftOffsetY(12);
        s1.SetMenuCursorRightOffsetX(14);
        s1.SetMenuCursorRightOffsetY(14);
        s1.SetMenuIdx(0);
        s1.SetMenuOn(false);
        
        Assert.assertEquals(true, s1.GetMenuCursorLeftOffsetX() == 12);
        Assert.assertEquals(true, s1.GetMenuCursorLeftOffsetY() == 12);        
        Assert.assertEquals(true, s1.GetMenuCursorRightOffsetX() == 14);
        Assert.assertEquals(true, s1.GetMenuCursorRightOffsetY() == 14);                
        Assert.assertEquals(true, s1.GetMenuIdx() == 0);
        Assert.assertEquals(true, s1.GetMenuOn() == false);
        
        c1 = new MmgContainer();
        o1 = new MmgObj();
        s1.SetMenuStart(0);
        s1.SetMenuStop(10);
        s1.SetMessage(o1);
        s1.SetObjects(c1);
        
        Assert.assertEquals(true, s1.GetMenuStart() == 0);
        Assert.assertEquals(true, s1.GetMenuStop() == 10);
        Assert.assertEquals(true, s1.GetMessage().ApiEquals(o1));
        Assert.assertEquals(true, s1.GetMessage().equals(o1));
        Assert.assertEquals(true, s1.GetObjects().ApiEquals(c1));
        Assert.assertEquals(true, s1.GetObjects().equals(c1));        
    
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

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
        MmgGameScreen s1, s2, s3 = null;
        MmgBmp b1, b2, b3 = null;
        MmgMenuContainer mm1 = null;
        MmgObj o1 = null;
        MmgContainer c1 = null;
        
        s1 = new MmgGameScreen(new MmgGameScreen());
        s3 = new MmgGameScreen();
        
        Assert.assertEquals(true, s1.GetObjects() != null);
        Assert.assertEquals(true, s1.GetMenu() != null);
        Assert.assertEquals(true, s1.GetBackground() == null);
        Assert.assertEquals(true, s1.GetForeground() == null);
        Assert.assertEquals(true, s1.GetHeader() == null);
        Assert.assertEquals(true, s1.GetFooter() == null);
        Assert.assertEquals(true, s1.GetLeftCursor() == null);
        Assert.assertEquals(true, s1.GetRightCursor() == null);
        Assert.assertEquals(true, s1.GetMessage() == null);
        Assert.assertEquals(true, s1.GetMenuIdx() == 0);
        Assert.assertEquals(true, s1.GetMenuStart() == 0);
        Assert.assertEquals(true, s1.GetMenuStop() == 0);
        Assert.assertEquals(true, s1.GetMenuOn() == false);
        Assert.assertEquals(true, s1.GetWidth() == MmgScreenData.GetGameWidth());
        Assert.assertEquals(true, s1.GetHeight() == MmgScreenData.GetGameHeight());
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));        

        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        s1.SetBackground(b1);
        
        Assert.assertEquals(true, s1.GetBackground().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetBackground().equals(b1));        
        
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");        
        s1.SetForeground(b2);
        
        Assert.assertEquals(true, s1.GetForeground().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetForeground().equals(b2));        
    
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");        
        s1.SetHeader(b3);
        
        Assert.assertEquals(true, s1.GetHeader().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetHeader().equals(b3));        
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        s1.SetFooter(b1);
        
        Assert.assertEquals(true, s1.GetFooter().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetFooter().equals(b1));                
    
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "loading_bar.png");        
        s1.SetLeftCursor(b2);

        Assert.assertEquals(true, s1.GetLeftCursor().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetLeftCursor().equals(b2));

        mm1 = new MmgMenuContainer();
        s1.SetMenu(mm1);
        
        Assert.assertEquals(true, s1.GetMenu().ApiEquals(mm1));
        Assert.assertEquals(true, s1.GetMenu().equals(mm1));
        
        s1.SetMenuCursorLeftOffsetX(12);
        s1.SetMenuCursorLeftOffsetY(12);
        s1.SetMenuCursorRightOffsetX(14);
        s1.SetMenuCursorRightOffsetY(14);
        s1.SetMenuIdx(0);
        s1.SetMenuOn(false);
        
        Assert.assertEquals(true, s1.GetMenuCursorLeftOffsetX() == 12);
        Assert.assertEquals(true, s1.GetMenuCursorLeftOffsetY() == 12);        
        Assert.assertEquals(true, s1.GetMenuCursorRightOffsetX() == 14);
        Assert.assertEquals(true, s1.GetMenuCursorRightOffsetY() == 14);                
        Assert.assertEquals(true, s1.GetMenuIdx() == 0);
        Assert.assertEquals(true, s1.GetMenuOn() == false);
        
        c1 = new MmgContainer();
        o1 = new MmgObj();
        s1.SetMenuStart(0);
        s1.SetMenuStop(10);
        s1.SetMessage(o1);
        s1.SetObjects(c1);
        
        Assert.assertEquals(true, s1.GetMenuStart() == 0);
        Assert.assertEquals(true, s1.GetMenuStop() == 10);
        Assert.assertEquals(true, s1.GetMessage().ApiEquals(o1));
        Assert.assertEquals(true, s1.GetMessage().equals(o1));
        Assert.assertEquals(true, s1.GetObjects().ApiEquals(c1));
        Assert.assertEquals(true, s1.GetObjects().equals(c1));        
    
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));

        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));        
    }    
}