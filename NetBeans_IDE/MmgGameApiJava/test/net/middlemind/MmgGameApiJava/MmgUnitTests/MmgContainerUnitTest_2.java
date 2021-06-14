package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.util.ArrayList;
import net.middlemind.MmgGameApiJava.MmgBase.MmgContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
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
public class MmgContainerUnitTest_2 {
    
    public MmgContainerUnitTest_2() {
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
        MmgContainer c1, c2, c3;
        MmgObj o1, o2, o3;
        Object[] a1;
        
        o1 = new MmgObj();
        o2 = new MmgObj();
        c1 = new MmgContainer();
        c2 = new MmgContainer();        
        
        Assert.assertEquals(MmgContainer.INITIAL_SIZE, 10);
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetIsDirty());
        
        c1.SetPosition(MmgVector2Int.GetUnitVec());
        
        Assert.assertEquals(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));
    
        c1.Add(o1);
        c1.Add(o1);        

        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.AddAt(2, o2);        

        Assert.assertEquals(c1.GetCount(), 3);
        
        o3 = c1.GetAt(2);        

        Assert.assertEquals(o3, o2);
        
        o3 = c1.RemoveAt(2);

        Assert.assertEquals(o3, o2);
        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.Remove(o1);
        
        Assert.assertEquals(c1.GetCount(), 1);
        
        a1 = c1.GetArray();
        
        Assert.assertEquals(a1.length, c1.GetCount());
        for(int i = 0; i < a1.length; i++) {
            Assert.assertEquals(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
        }

        //Restore has parent value after shared reference set it to false
        c1.GetAt(0).SetHasParent(true);
        c1.GetAt(0).SetParent(c1);

        c3 = c1.CloneTyped();
                
        Assert.assertEquals(true, c1.ApiEquals(c3));
        Assert.assertEquals(false, c1.ApiEquals(c2));
        
        c1.SetIsDirty(true);
        
        Assert.assertEquals(c1.GetIsDirty(), true);
        
        MmgObj obj1 = (MmgObj)c1;
        Assert.assertEquals(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
        Assert.assertEquals(true, obj1.ApiEquals(c1));
        
        ArrayList<MmgObj> container = c1.GetContainer();
        c1.Clear();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetContainer().equals(container));
    
        MmgObj m1 = c1.Clone();
        MmgObj m2 = new MmgObj();
        Assert.assertEquals(true, ((MmgObj)c1).ApiEquals(m1));
        Assert.assertEquals(false, ((MmgObj)c1).ApiEquals(m2));
        
        c1.Add(o1);        
        c1.Add(o2);        
        
        Assert.assertEquals(c1.GetCount(), 2);        
        
        c1.Reset();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(false, c1.GetContainer().equals(container));

        c1.Add(o1);        
        c1.Add(o2);         
        o3 = c1.GetChildAt(0);
        
        Assert.assertEquals(true, o3.ApiEquals(o1));
        Assert.assertEquals(true, o3.equals(o1));  
        
        c1.SetPosition(10, 10);
        o3.SetPosition(10, 10);
        
        Assert.assertEquals(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
        Assert.assertEquals(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgContainer c1, c2, c3;
        MmgObj o1, o2, o3;
        Object[] a1;
        
        o1 = new MmgObj();
        o2 = new MmgObj();
        c1 = new MmgContainer(new MmgObj());
        c2 = new MmgContainer();        
        
        Assert.assertEquals(MmgContainer.INITIAL_SIZE, 10);
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetIsDirty());
        
        c1.SetPosition(MmgVector2Int.GetUnitVec());
        
        Assert.assertEquals(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));
    
        c1.Add(o1);
        c1.Add(o1);        

        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.AddAt(2, o2);        

        Assert.assertEquals(c1.GetCount(), 3);
        
        o3 = c1.GetAt(2);        

        Assert.assertEquals(o3, o2);
        
        o3 = c1.RemoveAt(2);

        Assert.assertEquals(o3, o2);
        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.Remove(o1);
        
        Assert.assertEquals(c1.GetCount(), 1);
        
        a1 = c1.GetArray();
        
        Assert.assertEquals(a1.length, c1.GetCount());
        for(int i = 0; i < a1.length; i++) {
            Assert.assertEquals(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
        }

        //Restore has parent value after shared reference set it to false
        c1.GetAt(0).SetHasParent(true);
        c1.GetAt(0).SetParent(c1);

        c3 = c1.CloneTyped();
                
        Assert.assertEquals(true, c1.ApiEquals(c3));
        Assert.assertEquals(false, c1.ApiEquals(c2));
        
        c1.SetIsDirty(true);
        
        Assert.assertEquals(c1.GetIsDirty(), true);
        
        MmgObj obj1 = (MmgObj)c1;
        Assert.assertEquals(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
        Assert.assertEquals(true, obj1.ApiEquals(c1));
        
        ArrayList<MmgObj> container = c1.GetContainer();
        c1.Clear();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetContainer().equals(container));
    
        MmgObj m1 = c1.Clone();
        MmgObj m2 = new MmgObj();
        Assert.assertEquals(true, ((MmgObj)c1).ApiEquals(m1));
        Assert.assertEquals(false, ((MmgObj)c1).ApiEquals(m2));
        
        c1.Add(o1);        
        c1.Add(o2);        
        
        Assert.assertEquals(c1.GetCount(), 2);        
        
        c1.Reset();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(false, c1.GetContainer().equals(container));

        c1.Add(o1);        
        c1.Add(o2);         
        o3 = c1.GetChildAt(0);
        
        Assert.assertEquals(true, o3.ApiEquals(o1));
        Assert.assertEquals(true, o3.equals(o1));  
        
        c1.SetPosition(10, 10);
        o3.SetPosition(10, 10);
        
        Assert.assertEquals(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
        Assert.assertEquals(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgContainer c1, c2, c3;
        MmgObj o1, o2, o3;
        Object[] a1;
        
        ArrayList<MmgObj> objects = new ArrayList<MmgObj>();
        
        o1 = new MmgObj();
        o2 = new MmgObj();
        c1 = new MmgContainer(objects);
        c2 = new MmgContainer();        
        
        Assert.assertEquals(MmgContainer.INITIAL_SIZE, 10);
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetIsDirty());
        
        c1.SetPosition(MmgVector2Int.GetUnitVec());
        
        Assert.assertEquals(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));
    
        c1.Add(o1);
        c1.Add(o1);        

        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.AddAt(2, o2);        

        Assert.assertEquals(c1.GetCount(), 3);
        
        o3 = c1.GetAt(2);        

        Assert.assertEquals(o3, o2);
        
        o3 = c1.RemoveAt(2);

        Assert.assertEquals(o3, o2);
        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.Remove(o1);
        
        Assert.assertEquals(c1.GetCount(), 1);
        
        a1 = c1.GetArray();
        
        Assert.assertEquals(a1.length, c1.GetCount());
        for(int i = 0; i < a1.length; i++) {
            Assert.assertEquals(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
        }

        //Restore has parent value after shared reference set it to false
        c1.GetAt(0).SetHasParent(true);
        c1.GetAt(0).SetParent(c1);

        c3 = c1.CloneTyped();
                
        Assert.assertEquals(true, c1.ApiEquals(c3));
        Assert.assertEquals(false, c1.ApiEquals(c2));
        
        c1.SetIsDirty(true);
        
        Assert.assertEquals(c1.GetIsDirty(), true);
        
        MmgObj obj1 = (MmgObj)c1;
        Assert.assertEquals(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
        Assert.assertEquals(true, obj1.ApiEquals(c1));
        
        ArrayList<MmgObj> container = c1.GetContainer();
        c1.Clear();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetContainer().equals(container));
    
        MmgObj m1 = c1.Clone();
        MmgObj m2 = new MmgObj();
        Assert.assertEquals(true, ((MmgObj)c1).ApiEquals(m1));
        Assert.assertEquals(false, ((MmgObj)c1).ApiEquals(m2));
        
        c1.Add(o1);        
        c1.Add(o2);        
        
        Assert.assertEquals(c1.GetCount(), 2);        
        
        c1.Reset();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(false, c1.GetContainer().equals(container));

        c1.Add(o1);        
        c1.Add(o2);         
        o3 = c1.GetChildAt(0);
        
        Assert.assertEquals(true, o3.ApiEquals(o1));
        Assert.assertEquals(true, o3.equals(o1));  
        
        c1.SetPosition(10, 10);
        o3.SetPosition(10, 10);
        
        Assert.assertEquals(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
        Assert.assertEquals(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test4() {
        MmgContainer c1, c2, c3;
        MmgObj o1, o2, o3;
        Object[] a1;
        
        ArrayList<MmgObj> objects = new ArrayList<MmgObj>();
        
        o1 = new MmgObj();
        o2 = new MmgObj();
        c1 = new MmgContainer(new MmgContainer());
        c2 = new MmgContainer();        
        
        Assert.assertEquals(MmgContainer.INITIAL_SIZE, 10);
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetIsDirty());
        
        c1.SetPosition(MmgVector2Int.GetUnitVec());
        
        Assert.assertEquals(true, c1.GetPosition().ApiEquals(MmgVector2Int.GetUnitVec()));
    
        c1.Add(o1);
        c1.Add(o1);        

        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.AddAt(2, o2);        

        Assert.assertEquals(c1.GetCount(), 3);
        
        o3 = c1.GetAt(2);        

        Assert.assertEquals(o3, o2);
        
        o3 = c1.RemoveAt(2);

        Assert.assertEquals(o3, o2);
        Assert.assertEquals(c1.GetCount(), 2);
        
        c1.Remove(o1);
        
        Assert.assertEquals(c1.GetCount(), 1);
        
        a1 = c1.GetArray();
        
        Assert.assertEquals(a1.length, c1.GetCount());
        for(int i = 0; i < a1.length; i++) {
            Assert.assertEquals(true, ((MmgObj)a1[i]).ApiEquals(c1.GetAt(i)));
        }

        //Restore has parent value after shared reference set it to false
        c1.GetAt(0).SetHasParent(true);
        c1.GetAt(0).SetParent(c1);

        c3 = c1.CloneTyped();
                
        Assert.assertEquals(true, c1.ApiEquals(c3));
        Assert.assertEquals(false, c1.ApiEquals(c2));
        
        c1.SetIsDirty(true);
        
        Assert.assertEquals(c1.GetIsDirty(), true);
        
        MmgObj obj1 = (MmgObj)c1;
        Assert.assertEquals(true, MmgVector2Int.GetUnitVec().ApiEquals((MmgVector2Int)obj1.GetPosition()));
        Assert.assertEquals(true, obj1.ApiEquals(c1));
        
        ArrayList<MmgObj> container = c1.GetContainer();
        c1.Clear();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(true, c1.GetContainer().equals(container));
    
        MmgObj m1 = c1.Clone();
        MmgObj m2 = new MmgObj();
        Assert.assertEquals(true, ((MmgObj)c1).ApiEquals(m1));
        Assert.assertEquals(false, ((MmgObj)c1).ApiEquals(m2));
        
        c1.Add(o1);        
        c1.Add(o2);        
        
        Assert.assertEquals(c1.GetCount(), 2);        
        
        c1.Reset();
        
        Assert.assertEquals(c1.GetCount(), 0);
        Assert.assertEquals(false, c1.GetContainer().equals(container));

        c1.Add(o1);        
        c1.Add(o2);         
        o3 = c1.GetChildAt(0);
        
        Assert.assertEquals(true, o3.ApiEquals(o1));
        Assert.assertEquals(true, o3.equals(o1));  
        
        c1.SetPosition(10, 10);
        o3.SetPosition(10, 10);
        
        Assert.assertEquals(true, c1.GetChildPosAbsolute(0).ApiEquals(new MmgVector2Int(10, 10)));
        Assert.assertEquals(true, c1.GetChildPosRelative(0).ApiEquals(new MmgVector2Int(0, 0)));
    }    
}