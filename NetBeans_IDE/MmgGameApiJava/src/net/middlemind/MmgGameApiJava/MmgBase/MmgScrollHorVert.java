package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Color;
import java.awt.Graphics2D;

/**
 * A class the provides support for a horizontal and vertical scroll pane.
 * Created by Middlemind Games 02/26/2020
 * 
 * @author Victor G. Brusca
 */
public class MmgScrollHorVert extends MmgObj {
    
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
     * The height of the scroll pane view port.
     */
    private int viewPortHeight;
    
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
     * The height of the scroll pane.
     */
    private int scrollPaneHeight;
    
    /**
     * An MmgBmp object that is the horizontal slider.
     */
    private MmgBmp scrollBarHorCenterButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider.
     */
    private MmgRect scrollBarHorCenterButtonRect;
    
    /**
     * An MmgBmp object that is the vertical slider.
     */
    private MmgBmp scrollBarVertCenterButton;
    
    /**
     * A rectangle with the dimensions of the vertical slider.
     */
    private MmgRect scrollBarVertCenterButtonRect;    
    
    /**
     * An MmgBmp that is the horizontal slider's left button.
     */
    private MmgBmp scrollBarHorLeftButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider's left button.
     */
    private MmgRect scrollBarHorLeftButtonRect;
    
    /**
     * An MmgBmp that is the horizontal slider's right button.
     */    
    private MmgBmp scrollBarHorRightButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider's right button.
     */    
    private MmgRect scrollBarHorRightButtonRect;
    
    /**
     * An MmgBmp that is the vertical slider's top button.
     */    
    private MmgBmp scrollBarVertUpButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider's top button.
     */    
    private MmgRect scrollBarVertUpButtonRect;
    
    /**
     * An MmgBmp that is the vertical slider's bottom button.
     */    
    private MmgBmp scrollBarVertDownButton;

    /**
     * A rectangle with the dimensions of the horizontal slider's bottom button.
     */    
    private MmgRect scrollBarVertDownButtonRect;    
    
    /**
     * The width difference between the view port and the scroll pane.
     */
    private int widthDiff;
    
    /**
     * The width difference percentage between the view port and the scroll pane.
     */
    private double widthDiffPrct;
    
    /**
     * The height difference between the view port and the scroll pane.
     */    
    private int heightDiff;
    
    /**
     * The height difference percentage between the view port and the scroll pane.
     */    
    private double heightDiffPrct;    
    
    /**
     * A boolean flag indicating if the horizontal scroll bar is visible.
     */    
    private boolean scrollBarHorVisible;
    
    /**
     * A boolean flag indicating if the vertical scroll bar is visible.
     */    
    private boolean scrollBarVertVisible;  
    
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
    private int scrollBarHorHeight;
    
    /**
     * The vertical scroll bar width.
     */
    private int scrollBarVertWidth;
    
    /**
     * The width of the horizontal scroll bar slider.
     */    
    private int scrollBarHorCenterButtonWidth;
    
    /**
     * The height of the vertical scroll bar slider.
     */
    private int scrollBarVertCenterButtonHeight;
    
    /**
     * The width of the scroll bar slider button.
     */
    private int scrollBarLeftRightButtonWidth;
    
    /**
     * The height of the scroll bar slider button.
     */
    private int scrollBarUpDownButtonHeight;    
    
    /**
     * The scroll interval of the horizontal slider.
     */
    private int intervalX;
    
    /**
     * The scroll interval of the vertical slider.
     */
    private int intervalY;
    
    /**
     * The scroll interval percentage of the horizontal slider.
     */
    private double intervalPrctX;
    
    /**
     * The scroll interval percentage of the vertical slider.
     */
    private double intervalPrctY;
    
    /**
     * A boolean flag indicating if the scroll pane needs to be updated during the MmgUpdate call.
     */    
    private boolean isDirty;
    
    /**
     * The current offset of the horizontal scroll bar's slider.
     */
    private int offsetXScrollBarCenterButton;
    
    /**
     * The current offset of the vertical scroll bar's slider.
     */
    private int offsetYScrollBarCenterButton;
    
    /**
     * The current offset of the horizontal scroll pane.
     */    
    private int offsetXScrollPane;
    
    /**
     * The current offset of the vertical scroll pane.
     */    
    private int offsetYScrollPane;    
    
    /**
     * A boolean flag indicating if a bounding box should be drawn around the elements of the scroll pane.
     */    
    public static boolean SHOW_CONTROL_BOUNDING_BOX = true;    
    
    /**
     * The MmgEvent to fire when a screen click occurs.
     */
    private MmgEvent clickScreen = new MmgEvent(null, "both_click_screen", MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);    
    
    /**
     * The MmgEvent to fire when a scroll up event occurs.
     */
    private MmgEvent clickUp = new MmgEvent(null, "both_click_up", MmgScrollHorVert.SCROLL_BOTH_SCROLL_UP_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);        
    
    /**
     * The MmgEvent to fire when a scroll down event occurs.
     */
    private MmgEvent clickDown = new MmgEvent(null, "both_click_down", MmgScrollHorVert.SCROLL_BOTH_SCROLL_DOWN_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);
        
    /**
     * The MmgEvent to fire when a scroll left event occurs.
     */
    private MmgEvent clickLeft = new MmgEvent(null, "both_click_left", MmgScrollHorVert.SCROLL_BOTH_SCROLL_LEFT_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);        
    
    /**
     * The MmgEvent to fire when a scroll right event occurs.
     */
    private MmgEvent clickRight = new MmgEvent(null, "both_click_right", MmgScrollHorVert.SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);
                
    /**
     * An event type id for this object's events.
     */
    public static int SCROLL_BOTH_CLICK_EVENT_TYPE = 2;
    
    /**
     * An event id for a scroll pane click event.
     */
    public static int SCROLL_BOTH_CLICK_EVENT_ID = 6;
    
    /**
     * An event id for a scroll pane up click event.
     */
    public static int SCROLL_BOTH_SCROLL_UP_EVENT_ID = 7;
    
    /**
     * An event id for a scroll pane down click event.
     */
    public static int SCROLL_BOTH_SCROLL_DOWN_EVENT_ID = 8;
    
    /**
     * An event id for a scroll pane left click event.
     */
    public static int SCROLL_BOTH_SCROLL_LEFT_EVENT_ID = 9;
    
    /**
     * An event id for a scroll pane right click event.
     */
    public static int SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID = 10;        
    
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
    private MmgRect updDestRect;
    
    /**
     * A Color object used in the bounding box drawing of the MmgDraw method.
     */    
    private Color c;
    
