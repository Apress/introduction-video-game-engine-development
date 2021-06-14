package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Color;
import java.awt.Graphics2D;

/**
 * A class the provides support for a vertical scroll pane.
 * Created by Middlemind Games 01/16/2020
 * 
 * @author Victor G. Brusca
 */
public class MmgScrollVert extends MmgObj {
    
    /**
     * An MmgBmp object that is the view port for a scroll pane that sits behind the view port.
     */        
    private MmgBmp viewPort;
    
    /**
     * A rectangle with the dimensions of the view port.
     */        
    private MmgRect viewPortRect;  
    
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
     * The height of the scroll pane.
     */     
    private int scrollPaneHeight;
    
    /**
     * An MmgBmp object that is the vertical slider.
     */    
    private MmgBmp scrollBarCenterButton;
    
    /**
     * A rectangle with the dimensions of the vertical slider.
     */     
    private MmgRect scrollBarCenterButtonRect;
    
    /**
     * An MmgBmp that is the horizontal slider's top button.
     */    
    private MmgBmp scrollBarUpButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider's top button.
     */    
    private MmgRect scrollBarUpButtonRect;
    
    /**
     * An MmgBmp that is the horizontal slider's bottom button.
     */      
    private MmgBmp scrollBarDownButton;
    
    /**
     * A rectangle with the dimensions of the horizontal slider's bottom button.
     */      
    private MmgRect scrollBarDownButtonRect;
    
    /**
     * The height difference between the view port and the scroll pane.
     */      
    private int heightDiff;
    
    /**
     * The height difference percentage between the view port and the scroll pane.
     */      
    private double heightDiffPrct;
    
    /**
     * A boolean flag indicating if the vertical scroll bar is visible.
     */    
    private boolean scrollBarVisible;
    
    /**
     * An MmgColor for the horizontal scroll bar background color.
     */    
    private MmgColor scrollBarColor;
    
    /**
     * An MmgColor for the horizontal scroll bar slider's color.
     */    
    private MmgColor scrollBarCenterButtonColor;    
    
    /**
     * The vertical scroll bar width.
     */      
    private int scrollBarWidth;
    
    /**
     * The height of the vertical scroll bar slider.
     */    
    private int scrollBarCenterButtonHeight;
    
    /**
     * The height of the scroll bar slider button.
     */     
    private int scrollBarUpDownButtonHeight; 
    
    /**
     * The scroll interval of the vertical slider.
     */      
    private int intervalY;
    
    /**
     * The scroll interval percentage of the vertical slider.
     */     
    private double intervalPrctY;
    
    /**
     * A boolean flag indicating if the scroll pane needs to be updated during the MmgUpdate call.
     */    
    private boolean isDirty;
    
    /**
     * The current offset of the vertical scroll bar's slider.
     */    
    private int offsetYScrollBarCenterButton;
    
    /**
     * The current offset of the vertical scroll pane.
     */    
    private int offsetYScrollPane;
            
    /**
     * A boolean flag indicating if a bounding box should be drawn around the elements of the scroll pane.
     */    
    public static boolean SHOW_CONTROL_BOUNDING_BOX = false;
    
    /**
     * The MmgEvent to fire when a screen click occurs.
     */
    private MmgEvent clickScreen = new MmgEvent(null, "vert_click_screen", MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE, null, null);    
    
    /**
     * The MmgEvent to fire when a scroll up event occurs.
     */
    private MmgEvent clickUp = new MmgEvent(null, "vert_click_up", MmgScrollVert.SCROLL_VERT_SCROLL_UP_EVENT_ID, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE, null, null);        
    
    /**
     * The MmgEvent to fire when a scroll down event occurs.
     */
    private MmgEvent clickDown = new MmgEvent(null, "vert_click_down", MmgScrollVert.SCROLL_VERT_SCROLL_DOWN_EVENT_ID, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE, null, null);
    
