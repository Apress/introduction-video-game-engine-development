package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgContainer;
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
public class MmgContainerUnitTest {
    
    public MmgContainerUnitTest() {
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
    public void testConstructors() {
        //VAR
        MmgContainer m1;
        MmgVector2 v1;
        int w;
        int h;
        MmgColor c1;
        
        //PREP TEST 1
        m1 = new MmgContainer();
        v1 = new MmgVector2(0, 0);
        w = 0;
        h = 0;
        c1 = new MmgColor(java.awt.Color.ORANGE);
        
        //TEST 1
        Assert.assertEquals(true, v1.ApiEquals(m1.GetPosition()));
        Assert.assertEquals(w, m1.GetWidth());
        Assert.assertEquals(h, m1.GetHeight());
    }
}