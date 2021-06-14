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
public class MmgVector2UnitTest_2 {
    
    public MmgVector2UnitTest_2() {
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
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2();
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        

        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgVector2 v0 = MmgVector2.GetOriginVec();
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(v0);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));                

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));                
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());        
    } 
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(0.0d, 0.0d);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));                
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));                
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test4() {
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(0.0d);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));                

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));                
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        Assert.assertEquals(true, v1.ApiEquals(v1));        
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test5() {
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(0.0f, 0.0f);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test6() {
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(0.0f);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test7() {
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(0, 0);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
        
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test8() {
        MmgVector2 v1;
        MmgVector2 v2;
        double[] v3;
        double[] v4 = new double[] {1.1, 1.2};
        double d1 = 2.1d;
        float f1 = 3.24f;
        int i1 = 10;
        
        v1 = new MmgVector2(0);
        Assert.assertEquals(v1.GetX(), 0);
        Assert.assertEquals(v1.GetY(), 0);

        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v3 = v1.GetVector();
        Assert.assertEquals(0.0d, v3[0], 0.001);
        Assert.assertEquals(0.0d, v3[1], 0.001);

        Assert.assertEquals(0, v1.GetX());
        Assert.assertEquals(0.0d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetXFloat(), 0.001);        

        Assert.assertEquals(0, v1.GetY());
        Assert.assertEquals(0.0d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(0.0f, v1.GetYFloat(), 0.001);
        
        v1.SetVector(v4);
        Assert.assertEquals(1, v1.GetX());
        Assert.assertEquals(1.1d, v1.GetXDouble(), 0.001);
        Assert.assertEquals(1.1f, v1.GetXFloat(), 0.001);

        Assert.assertEquals(1, v1.GetY());
        Assert.assertEquals(1.2d, v1.GetYDouble(), 0.001);
        Assert.assertEquals(1.2f, v1.GetYFloat(), 0.001);        

        v1.SetX(i1);
        Assert.assertEquals(10, v1.GetX());
        
        v1.SetX(d1);
        Assert.assertEquals(2.1d, v1.GetXDouble(), 0.001);
        
        v1.SetX(f1);
        Assert.assertEquals(3.24f, v1.GetXFloat(), 0.001);
        
        v1.SetY(i1);
        Assert.assertEquals(10, v1.GetY());
        
        v1.SetY(d1);
        Assert.assertEquals(2.1d, v1.GetYDouble(), 0.001);
        
        v1.SetY(f1);        
        Assert.assertEquals(3.24f, v1.GetYFloat(), 0.001);
        
        v2 = v1.Clone();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneDouble();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));

        v2 = v1.CloneFloat();
        Assert.assertEquals(true, v2.ApiEquals(v1));
        Assert.assertEquals(true, v1.ApiEquals(v2));
        
        v2 = v1.CloneInt();
        Assert.assertEquals(false, v2.ApiEquals(v1));
        Assert.assertEquals(false, v1.ApiEquals(v2));
       
        Assert.assertEquals("MmgVector2: X: " + v1.GetXDouble() + " Y:" + v1.GetYDouble(), v1.ApiToString());        
    }    
}