package net.middlemind.MmgGameApiJava.MmgUnitTests;

import java.awt.Image;
import java.io.File;
import javax.imageio.ImageIO;
import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgApiUtils;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
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
public class Mmg9SliceUnitTest {
    
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
    
    @SuppressWarnings("UnusedAssignment")
    public void testStaticMembers() {
        //do nothing
    }

    @SuppressWarnings("UnusedAssignment")
    public void testEquals() {
        /*
        //VARS
        MmgBmp b1;
        MmgBmp b2;
        MmgBmp b3;
        MmgObj o1;
        MmgObj o2;
        Image i = null;
        String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
        
        //TEST 1
        b1 = new MmgBmp();
        b2 = new MmgBmp();
        apiEqualityTests(b1, b2);
        
        //TEST 2
        o1 = new MmgObj(10, 10, 50, 50, true, MmgColor.GetBlack());
        o2 = new MmgObj(10, 10, 50, 50, true, MmgColor.GetBlack());
        b1 = new MmgBmp(o1);
        b2 = new MmgBmp(o2);
        apiEqualityTests(b1, b2);
        
        //TEST 3
        b3 = new MmgBmp();
        b1 = new MmgBmp(b3);
        b2 = new MmgBmp(b3);
        apiEqualityTests(b1, b2);
        
        //TEST 4
        try {
            i = ImageIO.read(new File(src));
        }catch(Exception e) {
            MmgApiUtils.wrErr(e);
        }
        
        b1 = new MmgBmp(i);
        b2 = new MmgBmp(i);
        apiEqualityTests(b1, b2);
        
        //TEST 5
        b1 = new MmgBmp(i, null, null, MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
        b2 = new MmgBmp(i, null, null, MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
        apiEqualityTests(b1, b2);
        
        //TEST 6
        b1 = new MmgBmp(i, MmgVector2.GetOriginVec(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
        b2 = new MmgBmp(i, MmgVector2.GetOriginVec(), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
        apiEqualityTests(b1, b2);
        */
    }

    private void testEqualityMmg(Mmg9Slice o1, Mmg9Slice o2) {
        //VARS
        /*
        MmgVector2 o;
        MmgRect s;
        MmgRect d;
        Image i = null;
        String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
        float r;
        
        //TEST 1
        Assert.assertEquals(true, b1.Equals(b2));
        
        //TEST 2
        o = new MmgVector2(20, 20);
        b1.SetOrigin(o);
        Assert.assertEquals(false, b1.Equals(b2));
        b2.SetOrigin(o);
        Assert.assertEquals(true, b1.Equals(b2));
        
        //TEST 3
        o = new MmgVector2(0.15, 0.15);
        b1.SetScaling(o);
        Assert.assertEquals(false, b1.Equals(b2));
        b2.SetScaling(o);
        Assert.assertEquals(true, b1.Equals(b2));
        
        //TEST 4
        s = new MmgRect(0, 0, 20, 20);
        b1.SetSrcRect(s);
        Assert.assertEquals(false, b1.Equals(b2));
        b2.SetSrcRect(s);
        Assert.assertEquals(true, b1.Equals(b2));
        
        //TEST 5
        d = new MmgRect(0, 0, 30, 30);
        b1.SetDstRect(d);
        Assert.assertEquals(false, b1.Equals(b2));
        b2.SetDstRect(d);
        Assert.assertEquals(true, b1.Equals(b2));

        //TEST 6        
        try {
            i = ImageIO.read(new File(src));
        }catch(Exception e) {
            MmgApiUtils.wrErr(e);
        }
        
        b1.SetImage(i);
        Assert.assertEquals(false, b1.Equals(b2));
        b2.SetImage(i);
        Assert.assertEquals(true, b1.Equals(b2));
        
        //TEST 7
        r = 90;
        b1.SetRotation(r);
        Assert.assertEquals(false, b1.Equals(b2));
        b2.SetRotation(r);
        Assert.assertEquals(true, b1.Equals(b2));
        
        //TEST 8 
        b1.DRAW_MODE = MmgBmp.MmgBmpDrawMode.DRAW_BMP_BASIC_CACHE;
        Assert.assertEquals(false, b1.Equals(b2));
        b2.DRAW_MODE = MmgBmp.MmgBmpDrawMode.DRAW_BMP_BASIC_CACHE;
        Assert.assertEquals(true, b1.Equals(b2));
        */
    }
    
