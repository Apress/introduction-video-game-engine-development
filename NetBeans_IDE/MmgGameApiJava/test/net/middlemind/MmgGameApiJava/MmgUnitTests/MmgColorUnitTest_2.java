package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.awt.Color;
import org.junit.Assert;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author Victor G. Brusca, Middlemind Games
 */
public class MmgColorUnitTest_2 {
    
    public MmgColorUnitTest_2() {
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
        MmgColor c1;
        MmgColor c2;
        MmgColor c3;
        
        c3 = new MmgColor(Color.YELLOW);
        c1 = new MmgColor();
        Assert.assertEquals(c1.GetColor(), Color.WHITE);
        
        c2 = c1.Clone();
        Assert.assertEquals(true, c1.ApiEquals(c2));
        Assert.assertEquals(true, c1.ApiEquals(c1));
        Assert.assertEquals(false, c1.ApiEquals(c3));        

        c1.SetColor(Color.red);
        Assert.assertEquals(c1.GetColor(), Color.red);        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgColor c1;
        MmgColor c2;
        MmgColor c3;
        
        c3 = new MmgColor(Color.YELLOW);        
        c1 = new MmgColor(new MmgColor());
        Assert.assertEquals(c1.GetColor(), Color.WHITE);
        
        c2 = c1.Clone();
        Assert.assertEquals(true, c1.ApiEquals(c2));
        Assert.assertEquals(true, c1.ApiEquals(c1));
        Assert.assertEquals(false, c1.ApiEquals(c3));        
        
        c1.SetColor(Color.red);
        Assert.assertEquals(c1.GetColor(), Color.red);        
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgColor c1;
        MmgColor c2;
        MmgColor c3;
        
        c3 = new MmgColor();        
        c1 = new MmgColor(Color.BLUE);
        Assert.assertEquals(c1.GetColor(), Color.BLUE);
        
        c2 = c1.Clone();
        Assert.assertEquals(true, c1.ApiEquals(c2));
        Assert.assertEquals(true, c1.ApiEquals(c1));
        Assert.assertEquals(false, c1.ApiEquals(c3));        
        
        c1.SetColor(Color.red);
        Assert.assertEquals(c1.GetColor(), Color.red);        
    }    
}