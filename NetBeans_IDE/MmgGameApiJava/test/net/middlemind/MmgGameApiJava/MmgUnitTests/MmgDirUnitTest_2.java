package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgDir;
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
public class MmgDirUnitTest_2 {
    
    public MmgDirUnitTest_2() {
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
        Assert.assertEquals(MmgDir.DIR_FRONT, 0);
        Assert.assertEquals(MmgDir.DIR_BOTTOM, 0);
        Assert.assertEquals(MmgDir.DIR_FRONT, MmgDir.DIR_BOTTOM, 0);        
        Assert.assertEquals(MmgDir.DIR_BACK, 1);
        Assert.assertEquals(MmgDir.DIR_TOP, 1);
        Assert.assertEquals(MmgDir.DIR_BACK, MmgDir.DIR_TOP, 0);
        Assert.assertEquals(MmgDir.DIR_LEFT, 2);
        Assert.assertEquals(MmgDir.DIR_RIGHT, 3);        
    }    
}