    private void testEqualityJava(Mmg9Slice o1, Mmg9Slice o2) {
        
    }
    
    private void testGetAndSet(Mmg9Slice o1, Mmg9Slice o2) {
        
    }    
    
    private void testClone(Mmg9Slice o1, Mmg9Slice o2) {
        
    }    
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testGettersSetters() {
        //VARS
        MmgBmp b1;
        String s;
        MmgRect d;
        Image i = null;        
        String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
        MmgVector2 v;
        float f;
                
        //TEST 1
        b1 = new MmgBmp();        
        s = "T1";
        b1.SetBmpIdStr(s);
        Assert.assertEquals(s, b1.GetBmpIdStr());
        
        //TEST 2
        d = new MmgRect(0, 0, 50, 50);
        b1.SetDstRect(d);
        Assert.assertEquals(true, d.ApiEquals(b1.GetDstRect()));
        
        d = new MmgRect(0, 0, 100, 100);
        b1.SetSrcRect(d);
        Assert.assertEquals(true, d.ApiEquals(b1.GetSrcRect()));        
        
        //TEST 3        
        try {
            i = ImageIO.read(new File(src));
        }catch(Exception e) {
            MmgApiUtils.wrErr(e);
        }
        b1.SetImage(i);
        Assert.assertEquals(i, b1.GetImage());
        Assert.assertEquals(i, b1.GetTexture2D());        
        
        b1.SetTexture2D(i);
        Assert.assertEquals(i, b1.GetImage());
        Assert.assertEquals(i, b1.GetTexture2D());                
        
        //TEST 4
        v = new MmgVector2(100, 100);
        b1.SetOrigin(v);
        Assert.assertEquals(true, v.ApiEquals(b1.GetOrigin()));
        
        v = new MmgVector2(50, 50);
        b1.SetPosition(v);
        Assert.assertEquals(true, v.ApiEquals(b1.GetPosition()));        
        
        v = new MmgVector2(2, 2);
        b1.SetScaling(v);
        Assert.assertEquals(true, v.ApiEquals(b1.GetScaling()));                
        
        //TEST 5
        f = 32.0f;
        b1.SetRotation(f);
        Assert.assertEquals(f, b1.GetRotation(), MmgApiTestSuite.DELTA_D);
        
        int t = 25;
        f = 25.0f;
        b1.SetWidth(t);

        Assert.assertTrue(t == b1.GetUnscaledWidth());
        Assert.assertFalse(t == b1.GetWidth());
        Assert.assertTrue(f * v.GetX() == b1.GetWidth());                
        Assert.assertFalse(f == b1.GetWidthFloat());        
        Assert.assertTrue(f * v.GetXFloat() == b1.GetWidthFloat());
        
        t = 50;
        f = 50.0f;
        b1.SetHeight(t);
        Assert.assertTrue(t == b1.GetUnscaledHeight());
        Assert.assertFalse(t == b1.GetHeight());
        Assert.assertTrue(f * v.GetY() == b1.GetHeight());                        
        Assert.assertFalse(f == b1.GetHeightFloat());        
        Assert.assertTrue(f * v.GetYFloat() == b1.GetHeightFloat());
        
        t = 100;
        Assert.assertTrue(t == b1.GetScaledHeight());        
        
        t = 50;
        Assert.assertTrue(t == b1.GetScaledWidth());                        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testCloning() {
        //VARS
        MmgBmp b1;
        MmgBmp b2;
        Image i = null;        
        String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
        
        b1 = new MmgBmp();
        //TEST 3        
        try {
            i = ImageIO.read(new File(src));
        }catch(Exception e) {
            MmgApiUtils.wrErr(e);
        }
        b1.SetImage(i);
        b1.SetWidth(i.getWidth(null));
        b1.SetHeight(i.getHeight(null));        
        b1.SetMmgColor(MmgColor.GetDarkBlue());
        b1.SetPosition(new MmgVector2(20, 20));
        b1.SetRotation(90.0f);
        b1.SetOrigin(MmgVector2.GetOriginVec());
        b1.SetScaling(new MmgVector2(2, 2));        
        b1.SetDstRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
        b1.SetSrcRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));        
        
