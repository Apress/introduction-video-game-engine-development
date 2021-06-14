package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry.CfgEntryType;
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
public class MmgCfgFileEntryUnitTest_2 {
    
    public MmgCfgFileEntryUnitTest_2() {
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
        MmgCfgFileEntry m1;
        MmgCfgFileEntry m2;        
        MmgCfgFileEntry m3;                
        
        m3 = new MmgCfgFileEntry();
        m3.cfgType = CfgEntryType.TYPE_DOUBLE;
        m1 = new MmgCfgFileEntry();
        
        Assert.assertEquals(m1.name, null);
        Assert.assertEquals(m1.cfgType, CfgEntryType.NONE);
        Assert.assertEquals(m1.str, null);
        Assert.assertEquals(m1.number, null);
        
        m2 = m1.Clone();
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m1.ApiEquals(m1));
        Assert.assertEquals(false, m3.ApiEquals(m1));
        Assert.assertEquals(m1.ApiToString(), "");        
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgCfgFileEntry m1;
        MmgCfgFileEntry m2;
        MmgCfgFileEntry m3;                
        
        m3 = new MmgCfgFileEntry();     
        m3.cfgType = CfgEntryType.TYPE_DOUBLE;        
        m1 = new MmgCfgFileEntry(new MmgCfgFileEntry());
        
        Assert.assertEquals(m1.name, null);
        Assert.assertEquals(m1.cfgType, CfgEntryType.NONE);
        Assert.assertEquals(m1.str, null);
        Assert.assertEquals(m1.number, null);
        
        m2 = m1.Clone();
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m1.ApiEquals(m1));
        Assert.assertEquals(false, m3.ApiEquals(m1));        
        Assert.assertEquals(m1.ApiToString(), "");
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgCfgFileEntry m1;
        MmgCfgFileEntry m2;        
        MmgCfgFileEntry m3;                
        
        m3 = new MmgCfgFileEntry();  
        m3.cfgType = CfgEntryType.TYPE_DOUBLE;        
        m1 = new MmgCfgFileEntry();
        m1.name = "Test";
        m1.cfgType = CfgEntryType.TYPE_STRING;
        m1.str = "test_string";
        
        Assert.assertEquals(m1.name, "Test");
        Assert.assertEquals(m1.cfgType, CfgEntryType.TYPE_STRING);
        Assert.assertEquals(m1.str, "test_string");
        Assert.assertEquals(m1.number, null);
        
        m2 = m1.Clone();
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m1.ApiEquals(m1));  
        Assert.assertEquals(false, m3.ApiEquals(m1));        
        Assert.assertEquals(m1.ApiToString(), "Test->test_string");        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test4() {
        MmgCfgFileEntry m1;
        MmgCfgFileEntry m2;        
        MmgCfgFileEntry m3;                
        
        m3 = new MmgCfgFileEntry();  
        m3.cfgType = CfgEntryType.TYPE_DOUBLE;        
        m1 = new MmgCfgFileEntry();
        m1.name = "Test";
        m1.cfgType = CfgEntryType.TYPE_DOUBLE;
        m1.str = null;
        m1.number = new Double(1.234); 
        
        Assert.assertEquals(m1.name, "Test");
        Assert.assertEquals(m1.cfgType, CfgEntryType.TYPE_DOUBLE);
        Assert.assertEquals(m1.str, null);
        Assert.assertEquals(m1.number, new Double(1.234));
        Assert.assertEquals(m1.number.doubleValue(), 1.234, 0.001);        
        Assert.assertEquals(m1.number.intValue(), 1);
        
        m2 = m1.Clone();
        Assert.assertEquals(true, m1.ApiEquals(m2));
        Assert.assertEquals(true, m2.ApiEquals(m1));
        Assert.assertEquals(true, m1.ApiEquals(m1));  
        Assert.assertEquals(false, m3.ApiEquals(m1));        
        Assert.assertEquals(m1.ApiToString(), "Test=1.234");        
    }    
}