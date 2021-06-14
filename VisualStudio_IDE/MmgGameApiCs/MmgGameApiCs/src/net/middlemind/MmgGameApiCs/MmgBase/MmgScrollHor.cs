using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class the provides support for a horizontal scroll pane.
    /// Created by Middlemind Games 01/16/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgScrollHor : MmgObj
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
        /// An MmgBmp object that is the horizontal slider.
        /// </summary>
        private MmgBmp scrollBarCenterButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider.
        /// </summary>
        private MmgRect scrollBarCenterButtonRect;

        /// <summary>
        /// An MmgBmp that is the horizontal slider's left button.
        /// </summary>
        private MmgBmp scrollBarLeftButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's left button.
        /// </summary>
        private MmgRect scrollBarLeftButtonRect;

        /// <summary>
        /// An MmgBmp that is the horizontal slider's right button.
        /// </summary>
        private MmgBmp scrollBarRightButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's right button.
        /// </summary>
        private MmgRect scrollBarRightButtonRect;

        /// <summary>
        /// The width difference between the view port and the scroll pane.
        /// </summary>
        private int widthDiff;

        /// <summary>
        /// The width difference percentage between the view port and the scroll pane.
        /// </summary>
        private double widthDiffPrct;

        /// <summary>
        /// A bool flag indicating if the horizontal scroll bar is visible.
        /// </summary>
        private bool scrollBarVisible = false;

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
        private int scrollBarHeight;

        /// <summary>
        /// The width of the horizontal scroll bar slider.
        /// </summary>
        private int scrollBarCenterButtonWidth;

        /// <summary>
        /// The width of the scroll bar slider button. 
        /// </summary>
        private int scrollBarLeftRightButtonWidth;

        /// <summary>
        /// The scroll interval of the horizontal slider.
        /// </summary>
        private int intervalX;

        /// <summary>
        /// The scroll interval percentage of the horizontal slider.
        /// </summary>
        private double intervalPrctX;

        /// <summary>
        /// A bool flag indicating if the scroll pane needs to be updated during the MmgUpdate call. 
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// The current offset of the horizontal scroll bar's slider.
        /// </summary>
        private int offsetXScrollBarCenterButton;

        /// <summary>
        /// The current offset of the horizontal scroll pane.
        /// </summary>
        private int offsetXScrollPane;

        /// <summary>
        /// A bool flag indicating if a bounding box should be drawn around the elements of the scroll pane.
        /// </summary>
        public static bool SHOW_CONTROL_BOUNDING_BOX = false;

        /// <summary>
        /// The MmgEvent to fire when a screen click occurs. 
        /// </summary>
        private MmgEvent clickScreen = new MmgEvent(null, "hor_click_screen", MmgScrollHor.SCROLL_HOR_CLICK_EVENT_ID, MmgScrollHor.SCROLL_HOR_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll left event occurs. 
        /// </summary>
        private MmgEvent clickLeft = new MmgEvent(null, "hor_click_left", MmgScrollHor.SCROLL_HOR_SCROLL_LEFT_EVENT_ID, MmgScrollHor.SCROLL_HOR_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll right event occurs.
        /// </summary>
        private MmgEvent clickRight = new MmgEvent(null, "hor_click_right", MmgScrollHor.SCROLL_HOR_SCROLL_RIGHT_EVENT_ID, MmgScrollHor.SCROLL_HOR_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// An event type id for this object's events.
        /// </summary>
        public static int SCROLL_HOR_CLICK_EVENT_TYPE = 0;

        /// <summary>
        /// An event id for a scroll pane click event.
        /// </summary>
        public static int SCROLL_HOR_CLICK_EVENT_ID = 3;

        /// <summary>
        /// An event id for a scroll pane left click event.
        /// </summary>
        public static int SCROLL_HOR_SCROLL_LEFT_EVENT_ID = 4;

        /// <summary>
        /// An event id for a scroll pane right click event.
        /// </summary>
        public static int SCROLL_HOR_SCROLL_RIGHT_EVENT_ID = 5;

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
        /// <param name="ScrollBarCenterButtonColor">The MmgColor to use for the scroll bar slider.</param>
        /// <param name="ScrollBarHeight">The height of the scroll bar.</param>
        /// <param name="ScrollBarCenterButtonWidth">The width of the scroll bar slider.</param>
        /// <param name="IntervalX">The interval to use when moving the scroll bar.</param>
        public MmgScrollHor(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int ScrollBarHeight, int ScrollBarCenterButtonWidth, int IntervalX) : base()
        {
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

        /// <summary>
        /// Abridged constructor that sets the required objects, colors, and dimensions.
        /// Prepares the drawing dimensions based on the provided objects.
        /// </summary>
        /// <param name="ViewPort">The MmgBmp that shows a portion of the MmgBmp scroll pane.</param>
        /// <param name="ScrollPane">The MmgBmp the is used to display a portion of itself to the view port.</param>
        /// <param name="ScrollBarColor">The MmgColor to use for the scroll bar.</param>
        /// <param name="ScrollBarCenterButtonColor">The MmgColor to use for the scroll bar slider.</param>
        /// <param name="IntervalX">The interval to use when moving the scroll bar.</param>
        public MmgScrollHor(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int IntervalX) : base()
        {
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

        /// <summary>
        /// Constructor that is based on an instance of this class.
        /// </summary>
        /// <param name="obj">An MmgScrollHor instance. </param>
        public MmgScrollHor(MmgScrollHor obj) : base()
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

            if (obj.GetScrollBarCenterButton() == null)
            {
                SetScrollBarCenterButton(obj.GetScrollBarCenterButton());
            }
            else
            {
                SetScrollBarCenterButton(obj.GetScrollBarCenterButton().CloneTyped());
            }

            if (obj.GetScrollBarCenterButtonRect() == null)
            {
                SetScrollBarCenterButtonRect(obj.GetScrollBarCenterButtonRect());
            }
            else
            {
                SetScrollBarCenterButtonRect(obj.GetScrollBarCenterButtonRect().Clone());
            }

            if (obj.GetScrollBarLeftButton() == null)
            {
                SetScrollBarLeftButton(obj.GetScrollBarLeftButton());
            }
            else
            {
                SetScrollBarLeftButton(obj.GetScrollBarLeftButton().CloneTyped());
            }

            if (obj.GetScrollBarLeftButtonRect() == null)
            {
                SetScrollBarLeftButtonRect(obj.GetScrollBarLeftButtonRect());
            }
            else
            {
                SetScrollBarLeftButtonRect(obj.GetScrollBarLeftButtonRect().Clone());
            }

            if (obj.GetScrollBarRightButton() == null)
            {
                SetScrollBarRightButton(obj.GetScrollBarRightButton());
            }
            else
            {
                SetScrollBarRightButton(obj.GetScrollBarRightButton().CloneTyped());
            }

            if (obj.GetScrollBarRightButtonRect() == null)
            {
                SetScrollBarRightButtonRect(obj.GetScrollBarRightButtonRect());
            }
            else
            {
                SetScrollBarRightButtonRect(obj.GetScrollBarRightButtonRect().Clone());
            }

            SetWidthDiff(obj.GetWidthDiff());
            SetWidthDiffPrct(obj.GetWidthDiffPrct());
            SetScrollBarVisible(obj.GetScrollBarVisible());

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

            SetScrollBarHeight(obj.GetScrollBarHeight());
            SetScrollBarCenterButtonWidth(obj.GetScrollBarCenterButtonWidth());
            SetScrollBarLeftRightButtonWidth(obj.GetScrollBarLeftRightButtonWidth());
            SetOffsetX(obj.GetOffsetX());

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
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgScrollHor(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgScrollHor CloneTyped()
        {
            return new MmgScrollHor(this);
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

            if (scrollBarLeftButton == null)
            {
                scrollBarLeftButton = MmgHelper.GetBasicCachedBmp("scroll_bar_left_sm.png");
            }

            if (scrollBarRightButton == null)
            {
                scrollBarRightButton = MmgHelper.GetBasicCachedBmp("scroll_bar_right_sm.png");
            }

            if (scrollBarCenterButton == null)
            {
                scrollBarCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");
            }

            if (scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null)
            {
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

            if (scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null)
            {
                scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
                scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());
                scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
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

            if (scrollPaneWidth - viewPortWidth > 0)
            {
                widthDiff = H - scrollNotchTravel;
                widthDiffPrct = intervalPrctScrollPane;
                scrollBarVisible = true;
            }
            else
            {
                widthDiff = 0;
                widthDiffPrct = 0.0;
                scrollBarVisible = false;
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
        /// Sets event handlers for all this object's events.
        /// </summary>
        /// <param name="e">The MmgEventHandler to use to handle events.</param>
        public virtual void SetEventHandler(MmgEventHandler e)
        {
            clickScreen.SetTargetEventHandler(e);
            clickLeft.SetTargetEventHandler(e);
            clickRight.SetTargetEventHandler(e);
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
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(inX + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarCenterButtonRect.GetTop()));
            scrollBarLeftButtonRect.SetPosition(new MmgVector2(inX, scrollBarLeftButtonRect.GetTop()));
            scrollBarRightButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, scrollBarRightButtonRect.GetTop()));

            if (scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null)
            {
                scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
                scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());
                scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
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
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(scrollBarCenterButtonRect.GetLeft(), inY + viewPort.GetHeight()));
            scrollBarLeftButtonRect.SetPosition(new MmgVector2(scrollBarLeftButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));
            scrollBarRightButtonRect.SetPosition(new MmgVector2(scrollBarRightButtonRect.GetLeft(), inY + viewPortRect.GetHeight()));

            if (scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null)
            {
                scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
                scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());
                scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
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
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, inPos.GetY() + viewPort.GetHeight()));
            scrollBarLeftButtonRect.SetPosition(new MmgVector2(inPos.GetX(), inPos.GetY() + viewPort.GetHeight()));
            scrollBarRightButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth() - scrollBarLeftRightButtonWidth, inPos.GetY() + viewPortRect.GetHeight()));

            if (scrollBarLeftButton != null && scrollBarRightButton != null && scrollBarCenterButton != null)
            {
                scrollBarLeftButton.SetPosition(scrollBarLeftButtonRect.GetPosition());
                scrollBarRightButton.SetPosition(scrollBarRightButtonRect.GetPosition());
                scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
            }
        }

        /// <summary>
        /// Processes dpad input release events.
        /// </summary>
        /// <param name="dir">The direction of the dpad input to process.</param>
        /// <returns>A bool indicating if the dpad input was handled.</returns>
        public virtual bool ProcessDpadRelease(int dir)
        {
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

            if (scrollBarVisible && dir == MmgDir.DIR_LEFT)
            {
                if (currentPrct - widthDiffPrct < 0.0)
                {
                    currentPrct = 0.0;
                }
                else
                {
                    currentPrct -= widthDiffPrct;
                }

                if (currentPrct >= -0.002 && currentPrct <= 0.002)
                {
                    currentPrct = 0.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

                if (clickLeft != null)
                {
                    clickLeft.Fire();
                }

                isDirty = true;
                return true;

            }
            else if (scrollBarVisible && dir == MmgDir.DIR_RIGHT)
            {
                if (currentPrct + widthDiffPrct > 1.0)
                {
                    currentPrct = 1.0;
                }
                else
                {
                    currentPrct += widthDiffPrct;
                }

                if (currentPrct >= 0.998 && currentPrct <= 1.002)
                {
                    currentPrct = 1.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

                if (clickRight != null)
                {
                    clickRight.Fire();
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

            if (MmgHelper.RectCollision(x, y, viewPortRect))
            {
                if (clickScreen != null)
                {
                    clickScreen.SetExtra(new MmgVector2(x, y));
                    clickScreen.Fire();
                }
                ret = true;
            }
            else if (scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarLeftButtonRect))
            {
                if (currentPrct + widthDiffPrct > 1.0)
                {
                    currentPrct = 1.0;
                }
                else
                {
                    currentPrct += widthDiffPrct;
                }

                if (currentPrct >= 0.998 && currentPrct <= 1.001)
                {
                    currentPrct = 1.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

                if (clickLeft != null)
                {
                    clickLeft.Fire();
                }

                isDirty = true;
                ret = true;
            }
            else if (scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarRightButtonRect))
            {
                if (currentPrct + widthDiffPrct > 1.0)
                {
                    currentPrct = 1.0;
                }
                else
                {
                    currentPrct += widthDiffPrct;
                }

                if (currentPrct >= 0.998 && currentPrct <= 1.001)
                {
                    currentPrct = 1.0;
                }

                offsetXScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetXScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

                if (clickRight != null)
                {
                    clickRight.Fire();
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
        public virtual MmgBmp GetScrollBarCenterButton()
        {
            return scrollBarCenterButton;
        }

        /// <summary>
        /// Sets the MmgBmp that is used for the horizontal slider.
        /// Changing the slider requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the horizontal slider.</param>
        public virtual void SetScrollBarCenterButton(MmgBmp b)
        {
            scrollBarCenterButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the horizontal slider.
        /// </summary>
        /// <returns>The MmgRect dimensions for the horizontal slider.</returns>
        public virtual MmgRect GetScrollBarCenterButtonRect()
        {
            return scrollBarCenterButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the horizontal slider.
        /// Changing the slider dimensions requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r"></param>
        public virtual void SetScrollBarCenterButtonRect(MmgRect r)
        {
            scrollBarCenterButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp used for the slider up button.
        /// </summary>
        /// <returns>The MmgBmp used for the slider up button.</returns>
        public virtual MmgBmp GetScrollBarLeftButton()
        {
            return scrollBarLeftButton;
        }

        /// <summary>
        /// Sets the MmgBmp used for the slider up button.
        /// Changing the slider up button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the slider up button.</param>
        public virtual void SetScrollBarLeftButton(MmgBmp b)
        {
            scrollBarLeftButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the left button.
        /// </summary>
        /// <returns>The MmgRect used for the left button.</returns>
        public virtual MmgRect GetScrollBarLeftButtonRect()
        {
            return scrollBarLeftButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the left button.
        /// Changing the left button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the left button.</param>
        public virtual void SetScrollBarLeftButtonRect(MmgRect r)
        {
            scrollBarLeftButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp for the slider right button.
        /// </summary>
        /// <returns>The MmgBmp for the right button.</returns>
        public virtual MmgBmp GetScrollBarRightButton()
        {
            return scrollBarRightButton;
        }

        /// <summary>
        /// Sets the MmgBmp for the slider right button.
        /// Changing the right button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp for the right button.</param>
        public virtual void SetScrollBarRightButton(MmgBmp b)
        {
            scrollBarRightButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the right button.
        /// </summary>
        /// <returns>The MmgRect used for the right button.</returns>
        public virtual MmgRect GetScrollBarRightButtonRect()
        {
            return scrollBarRightButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the right button.
        /// Changing the right button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the right button.</param>
        public virtual void SetScrollBarRightButtonRect(MmgRect r)
        {
            scrollBarRightButtonRect = r;
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
        /// Gets a bool indicating if the horizontal scroll bar is visible.
        /// </summary>
        /// <returns>A bool indicating if the horizontal scroll bar is visible.</returns>
        public virtual bool GetScrollBarVisible()
        {
            return scrollBarVisible;
        }

        /// <summary>
        /// Sets a bool value indicating if the horizontal scroll bar is visible.
        /// </summary>
        /// <param name="b">A bool indicating if the horizontal scroll bar is visible.</param>
        public virtual void SetScrollBarVisible(bool b)
        {
            scrollBarVisible = b;
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
        public virtual int GetScrollBarHeight()
        {
            return scrollBarHeight;
        }

        /// <summary>
        /// Sets the vertical scroll bar height.
        /// </summary>
        /// <param name="h">The vertical scroll bar height.</param>
        public virtual void SetScrollBarHeight(int h)
        {
            scrollBarHeight = h;
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
        /// Gets the scroll bar horizontal slider width. 
        /// </summary>
        /// <returns>The scroll bar horizontal slider width.</returns>
        public virtual int GetScrollBarCenterButtonWidth()
        {
            return scrollBarCenterButtonWidth;
        }

        /// <summary>
        /// Sets the scroll bar horizontal slider width.
        /// </summary>
        /// <param name="w">The scroll bar horizontal slider width.</param>
        public virtual void SetScrollBarCenterButtonWidth(int w)
        {
            scrollBarCenterButtonWidth = w;
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
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number. </param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            if (isVisible == true && isDirty == true)
            {
                scrollBarCenterButtonRect.SetPosition(new MmgVector2(GetX() + scrollBarLeftRightButtonWidth + offsetXScrollBarCenterButton, scrollBarCenterButtonRect.GetTop()));
                scrollPaneRect.SetPosition(new MmgVector2(GetX() - offsetXScrollPane, scrollPaneRect.GetTop()));

                if (scrollBarCenterButton != null)
                {
                    scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
                }

                updSrcRect = new MmgRect(offsetXScrollPane, 0, viewPortRect.GetHeight(), offsetXScrollPane + viewPortRect.GetWidth());
                updDstRect = new MmgRect(0, 0, viewPortRect.GetHeight(), viewPortRect.GetWidth());

                //MmgHelper.wr("Update Source Rect: " + updSrcRect.ApiToString());
                //MmgHelper.wr("Update Dest Rect: " + updDestRect.ApiToString());                        

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
        /// <param name="p">The MmgPen to use to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                if (MmgScrollHor.SHOW_CONTROL_BOUNDING_BOX == true)
                {
                    c = p.GetGraphicsColor();

                    //draw obj rect
                    p.SetGraphicsColor(Color.Red);
                    p.DrawRect(this);
                    p.DrawRect(GetX(), GetY() + GetHeight() - scrollBarHeight, w, scrollBarHeight);

                    //draw view port rect
                    p.SetGraphicsColor(Color.Blue);
                    p.DrawRect(viewPortRect);

                    //draw scroll pane rect
                    p.SetGraphicsColor(Color.Green);
                    p.DrawRect(scrollPaneRect);

                    if (scrollBarVisible)
                    {
                        //centre button
                        p.SetGraphicsColor(Color.Orange);
                        p.DrawRect(scrollBarCenterButtonRect);

                        //right button
                        p.SetGraphicsColor(Color.Cyan);
                        p.DrawRect(scrollBarRightButtonRect);

                        //left button
                        p.SetGraphicsColor(Color.Pink);
                        p.DrawRect(scrollBarLeftButtonRect);
                    }

                    p.SetGraphicsColor(c);
                }

                if (scrollBarVisible)
                {
                    c = p.GetGraphicsColor();
                    if (scrollBarColor != null)
                    {
                        p.SetGraphicsColor(scrollBarColor.GetColor());
                        p.DrawRect(new MmgRect(scrollBarLeftButtonRect.GetLeft(), scrollBarLeftButtonRect.GetTop(), scrollBarRightButtonRect.GetBottom(), scrollBarRightButtonRect.GetRight()));
                    }

                    if (scrollBarLeftButton != null)
                    {
                        p.DrawBmp(scrollBarLeftButton);
                    }

                    if (scrollBarRightButton != null)
                    {
                        p.DrawBmp(scrollBarRightButton);
                    }

                    if (scrollBarCenterButton != null)
                    {
                        if (scrollBarCenterButtonColor != null)
                        {
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

        /// <summary>
        /// A method used to check the equality of this MmgScrollHor when compared to another MmgScrollHor.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgScrollHor object to compare to.</param>
        /// <returns>A bool indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgScrollHor obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            if(!(base.equals((MmgObj)obj))) {
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

            if(!(((obj.GetScrollBarCenterButton() == null && GetScrollBarCenterButton() == null) || (obj.GetScrollBarCenterButton() != null && GetScrollBarCenterButton() != null && obj.GetScrollBarCenterButton().equals(GetScrollBarCenterButton()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarCenterButton is not equals!");

            }

            if(!(((obj.GetScrollBarCenterButtonColor() == null && GetScrollBarCenterButtonColor() == null) || (obj.GetScrollBarCenterButtonColor() != null && GetScrollBarCenterButtonColor() != null && obj.GetScrollBarCenterButtonColor().equals(GetScrollBarCenterButtonColor()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarCenterButtonColor is not equals!"); 
            }

            if(!(((obj.GetScrollBarCenterButtonRect() == null && GetScrollBarCenterButtonRect() == null) || (obj.GetScrollBarCenterButtonRect() != null && GetScrollBarCenterButtonRect() != null && obj.GetScrollBarCenterButtonRect().equals(GetScrollBarCenterButtonRect()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarCenterButtonRect is not equals!");
            }

            if(!(obj.GetScrollBarCenterButtonWidth() == GetScrollBarCenterButtonWidth())) {
                MmgHelper.wr("MmgScrollHor: ScrollBarCenterButtonWidth is not equals!");
            }

            if(!(((obj.GetScrollBarColor() == null && GetScrollBarColor() == null) || (obj.GetScrollBarColor() != null && GetScrollBarColor() != null && obj.GetScrollBarColor().equals(GetScrollBarColor()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarColor is not equals!");
            }

            if(!(obj.GetScrollBarHeight() == GetScrollBarHeight())) {
                MmgHelper.wr("MmgScrollHor: ScrollBarHeight is not equals!");
            }

            if(!(((obj.GetScrollBarLeftButton() == null && GetScrollBarLeftButton() == null) || (obj.GetScrollBarLeftButton() != null && GetScrollBarLeftButton() != null && obj.GetScrollBarLeftButton().equals(GetScrollBarLeftButton()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarLeftButton is not equals!");
            }

            if(!(((obj.GetScrollBarLeftButtonRect() == null && GetScrollBarLeftButtonRect() == null) || (obj.GetScrollBarLeftButtonRect() != null && GetScrollBarLeftButtonRect() != null && obj.GetScrollBarLeftButtonRect().equals(GetScrollBarLeftButtonRect()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarLeftButtonRect is not equals!");
            }

            if(!(obj.GetScrollBarLeftRightButtonWidth() == GetScrollBarLeftRightButtonWidth())) {
                MmgHelper.wr("MmgScrollHor: ScrollBarLeftRightButtonWidth is not equals!");
            }

            if(!(((obj.GetScrollBarRightButton() == null && GetScrollBarRightButton() == null) || (obj.GetScrollBarRightButton() != null && GetScrollBarRightButton() != null && obj.GetScrollBarRightButton().equals(GetScrollBarRightButton()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarRightButton is not equals!");            
            }

            if(!(((obj.GetScrollBarRightButtonRect() == null && GetScrollBarRightButtonRect() == null) || (obj.GetScrollBarRightButtonRect() != null && GetScrollBarRightButtonRect() != null && obj.GetScrollBarRightButtonRect().equals(GetScrollBarRightButtonRect()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollBarRightButtonRect is not equals!");
            }

            if(!(((obj.GetScrollPane() == null && GetScrollPane() == null) || (obj.GetScrollPane() != null && GetScrollPane() != null && obj.GetScrollPane().equals(GetScrollPane()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollPane is not equals!");
            }

            if(!(((obj.GetScrollPaneRect() == null && GetScrollPaneRect() == null) || (obj.GetScrollPaneRect() != null && GetScrollPaneRect() != null && obj.GetScrollPaneRect().equals(GetScrollPaneRect()))))) {
                MmgHelper.wr("MmgScrollHor: ScrollPaneRect is not equals!");
            }

            if(!(((obj.GetViewPort() == null && GetViewPort() == null) || (obj.GetViewPort() != null && GetViewPort() != null && obj.GetViewPort().equals(GetViewPort()))))) {
                MmgHelper.wr("MmgScrollHor: ViewPort is not equals!");
            }

            if(!(((obj.GetViewPortRect() == null && GetViewPortRect() == null) || (obj.GetViewPortRect() != null && GetViewPortRect() != null && obj.GetViewPortRect().equals(GetViewPortRect()))))) {
                MmgHelper.wr("MmgScrollHor: ViewPortRect is not equals!");
            }

            if(!(obj.GetWidthDiff() == GetWidthDiff())) {
                MmgHelper.wr("MmgScrollHor: WidthDiff is not equals!");
            }

            if(!(obj.GetWidthDiffPrct() == GetWidthDiffPrct())) {
                MmgHelper.wr("MmgScrollHor: WidthDiffPrct is not equals!");
            }
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
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
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}