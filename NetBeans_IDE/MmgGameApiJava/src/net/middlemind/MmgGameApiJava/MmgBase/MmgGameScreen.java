package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class that represents a basic game screen. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgGameScreen extends MmgObj {
    
    /**
     * Pause this screen.
     */
    public boolean pause;

    /**
     * Is this screen ready.
     */
    public boolean ready;

    /**
     * The MmgContainer that holds all the child objects.
     */
    private MmgContainer objects;

    /**
     * A place holder for the background object of the game screen.
     */
    private MmgObj background;

    /**
     * A place holder for the foreground object of the game screen.
     */
    private MmgObj foreground;

    /**
     * A place holder for the header object.
     */
    private MmgObj header;

    /**
     * A place holder for the footer object.
     */
    private MmgObj footer;

    /**
     * A place holder for the left menu cursor.
     */
    private MmgObj leftCursor;

    /**
     * A place holder for the right menu cursor.
     */
    private MmgObj rightCursor;

    /**
     * A place holder for the message object of the game screen.
     */
    private MmgObj message;

    /**
     * The MmgMenuContainer place holder for holding a menu.
     */
    private MmgMenuContainer menu;

    /**
     * Helper variables for the menu.
     */
    private int menuIdx;

    /**
     * Helper variables for the menu.
     */
    private int menuStart;

    /**
     * Helper variables for the menu.
     */
    private int menuStop;

    /**
     * The X offset of the left menu cursor.
     */
    private int menuCursorLeftOffsetX;
    
    /**
     * The Y offset of the left menu cursor.
     */
    private int menuCursorLeftOffsetY;
    
    /**
     * The X offset of the right menu cursor.
     */
    private int menuCursorRightOffsetX;
    
    /**
     * The Y offset of the right menu cursor.
     */
    private int menuCursorRightOffsetY;
    
    /**
     * Event handler for update events.
     */
    private MmgUpdateHandler updateHandler;

    /**
     * Flag to indicate if the menu is used on this game screen.
     */
    private boolean menuOn;

    /**
     * A private flag the holds a boolean return value.
     */
    private boolean lret;
    
    /**
     * Constructor for this class.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgGameScreen() {
        super();
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

    /**
     * Constructor that sets attributes based on the given argument.
     *
     * @param obj        The MmgGameScreen to use for attribute settings.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgGameScreen(MmgGameScreen obj) {
        super();
        if(obj.GetBackground() == null) {
            SetBackground(obj.GetBackground());
        } else {
            SetBackground(obj.GetBackground().Clone());
        }
        
        if(obj.GetFooter() == null) {
            SetFooter(obj.GetFooter());            
        } else {
            SetFooter(obj.GetFooter().Clone());
        }
        
        SetHasParent(obj.GetHasParent());
        SetIsVisible(obj.GetIsVisible());
                
        if(obj.GetHeader() == null) {
            SetHeader(obj.GetHeader());
        } else {
            SetHeader(obj.GetHeader().Clone());            
        }
        
        SetHeight(obj.GetHeight());
        SetIsVisible(obj.GetIsVisible());
        
        if(obj.GetLeftCursor() == null) {
            SetLeftCursor(obj.GetLeftCursor());
        } else {
            SetLeftCursor(obj.GetLeftCursor().Clone());
        }

        if(obj.GetMenu() == null) {
            SetMenu(obj.GetMenu());
        } else {
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
        
        if(obj.GetMessage() == null) {
            SetMessage(obj.GetMessage());
        } else {
            SetMessage(obj.GetMessage().Clone());
        }

        if(obj.GetMmgColor() == null) {
            SetMmgColor(obj.GetMmgColor());
        } else {
            SetMmgColor(obj.GetMmgColor().Clone());
        }
        
        SetName(obj.GetName());
        
        if(obj.GetObjects() == null) {
            SetObjects(obj.GetObjects());
        } else {
            SetObjects(obj.GetObjects().CloneTyped());
        }
        
        SetParent(obj.GetParent());
        
        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }
                        
        if(obj.GetRightCursor() == null) {
            SetRightCursor(obj.GetRightCursor());
        } else {
            SetRightCursor(obj.GetRightCursor().Clone());            
        }
                                
        SetWidth(obj.GetWidth());
    }

    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgGameScreen(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.  
     */
    @Override
    public MmgGameScreen CloneTyped() {
        return new MmgGameScreen(this);
    }
    
    /**
     * Gets the X axis cursor offset, left cursor.
     * 
     * @return      The X axis offset, left cursor.
     */
    public int GetMenuCursorLeftOffsetX() {
        return menuCursorLeftOffsetX;
    }

    /**
     * Sets the X axis cursor offset, left cursor.
     * 
     * @param i     The X axis offset, left cursor.
     */
    public void SetMenuCursorLeftOffsetX(int i) {
        menuCursorLeftOffsetX = i;
    }

    /**
     * Gets the Y axis cursor offset, left cursor.
     * 
     * @return      The Y axis offset, left cursor.
     */
    public int GetMenuCursorLeftOffsetY() {
        return menuCursorLeftOffsetY;
    }

    /**
     * Sets the Y axis cursor offset, left cursor.
     * 
     * @param i     The Y axis offset, left cursor.
     */
    public void SetMenuCursorLeftOffsetY(int i) {
        menuCursorLeftOffsetY = i;
    }

    /**
     * Gets the X axis cursor offset, right cursor.
     * 
     * @return      The X axis offset, right cursor.
     */
    public int GetMenuCursorRightOffsetX() {
        return menuCursorRightOffsetX;
    }

    /**
     * Sets the X axis cursor offset, right cursor.
     * 
     * @param i     The X axis offset, right cursor. 
     */
    public void SetMenuCursorRightOffsetX(int i) {
        menuCursorRightOffsetX = i;
    }

    /**
     * Gets the Y axis cursor offset, right cursor.
     * 
     * @return      The Y axis offset, right cursor.
     */
    public int GetMenuCursorRightOffsetY() {
        return menuCursorRightOffsetY;
    }

    /**
     * Sets the Y axis cursor offset, right cursor.
     * 
     * @param i     The Y axis offset, right cursor.
     */
    public void SetMenuCursorRightOffsetY(int i) {
        menuCursorRightOffsetY = i;
    }
    
    /**
     * Gets true if this game screen has loaded its resources and is ready to display itself.
     *
     * @return      True if this object is ready, false otherwise.
     */
    public boolean IsReady() {
        return ready;
    }

    /**
     * Sets if this game screen is ready to display itself.
     *
     * @param b     A boolean indicating if this object is ready for display.
     */
    public void SetReady(boolean b) {
        ready = b;
    }

    /**
     * Pauses this object. 
     * If paused no drawing occurs.
     */
    public void Pause() {
        pause = true;
    }

    /**
     * Un-pause this object. 
     * If paused no drawing occurs.
     */
    public void UnPause() {
        pause = false;
    }

    /**
     * Gets the pause state of this object.
     *
     * @return      True if this object was paused, false otherwise.
     */
    public boolean IsPaused() {
        return pause;
    }

    /**
     * Gets if the menu is on.
     *
     * @return      The menu on flag.
     */
    public boolean GetMenuOn() {
        return menuOn;
    }

    /**
     * Sets if the menu is on.
     *
     * @param m     The menu on flag.
     */
    public void SetMenuOn(boolean m) {
        menuOn = m;
    }

    /**
     * Adds an MmgObj to the game screen.
     *
     * @param obj   The object to add.
     */
    public void AddObj(MmgObj obj) {
        objects.Add(obj);
    }

    /**
     * Removes an MmgObj from the game screen.
     *
     * @param obj   The object to remove.
     */
    public void RemoveObj(MmgObj obj) {
        objects.Remove(obj);
    }

    /**
     * Clears the objects on this screen.
     */
    public void ClearObjs() {
        objects.Clear();
    }

    /**
     * Event handler for processing simple menu events.
     *
     * @param e     The MmgEvent object to handle.
     */
    @SuppressWarnings("UnusedAssignment")
    public void EventHandler(MmgEvent e) {
        if (e.GetEventId() == MmgEvent.EVENT_ID_UP) {
            MoveMenuSelUp();
        } else if (e.GetEventId() == MmgEvent.EVENT_ID_DOWN) {
            MoveMenuSelDown();
        } else if (e.GetEventId() == MmgEvent.EVENT_ID_ENTER) {
            if (menu != null) {
                Object[] objs = menu.GetArray();
                MmgMenuItem item = null;
                item = (MmgMenuItem) objs[menuIdx];
                ProcessMenuItemSel(item);
            }
        } else if (e.GetEventId() == MmgEvent.EVENT_ID_SPACE) {
            if (menu != null) {
                Object[] objs = menu.GetArray();
                MmgMenuItem item = null;
                item = (MmgMenuItem) objs[menuIdx];
                ProcessMenuItemSel(item);
            }
        }
    }

    /**
     * Gets the object container for this game screen.
     *
     * @return      The MmgContainer used by this game screen.
     */
    public MmgContainer GetObjects() {
        return objects;
    }

    /**
     * Sets the object container for this game screen.
     *
     * @param c     The MmgContainer used by this game screen.
     */
    public void SetObjects(MmgContainer c) {
        objects = c;
    }

    /**
     * Gets the background object for this game screen.
     *
     * @return      The background object.
     */
    public MmgObj GetBackground() {
        return background;
    }

    /**
     * Sets the background object for this game screen.
     *
     * @param b     The background object.
     */
    public void SetBackground(MmgObj b) {
        background = b;
    }

    /**
     * Sets the background object centered.
     *
     * @param b     The background object.
     * @see         MmgHelper
     */
    public void SetCenteredBackground(MmgObj b) {
        MmgHelper.CenterHorAndVert(b);
        SetBackground(b);
    }

    /**
     * Gets the foreground object.
     *
     * @return      The foreground object.
     */
    public MmgObj GetForeground() {
        return foreground;
    }

    /**
     * Sets the foreground object.
     *
     * @param b     The foreground object.
     */
    public void SetForeground(MmgObj b) {
        foreground = b;
    }

    /**
     * Gets the header object.
     *
     * @return      The header object.
     */
    public MmgObj GetHeader() {
        return header;
    }

    /**
     * Sets the header object.
     *
     * @param m     The header object.
     */
    public void SetHeader(MmgObj m) {
        header = m;
    }

    /**
     * Gets the footer object.
     *
     * @return      The footer object.
     */
    public MmgObj GetFooter() {
        return footer;
    }

    /**
     * Sets the footer object.
     *
     * @param m     The footer object.
     */
    public void SetFooter(MmgObj m) {
        footer = m;
    }

    /**
     * Gets the left menu cursor.
     *
     * @return      The left menu cursor.
     */
    public MmgObj GetLeftCursor() {
        return leftCursor;
    }

    /**
     * Sets the left menu cursor.
     *
     * @param m     The left menu cursor.
     */
    public void SetLeftCursor(MmgObj m) {
        leftCursor = m;
    }

    /**
     * Gets the right menu cursor.
     *
     * @return      The right menu cursor.
     */
    public MmgObj GetRightCursor() {
        return rightCursor;
    }

    /**
     * Sets the right menu cursor.
     *
     * @param m     The right menu cursor.
     */
    public void SetRightCursor(MmgObj m) {
        rightCursor = m;
    }

    /**
     * Gets the message object.
     *
     * @return      The message object.
     */
    public MmgObj GetMessage() {
        return message;
    }

    /**
     * Sets the message object.
     *
     * @param m     The message object.
     */
    public void SetMessage(MmgObj m) {
        message = m;
    }

    /**
     * Gets the MmgMenuContainer object.
     *
     * @return      The MmgMenuContainer object.
     */
    public MmgMenuContainer GetMenu() {
        return menu;
    }

    /**
     * Sets the MmgMenuContainer object.
     *
     * @param m     The MmgMenuContainer object.
     */
    public void SetMenu(MmgMenuContainer m) {
        menu = m;
    }

    /**
     * Gets the current menu item index.
     *
     * @return      The menu item index.
     */
    public int GetMenuIdx() {
        return menuIdx;
    }

    /**
     * Sets the current menu item index.
     *
     * @param i     The menu item index.
     */
    public void SetMenuIdx(int i) {
        menuIdx = i;
    }

    /**
     * Gets the menu start index.
     *
     * @return      The menu start index.
     */
    public int GetMenuStart() {
        return menuStart;
    }

    /**
     * Sets the menu start index.
     *
     * @param i     The menu start index.
     */
    public void SetMenuStart(int i) {
        menuStart = i;
    }

    /**
     * Gets the menu stop index.
     *
     * @return      The menu stop index.
     */
    public int GetMenuStop() {
        return menuStop;
    }

    /**
     * Sets the menu stop index.
     *
     * @param i     The menu stop index.
     */
    public void SetMenuStop(int i) {
        menuStop = i;
    }

    /**
     * Centers all default place holder object of this game screen.
     */
    public void CenterObjects() {
        if (background != null) {
            background.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - background.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - background.GetHeight()) / 2));
        }

        if (header != null) {
            header.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - header.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - header.GetHeight()) / 2));
        }

        if (footer != null) {
            footer.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - footer.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - footer.GetHeight()) / 2));
        }

        if (message != null) {
            message.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - message.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - message.GetHeight()) / 2));
        }

        if (foreground != null) {
            foreground.SetPosition(new MmgVector2((MmgScreenData.GetGameWidth() - foreground.GetWidth()) / 2, (MmgScreenData.GetGameHeight() - foreground.GetHeight()) / 2));
        }
    }

    /**
     * Sets a handler for the update event.
     *
     * @param u     An MmgUpdateHandler to handle events from this object.
     */
    public void SetMmgUpdateHandler(MmgUpdateHandler u) {
        updateHandler = u;
    }

    /**
     * Gets a handler for the update event.
     *
     * @return      The MmgUpdateHandler that handles update events from this class.
     */
    public MmgUpdateHandler GetMmgUpdateHandler() {
        return updateHandler;
    }

    /**
     * Fires an update event to the update handler.
     *
     * @param data  The event data to process.
     */
    public void Update(Object data) {
        if (updateHandler != null) {
            updateHandler.MmgHandleUpdate(data);
        }
    }

    /**
     * Base draw method, handles drawing this class.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (pause == false && isVisible == true) {
            if (background != null) {
                background.MmgDraw(p);
            }

            if (header != null) {
                header.MmgDraw(p);
            }

            if (footer != null) {
                footer.MmgDraw(p);
            }

            if (message != null) {
                message.MmgDraw(p);
            }

            if (objects != null) {
                objects.MmgDraw(p);
            }

            if (menuOn == true) {
                DrawMenu(p);
            }

            if (foreground != null) {
                foreground.MmgDraw(p);
            }
        }
    }

    /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick            The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done this game frame.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;

        if (pause == false && isVisible == true) {
            if (message != null) {
                if (message.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true) {
                    lret = true;
                }
            }

            if (objects != null) {
                if (objects.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true) {
                    lret = true;
                }
            }

            if (foreground != null) {
                if (foreground.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true) {
                    lret = true;
                }
            }
        }

        return lret;
    }

    /**
     * Expects a relative X, Y coordinate that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param x     The X coordinate of the mouse.
     * @param y     The Y coordinate of the mouse.
     * @return      A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMouseMove(int x, int y) {
        return true;
    }    
    
    /**
     * Expects a relative X, Y coordinate that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param v     The X,Y coordinates of the mouse in MmgVector2 form.
     * @return      A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMouseMove(MmgVector2 v) {
        return true;
    }        
    
    /**
     * Expects a relative X, Y vector that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param v     The coordinates of the mouse event.
     * @return      A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMousePress(MmgVector2 v) {
        return ProcessMousePress(v.GetX(), v.GetY(), 0);
    }

    /**
     * Expects a relative X, Y vector that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param v         The coordinates of the mouse event.
     * @param btnIndex  The index of the mouse button.
     * @return          A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMousePress(MmgVector2 v, int btnIndex) {
        return ProcessMousePress(v.GetX(), v.GetY(), btnIndex);
    }    
    
    /**
     * Expects a relative X, Y values that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param x     The X coordinate of the mouse.
     * @param y     The Y coordinate of the mouse.
     * @return      A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMousePress(int x, int y) {
        return ProcessMousePress(x, y, 0);
    }

    /**
     * Expects a relative X, Y values that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param x         The X coordinate of the mouse.
     * @param y         The Y coordinate of the mouse.
     * @param btnIndex  The index of the mouse button.
     * @return          A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMousePress(int x, int y, int btnIndex) {
        return true;
    }    
    
    /**
     * Expects a relative X, Y vector that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param v     The coordinates of the mouse event.
     * @return      A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMouseRelease(MmgVector2 v) {
        return ProcessMousePress(v.GetX(), v.GetY());
    }

    /**
     * Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
     * 
     * @param v         The coordinates of the mouse event.
     * @param btnIndex  The index of the mouse button.
     * @return          A bool indicating if the event was handled or not.
     */
    public boolean ProcessMouseRelease(MmgVector2 v, int btnIndex) {
        return ProcessMousePress(v.GetX(), v.GetY(), btnIndex);
    }    
    
    /**
     * Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
     * 
     * @param x     The X coordinate of the event.
     * @param y     The Y coordinate of the event.
     * @return      A boolean indicating if the event was handled or not.      
     */
    public boolean ProcessMouseRelease(int x, int y) {
        return ProcessMouseRelease(x, y, 0);
    }

    /**
     * Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
     * 
     * @param x         The X coordinate of the event.
     * @param y         The Y coordinate of the event.
     * @param btnIndex  The index of the mouse button.
     * @return          A boolean indicating if the event was handled or not.
     */
    public boolean ProcessMouseRelease(int x, int y, int btnIndex) {
        return true;
    }    
    
    /**
     * Process a screen click. 
     * Expects coordinate that don't take into account the offset of the game and panel.
     *
     * @param v     The coordinates of the click.
     * @return      Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.
     */
    public boolean ProcessMouseClick(MmgVector2 v) {
        return ProcessMouseClick(v.GetX(), v.GetY(), 0);
    }

    /**
     * Process a screen click. 
     * Expects coordinate that don't take into account the offset of the game and panel.
     * 
     * @param v         The coordinates of the click.
     * @param btnIndex  The index of the mouse button.
     * @return          Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.
     */
    public boolean ProcessMouseClick(MmgVector2 v, int btnIndex) {
        return ProcessMouseClick(v.GetX(), v.GetY(), btnIndex);
    }    
    
    /**
     * Process a screen click. 
     * Expects coordinate that don't take into account the offset of the game and panel.
     * 
     * @param x     The X axis coordinate of the screen click.
     * @param y     The Y axis coordinate of the screen click.
     * @return      Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.
     */
    public boolean ProcessMouseClick(int x, int y) {
        return ProcessMouseClick(x, y, 0);
    }    
    
    /**
     * Process a screen click. 
     * Expects coordinate that don't take into account the offset of the game and panel.
     *
     * @param x         The X axis coordinate of the screen click.
     * @param y         The Y axis coordinate of the screen click.
     * @param btnIndex The index of the mouse button.
     * @return          Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.
     */
    @SuppressWarnings("UnusedAssignment")
    public boolean ProcessMouseClick(int x, int y, int btnIndex) {
        if (menuOn == true && menu != null) {
            Object[] objs = menu.GetArray();
            MmgMenuItem item = null;
            if (objs != null) {
                for (int i = 0; i < objs.length; i++) {
                    item = (MmgMenuItem) objs[i];
                    if (x >= item.GetX() && x <= (item.GetX() + item.GetWidth())) {
                        if (y >= item.GetY() && y <= (item.GetY() + item.GetHeight())) {
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
    
    /**
     * A method to handle A press events.
     * 
     * @param src       The source gamepad, keyboard of the A event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessAPress(int src) {
        return true;
    }    
    
    /**
     * A method to handle A release events.
     * 
     * @param src       The source gamepad, keyboard of the A event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessARelease(int src) {
        return true;
    }    
    
    /**
     * A method to handle A click events.
     * 
     * @param src       The source gamepad, keyboard of the A event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessAClick(int src) {
        return true;
    }
    
    /**
     * A method to handle B press events.
     * 
     * @param src       The source gamepad, keyboard of the B event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessBPress(int src) {
        return true;
    }    
    
    /**
     * A method to handle B release events.
     * 
     * @param src       The source gamepad, keyboard of the B event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessBRelease(int src) {
        return true;
    }    
    
    /**
     * A method to handle B click events.
     * 
     * @param src       The source gamepad, keyboard of the B event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessBClick(int src) {
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    public void ProcessDebugClick() {

    }
    
    /**
     * A method to handle keyboard press events.
     * 
     * @param c         The key used in the event.
     * @param code      The code of the key used in the event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessKeyPress(char c, int code) {
        return true;
    }
    
    /**
     * A method to handle keyboard release events.
     * 
     * @param c         The key used in the event.
     * @param code      The code of the key used in the event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessKeyRelease(char c, int code) {
        return true;
    }
    
    /**
     * A method to handle keyboard click events.
     * 
     * @param c         The key used in the event.
     * @param code      The code of the key used in the event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessKeyClick(char c, int code) {
        return true;
    }    
    
    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessDpadPress(int dir) {
        return true;
    }
    
    /**
     * A method to handle dpad release events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessDpadRelease(int dir) {
        return true;
    }
    
    /**
     * A method to handle dpad click events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    public boolean ProcessDpadClick(int dir) {
        return true;
    }
    
    /**
     * Fire the click event registered in the target menu item object.
     *
     * @param item      The menu item to fire a click event for.
     * @see             MmgMenuItem
     */
    public void ProcessMenuItemSel(MmgMenuItem item) {
        if (item != null) {
            MmgEvent me = item.GetEventPress();
            if (me != null && me.GetTargetEventHandler() != null) {
                me.GetTargetEventHandler().MmgHandleEvent(me);
            }
        }
    }

    /**
     * Move the current menu selection up.
     */
    public void MoveMenuSelUp() {
        if (menuIdx - 1 >= menuStart) {
            menuIdx--;
        }
    }

    /**
     * Move the current menu selection down.
     */
    public void MoveMenuSelDown() {
        if (menuIdx + 1 <= menuStop) {
            menuIdx++;
        }
    }

    /**
     * Draws the current menu.
     *
     * @param p     The MmgPen object used to draw the menu.
     */
    private void DrawMenu(MmgPen p) {
        if (menu != null) {
            int padPosY = MmgHelper.ScaleValue(5);
            int padPosX = MmgHelper.ScaleValue(5);
            Object[] objs = menu.GetArray();

            for (int i = 0; i < objs.length; i++) {
                if (objs[i] != null) {
                    MmgMenuItem tmp = (MmgMenuItem) objs[i];
                    if (tmp != null && tmp.GetIsVisible() == true) {
                        if (i == menuIdx) {
                            if (tmp.GetState() != MmgMenuItem.STATE_INACTIVE) {
                                tmp.SetState(MmgMenuItem.STATE_SELECTED);
                            }
                        } else {
                            if (tmp.GetState() != MmgMenuItem.STATE_INACTIVE) {
                                tmp.SetState(MmgMenuItem.STATE_NORMAL);
                            }
                        }

                        tmp.MmgDraw(p);

                        if (menuIdx == i) {
                            if(tmp.GetHeight() > leftCursor.GetHeight()) {
                                padPosY = (tmp.GetHeight() - leftCursor.GetHeight()) / 2;
                            }else {
                                padPosY = (leftCursor.GetHeight() - tmp.GetHeight()) / 2;                                
                            }
                                                        
                            if (leftCursor != null) {
                                leftCursor.SetPosition(new MmgVector2((tmp.GetX() - leftCursor.GetWidth() - padPosX + menuCursorLeftOffsetX), tmp.GetY() + padPosY + menuCursorLeftOffsetY));
                                leftCursor.MmgDraw(p);
                            }

                            if (rightCursor != null) {
                                rightCursor.SetPosition(new MmgVector2((tmp.GetX() + tmp.GetWidth() + padPosX + menuCursorRightOffsetY), tmp.GetY() + padPosY + menuCursorRightOffsetY));
                                rightCursor.MmgDraw(p);
                            }
                        }
                    }
                }
            }
        }
    }
    
    /**
     * Tests if this object is equal to another MmgGameScreen object.
     * 
     * @param obj   An MmgGameScreen object instance to compare to.
     * @return      Returns true if the objects are considered equal and false otherwise.
     */    
    public boolean ApiEquals(MmgGameScreen obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
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
            && ((obj.GetName() == null && GetName() == null) || (obj.GetName() != null && GetName() != null && obj.GetName().equals(GetName())))
            && ((obj.GetObjects() == null && GetObjects() == null) || (obj.GetObjects() != null && GetObjects() != null && obj.GetObjects().ApiEquals(GetObjects())))
            && ((obj.GetRightCursor() == null && GetRightCursor() == null) || (obj.GetRightCursor() != null && GetRightCursor() != null && obj.GetRightCursor().ApiEquals(GetRightCursor())))
        ) {
            ret = true;
        }
    
        return ret;
    }
}