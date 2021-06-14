using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class the provides support for a horizontal and vertical scroll pane.
    /// Created by Middlemind Games 02/26/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgScrollHorVert : MmgObj
    {
        /// <summary>
        /// An MmgBmp object that is the view port for a scroll pane that sits behind the view port.
        /// </summary>
        private MmgBmp viewPort;

        /// <summary>
        /// A rectangle with the dimensions of the view port.
        /// </summary>
        private MmgRect viewPortRect;

        /// <summary>
        /// The width of the scroll pane view port.
        /// </summary>
        private int viewPortWidth;

        /// <summary>
        /// The height of the scroll pane view port.
        /// </summary>
        private int viewPortHeight;

        /// <summary>
        /// An MmgBmp object that is the scroll pane to show a portion of through the view port.
        /// </summary>
        private MmgBmp scrollPane;

        /// <summary>
        /// A rectangle with the dimensions of the scroll pane. 
        /// </summary>
        private MmgRect scrollPaneRect;

        /// <summary>
        /// The width of the scroll pane. 
        /// </summary>
        private int scrollPaneWidth;

        /// <summary>
        /// The height of the scroll pane.
        /// </summary>
        private int scrollPaneHeight;

        /// <summary>
        /// An MmgBmp object that is the horizontal slider. 
        /// </summary>
        private MmgBmp scrollBarHorCenterButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider.
        /// </summary>
        private MmgRect scrollBarHorCenterButtonRect;

        /// <summary>
        /// An MmgBmp object that is the vertical slider.
        /// </summary>
        private MmgBmp scrollBarVertCenterButton;

        /// <summary>
        /// A rectangle with the dimensions of the vertical slider.
        /// </summary>
        private MmgRect scrollBarVertCenterButtonRect;

        /// <summary>
        /// An MmgBmp that is the horizontal slider's left button.
        /// </summary>
        private MmgBmp scrollBarHorLeftButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's left button.
        /// </summary>
        private MmgRect scrollBarHorLeftButtonRect;

        /// <summary>
        /// An MmgBmp that is the horizontal slider's right button.
        /// </summary>
        private MmgBmp scrollBarHorRightButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's right button.
        /// </summary>
        private MmgRect scrollBarHorRightButtonRect;

        /// <summary>
        /// An MmgBmp that is the vertical slider's top button.
        /// </summary>
        private MmgBmp scrollBarVertUpButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's top button. 
        /// </summary>
        private MmgRect scrollBarVertUpButtonRect;

        /// <summary>
        /// An MmgBmp that is the vertical slider's bottom button. 
        /// </summary>
        private MmgBmp scrollBarVertDownButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's bottom button. 
        /// </summary>
        private MmgRect scrollBarVertDownButtonRect;

        /// <summary>
        /// The width difference between the view port and the scroll pane.
        /// </summary>
        private int widthDiff;

        /// <summary>
        /// The width difference percentage between the view port and the scroll pane.
        /// </summary>
        private double widthDiffPrct;

        /// <summary>
        /// The height difference between the view port and the scroll pane.
        /// </summary>
        private int heightDiff;

        /// <summary>
        /// The height difference percentage between the view port and the scroll pane.
        /// </summary>
        private double heightDiffPrct;

        /// <summary>
        /// A bool flag indicating if the horizontal scroll bar is visible. 
        /// </summary>
        private bool scrollBarHorVisible;

        /// <summary>
        /// A bool flag indicating if the vertical scroll bar is visible. 
        /// </summary>
        private bool scrollBarVertVisible;

        /// <summary>
        /// An MmgColor for the horizontal scroll bar background color. 
        /// </summary>
        private MmgColor scrollBarColor;

        /// <summary>
        /// An MmgColor for the horizontal scroll bar slider's color. 
        /// </summary>
        private MmgColor scrollBarCenterButtonColor;

        /// <summary>
        /// The horizontal scroll bar height.
        /// </summary>
        private int scrollBarHorHeight;

        /// <summary>
        /// The vertical scroll bar width.
        /// </summary>
        private int scrollBarVertWidth;

        /// <summary>
        /// The width of the horizontal scroll bar slider.
        /// </summary>
        private int scrollBarHorCenterButtonWidth;

        /// <summary>
        /// The height of the vertical scroll bar slider.
        /// </summary>
        private int scrollBarVertCenterButtonHeight;

        /// <summary>
        /// The width of the scroll bar slider button.
        /// </summary>
        private int scrollBarLeftRightButtonWidth;

        /// <summary>
        /// The height of the scroll bar slider button.
        /// </summary>
        private int scrollBarUpDownButtonHeight;

        /// <summary>
        /// The scroll interval of the horizontal slider. 
        /// </summary>
        private int intervalX;

        /// <summary>
        /// The scroll interval of the vertical slider.
        /// </summary>
        private int intervalY;

        /// <summary>
        /// The scroll interval percentage of the horizontal slider.
        /// </summary>
        private double intervalPrctX;

        /// <summary>
        /// The scroll interval percentage of the vertical slider.
        /// </summary>
        private double intervalPrctY;

        /// <summary>
        /// A bool flag indicating if the scroll pane needs to be updated during the MmgUpdate call.
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// The current offset of the horizontal scroll bar's slider.
        /// </summary>
        private int offsetXScrollBarCenterButton;

        /// <summary>
        /// The current offset of the vertical scroll bar's slider. 
        /// </summary>
        private int offsetYScrollBarCenterButton;

        /// <summary>
        /// The current offset of the horizontal scroll pane. 
        /// </summary>
        private int offsetXScrollPane;

        /// <summary>
        /// The current offset of the vertical scroll pane. 
        /// </summary>
        private int offsetYScrollPane;

        /// <summary>
        /// A bool flag indicating if a bounding box should be drawn around the elements of the scroll pane.
        /// </summary>
        public static bool SHOW_CONTROL_BOUNDING_BOX = false;

        /// <summary>
        /// The MmgEvent to fire when a screen click occurs.
        /// </summary>
        private MmgEvent clickScreen = new MmgEvent(null, "both_click_screen", MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll up event occurs.
        /// </summary>
        private MmgEvent clickUp = new MmgEvent(null, "both_click_up", MmgScrollHorVert.SCROLL_BOTH_SCROLL_UP_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll down event occurs.
        /// </summary>
        private MmgEvent clickDown = new MmgEvent(null, "both_click_down", MmgScrollHorVert.SCROLL_BOTH_SCROLL_DOWN_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll left event occurs.
        /// </summary>
        private MmgEvent clickLeft = new MmgEvent(null, "both_click_left", MmgScrollHorVert.SCROLL_BOTH_SCROLL_LEFT_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll right event occurs.
        /// </summary>
        private MmgEvent clickRight = new MmgEvent(null, "both_click_right", MmgScrollHorVert.SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID, MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// An event type id for this object's events. 
        /// </summary>
        public static int SCROLL_BOTH_CLICK_EVENT_TYPE = 2;

        /// <summary>
        /// An event id for a scroll pane click event. 
        /// </summary>
        public static int SCROLL_BOTH_CLICK_EVENT_ID = 6;

        /// <summary>
        /// An event id for a scroll pane up click event.
        /// </summary>
        public static int SCROLL_BOTH_SCROLL_UP_EVENT_ID = 7;

        /// <summary>
        /// An event id for a scroll pane down click event.
        /// </summary>
        public static int SCROLL_BOTH_SCROLL_DOWN_EVENT_ID = 8;

        /// <summary>
        /// An event id for a scroll pane left click event.
        /// </summary>
        public static int SCROLL_BOTH_SCROLL_LEFT_EVENT_ID = 9;

        /// <summary>
        /// An event id for a scroll pane right click event.
        /// </summary>
        public static int SCROLL_BOTH_SCROLL_RIGHT_EVENT_ID = 10;

        /// <summary>
        /// An MmgPen object instance used to draw the visible portion of the scroll pane to the view port.
        /// </summary>
        private MmgPen p;

        /// <summary>
        /// An MmgRect used in the MmgUpdate method.
        /// </summary>
        private MmgRect updSrcRect;

        /// <summary>
        /// An MmgRect used in the MmgUpdate method.
        /// </summary>
        private MmgRect updDstRect;

        /// <summary>
        /// A Color object used in the bounding box drawing of the MmgDraw method. 
        /// </summary>
        private Color c;

        /// <summary>
        /// Basic constructor that sets the required objects, colors, and dimensions.
        /// Prepares the drawing dimensions based on the provided objects.
        /// </summary>
        /// <param name="ViewPort">The MmgBmp that shows a portion of the MmgBmp scroll pane.</param>
        /// <param name="ScrollPane">The MmgBmp the is used to display a portion of itself to the view port.</param>
        /// <param name="ScrollBarColor">The MmgColor to use for the scroll bar.</param>
        /// <param name="ScrollBarSliderColor">The MmgColor to use for the scroll bar slider.</param>
        /// <param name="ScrollBarHeight">The height of the scroll bar.</param>
        /// <param name="ScrollBarWidth">The width of the scroll bar.</param>
        /// <param name="ScrollBarVertCenterButtonHeight">The height of the scroll bar slider.</param>
        /// <param name="ScrollBarHorCenterButtonWidth">The width of the scroll bar slider.</param>
        /// <param name="IntervalX">The interval to use when moving the scroll bar.</param>
        /// <param name="IntervalY">The interval to use when moving the scroll bar.</param>
        public MmgScrollHorVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarSliderColor, int ScrollBarHeight, int ScrollBarWidth, int ScrollBarVertCenterButtonHeight, int ScrollBarHorCenterButtonWidth, int IntervalX, int IntervalY) : base()
        {
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

        /// <summary>
        /// Abridged constructor that sets the required objects, colors, and dimensions.
        /// Prepares the drawing dimensions based on the provided objects.
        /// </summary>
        /// <param name="ViewPort">The MmgBmp that shows a portion of the MmgBmp scroll pane.</param>
        /// <param name="ScrollPane">The MmgBmp the is used to display a portion of itself to the view port.</param>
        /// <param name="ScrollBarColor">The MmgColor to use for the scroll bar.</param>
        /// <param name="ScrollBarSliderColor">The MmgColor to use for the scroll bar slider.</param>
        /// <param name="IntervalX">The interval to use when moving the scroll bar.</param>
        /// <param name="IntervalY">The interval to use when moving the scroll bar.</param>
        public MmgScrollHorVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarSliderColor, int IntervalX, int IntervalY) : base()
        {
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

        /// <summary>
        /// Constructor that is based on an instance of this class.
        /// </summary>
        /// <param name="obj">An MmgScrollHorVert instance.</param>
        public MmgScrollHorVert(MmgScrollHorVert obj) : base()
        {
            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            if (obj.GetViewPort() == null)
            {
                SetViewPort(obj.GetViewPort());
            }
            else
            {
                SetViewPort(obj.GetViewPort().CloneTyped());
            }

            if (obj.GetViewPortRect() == null)
            {
                SetViewPortRect(obj.GetViewPortRect());
            }
            else
            {
                SetViewPortRect(obj.GetViewPortRect().Clone());
            }

            if (obj.GetScrollPane() == null)
            {
                SetScrollPane(obj.GetScrollPane());
            }
            else
            {
                SetScrollPane(obj.GetScrollPane().CloneTyped());
            }

            if (obj.GetScrollPaneRect() == null)
            {
                SetScrollPaneRect(obj.GetScrollPaneRect());
            }
            else
            {
                SetScrollPaneRect(obj.GetScrollPaneRect().Clone());
            }

            if (obj.GetScrollBarHorCenterButton() == null)
            {
                SetScrollBarHorCenterButton(obj.GetScrollBarHorCenterButton());
            }
            else
            {
                SetScrollBarHorCenterButton(obj.GetScrollBarHorCenterButton().CloneTyped());
            }

            if (obj.GetScrollBarHorCenterButtonRect() == null)
            {
                SetScrollBarHorCenterButtonRect(obj.GetScrollBarHorCenterButtonRect());
            }
            else
            {
                SetScrollBarHorCenterButtonRect(obj.GetScrollBarHorCenterButtonRect().Clone());
            }

            if (obj.GetScrollBarVertCenterButton() == null)
            {
                SetScrollBarVertCenterButton(obj.GetScrollBarVertCenterButton());
            }
            else
            {
                SetScrollBarVertCenterButton(obj.GetScrollBarVertCenterButton().CloneTyped());
            }

            if (obj.GetScrollBarVertCenterButtonRect() == null)
            {
                SetScrollBarVertCenterButtonRect(obj.GetScrollBarVertCenterButtonRect());
            }
            else
            {
                SetScrollBarVertCenterButtonRect(obj.GetScrollBarVertCenterButtonRect().Clone());
            }

            if (obj.GetScrollBarHorLeftButton() == null)
            {
                SetScrollBarHorLeftButton(obj.GetScrollBarHorLeftButton());
            }
            else
            {
                SetScrollBarHorLeftButton(obj.GetScrollBarHorLeftButton().CloneTyped());
            }

            if (obj.GetScrollBarHorLeftButtonRect() == null)
            {
                SetScrollBarHorLeftButtonRect(obj.GetScrollBarHorLeftButtonRect());
            }
            else
            {
                SetScrollBarHorLeftButtonRect(obj.GetScrollBarHorLeftButtonRect().Clone());
            }

            if (obj.GetScrollBarHorRightButton() == null)
            {
                SetScrollBarHorRightButton(obj.GetScrollBarHorRightButton());
            }
            else
            {
                SetScrollBarHorRightButton(obj.GetScrollBarHorRightButton().CloneTyped());
            }

            if (obj.GetScrollBarHorRightButtonRect() == null)
            {
                SetScrollBarHorRightButtonRect(obj.GetScrollBarHorRightButtonRect());
            }
            else
            {
                SetScrollBarHorRightButtonRect(obj.GetScrollBarHorRightButtonRect().Clone());
            }

            if (obj.GetScrollBarVertUpButton() == null)
            {
                SetScrollBarVertUpButton(obj.GetScrollBarVertUpButton());
            }
            else
            {
                SetScrollBarVertUpButton(obj.GetScrollBarVertUpButton().CloneTyped());
            }

            if (obj.GetScrollBarVertUpButtonRect() == null)
            {
                SetScrollBarVertUpButtonRect(obj.GetScrollBarVertUpButtonRect());
            }
            else
            {
                SetScrollBarVertUpButtonRect(obj.GetScrollBarVertUpButtonRect().Clone());
            }

            if (obj.GetScrollBarVertDownButton() == null)
            {
                SetScrollBarVertDownButton(obj.GetScrollBarVertDownButton());
            }
            else
            {
                SetScrollBarVertDownButton(obj.GetScrollBarVertDownButton().CloneTyped());
            }

            if (obj.GetScrollBarVertDownButtonRect() == null)
            {
                SetScrollBarVertDownButtonRect(obj.GetScrollBarVertDownButtonRect());
            }
            else
            {
                SetScrollBarVertDownButtonRect(obj.GetScrollBarVertDownButtonRect().Clone());
            }

            SetWidthDiff(obj.GetWidthDiff());
            SetWidthDiffPrct(obj.GetWidthDiffPrct());
            SetHeightDiff(obj.GetHeightDiff());
            SetHeightDiffPrct(obj.GetHeightDiffPrct());
            SetScrollBarHorVisible(obj.GetScrollBarHorVisible());
            SetScrollBarVertVisible(obj.GetScrollBarVertVisible());

            if (obj.GetScrollBarColor() == null)
            {
                SetScrollBarColor(obj.GetScrollBarColor());
            }
            else
            {
                SetScrollBarColor(obj.GetScrollBarColor().Clone());
            }

            if (obj.GetScrollBarCenterButtonColor() == null)
            {
                SetScrollBarCenterButtonColor(obj.GetScrollBarCenterButtonColor());
            }
            else
            {
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

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                GetPosition().SetX(obj.GetPosition().GetX());
                GetPosition().SetY(obj.GetPosition().GetY());
            }

            SetIntervalX(obj.GetIntervalX());
            SetIntervalY(obj.GetIntervalY());
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgScrollHorVert(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgScrollHorVert CloneTyped()
        {
            return new MmgScrollHorVert(this);
        }

        /// <summary>
        /// Prepares the dimension of the scroll view, scroll bar, slider, and buttons.
        /// </summary>
        public virtual void PrepDimensions()
        {
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
            if (scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null)
            {
                scrollBarLeftRightButtonWidth = scrollBarHorLeftButton.GetWidth();
                scrollBarHorHeight = scrollBarHorLeftButton.GetHeight();
                scrollBarHorCenterButtonWidth = scrollBarHorCenterButton.GetWidth();
            }

            scrollBarVertCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");
            if (scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null)
            {
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

            if (scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null)
            {
                scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
                scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());
                scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
            }

            if (scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null)
            {
                scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
                scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());
                scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
            }

            PrepScrollPane();
            isDirty = true;
        }

        /// <summary>
        /// Finalizes the scroll view's preparation.
        /// Called at the end of the PrepDimensions method.
        /// </summary>
        public virtual void PrepScrollPane()
        {
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
            int scrollNotchTravelX = h - buttonWidth;
            //T = H - h;
            int scrollPaneTravelX = W - w;
            //TP = h / T
            double prctWidthDiffX = (double)scrollNotchTravelX / (double)scrollPaneTravelX;
            //IPS = I / S
            double intervalPrctViewPortX = (double)intervalX / (double)scrollNotchTravelX;
            //IPT = I / T
            double intervalPrctScrollPaneX = (double)intervalX / (double)scrollPaneTravelX;

            if (scrollPaneWidth - viewPortWidth > 0)
            {
                widthDiff = W - scrollNotchTravelX - scrollBarLeftRightButtonWidth - scrollBarLeftRightButtonWidth - scrollBarHorCenterButtonWidth;
                widthDiffPrct = intervalPrctScrollPaneX;
                scrollBarHorVisible = true;
            }
            else
            {
                widthDiff = 0;
                widthDiffPrct = 0.0;
                scrollBarHorVisible = false;
            }

            if (scrollPaneHeight - viewPortHeight > 0)
            {
                heightDiff = H - scrollNotchTravelY - scrollBarUpDownButtonHeight - scrollBarUpDownButtonHeight - scrollBarVertCenterButtonHeight;
                heightDiffPrct = intervalPrctScrollPaneY;
                scrollBarVertVisible = true;
            }
            else
            {
                heightDiff = 0;
                heightDiffPrct = 0.0;
                scrollBarVertVisible = false;
            }

            p = new MmgPen(viewPort.GetImage());
            p.SetAdvRenderHints();
        }

        /// <summary>
        /// Returns the target event handler of the clickScreen MmgEvent class field.
        /// </summary>
        /// <returns>The MmgEventHandler to use to handle events.</returns>
        public virtual MmgEventHandler GetEventHandler()
        {
            if (clickScreen != null)
            {
                return clickScreen.GetTargetEventHandler();
            }

            return null;
        }

        /// <summary>
        /// Sets event handlers for all this object's event.
        /// </summary>
        /// <param name="e">The MmgEventHandler to use to handle events.</param>
        public virtual void SetEventHandler(MmgEventHandler e)
        {
            clickScreen.SetTargetEventHandler(e);
            clickLeft.SetTargetEventHandler(e);
            clickRight.SetTargetEventHandler(e);
            clickUp.SetTargetEventHandler(e);
            clickDown.SetTargetEventHandler(e);
        }

        /// <summary>
        /// Gets the click screen event.
        /// </summary>
        /// <returns>The click screen event.</returns>
        public virtual MmgEvent GetClickScreen()
        {
            return clickScreen;
        }

        /// <summary>
        /// Sets the click screen event.
        /// </summary>
        /// <param name="e">The click screen event.</param>
        public virtual void SetClickScreen(MmgEvent e)
        {
            clickScreen = e;
        }

        /// <summary>
        /// Gets the scroll up event.
        /// </summary>
        /// <returns>The scroll up event.</returns>
        public virtual MmgEvent GetClickUp()
        {
            return clickUp;
        }

        /// <summary>
        /// Sets the scroll up event.
        /// </summary>
        /// <param name="e">The scroll up event.</param>
        public virtual void SetClickUp(MmgEvent e)
        {
            clickUp = e;
        }

        /// <summary>
        /// Gets the scroll down event.
        /// </summary>
        /// <returns>The scroll down event.</returns>
        public virtual MmgEvent GetClickDown()
        {
            return clickDown;
        }

        /// <summary>
        /// Sets the scroll down event.
        /// </summary>
        /// <param name="e">The scroll down event.</param>
        public virtual void SetClickDown(MmgEvent e)
        {
            clickDown = e;
        }

        /// <summary>
        /// Gets the scroll left event.
        /// </summary>
        /// <returns>The scroll left event.</returns>
        public virtual MmgEvent GetClickLeft()
        {
            return clickLeft;
        }

        /// <summary>
        /// Sets the scroll left event.
        /// </summary>
        /// <param name="e">The scroll left event.</param>
        public virtual void SetClickLeft(MmgEvent e)
        {
            clickLeft = e;
        }

        /// <summary>
        /// Gets the scroll right event.
        /// </summary>
        /// <returns>The scroll right event.</returns>
        public virtual MmgEvent GetClickRight()
        {
            return clickRight;
        }

        /// <summary>
        /// Sets the scroll right event.
        /// </summary>
        /// <param name="e">The scroll right event.</param>
        public virtual void SetClickRight(MmgEvent e)
        {
            clickRight = e;
        }

        /// <summary>
        /// Sets the X coordinate of this scroll view.
        /// </summary>
        /// <param name="inX">The X coordinate of this scroll view.</param>
        public override void SetX(int inX)
        {
            base.SetX(inX);
            viewPortRect.SetPosition(new MmgVector2(inX, viewPortRect.GetTop()));
            scrollPaneRect.SetPosition(new MmgVector2(inX, scrollPaneRect.GetTop()));

            scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(inX + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarHorCenterButtonRect.GetTop()));
            scrollBarHorLeftButtonRect.SetPosition(new MmgVector2(inX, scrollBarHorLeftButtonRect.GetTop()));
            scrollBarHorRightButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, scrollBarHorRightButtonRect.GetTop()));

            if (scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null)
            {
                scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
                scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());
                scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
            }

            scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarVertCenterButtonRect.GetTop()));
            scrollBarVertUpButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarVertUpButtonRect.GetTop()));
            scrollBarVertDownButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarVertDownButtonRect.GetTop()));

            if (scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null)
            {
                scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
                scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());
                scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
            }
        }

        /// <summary>
        /// Sets the Y coordinate of this scroll view.
        /// </summary>
        /// <param name="inY">The Y coordinate of this scroll view.</param>
        public override void SetY(int inY)
        {
            base.SetX(inY);
            viewPortRect.SetPosition(new MmgVector2(viewPortRect.GetLeft(), inY));
            scrollPaneRect.SetPosition(new MmgVector2(scrollPaneRect.GetLeft(), inY));

            scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(scrollBarHorCenterButtonRect.GetLeft(), inY + viewPort.GetHeight()));
            scrollBarHorLeftButtonRect.SetPosition(new MmgVector2(scrollBarHorLeftButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));
            scrollBarHorRightButtonRect.SetPosition(new MmgVector2(scrollBarHorRightButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));

            if (scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null)
            {
                scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
                scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());
                scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
            }

            scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(scrollBarVertCenterButtonRect.GetLeft(), inY + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
            scrollBarVertUpButtonRect.SetPosition(new MmgVector2(scrollBarVertUpButtonRect.GetLeft(), inY));
            scrollBarVertDownButtonRect.SetPosition(new MmgVector2(scrollBarVertDownButtonRect.GetLeft(), inY + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));

            if (scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null)
            {
                scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
                scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());
                scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
            }
        }

        /// <summary>
        /// Sets the position of the scroll view.
        /// </summary>
        /// <param name="x">The X coordinate of the position.</param>
        /// <param name="y">The Y coordinate of the position.</param>
        public override void SetPosition(int x, int y)
        {
            SetPosition(new MmgVector2(x, y));
        }

        /// <summary>
        /// Sets the position of the scroll view.
        /// </summary>
        /// <param name="inPos">The position to set the scroll view.</param>
        public override void SetPosition(MmgVector2 inPos)
        {
            base.SetPosition(inPos);
            viewPortRect.SetPosition(inPos);
            scrollPaneRect.SetPosition(inPos);

            scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, inPos.GetY() + viewPort.GetHeight()));
            scrollBarHorLeftButtonRect.SetPosition(new MmgVector2(inPos.GetX(), inPos.GetY() + viewPort.GetHeight()));
            scrollBarHorRightButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, inPos.GetY() + viewPortRect.GetHeight()));

            if (scrollBarHorLeftButton != null && scrollBarHorRightButton != null && scrollBarHorCenterButton != null)
            {
                scrollBarHorLeftButton.SetPosition(scrollBarHorLeftButtonRect.GetPosition());
                scrollBarHorRightButton.SetPosition(scrollBarHorRightButtonRect.GetPosition());
                scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
            }

            scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
            scrollBarVertUpButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY()));
            scrollBarVertDownButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));

            if (scrollBarVertUpButton != null && scrollBarVertDownButton != null && scrollBarVertCenterButton != null)
            {
                scrollBarVertUpButton.SetPosition(scrollBarVertUpButtonRect.GetPosition());
                scrollBarVertDownButton.SetPosition(scrollBarVertDownButtonRect.GetPosition());
                scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
            }
        }

        /// <summary>
        /// Processes dpad input release events.
        /// </summary>
        /// <param name="dir">The direction of the dpad input to process.</param>
        /// <returns>A bool indicating if the dpad input was handled.</returns>
        public virtual bool ProcessDpadRelease(int dir)
        {
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

            if (scrollBarHorVisible && dir == MmgDir.DIR_LEFT)
            {
                if (currentPrctX - widthDiffPrct < 0.0)
                {
                    currentPrctX = 0.0;
                }
                else
                {
                    currentPrctX -= widthDiffPrct;
                }

                if (currentPrctX >= -0.002 && currentPrctX <= 0.002)
                {
                    currentPrctX = 0.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
                offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);

                if (clickLeft != null)
                {
                    clickLeft.Fire();
                }

                isDirty = true;
                return true;
            }
            else if (scrollBarHorVisible && dir == MmgDir.DIR_RIGHT)
            {
                if (currentPrctX + widthDiffPrct > 1.0)
                {
                    currentPrctX = 1.0;
                }
                else
                {
                    currentPrctX += widthDiffPrct;
                }

                if (currentPrctX >= 0.998 && currentPrctX <= 1.002)
                {
                    currentPrctX = 1.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
                offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);

                if (clickRight != null)
                {
                    clickRight.Fire();
                }

                isDirty = true;
                return true;
            }
            else if (scrollBarVertVisible && dir == MmgDir.DIR_BACK)
            {
                if (currentPrctY - heightDiffPrct < 0.0)
                {
                    currentPrctY = 0.0;
                }
                else
                {
                    currentPrctY -= heightDiffPrct;
                }

                if (currentPrctY >= -0.002 && currentPrctY <= 0.002)
                {
                    currentPrctY = 0.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
                offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);

                if (clickUp != null)
                {
                    clickUp.Fire();
                }

                isDirty = true;
                return true;
            }
            else if (scrollBarVertVisible && dir == MmgDir.DIR_FRONT)
            {
                if (currentPrctY + heightDiffPrct > 1.0)
                {
                    currentPrctY = 1.0;
                }
                else
                {
                    currentPrctY += heightDiffPrct;
                }

                if (currentPrctY >= 0.998 && currentPrctY <= 1.002)
                {
                    currentPrctY = 1.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
                offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);

                if (clickDown != null)
                {
                    clickDown.Fire();
                }

                isDirty = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Handle screen click events.
        /// </summary>
        /// <param name="x">The X coordinate of the screen click event.</param>
        /// <param name="y">The Y coordinate of the screen click event.</param>
        /// <returns>A bool indicating if the click event was handled.</returns>
        public virtual bool ProcessScreenClick(int x, int y)
        {
            bool ret = false;

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

            if (MmgHelper.RectCollision(x, y, viewPortRect))
            {
                if (clickScreen != null)
                {
                    clickScreen.SetExtra(new MmgVector2(x, y));
                    clickScreen.Fire();
                }
                ret = true;
            }
            else if (scrollBarHorVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarHorLeftButtonRect))
            {
                if (currentPrctX - widthDiffPrct < 0.0)
                {
                    currentPrctX = 0.0;
                }
                else
                {
                    currentPrctX -= widthDiffPrct;
                }

                if (currentPrctX >= -0.002 && currentPrctX <= 0.002)
                {
                    currentPrctX = 0.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
                offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);

                if (clickLeft != null)
                {
                    clickLeft.Fire();
                }

                isDirty = true;
                ret = true;
            }
            else if (scrollBarHorVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarHorRightButtonRect))
            {
                if (currentPrctX + widthDiffPrct > 1.0)
                {
                    currentPrctX = 1.0;
                }
                else
                {
                    currentPrctX += widthDiffPrct;
                }

                if (currentPrctX >= 0.998 && currentPrctX <= 1.002)
                {
                    currentPrctX = 1.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrctX * (double)scrollNotchTravelX);
                offsetXScrollPane = (int)(currentPrctX * (double)scrollPaneTravelX);

                if (clickRight != null)
                {
                    clickRight.Fire();
                }

                isDirty = true;
                ret = true;
            }
            else if (scrollBarVertVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarVertUpButtonRect))
            {
                if (currentPrctY - heightDiffPrct < 0.0)
                {
                    currentPrctY = 0.0;
                }
                else
                {
                    currentPrctY -= heightDiffPrct;
                }

                if (currentPrctY >= -0.002 && currentPrctY <= 0.002)
                {
                    currentPrctY = 0.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
                offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);

                if (clickUp != null)
                {
                    clickUp.Fire();
                }

                isDirty = true;
                ret = true;
            }
            else if (scrollBarVertVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarVertDownButtonRect))
            {
                if (currentPrctY + heightDiffPrct > 1.0)
                {
                    currentPrctY = 1.0;
                }
                else
                {
                    currentPrctY += heightDiffPrct;
                }

                if (currentPrctY >= 0.998 && currentPrctY <= 1.002)
                {
                    currentPrctY = 1.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrctY * (double)scrollNotchTravelY);
                offsetYScrollPane = (int)(currentPrctY * (double)scrollPaneTravelY);

                if (clickDown != null)
                {
                    clickDown.Fire();
                }

                isDirty = true;
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Gets the current view port for scroll view.
        /// </summary>
        /// <returns>The view port for scroll view.</returns>
        public virtual MmgBmp GetViewPort()
        {
            return viewPort;
        }

        /// <summary>
        /// Sets the current view port for this scroll view.
        /// Changing the view port requires a call to PrepDimensions.
        /// </summary>
        /// <param name="ViewPort">The view port for this scroll view.</param>
        public virtual void SetViewPort(MmgBmp ViewPort)
        {
            viewPort = ViewPort;
        }

        /// <summary>
        /// Gets the scroll pane for this scroll view.
        /// </summary>
        /// <returns>The scroll pane for this scroll view.</returns>
        public virtual MmgBmp GetScrollPane()
        {
            return scrollPane;
        }

        /// <summary>
        /// Sets the scroll pane for this scroll view.
        /// Changing the scroll pane requires a call to PrepDimensions.
        /// </summary>
        /// <param name="ScrollPane">The scroll pane for this scroll view.</param>
        public virtual void SetScrollPane(MmgBmp ScrollPane)
        {
            scrollPane = ScrollPane;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the view port.
        /// </summary>
        /// <returns>The MmgRect dimensions for the view port.</returns>
        public virtual MmgRect GetViewPortRect()
        {
            return viewPortRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the view port.
        /// Changing the view port dimensions requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect dimensions for the view ports.</param>
        public virtual void SetViewPortRect(MmgRect r)
        {
            viewPortRect = r;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the scroll pane.
        /// </summary>
        /// <returns>The MmgRect dimensions for the scroll pane.</returns>
        public virtual MmgRect GetScrollPaneRect()
        {
            return scrollPaneRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the scroll pane.
        /// Changing the scroll pane dimensions requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect dimensions for this scroll pane.</param>
        public virtual void SetScrollPaneRect(MmgRect r)
        {
            scrollPaneRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp that is used for the horizontal slider.
        /// </summary>
        /// <returns>The MmgBmp used for the horizontal slider.</returns>
        public virtual MmgBmp GetScrollBarHorCenterButton()
        {
            return scrollBarHorCenterButton;
        }

        /// <summary>
        /// Sets the MmgBmp that is used for the horizontal slider.
        /// Changing the slider requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the horizontal slider.</param>
        public virtual void SetScrollBarHorCenterButton(MmgBmp b)
        {
            scrollBarHorCenterButton = b;
        }

        /// <summary>
        /// Gets the MmgBmp that is used for the vertical slider.
        /// </summary>
        /// <returns>The MmgBmp used for the vertical slider.</returns>
        public virtual MmgBmp GetScrollBarVertCenterButton()
        {
            return scrollBarVertCenterButton;
        }

        /// <summary>
        /// Sets the MmgBmp that is used for the horizontal slider.
        /// Changing the slider requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the horizontal slider.</param>
        public virtual void SetScrollBarVertCenterButton(MmgBmp b)
        {
            scrollBarVertCenterButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the horizontal slider.
        /// </summary>
        /// <returns>The MmgRect dimensions for the horizontal slider.</returns>
        public virtual MmgRect GetScrollBarHorCenterButtonRect()
        {
            return scrollBarHorCenterButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the horizontal slider.
        /// Changing the slider dimensions requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect dimensions for the horizontal slider.</param>
        public virtual void SetScrollBarHorCenterButtonRect(MmgRect r)
        {
            scrollBarHorCenterButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the vertical slider.
        /// </summary>
        /// <returns>The MmgRect dimensions for the vertical slider.</returns>
        public virtual MmgRect GetScrollBarVertCenterButtonRect()
        {
            return scrollBarVertCenterButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the vertical slider.
        /// Changing the slider dimensions requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect dimensions for the vertical slider.</param>
        public virtual void SetScrollBarVertCenterButtonRect(MmgRect r)
        {
            scrollBarVertCenterButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp used for the slider up button.
        /// </summary>
        /// <returns>The MmgBmp used for the slider up button.</returns>
        public virtual MmgBmp GetScrollBarHorLeftButton()
        {
            return scrollBarHorLeftButton;
        }

        /// <summary>
        /// Sets the MmgBmp used for the slider up button.
        /// Changing the slider up button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the slider up button.</param>
        public virtual void SetScrollBarHorLeftButton(MmgBmp b)
        {
            scrollBarHorLeftButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the left button.
        /// </summary>
        /// <returns>The MmgRect used for the left button.</returns>
        public virtual MmgRect GetScrollBarHorLeftButtonRect()
        {
            return scrollBarHorLeftButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the left button.
        /// Changing the left button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the left button.</param>
        public virtual void SetScrollBarHorLeftButtonRect(MmgRect r)
        {
            scrollBarHorLeftButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp for the slider right button.
        /// </summary>
        /// <returns>The MmgBmp for the right button.</returns>
        public virtual MmgBmp GetScrollBarHorRightButton()
        {
            return scrollBarHorRightButton;
        }

        /// <summary>
        /// Sets the MmgBmp for the slider right button.
        /// Changing the right button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp for the right button.</param>
        public virtual void SetScrollBarHorRightButton(MmgBmp b)
        {
            scrollBarHorRightButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the right button.
        /// </summary>
        /// <returns>The MmgRect used for the right button.</returns>
        public virtual MmgRect GetScrollBarHorRightButtonRect()
        {
            return scrollBarHorRightButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the right button.
        /// Changing the right button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the right button.</param>
        public virtual void SetScrollBarHorRightButtonRect(MmgRect r)
        {
            scrollBarHorRightButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp used for the slider up button.
        /// </summary>
        /// <returns>The MmgBmp used for the slider up button.</returns>
        public virtual MmgBmp GetScrollBarVertUpButton()
        {
            return scrollBarVertUpButton;
        }

        /// <summary>
        /// Sets the MmgBmp used for the slider up button.
        /// Changing the slider up button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the slider up button.</param>
        public virtual void SetScrollBarVertUpButton(MmgBmp b)
        {
            scrollBarVertUpButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the up button.
        /// </summary>
        /// <returns>The MmgRect used for the up button.</returns>
        public virtual MmgRect GetScrollBarVertUpButtonRect()
        {
            return scrollBarVertUpButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the up button.
        /// Changing the up button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r"></param>
        public virtual void SetScrollBarVertUpButtonRect(MmgRect r)
        {
            scrollBarVertUpButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp for the slider down button.
        /// </summary>
        /// <returns>The MmgBmp for the down button.</returns>
        public virtual MmgBmp GetScrollBarVertDownButton()
        {
            return scrollBarVertDownButton;
        }

        /// <summary>
        /// Sets the MmgBmp for the slider down button.
        /// Changing the down button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp for the down button.</param>
        public virtual void SetScrollBarVertDownButton(MmgBmp b)
        {
            scrollBarVertDownButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the down button.
        /// </summary>
        /// <returns>The MmgRect used for the down button.</returns>
        public virtual MmgRect GetScrollBarVertDownButtonRect()
        {
            return scrollBarVertDownButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the down button.
        /// Changing the down button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the down button.</param>
        public virtual void SetScrollBarVertDownButtonRect(MmgRect r)
        {
            scrollBarVertDownButtonRect = r;
        }

        /// <summary>
        /// Gets the width difference between the view port and the scroll pane.
        /// </summary>
        /// <returns>The width difference between the view port and the scroll pane.</returns>
        public virtual int GetWidthDiff()
        {
            return widthDiff;
        }

        /// <summary>
        /// Sets the width difference between the view port and the scroll pane.
        /// </summary>
        /// <param name="WidthDiff">The width difference between the view port and the scroll pane.</param>
        public virtual void SetWidthDiff(int WidthDiff)
        {
            widthDiff = WidthDiff;
        }

        /// <summary>
        /// Gets the height difference between the view port and the scroll pane.
        /// </summary>
        /// <returns>The height difference between the view port and the scroll pane.</returns>
        public virtual int GetHeightDiff()
        {
            return heightDiff;
        }

        /// <summary>
        /// Sets the height difference between the view port and the scroll pane.
        /// </summary>
        /// <param name="HeightDiff">The height difference between the view port and the scroll pane.</param>
        public virtual void SetHeightDiff(int HeightDiff)
        {
            heightDiff = HeightDiff;
        }

        /// <summary>
        /// Gets the width difference percentage between the view port and the scroll pane.
        /// </summary>
        /// <returns>The width difference percentage between the view port and the scroll pane.</returns>
        public virtual double GetWidthDiffPrct()
        {
            return widthDiffPrct;
        }

        /// <summary>
        /// Sets the width difference percentage between the view port and the scroll pane.
        /// </summary>
        /// <param name="d">The width difference percentage between the view port and the scroll pane.</param>
        public virtual void SetWidthDiffPrct(double d)
        {
            widthDiffPrct = d;
        }

        /// <summary>
        /// Gets the height difference percentage between the view port and the scroll pane.
        /// </summary>
        /// <returns>The height difference percentage between the view port and the scroll pane.</returns>
        public virtual double GetHeightDiffPrct()
        {
            return heightDiffPrct;
        }

        /// <summary>
        /// Sets the height difference percentage between the view port and the scroll pane.
        /// </summary>
        /// <param name="d">The height difference percentage between the view port and the scroll pane.</param>
        public virtual void SetHeightDiffPrct(double d)
        {
            heightDiffPrct = d;
        }

        /// <summary>
        /// Gets a bool indicating if the horizontal scroll bar is visible.
        /// </summary>
        /// <returns>A bool indicating if the horizontal scroll bar is visible.</returns>
        public virtual bool GetScrollBarHorVisible()
        {
            return scrollBarHorVisible;
        }

        /// <summary>
        /// Sets a bool value indicating if the horizontal scroll bar is visible.
        /// </summary>
        /// <param name="b">A bool indicating if the horizontal scroll bar is visible.</param>
        public virtual void SetScrollBarHorVisible(bool b)
        {
            scrollBarHorVisible = b;
        }

        /// <summary>
        /// Gets a bool indicating if the vertical scroll bar is visible.
        /// </summary>
        /// <returns>A bool indicating if the vertical scroll bar is visible.</returns>
        public virtual bool GetScrollBarVertVisible()
        {
            return scrollBarVertVisible;
        }

        /// <summary>
        /// Sets a bool value indicating if the vertical scroll bar is visible.
        /// </summary>
        /// <param name="b">A bool indicating if the vertical scroll bar is visible.</param>
        public virtual void SetScrollBarVertVisible(bool b)
        {
            scrollBarVertVisible = b;
        }

        /// <summary>
        /// Gets the MmgColor of the scroll bar.
        /// </summary>
        /// <returns>The MmgColor of the scroll bar.</returns>
        public virtual MmgColor GetScrollBarColor()
        {
            return scrollBarColor;
        }

        /// <summary>
        /// Sets the MmgColor of the scroll bar.
        /// </summary>
        /// <param name="c">The MmgColor of the scroll bar.</param>
        public virtual void SetScrollBarColor(MmgColor c)
        {
            scrollBarColor = c;
        }

        /// <summary>
        /// Gets the MmgColor of the scroll bar slider.
        /// </summary>
        /// <returns>The MmgColor of the scroll bar slider.</returns>
        public virtual MmgColor GetScrollBarCenterButtonColor()
        {
            return scrollBarCenterButtonColor;
        }

        /// <summary>
        /// Sets the MmgColor of the scroll bar slider.
        /// </summary>
        /// <param name="c">The MmgColor of the scroll bar.</param>
        public virtual void SetScrollBarCenterButtonColor(MmgColor c)
        {
            scrollBarCenterButtonColor = c;
        }

        /// <summary>
        /// Gets the horizontal scroll bar height.
        /// </summary>
        /// <returns>The horizontal scroll bar height.</returns>
        public virtual int GetScrollBarHorHeight()
        {
            return scrollBarHorHeight;
        }

        /// <summary>
        /// Sets the vertical scroll bar height.
        /// </summary>
        /// <param name="h">The vertical scroll bar height.</param>
        public virtual void SetScrollBarHorHeight(int h)
        {
            scrollBarHorHeight = h;
        }

        /// <summary>
        /// Gets the vertical scroll bar height.
        /// </summary>
        /// <returns>The vertical scroll bar height.</returns>
        public virtual int GetScrollBarVertWidth()
        {
            return scrollBarVertWidth;
        }

        /// <summary>
        /// Sets the vertical scroll bar height.
        /// </summary>
        /// <param name="w">The vertical scroll bar height.</param>
        public virtual void SetScrollBarVertWidth(int w)
        {
            scrollBarVertWidth = w;
        }

        /// <summary>
        /// Gets the scroll bar slider button width.
        /// </summary>
        /// <returns>The scroll bar slider button width.</returns>
        public virtual int GetScrollBarLeftRightButtonWidth()
        {
            return scrollBarLeftRightButtonWidth;
        }

        /// <summary>
        /// Sets the scroll bar slider button width.
        /// </summary>
        /// <param name="w">The scroll bar slider button width.</param>
        public virtual void SetScrollBarLeftRightButtonWidth(int w)
        {
            scrollBarLeftRightButtonWidth = w;
        }

        /// <summary>
        /// Gets the scroll bar slider button height.
        /// </summary>
        /// <returns>The scroll bar slider button height.</returns>
        public virtual int GetScrollBarUpDownButtonHeight()
        {
            return scrollBarUpDownButtonHeight;
        }

        /// <summary>
        /// Sets the scroll bar slider button height.
        /// </summary>
        /// <param name="h">The scroll bar slider button height.</param>
        public virtual void SetScrollBarUpDownButtonHeight(int h)
        {
            scrollBarUpDownButtonHeight = h;
        }

        /// <summary>
        /// Gets the scroll bar horizontal slider width.
        /// </summary>
        /// <returns>The scroll bar horizontal slider width.</returns>
        public virtual int GetScrollBarHorCenterButtonWidth()
        {
            return scrollBarHorCenterButtonWidth;
        }

        /// <summary>
        /// Sets the scroll bar horizontal slider width.
        /// </summary>
        /// <param name="w">The scroll bar horizontal slider width.</param>
        public virtual void SetScrollBarHorCenterButtonWidth(int w)
        {
            scrollBarHorCenterButtonWidth = w;
        }

        /// <summary>
        /// Gets the scroll bar vertical slider height.
        /// </summary>
        /// <returns>The scroll bar vertical slider height.</returns>
        public virtual int GetScrollBarVertCenterButtonHeight()
        {
            return scrollBarVertCenterButtonHeight;
        }

        /// <summary>
        /// Sets the scroll bar vertical slider width.
        /// </summary>
        /// <param name="h">The scroll bar vertical slider width.</param>
        public virtual void SetScrollBarVertCenterButtonHeight(int h)
        {
            scrollBarVertCenterButtonHeight = h;
        }

        /// <summary>
        /// Gets the interval for movement on the X axis.
        /// </summary>
        /// <returns>The X interval for movement.</returns>
        public virtual int GetIntervalX()
        {
            return intervalX;
        }

        /// <summary>
        /// Sets the interval for movement on the X axis.
        /// </summary>
        /// <param name="IntervalX">The X interval for movement.</param>
        public virtual void SetIntervalX(int IntervalX)
        {
            if (IntervalX != 0)
            {
                intervalX = IntervalX;
                intervalPrctX = (double)intervalX / (double)widthDiff;
            }
            else
            {
                intervalX = 0;
                intervalPrctX = 0.0;
            }
        }

        /// <summary>
        /// Gets the interval for movement on the Y axis.
        /// </summary>
        /// <returns>The Y interval for movement.</returns>
        public virtual int GetIntervalY()
        {
            return intervalY;
        }

        /// <summary>
        /// Sets the interval for movement on the X axis.
        /// </summary>
        /// <param name="IntervalY">The X interval for movement.</param>
        public virtual void SetIntervalY(int IntervalY)
        {
            if (IntervalY != 0)
            {
                intervalY = IntervalY;
                intervalPrctY = (double)intervalY / (double)heightDiff;
            }
            else
            {
                intervalY = 0;
                intervalPrctY = 0.0;
            }
        }

        /// <summary>
        /// Gets a bool indicating if the scroll view needs to be redrawn.
        /// </summary>
        /// <returns>A bool indicating if the scroll view needs to be redrawn.</returns>
        public virtual bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Sets a bool indicating if the scroll view needs to be redrawn.
        /// </summary>
        /// <param name="IsDirty">A bool indicating if the scroll view needs to be redrawn.</param>
        public virtual void SetIsDirty(bool IsDirty)
        {
            isDirty = IsDirty;
        }

        /// <summary>
        /// Gets the X offset.
        /// </summary>
        /// <returns>The X offset.</returns>
        public virtual int GetOffsetX()
        {
            return offsetXScrollPane;
        }

        /// <summary>
        /// Sets the X offset.
        /// </summary>
        /// <param name="OffsetX">The X offset.</param>
        public virtual void SetOffsetX(int OffsetX)
        {
            offsetXScrollPane = OffsetX;
        }

        /// <summary>
        /// Gets the Y offset.
        /// </summary>
        /// <returns>The Y offset.</returns>
        public virtual int GetOffsetY()
        {
            return offsetYScrollPane;
        }

        /// <summary>
        /// Sets the Y offset.
        /// </summary>
        /// <param name="OffsetY">The Y offset.</param>
        public virtual void SetOffsetY(int OffsetY)
        {
            offsetYScrollPane = OffsetY;
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            if (isVisible == true && isDirty == true)
            {
                scrollPaneRect.SetPosition(new MmgVector2(GetX() - offsetXScrollPane, GetY() - offsetYScrollPane));

                scrollBarHorCenterButtonRect.SetPosition(new MmgVector2(GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarHorCenterButtonRect.GetTop()));
                if (scrollBarHorCenterButton != null)
                {
                    scrollBarHorCenterButton.SetPosition(scrollBarHorCenterButtonRect.GetPosition());
                }

                scrollBarVertCenterButtonRect.SetPosition(new MmgVector2(scrollBarVertCenterButtonRect.GetLeft(), GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
                if (scrollBarVertCenterButton != null)
                {
                    scrollBarVertCenterButton.SetPosition(scrollBarVertCenterButtonRect.GetPosition());
                }

                updSrcRect = new MmgRect(offsetXScrollBarCenterButton, offsetYScrollBarCenterButton, offsetYScrollBarCenterButton + viewPortRect.GetHeight(), offsetXScrollBarCenterButton + viewPortRect.GetWidth());
                updDstRect = new MmgRect(0, 0, viewPortRect.GetHeight(), viewPortRect.GetWidth());

                p.GetGraphics().GraphicsDevice.SetRenderTarget((RenderTarget2D)viewPort.GetImage());
                p.GetGraphics().Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                p.DrawBmp(scrollPane, updSrcRect, updDstRect);
                p.GetGraphics().End();
                p.GetGraphics().GraphicsDevice.SetRenderTarget(null);

                isDirty = false;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Draws this object using the given pen, MmgPen.
        /// </summary>
        /// <param name="p">The pen to use to draw this object, MmgPen.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX == true)
                {
                    c = p.GetGraphicsColor();

                    //draw obj rect
                    p.SetGraphicsColor(Color.Red);
                    p.DrawRect(this);
                    p.DrawRect(GetX(), GetY() + GetHeight() - scrollBarHorHeight, w, scrollBarHorHeight);

                    //draw view port rect
                    p.SetGraphicsColor(Color.Blue);
                    p.DrawRect(viewPortRect);

                    //draw scroll pane rect
                    p.SetGraphicsColor(Color.Green);
                    p.DrawRect(scrollPaneRect);

                    if (scrollBarHorVisible)
                    {
                        //slider
                        p.SetGraphicsColor(Color.Orange);
                        p.DrawRect(scrollBarHorCenterButtonRect);

                        //slider button bottom
                        p.SetGraphicsColor(Color.Cyan);
                        p.DrawRect(scrollBarHorRightButtonRect);

                        //slider button top
                        p.SetGraphicsColor(Color.Pink);
                        p.DrawRect(scrollBarHorLeftButtonRect);
                    }

                    if (scrollBarVertVisible)
                    {
                        //slider
                        p.SetGraphicsColor(Color.Orange);
                        p.DrawRect(scrollBarVertCenterButtonRect);

                        //slider button bottom
                        p.SetGraphicsColor(Color.Cyan);
                        p.DrawRect(scrollBarVertDownButtonRect);

                        //slider button top
                        p.SetGraphicsColor(Color.Pink);
                        p.DrawRect(scrollBarVertUpButtonRect);
                    }

                    p.SetGraphicsColor(c);
                }

                if (scrollBarHorVisible)
                {
                    c = p.GetGraphicsColor();
                    if (scrollBarColor != null)
                    {
                        p.SetGraphicsColor(scrollBarColor.GetColor());
                        p.DrawRect(new MmgRect(scrollBarHorLeftButtonRect.GetLeft(), scrollBarHorLeftButtonRect.GetTop(), scrollBarHorRightButtonRect.GetBottom(), scrollBarHorRightButtonRect.GetRight()));
                    }

                    if (scrollBarHorLeftButton != null)
                    {
                        p.DrawBmp(scrollBarHorLeftButton);
                    }

                    if (scrollBarHorRightButton != null)
                    {
                        p.DrawBmp(scrollBarHorRightButton);
                    }

                    if (scrollBarHorCenterButton != null)
                    {
                        if (scrollBarCenterButtonColor != null)
                        {
                            p.SetGraphicsColor(scrollBarCenterButtonColor.GetColor());
                            p.DrawRect(scrollBarHorCenterButtonRect);
                        }
                        p.DrawBmp(scrollBarHorCenterButton);
                    }

                    p.SetGraphicsColor(c);
                }

                if (scrollBarVertVisible)
                {
                    c = p.GetGraphicsColor();
                    if (scrollBarColor != null)
                    {
                        p.SetGraphicsColor(scrollBarColor.GetColor());
                        p.DrawRect(new MmgRect(scrollBarVertUpButtonRect.GetLeft(), scrollBarVertUpButtonRect.GetTop(), scrollBarVertDownButtonRect.GetBottom(), scrollBarVertDownButtonRect.GetRight()));
                    }

                    if (scrollBarVertUpButton != null)
                    {
                        p.DrawBmp(scrollBarVertUpButton);
                    }

                    if (scrollBarVertDownButton != null)
                    {
                        p.DrawBmp(scrollBarVertDownButton);
                    }

                    if (scrollBarVertCenterButton != null)
                    {
                        if (scrollBarCenterButtonColor != null)
                        {
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

        /// <summary>
        /// A method used to check the equality of this MmgScrollHorVert when compared to another MmgScrollHorVert.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgScrollHorVert object to compare to.</param>
        /// <returns>A bool indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgScrollHorVert obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
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
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}