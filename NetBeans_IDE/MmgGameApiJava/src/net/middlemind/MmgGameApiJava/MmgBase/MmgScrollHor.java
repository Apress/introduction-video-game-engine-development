package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Color;
import java.awt.Graphics2D;

/**
 * A class the provides support for a horizontal scroll pane.
 * Created by Middlemind Games 01/16/2020
 * 
 * @author Victor G. Brusca
 */
public class MmgScrollHor extends MmgObj {
    
    /**
     * An MmgBmp object that is the view port for a scroll pane that sits behind the view port.
     */    
    private MmgBmp viewPort;

    /**
     * A rectangle with the dimensions of the view port.
     */    
    private MmgRect viewPortRect;  

    /**
     * The width of the scroll pane view port.
     */    
    private int viewPortWidth;
    
    /**
     * An MmgBmp object that is the scroll pane to show a portion of through the view port.
     */    
    private MmgBmp scrollPane;
    
    /**
     * A rectangle with the dimensions of the scroll pane.
     */
    private MmgRect scrollPaneRect;
    
    /**
     * The width of the scroll pane.
     */    
    private int scrollPaneWidth;
    
    /**
     * An MmgBmp object that is the horizontal slider.
     */    
    private MmgBmp scrollBarCenterButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider.
     */    
    private MmgRect scrollBarCenterButtonRect;
    
    /**
     * An MmgBmp that is the horizontal slider's left button.
     */    
    private MmgBmp scrollBarLeftButton;

    /**
     * A rectangle with the dimensions of the horizontal slider's left button.
     */    
    private MmgRect scrollBarLeftButtonRect;
    
    /**
     * An MmgBmp that is the horizontal slider's right button.
     */     
    private MmgBmp scrollBarRightButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider's right button.
     */    
    private MmgRect scrollBarRightButtonRect;
    
    /**
     * The width difference between the view port and the scroll pane.
     */    
    private int widthDiff;
    
    /**
     * The width difference percentage between the view port and the scroll pane.
     */    
    private double widthDiffPrct;
    
    /**
     * A boolean flag indicating if the horizontal scroll bar is visible.
     */
    private boolean scrollBarVisible = false;
    
    /**
     * An MmgColor for the horizontal scroll bar background color.
     */
    private MmgColor scrollBarColor;
    
    /**
     * An MmgColor for the horizontal scroll bar slider's color.
     */
    private MmgColor scrollBarCenterButtonColor;    
    
    /**
     * The horizontal scroll bar height.
     */    
    private int scrollBarHeight;
    
    /**
     * The width of the horizontal scroll bar slider.
     */
    private int scrollBarCenterButtonWidth;
    
    /**
     * The width of the scroll bar slider button.
     */    
    private int scrollBarLeftRightButtonWidth;
    
    /**
     * The scroll interval of the horizontal slider.
     */    
    private int intervalX;
    
    /**
     * The scroll interval percentage of the horizontal slider.
     */    
    private double intervalPrctX;
    
    /**
     * A boolean flag indicating if the scroll pane needs to be updated during the MmgUpdate call.
     */
    private boolean isDirty;
    
    /**
     * The current offset of the horizontal scroll bar's slider.
     */    
    private int offsetXScrollBarCenterButton;
    
    /**
     * The current offset of the horizontal scroll pane.
     */
    private int offsetXScrollPane;
     
    /**
     * A boolean flag indicating if a bounding box should be drawn around the elements of the scroll pane.
     */
    public static boolean SHOW_CONTROL_BOUNDING_BOX = false;   
    
    /**
     * The MmgEvent to fire when a screen click occurs.
     */
    private MmgEvent clickScreen = new MmgEvent(null, "hor_click_screen", MmgScrollHor.SCROLL_HOR_CLICK_EVENT_ID, MmgScrollHor.SCROLL_HOR_CLICK_EVENT_TYPE, null, null);    
    
    /**
     * The MmgEvent to fire when a scroll left event occurs.
     */
    private MmgEvent clickLeft = new MmgEvent(null, "hor_click_left", MmgScrollHor.SCROLL_HOR_SCROLL_LEFT_EVENT_ID, MmgScrollHor.SCROLL_HOR_CLICK_EVENT_TYPE, null, null);        
    
    /**
     * The MmgEvent to fire when a scroll right event occurs.
     */
    private MmgEvent clickRight = new MmgEvent(null, "hor_click_right", MmgScrollHor.SCROLL_HOR_SCROLL_RIGHT_EVENT_ID, MmgScrollHor.SCROLL_HOR_CLICK_EVENT_TYPE, null, null);
    
    /**
     * An event type id for this object's events.
     */
    public static int SCROLL_HOR_CLICK_EVENT_TYPE = 0;    
    
    /**
     * An event id for a scroll pane click event.
     */    
    public static int SCROLL_HOR_CLICK_EVENT_ID = 3;
    
    /**
     * An event id for a scroll pane left click event.
     */    
    public static int SCROLL_HOR_SCROLL_LEFT_EVENT_ID = 4;
    
    /**
     * An event id for a scroll pane right click event.
     */    
    public static int SCROLL_HOR_SCROLL_RIGHT_EVENT_ID = 5;
    
    /**
     * An MmgPen object instance used to draw the visible portion of the scroll pane to the view port.
     */
    private MmgPen p;
    
    /**
     * An MmgRect used in the MmgUpdate method.
     */
    private MmgRect updSrcRect;
    
    /**
     * An MmgRect used in the MmgUpdate method.
     */    
    private MmgRect updDstRect;
    
    /**
     * A Color object used in the bounding box drawing of the MmgDraw method.
     */
    private Color c;    
    