        b2 = b1.CloneTyped();        
        Assert.assertTrue(b2.ApiEquals(b1));
        Assert.assertEquals(b2.GetWidth(), b1.GetWidth());
        Assert.assertEquals(b2.GetHeight(), b1.GetHeight());      
        Assert.assertEquals(b2.GetImage(), b1.GetImage());
        Assert.assertEquals(b2.GetTexture2D(), b1.GetTexture2D());        
        Assert.assertTrue(b2.GetMmgColor().ApiEquals(b1.GetMmgColor()));
        Assert.assertTrue(b2.GetPosition().ApiEquals(b1.GetPosition()));
        Assert.assertFalse((b2.GetBmpId() == b1.GetBmpId()));
        Assert.assertFalse((b2.GetBmpIdStr().equals(b1.GetBmpIdStr())));
        Assert.assertTrue(b2.GetRotation() == b1.GetRotation());
        Assert.assertTrue(b2.GetOrigin().ApiEquals(b1.GetOrigin()));        
        Assert.assertTrue(b2.GetSrcRect().ApiEquals(b1.GetSrcRect()));        
        Assert.assertTrue(b2.GetDstRect().ApiEquals(b1.GetDstRect()));
        Assert.assertTrue(b1.GetScaledHeight() == b2.GetScaledHeight());
        Assert.assertTrue(b1.GetScaledWidth() == b2.GetScaledWidth());
        Assert.assertTrue(b1.GetUnscaledHeight() == b2.GetUnscaledHeight());
        Assert.assertTrue(b1.GetUnscaledWidth() == b2.GetUnscaledWidth());        
        Assert.assertTrue(b1.GetHeightFloat() == b2.GetHeightFloat());
        Assert.assertTrue(b1.GetWidthFloat() == b2.GetWidthFloat());        
        Assert.assertNotEquals(b2, b1);        
        b1.SetPosition(new MmgVector2(100, 100));
        Assert.assertFalse(b1.GetPosition().ApiEquals(b2.GetPosition()));
        
