package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.util.ArrayList;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuItem;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
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
public class MmgMenuContainerUnitTest_2 {
    
    public MmgMenuContainerUnitTest_2() {
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
        MmgMenuContainer m1, m2, m3 = null;
        
        m1 = new MmgMenuContainer();
        m3 = new MmgMenuContainer(new MmgObj(10, 10));
        
        Assert.assertEquals(true, m1.GetContainer() != null);
        Assert.assertEquals(true, m1.GetContainer().size() == 0);
        
        m2 = m1.CloneTyped();
        
        Assert.assertEquals(true, m1.ApiEquals(m1));        
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(false, m3.ApiEquals(m1));
        Assert.assertEquals(false, m1.ApiEquals(m3));               
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgMenuContainer m1, m2, m3 = null;
        
        m1 = new MmgMenuContainer(new MmgObj(20, 20));
        m3 = new MmgMenuContainer(new MmgObj(10, 10));        
        
        Assert.assertEquals(true, m1.GetContainer() != null);
        Assert.assertEquals(true, m1.GetContainer().size() == 0);
        
        m2 = m1.CloneTyped();
        
        Assert.assertEquals(true, m1.ApiEquals(m1));        
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(false, m3.ApiEquals(m1));
        Assert.assertEquals(false, m1.ApiEquals(m3));               
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgMenuContainer m1, m2, m3 = null;
        ArrayList<MmgMenuItem> a = null;
        
        a = new ArrayList();
        a.add(new MmgMenuItem());
        a.add(new MmgMenuItem());
        a.add(new MmgMenuItem());       
        
        m1 = new MmgMenuContainer(new MmgObj(20, 20));
        m3 = new MmgMenuContainer(new MmgObj(10, 10));        
        
        Assert.assertEquals(true, m1.GetContainer() != null);
        Assert.assertEquals(true, m1.GetContainer().size() == 0);
        
        m1.SetContainer(a);
        Assert.assertEquals(true, m1.GetContainer().size() == 3);        
        
        m2 = m1.CloneTyped();
        
        Assert.assertEquals(true, m1.ApiEquals(m1));        
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(false, m3.ApiEquals(m1));
        Assert.assertEquals(false, m1.ApiEquals(m3));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test4() {
        MmgMenuContainer m1, m2, m3 = null;
        ArrayList<MmgMenuItem> a = null;
        
        a = new ArrayList();
        a.add(new MmgMenuItem());
        a.add(new MmgMenuItem());
        a.add(new MmgMenuItem());       
        
        m1 = new MmgMenuContainer(new MmgMenuContainer(new MmgObj(20, 20)));
        m3 = new MmgMenuContainer(new MmgObj(10, 10));        
        
        Assert.assertEquals(true, m1.GetContainer() != null);
        Assert.assertEquals(true, m1.GetContainer().size() == 0);
        
        m1.SetContainer(a);
        Assert.assertEquals(true, m1.GetContainer().size() == 3);        
        
        m2 = m1.CloneTyped();
        
        Assert.assertEquals(true, m1.ApiEquals(m1));        
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(false, m3.ApiEquals(m1));
        Assert.assertEquals(false, m1.ApiEquals(m3));               
    }     
}