    /**
     * Basic constructor that sets the required objects, colors, and dimensions.
     * Prepares the drawing dimensions based on the provided objects.
     * 
     * @param ViewPort                      The MmgBmp that shows a portion of the MmgBmp scroll pane.
     * @param ScrollPane                    The MmgBmp the is used to display a portion of itself to the view port.
     * @param ScrollBarColor                The MmgColor to use for the scroll bar.
     * @param ScrollBarCenterButtonColor    The MmgColor to use for the scroll bar slider.
     * @param ScrollBarHeight               The height of the scroll bar.
     * @param ScrollBarCenterButtonWidth    The width of the scroll bar slider.
     * @param IntervalX                     The interval to use when moving the scroll bar.
     */
    public MmgScrollHor(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int ScrollBarHeight, int ScrollBarCenterButtonWidth, int IntervalX) {
        super();
        viewPort = ViewPort;
        scrollPane = ScrollPane;
        scrollBarHeight = ScrollBarHeight;
        scrollBarColor = ScrollBarColor;
        scrollBarCenterButtonColor = ScrollBarCenterButtonColor;
        scrollBarCenterButtonWidth = ScrollBarCenterButtonWidth;
        scrollBarLeftRightButtonWidth = MmgHelper.ScaleValue(15);
        intervalX = IntervalX;        
        PrepDimensions();
        SetIntervalX(IntervalX);
    }
    
    /**
     * Abridged constructor that sets the required objects, colors, and dimensions.
     * Prepares the drawing dimensions based on the provided objects.
     * 
     * @param ViewPort                      The MmgBmp that shows a portion of the MmgBmp scroll pane.
     * @param ScrollPane                    The MmgBmp the is used to display a portion of itself to the view port.
     * @param ScrollBarColor                The MmgColor to use for the scroll bar.
     * @param ScrollBarCenterButtonColor    The MmgColor to use for the scroll bar slider.
     * @param IntervalX                     The interval to use when moving the scroll bar.
     */
    public MmgScrollHor(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int IntervalX) {
        super();
        viewPort = ViewPort;
        scrollPane = ScrollPane;
        scrollBarHeight = MmgHelper.ScaleValue(10);
        scrollBarColor = ScrollBarColor;
        scrollBarCenterButtonColor = ScrollBarCenterButtonColor;
        scrollBarCenterButtonWidth = MmgHelper.ScaleValue(30);
        scrollBarLeftRightButtonWidth = MmgHelper.ScaleValue(15);
        intervalX = IntervalX;
        PrepDimensions();
        SetIntervalX(IntervalX);
    }    
    
    /**
     * Constructor that is based on an instance of this class.
     * 
     * @param obj       An MmgScrollHor instance. 
     */
    public MmgScrollHor(MmgScrollHor obj) {
        super();

        SetWidth(obj.GetWidth());
        SetHeight(obj.GetHeight());
        
        if(obj.GetMmgColor() == null) {
            SetMmgColor(obj.GetMmgColor());
        } else {
            SetMmgColor(obj.GetMmgColor().Clone());
        }
                
        if(obj.GetViewPort() == null) {
            SetViewPort(obj.GetViewPort());
        } else {
            SetViewPort(obj.GetViewPort().CloneTyped());
        }
        
        if(obj.GetViewPortRect() == null) {
            SetViewPortRect(obj.GetViewPortRect());
        } else {
            SetViewPortRect(obj.GetViewPortRect().Clone());
        }
        
        if(obj.GetScrollPane() == null) {
            SetScrollPane(obj.GetScrollPane());
        } else {
            SetScrollPane(obj.GetScrollPane().CloneTyped());
        }
        
        if(obj.GetScrollPaneRect() == null) {
            SetScrollPaneRect(obj.GetScrollPaneRect());
        } else {
            SetScrollPaneRect(obj.GetScrollPaneRect().Clone());
        }
        
        if(obj.GetScrollBarCenterButton() == null) {
            SetScrollBarCenterButton(obj.GetScrollBarCenterButton());
        } else {
            SetScrollBarCenterButton(obj.GetScrollBarCenterButton().CloneTyped());
        }
        
        if(obj.GetScrollBarCenterButtonRect() == null) {
            SetScrollBarCenterButtonRect(obj.GetScrollBarCenterButtonRect());
        } else {
            SetScrollBarCenterButtonRect(obj.GetScrollBarCenterButtonRect().Clone());
        }
        
        if(obj.GetScrollBarLeftButton() == null) {
            SetScrollBarLeftButton(obj.GetScrollBarLeftButton());
        } else {
            SetScrollBarLeftButton(obj.GetScrollBarLeftButton().CloneTyped());
        }
        
        if(obj.GetScrollBarLeftButtonRect() == null) {
            SetScrollBarLeftButtonRect(obj.GetScrollBarLeftButtonRect());
        } else {
            SetScrollBarLeftButtonRect(obj.GetScrollBarLeftButtonRect().Clone());
        }
        
        if(obj.GetScrollBarRightButton() == null) {
            SetScrollBarRightButton(obj.GetScrollBarRightButton());
        } else {
            SetScrollBarRightButton(obj.GetScrollBarRightButton().CloneTyped());
        }
        
        if(obj.GetScrollBarRightButtonRect() == null) {
            SetScrollBarRightButtonRect(obj.GetScrollBarRightButtonRect());
        } else {
            SetScrollBarRightButtonRect(obj.GetScrollBarRightButtonRect().Clone());
        }
        
        SetWidthDiff(obj.GetWidthDiff());
        SetWidthDiffPrct(obj.GetWidthDiffPrct());
        SetScrollBarVisible(obj.GetScrollBarVisible());
        
        if(obj.GetScrollBarColor() == null) {
            SetScrollBarColor(obj.GetScrollBarColor());
        } else {
            SetScrollBarColor(obj.GetScrollBarColor().Clone());
        }
        
        if(obj.GetScrollBarCenterButtonColor() == null) {
            SetScrollBarCenterButtonColor(obj.GetScrollBarCenterButtonColor());
        } else {
            SetScrollBarCenterButtonColor(obj.GetScrollBarCenterButtonColor().Clone());
        }
        
        SetScrollBarHeight(obj.GetScrollBarHeight());
        SetScrollBarCenterButtonWidth(obj.GetScrollBarCenterButtonWidth());
        SetScrollBarLeftRightButtonWidth(obj.GetScrollBarLeftRightButtonWidth());
        SetOffsetX(obj.GetOffsetX());

        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            GetPosition().SetX(obj.GetPosition().GetX());
            GetPosition().SetY(obj.GetPosition().GetY());            
        }        
        
