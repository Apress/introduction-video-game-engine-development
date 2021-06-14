using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class the provides support for a vertical scroll pane.
    /// Created by Middlemind Games 01/16/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgScrollVert : MmgObj
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
        /// The height of the scroll pane.
        /// </summary>
        private int scrollPaneHeight;

        /// <summary>
        /// An MmgBmp object that is the vertical slider.
        /// </summary>
        private MmgBmp scrollBarCenterButton;

        /// <summary>
        /// A rectangle with the dimensions of the vertical slider.
        /// </summary>
        private MmgRect scrollBarCenterButtonRect;

        /// <summary>
        /// An MmgBmp that is the horizontal slider's top button.
        /// </summary>
        private MmgBmp scrollBarUpButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's top button.
        /// </summary>
        private MmgRect scrollBarUpButtonRect;

        /// <summary>
        /// An MmgBmp that is the horizontal slider's bottom button.
        /// </summary>
        private MmgBmp scrollBarDownButton;

        /// <summary>
        /// A rectangle with the dimensions of the horizontal slider's bottom button.
        /// </summary>
        private MmgRect scrollBarDownButtonRect;

        /// <summary>
        /// The height difference between the view port and the scroll pane.
        /// </summary>
        private int heightDiff;

        /// <summary>
        /// The height difference percentage between the view port and the scroll pane.
        /// </summary>
        private double heightDiffPrct;

        /// <summary>
        /// A bool flag indicating if the vertical scroll bar is visible.
        /// </summary>
        private bool scrollBarVisible;

        /// <summary>
        /// An MmgColor for the horizontal scroll bar background color. 
        /// </summary>
        private MmgColor scrollBarColor;

        /// <summary>
        /// An MmgColor for the horizontal scroll bar slider's color.
        /// </summary>
        private MmgColor scrollBarCenterButtonColor;

        /// <summary>
        /// The vertical scroll bar width.
        /// </summary>
        private int scrollBarWidth;

        /// <summary>
        /// The height of the vertical scroll bar slider. 
        /// </summary>
        private int scrollBarCenterButtonHeight;

        /// <summary>
        /// The height of the scroll bar slider button. 
        /// </summary>
        private int scrollBarUpDownButtonHeight;

        /// <summary>
        /// The scroll interval of the vertical slider.
        /// </summary>
        private int intervalY;

        /// <summary>
        /// The scroll interval percentage of the vertical slider.
        /// </summary>
        private double intervalPrctY;

        /// <summary>
        /// A bool flag indicating if the scroll pane needs to be updated during the MmgUpdate call.
        /// </summary>
        private bool isDirty;

        /// <summary>
        /// The current offset of the vertical scroll bar's slider.
        /// </summary>
        private int offsetYScrollBarCenterButton;

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
        private MmgEvent clickScreen = new MmgEvent(null, "vert_click_screen", MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll up event occurs.
        /// </summary>
        private MmgEvent clickUp = new MmgEvent(null, "vert_click_up", MmgScrollVert.SCROLL_VERT_SCROLL_UP_EVENT_ID, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// The MmgEvent to fire when a scroll down event occurs.
        /// </summary>
        private MmgEvent clickDown = new MmgEvent(null, "vert_click_down", MmgScrollVert.SCROLL_VERT_SCROLL_DOWN_EVENT_ID, MmgScrollVert.SCROLL_VERT_CLICK_EVENT_TYPE, null, null);

        /// <summary>
        /// An event type for a scroll pane click event.
        /// </summary>
        public static int SCROLL_VERT_CLICK_EVENT_TYPE = 1;

        /// <summary>
        /// An event id for a scroll pane click event.
        /// </summary>
        public static int SCROLL_VERT_CLICK_EVENT_ID = 0;

        /// <summary>
        /// An event id for a scroll pane up click event.
        /// </summary>
        public static int SCROLL_VERT_SCROLL_UP_EVENT_ID = 1;

        /// <summary>
        /// An event id for a scroll pane down click event.
        /// </summary>
        public static int SCROLL_VERT_SCROLL_DOWN_EVENT_ID = 2;

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
        /// Basic constructor that sets the required objects and dimensions.
        /// Prepares the drawing dimensions based on the provided objects.
        /// </summary>
        /// <param name="ViewPort">The MmgBmp that shows a portion of the MmgBmp scroll pane.</param>
        /// <param name="ScrollPane">The MmgBmp the is used to display a portion of itself to the view port.</param>
        /// <param name="ScrollBarColor">The MmgColor to use for the scroll bar.</param>
        /// <param name="ScrollBarCenterButtonColor">The MmgColor to use for the scroll bar slider.</param>
        /// <param name="ScrollBarWidth">The width of the scroll bar.</param>
        /// <param name="ScrollBarCenterButtonHeight">The height of the scroll bar slider.</param>
        /// <param name="IntervalY">The interval to use when moving the scroll bar.</param>
        public MmgScrollVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int ScrollBarWidth, int ScrollBarCenterButtonHeight, int IntervalY) : base()
        {
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

        /// <summary>
        /// Abridged constructor that sets the required objects, colors, and dimensions.
        /// Prepares the drawing dimensions based on the provided objects.
        /// </summary>
        /// <param name="ViewPort">The MmgBmp that shows a portion of the MmgBmp scroll pane.</param>
        /// <param name="ScrollPane">The MmgBmp the is used to display a portion of itself to the view port.</param>
        /// <param name="ScrollBarColor">The MmgColor to use for the scroll bar.</param>
        /// <param name="ScrollBarCenterButtonColor">The MmgColor to use for the scroll bar slider.</param>
        /// <param name="IntervalY">The interval to use when moving the scroll bar.</param>
        public MmgScrollVert(MmgBmp ViewPort, MmgBmp ScrollPane, MmgColor ScrollBarColor, MmgColor ScrollBarCenterButtonColor, int IntervalY) : base()
        {
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

        /// <summary>
        /// Constructor that is based on an instance of this class.
        /// </summary>
        /// <param name="obj">An MmgScrollHor instance.</param>
        public MmgScrollVert(MmgScrollVert obj) : base()
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

            if (obj.GetScrollBarUpButton() == null)
            {
                SetScrollBarUpButton(obj.GetScrollBarUpButton());
            }
            else
            {
                SetScrollBarUpButton(obj.GetScrollBarUpButton().CloneTyped());
            }

            if (obj.GetScrollBarUpButtonRect() == null)
            {
                SetScrollBarUpButtonRect(obj.GetScrollBarUpButtonRect());
            }
            else
            {
                SetScrollBarUpButtonRect(obj.GetScrollBarUpButtonRect().Clone());
            }

            if (obj.GetScrollBarDownButton() == null)
            {
                SetScrollBarDownButton(obj.GetScrollBarDownButton());
            }
            else
            {
                SetScrollBarDownButton(obj.GetScrollBarDownButton().CloneTyped());
            }

            if (obj.GetScrollBarDownButtonRect() == null)
            {
                SetScrollBarDownButtonRect(obj.GetScrollBarDownButtonRect());
            }
            else
            {
                SetScrollBarDownButtonRect(obj.GetScrollBarDownButtonRect().Clone());
            }

            SetHeightDiff(obj.GetHeightDiff());
            SetHeightDiffPrct(obj.GetHeightDiffPrct());
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

            SetScrollBarWidth(obj.GetScrollBarWidth());
            SetScrollBarCenterButtonHeight(obj.GetScrollBarCenterButtonHeight());
            SetScrollBarUpDownButtonHeight(obj.GetScrollBarUpDownButtonHeight());
            SetOffsetY(obj.GetOffsetY());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                GetPosition().SetX(obj.GetPosition().GetX());
                GetPosition().SetY(obj.GetPosition().GetY());
            }

            SetIntervalY(obj.GetIntervalY());
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgScrollVert(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgScrollVert CloneTyped()
        {
            return new MmgScrollVert(this);
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
            viewPortHeight = viewPortRect.GetHeight();

            scrollBarDownButton = MmgHelper.GetBasicCachedBmp("scroll_bar_down_sm.png");
            scrollBarUpButton = MmgHelper.GetBasicCachedBmp("scroll_bar_up_sm.png");
            scrollBarCenterButton = MmgHelper.GetBasicCachedBmp("scroll_bar_slider_sm.png");
            if (scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null)
            {
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

            if (scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null)
            {
                scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
                scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());
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

            if (scrollPaneHeight - viewPortHeight > 0)
            {
                heightDiff = H - scrollNotchTravel;
                heightDiffPrct = intervalPrctScrollPane;
                scrollBarVisible = true;
            }
            else
            {
                heightDiff = 0;
                heightDiffPrct = 0.0;
                scrollBarVisible = false;
            }

            p = new MmgPen(viewPort.GetImage());
            p.SetAdvRenderHints();
        }

        /// <summary>
        /// Returns the target event handler of the clickScreen MmgEvent class field.
        /// </summary>
        /// <returns>The MmgEventHandler to use to handle events.</returns>
        public MmgEventHandler GetEventHandler()
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
        /// Sets the X coordinate of this scroll view.
        /// </summary>
        /// <param name="inX">The X coordinate of this scroll view.</param>
        public override void SetX(int inX)
        {
            base.SetX(inX);
            viewPortRect.SetPosition(new MmgVector2(inX, viewPortRect.GetTop()));
            scrollPaneRect.SetPosition(new MmgVector2(inX, scrollPaneRect.GetTop()));
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarCenterButtonRect.GetTop()));
            scrollBarUpButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarUpButtonRect.GetTop()));
            scrollBarDownButtonRect.SetPosition(new MmgVector2(inX + viewPort.GetWidth(), scrollBarDownButtonRect.GetTop()));

            if (scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null)
            {
                scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
                scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());
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
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(scrollBarCenterButtonRect.GetLeft(), inY + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
            scrollBarUpButtonRect.SetPosition(new MmgVector2(scrollBarUpButtonRect.GetLeft(), inY));
            scrollBarDownButtonRect.SetPosition(new MmgVector2(scrollBarDownButtonRect.GetLeft(), inY + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));

            if (scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null)
            {
                scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
                scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());
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
            scrollBarCenterButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
            scrollBarUpButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY()));
            scrollBarDownButtonRect.SetPosition(new MmgVector2(inPos.GetX() + viewPort.GetWidth(), inPos.GetY() + viewPortRect.GetHeight() - scrollBarUpDownButtonHeight));

            if (scrollBarUpButton != null && scrollBarDownButton != null && scrollBarCenterButton != null)
            {
                scrollBarUpButton.SetPosition(scrollBarUpButtonRect.GetPosition());
                scrollBarDownButton.SetPosition(scrollBarDownButtonRect.GetPosition());
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

            if (scrollBarVisible && dir == MmgDir.DIR_BACK)
            {
                if (currentPrct - heightDiffPrct < 0.0)
                {
                    currentPrct = 0.0;
                }
                else
                {
                    currentPrct -= heightDiffPrct;
                }

                if (currentPrct >= -0.002 && currentPrct <= 0.002)
                {
                    currentPrct = 0.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

                if (clickUp != null)
                {
                    clickUp.Fire();
                }

                isDirty = true;
                return true;
            }
            else if (scrollBarVisible && dir == MmgDir.DIR_FRONT)
            {
                if (currentPrct + heightDiffPrct > 1.0)
                {
                    currentPrct = 1.0;
                }
                else
                {
                    currentPrct += heightDiffPrct;
                }

                if (currentPrct >= 0.998 && currentPrct <= 1.002)
                {
                    currentPrct = 1.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

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

            if (MmgHelper.RectCollision(x, y, viewPortRect))
            {
                if (clickScreen != null)
                {
                    clickScreen.SetExtra(new MmgVector2(x, y));
                    clickScreen.Fire();
                }
                ret = true;
            }
            else if (scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarUpButtonRect))
            {
                if (currentPrct - heightDiffPrct < 0.0)
                {
                    currentPrct = 0.0;
                }
                else
                {
                    currentPrct -= heightDiffPrct;
                }

                if (currentPrct >= -0.002 && currentPrct <= 0.002)
                {
                    currentPrct = 0.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

                if (clickUp != null)
                {
                    clickUp.Fire();
                }

                isDirty = true;
                ret = true;

            }
            else if (scrollBarVisible && MmgHelper.RectCollision(x - 3, y - 3, 6, 6, scrollBarDownButtonRect))
            {
                if (currentPrct + heightDiffPrct > 1.0)
                {
                    currentPrct = 1.0;
                }
                else
                {
                    currentPrct += heightDiffPrct;
                }

                if (currentPrct >= 0.998 && currentPrct <= 1.002)
                {
                    currentPrct = 1.0;
                }

                offsetYScrollBarCenterButton = (int)(currentPrct * (double)scrollNotchTravel);
                offsetYScrollPane = (int)(currentPrct * (double)scrollPaneTravel);

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
        /// Changing the scroll pane dimensiosn requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect dimensions for this scroll pane.</param>
        public virtual void SetScrollPaneRect(MmgRect r)
        {
            scrollPaneRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp that is used for the vertical slider.
        /// </summary>
        /// <returns>The MmgBmp used for the vertical slider.</returns>
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
        /// Gets the MmgRect dimensions for the vertical slider.
        /// </summary>
        /// <returns>The MmgRect dimensions for the vertical slider.</returns>
        public virtual MmgRect GetScrollBarCenterButtonRect()
        {
            return scrollBarCenterButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the vertical slider.
        /// Changing the slider dimensions requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect dimensions for the vertical slider.</param>
        public virtual void SetScrollBarCenterButtonRect(MmgRect r)
        {
            scrollBarCenterButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp used for the slider up button.
        /// </summary>
        /// <returns>The MmgBmp used for the slider up button.</returns>
        public virtual MmgBmp GetScrollBarUpButton()
        {
            return scrollBarUpButton;
        }

        /// <summary>
        /// Sets the MmgBmp used for the slider up button.
        /// Changing the slider up button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp used for the slider up button.</param>
        public virtual void SetScrollBarUpButton(MmgBmp b)
        {
            scrollBarUpButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the up button.
        /// </summary>
        /// <returns>The MmgRect used for the up button.</returns>
        public virtual MmgRect GetScrollBarUpButtonRect()
        {
            return scrollBarUpButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the up button.
        /// Changing the up button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the up button.</param>
        public virtual void SetScrollBarUpButtonRect(MmgRect r)
        {
            scrollBarUpButtonRect = r;
        }

        /// <summary>
        /// Gets the MmgBmp for the slider down button.
        /// </summary>
        /// <returns>The MmgBmp for the down button.</returns>
        public virtual MmgBmp GetScrollBarDownButton()
        {
            return scrollBarDownButton;
        }

        /// <summary>
        /// Sets the MmgBmp for the slider down button.
        /// Changing the down button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="b">The MmgBmp for the down button.</param>
        public virtual void SetScrollBarDownButton(MmgBmp b)
        {
            scrollBarDownButton = b;
        }

        /// <summary>
        /// Gets the MmgRect dimensions for the down button.
        /// </summary>
        /// <returns>The MmgRect used for the down button.</returns>
        public virtual MmgRect GetScrollBarDownButtonRect()
        {
            return scrollBarDownButtonRect;
        }

        /// <summary>
        /// Sets the MmgRect dimensions for the down button.
        /// Changing the down button requires a call to PrepDimensions.
        /// </summary>
        /// <param name="r">The MmgRect used for the down button.</param>
        public virtual void SetScrollBarDownButtonRect(MmgRect r)
        {
            scrollBarDownButtonRect = r;
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
        /// Gets a bool indicating if the vertical scroll bar is visible.
        /// </summary>
        /// <returns>A bool indicating if the vertical scroll bar is visible.</returns>
        public virtual bool GetScrollBarVisible()
        {
            return scrollBarVisible;
        }

        /// <summary>
        /// Sets a bool value indicating if the vertical scroll bar is visible.
        /// </summary>
        /// <param name="b">A bool indicating if the vertical scroll bar is visible.</param>
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
        /// <param name="ScrollBarColor">The MmgColor of the scroll bar.</param>
        public virtual void SetScrollBarColor(MmgColor ScrollBarColor)
        {
            scrollBarColor = ScrollBarColor;
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
        /// Gets the vertical scroll bar height.
        /// </summary>
        /// <returns>The vertical scroll bar height.</returns>
        public virtual int GetScrollBarWidth()
        {
            return scrollBarWidth;
        }

        /// <summary>
        /// Sets the vertical scroll bar height.
        /// </summary>
        /// <param name="w">The vertical scroll bar height.</param>
        public virtual void SetScrollBarWidth(int w)
        {
            scrollBarWidth = w;
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
        /// Gets the scroll bar vertical slider height.
        /// </summary>
        /// <returns>The scroll bar vertical slider height.</returns>
        public virtual int GetScrollBarCenterButtonHeight()
        {
            return scrollBarCenterButtonHeight;
        }

        /// <summary>
        /// Sets the scroll bar vertical slider width.
        /// </summary>
        /// <param name="h">The scroll bar vertical slider width.</param>
        public virtual void SetScrollBarCenterButtonHeight(int h)
        {
            scrollBarCenterButtonHeight = h;
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
        /// Sets the interval for movement on the Y axis.
        /// </summary>
        /// <param name="IntervalY">The Y interval for movement.</param>
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
        /// <param name="OffsetY"></param>
        public virtual void SetOffsetY(int OffsetY)
        {
            offsetYScrollPane = OffsetY;
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
                scrollBarCenterButtonRect.SetPosition(new MmgVector2(scrollBarCenterButtonRect.GetLeft(), GetY() + scrollBarUpDownButtonHeight + offsetYScrollBarCenterButton));
                scrollPaneRect.SetPosition(new MmgVector2(scrollPaneRect.GetLeft(), GetY() - offsetYScrollPane));

                if (scrollBarCenterButton != null)
                {
                    scrollBarCenterButton.SetPosition(scrollBarCenterButtonRect.GetPosition());
                }

                updSrcRect = new MmgRect(offsetYScrollPane, 0, viewPortRect.GetHeight(), offsetYScrollPane + viewPortRect.GetWidth());
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
                if (MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX == true)
                {
                    c = p.GetGraphicsColor();

                    //draw obj rect
                    p.SetGraphicsColor(Color.Red);
                    p.DrawRect(this);
                    p.DrawRect(GetX() + GetWidth() - scrollBarWidth, GetY(), scrollBarWidth, h);

                    //draw view port rect
                    p.SetGraphicsColor(Color.Blue);
                    p.DrawRect(viewPortRect);

                    //draw scroll pane rect
                    p.SetGraphicsColor(Color.Green);
                    p.DrawRect(scrollPaneRect);

                    if (scrollBarVisible)
                    {
                        //center button
                        p.SetGraphicsColor(Color.Orange);
                        p.DrawRect(scrollBarCenterButtonRect);

                        //bottom button
                        p.SetGraphicsColor(Color.Cyan);
                        p.DrawRect(scrollBarDownButtonRect);

                        //top button
                        p.SetGraphicsColor(Color.Pink);
                        p.DrawRect(scrollBarUpButtonRect);
                    }

                    p.SetGraphicsColor(c);
                }

                if (scrollBarVisible)
                {
                    c = p.GetGraphicsColor();
                    if (scrollBarColor != null)
                    {
                        p.SetGraphicsColor(scrollBarColor.GetColor());
                        p.DrawRect(new MmgRect(scrollBarUpButtonRect.GetLeft(), scrollBarUpButtonRect.GetTop(), scrollBarDownButtonRect.GetBottom(), scrollBarDownButtonRect.GetRight()));
                    }

                    if (scrollBarUpButton != null)
                    {
                        p.DrawBmp(scrollBarUpButton);
                    }

                    if (scrollBarDownButton != null)
                    {
                        p.DrawBmp(scrollBarDownButton);
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
        /// A method used to check the equality of this MmgScrollVert when compared to another MmgScrollVert.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgScrollVert object to compare to.</param>
        /// <returns>A bool indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgScrollVert obj)
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
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}