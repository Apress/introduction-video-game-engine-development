package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgTextField;
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
public class MmgTextFieldUnitTest_2 {
    
    public MmgTextFieldUnitTest_2() {
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
        MmgBmp b1, b2, b3, b4, b5 = null;
        MmgFont f1, f2, f3 = null;
        MmgTextField t1, t2, t3 = null;
        MmgVector2Int v1 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");                
        
        f1 = MmgFontData.GetMmgFontBold();
        f2 = MmgFontData.GetMmgFontItalic();
        f3 = MmgFontData.GetMmgFontNorm();
        
        Mmg9Slice n1, n2 = null;
        
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
        b5 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");        

        n1 = new Mmg9Slice(10, b4, 200, 200, MmgVector2.GetUnitVec());
        n2 = new Mmg9Slice(12, b5, 300, 300);                
        
        t1 = new MmgTextField(b1, f1, 100, 100, 4, 20);
        t3 = new MmgTextField(b2, f2, 300, 300, 12, 20);

        Assert.assertEquals(true, t1.GetBgroundSrc().ApiEquals(b1));
        Assert.assertEquals(true, t1.GetBgroundSrc().equals(b1));
        Assert.assertEquals(true, t1.GetFont().ApiEquals(f1));
        Assert.assertEquals(true, t1.GetFont().equals(f1));
        Assert.assertEquals(true, t1.GetPadding() == 4);
        Assert.assertEquals(true, t1.GetDisplayChars() == 20);
        Assert.assertEquals(true, t1.GetWidth() == 100);
        Assert.assertEquals(true, t1.GetHeight() == 100);
        Assert.assertEquals(true, t1.GetMaxLength() == MmgTextField.DEFAULT_MAX_LENGTH);
        Assert.assertEquals(true, t1.GetTextFieldString().equals(""));
        
        t1.SetBground(n1);
        t1.SetBgroundSrc(b3);
        t1.SetDisplayChars(24);
        
        Assert.assertEquals(true, t1.GetBground().ApiEquals(n1));
        Assert.assertEquals(true, t1.GetBground().equals(n1));
        Assert.assertEquals(true, t1.GetBgroundSrc().ApiEquals(b3));
        Assert.assertEquals(true, t1.GetBgroundSrc().equals(b3));
        Assert.assertEquals(true, t1.GetDisplayChars() == 24);

        t1.SetFont(f3);
        t1.SetFontHeight(15);
        t1.SetIsDirty(true);
        t1.SetMaxLength(30);
        t1.SetMaxLengthOn(true);
        
        Assert.assertEquals(true, t1.GetFont().ApiEquals(f3));
        Assert.assertEquals(true, t1.GetFont().equals(f3));
        Assert.assertEquals(true, t1.GetMaxLength() == 30);
        Assert.assertEquals(true, t1.GetMaxLengthOn() == true);
        
        v1 = new MmgVector2Int(32, 32);
        t1.SetPadding(8);
        t1.SetPosition(v1);
        t1.SetTextFieldString("Test textfield string");
        
        Assert.assertEquals(true, t1.GetPadding() == 8);
        Assert.assertEquals(true, t1.GetPosition().ApiEquals(v1));
        Assert.assertEquals(true, t1.GetPosition().equals(v1));
        Assert.assertEquals(true, t1.GetTextFieldString().equals("Test textfield string"));        

        t1.SetX(88);
        t1.SetY(88);
        v1 = new MmgVector2Int(88, 88);
        Assert.assertEquals(true, t1.GetPosition().ApiEquals(v1));
        
        t2 = t1.CloneTyped();
        
        Assert.assertEquals(true, t1.ApiEquals(t1));                
        Assert.assertEquals(true, t1.ApiEquals(t2));
        Assert.assertEquals(true, t2.ApiEquals(t1));
        Assert.assertEquals(true, t2.ApiEquals(t1));
        Assert.assertEquals(false, t3.ApiEquals(t1));
        Assert.assertEquals(false, t1.ApiEquals(t3));
        
        Assert.assertEquals(true, MmgTextField.DEFAULT_MAX_LENGTH == 20);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID == 1);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_TYPE == 0);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_CURSOR_BLINK_RATE_MS == 350l);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_CURSOR.equals("_"));
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_9_SLICE_OFFSET == MmgHelper.ScaleValue(16));
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgBmp b1, b2, b3, b4, b5 = null;
        MmgFont f1, f2, f3 = null;
        MmgTextField t1, t2, t3 = null;
        MmgVector2Int v1 = null;
        
        b1 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_1.png");
        b2 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_2.png");
        b3 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.APP_IMAGE_RESOURCE_ROOT_DIR + "soldier_frame_3.png");                
        
        f1 = MmgFontData.GetMmgFontBold();
        f2 = MmgFontData.GetMmgFontItalic();
        f3 = MmgFontData.GetMmgFontNorm();
        
        Mmg9Slice n1, n2 = null;
        
        b4 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/popup_window_base.png");
        b5 = MmgHelper.GetBasicBmp(MmgUnitTestSettings.RESOURCE_ROOT_DIR + "drawable/auto_load/game_title.png");        

        n1 = new Mmg9Slice(10, b4, 200, 200, MmgVector2.GetUnitVec());
        n2 = new Mmg9Slice(12, b5, 300, 300);                
        
        t1 = new MmgTextField(new MmgTextField(b1, f1, 100, 100, 4, 20));
        t3 = new MmgTextField(b2, f2, 300, 300, 12, 20);

        Assert.assertEquals(true, t1.GetBgroundSrc().ApiEquals(b1));
        Assert.assertEquals(false, t1.GetBgroundSrc().equals(b1));
        Assert.assertEquals(false, t1.GetFont().ApiEquals(f1));
        Assert.assertEquals(false, t1.GetFont().equals(f1));
        Assert.assertEquals(true, t1.GetPadding() == 4);
        Assert.assertEquals(true, t1.GetDisplayChars() == 20);
        Assert.assertEquals(true, t1.GetWidth() == 100);
        Assert.assertEquals(true, t1.GetHeight() == 100);
        Assert.assertEquals(true, t1.GetMaxLength() == MmgTextField.DEFAULT_MAX_LENGTH);
        Assert.assertEquals(true, t1.GetTextFieldString().equals(""));
        
        t1.SetBground(n1);
        t1.SetBgroundSrc(b3);
        t1.SetDisplayChars(24);
        
        Assert.assertEquals(true, t1.GetBground().ApiEquals(n1));
        Assert.assertEquals(true, t1.GetBground().equals(n1));
        Assert.assertEquals(true, t1.GetBgroundSrc().ApiEquals(b3));
        Assert.assertEquals(true, t1.GetBgroundSrc().equals(b3));
        Assert.assertEquals(true, t1.GetDisplayChars() == 24);

        t1.SetFont(f3);
        t1.SetFontHeight(15);
        t1.SetIsDirty(true);
        t1.SetMaxLength(30);
        t1.SetMaxLengthOn(true);
        
        Assert.assertEquals(true, t1.GetFont().ApiEquals(f3));
        Assert.assertEquals(true, t1.GetFont().equals(f3));
        Assert.assertEquals(true, t1.GetMaxLength() == 30);
        Assert.assertEquals(true, t1.GetMaxLengthOn() == true);
        
        v1 = new MmgVector2Int(32, 32);
        t1.SetPadding(8);
        t1.SetPosition(v1);
        t1.SetTextFieldString("Test textfield string");
        
        Assert.assertEquals(true, t1.GetPadding() == 8);
        Assert.assertEquals(true, t1.GetPosition().ApiEquals(v1));
        Assert.assertEquals(true, t1.GetPosition().equals(v1));
        Assert.assertEquals(true, t1.GetTextFieldString().equals("Test textfield string"));        

        t1.SetX(88);
        t1.SetY(88);
        v1 = new MmgVector2Int(88, 88);
        Assert.assertEquals(true, t1.GetPosition().ApiEquals(v1));
        
        t2 = t1.CloneTyped();
        
        Assert.assertEquals(true, t1.ApiEquals(t1));                
        Assert.assertEquals(true, t1.ApiEquals(t2));
        Assert.assertEquals(true, t2.ApiEquals(t1));
        Assert.assertEquals(true, t2.ApiEquals(t1));
        Assert.assertEquals(false, t3.ApiEquals(t1));
        Assert.assertEquals(false, t1.ApiEquals(t3));
        
        Assert.assertEquals(true, MmgTextField.DEFAULT_MAX_LENGTH == 20);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_EVENT_ID == 1);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_MAX_LENGTH_ERROR_TYPE == 0);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_CURSOR_BLINK_RATE_MS == 350l);
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_CURSOR.equals("_"));
        Assert.assertEquals(true, MmgTextField.TEXT_FIELD_9_SLICE_OFFSET == MmgHelper.ScaleValue(16));        
    }  
}