        SetIntervalX(obj.GetIntervalX());        
    }    
    
    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgScrollHor(this);
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override    
    public MmgScrollHor CloneTyped() {
        return new MmgScrollHor(this);
    }    
    
    /**
     * Prepares the dimension of the scroll view, scroll bar, slider, and buttons.
     */
    public void PrepDimensions() {
        int left = 0;
        int top = 0;
        int bottom = viewPort.GetHeight();
        int right = viewPort.GetWidth();
        viewPortRect = new MmgRect(left, top, bottom, right);
        viewPortWidth = viewPortRect.GetWidth();
        
        if(scrollBarLeftButton == null) {
            scrollBarLeftButton = MmgHelper.GetBasicCachedBmp("scroll_bar_left_sm.png");
        }
        
        if(scrollBarRightButton == null) {
            scrollBarRightButton = MmgHelper.GetBasicCachedBmp("scroll_bar_right_sm.png");
        }
        
        if(scrollBarCenterButton == null) {
            scrollBarCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");
        }
        
        if(scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null) {
            scrollBarLeftRightButtonWidth = scrollBarLeftButton.GetWidth();
            scrollBarHeight = scrollBarLeftButton.GetHeight();
            scrollBarCenterButtonWidth = scrollBarCenterButton.GetWidth();
        }
        
        left = 0;
        top = 0;
        bottom = scrollPane.GetHeight();
        right = scrollPane.GetWidth();
        scrollPaneRect = new MmgRect(left, top, bottom, right);
        scrollPaneWidth = scrollPaneRect.GetWidth();
        
        left = scrollBarLeftRightButtonWidth;
        top = viewPort.GetHeight();
        bottom = viewPort.GetHeight() + scrollBarHeight;
        right = scrollBarLeftRightButtonWidth + scrollBarCenterButtonWidth;
        scrollBarCenterButtonRect = new MmgRect(left, top, bottom, right);
        
        left = 0;
        top = viewPort.GetHeight();
        bottom = viewPort.GetHeight() + scrollBarHeight;
        right = scrollBarLeftRightButtonWidth;
        scrollBarLeftButtonRect = new MmgRect(left, top, bottom, right);        
                
        left = viewPort.GetWidth() - scrollBarLeftRightButtonWidth;
        top = viewPort.GetHeight();
        bottom = viewPort.GetHeight() + scrollBarHeight;        
        right = viewPort.GetWidth();
        scrollBarRightButtonRect = new MmgRect(left, top, bottom, right);   
          
        if(scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null) {
            scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
            scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());            
            scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
        }
        
        PrepScrollPane();        
        isDirty = true;
    }
    
    /**
     * Finalizes the scroll view's preparation.
     * Called at the end of the PrepDimensions method.
     */
    public void PrepScrollPane() {
        int h = viewPortWidth;
        int H = scrollPaneWidth;        
        //B = b1 + b2 + b3
        int buttonWidth = (scrollBarLeftRightButtonWidth + scrollBarLeftRightButtonWidth + scrollBarCenterButtonWidth);        
        //S = h - B
        int scrollNotchTravel = h - buttonWidth;        
        //T = H - h;
        int scrollPaneTravel = H - h;        
        //TP = h / T
        double prctHeightDiff = (double)scrollNotchTravel / (double)scrollPaneTravel;        
        //IPS = I / S
        double intervalPrctViewPort = (double)intervalX / (double)scrollNotchTravel;        
        //IPT = I / T
        double intervalPrctScrollPane = (double)intervalX / (double)scrollPaneTravel;        
        
        if(scrollPaneWidth - viewPortWidth > 0) {
            widthDiff = H - scrollNotchTravel;
            widthDiffPrct = intervalPrctScrollPane;            
            scrollBarVisible = true;            
        } else {
            widthDiff = 0;
            widthDiffPrct = 0.0;
            scrollBarVisible = false;
        }
        
        p = new MmgPen((Graphics2D)viewPort.GetImage().getGraphics());
        p.SetAdvRenderHints();
    }    
    
    /**
     * Returns the target event handler of the clickScreen MmgEvent class field.
     * 
     * @return      The MmgEventHandler to use to handle events.
     */
    public MmgEventHandler GetEventHandler() {
        if(clickScreen != null) {
            return clickScreen.GetTargetEventHandler();
        }
        
        return null;
    }
    
    /**
     * Sets event handlers for all this object's events.
     * 
     * @param e     The MmgEventHandler to use to handle events.
     */
    public void SetEventHandler(MmgEventHandler e) {
        clickScreen.SetTargetEventHandler(e);
        clickLeft.SetTargetEventHandler(e);
        clickRight.SetTargetEventHandler(e);
    }
    
    /**
     * Gets the click screen event.
     * 
     * @return      The click screen event.
     */
    public MmgEvent GetClickScreen() {
        return clickScreen;
    }

    /**
     * Sets the click screen event.
     * 
     * @param e     The click screen event.
     */
    public void SetClickScreen(MmgEvent e) {
        clickScreen = e;
    }

    /**
     * Gets the scroll left event.
     * 
     * @return      The scroll left event.
     */
    public MmgEvent GetClickLeft() {
        return clickLeft;
    }

    /**
     * Sets the scroll left event.
     * 
     * @param e     The scroll left event.
     */
    public void SetClickLeft(MmgEvent e) {
        clickLeft = e;
    }

    /**
     * Gets the scroll right event.
     * 
     * @return      The scroll right event.
     */
    public MmgEvent GetClickRight() {
        return clickRight;
    }

    /**
     * Sets the scroll right event.
     * 
     * @param e     The scroll right event.
     */
    public void SetClickRight(MmgEvent e) {
        clickRight = e;
    }

    /**
     * Sets the X coordinate of this scroll view.
     * 
     * @param inX       The X coordinate of this scroll view.
     */
    @Override
    public void SetX(int inX) {
        super.SetX(inX);
        viewPortRect.SetPosition(new MmgVector2(inX, viewPortRect.GetTop()));
        scrollPaneRect.SetPosition(new MmgVector2(inX, scrollPaneRect.GetTop()));
        scrollBarCenterButtonRect.SetPosition(new MmgVector2(inX + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarCenterButtonRect.GetTop()));
        scrollBarLeftButtonRect.SetPosition(new MmgVector2(inX, scrollBarLeftButtonRect.GetTop()));
        scrollBarRightButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, scrollBarRightButtonRect.GetTop()));        

        if(scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null) {
            scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
            scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());            
            scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
        }        
    }
    
    /**
     * Sets the Y coordinate of this scroll view.
     * 
     * @param inY       The Y coordinate of this scroll view.
     */
    @Override
    public void SetY(int inY) {
        super.SetX(inY);
        viewPortRect.SetPosition(new MmgVector2(viewPortRect.GetLeft(), inY));
        scrollPaneRect.SetPosition(new MmgVector2(scrollPaneRect.GetLeft(), inY));
        scrollBarCenterButtonRect.SetPosition(new MmgVector2(scrollBarCenterButtonRect.GetLeft(), inY + viewPort.GetHeight()));
        scrollBarLeftButtonRect.SetPosition(new MmgVector2(scrollBarLeftButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));
        scrollBarRightButtonRect.SetPosition(new MmgVector2(scrollBarRightButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));

        if(scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null) {
            scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
            scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());            
            scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
        }
    }
    
    /**
     * Sets the position of the scroll view.
     * 
     * @param x     The X coordinate of the position.
     * @param y     The Y coordinate of the position.
     */
    @Override
    public void SetPosition(int x, int y) {
        SetPosition(new MmgVector2(x, y));
    }
     
    /**
     * Sets the position of the scroll view.
     * 
     * @param inPos     The position to set the scroll view.
     */
    @Override
    public void SetPosition(MmgVector2 inPos) {
        super.SetPosition(inPos);
        viewPortRect.SetPosition(inPos);
        scrollPaneRect.SetPosition(inPos);
        scrollBarCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, inPos.GetY() + viewPort.GetHeight()));
        scrollBarLeftButtonRect.SetPosition(new MmgVector2(inPos.GetX(), inPos.GetY() + viewPort.GetHeight()));
        scrollBarRightButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, inPos.GetY() + viewPortRect.GetHeight()));        

        if(scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null) {
            scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
            scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());            
            scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
        }
    }
         
    /**
     * Processes dpad input release events.
     * 
     * @param dir   The direction of the dpad input to process.
     * @return      A boolean indicating if the dpad input was handled.
     */    
    public boolean ProcessDpadRelease(int dir) {
        int h = viewPortWidth;
        int H = scrollPaneWidth;        
        //B = b1 + b2 + b3
        int buttonWidth = (scrollBarLeftRightButtonWidth + scrollBarLeftRightButtonWidth + scrollBarCenterButtonWidth);        
        //S = h - B
        int scrollNotchTravel = h - buttonWidth;        
        //T = H - h;
        int scrollPaneTravel = H - h;        
        //TP = h / T
        double prctHeightDiff = (double)scrollNotchTravel / (double)scrollPaneTravel;        
        //IPS = I / S
        double intervalPrctViewPort = (double)intervalX / (double)scrollNotchTravel;        
        //IPT = I / T
        double intervalPrctScrollPane = (double)intervalX / (double)scrollPaneTravel;         
        double currentPrct = (double)offsetXScrollPane / (double)scrollPaneTravel;        
        
        if(scrollBarVisible && dir == MmgDir.DIR_LEFT) {
            if(currentPrct - widthDiffPrct < 0.0) {
                currentPrct = 0.0;
            } else {
                currentPrct -= widthDiffPrct;
            }

            if(currentPrct >= -0.002 && currentPrct <= 0.002) {
                currentPrct = 0.0;
            }

            offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);
            
            if(clickLeft != null) {
                clickLeft.Fire();
            }            
            
            isDirty = true;
            return true;            
        } else if(scrollBarVisible && dir == MmgDir.DIR_RIGHT) {
            if(currentPrct + widthDiffPrct > 1.0) {
                currentPrct = 1.0;
            } else {
                currentPrct += widthDiffPrct;                    
            }

            if(currentPrct >= 0.998 && currentPrct <= 1.002) {
                currentPrct = 1.0;
            }                

            offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);
            
            if(clickRight != null) {
                clickRight.Fire();
            }                        
            
            isDirty = true;            
            return true;
            
        }        
        return false;
    }
    
    /**
     * Handle screen click events.
     * 
     * @param x     The X coordinate of the screen click event.
     * @param y     The Y coordinate of the screen click event.
     * @return      A boolean indicating if the click event was handled.
     */
    public boolean ProcessScreenClick(int x, int y) {
        boolean ret = false;
        
        int h = viewPortWidth;
        int H = scrollPaneWidth;        
        //B = b1 + b2 + b3
        int buttonWidth = (scrollBarLeftRightButtonWidth + scrollBarLeftRightButtonWidth + scrollBarCenterButtonWidth);        
        //S = h - B
        int scrollNotchTravel = h - buttonWidth;        
        //T = H - h;
        int scrollPaneTravel = H - h;        
        //TP = h / T
        double prctHeightDiff = (double)scrollNotchTravel / (double)scrollPaneTravel;        
        //IPS = I / S
        double intervalPrctViewPort = (double)intervalX / (double)scrollNotchTravel;        
        //IPT = I / T
        double intervalPrctScrollPane = (double)intervalX / (double)scrollPaneTravel;         
        double currentPrct = (double)offsetXScrollBarCenterButton / (double)scrollNotchTravel;        
                        
        if(MmgHelper.RectCollision(x, y, viewPortRect)) {
            if(clickScreen != null) {
                clickScreen.SetExtra(new MmgVector2(x, y));
                clickScreen.Fire();
            }
            ret = true;
                                    
        }else if(scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarLeftButtonRect)) {
            if(currentPrct - widthDiffPrct < 0.0) {
                currentPrct = 0.0;
            } else {
                currentPrct -= widthDiffPrct;
            }

            if(currentPrct >= -0.002 && currentPrct <= 0.002) {
                currentPrct = 0.0;
            }

            offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);
            
            if(clickLeft != null) {
                clickLeft.Fire();
            }                        
            
            isDirty = true;
            ret = true;            
        }else if(scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarRightButtonRect)) {
            if(currentPrct + widthDiffPrct > 1.0) {
                currentPrct = 1.0;
            } else {
                currentPrct += widthDiffPrct;                    
            }

            if(currentPrct >= 0.998 && currentPrct <= 1.002) {
                currentPrct = 1.0;
            }                

            offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);
            
            if(clickRight != null) {
                clickRight.Fire();
            }            
            
            isDirty = true;            
            ret = true;                       
        }
        
        return ret;
    }
    
    /**
     * Gets the current view port for scroll view.
     * 
     * @return      The view port for scroll view.
     */
    public MmgBmp GetViewPort() {
        return viewPort;
    }

    /**
     * Sets the current view port for this scroll view.
     * Changing the view port requires a call to PrepDimensions.
     * 
     * @param ViewPort      The view port for this scroll view.
     */    
    public void SetViewPort(MmgBmp ViewPort) {
        viewPort = ViewPort;
    }

    /**
     * Gets the scroll pane for this scroll view.
     * 
     * @return      The scroll pane for this scroll view.
     */    
    public MmgBmp GetScrollPane() {
        return scrollPane;
    }

    /**
     * Sets the scroll pane for this scroll view.
     * Changing the scroll pane requires a call to PrepDimensions.
     * 
     * @param ScrollPane    The scroll pane for this scroll view.
     */
    public void SetScrollPane(MmgBmp ScrollPane) {
        scrollPane = ScrollPane;
    }

    /**
     * Gets the MmgRect dimensions for the view port.
     * 
     * @return      The MmgRect dimensions for the view port.
     */
    public MmgRect GetViewPortRect() {
        return viewPortRect;
    }

    /**
     * Sets the MmgRect dimensions for the view port.
     * Changing the view port dimensions requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for the view ports.
     */
    public void SetViewPortRect(MmgRect r) {
        viewPortRect = r;
    }    
    
    /**
     * Gets the MmgRect dimensions for the scroll pane.
     * 
     * @return      The MmgRect dimensions for the scroll pane.
     */
    public MmgRect GetScrollPaneRect() {
        return scrollPaneRect;
    }

    /**
     * Sets the MmgRect dimensions for the scroll pane.
     * Changing the scroll pane dimensions requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for this scroll pane.
     */
    public void SetScrollPaneRect(MmgRect r) {
        scrollPaneRect = r;
    }    

    /**
     * Gets the MmgBmp that is used for the horizontal slider.
     * 
     * @return      The MmgBmp used for the horizontal slider.
     */
    public MmgBmp GetScrollBarCenterButton() {
        return scrollBarCenterButton;
    }
    
    /**
     * Sets the MmgBmp that is used for the horizontal slider.
     * Changing the slider requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the horizontal slider.
     */
    public void SetScrollBarCenterButton(MmgBmp b) {
        scrollBarCenterButton = b;
    }
    
    /**
     * Gets the MmgRect dimensions for the horizontal slider.
     * 
     * @return      The MmgRect dimensions for the horizontal slider.
     */
    public MmgRect GetScrollBarCenterButtonRect() {
        return scrollBarCenterButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the horizontal slider.
     * Changing the slider dimensions requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for the horizontal slider.
     */
    public void SetScrollBarCenterButtonRect(MmgRect r) {
        scrollBarCenterButtonRect = r;
    }    
    
    /**
     * Gets the MmgBmp used for the slider up button.
     * 
     * @return      The MmgBmp used for the slider up button.
     */
    public MmgBmp GetScrollBarLeftButton() {
        return scrollBarLeftButton;
    }    
    
    /**
     * Sets the MmgBmp used for the slider up button.
     * Changing the slider up button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the slider up button.
     */
    public void SetScrollBarLeftButton(MmgBmp b) {
        scrollBarLeftButton = b;
    }    
    
    /**
     * Gets the MmgRect dimensions for the left button.
     * 
     * @return      The MmgRect used for the left button.
     */
    public MmgRect GetScrollBarLeftButtonRect() {
        return scrollBarLeftButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the left button.
     * Changing the left button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the left button.
     */
    public void SetScrollBarLeftButtonRect(MmgRect r) {
        scrollBarLeftButtonRect = r;
    }    
    
    /**
     * Gets the MmgBmp for the slider right button.
     * 
     * @return      The MmgBmp for the right button.
     */
    public MmgBmp GetScrollBarRightButton() {
        return scrollBarRightButton;
    }    
    
    /**
     * Sets the MmgBmp for the slider right button.
     * Changing the right button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp for the right button.
     */
    public void SetScrollBarRightButton(MmgBmp b) {
        scrollBarRightButton = b;
    }
    
    /**
     * Gets the MmgRect dimensions for the right button.
     * 
     * @return      The MmgRect used for the right button.
     */    
    public MmgRect GetScrollBarRightButtonRect() {
        return scrollBarRightButtonRect;
    }    
    
    /**
     * Sets the MmgRect dimensions for the right button.
     * Changing the right button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the right button.
     */    
    public void SetScrollBarRightButtonRect(MmgRect r) {
        scrollBarRightButtonRect = r;
    }
        
    /**
     * Gets the width difference between the view port and the scroll pane.
     * 
     * @return      The width difference between the view port and the scroll pane.
     */    
    public int GetWidthDiff() {
        return widthDiff;
    }

    /**
     * Sets the width difference between the view port and the scroll pane.
     * 
     * @param WidthDiff    The width difference between the view port and the scroll pane.
     */    
    public void SetWidthDiff(int WidthDiff) {
        widthDiff = WidthDiff;
    }

    /**
     * Gets the width difference percentage between the view port and the scroll pane.
     * 
     * @return      The width difference percentage between the view port and the scroll pane.
     */
    public double GetWidthDiffPrct() {
        return widthDiffPrct;
    }

    /**
     * Sets the width difference percentage between the view port and the scroll pane.
     * 
     * @param d     The width difference percentage between the view port and the scroll pane.
     */
    public void SetWidthDiffPrct(double d) {
        widthDiffPrct = d;
    }     
    
    /**
     * Gets a boolean indicating if the horizontal scroll bar is visible.
     * 
     * @return  A boolean indicating if the horizontal scroll bar is visible.
     */    
    public boolean GetScrollBarVisible() {
        return scrollBarVisible;
    }

    /**
     * Sets a boolean value indicating if the horizontal scroll bar is visible.
     * 
     * @param b       A boolean indicating if the horizontal scroll bar is visible.
     */
    public void SetScrollBarVisible(boolean b) {
        scrollBarVisible = b;
    }

    /**
     * Gets the MmgColor of the scroll bar.
     * 
     * @return      The MmgColor of the scroll bar.
     */
    public MmgColor GetScrollBarColor() {
        return scrollBarColor;
    }

    /**
     * Sets the MmgColor of the scroll bar.
     * 
     * @param c    The MmgColor of the scroll bar.
     */
    public void SetScrollBarColor(MmgColor c) {
        scrollBarColor = c;
    }

    /**
     * Gets the MmgColor of the scroll bar slider.
     * 
     * @return     The MmgColor of the scroll bar slider.
     */
    public MmgColor GetScrollBarCenterButtonColor() {
        return scrollBarCenterButtonColor;
    }

    /**
     * Sets the MmgColor of the scroll bar slider.
     * 
     * @param c      The MmgColor of the scroll bar.
     */    
    public void SetScrollBarCenterButtonColor(MmgColor c) {
        scrollBarCenterButtonColor = c;
    }

    /**
     * Gets the horizontal scroll bar height.
     * 
     * @return      The horizontal scroll bar height.
     */
    public int GetScrollBarHeight() {
        return scrollBarHeight;
    }

    /**
     * Sets the vertical scroll bar height.
     * 
     * @param h    The vertical scroll bar height.
     */    
    public void SetScrollBarHeight(int h) {
        scrollBarHeight = h;
    }

    /**
     * Gets the scroll bar slider button width.
     * 
     * @return      The scroll bar slider button width.
     */
    public int GetScrollBarLeftRightButtonWidth() {
        return scrollBarLeftRightButtonWidth;
    }

    /**
     * Sets the scroll bar slider button width.
     * 
     * @param w     The scroll bar slider button width.
     */
    public void SetScrollBarLeftRightButtonWidth(int w) {
        scrollBarLeftRightButtonWidth = w;
    }
    
    /**
     * Gets the scroll bar horizontal slider width. 
     * 
     * @return      The scroll bar horizontal slider width.
     */
    public int GetScrollBarCenterButtonWidth() {
        return scrollBarCenterButtonWidth;
    }

    /**
     * Sets the scroll bar horizontal slider width.
     * 
     * @param w       The scroll bar horizontal slider width.
     */
    public void SetScrollBarCenterButtonWidth(int w) {
        scrollBarCenterButtonWidth = w;
    }

    /**
     * Gets the interval for movement on the X axis.
     * 
     * @return      The X interval for movement.
     */
    public int GetIntervalX() {
        return intervalX;
    }

    /**
     * Sets the interval for movement on the X axis.
     * 
     * @param IntervalX     The X interval for movement.
     */
    public void SetIntervalX(int IntervalX) {
        if(IntervalX != 0) {
            intervalX = IntervalX;
            intervalPrctX = (double)intervalX / (double)widthDiff;
        } else {
            intervalX = 0;
            intervalPrctX = 0.0;
        }
    }

    /**
     * Gets a boolean indicating if the scroll view needs to be redrawn.
     * 
     * @return      A boolean indicating if the scroll view needs to be redrawn.
     */    
    public boolean GetIsDirty() {
        return isDirty;
    }

    /**
     * Sets a boolean indicating if the scroll view needs to be redrawn.
     * 
     * @param IsDirty       A boolean indicating if the scroll view needs to be redrawn.
     */
    public void SetIsDirty(boolean IsDirty) {
        isDirty = IsDirty;
    }

    /**
     * Gets the X offset.
     * 
     * @return      The X offset.
     */    
    public int GetOffsetX() {
        return offsetXScrollPane;
    }

    /**
     * Sets the X offset.
     * 
     * @param OffsetX       The X offset.
     */
    public void SetOffsetX(int OffsetX) {
        offsetXScrollPane = OffsetX;
    }
        
    /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick            The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done.
     */    
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        if(isVisible == true && isDirty == true) {
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarCenterButtonRect.GetTop()));
            scrollPaneRect.SetPosition(new MmgVector2(GetX() - offsetXScrollPane, scrollPaneRect.GetTop()));

            if(scrollBarCenterButton != null) {
                scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());                    
            }

            updSrcRect = new MmgRect(offsetXScrollPane, 0, viewPortRect.GetHeight(), offsetXScrollPane + viewPortRect.GetWidth());
            updDstRect = new MmgRect(0, 0, viewPortRect.GetHeight(), viewPortRect.GetWidth());
            
            //MmgHelper.wr("Update Source Rect: " + updSrcRect.ApiToString());
            //MmgHelper.wr("Update Dest Rect: " + updDestRect.ApiToString());                        
            
            p.DrawBmp(scrollPane, updSrcRect, updDstRect);
            
            isDirty = false;
            return true;
        }
        
        return false;
    }    
    
    /**
     * Draws this object using the given pen, MmgPen.
     *
     * @param p     The MmgPen to use to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if (MmgScrollHor.SHOW_CONTROL_BOUNDING_BOX == true) {
                c = p.GetGraphicsColor();
                
                //draw obj rect
                p.SetGraphicsColor(Color.RED);
                p.DrawRect(this);
                p.DrawRect(GetX(), GetY() + GetHeight() - scrollBarHeight, w, scrollBarHeight);

                //draw view port rect
                p.SetGraphicsColor(Color.BLUE);
                p.DrawRect(viewPortRect);
                
                //draw scroll pane rect
                p.SetGraphicsColor(Color.GREEN);
                p.DrawRect(scrollPaneRect);
                
                if(scrollBarVisible) {
                    //centre button
                    p.SetGraphicsColor(Color.ORANGE);
                    p.DrawRect(scrollBarCenterButtonRect);

                    //right button
                    p.SetGraphicsColor(Color.CYAN);
                    p.DrawRect(scrollBarRightButtonRect);

                    //left button
                    p.SetGraphicsColor(Color.PINK);
                    p.DrawRect(scrollBarLeftButtonRect);
                }
                
                p.SetGraphicsColor(c);
            }
            
            if(scrollBarVisible) {
                c = p.GetGraphicsColor();                
                if(scrollBarColor != null) {
                    p.SetGraphicsColor(scrollBarColor.GetColor());
                    p.DrawRect(new MmgRect(scrollBarLeftButtonRect.GetLeft(), scrollBarLeftButtonRect.GetTop(), scrollBarRightButtonRect.GetBottom(), scrollBarRightButtonRect.GetRight()));
                }
                
                if(scrollBarLeftButton != null) {
                    p.DrawBmp(scrollBarLeftButton);
                }
                
                if(scrollBarRightButton != null) {
                    p.DrawBmp(scrollBarRightButton);
                }
                
                if(scrollBarCenterButton != null) {
                    if(scrollBarCenterButtonColor != null) {
                        p.SetGraphicsColor(scrollBarCenterButtonColor.GetColor());
                        p.DrawRect(scrollBarCenterButtonRect);                        
                    }
                    p.DrawBmp(scrollBarCenterButton);
                }
                
                p.SetGraphicsColor(c);
            }
            
            p.DrawBmp(viewPort, GetPosition());            
        }
    }

    /**
     * A method used to check the equality of this MmgScrollHor when compared to another MmgScrollHor.
     * Compares object fields to determine equality.
     * 
     * @param obj     The MmgScrollHor object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */    
    public boolean ApiEquals(MmgScrollHor obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
            MmgHelper.wr("MmgScrollHor: MmgObj is not equals!");
        }
        
        if(!(obj.GetScrollBarVisible() == GetScrollBarVisible())) {
            MmgHelper.wr("MmgScrollHor: ScrollBarVisible is not equals!");
        }

        if(!(obj.GetIntervalX() == GetIntervalX())) {
            MmgHelper.wr("MmgScrollHor: IntervalX is not equals!");
        }        
        
        if(!(obj.GetOffsetX() == GetOffsetX())) {
            MmgHelper.wr("MmgScrollHor: OffsetX is not equals!");
        }        
        
        if(!(((obj.GetScrollBarCenterButton() == null && GetScrollBarCenterButton() == null) || (obj.GetScrollBarCenterButton() != null && GetScrollBarCenterButton() != null && obj.GetScrollBarCenterButton().Equals(GetScrollBarCenterButton()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarCenterButton is not equals!");
            
        }
        
        if(!(((obj.GetScrollBarCenterButtonColor() == null && GetScrollBarCenterButtonColor() == null) || (obj.GetScrollBarCenterButtonColor() != null && GetScrollBarCenterButtonColor() != null && obj.GetScrollBarCenterButtonColor().Equals(GetScrollBarCenterButtonColor()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarCenterButtonColor is not equals!"); 
        }
        
        if(!(((obj.GetScrollBarCenterButtonRect() == null && GetScrollBarCenterButtonRect() == null) || (obj.GetScrollBarCenterButtonRect() != null && GetScrollBarCenterButtonRect() != null && obj.GetScrollBarCenterButtonRect().Equals(GetScrollBarCenterButtonRect()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarCenterButtonRect is not equals!");
        }
        
        if(!(obj.GetScrollBarCenterButtonWidth() == GetScrollBarCenterButtonWidth())) {
            MmgHelper.wr("MmgScrollHor: ScrollBarCenterButtonWidth is not equals!");
        }
        
        if(!(((obj.GetScrollBarColor() == null && GetScrollBarColor() == null) || (obj.GetScrollBarColor() != null && GetScrollBarColor() != null && obj.GetScrollBarColor().Equals(GetScrollBarColor()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarColor is not equals!");
        }
        
        if(!(obj.GetScrollBarHeight() == GetScrollBarHeight())) {
            MmgHelper.wr("MmgScrollHor: ScrollBarHeight is not equals!");
        }
                
        if(!(((obj.GetScrollBarLeftButton() == null && GetScrollBarLeftButton() == null) || (obj.GetScrollBarLeftButton() != null && GetScrollBarLeftButton() != null && obj.GetScrollBarLeftButton().Equals(GetScrollBarLeftButton()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarLeftButton is not equals!");
        }
        
        if(!(((obj.GetScrollBarLeftButtonRect() == null && GetScrollBarLeftButtonRect() == null) || (obj.GetScrollBarLeftButtonRect() != null && GetScrollBarLeftButtonRect() != null && obj.GetScrollBarLeftButtonRect().Equals(GetScrollBarLeftButtonRect()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarLeftButtonRect is not equals!");
        }
        
        if(!(obj.GetScrollBarLeftRightButtonWidth() == GetScrollBarLeftRightButtonWidth())) {
            MmgHelper.wr("MmgScrollHor: ScrollBarLeftRightButtonWidth is not equals!");
        }
        
        if(!(((obj.GetScrollBarRightButton() == null && GetScrollBarRightButton() == null) || (obj.GetScrollBarRightButton() != null && GetScrollBarRightButton() != null && obj.GetScrollBarRightButton().Equals(GetScrollBarRightButton()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarRightButton is not equals!");            
        }
        
        if(!(((obj.GetScrollBarRightButtonRect() == null && GetScrollBarRightButtonRect() == null) || (obj.GetScrollBarRightButtonRect() != null && GetScrollBarRightButtonRect() != null && obj.GetScrollBarRightButtonRect().Equals(GetScrollBarRightButtonRect()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollBarRightButtonRect is not equals!");
        }
        
        if(!(((obj.GetScrollPane() == null && GetScrollPane() == null) || (obj.GetScrollPane() != null && GetScrollPane() != null && obj.GetScrollPane().Equals(GetScrollPane()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollPane is not equals!");
        }
        
        if(!(((obj.GetScrollPaneRect() == null && GetScrollPaneRect() == null) || (obj.GetScrollPaneRect() != null && GetScrollPaneRect() != null && obj.GetScrollPaneRect().Equals(GetScrollPaneRect()))))) {
            MmgHelper.wr("MmgScrollHor: ScrollPaneRect is not equals!");
        }
        
        if(!(((obj.GetViewPort() == null && GetViewPort() == null) || (obj.GetViewPort() != null && GetViewPort() != null && obj.GetViewPort().Equals(GetViewPort()))))) {
            MmgHelper.wr("MmgScrollHor: ViewPort is not equals!");
        }

        if(!(((obj.GetViewPortRect() == null && GetViewPortRect() == null) || (obj.GetViewPortRect() != null && GetViewPortRect() != null && obj.GetViewPortRect().Equals(GetViewPortRect()))))) {
            MmgHelper.wr("MmgScrollHor: ViewPortRect is not equals!");
        }
        
        if(!(obj.GetWidthDiff() == GetWidthDiff())) {
            MmgHelper.wr("MmgScrollHor: WidthDiff is not equals!");
        }
        
        if(!(obj.GetWidthDiffPrct() == GetWidthDiffPrct())) {
            MmgHelper.wr("MmgScrollHor: WidthDiffPrct is not equals!");
        }
        */
        
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
            && obj.GetScrollBarVisible() == GetScrollBarVisible()
            && obj.GetIntervalX() == GetIntervalX()
            && obj.GetOffsetX() == GetOffsetX()
            && ((obj.GetScrollBarCenterButton() == null && GetScrollBarCenterButton() == null) || (obj.GetScrollBarCenterButton() != null && GetScrollBarCenterButton() != null && obj.GetScrollBarCenterButton().ApiEquals(GetScrollBarCenterButton())))
            && ((obj.GetScrollBarCenterButtonColor() == null && GetScrollBarCenterButtonColor() == null) || (obj.GetScrollBarCenterButtonColor() != null && GetScrollBarCenterButtonColor() != null && obj.GetScrollBarCenterButtonColor().ApiEquals(GetScrollBarCenterButtonColor())))
            && ((obj.GetScrollBarCenterButtonRect() == null && GetScrollBarCenterButtonRect() == null) || (obj.GetScrollBarCenterButtonRect() != null && GetScrollBarCenterButtonRect() != null && obj.GetScrollBarCenterButtonRect().ApiEquals(GetScrollBarCenterButtonRect())))
            && obj.GetScrollBarCenterButtonWidth() == GetScrollBarCenterButtonWidth()
            && ((obj.GetScrollBarColor() == null && GetScrollBarColor() == null) || (obj.GetScrollBarColor() != null && GetScrollBarColor() != null && obj.GetScrollBarColor().ApiEquals(GetScrollBarColor())))
            && obj.GetScrollBarHeight() == GetScrollBarHeight()
            && ((obj.GetScrollBarLeftButton() == null && GetScrollBarLeftButton() == null) || (obj.GetScrollBarLeftButton() != null && GetScrollBarLeftButton() != null && obj.GetScrollBarLeftButton().ApiEquals(GetScrollBarLeftButton())))
            && ((obj.GetScrollBarLeftButtonRect() == null && GetScrollBarLeftButtonRect() == null) || (obj.GetScrollBarLeftButtonRect() != null && GetScrollBarLeftButtonRect() != null && obj.GetScrollBarLeftButtonRect().ApiEquals(GetScrollBarLeftButtonRect())))
            && obj.GetScrollBarLeftRightButtonWidth() == GetScrollBarLeftRightButtonWidth()
            && ((obj.GetScrollBarRightButton() == null && GetScrollBarRightButton() == null) || (obj.GetScrollBarRightButton() != null && GetScrollBarRightButton() != null && obj.GetScrollBarRightButton().ApiEquals(GetScrollBarRightButton())))                
            && ((obj.GetScrollBarRightButtonRect() == null && GetScrollBarRightButtonRect() == null) || (obj.GetScrollBarRightButtonRect() != null && GetScrollBarRightButtonRect() != null && obj.GetScrollBarRightButtonRect().ApiEquals(GetScrollBarRightButtonRect())))                
            && ((obj.GetScrollPane() == null && GetScrollPane() == null) || (obj.GetScrollPane() != null && GetScrollPane() != null && obj.GetScrollPane().ApiEquals(GetScrollPane())))            
            && ((obj.GetScrollPaneRect() == null && GetScrollPaneRect() == null) || (obj.GetScrollPaneRect() != null && GetScrollPaneRect() != null && obj.GetScrollPaneRect().ApiEquals(GetScrollPaneRect())))    
            && ((obj.GetViewPort() == null && GetViewPort() == null) || (obj.GetViewPort() != null && GetViewPort() != null && obj.GetViewPort().ApiEquals(GetViewPort())))
            && ((obj.GetViewPortRect() == null && GetViewPortRect() == null) || (obj.GetViewPortRect() != null && GetViewPortRect() != null && obj.GetViewPortRect().ApiEquals(GetViewPortRect())))
            && obj.GetWidthDiff() == GetWidthDiff()
            && obj.GetWidthDiffPrct() == GetWidthDiffPrct()
        ) {
            ret = true;
        }
        return ret;
    }
}