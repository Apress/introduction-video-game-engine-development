package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSizeTween;
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
public class MmgSizeTweenUnitTest_2 {
    
    public MmgSizeTweenUnitTest_2() {
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
        float f1, f2, f3 = 0.0f;
        MmgVector2 vs1, vs2, vs3 = null;
        MmgVector2 ve1, ve2, ve3 = null;        
        MmgSizeTween p1, p2, p3 = null;
        MmgVector2 v = null;
        
        o1 = new MmgObj(10, 10);
        o2 = new MmgObj(20, 20);
        o3 = new MmgObj(30, 30);

        f1 = 1000.0f;
        f2 = 1500.0f;
        f3 = 2000.0f;
        
        vs1 = new MmgVector2(10, 10);
        vs2 = new MmgVector2(20, 20);
        vs3 = new MmgVector2(30, 30);
        
        ve1 = new MmgVector2(110, 110);
        ve2 = new MmgVector2(120, 120);
        ve3 = new MmgVector2(130, 130);  
        
        p1 = new MmgSizeTween(o1, f1, vs1, ve1);
        p3 = new MmgSizeTween(o3, f3, vs3, ve3);
        
        Assert.assertEquals(true, p1.GetSubj().ApiEquals(o1));
        Assert.assertEquals(true, p1.GetSubj().equals(o1));        
    
        v = new MmgVector2(110 - 10, 110 - 10);        
        Assert.assertEquals(true, p1.GetPixelSizeToChange().ApiEquals(v));
        Assert.assertEquals(true, p1.GetMsTimeToChange() == f1);
        
        float iX = (100 / f1);
        float iY = (100 / f1);
        
        Assert.assertEquals(true, p1.GetPixelsPerMsToChangeX() == iX);
        Assert.assertEquals(true, p1.GetPixelsPerMsToChangeY() == iY);
        Assert.assertEquals(true, p1.GetStartSize().ApiEquals(vs1));
        Assert.assertEquals(true, p1.GetStartSize().equals(vs1));
        Assert.assertEquals(true, p1.GetFinishSize().ApiEquals(ve1));
        Assert.assertEquals(true, p1.GetFinishSize().equals(ve1));
        Assert.assertEquals(false, p1.GetPosition().ApiEquals(vs1));
        Assert.assertEquals(false, p1.GetPosition().equals(vs1));
        Assert.assertEquals(true, p1.GetDirStartToFinish() == true);
        Assert.assertEquals(true, p1.GetAtStart() == true);
        Assert.assertEquals(true, p1.GetAtFinish() == false);
        Assert.assertEquals(true, p1.GetChanging() == false);

        p1.SetAtFinish(true);
        p1.SetAtStart(false);
        p1.SetDirStartToFinish(false);
        p1.SetFinishEventId(3);
        
        Assert.assertEquals(true, p1.GetAtFinish() == true);
        Assert.assertEquals(true, p1.GetAtStart() == false);
        Assert.assertEquals(true, p1.GetDirStartToFinish() == false);        
        Assert.assertEquals(true, p1.GetFinishEventId() == 3);

        p1.SetFinishSize(ve2);
        
        Assert.assertEquals(true, p1.GetFinishSize().ApiEquals(ve2));
        Assert.assertEquals(true, p1.GetFinishSize().equals(ve2));        

        p1.SetHeight(250);
        p1.SetChanging(true);
        p1.SetMsStartChange(333l);
        p1.SetMsTimeToChange(5.0f);
        
        Assert.assertEquals(true, p1.GetHeight() == 250);
        Assert.assertEquals(true, p1.GetChanging() == true);
        Assert.assertEquals(true, p1.GetMsStartChange() == 333l);
        Assert.assertEquals(true, p1.GetMsTimeToChange() == 5.0f);
    
        v = new MmgVector2(175, 175);
        p1.SetPixelSizeToChange(v);
        p1.SetPixelsPerMsToChangeX(222f);
        p1.SetPixelsPerMsToChangeY(111f);

        Assert.assertEquals(true, p1.GetPixelSizeToChange().ApiEquals(v));
        Assert.assertEquals(true, p1.GetPixelSizeToChange().equals(v));
        Assert.assertEquals(p1.GetPixelsPerMsToChangeX(), 222f, 0.01f);
        Assert.assertEquals(p1.GetPixelsPerMsToChangeY(), 111f, 0.01f);

        v = new MmgVector2(150, 150);        
        p1.SetPosition(v);
        
        Assert.assertEquals(true, p1.GetPosition().ApiEquals(v));
        Assert.assertEquals(true, p1.GetPosition().equals(v));        

        p1.SetStartEventId(5);
        
        Assert.assertEquals(true, p1.GetStartEventId() == 5);
        
        p1.SetStartSize(v);
        
        Assert.assertEquals(true, p1.GetStartSize().ApiEquals(v));
        Assert.assertEquals(true, p1.GetStartSize().equals(v));                

        p1.SetSubj(o3);
        
        Assert.assertEquals(true, p1.GetSubj().ApiEquals(o3));
        Assert.assertEquals(true, p1.GetSubj().equals(o3));                        

        p1.SetWidth(200);
        
        Assert.assertEquals(true, p1.GetWidth() == 200);

        p1.SetX(32);
        p1.SetY(64);
        
        Assert.assertEquals(true, p1.GetX() == 32);
        Assert.assertEquals(true, p1.GetY() == 64);

        p2 = p1.CloneTyped();
        
        Assert.assertEquals(true, p1.ApiEquals(p1));                
        Assert.assertEquals(true, p1.ApiEquals(p2));
        Assert.assertEquals(true, p2.ApiEquals(p1));
        Assert.assertEquals(true, p2.ApiEquals(p1));
        Assert.assertEquals(false, p3.ApiEquals(p1));
        Assert.assertEquals(false, p1.ApiEquals(p3));              
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgObj o1, o2, o3 = null;
        float f1, f2, f3 = 0.0f;
        MmgVector2 vs1, vs2, vs3 = null;
        MmgVector2 ve1, ve2, ve3 = null;        
        MmgSizeTween p1, p2, p3 = null;
        MmgVector2 v = null;
        
        o1 = new MmgObj(10, 10);
        o2 = new MmgObj(20, 20);
        o3 = new MmgObj(30, 30);

        f1 = 1000.0f;
        f2 = 1500.0f;
        f3 = 2000.0f;
        
        vs1 = new MmgVector2(10, 10);
        vs2 = new MmgVector2(20, 20);
        vs3 = new MmgVector2(30, 30);
        
        ve1 = new MmgVector2(110, 110);
        ve2 = new MmgVector2(120, 120);
        ve3 = new MmgVector2(130, 130);  
        
        p1 = new MmgSizeTween(new MmgSizeTween(o1, f1, vs1, ve1));
        p3 = new MmgSizeTween(o3, f3, vs3, ve3);
        
        Assert.assertEquals(true, p1.GetSubj().ApiEquals(o1));
        Assert.assertEquals(false, p1.GetSubj().equals(o1));        
    
        v = new MmgVector2(110 - 10, 110 - 10);        
        Assert.assertEquals(true, p1.GetPixelSizeToChange().ApiEquals(v));
        Assert.assertEquals(true, p1.GetMsTimeToChange() == f1);
        
        float iX = (100 / f1);
        float iY = (100 / f1);
        
        Assert.assertEquals(true, p1.GetPixelsPerMsToChangeX() == iX);
        Assert.assertEquals(true, p1.GetPixelsPerMsToChangeY() == iY);
        Assert.assertEquals(true, p1.GetStartSize().ApiEquals(vs1));
        Assert.assertEquals(false, p1.GetStartSize().equals(vs1));
        Assert.assertEquals(true, p1.GetFinishSize().ApiEquals(ve1));
        Assert.assertEquals(false, p1.GetFinishSize().equals(ve1));
        Assert.assertEquals(false, p1.GetPosition().ApiEquals(vs1));
        Assert.assertEquals(false, p1.GetPosition().equals(vs1));
        Assert.assertEquals(true, p1.GetDirStartToFinish() == true);
        Assert.assertEquals(true, p1.GetAtStart() == true);
        Assert.assertEquals(true, p1.GetAtFinish() == false);
        Assert.assertEquals(true, p1.GetChanging() == false);

        p1.SetAtFinish(true);
        p1.SetAtStart(false);
        p1.SetDirStartToFinish(false);
        p1.SetFinishEventId(3);
        
        Assert.assertEquals(true, p1.GetAtFinish() == true);
        Assert.assertEquals(true, p1.GetAtStart() == false);
        Assert.assertEquals(true, p1.GetDirStartToFinish() == false);        
        Assert.assertEquals(true, p1.GetFinishEventId() == 3);

        p1.SetFinishSize(ve2);
        
        Assert.assertEquals(true, p1.GetFinishSize().ApiEquals(ve2));
        Assert.assertEquals(true, p1.GetFinishSize().equals(ve2));        

        p1.SetHeight(250);
        p1.SetChanging(true);
        p1.SetMsStartChange(333l);
        p1.SetMsTimeToChange(5.0f);
        
        Assert.assertEquals(true, p1.GetHeight() == 250);
        Assert.assertEquals(true, p1.GetChanging() == true);
        Assert.assertEquals(true, p1.GetMsStartChange() == 333l);
        Assert.assertEquals(true, p1.GetMsTimeToChange() == 5.0f);
    
        v = new MmgVector2(175, 175);
        p1.SetPixelSizeToChange(v);
        p1.SetPixelsPerMsToChangeX(222f);
        p1.SetPixelsPerMsToChangeY(111f);

        Assert.assertEquals(true, p1.GetPixelSizeToChange().ApiEquals(v));
        Assert.assertEquals(true, p1.GetPixelSizeToChange().equals(v));
        Assert.assertEquals(p1.GetPixelsPerMsToChangeX(), 222f, 0.01f);
        Assert.assertEquals(p1.GetPixelsPerMsToChangeY(), 111f, 0.01f);

        v = new MmgVector2(150, 150);        
        p1.SetPosition(v);
        
        Assert.assertEquals(true, p1.GetPosition().ApiEquals(v));
        Assert.assertEquals(true, p1.GetPosition().equals(v));        

        p1.SetStartEventId(5);
        
        Assert.assertEquals(true, p1.GetStartEventId() == 5);
        
        p1.SetStartSize(v);
        
        Assert.assertEquals(true, p1.GetStartSize().ApiEquals(v));
        Assert.assertEquals(true, p1.GetStartSize().equals(v));                

        p1.SetSubj(o3);
        
        Assert.assertEquals(true, p1.GetSubj().ApiEquals(o3));
        Assert.assertEquals(true, p1.GetSubj().equals(o3));                        

        p1.SetWidth(200);
        
        Assert.assertEquals(true, p1.GetWidth() == 200);

        p1.SetX(32);
        p1.SetY(64);
        
        Assert.assertEquals(true, p1.GetX() == 32);
        Assert.assertEquals(true, p1.GetY() == 64);

        p2 = p1.CloneTyped();
        
        Assert.assertEquals(true, p1.ApiEquals(p1));                
        Assert.assertEquals(true, p1.ApiEquals(p2));
        Assert.assertEquals(true, p2.ApiEquals(p1));
        Assert.assertEquals(true, p2.ApiEquals(p1));
        Assert.assertEquals(false, p3.ApiEquals(p1));
        Assert.assertEquals(false, p1.ApiEquals(p3));             
    }    
}