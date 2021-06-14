package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.awt.Rectangle;
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
public class MmgRectUnitTest {
    
    public MmgRectUnitTest() {
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
        MmgRect r1;
        
        //PREP TEST 1
        r1 = new MmgRect(0, 0, 1, 1);
        
        //TEST 1
        Assert.assertEquals(true, r1.ApiEquals(MmgRect.GetUnitRect()));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testEquals() {
        //VARS
        int x;
        int y;
        int w;
        int h;
        MmgRect r1;
        MmgRect r2;
        
        //PREP TEST 1
        x = 10;
        y = 12;
        w = 25;
        h = 20;
        r1 = new MmgRect(x, y, w, h);
        r2 = new MmgRect(x, y, w, h);
        
        //TEST 1
        Assert.assertEquals(true, r1.ApiEquals(r2));
        Assert.assertNotSame(r1, r2);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testGettersSetters() {
        //VARS
        int l;
        int t;
        int r;
        int b;
        int w;
        int h;
        MmgRect r1;
        Rectangle rc;
        MmgVector2 v1;
        String s;
        
        //PREP TEST 1
        l = 5;
        t = 5;
        r = 23;
        b = 47;
        w = r - l;
        h = b - t;
        r1 = new MmgRect();
        rc = new Rectangle(l, t, w, h);
        
        //TEST - Rect
        r1.SetRect(rc);
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
        
        //PREP TEST 2
        l = 1;
        t = 1;
        r = l + w;
        b = t + h;
        v1 = new MmgVector2(l, t);
        
        //TEST - Position
        r1.SetPosition(v1);
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
        
        //PREP TEST 3
        w = 12;
        r = l + w;
        
        //TEST - Width
        r1.SetWidth(w);
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
        
        //PREP TEST 4
        h = 15;
        b = t + h;
        
        //TEST - Height
        r1.SetHeight(h);
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
        
        //PREP TEST 5
        s = "MmgRect: L: " + r1.GetLeft() + " R: " + r1.GetRight() + " T: " + r1.GetTop() + " B: " + r1.GetBottom() + ", W: " + r1.GetWidth() + " H: " + r1.GetHeight();
        Assert.assertEquals(s, r1.ApiToString());
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testCloning() {
        //VARS
        int l;
        int t;
        int r;
        int b;
        int w;
        int h;
        MmgRect r1;
        MmgRect r2;
        
        //PREP TEST 1
        l = 5;
        t = 5;
        r = 23;
        b = 47;
        w = r - l;
        h = b - t;
        r1 = new MmgRect(l, t, b, r);
        r2 = r1.Clone();
        
        Assert.assertEquals(r1.GetLeft(), r2.GetLeft());
        Assert.assertEquals(r1.GetTop(), r2.GetTop());
        Assert.assertEquals(r1.GetBottom(), r2.GetBottom());
        Assert.assertEquals(r1.GetRight(), r2.GetRight());
        Assert.assertEquals(r1.GetWidth(), r2.GetWidth());
        Assert.assertEquals(r1.GetHeight(), r2.GetHeight());
        Assert.assertEquals(true, r1.ApiEquals(r2));
        Assert.assertNotSame(r1, r2);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testConstructors() {
        //VARS
        int l;
        int t;
        int r;
        int b;
        int w;
        int h;
        MmgRect r1;
        MmgRect r2;
        MmgVector2 v1;
        
        //PREP TEST 1
        l = 0;
        t = 0;
        r = 1;
        b = 1;
        w = 1;
        h = 1;
        r1 = new MmgRect();
        
        //TEST 1
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
        
        //PREP TEST 2
        l = 5; 
        t = 6;
        r = 10;
        b = 12;
        w = r - l;
        h = b - t;
        r1 = new MmgRect(l, t, b, r);
        r2 = new MmgRect(r1);
        
        //TEST 2
        Assert.assertEquals(l, r2.GetLeft());
        Assert.assertEquals(t, r2.GetTop());
        Assert.assertEquals(b, r2.GetBottom());
        Assert.assertEquals(r, r2.GetRight());
        Assert.assertEquals(w, r2.GetWidth());
        Assert.assertEquals(h, r2.GetHeight());
        
        //PREP TEST 3
        l = 0;
        t = 0;
        r = 15;
        b = 24;
        w = r - l;
        h = b - t;
        r1 = new MmgRect(l, t, b, r);
        
        //TEST 3
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
        
        //PREP TEST 4
        l = -5;
        t = -5;
        r = 15;
        b = 20;
        w = r - l;
        h = b - t;
        v1 = new MmgVector2(l, t);
        r1 = new MmgRect(v1, w, h);
        
        //TEST 4
        Assert.assertEquals(l, r1.GetLeft());
        Assert.assertEquals(t, r1.GetTop());
        Assert.assertEquals(b, r1.GetBottom());
        Assert.assertEquals(r, r1.GetRight());
        Assert.assertEquals(w, r1.GetWidth());
        Assert.assertEquals(h, r1.GetHeight());
    }
}