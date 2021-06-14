package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSound;
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
public class MmgSoundUnitTest_2 {
    
    public MmgSoundUnitTest_2() {
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
        MmgSound s1, s2, s3;
        
        s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
        s3 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");
        
        Assert.assertEquals(MmgSound.MMG_SOUND_GLOBAL_VOLUME, 0.64999f, 0.001);
        Assert.assertEquals(-24.0866f, s1.GetCurrentVolume(), 0.001);
        Assert.assertEquals(s1.GetCurrentRate(), 1.0f, 0.001);
        
        s2 = s1.Clone();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));         
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s2));
        Assert.assertEquals(false, s1.ApiEquals(s3));
        Assert.assertEquals(false, s3.ApiEquals(s1));        
        
        Assert.assertEquals(1.0f, s1.GetCurrentRate(), 0.001);
        Assert.assertEquals(-24.0866f, s1.GetCurrentVolume(), 0.001);
        
        Assert.assertEquals(true, s1.GetSound().equals(s2.GetSound()));
        Assert.assertEquals(true, s1.GetSound().equals(s1.GetSound()));
        Assert.assertEquals(false, s1.GetSound().equals(s3.GetSound())); 
        
        String idStr = "MmgSound: " + s1.GetIdStr() + " Clip Length MS: " + (s1.GetSound().getMicrosecondLength() / 1000);
        Assert.assertEquals(true, idStr.equals(s1.ApiToString()));
        Assert.assertEquals(false, idStr.equals(s2.ApiToString()));
        Assert.assertEquals(false, idStr.equals(s3.ApiToString()));        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgSound s1, s2, s3, s4;
        
        s1 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");
        s3 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump2.wav");
        s4 = MmgHelper.GetBasicSound(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "playable/auto_load/jump1.wav");        
        
        s1 = new MmgSound(s4);
        
        Assert.assertEquals(MmgSound.MMG_SOUND_GLOBAL_VOLUME, 0.64999f, 0.001);
        Assert.assertEquals(-24.0866f, s1.GetCurrentVolume(), 0.001);
        Assert.assertEquals(s1.GetCurrentRate(), 1.0f, 0.001);
        
        s2 = s1.Clone();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));         
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s2));
        Assert.assertEquals(false, s1.ApiEquals(s3));
        Assert.assertEquals(false, s3.ApiEquals(s1));        
        
        Assert.assertEquals(1.0f, s1.GetCurrentRate(), 0.001);
        Assert.assertEquals(-24.0866f, s1.GetCurrentVolume(), 0.001);
        
        Assert.assertEquals(true, s1.GetSound().equals(s2.GetSound()));
        Assert.assertEquals(true, s1.GetSound().equals(s1.GetSound()));
        Assert.assertEquals(false, s1.GetSound().equals(s3.GetSound())); 
        
        String idStr = "MmgSound: " + s1.GetIdStr() + " Clip Length MS: " + (s1.GetSound().getMicrosecondLength() / 1000);    
        Assert.assertEquals(true, idStr.equals(s1.ApiToString()));
        Assert.assertEquals(false, idStr.equals(s2.ApiToString()));
        Assert.assertEquals(false, idStr.equals(s3.ApiToString()));        
    }    
}