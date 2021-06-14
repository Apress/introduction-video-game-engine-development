package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2Int;
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
public class MmgObjUnitTest_2 {
    
    public MmgObjUnitTest_2() {
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
        MmgObj o1, o2, o3 = null;
        
        o1 = new MmgObj();
        o3 = new MmgObj();
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, o1.GetWidth() == 0);
        Assert.assertEquals(true, o1.GetHeight() == 0);
        Assert.assertEquals(true, o1.GetIsVisible() == true);
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
        Assert.assertEquals(true, o1.GetHasParent() == false);
        Assert.assertEquals(true, o1.GetParent() == null);
        Assert.assertEquals(true, o1.GetName().equals(""));
        Assert.assertEquals(true, o1.GetId().equals(""));
        
        o1.SetHasParent(true);
        o1.SetHeight(100);
        o1.SetId("Test String");
        o1.SetIsVisible(false);
        
        Assert.assertEquals(true, o1.GetHasParent() == true);
        Assert.assertEquals(true, o1.GetHeight() == 100);
        Assert.assertEquals(true, o1.GetId().equals("Test String"));
        Assert.assertEquals(true, o1.GetIsVisible() == false);
        
        o1.SetMmgColor(MmgColor.GetBlackCat());
        o1.SetName("Test Name");
        o1.SetParent(new MmgObj());
        
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetParent().ApiEquals(new MmgObj()));

        o1.SetPosition(50, 50);
        o1.SetWidth(100);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
        Assert.assertEquals(true, o1.GetWidth() == 100);
        
        o1.SetX(75);
        o1.SetY(75);
        
        Assert.assertEquals(true, o1.GetX() == 75);
        Assert.assertEquals(true, o1.GetY() == 75);
        
        o2 = o1.CloneTyped();
        
        Assert.assertEquals(true, o1.ApiEquals(o1));                
        Assert.assertEquals(true, o1.ApiEquals(o2));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(false, o3.ApiEquals(o1));
        Assert.assertEquals(false, o1.ApiEquals(o3));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgObj o1, o2, o3 = null;
        
        o1 = new MmgObj("Test Name", "Test Id");
        o3 = new MmgObj();
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, o1.GetWidth() == 0);
        Assert.assertEquals(true, o1.GetHeight() == 0);
        Assert.assertEquals(true, o1.GetIsVisible() == true);
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
        Assert.assertEquals(true, o1.GetHasParent() == false);
        Assert.assertEquals(true, o1.GetParent() == null);
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetId().equals("Test Id"));
        
        o1.SetHasParent(true);
        o1.SetHeight(100);
        o1.SetId("Test String");
        o1.SetIsVisible(false);
        
        Assert.assertEquals(true, o1.GetHasParent() == true);
        Assert.assertEquals(true, o1.GetHeight() == 100);
        Assert.assertEquals(true, o1.GetId().equals("Test String"));
        Assert.assertEquals(true, o1.GetIsVisible() == false);
        
        o1.SetMmgColor(MmgColor.GetBlackCat());
        o1.SetName("Test Name");
        o1.SetParent(new MmgObj());
        
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetParent().ApiEquals(new MmgObj()));

        o1.SetPosition(50, 50);
        o1.SetWidth(100);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
        Assert.assertEquals(true, o1.GetWidth() == 100);
        
        o1.SetX(75);
        o1.SetY(75);
        
        Assert.assertEquals(true, o1.GetX() == 75);
        Assert.assertEquals(true, o1.GetY() == 75);
        
        o2 = o1.CloneTyped();
        
        Assert.assertEquals(true, o1.ApiEquals(o1));                
        Assert.assertEquals(true, o1.ApiEquals(o2));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(false, o3.ApiEquals(o1));
        Assert.assertEquals(false, o1.ApiEquals(o3));               
    } 

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgObj o1, o2, o3 = null;
        
        o1 = new MmgObj(3, 3, 30, 30, true, MmgColor.GetCyan());
        o3 = new MmgObj();
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(3, 3)));
        Assert.assertEquals(true, o1.GetWidth() == 30);
        Assert.assertEquals(true, o1.GetHeight() == 30);
        Assert.assertEquals(true, o1.GetIsVisible() == true);
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetCyan()));
        Assert.assertEquals(true, o1.GetHasParent() == false);
        Assert.assertEquals(true, o1.GetParent() == null);
        Assert.assertEquals(true, o1.GetName().equals(""));
        Assert.assertEquals(true, o1.GetId().equals(""));
        
        o1.SetHasParent(true);
        o1.SetHeight(100);
        o1.SetId("Test String");
        o1.SetIsVisible(false);
        
        Assert.assertEquals(true, o1.GetHasParent() == true);
        Assert.assertEquals(true, o1.GetHeight() == 100);
        Assert.assertEquals(true, o1.GetId().equals("Test String"));
        Assert.assertEquals(true, o1.GetIsVisible() == false);
        
        o1.SetMmgColor(MmgColor.GetBlackCat());
        o1.SetName("Test Name");
        o1.SetParent(new MmgObj());
        
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetParent().ApiEquals(new MmgObj()));

        o1.SetPosition(50, 50);
        o1.SetWidth(100);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
        Assert.assertEquals(true, o1.GetWidth() == 100);
        
        o1.SetX(75);
        o1.SetY(75);
        
        Assert.assertEquals(true, o1.GetX() == 75);
        Assert.assertEquals(true, o1.GetY() == 75);
        
        o2 = o1.CloneTyped();
        
        Assert.assertEquals(true, o1.ApiEquals(o1));                
        Assert.assertEquals(true, o1.ApiEquals(o2));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(false, o3.ApiEquals(o1));
        Assert.assertEquals(false, o1.ApiEquals(o3));               
    }   
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test4() {
        MmgObj o1, o2, o3 = null;
        
        o1 = new MmgObj(25, 25);
        o3 = new MmgObj(15, 15);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
        Assert.assertEquals(true, o1.GetWidth() == 25);
        Assert.assertEquals(true, o1.GetHeight() == 25);
        Assert.assertEquals(true, o1.GetIsVisible() == true);
        Assert.assertEquals(true, o1.GetMmgColor() == null);
        Assert.assertEquals(true, o1.GetHasParent() == false);
        Assert.assertEquals(true, o1.GetParent() == null);
        Assert.assertEquals(true, o1.GetName().equals(""));
        Assert.assertEquals(true, o1.GetId().equals(""));
        
        o1.SetHasParent(true);
        o1.SetHeight(100);
        o1.SetId("Test String");
        o1.SetIsVisible(false);
        
        Assert.assertEquals(true, o1.GetHasParent() == true);
        Assert.assertEquals(true, o1.GetHeight() == 100);
        Assert.assertEquals(true, o1.GetId().equals("Test String"));
        Assert.assertEquals(true, o1.GetIsVisible() == false);
        
        o1.SetMmgColor(MmgColor.GetBlackCat());
        o1.SetName("Test Name");
        o1.SetParent(new MmgObj());
        
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetParent().ApiEquals(new MmgObj()));

        o1.SetPosition(50, 50);
        o1.SetWidth(100);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
        Assert.assertEquals(true, o1.GetWidth() == 100);
        
        o1.SetX(75);
        o1.SetY(75);
        
        Assert.assertEquals(true, o1.GetX() == 75);
        Assert.assertEquals(true, o1.GetY() == 75);
        
        o2 = o1.CloneTyped();
        
        Assert.assertEquals(true, o1.ApiEquals(o1));                
        Assert.assertEquals(true, o1.ApiEquals(o2));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(false, o3.ApiEquals(o1));
        Assert.assertEquals(false, o1.ApiEquals(o3));               
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test5() {
        MmgObj o1, o2, o3 = null;
        
        o1 = new MmgObj(4, 4, 25, 25, true, MmgColor.GetGray(), "Test Name", "Test Id");
        o3 = new MmgObj(15, 15);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2Int(4, 4)));
        Assert.assertEquals(true, o1.GetWidth() == 25);
        Assert.assertEquals(true, o1.GetHeight() == 25);
        Assert.assertEquals(true, o1.GetIsVisible() == true);
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetGray()));
        Assert.assertEquals(true, o1.GetHasParent() == false);
        Assert.assertEquals(true, o1.GetParent() == null);
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetId().equals("Test Id"));
        
        o1.SetHasParent(true);
        o1.SetHeight(100);
        o1.SetId("Test String");
        o1.SetIsVisible(false);
        
        Assert.assertEquals(true, o1.GetHasParent() == true);
        Assert.assertEquals(true, o1.GetHeight() == 100);
        Assert.assertEquals(true, o1.GetId().equals("Test String"));
        Assert.assertEquals(true, o1.GetIsVisible() == false);
        
        o1.SetMmgColor(MmgColor.GetBlackCat());
        o1.SetName("Test Name");
        o1.SetParent(new MmgObj());
        
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetParent().ApiEquals(new MmgObj()));

        o1.SetPosition(50, 50);
        o1.SetWidth(100);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
        Assert.assertEquals(true, o1.GetWidth() == 100);
        
        o1.SetX(75);
        o1.SetY(75);
        
        Assert.assertEquals(true, o1.GetX() == 75);
        Assert.assertEquals(true, o1.GetY() == 75);
        
        o2 = o1.CloneTyped();
        
        Assert.assertEquals(true, o1.ApiEquals(o1));                
        Assert.assertEquals(true, o1.ApiEquals(o2));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(false, o3.ApiEquals(o1));
        Assert.assertEquals(false, o1.ApiEquals(o3));               
    }     
    
   @Test
    @SuppressWarnings("UnusedAssignment")
    public void test6() {
        MmgObj o1, o2, o3 = null;
        
        o1 = new MmgObj(new MmgVector2(4, 4), 25, 25, true, MmgColor.GetGray(), "Test Name", "Test Id");
        o3 = new MmgObj(15, 15);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2Int(4, 4)));
        Assert.assertEquals(true, o1.GetWidth() == 25);
        Assert.assertEquals(true, o1.GetHeight() == 25);
        Assert.assertEquals(true, o1.GetIsVisible() == true);
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetGray()));
        Assert.assertEquals(true, o1.GetHasParent() == false);
        Assert.assertEquals(true, o1.GetParent() == null);
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetId().equals("Test Id"));
        
        o1.SetHasParent(true);
        o1.SetHeight(100);
        o1.SetId("Test String");
        o1.SetIsVisible(false);
        
        Assert.assertEquals(true, o1.GetHasParent() == true);
        Assert.assertEquals(true, o1.GetHeight() == 100);
        Assert.assertEquals(true, o1.GetId().equals("Test String"));
        Assert.assertEquals(true, o1.GetIsVisible() == false);
        
        o1.SetMmgColor(MmgColor.GetBlackCat());
        o1.SetName("Test Name");
        o1.SetParent(new MmgObj());
        
        Assert.assertEquals(true, o1.GetMmgColor().ApiEquals(MmgColor.GetBlackCat()));
        Assert.assertEquals(true, o1.GetName().equals("Test Name"));
        Assert.assertEquals(true, o1.GetParent().ApiEquals(new MmgObj()));

        o1.SetPosition(50, 50);
        o1.SetWidth(100);
        
        Assert.assertEquals(true, o1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
        Assert.assertEquals(true, o1.GetWidth() == 100);
        
        o1.SetX(75);
        o1.SetY(75);
        
        Assert.assertEquals(true, o1.GetX() == 75);
        Assert.assertEquals(true, o1.GetY() == 75);
        
        o2 = o1.CloneTyped();
        
        Assert.assertEquals(true, o1.ApiEquals(o1));                
        Assert.assertEquals(true, o1.ApiEquals(o2));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(true, o2.ApiEquals(o1));
        Assert.assertEquals(false, o3.ApiEquals(o1));
        Assert.assertEquals(false, o1.ApiEquals(o3));               
    }         
}