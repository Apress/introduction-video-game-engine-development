using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that represents a basic game screen. 
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgGameScreen : MmgObj
    {
        /// <summary>
        /// Pause this screen.
        /// </summary>
        public bool pause;

        /// <summary>
        /// Is this screen ready.
        /// </summary>
        public bool ready;

        /// <summary>
        /// The MmgContainer that holds all the child objects.
        /// </summary>
        private MmgContainer objects;

        /// <summary>
        /// A place holder for the background object of the game screen.
        /// </summary>
        private MmgObj background;

        /// <summary>
        /// A place holder for the foreground object of the game screen.
        /// </summary>
        private MmgObj foreground;

        /// <summary>
        /// A place holder for the header object.
        /// </summary>
        private MmgObj header;

        /// <summary>
        /// A place holder for the footer object.
        /// </summary>
        private MmgObj footer;

        /// <summary>
        /// A place holder for the left menu cursor.
        /// </summary>
        private MmgObj leftCursor;

        /// <summary>
        /// A place holder for the right menu cursor.
        /// </summary>
        private MmgObj rightCursor;

        /// <summary>
        /// A place holder for the message object of the game screen.
        /// </summary>
        private MmgObj message;

        /// <summary>
        /// The MmgMenuContainer place holder for holding a menu.
        /// </summary>
        private MmgMenuContainer menu;

        /// <summary>
        /// Helper variables for the menu.
        /// </summary>
        private int menuIdx;

        /// <summary>
        /// Helper variables for the menu.
        /// </summary>
        private int menuStart;

        /// <summary>
        /// Helper variables for the menu.
        /// </summary>
        private int menuStop;

        /// <summary>
        /// The X offset of the left menu cursor.
        /// </summary>
        private int menuCursorLeftOffsetX;

        /// <summary>
        /// The Y offset of the left menu cursor.
        /// </summary>
        private int menuCursorLeftOffsetY;

        /// <summary>
        /// The X offset of the right menu cursor.
        /// </summary>
        private int menuCursorRightOffsetX;

        /// <summary>
        /// The Y offset of the right menu cursor. 
        /// </summary>
        private int menuCursorRightOffsetY;

        /// <summary>
        /// Event handler for update events.
        /// </summary>
        private MmgUpdateHandler updateHandler;

        /// <summary>
        /// Flag to indicate if the menu is used on this game screen. 
        /// </summary>
        private bool menuOn;

        /// <summary>
        /// A private flag the holds a bool return value.
        /// </summary>
        private bool lret;

        /// <summary>
        /// Constructor for this class. 
        /// </summary>
        public MmgGameScreen() : base()
        {
            pause = false;
            ready = false;
            objects = new MmgContainer();
            menu = new MmgMenuContainer();
            background = null;
            foreground = null;
            header = null;
            footer = null;
            leftCursor = null;
            rightCursor = null;
            message = null;
            menuIdx = 0;
            menuStart = 0;
            menuStop = 0;
            SetMenuOn(false);
            SetWidth(MmgScreenData.GetGameWidth());
            SetHeight(MmgScreenData.GetGameHeight());
            SetPosition(MmgVector2.GetOriginVec());
        }

        /// <summary>
        /// Constructor that sets attributes based on the given argument.
        /// </summary>
        /// <param name="obj">The MmgGameScreen to use for attribute settings.</param>
        public MmgGameScreen(MmgGameScreen obj) : base()
        {
            if (obj.GetBackground() == null)
            {
                SetBackground(obj.GetBackground());
            }
            else
            {
                SetBackground(obj.GetBackground().Clone());
            }

            if (obj.GetFooter() == null)
            {
                SetFooter(obj.GetFooter());
            }
            else
            {
                SetFooter(obj.GetFooter().Clone());
            }

            SetHasParent(obj.GetHasParent());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetHeader() == null)
            {
                SetHeader(obj.GetHeader());
            }
            else
            {
                SetHeader(obj.GetHeader().Clone());
            }

            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetLeftCursor() == null)
            {
                SetLeftCursor(obj.GetLeftCursor());
            }
            else
            {
                SetLeftCursor(obj.GetLeftCursor().Clone());
            }

            if (obj.GetMenu() == null)
            {
                SetMenu(obj.GetMenu());
            }
            else
            {
                SetMenu(obj.GetMenu().CloneTyped());
            }

            SetMenuCursorLeftOffsetX(obj.GetMenuCursorLeftOffsetX());
            SetMenuCursorLeftOffsetY(obj.GetMenuCursorLeftOffsetY());
            SetMenuCursorRightOffsetX(obj.GetMenuCursorRightOffsetX());
            SetMenuCursorRightOffsetY(obj.GetMenuCursorRightOffsetY());
            SetMenuIdx(obj.GetMenuIdx());
            SetMenuOn(obj.GetMenuOn());
            SetMenuStart(obj.GetMenuStart());
            SetMenuStop(obj.GetMenuStop());

            if (obj.GetMessage() == null)
            {
                SetMessage(obj.GetMessage());
            }
            else
            {
                SetMessage(obj.GetMessage().Clone());
            }

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            SetName(obj.GetName());

            if (obj.GetObjects() == null)
            {
                SetObjects(obj.GetObjects());
            }
            else
            {
                SetObjects(obj.GetObjects().CloneTyped());
            }

            SetParent(obj.GetParent());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            if (obj.GetRightCursor() == null)
            {
                SetRightCursor(obj.GetRightCursor());
            }
            else
            {
                SetRightCursor(obj.GetRightCursor().Clone());
            }

            SetWidth(obj.GetWidth());
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgGameScreen(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class. </returns>
        public virtual new MmgGameScreen CloneTyped()
        {
            return new MmgGameScreen(this);
        }

        /// <summary>
        /// Gets the X axis cursor offset, left cursor.
        /// </summary>
        /// <returns>The X axis offset, left cursor.</returns>
        public virtual int GetMenuCursorLeftOffsetX()
        {
            return menuCursorLeftOffsetX;
        }

        /// <summary>
        /// Sets the X axis cursor offset, left cursor.
        /// </summary>
        /// <param name="i">The X axis offset, left cursor.</param>
        public virtual void SetMenuCursorLeftOffsetX(int i)
        {
            menuCursorLeftOffsetX = i;
        }

        /// <summary>
        /// Gets the Y axis cursor offset, left cursor.
        /// </summary>
        /// <returns>The Y axis offset, left cursor.</returns>
        public virtual int GetMenuCursorLeftOffsetY()
        {
            return menuCursorLeftOffsetY;
        }

        /// <summary>
        /// Sets the Y axis cursor offset, left cursor.
        /// </summary>
        /// <param name="i">The Y axis offset, left cursor.</param>
        public virtual void SetMenuCursorLeftOffsetY(int i)
        {
            menuCursorLeftOffsetY = i;
        }

        /// <summary>
        /// Gets the X axis cursor offset, right cursor.
        /// </summary>
        /// <returns>The X axis offset, right cursor.</returns>
        public virtual int GetMenuCursorRightOffsetX()
        {
            return menuCursorRightOffsetX;
        }

        /// <summary>
        /// Sets the X axis cursor offset, right cursor.
        /// </summary>
        /// <param name="i">The X axis offset, right cursor. </param>
        public virtual void SetMenuCursorRightOffsetX(int i)
        {
            menuCursorRightOffsetX = i;
        }

        /// <summary>
        /// Gets the Y axis cursor offset, right cursor.
        /// </summary>
        /// <returns>The Y axis offset, right cursor.</returns>
        public virtual int GetMenuCursorRightOffsetY()
        {
            return menuCursorRightOffsetY;
        }

        /// <summary>
        /// Sets the Y axis cursor offset, right cursor.
        /// </summary>
        /// <param name="i">The Y axis offset, right cursor.</param>
        public virtual void SetMenuCursorRightOffsetY(int i)
        {
            menuCursorRightOffsetY = i;
        }

        /// <summary>
        /// Gets true if this game screen has loaded its resources and is ready to display itself.
        /// </summary>
        /// <returns>True if this object is ready, false otherwise.</returns>
        public virtual bool IsReady()
        {
            return ready;
        }

        /// <summary>
        /// Sets if this game screen is ready to display itself.
        /// </summary>
        /// <param name="b">A bool indicating if this object is ready for display.</param>
        public virtual void SetReady(bool b)
        {
            ready = b;
        }

        /// <summary>
        /// Pauses this object. 
        /// If paused no drawing occurs.
        /// </summary>
        public virtual void Pause()
        {
            pause = true;
        }

        /// <summary>
        /// Un-pause this object. 
        /// If paused no drawing occurs.
        /// </summary>
        public virtual void UnPause()
        {
            pause = false;
        }

        /// <summary>
        /// Gets the pause state of this object.
        /// </summary>
        /// <returns>True if this object was paused, false otherwise.</returns>
        public virtual bool IsPaused()
        {
            return pause;
        }

        /// <summary>
        /// Gets if the menu is on.
        /// </summary>
        /// <returns>The menu on flag.</returns>
        public virtual bool GetMenuOn()
        {
            return menuOn;
        }

        /// <summary>
        /// Sets if the menu is on.
        /// </summary>
        /// <param name="m">The menu on flag.</param>
        public virtual void SetMenuOn(bool m)
        {
            menuOn = m;
        }

        /// <summary>
        /// Adds an MmgObj to the game screen.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public virtual void AddObj(MmgObj obj)
        {
            objects.Add(obj);
        }

        /// <summary>
        /// Removes an MmgObj from the game screen.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public virtual void RemoveObj(MmgObj obj)
        {
            objects.Remove(obj);
        }

        /// <summary>
        /// Clears the objects on this screen.
        /// </summary>
        public virtual void ClearObjs()
        {
            objects.Clear();
        }

        /// <summary>
        /// Event handler for processing simple menu events.
        /// </summary>
        /// <param name="e">The MmgEvent object to handle.</param>
        public virtual void EventHandler(MmgEvent e)
        {
            if (e.GetEventId() == MmgEvent.EVENT_ID_UP)
            {
                MoveMenuSelUp();
            }
            else if (e.GetEventId() == MmgEvent.EVENT_ID_DOWN)
            {
                MoveMenuSelDown();
            }
            else if (e.GetEventId() == MmgEvent.EVENT_ID_ENTER)
            {
                if (menu != null)
                {
                    object[] objs = menu.GetArray();
                    MmgMenuItem item = null;
                    item = (MmgMenuItem)objs[menuIdx];
                    ProcessMenuItemSel(item);
                }
            }
            else if (e.GetEventId() == MmgEvent.EVENT_ID_SPACE)
            {
                if (menu != null)
                {
                    object[] objs = menu.GetArray();
                    MmgMenuItem item = null;
                    item = (MmgMenuItem)objs[menuIdx];
                    ProcessMenuItemSel(item);
                }
            }
        }

        /// <summary>
        /// Gets the object container for this game screen.
        /// </summary>
        /// <returns>The MmgContainer used by this game screen.</returns>
        public virtual MmgContainer GetObjects()
        {
            return objects;
        }

        /// <summary>
        /// Sets the object container for this game screen.
        /// </summary>
        /// <param name="c">The MmgContainer used by this game screen.</param>
        public virtual void SetObjects(MmgContainer c)
        {
            objects = c;
        }

        /// <summary>
        /// Gets the background object for this game screen.
        /// </summary>
        /// <returns>The background object.</returns>
        public virtual MmgObj GetBackground()
        {
            return background;
        }

        /// <summary>
        /// Sets the background object for this game screen.
        /// </summary>
        /// <param name="b">The background object.</param>
        public virtual void SetBackground(MmgObj b)
        {
            background = b;
        }

        /// <summary>
        /// Sets the background object centered.
        /// </summary>
        /// <param name="b">The background object.</param>
        public virtual void SetCenteredBackground(MmgObj b)
        {
            MmgHelper.CenterHorAndVert(b);
            SetBackground(b);
        }

        /// <summary>
        /// Gets the foreground object.
        /// </summary>
        /// <returns>The foreground object.</returns>
        public virtual MmgObj GetForeground()
        {
            return foreground;
        }

        /// <summary>
        /// Sets the foreground object.
        /// </summary>
        /// <param name="b">The foreground object.</param>
        public virtual void SetForeground(MmgObj b)
        {
            foreground = b;
        }

        /// <summary>
        /// Gets the header object.
        /// </summary>
        /// <returns>The header object.</returns>
        public virtual MmgObj GetHeader()
        {
            return header;
        }

        /// <summary>
        /// Sets the header object.
        /// </summary>
        /// <param name="m">The header object.</param>
        public virtual void SetHeader(MmgObj m)
        {
            header = m;
        }

        /// <summary>
        /// Gets the footer object.
        /// </summary>
        /// <returns>The footer object.</returns>
        public virtual MmgObj GetFooter()
        {
            return footer;
        }

        /// <summary>
        /// Sets the footer object.
        /// </summary>
        /// <param name="m">The footer object.</param>
        public virtual void SetFooter(MmgObj m)
        {
            footer = m;
        }

        /// <summary>
        /// Gets the left menu cursor.
        /// </summary>
        /// <returns>The left menu cursor.</returns>
        public virtual MmgObj GetLeftCursor()
        {
            return leftCursor;
        }

        /// <summary>
        /// Sets the left menu cursor.
        /// </summary>
        /// <param name="m">The left menu cursor.</param>
        public virtual void SetLeftCursor(MmgObj m)
        {
            leftCursor = m;
        }

        /// <summary>
        /// Gets the right menu cursor.
        /// </summary>
        /// <returns>The right menu cursor.</returns>
        public virtual MmgObj GetRightCursor()
        {
            return rightCursor;
        }

        /// <summary>
        /// Sets the right menu cursor.
        /// </summary>
        /// <param name="m">The right menu cursor.</param>
        public virtual void SetRightCursor(MmgObj m)
        {
            rightCursor = m;
        }

        /// <summary>
        /// Gets the message object.
        /// </summary>
        /// <returns>The message object.</returns>
        public virtual MmgObj GetMessage()
        {
            return message;
        }

        /// <summary>
        /// Sets the message object.
        /// </summary>
        /// <param name="m">The message object.</param>
        public virtual void SetMessage(MmgObj m)
        {
            message = m;
        }

        /// <summary>
        /// Gets the MmgMenuContainer object.
        /// </summary>
        /// <returns>The MmgMenuContainer object.</returns>
        public virtual MmgMenuContainer GetMenu()
        {
            return menu;
        }

        /// <summary>
        /// Sets the MmgMenuContainer object.
        /// </summary>
        /// <param name="m">The MmgMenuContainer object.</param>
        public virtual void SetMenu(MmgMenuContainer m)
        {
            menu = m;
        }

        /// <summary>
        /// Gets the current menu item index.
        /// </summary>
        /// <returns>The menu item index.</returns>
        public virtual int GetMenuIdx()
        {
            return menuIdx;
        }

        /// <summary>
        /// Sets the current menu item index.
        /// </summary>
        /// <param name="i">The menu item index.</param>
        public virtual void SetMenuIdx(int i)
        {
            menuIdx = i;
        }

        /// <summary>
        /// Gets the menu start index.
        /// </summary>
        /// <returns>The menu start index.</returns>
        public virtual int GetMenuStart()
        {
            return menuStart;
        }

        /// <summary>
        /// Sets the menu start index.
        /// </summary>
        /// <param name="i">The menu start index.</param>
        public virtual void SetMenuStart(int i)
        {
            menuStart = i;
        }

        /// <summary>
        /// Gets the menu stop index.
        /// </summary>
        /// <returns>The menu stop index.</returns>
        public virtual int GetMenuStop()
        {
            return menuStop;
        }

        /// <summary>
        /// Sets the menu stop index.
        /// </summary>
        /// <param name="i">The menu stop index.</param>
        public virtual void SetMenuStop(int i)
        {
            menuStop = i;
        }

        /// <summary>
        /// Centers all default place holder object of this game screen. 
        /// </summary>
        public virtual void Centerobjects()
        {
            if (background != null)
            {
                background.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - background.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - background.GetHeight()) / 2));
            }

            if (header != null)
            {
                header.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - header.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - header.GetHeight()) / 2));
            }

            if (footer != null)
            {
                footer.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - footer.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - footer.GetHeight()) / 2));
            }

            if (message != null)
            {
                message.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - message.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - message.GetHeight()) / 2));
            }

            if (foreground != null)
            {
                foreground.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - foreground.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - foreground.GetHeight()) / 2));
            }
        }

        /// <summary>
        /// Sets a handler for the update event.
        /// </summary>
        /// <param name="u">An MmgUpdateHandler to handle events from this object.</param>
        public virtual void SetMmgUpdateHandler(MmgUpdateHandler u)
        {
            updateHandler = u;
        }

        /// <summary>
        /// Gets a handler for the update event.
        /// </summary>
        /// <returns>The MmgUpdateHandler that handles update events from this class.</returns>
        public virtual MmgUpdateHandler GetMmgUpdateHandler()
        {
            return updateHandler;
        }

        /// <summary>
        /// Fires an update event to the update handler.
        /// </summary>
        /// <param name="data">The event data to process.</param>
        public virtual void Update(object data)
        {
            if (updateHandler != null)
            {
                updateHandler.MmgHandleUpdate(data);
            }
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                if (background != null)
                {
                    background.MmgDraw(p);
                }

                if (header != null)
                {
                    header.MmgDraw(p);
                }

                if (footer != null)
                {
                    footer.MmgDraw(p);
                }

                if (message != null)
                {
                    message.MmgDraw(p);
                }

                if (objects != null)
                {
                    objects.MmgDraw(p);
                }

                if (menuOn == true)
                {
                    DrawMenu(p);
                }

                if (foreground != null)
                {
                    foreground.MmgDraw(p);
                }
            }
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number. </param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                if (message != null)
                {
                    if (message.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                    {
                        lret = true;
                    }
                }

                if (objects != null)
                {
                    if (objects.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                    {
                        lret = true;
                    }
                }

                if (foreground != null)
                {
                    if (foreground.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                    {
                        lret = true;
                    }
                }
            }

            return lret;
        }

        /// <summary>
        /// Expects a relative X, Y coordinate that takes into account the game's offset and the current panel's
        /// offset.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMouseMove(int x, int y)
        {
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y coordinate that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The X,Y coordinates of the mouse in MmgVector2 form.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMouseMove(MmgVector2 v)
        {
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMousePress(MmgVector2 v)
        {
            return ProcessMousePress(v.GetX(), v.GetY(), 0);
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset and a mouse button index, 0 - 2, left mouse button - right mouse button.
        /// </summary>
        /// <param name="v">he coordinates of the mouse event.</param>
        /// <param name="btnIndex">The index of the mouse button.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMousePress(MmgVector2 v, int btnIndex)
        {
            return ProcessMousePress(v.GetX(), v.GetY(), btnIndex);
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A boolean indicating if the event was handled or not.</returns>
        public virtual bool ProcessMousePress(int x, int y)
        {
            return ProcessMousePress(x, y, 0);
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <param name="btnIndex">The index of the mouse button.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMousePress(int x, int y, int btnIndex)
        {
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMouseRelease(MmgVector2 v)
        {
            return ProcessMousePress(v.GetX(), v.GetY(), 0);
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <param name="btnIndex">The index of the mouse button.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMouseRelease(MmgVector2 v, int btnIndex)
        {
            return ProcessMousePress(v.GetX(), v.GetY(), btnIndex);
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMouseRelease(int x, int y)
        {
            return ProcessMouseRelease(x, y, 0);
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <param name="btnIndex">The index of the mouse button.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public virtual bool ProcessMouseRelease(int x, int y, int btnIndex)
        {
            return true;
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public virtual bool ProcessMouseClick(MmgVector2 v)
        {
            return ProcessMouseClick(v.GetX(), v.GetY(), 0);
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="v">The coordinates of the click.</param>
        /// <param name="btnIndex">The index of the mouse button.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public virtual bool ProcessMouseClick(MmgVector2 v, int btnIndex)
        {
            return ProcessMouseClick(v.GetX(), v.GetY(), btnIndex);
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public virtual bool ProcessMouseClick(int x, int y)
        {
            return ProcessMouseClick(x, y, 0);
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <param name="btnIndex">The index of the mouse button.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public virtual bool ProcessMouseClick(int x, int y, int btnIndex)
        {
            if (menuOn == true && menu != null)
            {
                object[] objs = menu.GetArray();
                MmgMenuItem item = null;
                if (objs != null)
                {
                    for (int i = 0; i < objs.Length; i++)
                    {
                        item = (MmgMenuItem)objs[i];
                        if (x >= item.GetX() && x <= (item.GetX() + item.GetWidth()))
                        {
                            if (y >= item.GetY() && y <= (item.GetY() + item.GetHeight()))
                            {
                                menuIdx = i;
                                ProcessMenuItemSel(item);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// A method to handle A press events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessAPress(int src)
        {
            return true;
        }

        /// <summary>
        /// A method to handle A release events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessARelease(int src)
        {
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessAClick(int src)
        {
            return true;
        }

        /// <summary>
        /// A method to handle B press events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessBPress(int src)
        {
            return true;
        }

        /// <summary>
        /// A method to handle B release events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessBRelease(int src)
        {
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessBClick(int src)
        {
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public virtual void ProcessDebugClick()
        {

        }

        /// <summary>
        /// A method to handle keyboard press events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessKeyPress(char c, int code)
        {
            return true;
        }

        /// <summary>
        /// A method to handle keyboard release events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessKeyRelease(char c, int code)
        {
            return true;
        }

        /// <summary>
        /// A method to handle keyboard click events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessKeyClick(char c, int code)
        {
            return true;
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessDpadPress(int dir)
        {
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessDpadRelease(int dir)
        {
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public virtual bool ProcessDpadClick(int dir)
        {
            return true;
        }

        /// <summary>
        /// Fire the click event registered in the target menu item object.
        /// </summary>
        /// <param name="item">The menu item to fire a click event for.</param>
        public virtual void ProcessMenuItemSel(MmgMenuItem item)
        {
            if (item != null)
            {
                MmgEvent me = item.GetEventPress();
                if (me != null && me.GetTargetEventHandler() != null)
                {
                    me.GetTargetEventHandler().MmgHandleEvent(me);
                }
            }
        }

        /// <summary>
        /// Move the current menu selection up.
        /// </summary>
        public virtual void MoveMenuSelUp()
        {
            if (menuIdx - 1 >= menuStart)
            {
                menuIdx--;
            }
        }

        /// <summary>
        /// Move the current menu selection down.
        /// </summary>
        public virtual void MoveMenuSelDown()
        {
            if (menuIdx + 1 <= menuStop)
            {
                menuIdx++;
            }
        }

        /// <summary>
        /// Draws the current menu.
        /// </summary>
        /// <param name="p">The MmgPen object used to draw the menu.</param>
        private void DrawMenu(MmgPen p)
        {
            if (menu != null)
            {
                int padPosY = MmgHelper.ScaleValue(5);
                int padPosX = MmgHelper.ScaleValue(5);
                object[] objs = menu.GetArray();

                for (int i = 0; i < objs.Length; i++)
                {
                    if (objs[i] != null)
                    {
                        MmgMenuItem tmp = (MmgMenuItem)objs[i];
                        if (tmp != null && tmp.GetIsVisible() == true)
                        {
                            if (i == menuIdx)
                            {
                                if (tmp.GetState() != MmgMenuItem.STATE_INACTIVE)
                                {
                                    tmp.SetState(MmgMenuItem.STATE_SELECTED);
                                }
                            }
                            else
                            {
                                if (tmp.GetState() != MmgMenuItem.STATE_INACTIVE)
                                {
                                    tmp.SetState(MmgMenuItem.STATE_NORMAL);
                                }
                            }

                            tmp.MmgDraw(p);

                            if (menuIdx == i)
                            {
                                if (tmp.GetHeight() > leftCursor.GetHeight())
                                {
                                    padPosY = (tmp.GetHeight() - leftCursor.GetHeight()) / 2;
                                }
                                else
                                {
                                    padPosY = (leftCursor.GetHeight() - tmp.GetHeight()) / 2;
                                }

                                if (leftCursor != null)
                                {
                                    leftCursor.SetPosition(new MmgVector2((tmp.GetX() - leftCursor.GetWidth() - padPosX + menuCursorLeftOffsetX), tmp.GetY() + padPosY + menuCursorLeftOffsetY));
                                    leftCursor.MmgDraw(p);
                                }

                                if (rightCursor != null)
                                {
                                    rightCursor.SetPosition(new MmgVector2((tmp.GetX() + tmp.GetWidth() + padPosX + menuCursorRightOffsetY), tmp.GetY() + padPosY + menuCursorRightOffsetY));
                                    rightCursor.MmgDraw(p);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tests if this object is equal to another MmgGameScreen object.
        /// </summary>
        /// <param name="obj">An MmgGameScreen object instance to compare to.</param>
        /// <returns>Returns true if the objects are considered equal and false otherwise.</returns>
        public virtual bool ApiEquals(MmgGameScreen obj)
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
                && ((obj.GetBackground() == null && GetBackground() == null) || (obj.GetBackground() != null && GetBackground() != null && obj.GetBackground().ApiEquals(GetBackground())))
                && ((obj.GetFooter() == null && GetFooter() == null) || (obj.GetFooter() != null && GetFooter() != null && obj.GetFooter().ApiEquals(GetFooter())))
                && obj.GetHasParent() == GetHasParent()
                && ((obj.GetHeader() == null && GetHeader() == null) || (obj.GetHeader() != null && GetHeader() != null && obj.GetHeader().ApiEquals(GetHeader())))
                && ((obj.GetLeftCursor() == null && GetLeftCursor() == null) || (obj.GetLeftCursor() != null && GetLeftCursor() != null && obj.GetLeftCursor().ApiEquals(GetLeftCursor())))
                && ((obj.GetMenu() == null && GetMenu() == null) || (obj.GetMenu() != null && GetMenu() != null && obj.GetMenu().ApiEquals(GetMenu())))
                && obj.GetMenuCursorLeftOffsetX() == GetMenuCursorLeftOffsetX()
                && obj.GetMenuCursorLeftOffsetY() == GetMenuCursorLeftOffsetY()
                && obj.GetMenuCursorRightOffsetX() == GetMenuCursorRightOffsetX()
                && obj.GetMenuCursorRightOffsetY() == GetMenuCursorRightOffsetY()
                && obj.GetMenuIdx() == GetMenuIdx()
                && obj.GetMenuOn() == GetMenuOn()
                && obj.GetMenuStart() == GetMenuStart()
                && obj.GetMenuStop() == GetMenuStop()
                && ((obj.GetMessage() == null && GetMessage() == null) || (obj.GetMessage() != null && GetMessage() != null && obj.GetMessage().ApiEquals(GetMessage())))
                && ((obj.GetMmgColor() == null && GetMmgColor() == null) || (obj.GetMmgColor() != null && GetMmgColor() != null && obj.GetMmgColor().ApiEquals(GetMmgColor())))
                && ((obj.GetName() == null && GetName() == null) || (obj.GetName() != null && GetName() != null && obj.GetName().Equals(GetName())))
                && ((obj.GetObjects() == null && GetObjects() == null) || (obj.GetObjects() != null && GetObjects() != null && obj.GetObjects().ApiEquals(GetObjects())))
                && ((obj.GetRightCursor() == null && GetRightCursor() == null) || (obj.GetRightCursor() != null && GetRightCursor() != null && obj.GetRightCursor().ApiEquals(GetRightCursor())))
            )
            {
                ret = true;
            }

            return ret;
        }
    }
}