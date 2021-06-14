package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
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
public class MmgSpriteUnitTest_2 {
    
    public MmgSpriteUnitTest_2() {
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
        MmgBmp frame1, frame2, frame3 = null;
        MmgBmp[] frames1, frames2 = null;
        MmgSprite sprite1, sprite2, sprite3 = null;
                
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());
        
        frame1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame1);
        
        frame2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");    
        frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame2);
        
        frame3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
        frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame3);
        
        frames1 = new MmgBmp[4];
        frames1[0] = frame1;
        frames1[1] = frame2;
        frames1[2] = frame3;
        frames1[3] = frame2;  
        
        frames2 = new MmgBmp[4];
        frames2[0] = frame1;
        frames2[1] = frame2;
        frames2[2] = frame3;        
        
        sprite1 = new MmgSprite(frames1, frame1.GetPosition().Clone());
        sprite1.SetFrameTime(200l);
        
        sprite3 = new MmgSprite(frames2, frame1.GetPosition().Clone());
        sprite3.SetFrameTime(200l);        
        
        Assert.assertEquals(sprite1.GetRotation(), 0.0f, 0.01);
        Assert.assertEquals(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, sprite1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertEquals(sprite1.GetSrcRect(), null);
        Assert.assertEquals(sprite1.GetDstRect(), null);
        Assert.assertEquals(true, sprite1.GetBmpArray().equals(frames1));
        Assert.assertEquals(true, sprite1.GetPosition().ApiEquals(frame1.GetPosition()));
        Assert.assertEquals(sprite1.GetIsVisible(), true);
        Assert.assertEquals(sprite1.GetSimpleRendering(), true);
        Assert.assertEquals(sprite1.GetMsPerFrame(), 100l);
        Assert.assertEquals(sprite1.GetFrameTime(), 200l);
        
        sprite2 = (MmgSprite)sprite1.Clone();
        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite2));
        Assert.assertEquals(true, sprite2.ApiEquals(sprite1));        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite1));
        Assert.assertEquals(false, sprite1.ApiEquals(null));
        Assert.assertEquals(false, sprite1.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite2.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite3.ApiEquals(sprite2));
        
        sprite2 = sprite1.CloneTyped();
        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite2));
        Assert.assertEquals(true, sprite2.ApiEquals(sprite1));        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite1));
        Assert.assertEquals(false, sprite1.ApiEquals(null));
        Assert.assertEquals(false, sprite1.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite2.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite3.ApiEquals(sprite2));        
        
        sprite1.SetTimerOnly(true);
        
        sprite1.SetSrcRect(MmgRect.GetUnitRect());
        
        Assert.assertEquals(true, sprite1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
        
        sprite1.SetDstRect(MmgRect.GetUnitRect());
        
        Assert.assertEquals(true, sprite1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));        
    
        sprite1.SetPrevFrameTime(300);
        
        Assert.assertEquals(sprite1.GetPrevFrameTime(), 300);
        
        sprite1.SetOrigin(MmgVector2.GetOriginVec());
        
        Assert.assertEquals(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
    
        sprite1.SetMsPerFrame(500);
        
        Assert.assertEquals(sprite1.GetMsPerFrame(), 500, 0);
        
        sprite1.SetFrameTime(2000l);
        
        Assert.assertEquals(sprite1.GetFrameTime(), 2000l, 0);
        
        sprite1.SetFrameStop(5);
        
        Assert.assertEquals(sprite1.GetFrameStop(), 5, 0);
        
        sprite1.SetFrameStart(1);
        
        Assert.assertEquals(sprite1.GetFrameStart(), 1, 0);

        sprite1.SetFrameIdx(3);
        
        Assert.assertEquals(sprite1.GetFrameIdx(), 3, 0);
        
        sprite1.SetCurrentFrame(frame1);
        
        Assert.assertEquals(true, sprite1.GetBmpArray()[sprite1.GetFrameIdx()].equals(frame1));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgBmp frame1, frame2, frame3 = null;
        MmgBmp[] frames1, frames2 = null;
        MmgSprite sprite1, sprite2, sprite3 = null;
                
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());
        
        frame1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame1);
        
        frame2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");    
        frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame2);
        
        frame3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
        frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame3);
        
        frames1 = new MmgBmp[4];
        frames1[0] = frame1;
        frames1[1] = frame2;
        frames1[2] = frame3;
        frames1[3] = frame2;  
        
        frames2 = new MmgBmp[4];
        frames2[0] = frame1;
        frames2[1] = frame2;
        frames2[2] = frame3;        
        
        sprite1 = new MmgSprite(frames1, frame1.GetPosition().Clone(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
        sprite1.SetFrameTime(200l);
        
        sprite3 = new MmgSprite(frames2, frame1.GetPosition().Clone());
        sprite3.SetFrameTime(200l);        
        
        Assert.assertEquals(sprite1.GetRotation(), 0.0f, 0.01);
        Assert.assertEquals(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, sprite1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertEquals(true, sprite1.GetSrcRect().ApiEquals(new MmgRect(sprite1.GetPosition(), frame1.GetWidth(), frame1.GetHeight())));
        Assert.assertEquals(sprite1.GetDstRect(), null);
        Assert.assertEquals(true, sprite1.GetBmpArray().equals(frames1));
        Assert.assertEquals(true, sprite1.GetPosition().ApiEquals(frame1.GetPosition()));
        Assert.assertEquals(sprite1.GetIsVisible(), true);
        Assert.assertEquals(sprite1.GetSimpleRendering(), true);
        Assert.assertEquals(sprite1.GetMsPerFrame(), 100l);
        Assert.assertEquals(sprite1.GetFrameTime(), 200l);
        
        sprite2 = (MmgSprite)sprite1.Clone();
        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite2));
        Assert.assertEquals(true, sprite2.ApiEquals(sprite1));        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite1));
        Assert.assertEquals(false, sprite1.ApiEquals(null));
        Assert.assertEquals(false, sprite1.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite2.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite3.ApiEquals(sprite2));
        
        sprite2 = sprite1.CloneTyped();
        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite2));
        Assert.assertEquals(true, sprite2.ApiEquals(sprite1));        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite1));
        Assert.assertEquals(false, sprite1.ApiEquals(null));
        Assert.assertEquals(false, sprite1.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite2.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite3.ApiEquals(sprite2));        
        
        sprite1.SetTimerOnly(true);
        
        sprite1.SetSrcRect(MmgRect.GetUnitRect());
        
        Assert.assertEquals(true, sprite1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
        
        sprite1.SetDstRect(MmgRect.GetUnitRect());
        
        Assert.assertEquals(true, sprite1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));        
    
        sprite1.SetPrevFrameTime(300);
        
        Assert.assertEquals(sprite1.GetPrevFrameTime(), 300);
        
        sprite1.SetOrigin(MmgVector2.GetOriginVec());
        
        Assert.assertEquals(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
    
        sprite1.SetMsPerFrame(500);
        
        Assert.assertEquals(sprite1.GetMsPerFrame(), 500, 0);
        
        sprite1.SetFrameTime(2000l);
        
        Assert.assertEquals(sprite1.GetFrameTime(), 2000l, 0);
        
        sprite1.SetFrameStop(5);
        
        Assert.assertEquals(sprite1.GetFrameStop(), 5, 0);
        
        sprite1.SetFrameStart(1);
        
        Assert.assertEquals(sprite1.GetFrameStart(), 1, 0);

        sprite1.SetFrameIdx(3);
        
        Assert.assertEquals(sprite1.GetFrameIdx(), 3, 0);
        
        sprite1.SetCurrentFrame(frame1);
        
        Assert.assertEquals(true, sprite1.GetBmpArray()[sprite1.GetFrameIdx()].equals(frame1));
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgBmp frame1, frame2, frame3 = null;
        MmgBmp[] frames1, frames2 = null;
        MmgSprite sprite1, sprite2, sprite3 = null;
                
        MmgScreenData.SetScale(MmgVector2.GetUnitVec());
        
        frame1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame1);
        
        frame2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");    
        frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame2);
        
        frame3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");
        frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame3);
        
        frames1 = new MmgBmp[4];
        frames1[0] = frame1;
        frames1[1] = frame2;
        frames1[2] = frame3;
        frames1[3] = frame2;  
        
        frames2 = new MmgBmp[4];
        frames2[0] = frame1;
        frames2[1] = frame2;
        frames2[2] = frame3;        
        
        sprite1 = new MmgSprite(frames1, new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth()), new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth()), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
        sprite1.SetFrameTime(200l);
        
        sprite3 = new MmgSprite(frames2, frame1.GetPosition().Clone());
        sprite3.SetFrameTime(200l);        
        
        Assert.assertEquals(sprite1.GetRotation(), 0.0f, 0.01);
        Assert.assertEquals(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, sprite1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertEquals(true, sprite1.GetSrcRect().ApiEquals(new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth())));
        Assert.assertEquals(true, sprite1.GetDstRect().ApiEquals(new MmgRect(0, 0, frame1.GetHeight(), frame1.GetWidth())));
        Assert.assertEquals(true, sprite1.GetBmpArray().equals(frames1));
        Assert.assertEquals(true, sprite1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(sprite1.GetIsVisible(), true);
        Assert.assertEquals(sprite1.GetSimpleRendering(), true);
        Assert.assertEquals(sprite1.GetMsPerFrame(), 100l);
        Assert.assertEquals(sprite1.GetFrameTime(), 200l);
        
        sprite2 = (MmgSprite)sprite1.Clone();
        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite2));
        Assert.assertEquals(true, sprite2.ApiEquals(sprite1));        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite1));
        Assert.assertEquals(false, sprite1.ApiEquals(null));
        Assert.assertEquals(false, sprite1.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite2.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite3.ApiEquals(sprite2));
        
        sprite2 = sprite1.CloneTyped();
        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite2));
        Assert.assertEquals(true, sprite2.ApiEquals(sprite1));        
        Assert.assertEquals(true, sprite1.ApiEquals(sprite1));
        Assert.assertEquals(false, sprite1.ApiEquals(null));
        Assert.assertEquals(false, sprite1.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite2.ApiEquals(sprite3));
        Assert.assertEquals(false, sprite3.ApiEquals(sprite2));        
        
        sprite1.SetTimerOnly(true);
        
        sprite1.SetSrcRect(MmgRect.GetUnitRect());
        
        Assert.assertEquals(true, sprite1.GetSrcRect().ApiEquals(MmgRect.GetUnitRect()));
        
        sprite1.SetDstRect(MmgRect.GetUnitRect());
        
        Assert.assertEquals(true, sprite1.GetDstRect().ApiEquals(MmgRect.GetUnitRect()));        
    
        sprite1.SetPrevFrameTime(300);
        
        Assert.assertEquals(sprite1.GetPrevFrameTime(), 300);
        
        sprite1.SetOrigin(MmgVector2.GetOriginVec());
        
        Assert.assertEquals(true, sprite1.GetOrigin().ApiEquals(MmgVector2.GetOriginVec()));
    
        sprite1.SetMsPerFrame(500);
        
        Assert.assertEquals(sprite1.GetMsPerFrame(), 500, 0);
        
        sprite1.SetFrameTime(2000l);
        
        Assert.assertEquals(sprite1.GetFrameTime(), 2000l, 0);
        
        sprite1.SetFrameStop(5);
        
        Assert.assertEquals(sprite1.GetFrameStop(), 5, 0);
        
        sprite1.SetFrameStart(1);
        
        Assert.assertEquals(sprite1.GetFrameStart(), 1, 0);

        sprite1.SetFrameIdx(3);
        
        Assert.assertEquals(sprite1.GetFrameIdx(), 3, 0);
        
        sprite1.SetCurrentFrame(frame1);
        
        Assert.assertEquals(true, sprite1.GetBmpArray()[sprite1.GetFrameIdx()].equals(frame1));
    }    
}