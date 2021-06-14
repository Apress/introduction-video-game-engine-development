package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScrollVert;
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
public class MmgScrollVertUnitTest_2 {
    
    public MmgScrollVertUnitTest_2() {
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
        MmgBmp b1, b2, b3 = null;
        MmgScrollVert s1, s2, s3 = null;
        MmgRect r1 = null;
        
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE == 1);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID == 0);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_SCROLL_UP_EVENT_ID == 1);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_SCROLL_DOWN_EVENT_ID == 2);
        Assert.assertEquals(true, MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX == false);        
            
        b1 = MmgHelper.CreateFilledBmp(20, 20, MmgColor.GetGreen());
        b2 = MmgHelper.CreateFilledBmp(100, 100, MmgColor.GetGreen());
        b3 = MmgHelper.CreateFilledBmp(150, 150, MmgColor.GetGreen());        
        s1 = new MmgScrollVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 20, 20, 10);
        s3 = new MmgScrollVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 32, 32, 12);

        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetViewPort().equals(b1));
        Assert.assertEquals(true, s1.GetViewPortRect().GetHeight() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetWidth() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetViewPortRect().GetTop() == 0);
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b2));
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetHeight() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetWidth() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetTop() == 0);        

        Assert.assertEquals(true, s1.GetScrollBarWidth() == 20);
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetBlack()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetBlack()));        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonHeight() == 20);
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == MmgHelper.ScaleValue(15));
        Assert.assertEquals(true, s1.GetIntervalY() == 10);

        s1.SetIntervalY(12);
        s1.SetIsDirty(true);
        s1.SetOffsetY(8);
        s1.SetPosition(50, 50);
        
        Assert.assertEquals(true, s1.GetIntervalY() == 12);
        Assert.assertEquals(true, s1.GetIsDirty() == true);
        Assert.assertEquals(true, s1.GetOffsetY() == 8);
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
    
        s1.SetScrollBarCenterButton(b3);
        s1.SetScrollBarCenterButtonColor(MmgColor.GetRed());
        s1.SetScrollBarCenterButtonHeight(32);
        
        Assert.assertEquals(true, s1.GetScrollBarCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarCenterButton().equals(b3));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetRed()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonHeight() == 32);
        
        r1 = new MmgRect(0, 0, 16, 16);
        s1.SetScrollBarCenterButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarColor(MmgColor.GetDarkBlue());
        
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetDarkBlue()));
        
        s1.SetScrollBarWidth(32);
        
        Assert.assertEquals(true, s1.GetScrollBarWidth() == 32);
        
        s1.SetScrollBarUpButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarUpButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarUpButton().equals(b1));

        s1.SetScrollBarUpButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarUpButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarUpDownButtonHeight(32);
        
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == 32);

        s1.SetScrollBarDownButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarDownButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarDownButton().equals(b1));        
    
        s1.SetScrollBarDownButtonRect(r1);

        Assert.assertEquals(true, s1.GetScrollBarDownButtonRect().ApiEquals(r1));        
    
        s1.SetScrollBarVisible(false);
        
        Assert.assertEquals(true, s1.GetScrollBarVisible() == false);
        
        s1.SetScrollPane(b3);
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b3));

        s1.SetScrollPaneRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollPaneRect().ApiEquals(r1));
        Assert.assertEquals(true, s1.GetScrollPaneRect().equals(r1));

        s1.SetViewPort(b3);
        
        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetViewPort().equals(b3));

        s1.SetViewPortRect(r1);
        
        Assert.assertEquals(true, s1.GetViewPortRect().ApiEquals(r1));
        Assert.assertEquals(true, s1.GetViewPortRect().equals(r1)); 
        
        s1.SetHeightDiff(200);
        s1.SetHeightDiffPrct(0.5d);
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetHeightDiff() == 200);
        Assert.assertEquals(s1.GetHeightDiffPrct(), 0.5d, 0.001);
        Assert.assertEquals(true, s1.GetX() == 50);
        Assert.assertEquals(true, s1.GetY() == 50);

        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));        
    }
    
    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test2() {
        MmgBmp b1, b2, b3 = null;
        MmgScrollVert s1, s2, s3 = null;
        MmgRect r1 = null;
        
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE == 1);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID == 0);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_SCROLL_UP_EVENT_ID == 1);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_SCROLL_DOWN_EVENT_ID == 2);
        Assert.assertEquals(true, MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX == false);        
            
        b1 = MmgHelper.CreateFilledBmp(20, 20, MmgColor.GetGreen());
        b2 = MmgHelper.CreateFilledBmp(100, 100, MmgColor.GetGreen());
        b3 = MmgHelper.CreateFilledBmp(150, 150, MmgColor.GetGreen());        
        s1 = new MmgScrollVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 10);
        s3 = new MmgScrollVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 32, 32, 12);

        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetViewPort().equals(b1));
        Assert.assertEquals(true, s1.GetViewPortRect().GetHeight() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetWidth() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetViewPortRect().GetTop() == 0);
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b2));
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetHeight() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetWidth() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetTop() == 0);        

        Assert.assertEquals(true, s1.GetScrollBarWidth() == MmgHelper.ScaleValue(10));
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetBlack()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetBlack()));        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonHeight() == MmgHelper.ScaleValue(30));
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == MmgHelper.ScaleValue(15));
        Assert.assertEquals(true, s1.GetIntervalY() == 10);

        s1.SetIntervalY(12);
        s1.SetIsDirty(true);
        s1.SetOffsetY(8);
        s1.SetPosition(50, 50);
        
        Assert.assertEquals(true, s1.GetIntervalY() == 12);
        Assert.assertEquals(true, s1.GetIsDirty() == true);
        Assert.assertEquals(true, s1.GetOffsetY() == 8);
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
    
        s1.SetScrollBarCenterButton(b3);
        s1.SetScrollBarCenterButtonColor(MmgColor.GetRed());
        s1.SetScrollBarCenterButtonHeight(32);
        
        Assert.assertEquals(true, s1.GetScrollBarCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarCenterButton().equals(b3));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetRed()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonHeight() == 32);
        
        r1 = new MmgRect(0, 0, 16, 16);
        s1.SetScrollBarCenterButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarColor(MmgColor.GetDarkBlue());
        
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetDarkBlue()));
        
        s1.SetScrollBarWidth(32);
        
        Assert.assertEquals(true, s1.GetScrollBarWidth() == 32);
        
        s1.SetScrollBarUpButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarUpButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarUpButton().equals(b1));

        s1.SetScrollBarUpButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarUpButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarUpDownButtonHeight(32);
        
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == 32);

        s1.SetScrollBarDownButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarDownButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarDownButton().equals(b1));        
    
        s1.SetScrollBarDownButtonRect(r1);

        Assert.assertEquals(true, s1.GetScrollBarDownButtonRect().ApiEquals(r1));        
    
        s1.SetScrollBarVisible(false);
        
        Assert.assertEquals(true, s1.GetScrollBarVisible() == false);
        
        s1.SetScrollPane(b3);
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b3));

        s1.SetScrollPaneRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollPaneRect().ApiEquals(r1));
        Assert.assertEquals(true, s1.GetScrollPaneRect().equals(r1));

        s1.SetViewPort(b3);
        
        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetViewPort().equals(b3));

        s1.SetViewPortRect(r1);
        
        Assert.assertEquals(true, s1.GetViewPortRect().ApiEquals(r1));
        Assert.assertEquals(true, s1.GetViewPortRect().equals(r1)); 
        
        s1.SetHeightDiff(200);
        s1.SetHeightDiffPrct(0.5d);
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetHeightDiff() == 200);
        Assert.assertEquals(s1.GetHeightDiffPrct(), 0.5d, 0.001);
        Assert.assertEquals(true, s1.GetX() == 50);
        Assert.assertEquals(true, s1.GetY() == 50);

        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));        
    }

    @Test
    @SuppressWarnings("UnusedAssignment")
    public void test3() {
        MmgBmp b1, b2, b3 = null;
        MmgScrollVert s1, s2, s3 = null;
        MmgRect r1 = null;
        
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE == 1);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID == 0);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_SCROLL_UP_EVENT_ID == 1);
        Assert.assertEquals(true, MmgScrollVert.SCROLL_VERT_SCROLL_DOWN_EVENT_ID == 2);
        Assert.assertEquals(true, MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX == false);        
            
        b1 = MmgHelper.CreateFilledBmp(20, 20, MmgColor.GetGreen());
        b2 = MmgHelper.CreateFilledBmp(100, 100, MmgColor.GetGreen());
        b3 = MmgHelper.CreateFilledBmp(150, 150, MmgColor.GetGreen());        
        s1 = new MmgScrollVert(new MmgScrollVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 10));
        s3 = new MmgScrollVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 32, 32, 12);

        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b1));
        Assert.assertEquals(false, s1.GetViewPort().equals(b1));
        Assert.assertEquals(true, s1.GetViewPortRect().GetHeight() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetWidth() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetViewPortRect().GetTop() == 0);
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b2));
        Assert.assertEquals(false, s1.GetScrollPane().equals(b2));
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetHeight() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetWidth() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetTop() == 0);        

        Assert.assertEquals(true, s1.GetScrollBarWidth() == MmgHelper.ScaleValue(10));
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetBlack()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetBlack()));        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonHeight() == MmgHelper.ScaleValue(30));
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == MmgHelper.ScaleValue(15));
        Assert.assertEquals(true, s1.GetIntervalY() == 10);

        s1.SetIntervalY(12);
        s1.SetIsDirty(true);
        s1.SetOffsetY(8);
        s1.SetPosition(50, 50);
        
        Assert.assertEquals(true, s1.GetIntervalY() == 12);
        Assert.assertEquals(true, s1.GetIsDirty() == true);
        Assert.assertEquals(true, s1.GetOffsetY() == 8);
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
    
        s1.SetScrollBarCenterButton(b3);
        s1.SetScrollBarCenterButtonColor(MmgColor.GetRed());
        s1.SetScrollBarCenterButtonHeight(32);
        
        Assert.assertEquals(true, s1.GetScrollBarCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarCenterButton().equals(b3));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetRed()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonHeight() == 32);
        
        r1 = new MmgRect(0, 0, 16, 16);
        s1.SetScrollBarCenterButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarColor(MmgColor.GetDarkBlue());
        
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetDarkBlue()));
        
        s1.SetScrollBarWidth(32);
        
        Assert.assertEquals(true, s1.GetScrollBarWidth() == 32);
        
        s1.SetScrollBarUpButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarUpButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarUpButton().equals(b1));

        s1.SetScrollBarUpButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarUpButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarUpDownButtonHeight(32);
        
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == 32);

        s1.SetScrollBarDownButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarDownButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarDownButton().equals(b1));        
    
        s1.SetScrollBarDownButtonRect(r1);

        Assert.assertEquals(true, s1.GetScrollBarDownButtonRect().ApiEquals(r1));        
    
        s1.SetScrollBarVisible(false);
        
        Assert.assertEquals(true, s1.GetScrollBarVisible() == false);
        
        s1.SetScrollPane(b3);
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b3));

        s1.SetScrollPaneRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollPaneRect().ApiEquals(r1));
        Assert.assertEquals(true, s1.GetScrollPaneRect().equals(r1));

        s1.SetViewPort(b3);
        
        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetViewPort().equals(b3));

        s1.SetViewPortRect(r1);
        
        Assert.assertEquals(true, s1.GetViewPortRect().ApiEquals(r1));
        Assert.assertEquals(true, s1.GetViewPortRect().equals(r1)); 
        
        s1.SetHeightDiff(200);
        s1.SetHeightDiffPrct(0.5d);
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetHeightDiff() == 200);
        Assert.assertEquals(s1.GetHeightDiffPrct(), 0.5d, 0.001);
        Assert.assertEquals(true, s1.GetX() == 50);
        Assert.assertEquals(true, s1.GetY() == 50);

        s2 = s1.CloneTyped();
        
        Assert.assertEquals(true, s1.ApiEquals(s1));        
        Assert.assertEquals(true, s1.ApiEquals(s2));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(true, s2.ApiEquals(s1));
        Assert.assertEquals(false, s3.ApiEquals(s1));
        Assert.assertEquals(false, s1.ApiEquals(s3));        
    }    
}