    /**
     * An event type for a scroll pane click event.
     */
    public static int SCROLL_VERT_CLICK_EVENT_TYPE = 1; 
    
    /**
     * An event id for a scroll pane click event.
     */    
    public static int SCROLL_VERT_CLICK_EVENT_ID = 0;
    
    /**
     * An event id for a scroll pane up event.
     */     
    public static int SCROLL_VERT_SCROLL_UP_EVENT_ID = 1;
    
    /**
     * An event id for a scroll pane down click event.
     */     
    public static int SCROLL_VERT_SCROLL_DOWN_EVENT_ID = 2;
    
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
     * Basic constructor that sets the required objects and dimensions.
     * Prepares the drawing dimensions based on the provided objects.
     * 
     * @param ViewPort                  The MmgBmp that shows a portion of the MmgBmp scroll pane.
     * @param ScrollPane                The MmgBmp the is used to display a portion of itself to the view port.
     * @param ScrollBarColor            The MmgColor to use for the scroll bar.
     * @param ScrollBarCenterColor      The MmgColor to use for the scroll bar slider.
     * @param ScrollBarWidth                The width of the scroll bar.
     * @param ScrollBarCenterButtonHeight   The height of the scroll bar slider.
     * @param IntervalY                 The interval to use when moving the scroll bar.
     */
    public MmgScrollVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int ScrollBarWidth, int ScrollBarCenterButtonHeight, int IntervalY) {
        super();
        viewPort = ViewPort;
        scrollPane = ScrollPane;
        scrollBarWidth = ScrollBarWidth;
        scrollBarColor = ScrollBarColor;
        scrollBarCenterButtonColor = ScrollBarCenterButtonColor;
        scrollBarCenterButtonHeight = ScrollBarCenterButtonHeight;
        scrollBarUpDownButtonHeight = MmgHelper.ScaleValue(15);
        intervalY = IntervalY;        
        PrepDimensions();
        SetIntervalY(IntervalY);
    }

    /**
     * Abridged constructor that sets the required objects, colors, and dimensions.
     * Prepares the drawing dimensions based on the provided objects.
     * 
     * @param ViewPort                  The MmgBmp that shows a portion of the MmgBmp scroll pane.
     * @param ScrollPane                The MmgBmp the is used to display a portion of itself to the view port.
     * @param ScrollBarColor            The MmgColor to use for the scroll bar.
     * @param ScrollBarCenterButtonColor      The MmgColor to use for the scroll bar slider.
     * @param IntervalY                 The interval to use when moving the scroll bar.
     */
    public MmgScrollVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int IntervalY) {
        super();
        viewPort = ViewPort;
        scrollPane = ScrollPane;
        scrollBarColor = ScrollBarColor;
        scrollBarCenterButtonColor = ScrollBarCenterButtonColor;
        scrollBarWidth = MmgHelper.ScaleValue(10);
        scrollBarCenterButtonHeight = MmgHelper.ScaleValue(30);
        scrollBarUpDownButtonHeight = MmgHelper.ScaleValue(15);        
        intervalY = IntervalY;
        PrepDimensions();
        SetIntervalY(IntervalY);        
    }    
    
    /**
     * Constructor that is based on an instance of this class.
     * 
     * @param obj       An MmgScrollHor instance.
     */
    public MmgScrollVert(MmgScrollVert obj) {
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
                
        if(obj.GetScrollBarUpButton() == null) {
            SetScrollBarUpButton(obj.GetScrollBarUpButton());
        } else {
            SetScrollBarUpButton(obj.GetScrollBarUpButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarUpButtonRect() == null) {
            SetScrollBarUpButtonRect(obj.GetScrollBarUpButtonRect());
        } else {
            SetScrollBarUpButtonRect(obj.GetScrollBarUpButtonRect().Clone());
        }

        if(obj.GetScrollBarDownButton() == null) {
            SetScrollBarDownButton(obj.GetScrollBarDownButton());
        } else {
            SetScrollBarDownButton(obj.GetScrollBarDownButton().CloneTyped());
        }        
        
        if(obj.GetScrollBarDownButtonRect() == null) {
            SetScrollBarDownButtonRect(obj.GetScrollBarDownButtonRect());
        } else {
            SetScrollBarDownButtonRect(obj.GetScrollBarDownButtonRect().Clone());
        }
        
        SetHeightDiff(obj.GetHeightDiff());
        SetHeightDiffPrct(obj.GetHeightDiffPrct()); 
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
        
        SetScrollBarWidth(obj.GetScrollBarWidth());
        SetScrollBarCenterButtonHeight(obj.GetScrollBarCenterButtonHeight());
        SetScrollBarUpDownButtonHeight(obj.GetScrollBarUpDownButtonHeight());
        SetOffsetY(obj.GetOffsetY());

        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            GetPosition().SetX(obj.GetPosition().GetX());
            GetPosition().SetY(obj.GetPosition().GetY());            
        }        
        
        SetIntervalY(obj.GetIntervalY());
    }
    
    /**
     * Creates a basic clone of this class.
     * 
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgScrollVert(this);
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override    
    public MmgScrollVert CloneTyped() {
        return new MmgScrollVert(this);
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
        viewPortHeight = viewPortRect.GetHeight();
        
        scrollBarDownButton = MmgHelper.GetBasicCachedBmp("scroll_bar_down_sm.png");
        scrollBarUpButton = MmgHelper.GetBasicCachedBmp("scroll_bar_up_sm.png");
        scrollBarCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");
        if(scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null) {
            scrollBarUpDownButtonHeight = scrollBarUpButton.GetHeight();
            scrollBarWidth = scrollBarUpButton.GetWidth();
            scrollBarCenterButtonHeight = scrollBarCenterButton.GetHeight();
        }
        
        left = 0;
        top = 0;
        bottom = scrollPane.GetHeight();
        right = scrollPane.GetWidth();
        scrollPaneRect = new MmgRect(left, top, bottom, right);
        scrollPaneHeight = scrollPaneRect.GetHeight();
                        
        left = viewPort.GetWidth();
        top = scrollBarUpDownButtonHeight;
        bottom = scrollBarUpDownButtonHeight + scrollBarCenterButtonHeight;
        right = viewPort.GetWidth() + scrollBarWidth;
        scrollBarCenterButtonRect = new MmgRect(left, top, bottom, right);
        
        left = viewPort.GetWidth();
        top = 0;
        bottom = scrollBarUpDownButtonHeight;
        right = viewPort.GetWidth() + scrollBarWidth;
        scrollBarUpButtonRect = new MmgRect(left, top, bottom, right);        
        
        left = viewPort.GetWidth();
        top = viewPort.GetHeight() - scrollBarUpDownButtonHeight;
        bottom = viewPort.GetHeight();
        right = viewPort.GetWidth() + scrollBarWidth;
        scrollBarDownButtonRect = new MmgRect(left, top, bottom, right);   
           
        if(scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null) {
            scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
            scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());            
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
        int h = viewPortHeight;
        int H = scrollPaneHeight;        
        //B = b1 + b2 + b3
        int buttonHeight = (scrollBarUpDownButtonHeight + scrollBarUpDownButtonHeight + scrollBarCenterButtonHeight);        
        //S = h - B
        int scrollNotchTravel = h - buttonHeight;        
        //T = H - h;
        int scrollPaneTravel = H - h;        
        //TP = h / T
        double prctHeightDiff = (double)scrollNotchTravel / (double)scrollPaneTravel;        
        //IPS = I / S
        double intervalPrctViewPort = (double)intervalY / (double)scrollNotchTravel;        
        //IPT = I / T
        double intervalPrctScrollPane = (double)intervalY / (double)scrollPaneTravel;        
                        
        if(scrollPaneHeight - viewPortHeight > 0) {            
            heightDiff = H - scrollNotchTravel;
            heightDiffPrct = intervalPrctScrollPane;                        
            scrollBarVisible = true;            
        } else {
            heightDiff = 0;
            heightDiffPrct = 0.0;
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
     * Sets event handlers for all this object's event.
     * 
     * @param e     The MmgEventHandler to use to handle events.
     */    
    public void SetEventHandler(MmgEventHandler e) {
        clickScreen.SetTargetEventHandler(e);
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
     * Sets the X coordinate of this scroll view.
     * 
     * @param inX       The X coordinate of this scroll view.
     */
    @Override
    public void SetX(int inX) {
        super.SetX(inX);
        viewPortRect.SetPosition(new MmgVector2(inX, viewPortRect.GetTop()));
        scrollPaneRect.SetPosition(new MmgVector2(inX, scrollPaneRect.GetTop()));
        scrollBarCenterButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarCenterButtonRect.GetTop()));
        scrollBarUpButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarUpButtonRect.GetTop()));
        scrollBarDownButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarDownButtonRect.GetTop()));        
        
        if(scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null) {
            scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
            scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());            
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
        scrollBarCenterButtonRect.SetPosition(new MmgVector2(scrollBarCenterButtonRect.GetLeft(), inY + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
        scrollBarUpButtonRect.SetPosition(new MmgVector2(scrollBarUpButtonRect.GetLeft(), inY));
        scrollBarDownButtonRect.SetPosition(new MmgVector2(scrollBarDownButtonRect.GetLeft(), inY + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));
        
        if(scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null) {
            scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
            scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition()); 
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
        scrollBarCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
        scrollBarUpButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY()));
        scrollBarDownButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));
        
        if(scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null) {
            scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
            scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());            
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
        int h = viewPortHeight;
        int H = scrollPaneHeight;        
        //B = b1 + b2 + b3
        int buttonHeight = (scrollBarUpDownButtonHeight + scrollBarUpDownButtonHeight + scrollBarCenterButtonHeight);        
        //S = h - B
        int scrollNotchTravel = h - buttonHeight;        
        //T = H - h;
        int scrollPaneTravel = H - h;        
        //TP = h / T
        double prctHeightDiff = (double)scrollNotchTravel / (double)scrollPaneTravel;        
        //IPS = I / S
        double intervalPrctViewPort = (double)intervalY / (double)scrollNotchTravel;        
        //IPS = I / T
        double intervalPrctScrollPane = (double)intervalY / (double)scrollPaneTravel;                
        double currentPrct = (double)offsetYScrollBarCenterButton / (double)scrollNotchTravel;

        MmgHelper.wr("====================MmgScrollVert: h: " + h);
        MmgHelper.wr("====================MmgScrollVert: H: " + H);
        MmgHelper.wr("====================MmgScrollVert: B: " + buttonHeight);
        MmgHelper.wr("====================MmgScrollVert: S: " + scrollNotchTravel);
        MmgHelper.wr("====================MmgScrollVert: T: " + scrollPaneTravel);        
        MmgHelper.wr("====================MmgScrollVert: TP: " + prctHeightDiff);
        MmgHelper.wr("====================MmgScrollVert: IPS: " + intervalPrctViewPort);
        MmgHelper.wr("====================MmgScrollVert: IPT: " + intervalPrctScrollPane);
        MmgHelper.wr("====================MmgScrollVert: IPS2: " + heightDiffPrct);
        MmgHelper.wr("====================MmgScrollVert: C%: " + currentPrct);
        MmgHelper.wr("====================MmgScrollVert: IntY: " + intervalY);
                
        if(scrollBarVisible && dir == MmgDir.DIR_BACK) {
            if(currentPrct - heightDiffPrct < 0.0) {
                currentPrct = 0.0;
            } else {
                currentPrct -= heightDiffPrct;
            }

            if(currentPrct >= -0.002 && currentPrct <= 0.002) {
                currentPrct = 0.0;
            }

            offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

            MmgHelper.wr("====================MmgScrollVert: offsetYScrollBarCenterButton: " + offsetYScrollBarCenterButton);              
            MmgHelper.wr("====================MmgScrollVert: offsetYScrollPane: " + offsetYScrollPane);
            
            if(clickUp != null) {
                clickUp.Fire();
            }
            
            isDirty = true;
            return true;  
        } else if(scrollBarVisible && dir == MmgDir.DIR_FRONT) {
            if(currentPrct + heightDiffPrct > 1.0) {
                currentPrct = 1.0;
            } else {
                currentPrct += heightDiffPrct;                    
            }

            if(currentPrct >= 0.998 && currentPrct <= 1.002) {
                currentPrct = 1.0;
            }                

            offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

            MmgHelper.wr("====================MmgScrollVert: offsetYScrollBarCenterButton: " + offsetYScrollBarCenterButton);              
            MmgHelper.wr("====================MmgScrollVert: offsetYScrollPane: " + offsetYScrollPane);                
            
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
     * @param x     The X coordinate of the screen click event.
     * @param y     The Y coordinate of the screen click event.
     * @return      A boolean indicating if the click event was handled.
     */
    public boolean ProcessScreenClick(int x, int y) {
        boolean ret = false;
        
        int h = viewPortHeight;
        int H = scrollPaneHeight;        
        //B = b1 + b2 + b3
        int buttonHeight = (scrollBarUpDownButtonHeight + scrollBarUpDownButtonHeight + scrollBarCenterButtonHeight);        
        //S = h - B
        int scrollNotchTravel = h - buttonHeight;        
        //T = H - h;
        int scrollPaneTravel = H - h;        
        //TP = h / T
        double prctHeightDiff = (double)scrollNotchTravel / (double)scrollPaneTravel;        
        //IPS = I / S
        double intervalPrctViewPort = (double)intervalY / (double)scrollNotchTravel;        
        //IPS = I / T
        double intervalPrctScrollPane = (double)intervalY / (double)scrollPaneTravel;                
        double currentPrct = (double)offsetYScrollPane / (double)scrollPaneTravel;

        MmgHelper.wr("====================MmgScrollVert: VPh: " + h);
        MmgHelper.wr("====================MmgScrollVert: SPH: " + H);
        MmgHelper.wr("====================MmgScrollVert: B: " + buttonHeight);
        MmgHelper.wr("====================MmgScrollVert: S: " + scrollNotchTravel);
        MmgHelper.wr("====================MmgScrollVert: T: " + scrollPaneTravel);        
        MmgHelper.wr("====================MmgScrollVert: TP: " + prctHeightDiff);
        MmgHelper.wr("====================MmgScrollVert: IPS: " + intervalPrctViewPort);
        MmgHelper.wr("====================MmgScrollVert: IPT: " + intervalPrctScrollPane);
        MmgHelper.wr("====================MmgScrollVert: IPS2: " + heightDiffPrct);
        MmgHelper.wr("====================MmgScrollVert: C%: " + currentPrct);
        MmgHelper.wr("====================MmgScrollVert: IntY: " + intervalY);                
                
        if(MmgHelper.RectCollision(x, y, viewPortRect)) {
            MmgHelper.wr("====================AAA");
            if(clickScreen != null) {
                clickScreen.SetExtra(new MmgVector2(x, y));                
                clickScreen.Fire();
            }
            ret = true;
        }else if(scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarUpButtonRect)) {
            MmgHelper.wr("====================BBB");
            if(currentPrct - heightDiffPrct < 0.0) {
                currentPrct = 0.0;
            } else {
                currentPrct -= heightDiffPrct;
            }

            if(currentPrct >= -0.002 && currentPrct <= 0.002) {
                currentPrct = 0.0;
            }

            offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);
            
            if(clickUp != null) {
                clickUp.Fire();
            }            
            
            isDirty = true;
            ret = true;            
        }else if(scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarDownButtonRect)) {
            MmgHelper.wr("====================CCC");
            if(currentPrct + heightDiffPrct > 1.0) {
                currentPrct = 1.0;
            } else {
                currentPrct += heightDiffPrct;                    
            }

            if(currentPrct >= 0.998 && currentPrct <= 1.002) {
                currentPrct = 1.0;
            }                

            offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
            offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);
            
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
     * Changing the scroll pane dimensiosn requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for this scroll pane.
     */    
    public void SetScrollPaneRect(MmgRect r) {
        scrollPaneRect = r;
    }
    
    /**
     * Gets the MmgBmp that is used for the vertical slider.
     * 
     * @return      The MmgBmp used for the vertical slider.
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
     * Gets the MmgRect dimensions for the vertical slider.
     * 
     * @return      The MmgRect dimensions for the vertical slider.
     */    
    public MmgRect GetScrollBarCenterButtonRect() {
        return scrollBarCenterButtonRect;
    }
    
    /**
     * Sets the MmgRect dimensions for the vertical slider.
     * Changing the slider dimensions requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect dimensions for the vertical slider.
     */
    public void SetScrollBarCenterButtonRect(MmgRect r) {
        scrollBarCenterButtonRect = r;
    }    
           
    /**
     * Gets the MmgBmp used for the slider up button.
     * 
     * @return      The MmgBmp used for the slider up button.
     */
    public MmgBmp GetScrollBarUpButton() {
        return scrollBarUpButton;
    }    
    
    /**
     * Sets the MmgBmp used for the slider up button.
     * Changing the slider up button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp used for the slider up button.
     */
    public void SetScrollBarUpButton(MmgBmp b) {
        scrollBarUpButton = b;
    }    
    
    /**
     * Gets the MmgRect dimensions for the up button.
     * 
     * @return      The MmgRect used for the up button.
     */
    public MmgRect GetScrollBarUpButtonRect() {
        return scrollBarUpButtonRect;
    }    
    
    /**
     * Sets the MmgRect dimensions for the up button.
     * Changing the up button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the up button.
     */
    public void SetScrollBarUpButtonRect(MmgRect r) {
        scrollBarUpButtonRect = r;
    }
        
    /**
     * Gets the MmgBmp for the slider down button.
     * 
     * @return      The MmgBmp for the down button.
     */    
    public MmgBmp GetScrollBarDownButton() {
        return scrollBarDownButton;
    }    
    
    /**
     * Sets the MmgBmp for the slider down button.
     * Changing the down button requires a call to PrepDimensions.
     * 
     * @param b     The MmgBmp for the down button.
     */    
    public void SetScrollBarDownButton(MmgBmp b) {
        scrollBarDownButton = b;
    }        
    
    /**
     * Gets the MmgRect dimensions for the down button.
     * 
     * @return      The MmgRect used for the down button.
     */    
    public MmgRect GetScrollBarDownButtonRect() {
        return scrollBarDownButtonRect;
    }    
    
    /**
     * Sets the MmgRect dimensions for the down button.
     * Changing the down button requires a call to PrepDimensions.
     * 
     * @param r     The MmgRect used for the down button.
     */     
    public void SetScrollBarDownButtonRect(MmgRect r) {
        scrollBarDownButtonRect = r;
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
     * Gets a boolean indicating if the vertical scroll bar is visible.
     * 
     * @return  A boolean indicating if the vertical scroll bar is visible.
     */
    public boolean GetScrollBarVisible() {
        return scrollBarVisible;
    }

    /**
     * Sets a boolean value indicating if the vertical scroll bar is visible.
     * 
     * @param b      A boolean indicating if the vertical scroll bar is visible.
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
     * @param ScrollBarColor    The MmgColor of the scroll bar.
     */
    public void SetScrollBarColor(MmgColor ScrollBarColor) {
        scrollBarColor = ScrollBarColor;
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
     * Gets the vertical scroll bar height.
     * 
     * @return      The vertical scroll bar height.
     */    
    public int GetScrollBarWidth() {
        return scrollBarWidth;
    }

    /**
     * Sets the vertical scroll bar height.
     * 
     * @param w    The vertical scroll bar height.
     */
    public void SetScrollBarWidth(int w) {
        scrollBarWidth = w;
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
     * Gets the scroll bar vertical slider height.
     * 
     * @return      The scroll bar vertical slider height.
     */
    public int GetScrollBarCenterButtonHeight() {
        return scrollBarCenterButtonHeight;
    }

    /**
     * Sets the scroll bar vertical slider width.
     * 
     * @param ScrollBarHorSliderWidth       The scroll bar vertical slider width.
     */    
    public void SetScrollBarCenterButtonHeight(int h) {
        scrollBarCenterButtonHeight = h;
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
     * Sets the interval for movement on the Y axis.
     * 
     * @param IntervalY     The Y interval for movement.
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
        MmgHelper.wr("MmgScrollVert: MmgUpdate: " + isVisible + ", " + isDirty);
        if(isVisible == true && isDirty == true) {
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(scrollBarCenterButtonRect.GetLeft(), GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
            scrollPaneRect.SetPosition(new MmgVector2(scrollPaneRect.GetLeft(), GetY() - offsetYScrollPane));

            if(scrollBarCenterButton != null) {
                scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());                    
            }

            updSrcRect = new MmgRect(0, offsetYScrollPane, offsetYScrollPane + viewPortRect.GetHeight(), viewPortRect.GetWidth());            
            updDstRect = new MmgRect(0, 0, viewPortRect.GetHeight(), viewPortRect.GetWidth());
            
            MmgHelper.wr("Update Source Rect: " + updSrcRect.ApiToString());
            MmgHelper.wr("Update Dest Rect: " + updDstRect.ApiToString());            
            
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
            if (MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX == true) {
                c = p.GetGraphicsColor();
                
                //draw obj rect
                p.SetGraphicsColor(Color.RED);
                p.DrawRect(this);
                p.DrawRect(GetX() + GetWidth() - scrollBarWidth, GetY(), scrollBarWidth, h);
                
                //draw view port rect
                p.SetGraphicsColor(Color.BLUE);
                p.DrawRect(viewPortRect);
                
                //draw scroll pane rect
                p.SetGraphicsColor(Color.GREEN);                
                p.DrawRect(scrollPaneRect);
                
                if(scrollBarVisible) {
                    //center button
                    p.SetGraphicsColor(Color.ORANGE);
                    p.DrawRect(scrollBarCenterButtonRect);

                    //bottom button
                    p.SetGraphicsColor(Color.CYAN);
                    p.DrawRect(scrollBarDownButtonRect);

                    //top button
                    p.SetGraphicsColor(Color.PINK);
                    p.DrawRect(scrollBarUpButtonRect);
                }
                
                p.SetGraphicsColor(c);
            }

            if(scrollBarVisible) {    
                c = p.GetGraphicsColor();                
                if(scrollBarColor != null) {
                    p.SetGraphicsColor(scrollBarColor.GetColor());
                    p.DrawRect(new MmgRect(scrollBarUpButtonRect.GetLeft(), scrollBarUpButtonRect.GetTop(), scrollBarDownButtonRect.GetBottom(), scrollBarDownButtonRect.GetRight()));
                }
                
                if(scrollBarUpButton != null) {
                    p.DrawBmp(scrollBarUpButton);
                }
                
                if(scrollBarDownButton != null) {
                    p.DrawBmp(scrollBarDownButton);
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
     * A method used to check the equality of this MmgScrollVert when compared to another MmgScrollVert.
     * Compares object fields to determine equality.
     * 
     * @param obj     The MmgScrollVert object to compare to.
     * @return      A boolean indicating if the two objects are equal or not.
     */  
    public boolean ApiEquals(MmgScrollVert obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
            && obj.GetScrollBarVisible() == GetScrollBarVisible()
            && obj.GetIntervalY() == GetIntervalY()
            && obj.GetOffsetY() == GetOffsetY()
            && ((obj.GetScrollBarCenterButton() == null && GetScrollBarCenterButton() == null) || (obj.GetScrollBarCenterButton() != null && GetScrollBarCenterButton() != null && obj.GetScrollBarCenterButton().ApiEquals(GetScrollBarCenterButton())))
            && ((obj.GetScrollBarCenterButtonColor() == null && GetScrollBarCenterButtonColor() == null) || (obj.GetScrollBarCenterButtonColor() != null && GetScrollBarCenterButtonColor() != null && obj.GetScrollBarCenterButtonColor().ApiEquals(GetScrollBarCenterButtonColor())))
            && ((obj.GetScrollBarCenterButtonRect() == null && GetScrollBarCenterButtonRect() == null) || (obj.GetScrollBarCenterButtonRect() != null && GetScrollBarCenterButtonRect() != null && obj.GetScrollBarCenterButtonRect().ApiEquals(GetScrollBarCenterButtonRect())))
            && obj.GetScrollBarCenterButtonHeight() == GetScrollBarCenterButtonHeight()
            && ((obj.GetScrollBarColor() == null && GetScrollBarColor() == null) || (obj.GetScrollBarColor() != null && GetScrollBarColor() != null && obj.GetScrollBarColor().ApiEquals(GetScrollBarColor())))
            && obj.GetScrollBarWidth() == GetScrollBarWidth()
            && ((obj.GetScrollBarUpButton() == null && GetScrollBarUpButton() == null) || (obj.GetScrollBarUpButton() != null && GetScrollBarUpButton() != null && obj.GetScrollBarUpButton().ApiEquals(GetScrollBarUpButton())))
            && ((obj.GetScrollBarUpButtonRect() == null && GetScrollBarUpButtonRect() == null) || (obj.GetScrollBarUpButtonRect() != null && GetScrollBarUpButtonRect() != null && obj.GetScrollBarUpButtonRect().ApiEquals(GetScrollBarUpButtonRect())))                
            && obj.GetScrollBarUpDownButtonHeight() == GetScrollBarUpDownButtonHeight()
            && ((obj.GetScrollBarDownButton() == null && GetScrollBarDownButton() == null) || (obj.GetScrollBarDownButton() != null && GetScrollBarDownButton() != null && obj.GetScrollBarDownButton().ApiEquals(GetScrollBarDownButton())))
            && ((obj.GetScrollBarDownButtonRect() == null && GetScrollBarDownButtonRect() == null) || (obj.GetScrollBarDownButtonRect() != null && GetScrollBarDownButtonRect() != null && obj.GetScrollBarDownButtonRect().ApiEquals(GetScrollBarDownButtonRect())))
            && ((obj.GetScrollPane() == null && GetScrollPane() == null) || (obj.GetScrollPane() != null && GetScrollPane() != null && obj.GetScrollPane().ApiEquals(GetScrollPane())))
            && ((obj.GetScrollPaneRect() == null && GetScrollPaneRect() == null) || (obj.GetScrollPaneRect() != null && GetScrollPaneRect() != null && obj.GetScrollPaneRect().ApiEquals(GetScrollPaneRect())))               
            && ((obj.GetViewPort() == null && GetViewPort() == null) || (obj.GetViewPort() != null && GetViewPort() != null && obj.GetViewPort().ApiEquals(GetViewPort())))
            && ((obj.GetViewPortRect() == null && GetViewPortRect() == null) || (obj.GetViewPortRect() != null && GetViewPortRect() != null && obj.GetViewPortRect().ApiEquals(GetViewPortRect())))               
            && obj.GetHeightDiff() == GetHeightDiff()
            && obj.GetHeightDiffPrct() == GetHeightDiffPrct()
        ) {
            ret = true;
        }
        return ret;
    }    
}