        b1 = new MmgBmp();
        b1.SetImage(i);
        b1.SetWidth(i.getWidth(null));
        b1.SetHeight(i.getHeight(null));        
        b1.SetMmgColor(MmgColor.GetDarkBlue());
        b1.SetPosition(new MmgVector2(20, 20));
        b1.SetRotation(90.0f);
        b1.SetOrigin(MmgVector2.GetOriginVec());
        b1.SetScaling(new MmgVector2(2, 2));
        b1.SetDstRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
        b1.SetSrcRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));                
        
        b2 = (MmgBmp)b1.Clone();
        Assert.assertTrue(b2.ApiEquals(b1));        
        Assert.assertEquals(b2.GetWidth(), b1.GetWidth());
        Assert.assertEquals(b2.GetWidth(), b1.GetWidth());        
        Assert.assertEquals(b2.GetImage(), b1.GetImage());
        Assert.assertEquals(b2.GetTexture2D(), b1.GetTexture2D());        
        Assert.assertTrue(b2.GetMmgColor().ApiEquals(b1.GetMmgColor()));
        Assert.assertTrue(b2.GetPosition().ApiEquals(b1.GetPosition())); 
        Assert.assertFalse((b2.GetBmpId() == b1.GetBmpId()));
        Assert.assertFalse((b2.GetBmpIdStr().equals(b1.GetBmpIdStr())));
        Assert.assertTrue(b2.GetRotation() == b1.GetRotation());
        Assert.assertTrue(b2.GetOrigin().ApiEquals(b1.GetOrigin()));        
        Assert.assertTrue(b2.GetSrcRect().ApiEquals(b1.GetSrcRect()));        
        Assert.assertTrue(b2.GetDstRect().ApiEquals(b1.GetDstRect()));
        Assert.assertTrue(b1.GetScaledHeight() == b2.GetScaledHeight());
        Assert.assertTrue(b1.GetScaledWidth() == b2.GetScaledWidth());
        Assert.assertTrue(b1.GetUnscaledHeight() == b2.GetUnscaledHeight());
        Assert.assertTrue(b1.GetUnscaledWidth() == b2.GetUnscaledWidth());
        Assert.assertTrue(b1.GetHeightFloat() == b2.GetHeightFloat());
        Assert.assertTrue(b1.GetWidthFloat() == b2.GetWidthFloat()); 
        Assert.assertNotEquals(b2, b1);        
        b1.SetPosition(new MmgVector2(100, 100));
        Assert.assertFalse(b1.GetPosition().ApiEquals(b2.GetPosition()));
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testConstructors() {
        MmgBmp b1;
        MmgBmp b2;
        
        b1 = new MmgBmp();
        Assert.assertTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
        Assert.assertTrue(b1.GetScaling().ApiEquals(new MmgVector2(1, 1)));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
        Assert.assertNull(b1.GetImage());
        Assert.assertNull(b1.GetTexture2D());
        Assert.assertTrue(b1.GetRotation() == 0f);
        Assert.assertTrue(b1.GetHeight() == 0);
        Assert.assertTrue(b1.GetHeightFloat() == 0.0f);
        Assert.assertTrue(b1.GetWidth() == 0);
        Assert.assertTrue(b1.GetWidthFloat() == 0.0f);        
        Assert.assertTrue(b1.GetUnscaledHeight() == 0);
        Assert.assertTrue(b1.GetUnscaledWidth() == 0);
        Assert.assertTrue(b1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
        Assert.assertTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));         
        
        MmgObj obj = new MmgObj();
        obj.SetWidth(20);
        obj.SetHeight(20);
        b1 = new MmgBmp(obj);
        Assert.assertTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
        Assert.assertTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertTrue(b1.GetScaling().ApiEquals(new MmgVector2(1, 1)));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
        Assert.assertNull(b1.GetImage());
        Assert.assertNull(b1.GetTexture2D());
        Assert.assertTrue(b1.GetRotation() == 0f);
        Assert.assertTrue(b1.GetHeight() == 20);
        Assert.assertTrue(b1.GetHeightFloat() == 20.0f);
        Assert.assertTrue(b1.GetWidth() == 20);
        Assert.assertTrue(b1.GetWidthFloat() == 20.0f);        
        Assert.assertTrue(b1.GetUnscaledHeight() == 20);
        Assert.assertTrue(b1.GetUnscaledWidth() == 20);
        Assert.assertTrue(b1.GetMmgColor().ApiEquals(MmgColor.GetWhite()));
        Assert.assertTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec())); 
        
        b2 = new MmgBmp(b1);
        Assert.assertTrue(b2.ApiEquals(b1));        
        Assert.assertEquals(b2.GetWidth(), b1.GetWidth());
        Assert.assertEquals(b2.GetImage(), b1.GetImage());
        Assert.assertNull(b1.GetTexture2D());        
        Assert.assertTrue(b2.GetMmgColor().ApiEquals(b1.GetMmgColor()));
        Assert.assertTrue(b2.GetPosition().ApiEquals(b1.GetPosition())); 
        Assert.assertFalse((b2.GetBmpId() == b1.GetBmpId()));
        Assert.assertFalse((b2.GetBmpIdStr().equals(b1.GetBmpIdStr())));
        Assert.assertTrue(b2.GetRotation() == b1.GetRotation());
        Assert.assertTrue(b2.GetOrigin().ApiEquals(b1.GetOrigin()));
        Assert.assertTrue(b2.GetScaling().ApiEquals(b1.GetScaling()));
        Assert.assertTrue(b2.GetSrcRect().ApiEquals(b1.GetSrcRect()));        
        Assert.assertTrue(b2.GetDstRect().ApiEquals(b1.GetDstRect()));
        Assert.assertTrue(b1.GetScaledHeight() == b2.GetScaledHeight());
        Assert.assertTrue(b1.GetScaledWidth() == b2.GetScaledWidth());
        Assert.assertTrue(b1.GetUnscaledHeight() == b2.GetUnscaledHeight());
        Assert.assertTrue(b1.GetUnscaledWidth() == b2.GetUnscaledWidth());
        Assert.assertTrue(b1.GetHeightFloat() == b2.GetHeightFloat());
        Assert.assertTrue(b1.GetWidthFloat() == b2.GetWidthFloat()); 
        Assert.assertNotEquals(b2, b1);        
        b1.SetPosition(new MmgVector2(100, 100));
        Assert.assertFalse(b1.GetPosition().ApiEquals(b2.GetPosition()));
        
        Image i = null;        
        String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
        
        try {
            i = ImageIO.read(new File(src));
        }catch(Exception e) {
            MmgApiUtils.wrErr(e);
        }
        b1 = new MmgBmp(i);
        Assert.assertTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
        Assert.assertTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));        
        Assert.assertTrue(b1.GetScaling().ApiEquals(new MmgVector2(1, 1)));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth())));
        Assert.assertTrue(b1.GetDstRect() == null);
        Assert.assertNotNull(b1.GetImage());
        Assert.assertTrue(b1.GetRotation() == 0f);
        Assert.assertTrue(b1.GetHeight() == 64);
        Assert.assertTrue(b1.GetHeightFloat() == 64.0f);
        Assert.assertTrue(b1.GetWidth() == 64);
        Assert.assertTrue(b1.GetWidthFloat() == 64.0f);        
        Assert.assertTrue(b1.GetUnscaledHeight() == 64);
        Assert.assertTrue(b1.GetUnscaledWidth() == 64);
        Assert.assertTrue(b1.GetMmgColor() == null);
        Assert.assertTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec())); 
        
        b1 = new MmgBmp(i, MmgRect.GetUnitRect(), new MmgRect(0, 0, 2, 2), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 45.0f);
        Assert.assertTrue(b1.GetOrigin().ApiEquals(new MmgVector2(0, 0)));
        Assert.assertTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, 1, 1)));
        Assert.assertTrue(b1.GetDstRect().ApiEquals(new MmgRect(0, 0, 2, 2)));
        Assert.assertNotNull(b1.GetImage());
        Assert.assertTrue(b1.GetRotation() == 45.0f);
        Assert.assertTrue(b1.GetHeight() == 64);
        Assert.assertTrue(b1.GetHeightFloat() == 64.0f);
        Assert.assertTrue(b1.GetWidth() == 64);
        Assert.assertTrue(b1.GetWidthFloat() == 64.0f);        
        Assert.assertTrue(b1.GetUnscaledHeight() == 64);
        Assert.assertTrue(b1.GetUnscaledWidth() == 64);
        Assert.assertTrue(b1.GetMmgColor() == null);
        Assert.assertTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));         
    
        b1 = new MmgBmp(i, MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), MmgVector2.GetUnitVec(), 45.0f);
        Assert.assertTrue(b1.GetOrigin().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertTrue(b1.GetScaling().ApiEquals(MmgVector2.GetUnitVec()));
        Assert.assertTrue(b1.GetSrcRect().ApiEquals(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth())));
        Assert.assertTrue(b1.GetDstRect() == null);
        Assert.assertNotNull(b1.GetImage());
        Assert.assertTrue(b1.GetRotation() == 45.0f);
        Assert.assertTrue(b1.GetHeight() == 64);
        Assert.assertTrue(b1.GetHeightFloat() == 64.0f);
        Assert.assertTrue(b1.GetWidth() == 64);
        Assert.assertTrue(b1.GetWidthFloat() == 64.0f);        
        Assert.assertTrue(b1.GetUnscaledHeight() == 64);
        Assert.assertTrue(b1.GetUnscaledWidth() == 64);
        Assert.assertTrue(b1.GetMmgColor() == null);
        Assert.assertTrue(b1.GetPosition().ApiEquals(MmgVector2.GetOriginVec()));
    }    
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void testScaling() {
        //VARS
        MmgBmp b1;
        Image i = null;        
        String src = "/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/cfg/drawable/auto_load/a_btn.png";
        
        b1 = new MmgBmp();
        //TEST 3        
        try {
            i = ImageIO.read(new File(src));
        }catch(Exception e) {
            MmgApiUtils.wrErr(e);
        }
        b1.SetImage(i);
        b1.SetWidth(i.getWidth(null));
        b1.SetHeight(i.getHeight(null));        
        b1.SetMmgColor(MmgColor.GetDarkBlue());
        b1.SetPosition(new MmgVector2(20, 20));
        b1.SetRotation(90.0f);
        b1.SetScaling(new MmgVector2(2, 2));
        b1.SetOrigin(MmgVector2.GetOriginVec());
        b1.SetDstRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
        b1.SetSrcRect(new MmgRect(0, 0, b1.GetHeight(), b1.GetWidth()));
        
        //System.err.println("B1.ScaledHeight: " + b1.GetScaledHeight() + " ScalingX: " + b1.GetScaling().GetXDouble() + " GetHeight: " + b1.GetHeight());
        Assert.assertTrue(b1.GetScaledHeight() == (64 * 2));
        Assert.assertTrue(b1.GetScaledWidth() == (64 * 2));
        Assert.assertTrue(b1.GetUnscaledHeight() == 64);
        Assert.assertTrue(b1.GetUnscaledWidth() == 64);
        Assert.assertTrue(b1.GetHeightFloat() == 128.0f);
        Assert.assertTrue(b1.GetWidthFloat() == 128.0f);
        b1.SetPosition(new MmgVector2(100, 100));
        Assert.assertTrue(b1.GetPosition().ApiEquals(new MmgVector2(100, 100)));        
    }
}