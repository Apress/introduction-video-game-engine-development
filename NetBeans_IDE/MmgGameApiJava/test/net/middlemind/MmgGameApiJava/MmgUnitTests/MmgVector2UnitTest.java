package net.middlemind.MmgGameApiJava.MmgUnitTests;

import org.junit.Assert;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 *
 * @author Victor G. Brusca, Middlemind Games
 */
public class MmgVector2UnitTest {
    
    public MmgVector2UnitTest() {
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
        MmgVector2 v1 = new MmgVector2(0, 0);
        MmgVector2 v2 = new MmgVector2(1, 1);
        
        Assert.assertEquals(true, v1.ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, v2.ApiEquals(MmgVector2.GetUnitVec()));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testEquals() {
        //VARS
        MmgVector2 v1;
        MmgVector2 v2;
        double xd;
        double yd;       
        
        //PREP TEST 1
        xd = 12.234;
        yd = 3.4546;
        v1 = new MmgVector2(xd, yd);
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertNotSame(v1, v2);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testGettersSetters() {
        //VARS
        MmgVector2 v1;
        double xd;
        double yd;
        float xf;
        float yf;
        int xi;
        int yi;
        double[] d;
        String s;
        
        //PREP TEST 1
        xd = 4.1;
        yd = 5.1;
        xf = 4.1f;
        yf = 5.1f;
        xi = 4;
        yi = 5;
        v1 = new MmgVector2();

        //TEST GET DOUBLE
        v1.SetX(xd);
        v1.SetY(yd);
        Assert.assertEquals(xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        
        //TEST GET FLOAT
        Assert.assertEquals((float)xd, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals((float)yd, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        v1.SetX(xf);
        v1.SetY(yf);
        Assert.assertEquals(xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);        
    
        //TEST GET INT
        Assert.assertEquals((int)xd, v1.GetX());
        Assert.assertEquals((int)yd, v1.GetY());
        v1.SetX(xi);
        v1.SetY(yi);
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        
        xd = 13.567;
        yd = 2.1234;
        d = new double[] { xd, yd };
        v1.SetVector(d);
        Assert.assertEquals(xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertArrayEquals(d, v1.GetVector(), MmgApiTestSuite.DELTA_D);
        
        s = "MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble();
        Assert.assertEquals(s, v1.ApiToString());
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testCloning() {
        //VARS
        MmgVector2 v1;
        MmgVector2 v2;
        double xd;
        double yd;
        
        //PREP TEST 1
        xd = 4.1;
        yd = 5.1;
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        v1 = new MmgVector2(new double[] { xd, yd });
        v2 = v1.Clone();
        
        //TEST 1
        Assert.assertEquals(v1.GetXDouble(), v2.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(v1.GetYDouble(), v2.GetYDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertNotSame(v1, v2);
    
        //TEST 2
        v2 = v1.CloneDouble();
        Assert.assertEquals(v1.GetXDouble(), v2.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(v1.GetYDouble(), v2.GetYDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertNotSame(v1, v2);
    
        //TEST 3
        v2 = v1.CloneFloat();
        Assert.assertEquals(v1.GetXFloat(), v2.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(v1.GetYFloat(), v2.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(false, v1.ApiEquals(v2));
        Assert.assertNotSame(v1, v2);
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testConstructors() {
        //VARS
        MmgVector2 v1;
        MmgVector2 v2;
        float xf;
        float yf;
        int xi;
        int yi;
        double xd;
        double yd;
        
        //PREP TEST 1
        xi = 0;
        yi = 0;
        xf = 0f;
        yf = 0f;
        xd = 0.0;
        yd = 0.0;
        v1 = new MmgVector2();
        
        //TEST 1
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        Assert.assertEquals(xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        
        //PREP TEST 2
        xi = 1;
        yi = 2;
        xf = 1f;
        yf = 2f;
        xd = 1.0;
        yd = 2.0;
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        v1 = new MmgVector2(v2);
        
        //TEST 2
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        Assert.assertEquals(xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        
        //PREP TEST 3
        xi = 4;
        yi = 5;
        xf = 4f;
        yf = 5f;
        xd = 4.0;
        yd = 5.0;
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        v1 = new MmgVector2(new double[] { xd, yd });
        
        //TEST 3
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        Assert.assertEquals(xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        
        //PREP TEST 4
        xi = 6;
        yi = 7;
        xf = 6f;
        yf = 7f;
        xd = 6.0;
        yd = 7.0;
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        v1 = new MmgVector2(xd, yd);
        
        //TEST 4
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        Assert.assertEquals(xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        
        //PREP TEST 5
        xi = 6;
        yi = 7;
        xf = 6.1f;
        yf = 7.1f;
        xd = 6.1;
        yd = 7.1;
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        v1 = new MmgVector2(xf, yf);
        
        //TEST 5
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        Assert.assertEquals(xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals(yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals((double)xf, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals((double)yf, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
        
        //PREP TEST 6
        xi = 16;
        yi = 17;
        xf = 16.11f;
        yf = 17.11f;
        xd = 16.11;
        yd = 17.11;
        v2 = new MmgVector2();
        v2.SetX(xd);
        v2.SetY(yd);
        v1 = new MmgVector2(xi, yi);
        
        //TEST 6
        Assert.assertEquals(xi, v1.GetX());
        Assert.assertEquals(yi, v1.GetY());
        Assert.assertEquals((float)(int)xf, v1.GetXFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals((float)(int)yf, v1.GetYFloat(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals((double)(int)xd, v1.GetXDouble(), MmgApiTestSuite.DELTA_D);
        Assert.assertEquals((double)(int)yd, v1.GetYDouble(), MmgApiTestSuite.DELTA_D);
    }
}