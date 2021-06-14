package net.middlemind.MmgGameApiJava.MmgUnitTests;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScrollHorVert;
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
public class MmgScrollHorVertUnitTest_2 {
    
    public MmgScrollHorVertUnitTest_2() {
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
        MmgScrollHorVert s1, s2, s3 = null;
        MmgRect r1 = null;
        
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE == 2);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID == 6);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_UP_EVENT_ID == 7);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_DOWN_EVENT_ID == 8);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_LEFT_EVENT_ID == 9);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID == 10);        
        Assert.assertEquals(true, MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX == false);        
            
        b1 = MmgHelper.CreateFilledBmp(20, 20, MmgColor.GetGreen());
        b2 = MmgHelper.CreateFilledBmp(100, 100, MmgColor.GetGreen());
        b3 = MmgHelper.CreateFilledBmp(150, 150, MmgColor.GetGreen());        
        s1 = new MmgScrollHorVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 20, 20, 20, 20, 10, 10);
        s3 = new MmgScrollHorVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 32, 32, 32, 32, 12, 12);

        Assert.assertEquals(true, s1.GetScrollBarLeftRightButtonWidth() == MmgHelper.ScaleValue(15));
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == MmgHelper.ScaleValue(15));        
        
        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetViewPort().equals(b1));
        Assert.assertEquals(true, s1.GetViewPortRect().GetHeight() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetWidth() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetViewPortRect().GetTop() == 0);
        
        Assert.assertEquals(true, s1.GetScrollBarHorHeight() == 20);
        Assert.assertEquals(true, s1.GetScrollBarVertWidth() == 20);        
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b2));
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetHeight() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetWidth() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetTop() == 0);        

        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetBlack()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetBlack()));        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonWidth() == 20);        
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButtonHeight() == 20);
        Assert.assertEquals(true, s1.GetIntervalX() == 10);
        Assert.assertEquals(true, s1.GetIntervalY() == 10);        

        s1.SetIntervalX(12);
        s1.SetIntervalY(12);        
        s1.SetIsDirty(true);
        s1.SetOffsetX(8);
        s1.SetOffsetY(8);        
        s1.SetPosition(50, 50);
        
        Assert.assertEquals(true, s1.GetIntervalX() == 12);
        Assert.assertEquals(true, s1.GetIntervalY() == 12);        
        Assert.assertEquals(true, s1.GetIsDirty() == true);
        Assert.assertEquals(true, s1.GetOffsetX() == 8);
        Assert.assertEquals(true, s1.GetOffsetY() == 8);        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
    
        s1.SetScrollBarHorCenterButton(b3);
        s1.SetScrollBarVertCenterButton(b3);
        s1.SetScrollBarCenterButtonColor(MmgColor.GetRed());
        s1.SetScrollBarHorCenterButtonWidth(32);
        s1.SetScrollBarVertCenterButtonHeight(32);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButton().equals(b3));
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButton().equals(b3));        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetRed()));
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonWidth() == 32);
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButtonHeight() == 32);        
        
        r1 = new MmgRect(0, 0, 16, 16);
        s1.SetScrollBarHorCenterButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarColor(MmgColor.GetDarkBlue());
        
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetDarkBlue()));
        
        s1.SetScrollBarHorHeight(32);
        s1.SetScrollBarVertWidth(64);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorHeight() == 32);
        Assert.assertEquals(true, s1.GetScrollBarVertWidth() == 64);        
        
        s1.SetScrollBarHorLeftButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButton().equals(b1));

        s1.SetScrollBarHorLeftButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarHorRightButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorRightButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarHorRightButton().equals(b1));

        s1.SetScrollBarHorRightButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorRightButtonRect().ApiEquals(r1));        
        
        
        s1.SetScrollBarVertUpButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertUpButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarVertUpButton().equals(b1));

        s1.SetScrollBarVertUpButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertUpButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarVertDownButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertDownButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarVertDownButton().equals(b1));

        s1.SetScrollBarVertDownButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertDownButtonRect().ApiEquals(r1));                
                
        s1.SetScrollBarLeftRightButtonWidth(32);
        
        Assert.assertEquals(true, s1.GetScrollBarLeftRightButtonWidth() == 32);
    
        s1.SetScrollBarHorVisible(false);
        s1.SetScrollBarVertVisible(true);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorVisible() == false);
        Assert.assertEquals(true, s1.GetScrollBarVertVisible() == true);        
        
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
        
        s1.SetWidthDiff(200);
        s1.SetWidthDiffPrct(0.5d);
        s1.SetHeightDiff(100);
        s1.SetHeightDiffPrct(0.7d);        
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetWidthDiff() == 200);
        Assert.assertEquals(s1.GetWidthDiffPrct(), 0.5d, 0.001);        
        Assert.assertEquals(true, s1.GetHeightDiff() == 100);
        Assert.assertEquals(s1.GetHeightDiffPrct(), 0.7d, 0.001);
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
        MmgScrollHorVert s1, s2, s3 = null;
        MmgRect r1 = null;
        
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE == 2);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID == 6);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_UP_EVENT_ID == 7);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_DOWN_EVENT_ID == 8);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_LEFT_EVENT_ID == 9);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID == 10);        
        Assert.assertEquals(true, MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX == false);        
            
        b1 = MmgHelper.CreateFilledBmp(20, 20, MmgColor.GetGreen());
        b2 = MmgHelper.CreateFilledBmp(100, 100, MmgColor.GetGreen());
        b3 = MmgHelper.CreateFilledBmp(150, 150, MmgColor.GetGreen());        
        s1 = new MmgScrollHorVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 10, 10);
        s3 = new MmgScrollHorVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 32, 32, 32, 32, 12, 12);

        Assert.assertEquals(true, s1.GetScrollBarLeftRightButtonWidth() == MmgHelper.ScaleValue(15));
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == MmgHelper.ScaleValue(15));        
        
        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetViewPort().equals(b1));
        Assert.assertEquals(true, s1.GetViewPortRect().GetHeight() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetWidth() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetViewPortRect().GetTop() == 0);
        
        Assert.assertEquals(true, s1.GetScrollBarHorHeight() == MmgHelper.ScaleValue(10));
        Assert.assertEquals(true, s1.GetScrollBarVertWidth() == MmgHelper.ScaleValue(10));
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b2));
        Assert.assertEquals(true, s1.GetScrollPane().equals(b2));
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetHeight() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetWidth() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetTop() == 0);        

        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetBlack()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetBlack()));        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonWidth() == MmgHelper.ScaleValue(30));        
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButtonHeight() == MmgHelper.ScaleValue(30));
        Assert.assertEquals(true, s1.GetIntervalX() == 10);
        Assert.assertEquals(true, s1.GetIntervalY() == 10);        

        s1.SetIntervalX(12);
        s1.SetIntervalY(12);        
        s1.SetIsDirty(true);
        s1.SetOffsetX(8);
        s1.SetOffsetY(8);        
        s1.SetPosition(50, 50);
        
        Assert.assertEquals(true, s1.GetIntervalX() == 12);
        Assert.assertEquals(true, s1.GetIntervalY() == 12);        
        Assert.assertEquals(true, s1.GetIsDirty() == true);
        Assert.assertEquals(true, s1.GetOffsetX() == 8);
        Assert.assertEquals(true, s1.GetOffsetY() == 8);        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
    
        s1.SetScrollBarHorCenterButton(b3);
        s1.SetScrollBarVertCenterButton(b3);
        s1.SetScrollBarCenterButtonColor(MmgColor.GetRed());
        s1.SetScrollBarHorCenterButtonWidth(32);
        s1.SetScrollBarVertCenterButtonHeight(32);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButton().equals(b3));
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButton().equals(b3));        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetRed()));
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonWidth() == 32);
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButtonHeight() == 32);        
        
        r1 = new MmgRect(0, 0, 16, 16);
        s1.SetScrollBarHorCenterButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarColor(MmgColor.GetDarkBlue());
        
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetDarkBlue()));
        
        s1.SetScrollBarHorHeight(32);
        s1.SetScrollBarVertWidth(64);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorHeight() == 32);
        Assert.assertEquals(true, s1.GetScrollBarVertWidth() == 64);        
        
        s1.SetScrollBarHorLeftButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButton().equals(b1));

        s1.SetScrollBarHorLeftButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarHorRightButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorRightButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarHorRightButton().equals(b1));

        s1.SetScrollBarHorRightButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorRightButtonRect().ApiEquals(r1));        
        
        
        s1.SetScrollBarVertUpButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertUpButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarVertUpButton().equals(b1));

        s1.SetScrollBarVertUpButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertUpButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarVertDownButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertDownButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarVertDownButton().equals(b1));

        s1.SetScrollBarVertDownButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertDownButtonRect().ApiEquals(r1));                
                
        s1.SetScrollBarLeftRightButtonWidth(32);
        
        Assert.assertEquals(true, s1.GetScrollBarLeftRightButtonWidth() == 32);
    
        s1.SetScrollBarHorVisible(false);
        s1.SetScrollBarVertVisible(true);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorVisible() == false);
        Assert.assertEquals(true, s1.GetScrollBarVertVisible() == true);        
        
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
        
        s1.SetWidthDiff(200);
        s1.SetWidthDiffPrct(0.5d);
        s1.SetHeightDiff(100);
        s1.SetHeightDiffPrct(0.7d);        
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetWidthDiff() == 200);
        Assert.assertEquals(s1.GetWidthDiffPrct(), 0.5d, 0.001);        
        Assert.assertEquals(true, s1.GetHeightDiff() == 100);
        Assert.assertEquals(s1.GetHeightDiffPrct(), 0.7d, 0.001);
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
        MmgScrollHorVert s1, s2, s3 = null;
        MmgRect r1 = null;
        
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE == 2);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID == 6);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_UP_EVENT_ID == 7);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_DOWN_EVENT_ID == 8);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_LEFT_EVENT_ID == 9);
        Assert.assertEquals(true, MmgScrollHorVert.SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID == 10);        
        Assert.assertEquals(true, MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX == false);        
            
        b1 = MmgHelper.CreateFilledBmp(20, 20, MmgColor.GetGreen());
        b2 = MmgHelper.CreateFilledBmp(100, 100, MmgColor.GetGreen());
        b3 = MmgHelper.CreateFilledBmp(150, 150, MmgColor.GetGreen());        
        s1 = new MmgScrollHorVert(new MmgScrollHorVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 10, 10));
        s3 = new MmgScrollHorVert(b1, b2, MmgColor.GetBlack(), MmgColor.GetBlack(), 32, 32, 32, 32, 12, 12);

        Assert.assertEquals(true, s1.GetScrollBarLeftRightButtonWidth() == MmgHelper.ScaleValue(15));
        Assert.assertEquals(true, s1.GetScrollBarUpDownButtonHeight() == MmgHelper.ScaleValue(15));        
        
        Assert.assertEquals(true, s1.GetViewPort().ApiEquals(b1));
        Assert.assertEquals(false, s1.GetViewPort().equals(b1));
        Assert.assertEquals(true, s1.GetViewPortRect().GetHeight() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetWidth() == 20);
        Assert.assertEquals(true, s1.GetViewPortRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetViewPortRect().GetTop() == 0);
        
        Assert.assertEquals(true, s1.GetScrollBarHorHeight() == MmgHelper.ScaleValue(10));
        Assert.assertEquals(true, s1.GetScrollBarVertWidth() == MmgHelper.ScaleValue(10));
        
        Assert.assertEquals(true, s1.GetScrollPane().ApiEquals(b2));
        Assert.assertEquals(false, s1.GetScrollPane().equals(b2));
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetHeight() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetWidth() == 100);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetLeft() == 0);
        Assert.assertEquals(true, s1.GetScrollPaneRect().GetTop() == 0);        

        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetBlack()));
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetBlack()));        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonWidth() == MmgHelper.ScaleValue(30));        
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButtonHeight() == MmgHelper.ScaleValue(30));
        Assert.assertEquals(true, s1.GetIntervalX() == 10);
        Assert.assertEquals(true, s1.GetIntervalY() == 10);        

        s1.SetIntervalX(12);
        s1.SetIntervalY(12);        
        s1.SetIsDirty(true);
        s1.SetOffsetX(8);
        s1.SetOffsetY(8);        
        s1.SetPosition(50, 50);
        
        Assert.assertEquals(true, s1.GetIntervalX() == 12);
        Assert.assertEquals(true, s1.GetIntervalY() == 12);        
        Assert.assertEquals(true, s1.GetIsDirty() == true);
        Assert.assertEquals(true, s1.GetOffsetX() == 8);
        Assert.assertEquals(true, s1.GetOffsetY() == 8);        
        Assert.assertEquals(true, s1.GetPosition().ApiEquals(new MmgVector2(50, 50)));
    
        s1.SetScrollBarHorCenterButton(b3);
        s1.SetScrollBarVertCenterButton(b3);
        s1.SetScrollBarCenterButtonColor(MmgColor.GetRed());
        s1.SetScrollBarHorCenterButtonWidth(32);
        s1.SetScrollBarVertCenterButtonHeight(32);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButton().equals(b3));
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButton().ApiEquals(b3));
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButton().equals(b3));        
        Assert.assertEquals(true, s1.GetScrollBarCenterButtonColor().ApiEquals(MmgColor.GetRed()));
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonWidth() == 32);
        Assert.assertEquals(true, s1.GetScrollBarVertCenterButtonHeight() == 32);        
        
        r1 = new MmgRect(0, 0, 16, 16);
        s1.SetScrollBarHorCenterButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorCenterButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarColor(MmgColor.GetDarkBlue());
        
        Assert.assertEquals(true, s1.GetScrollBarColor().ApiEquals(MmgColor.GetDarkBlue()));
        
        s1.SetScrollBarHorHeight(32);
        s1.SetScrollBarVertWidth(64);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorHeight() == 32);
        Assert.assertEquals(true, s1.GetScrollBarVertWidth() == 64);        
        
        s1.SetScrollBarHorLeftButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButton().equals(b1));

        s1.SetScrollBarHorLeftButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorLeftButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarHorRightButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorRightButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarHorRightButton().equals(b1));

        s1.SetScrollBarHorRightButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarHorRightButtonRect().ApiEquals(r1));        
        
        
        s1.SetScrollBarVertUpButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertUpButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarVertUpButton().equals(b1));

        s1.SetScrollBarVertUpButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertUpButtonRect().ApiEquals(r1));
    
        s1.SetScrollBarVertDownButton(b1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertDownButton().ApiEquals(b1));
        Assert.assertEquals(true, s1.GetScrollBarVertDownButton().equals(b1));

        s1.SetScrollBarVertDownButtonRect(r1);
        
        Assert.assertEquals(true, s1.GetScrollBarVertDownButtonRect().ApiEquals(r1));                
                
        s1.SetScrollBarLeftRightButtonWidth(32);
        
        Assert.assertEquals(true, s1.GetScrollBarLeftRightButtonWidth() == 32);
    
        s1.SetScrollBarHorVisible(false);
        s1.SetScrollBarVertVisible(true);        
        
        Assert.assertEquals(true, s1.GetScrollBarHorVisible() == false);
        Assert.assertEquals(true, s1.GetScrollBarVertVisible() == true);        
        
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
        
        s1.SetWidthDiff(200);
        s1.SetWidthDiffPrct(0.5d);
        s1.SetHeightDiff(100);
        s1.SetHeightDiffPrct(0.7d);        
        s1.SetX(50);
        s1.SetY(50);
        
        Assert.assertEquals(true, s1.GetWidthDiff() == 200);
        Assert.assertEquals(s1.GetWidthDiffPrct(), 0.5d, 0.001);        
        Assert.assertEquals(true, s1.GetHeightDiff() == 100);
        Assert.assertEquals(s1.GetHeightDiffPrct(), 0.7d, 0.001);
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