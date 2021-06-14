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
public class MmgColorUnitTest {
    
    public MmgColorUnitTest() {
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
    public void testStaticMembers() {
        //VARS
        Color cr;
        MmgColor c1;
        
        //TEST 1
        cr = Color.WHITE;
        Assert.assertEquals(true, MmgColor.GetWhite().ApiEquals(new MmgColor(cr)));
    
        //TEST 2
        cr = Color.BLACK;
        Assert.assertEquals(true, MmgColor.GetBlack().ApiEquals(new MmgColor(cr)));
        
        //TEST 3
        c1 = new MmgColor(Color.WHITE);
        Assert.assertEquals(true, MmgColor.GetWhite().ApiEquals(new MmgColor(c1)));
    
        //TEST 4
        c1 = new MmgColor(Color.BLACK);
        Assert.assertEquals(true, MmgColor.GetBlack().ApiEquals(new MmgColor(c1)));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testEquals() {
        //VARS
        MmgColor c1;
        MmgColor c2;
        Color cr;
        
        //TEST 1
        cr = Color.GREEN;
        c1 = new MmgColor(cr);
        c2 = new MmgColor(c1);
        Assert.assertEquals(true, c1.ApiEquals(c2));        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testGettersSetters() {
        //VARS
        MmgColor c1;
        Color cr;
        
        //TEST 1
        cr = Color.GREEN;
        c1 = new MmgColor();
        c1.SetColor(cr);
        Assert.assertEquals(cr, c1.GetColor());
        
        //TEST 2
        cr = Color.GRAY;
        c1.SetColor(cr);
        Assert.assertEquals(cr, c1.GetColor());
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testCloning() {
        //VARS
        MmgColor c1;
        MmgColor c2;
        Color cr;
        
        //TEST 1
        cr = Color.PINK;
        c1 = new MmgColor(cr);
        c2 = c1.Clone();
        
        Assert.assertNotSame(c1, c2);
        Assert.assertNotEquals(c1, c2);
        Assert.assertEquals(c1.GetColor(), c2.GetColor());
        Assert.assertTrue(c1.ApiEquals(c2));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testConstructors() {
        //VARS
        MmgColor c1;
        MmgColor c2;
        Color cr;
        
        //TEST 1 PREP
        c1 = new MmgColor();
        cr = Color.WHITE;
        
        //TEST 1
        Assert.assertEquals(cr, c1.GetColor());
    
        //TEST 2 PREP
        cr = Color.BLACK;
        c1 = new MmgColor();
        c1.SetColor(cr);
        c2 = new MmgColor(cr);
        
        //TEST 2
        Assert.assertEquals(cr, c2.GetColor());
    
        //TEST 3 PREP
        cr = Color.RED;
        c1 = new MmgColor(cr);
        c2 = new MmgColor(c1);
        
        //TEST 3
        Assert.assertEquals(cr, c2.GetColor());
    }
}