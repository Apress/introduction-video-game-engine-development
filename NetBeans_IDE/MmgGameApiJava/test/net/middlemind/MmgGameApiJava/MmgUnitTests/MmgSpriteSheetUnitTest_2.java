package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteSheet;
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
public class MmgSpriteSheetUnitTest_2 {
    
    public MmgSpriteSheetUnitTest_2() {
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
        MmgSpriteSheet s1, s2, s3 = null;
        MmgBmp[] ba1 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "knight_run_spritesheet.png");        
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");        
        s1 = new MmgSpriteSheet(b1, 16, 16);
        s3 = new MmgSpriteSheet(b2, b2.GetWidth(), b2.GetHeight());
        
        ba1 = new MmgBmp[3];
        ba1[0] = b2;
        ba1[1] = b3;
        ba1[2] = b4;        
        
        Assert.assertEquals(true, s1.GetSrc().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetSrc().equals(b1));

        s1.SetFrame(b4, 0);
        
        Assert.assertEquals(true, s1.GetFrame(0).ApiEquals(b4));
        Assert.assertEquals(true, s1.GetFrame(0).equals(b4));
        
        s1.SetFrames(ba1);
        
        Assert.assertEquals(true, s1.GetFrames().equals(ba1));        

        s1.SetHeight(64);
        s1.SetWidth(64);
        
        Assert.assertEquals(true, s1.GetHeight() == 64);
        Assert.assertEquals(true, s1.GetWidth() == 64);  
        
        s1.SetSrc(b2);
        
        Assert.assertEquals(true, s1.GetSrc().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetSrc().equals(b2));        
    
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
        MmgBmp b1, b2, b3, b4 = null;
        MmgSpriteSheet s1, s2, s3 = null;
        MmgBmp[] ba1 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "knight_run_spritesheet.png");        
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");        
        s1 = new MmgSpriteSheet(new MmgSpriteSheet(b1, 16, 16));
        s3 = new MmgSpriteSheet(b2, b2.GetWidth(), b2.GetHeight());
        
        ba1 = new MmgBmp[3];
        ba1[0] = b2;
        ba1[1] = b3;
        ba1[2] = b4;        
        
        Assert.assertEquals(true, s1.GetSrc().ApiEquals(b1));
        Assert.assertEquals(false, s1.GetSrc().equals(b1));

        s1.SetFrame(b4, 0);
        
        Assert.assertEquals(true, s1.GetFrame(0).ApiEquals(b4));
        Assert.assertEquals(true, s1.GetFrame(0).equals(b4));
        
        s1.SetFrames(ba1);
        
        Assert.assertEquals(true, s1.GetFrames().equals(ba1));        

        s1.SetHeight(64);
        s1.SetWidth(64);
        
        Assert.assertEquals(true, s1.GetHeight() == 64);
        Assert.assertEquals(true, s1.GetWidth() == 64);  
        
        s1.SetSrc(b2);
        
        Assert.assertEquals(true, s1.GetSrc().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetSrc().equals(b2));        
    
        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));                
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));                
    }       
}