    /**
     * Basic constructor that sets the required objects, colors, and dimensions.
     * Prepares the drawing dimensions based on the provided objects.
     * 
     * @param ViewPort                          The MmgBmp that shows a portion of the MmgBmp scroll pane.
     * @param ScrollPane                        The MmgBmp the is used to display a portion of itself to the view port.
     * @param ScrollBarColor                    The MmgColor to use for the scroll bar.
     * @param ScrollBarSliderColor              The MmgColor to use for the scroll bar slider.
     * @param ScrollBarHeight                   The height of the scroll bar.
     * @param ScrollBarWidth                    The width of the scroll bar.
     * @param ScrollBarVertCenterButtonHeight   The height of the scroll bar slider.
     * @param ScrollBarHorCenterButtonWidth     The width of the scroll bar slider.
     * @param IntervalX                         The interval to use when moving the scroll bar.
     * @param IntervalY                         The interval to use when moving the scroll bar.
     */    
    public MmgScrollHorVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarSliderColor, int ScrollBarHeight, int ScrollBarWidth, int ScrollBarVertCenterButtonHeight, int ScrollBarHorCenterButtonWidth, int IntervalX, int IntervalY) {
        super();
        scrollBarLeftRightButtonWidth = MmgHelper.ScaleValue(15);
        scrollBarUpDownButtonHeight = MmgHelper.ScaleValue(15);
        viewPort = ViewPort;
        scrollPane = ScrollPane;
        scrollBarHorHeight = ScrollBarHeight;
        scrollBarVertWidth = ScrollBarWidth;
        scrollBarColor = ScrollBarColor;
        scrollBarCenterButtonColor = ScrollBarSliderColor;
        scrollBarHorCenterButtonWidth = ScrollBarHorCenterButtonWidth;
        scrollBarVertCenterButtonHeight = ScrollBarVertCenterButtonHeight;
        intervalY = IntervalY;
        intervalX = IntervalX;        
        PrepDimensions();
        SetIntervalX(IntervalX);
        SetIntervalY(IntervalY);
    }

    /**
     * Abridged constructor that sets the required objects, colors, and dimensions.
     * Prepares the drawing dimensions based on the provided objects.
     * 
     * @param ViewPort                  The MmgBmp that shows a portion of the MmgBmp scroll pane.
     * @param ScrollPane                The MmgBmp the is used to display a portion of itself to the view port.
     * @param ScrollBarColor            The MmgColor to use for the scroll bar.
     * @param ScrollBarSliderColor      The MmgColor to use for the scroll bar slider.
     * @param IntervalX                 The interval to use when moving the scroll bar.
     * @param IntervalY                 The interval to use when moving the scroll bar.
     */    
    public MmgScrollHorVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarSliderColor, int IntervalX, int IntervalY) {
        super();
        scrollBarHorHeight = MmgHelper.ScaleValue(10);
        scrollBarVertWidth = MmgHelper.ScaleValue(10);
        scrollBarHorCenterButtonWidth = MmgHelper.ScaleValue(30);
        scrollBarVertCenterButtonHeight = MmgHelper.ScaleValue(30);
        scrollBarLeftRightButtonWidth = MmgHelper.ScaleValue(15);
        scrollBarUpDownButtonHeight = MmgHelper.ScaleValue(15);
        viewPort = ViewPort;
        scrollPane = ScrollPane;
        scrollBarColor = ScrollBarColor;
        scrollBarCenterButtonColor = ScrollBarSliderColor;
        intervalY = IntervalY;
        intervalX = IntervalX;
        PrepDimensions();
        SetIntervalX(IntervalX);
        SetIntervalY(IntervalY);
    }    
    
    /**
     * Constructor that is based on an instance of this class.
     * 
     * @param obj       An MmgScrollHorVert instance.
     */
    public MmgScrollHorVert(MmgScrollHorVert obj) {
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
        
        if(obj.GetScrollBarHorCenterButton() == null) {
            SetScrollBarHorCenterButton(obj.GetScrollBarHorCenterButton());
        } else {
            SetScrollBarHorCenterButton(obj.GetScrollBarHorCenterButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarHorCenterButtonRect() == null) {
            SetScrollBarHorCenterButtonRect(obj.GetScrollBarHorCenterButtonRect());
        } else {
            SetScrollBarHorCenterButtonRect(obj.GetScrollBarHorCenterButtonRect().Clone());
        }
        
        if(obj.GetScrollBarVertCenterButton() == null) {
            SetScrollBarVertCenterButton(obj.GetScrollBarVertCenterButton());
        } else {
            SetScrollBarVertCenterButton(obj.GetScrollBarVertCenterButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarVertCenterButtonRect() == null) {
            SetScrollBarVertCenterButtonRect(obj.GetScrollBarVertCenterButtonRect());
        } else {
            SetScrollBarVertCenterButtonRect(obj.GetScrollBarVertCenterButtonRect().Clone());
        }
        
        if(obj.GetScrollBarHorLeftButton() == null) {
            SetScrollBarHorLeftButton(obj.GetScrollBarHorLeftButton());
        } else {
            SetScrollBarHorLeftButton(obj.GetScrollBarHorLeftButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarHorLeftButtonRect() == null) {
            SetScrollBarHorLeftButtonRect(obj.GetScrollBarHorLeftButtonRect());
        } else {
            SetScrollBarHorLeftButtonRect(obj.GetScrollBarHorLeftButtonRect().Clone());
        }

        if(obj.GetScrollBarHorRightButton() == null) {
            SetScrollBarHorRightButton(obj.GetScrollBarHorRightButton());
        } else {
            SetScrollBarHorRightButton(obj.GetScrollBarHorRightButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarHorRightButtonRect() == null) {
            SetScrollBarHorRightButtonRect(obj.GetScrollBarHorRightButtonRect());
        } else {
            SetScrollBarHorRightButtonRect(obj.GetScrollBarHorRightButtonRect().Clone());
        }

        if(obj.GetScrollBarVertUpButton() == null) {
            SetScrollBarVertUpButton(obj.GetScrollBarVertUpButton());
        } else {
            SetScrollBarVertUpButton(obj.GetScrollBarVertUpButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarVertUpButtonRect() == null) {
            SetScrollBarVertUpButtonRect(obj.GetScrollBarVertUpButtonRect());
        } else {
            SetScrollBarVertUpButtonRect(obj.GetScrollBarVertUpButtonRect().Clone());
        }
        
        if(obj.GetScrollBarVertDownButton() == null) {
            SetScrollBarVertDownButton(obj.GetScrollBarVertDownButton());
        } else {
            SetScrollBarVertDownButton(obj.GetScrollBarVertDownButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarVertDownButtonRect() == null) {
            SetScrollBarVertDownButtonRect(obj.GetScrollBarVertDownButtonRect());
        } else {
            SetScrollBarVertDownButtonRect(obj.GetScrollBarVertDownButtonRect().Clone());
        } 
        
        SetWidthDiff(obj.GetWidthDiff());
        SetWidthDiffPrct(obj.GetWidthDiffPrct());
        SetHeightDiff(obj.GetHeightDiff());
        SetHeightDiffPrct(obj.GetHeightDiffPrct());
        SetScrollBarHorVisible(obj.GetScrollBarHorVisible());
        SetScrollBarVertVisible(obj.GetScrollBarVertVisible());
        
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
        
        SetScrollBarHorHeight(obj.GetScrollBarHorHeight());
        SetScrollBarVertWidth(obj.GetScrollBarVertWidth());
        SetScrollBarHorCenterButtonWidth(obj.GetScrollBarHorCenterButtonWidth());
        SetScrollBarVertCenterButtonHeight(obj.GetScrollBarVertCenterButtonHeight());        
        SetOffsetX(obj.GetOffsetX());
        SetOffsetY(obj.GetOffsetY());
        
        SetScrollBarLeftRightButtonWidth(obj.GetScrollBarLeftRightButtonWidth());
        SetScrollBarUpDownButtonHeight(obj.GetScrollBarUpDownButtonHeight());        
    
        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            GetPosition().SetX(obj.GetPosition().GetX());
            GetPosition().SetY(obj.GetPosition().GetY());            
        }
        
        SetIntervalX(obj.GetIntervalX());
        SetIntervalY(obj.GetIntervalY());        
    }
    
    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgScrollHorVert(this);
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override    
    public MmgScrollHorVert CloneTyped() {
        return new MmgScrollHorVert(this);
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
        viewPortHeight = viewPortRect.GetHeight();
        
        scrollBarHorLeftButton = MmgHelper.GetBasicCachedBmp("scroll_bar_left_sm.png");
        scrollBarHorRightButton = MmgHelper.GetBasicCachedBmp("scroll_bar_right_sm.png");
        scrollBarVertDownButton = MmgHelper.GetBasicCachedBmp("scroll_bar_down_sm.png");
        scrollBarVertUpButton = MmgHelper.GetBasicCachedBmp("scroll_bar_up_sm.png");
        
        scrollBarHorCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");        
        if(scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null) {
            scrollBarLeftRightButtonWidth = scrollBarHorLeftButton.GetWidth();
            scrollBarHorHeight = scrollBarHorLeftButton.GetHeight();
            scrollBarHorCenterButtonWidth = scrollBarHorCenterButton.GetWidth();            
        }
        
        scrollBarVertCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");        
        if(scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null) {
            scrollBarUpDownButtonHeight = scrollBarVertUpButton.GetHeight();
            scrollBarVertWidth = scrollBarVertUpButton.GetWidth();
            scrollBarVertCenterButtonHeight = scrollBarHorCenterButton.GetHeight();            
        }        
        
        left = 0;
        top = 0;
        bottom = scrollPane.GetHeight();
        right = scrollPane.GetWidth();
        scrollPaneRect = new MmgRect(left, top, bottom, right);
        scrollPaneWidth = scrollPaneRect.GetWidth();
        scrollPaneHeight = scrollPaneRect.GetHeight();        
        
        //slider hor
        left = scrollBarLeftRightButtonWidth;
        top = viewPort.GetHeight();
        bottom = viewPort.GetHeight() + scrollBarHorHeight;
        right = scrollBarLeftRightButtonWidth + scrollBarHorCenterButtonWidth;
        scrollBarHorCenterButtonRect = new MmgRect(left, top, bottom, right);
        
        //slider vert
        left = viewPort.GetWidth();
        top = scrollBarUpDownButtonHeight;
        bottom = scrollBarUpDownButtonHeight + scrollBarVertCenterButtonHeight;
        right = viewPort.GetWidth() + scrollBarVertWidth;
        scrollBarVertCenterButtonRect = new MmgRect(left, top, bottom, right);
        
        //button left
        left = 0;
        top = viewPort.GetHeight();
        bottom = viewPort.GetHeight() + scrollBarHorHeight;
        right = scrollBarLeftRightButtonWidth;
        scrollBarHorLeftButtonRect = new MmgRect(left, top, bottom, right);        
          
        //button right
        left = viewPort.GetWidth() - scrollBarLeftRightButtonWidth;
        top = viewPort.GetHeight();
        bottom = viewPort.GetHeight() + scrollBarHorHeight;        
        right = viewPort.GetWidth();
        scrollBarHorRightButtonRect = new MmgRect(left, top, bottom, right);   
          
        //button top
        left = viewPort.GetWidth();
        top = 0;
        bottom = scrollBarUpDownButtonHeight;
        right = viewPort.GetWidth() + scrollBarVertWidth;
        scrollBarVertUpButtonRect = new MmgRect(left, top, bottom, right);        
        
        //button bottom
        left = viewPort.GetWidth();
        top = viewPort.GetHeight() - scrollBarUpDownButtonHeight;
        bottom = viewPort.GetHeight();
        right = viewPort.GetWidth() + scrollBarVertWidth;
        scrollBarVertDownButtonRect = new MmgRect(left, top, bottom, right);           
        
        if(scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null) {
            scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
            scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());            
            scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
        }
        
        if(scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null) {
            scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
            scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());            
            scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
        }        
        
        PrepScrollPane();        
        isDirty = true;
    }
    
    /**
     * Finalizes the scroll view's preparation.
     * Called at the end of the PrepDimensions method.
     */     
    public void PrepScrollPane() {
        int h = viewPortHeight;
        int H = scrollPaneHeight;        
        //B = b1 + b2 + b3
        int buttonHeight = ((scrollBarUpDownButtonHeight * 2) + scrollBarVertCenterButtonHeight);        
        //S = h - B
        int scrollNotchTravelY = h - buttonHeight;        
        //T = H - h;
        int scrollPaneTravelY = H - h;        
        //TP = h / T
        double prctHeightDiffY = (double)scrollNotchTravelY / (double)scrollPaneTravelY;        
        //IPS = I / S
        double intervalPrctViewPortY = (double)intervalY / (double)scrollNotchTravelY;       
        //IPT = I / T
        double intervalPrctScrollPaneY = (double)intervalY / (double)scrollPaneTravelY;        
                                
        int w = viewPortWidth;
        int W = scrollPaneWidth;        
        //B = b1 + b2 + b3
        int buttonWidth = ((scrollBarLeftRightButtonWidth * 2) + scrollBarHorCenterButtonWidth);        
        //S = h - B
        int scrollNotchTravelX = w - buttonWidth;
        //T = H - h;
        int scrollPaneTravelX = W - w;        
        //TP = h / T
        double prctWidthDiffX = (double)scrollNotchTravelX / (double)scrollPaneTravelX;        
        //IPS = I / S
        double intervalPrctViewPortX = (double)intervalX / (double)scrollNotchTravelX;        
        //IPT = I / T
        double intervalPrctScrollPaneX = (double)intervalX / (double)scrollPaneTravelX;        
        
        if(scrollPaneWidth - viewPortWidth > 0) {
            widthDiff = W - scrollNotchTravelX - scrollBarLeftRightButtonWidth - scrollBarLeftRightButtonWidth - scrollBarHorCenterButtonWidth;
            widthDiffPrct = intervalPrctScrollPaneX;
            scrollBarHorVisible = true;            
        } else {
            widthDiff = 0;
            widthDiffPrct = 0.0;
            scrollBarHorVisible = false;
        }
        
        if(scrollPaneHeight - viewPortHeight > 0) {
            heightDiff = H - scrollNotchTravelY - scrollBarUpDownButtonHeight - scrollBarUpDownButtonHeight - scrollBarVertCenterButtonHeight;
            heightDiffPrct = intervalPrctScrollPaneY;
            scrollBarVertVisible = true;            
        } else {
            heightDiff = 0;
            heightDiffPrct = 0.0;
            scrollBarVertVisible = false;
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
     * Sets event handlers for all this object's event.
     * 
     * @param e     The MmgEventHandler to use to handle events.
     */    
    public void SetEventHandler(MmgEventHandler e) {
        clickScreen.SetTargetEventHandler(e);
        clickLeft.SetTargetEventHandler(e);
        clickRight.SetTargetEventHandler(e);
        clickUp.SetTargetEventHandler(e);
        clickDown.SetTargetEventHandler(e);        
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
     * Gets the scroll up event.
     * 
     * @return      The scroll up event. 
     */
    public MmgEvent GetClickUp() {
        return clickUp;
    }

    /**
     * Sets the scroll up event.
     * 
     * @param e     The scroll up event.
     */
    public void SetClickUp(MmgEvent e) {
        clickUp = e;
    }

    /**
     * Gets the scroll down event.
     * 
     * @return      The scroll down event.
     */
    public MmgEvent GetClickDown() {
        return clickDown;
    }

    /**
     * Sets the scroll down event.
     * 
     * @param e     The scroll down event.
     */
    public void SetClickDown(MmgEvent e) {
        clickDown = e;
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
        
        scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(inX + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarHorCenterButtonRect.GetTop()));
        scrollBarHorLeftButtonRect.SetPosition(new MmgVector2(inX, scrollBarHorLeftButtonRect.GetTop()));
        scrollBarHorRightButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, scrollBarHorRightButtonRect.GetTop()));        

        if(scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null) {
            scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
            scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());            
            scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
        }
        
        scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarVertCenterButtonRect.GetTop()));
        scrollBarVertUpButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarVertUpButtonRect.GetTop()));
        scrollBarVertDownButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarVertDownButtonRect.GetTop()));        
        
        if(scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null) {
            scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
            scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());            
            scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
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
        
        scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(scrollBarHorCenterButtonRect.GetLeft(), inY + viewPort.GetHeight()));
        scrollBarHorLeftButtonRect.SetPosition(new MmgVector2(scrollBarHorLeftButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));
        scrollBarHorRightButtonRect.SetPosition(new MmgVector2(scrollBarHorRightButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));

        if(scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null) {
            scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
            scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());            
            scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
        }
        
        scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(scrollBarVertCenterButtonRect.GetLeft(), inY + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
        scrollBarVertUpButtonRect.SetPosition(new MmgVector2(scrollBarVertUpButtonRect.GetLeft(), inY));
        scrollBarVertDownButtonRect.SetPosition(new MmgVector2(scrollBarVertDownButtonRect.GetLeft(), inY + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));
        
        if(scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null) {
            scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
            scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition()); 
            scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
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
        
        scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, inPos.GetY() + viewPort.GetHeight()));
        scrollBarHorLeftButtonRect.SetPosition(new MmgVector2(inPos.GetX(), inPos.GetY() + viewPort.GetHeight()));
        scrollBarHorRightButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, inPos.GetY() + viewPortRect.GetHeight()));        

        if(scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null) {
            scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
            scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());            
            scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
        }
        
        scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
        scrollBarVertUpButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY()));
        scrollBarVertDownButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));
        
        if(scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null) {
            scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
            scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());            
            scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
        }         
    }
        
    /**
     * Processes dpad input release events.
     * 
     * @param dir       The direction of the dpad input to process.
     * @return          A boolean indicating if the dpad input was handled.
     */    
    public boolean ProcessDpadRelease(int dir) {
        int h = viewPortHeight;
        int H = scrollPaneHeight;        
        //B = b1 + b2 + b3
        int buttonHeight = ((scrollBarUpDownButtonHeight * 2) + scrollBarVertCenterButtonHeight);        
        //S = h - B
        int scrollNotchTravelY = h - buttonHeight;        
        //T = H - h;
        int scrollPaneTravelY = H - h;        
        //TP = h / T
        double prctHeightDiffY = (double)scrollNotchTravelY / (double)scrollPaneTravelY;        
        //IPS = I / S
        double intervalPrctViewPortY = (double)intervalY / (double)scrollNotchTravelY;       
        //IPT = I / T
        double intervalPrctScrollPaneY = (double)intervalY / (double)scrollPaneTravelY;        
        double currentPrctY = (double)offsetYScrollPane / (double)scrollPaneTravelY;
        
        int w = viewPortWidth;
        int W = scrollPaneWidth;        
        //B = b1 + b2 + b3
        int buttonWidth = ((scrollBarLeftRightButtonWidth * 2) + scrollBarHorCenterButtonWidth);        
        //S = h - B
        int scrollNotchTravelX = w - buttonWidth;
        //T = H - h;
        int scrollPaneTravelX = W - w;        
        //TP = h / T
        double prctWidthDiffX = (double)scrollNotchTravelX / (double)scrollPaneTravelX;        
        //IPS = I / S
        double intervalPrctViewPortX = (double)intervalX / (double)scrollNotchTravelX;        
        //IPT = I / T
        double intervalPrctScrollPaneX = (double)intervalX / (double)scrollPaneTravelX;        
        double currentPrctX = (double)offsetXScrollPane / (double)scrollPaneTravelX;
                
        if(scrollBarHorVisible && dir == MmgDir.DIR_LEFT) {
            if(currentPrctX - widthDiffPrct < 0.0) {
                currentPrctX = 0.0;
            } else {
                currentPrctX -= widthDiffPrct;
            }

            if(currentPrctX >= -0.002 && currentPrctX <= 0.002) {
                currentPrctX = 0.0;
            }

            offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
            offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);
            
            if(clickLeft != null) {
                clickLeft.Fire();
            }                                    
            
            isDirty = true;
            return true;
        } else if(scrollBarHorVisible && dir == MmgDir.DIR_RIGHT) {
            if(currentPrctX + widthDiffPrct > 1.0) {
                currentPrctX = 1.0;
            } else {
                currentPrctX += widthDiffPrct;                    
            }

            if(currentPrctX >= 0.998 && currentPrctX <= 1.002) {
                currentPrctX = 1.0;
            }                

            offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
            offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);
            
            if(clickRight != null) {
                clickRight.Fire();
            }
            
            isDirty = true;            
            return true;
        } else if(scrollBarVertVisible && dir == MmgDir.DIR_BACK) {
            if(currentPrctY - heightDiffPrct < 0.0) {
                currentPrctY = 0.0;
            } else {
                currentPrctY -= heightDiffPrct;
            }

            if(currentPrctY >= -0.002 && currentPrctY <= 0.002) {
                currentPrctY = 0.0;
            }

            offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
            offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);
            
            if(clickUp != null) {
                clickUp.Fire();
            }
            
            isDirty = true;
            return true;
        } else if(scrollBarVertVisible && dir == MmgDir.DIR_FRONT) {
            if(currentPrctY + heightDiffPrct > 1.0) {
                currentPrctY = 1.0;
            } else {
                currentPrctY += heightDiffPrct;                    
            }

            if(currentPrctY >= 0.998 && currentPrctY <= 1.002) {
                currentPrctY = 1.0;
            }                

            offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
            offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);
            
            if(clickDown != null) {
                clickDown.Fire();
            }            
            
            isDirty = true;            
            return true;
        }
        return false;
    }
    
    /**
     * Handle screen click events.
     * 
     * @param x         The X coordinate of the screen click event.
     * @param y         The Y coordinate of the screen click event.
     * @return          A boolean indicating if the click event was handled.
     */
    public boolean ProcessScreenClick(int x, int y) {
        boolean ret = false;

        int h = viewPortHeight;
        int H = scrollPaneHeight;        
        //B = b1 + b2 + b3
        int buttonHeight = ((scrollBarUpDownButtonHeight * 2) + scrollBarVertCenterButtonHeight);        
        //S = h - B
        int scrollNotchTravelY = h - buttonHeight;        
        //T = H - h;
        int scrollPaneTravelY = H - h;        
        //TP = h / T
        double prctHeightDiffY = (double)scrollNotchTravelY / (double)scrollPaneTravelY;        
        //IPS = I / S
        double intervalPrctViewPortY = (double)intervalY / (double)scrollNotchTravelY;       
        //IPT = I / T
        double intervalPrctScrollPaneY = (double)intervalY / (double)scrollPaneTravelY;        
        double currentPrctY = (double)offsetYScrollPane / (double)scrollPaneTravelY;
        
        int w = viewPortWidth;
        int W = scrollPaneWidth;        
        //B = b1 + b2 + b3
        int buttonWidth = ((scrollBarLeftRightButtonWidth * 2) + scrollBarHorCenterButtonWidth);        
        //S = h - B
        int scrollNotchTravelX = h - buttonWidth;
        //T = H - h;
        int scrollPaneTravelX = W - w;        
        //TP = h / T
        double prctWidthDiffX = (double)scrollNotchTravelX / (double)scrollPaneTravelX;        
        //IPS = I / S
        double intervalPrctViewPortX = (double)intervalX / (double)scrollNotchTravelX;        
        //IPT = I / T
        double intervalPrctScrollPaneX = (double)intervalX / (double)scrollPaneTravelX;        
        double currentPrctX = (double)offsetXScrollPane / (double)scrollPaneTravelX;
        
        if(MmgHelper.RectCollision(x, y, viewPortRect)) {
            if(clickScreen != null) {
                clickScreen.SetExtra(new MmgVector2(x, y));
                clickScreen.Fire();
            }
            ret = true;
        }else if(scrollBarHorVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarHorLeftButtonRect)) {
            if(currentPrctX - widthDiffPrct < 0.0) {
                currentPrctX = 0.0;
            } else {
                currentPrctX -= widthDiffPrct;
            }

            if(currentPrctX >= -0.002 && currentPrctX <= 0.002) {
                currentPrctX = 0.0;
            }

            offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
            offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);
            
            if(clickLeft != null) {
                clickLeft.Fire();
            }
            
            isDirty = true;
            ret = true;            
        }else if(scrollBarHorVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarHorRightButtonRect)) {
            if(currentPrctX + widthDiffPrct > 1.0) {
                currentPrctX = 1.0;
            } else {
                currentPrctX += widthDiffPrct;                    
            }

            if(currentPrctX >= 0.998 && currentPrctX <= 1.002) {
                currentPrctX = 1.0;
            }                

            offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
            offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);
            
            if(clickRight != null) {
                clickRight.Fire();
            }                        
            
            isDirty = true;            
            ret = true;
        }else if(scrollBarVertVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarVertUpButtonRect)) {
            if(currentPrctY - heightDiffPrct < 0.0) {
                currentPrctY = 0.0;
            } else {
                currentPrctY -= heightDiffPrct;
            }

            if(currentPrctY >= -0.002 && currentPrctY <= 0.002) {
                currentPrctY = 0.0;
            }

            offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
            offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);
            
            if(clickUp != null) {
                clickUp.Fire();
            }                        
            
            isDirty = true;
            ret = true;
        }else if(scrollBarVertVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarVertDownButtonRect)) {            
            if(currentPrctY + heightDiffPrct > 1.0) {
                currentPrctY = 1.0;
            } else {
                currentPrctY += heightDiffPrct;                    
            }

            if(currentPrctY >= 0.998 && currentPrctY <= 1.002) {
                currentPrctY = 1.0;
            }                

            offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
            offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);
            
            if(clickDown != null) {
                clickDown.Fire();
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
    public MmgBmp GetScrollBarHorCenterButton() {
        return scrollBarHorCenterButton;
    }
    
    /**
     * Sets the MmgBmp that is used for the horizontal slider.
     * Changing the slider requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the horizontal slider.
     */    
    public void SetScrollBarHorCenterButton(MmgBmp b) {
        scrollBarHorCenterButton = b;
    }
    
    /**
     * Gets the MmgBmp that is used for the vertical slider.
     * 
     * @return      The MmgBmp used for the vertical slider.
     */    
    public MmgBmp GetScrollBarVertCenterButton() {
        return scrollBarVertCenterButton;
    }
    
    /**
     * Sets the MmgBmp that is used for the horizontal slider.
     * Changing the slider requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the horizontal slider.
     */    
    public void SetScrollBarVertCenterButton(MmgBmp b) {
        scrollBarVertCenterButton = b;
    }
    
    /**
     * Gets the MmgRect dimensions for the horizontal slider.
     * 
     * @return      The MmgRect dimensions for the horizontal slider.
     */    
    public MmgRect GetScrollBarHorCenterButtonRect() {
        return scrollBarHorCenterButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the horizontal slider.
     * Changing the slider dimensions requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for the horizontal slider.
     */    
    public void SetScrollBarHorCenterButtonRect(MmgRect r) {
        scrollBarHorCenterButtonRect = r;
    }
    
    /**
     * Gets the MmgRect dimensions for the vertical slider.
     * 
     * @return      The MmgRect dimensions for the vertical slider.
     */    
    public MmgRect GetScrollBarVertCenterButtonRect() {
        return scrollBarVertCenterButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the vertical slider.
     * Changing the slider dimensions requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for the vertical slider.
     */    
    public void SetScrollBarVertCenterButtonRect(MmgRect r) {
        scrollBarVertCenterButtonRect = r;
    }    
       
    /**
     * Gets the MmgBmp used for the slider up button.
     * 
     * @return      The MmgBmp used for the slider up button.
     */    
    public MmgBmp GetScrollBarHorLeftButton() {
        return scrollBarHorLeftButton;
    }
    
    /**
     * Sets the MmgBmp used for the slider up button.
     * Changing the slider up button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the slider up button.
     */    
    public void SetScrollBarHorLeftButton(MmgBmp b) {
        scrollBarHorLeftButton = b;
    }    
    
    /**
     * Gets the MmgRect dimensions for the left button.
     * 
     * @return      The MmgRect used for the left button.
     */    
    public MmgRect GetScrollBarHorLeftButtonRect() {
        return scrollBarHorLeftButtonRect;
    }
        
    /**
     * Sets the MmgRect dimensions for the left button.
     * Changing the left button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the left button.
     */    
    public void SetScrollBarHorLeftButtonRect(MmgRect r) {
        scrollBarHorLeftButtonRect = r;
    }    
    
    /**
     * Gets the MmgBmp for the slider right button.
     * 
     * @return      The MmgBmp for the right button.
     */    
    public MmgBmp GetScrollBarHorRightButton() {
        return scrollBarHorRightButton;
    }
    
    /**
     * Sets the MmgBmp for the slider right button.
     * Changing the right button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp for the right button.
     */    
    public void SetScrollBarHorRightButton(MmgBmp b) {
        scrollBarHorRightButton = b;
    }
    
    /**
     * Gets the MmgRect dimensions for the right button.
     * 
     * @return      The MmgRect used for the right button.
     */    
    public MmgRect GetScrollBarHorRightButtonRect() {
        return scrollBarHorRightButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the right button.
     * Changing the right button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the right button.
     */    
    public void SetScrollBarHorRightButtonRect(MmgRect r) {
        scrollBarHorRightButtonRect = r;
    }    
    
    /**
     * Gets the MmgBmp used for the slider up button.
     * 
     * @return      The MmgBmp used for the slider up button.
     */    
    public MmgBmp GetScrollBarVertUpButton() {
        return scrollBarVertUpButton;
    }
    
    /**
     * Sets the MmgBmp used for the slider up button.
     * Changing the slider up button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the slider up button.
     */    
    public void SetScrollBarVertUpButton(MmgBmp b) {
        scrollBarVertUpButton = b;
    }    

    /**
     * Gets the MmgRect dimensions for the up button.
     * 
     * @return      The MmgRect used for the up button.
     */    
    public MmgRect GetScrollBarVertUpButtonRect() {
        return scrollBarVertUpButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the up button.
     * Changing the up button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the up button.
     */    
    public void SetScrollBarVertUpButtonRect(MmgRect r) {
        scrollBarVertUpButtonRect = r;
    }    
    
    /**
     * Gets the MmgBmp for the slider down button.
     * 
     * @return      The MmgBmp for the down button.
     */     
    public MmgBmp GetScrollBarVertDownButton() {
        return scrollBarVertDownButton;
    }
    
    /**
     * Sets the MmgBmp for the slider down button.
     * Changing the down button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp for the down button.
     */     
    public void SetScrollBarVertDownButton(MmgBmp b) {
        scrollBarVertDownButton = b;
    }    
    
    /**
     * Gets the MmgRect dimensions for the down button.
     * 
     * @return      The MmgRect used for the down button.
     */     
    public MmgRect GetScrollBarVertDownButtonRect() {
        return scrollBarVertDownButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the down button.
     * Changing the down button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the down button.
     */    
    public void SetScrollBarVertDownButtonRect(MmgRect r) {
        scrollBarVertDownButtonRect = r;
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
     * @param HeightDiff    The width difference between the view port and the scroll pane.
     */     
    public void SetWidthDiff(int WidthDiff) {
        widthDiff = WidthDiff;
    }

    /**
     * Gets the height difference between the view port and the scroll pane.
     * 
     * @return      The height difference between the view port and the scroll pane.
     */    
    public int GetHeightDiff() {
        return heightDiff;
    }
    
    /**
     * Sets the height difference between the view port and the scroll pane.
     * 
     * @param HeightDiff    The height difference between the view port and the scroll pane.
     */    
    public void SetHeightDiff(int HeightDiff) {
        heightDiff = HeightDiff;
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
     * Gets the height difference percentage between the view port and the scroll pane.
     * 
     * @return      The height difference percentage between the view port and the scroll pane.
     */    
    public double GetHeightDiffPrct() {
        return heightDiffPrct;
    }    
    
     /**
     * Sets the height difference percentage between the view port and the scroll pane.
     * 
     * @param d     The height difference percentage between the view port and the scroll pane.
     */    
    public void SetHeightDiffPrct(double d) {
        heightDiffPrct = d;
    }     
    
    /**
     * Gets a boolean indicating if the horizontal scroll bar is visible.
     * 
     * @return  A boolean indicating if the horizontal scroll bar is visible.
     */      
    public boolean GetScrollBarHorVisible() {
        return scrollBarHorVisible;
    }

    /**
     * Sets a boolean value indicating if the horizontal scroll bar is visible.
     * 
     * @param b       A boolean indicating if the horizontal scroll bar is visible.
     */    
    public void SetScrollBarHorVisible(boolean b) {
        scrollBarHorVisible = b;
    }

    /**
     * Gets a boolean indicating if the vertical scroll bar is visible.
     * 
     * @return  A boolean indicating if the vertical scroll bar is visible.
     */    
    public boolean GetScrollBarVertVisible() {
        return scrollBarVertVisible;
    }

    /**
     * Sets a boolean value indicating if the vertical scroll bar is visible.
     * 
     * @param b      A boolean indicating if the vertical scroll bar is visible.
     */    
    public void SetScrollBarVertVisible(boolean b) {
        scrollBarVertVisible = b;
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
     * @return      The MmgColor of the scroll bar slider.
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
    public int GetScrollBarHorHeight() {
        return scrollBarHorHeight;
    }

    /**
     * Sets the vertical scroll bar height.
     * 
     * @param h    The vertical scroll bar height.
     */     
    public void SetScrollBarHorHeight(int h) {
        scrollBarHorHeight = h;
    }

    /**
     * Gets the vertical scroll bar height.
     * 
     * @return      The vertical scroll bar height.
     */      
    public int GetScrollBarVertWidth() {
        return scrollBarVertWidth;
    }

    /**
     * Sets the vertical scroll bar height.
     * 
     * @param w    The vertical scroll bar height.
     */    
    public void SetScrollBarVertWidth(int w) {
        scrollBarVertWidth = w;
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
     * @param w        The scroll bar slider button width.
     */    
    public void SetScrollBarLeftRightButtonWidth(int w) {
        scrollBarLeftRightButtonWidth = w;
    }
    
    /**
     * Gets the scroll bar slider button height.
     * 
     * @return      The scroll bar slider button height.
     */    
    public int GetScrollBarUpDownButtonHeight() {
        return scrollBarUpDownButtonHeight;
    }

    /**
     * Sets the scroll bar slider button height.
     * 
     * @param ScrollBarSliderButtonWidth        The scroll bar slider button height.
     */    
    public void SetScrollBarUpDownButtonHeight(int h) {
        scrollBarUpDownButtonHeight = h;
    }    
    
    /**
     * Gets the scroll bar horizontal slider width. 
     * 
     * @return      The scroll bar horizontal slider width.
     */    
    public int GetScrollBarHorCenterButtonWidth() {
        return scrollBarHorCenterButtonWidth;
    }

    /**
     * Sets the scroll bar horizontal slider width.
     * 
     * @param ScrollBarHorSliderWidth       The scroll bar horizontal slider width.
     */    
    public void SetScrollBarHorCenterButtonWidth(int w) {
        scrollBarHorCenterButtonWidth = w;
    }

    /**
     * Gets the scroll bar vertical slider height.
     * 
     * @return      The scroll bar vertical slider height.
     */    
    public int GetScrollBarVertCenterButtonHeight() {
        return scrollBarVertCenterButtonHeight;
    }

    /**
     * Sets the scroll bar vertical slider width.
     * 
     * @param ScrollBarHorSliderWidth       The scroll bar vertical slider width.
     */     
    public void SetScrollBarVertCenterButtonHeight(int h) {
        scrollBarVertCenterButtonHeight = h;
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
     * Gets the interval for movement on the Y axis.
     * 
     * @return      The Y interval for movement.
     */    
    public int GetIntervalY() {
        return intervalY;
    }    
        
    /**
     * Sets the interval for movement on the X axis.
     * 
     * @param IntervalX     The X interval for movement.
     */    
    public void SetIntervalY(int IntervalY) {
        if(IntervalY != 0) {
            intervalY = IntervalY;
            intervalPrctY = (double)intervalY / (double)heightDiff;            
        } else {
            intervalY = 0;
            intervalPrctY = 0.0;
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
     * Gets the Y offset.
     * 
     * @return      The Y offset.
     */      
    public int GetOffsetY() {
        return offsetYScrollPane;
    }

    /**
     * Sets the Y offset.
     * 
     * @param OffsetY       The Y offset.
     */    
    public void SetOffsetY(int OffsetY) {
        offsetYScrollPane = OffsetY;
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
            scrollPaneRect.SetPosition(new MmgVector2(GetX() - offsetXScrollPane, GetY() - offsetYScrollPane));

            scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarHorCenterButtonRect.GetTop()));            
            if(scrollBarHorCenterButton != null) {
                scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());                    
            }

            scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(scrollBarVertCenterButtonRect.GetLeft(), GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
            if(scrollBarVertCenterButton != null) {
                scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());                    
            }

            updSrcRect = new MmgRect(offsetXScrollPane, offsetYScrollPane, offsetYScrollPane + viewPortRect.GetHeight(), offsetXScrollPane + viewPortRect.GetWidth());
            updDestRect = new MmgRect(0, 0, viewPortRect.GetHeight(), viewPortRect.GetWidth());
            p.DrawBmp(scrollPane, updSrcRect, updDestRect);                
            
            isDirty = false;
            return true;
        }
        
        return false;
    }    
    
    /**
     * Draws this object using the given pen, MmgPen.
     *
     * @param p     The pen to use to draw this object, MmgPen.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if (MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX == true) {
                c = p.GetGraphicsColor();

                //draw obj rect
                p.SetGraphicsColor(Color.RED);
                p.DrawRect(this);
                p.DrawRect(GetX(), GetY() + GetHeight() - scrollBarHorHeight, w, scrollBarHorHeight);

                //draw view port rect
                p.SetGraphicsColor(Color.BLUE);
                p.DrawRect(viewPortRect);
                
                //draw scroll pane rect
                p.SetGraphicsColor(Color.GREEN);
                p.DrawRect(scrollPaneRect);
                
                if(scrollBarHorVisible) {
                    //slider
                    p.SetGraphicsColor(Color.ORANGE);
                    p.DrawRect(scrollBarHorCenterButtonRect);

                    //slider button bottom
                    p.SetGraphicsColor(Color.CYAN);
                    p.DrawRect(scrollBarHorRightButtonRect);

                    //slider button top
                    p.SetGraphicsColor(Color.PINK);
                    p.DrawRect(scrollBarHorLeftButtonRect);
                }
                
                if(scrollBarVertVisible) {
                    //slider
                    p.SetGraphicsColor(Color.ORANGE);
                    p.DrawRect(scrollBarVertCenterButtonRect);

                    //slider button bottom
                    p.SetGraphicsColor(Color.CYAN);
                    p.DrawRect(scrollBarVertDownButtonRect);

                    //slider button top
                    p.SetGraphicsColor(Color.PINK);
                    p.DrawRect(scrollBarVertUpButtonRect);
                }                
                
                p.SetGraphicsColor(c);
            }
                        
            if(scrollBarHorVisible) {
                c = p.GetGraphicsColor();
                if(scrollBarColor != null) {
                    p.SetGraphicsColor(scrollBarColor.GetColor());
                    p.DrawRect(new MmgRect(scrollBarHorLeftButtonRect.GetLeft(), scrollBarHorLeftButtonRect.GetTop(), scrollBarHorRightButtonRect.GetBottom(), scrollBarHorRightButtonRect.GetRight()));
                }                
                
                if(scrollBarHorLeftButton != null) {
                    p.DrawBmp(scrollBarHorLeftButton);
                }
                
                if(scrollBarHorRightButton != null) {
                    p.DrawBmp(scrollBarHorRightButton);
                }
                
                if(scrollBarHorCenterButton != null) {
                    if(scrollBarCenterButtonColor != null) {
                        p.SetGraphicsColor(scrollBarCenterButtonColor.GetColor());
                        p.DrawRect(scrollBarHorCenterButtonRect);                        
                    }                    
                    p.DrawBmp(scrollBarHorCenterButton);
                } 
                
                p.SetGraphicsColor(c);                
            }
            
            if(scrollBarVertVisible) {
                c = p.GetGraphicsColor();                
                if(scrollBarColor != null) {
                    p.SetGraphicsColor(scrollBarColor.GetColor());
                    p.DrawRect(new MmgRect(scrollBarVertUpButtonRect.GetLeft(), scrollBarVertUpButtonRect.GetTop(), scrollBarVertDownButtonRect.GetBottom(), scrollBarVertDownButtonRect.GetRight()));                    
                }
                
                if(scrollBarVertUpButton != null) {
                    p.DrawBmp(scrollBarVertUpButton);
                }
                
                if(scrollBarVertDownButton != null) {
                    p.DrawBmp(scrollBarVertDownButton);
                }
                
                if(scrollBarVertCenterButton != null) {
                    if(scrollBarCenterButtonColor != null) {
                        p.SetGraphicsColor(scrollBarCenterButtonColor.GetColor());
                        p.DrawRect(scrollBarVertCenterButtonRect);                        
                    }                    
                    p.DrawBmp(scrollBarVertCenterButton);
                }
                
                p.SetGraphicsColor(c);                
            }

            p.DrawBmp(viewPort, GetPosition());
            
        }
    }
    
    /**
     * A method used to check the equality of this MmgScrollHorVert when compared to another MmgScrollHorVert.
     * Compares object fields to determine equality.
     * 
     * @param obj     The MmgScrollHorVert object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */    
    public boolean ApiEquals(MmgScrollHorVert obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
            && obj.GetScrollBarHorVisible() == GetScrollBarHorVisible()
            && obj.GetScrollBarVertVisible() == GetScrollBarVertVisible()                
            && obj.GetIntervalX() == GetIntervalX()
            && obj.GetIntervalY() == GetIntervalY()                
            && obj.GetOffsetX() == GetOffsetX()
            && obj.GetOffsetY() == GetOffsetY()                
            && ((obj.GetScrollBarCenterButtonColor() == null && GetScrollBarCenterButtonColor() == null) || (obj.GetScrollBarCenterButtonColor() != null && GetScrollBarCenterButtonColor() != null && obj.GetScrollBarCenterButtonColor().ApiEquals(GetScrollBarCenterButtonColor())))
            && ((obj.GetScrollBarColor() == null && GetScrollBarColor() == null) || (obj.GetScrollBarColor() != null && GetScrollBarColor() != null && obj.GetScrollBarColor().ApiEquals(GetScrollBarColor())))
                
            && ((obj.GetScrollBarHorCenterButton() == null && GetScrollBarHorCenterButton() == null) || (obj.GetScrollBarHorCenterButton() != null && GetScrollBarHorCenterButton() != null && obj.GetScrollBarHorCenterButton().ApiEquals(GetScrollBarHorCenterButton())))
            && ((obj.GetScrollBarHorCenterButtonRect() == null && GetScrollBarHorCenterButtonRect() == null) || (obj.GetScrollBarHorCenterButtonRect() != null && GetScrollBarHorCenterButtonRect() != null && obj.GetScrollBarHorCenterButtonRect().ApiEquals(GetScrollBarHorCenterButtonRect())))            
            && obj.GetScrollBarHorCenterButtonWidth() == GetScrollBarHorCenterButtonWidth()
                
            && ((obj.GetScrollBarVertCenterButton() == null && GetScrollBarVertCenterButton() == null) || (obj.GetScrollBarVertCenterButton() != null && GetScrollBarVertCenterButton() != null && obj.GetScrollBarVertCenterButton().ApiEquals(GetScrollBarVertCenterButton())))
            && ((obj.GetScrollBarVertCenterButtonRect() == null && GetScrollBarVertCenterButtonRect() == null) || (obj.GetScrollBarVertCenterButtonRect() != null && GetScrollBarVertCenterButtonRect() != null && obj.GetScrollBarVertCenterButtonRect().ApiEquals(GetScrollBarVertCenterButtonRect())))            
            && obj.GetScrollBarVertCenterButtonHeight() == GetScrollBarVertCenterButtonHeight()                
                
            && obj.GetScrollBarHorHeight() == GetScrollBarHorHeight()
            && obj.GetScrollBarVertWidth() == GetScrollBarVertWidth()                
            && obj.GetScrollBarLeftRightButtonWidth() == GetScrollBarLeftRightButtonWidth()
            && obj.GetScrollBarUpDownButtonHeight() == GetScrollBarUpDownButtonHeight()
                
            && ((obj.GetScrollBarHorLeftButton() == null && GetScrollBarHorLeftButton() == null) || (obj.GetScrollBarHorLeftButton() != null && GetScrollBarHorLeftButton() != null && obj.GetScrollBarHorLeftButton().ApiEquals(GetScrollBarHorLeftButton())))
            && ((obj.GetScrollBarHorLeftButtonRect() == null && GetScrollBarHorLeftButtonRect() == null) || (obj.GetScrollBarHorLeftButtonRect() != null && GetScrollBarHorLeftButtonRect() != null && obj.GetScrollBarHorLeftButtonRect().ApiEquals(GetScrollBarHorLeftButtonRect())))                

            && ((obj.GetScrollBarHorRightButton() == null && GetScrollBarHorRightButton() == null) || (obj.GetScrollBarHorRightButton() != null && GetScrollBarHorRightButton() != null && obj.GetScrollBarHorRightButton().ApiEquals(GetScrollBarHorRightButton())))
            && ((obj.GetScrollBarHorRightButtonRect() == null && GetScrollBarHorRightButtonRect() == null) || (obj.GetScrollBarHorRightButtonRect() != null && GetScrollBarHorRightButtonRect() != null && obj.GetScrollBarHorRightButtonRect().ApiEquals(GetScrollBarHorRightButtonRect())))                

            && ((obj.GetScrollBarVertUpButton() == null && GetScrollBarVertUpButton() == null) || (obj.GetScrollBarVertUpButton() != null && GetScrollBarVertUpButton() != null && obj.GetScrollBarVertUpButton().ApiEquals(GetScrollBarVertUpButton())))
            && ((obj.GetScrollBarVertUpButtonRect() == null && GetScrollBarVertUpButtonRect() == null) || (obj.GetScrollBarVertUpButtonRect() != null && GetScrollBarVertUpButtonRect() != null && obj.GetScrollBarVertUpButtonRect().ApiEquals(GetScrollBarVertUpButtonRect())))                
                
            && ((obj.GetScrollBarVertDownButton() == null && GetScrollBarVertDownButton() == null) || (obj.GetScrollBarVertDownButton() != null && GetScrollBarVertDownButton() != null && obj.GetScrollBarVertDownButton().ApiEquals(GetScrollBarVertDownButton())))
            && ((obj.GetScrollBarVertDownButtonRect() == null && GetScrollBarVertDownButtonRect() == null) || (obj.GetScrollBarVertDownButtonRect() != null && GetScrollBarVertDownButtonRect() != null && obj.GetScrollBarVertDownButtonRect().ApiEquals(GetScrollBarVertDownButtonRect())))                                
                
            && ((obj.GetScrollPane() == null && GetScrollPane() == null) || (obj.GetScrollPane() != null && GetScrollPane() != null && obj.GetScrollPane().ApiEquals(GetScrollPane())))
            && ((obj.GetScrollPaneRect() == null && GetScrollPaneRect() == null) || (obj.GetScrollPaneRect() != null && GetScrollPaneRect() != null && obj.GetScrollPaneRect().ApiEquals(GetScrollPaneRect())))               
            && ((obj.GetViewPort() == null && GetViewPort() == null) || (obj.GetViewPort() != null && GetViewPort() != null && obj.GetViewPort().ApiEquals(GetViewPort())))
            && ((obj.GetViewPortRect() == null && GetViewPortRect() == null) || (obj.GetViewPortRect() != null && GetViewPortRect() != null && obj.GetViewPortRect().ApiEquals(GetViewPortRect())))               
            
            && obj.GetWidthDiff() == GetWidthDiff()
            && obj.GetWidthDiffPrct() == GetWidthDiffPrct()
            && obj.GetHeightDiff() == GetHeightDiff()
            && obj.GetHeightDiffPrct() == GetHeightDiffPrct()                
        ) {
            ret = true;
        }
        return ret;
    }    
}