package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * A class that represents a splash screen. 
 * Created by Middlemind Games 06/01/2005
 *
 * @author Victor G. Brusca
 */
public class MmgSplashScreen extends MmgGameScreen implements MmgUpdateHandler {

    /**
     * Inner class used to time how long to display the splash screen. 
     * Created by Middlemind Games 06/01/2005
     *
     * @author Victor G. Brusca
     */
    public class MmgSplashScreenTimer implements Runnable {

        /**
         * The display time to show the given splash screen.
         */
        private long displayTime;

        /**
         * The update handler to handle update event messages.
         */
        private MmgUpdateHandler update;

        /**
         * Generic constructor sets the display time in ms.
         *
         * @param DisplayTime   Splash screen display time in ms.
         */
        public MmgSplashScreenTimer(long DisplayTime) {
            displayTime = DisplayTime;
        }

        /**
         * Sets the update handler for this runnable. Calls back to the update
         * handler once the display time has passed.
         *
         * @param Update        A class that supports the MmgUpdateHandler interface.
         */
        public void SetUpdateHandler(MmgUpdateHandler Update) {
            update = Update;
        }

        /**
         * Start the display wait thread.
         */
        @Override
        public void run() {
            try {
                Thread.sleep(displayTime);

                if (update != null) {
                    MmgHelper.wr("MmgSplashScreen: run: Calling MmgHandleUpdate");
                    update.MmgHandleUpdate(null);
                }
            } catch (Exception e) {
                MmgHelper.wrErr(e);
            }
        }
    }

    /**
     * The display time to show this splash screen.
     */
    private int displayTime;

    /**
     * The update handler to handle update events.
     */
    private MmgUpdateHandler update;

    /**
     * The default display time.
     */
    public static int DEFAULT_DISPLAY_TIME_MS = 3000;

    /**
     * Constructor that sets the display time to the default display time.
     */
    public MmgSplashScreen() {
        super();
        SetDisplayTime(DEFAULT_DISPLAY_TIME_MS);
    }    
    
    /**
     * Constructor that sets the splash screen display time.
     *
     * @param DisplayTime       The display time for this splash screen, in milliseconds.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSplashScreen(int DisplayTime) {
        super();
        SetDisplayTime(DisplayTime);
    }

    /**
     * Constructor that sets the splash screen attributes based on the values of the given argument.
     *
     * @param obj       The display time in milliseconds.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgSplashScreen(MmgSplashScreen obj) { 
        super(obj);
        SetDisplayTime(obj.GetDisplayTime());
        
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
     * Starts the splash screen display.
     */
    public void StartDisplay() {
        MmgSplashScreenTimer s = new MmgSplashScreenTimer(displayTime);
        s.SetUpdateHandler(this);
        Runnable r = s;
        Thread t = new Thread(r);
        t.start();
    }

    /**
     * Sets the update event handler.
     *
     * @param Update    The update event handler.
     */
    public void SetUpdateHandler(MmgUpdateHandler Update) {
        update = Update;
    }
    
    /**
     * Gets the update event handler.
     * 
     * @return      The update event handler.
     */
    public MmgUpdateHandler GetUpdateHandler() {
        return update;
    }

    /**
     * Handles update events.
     *
     * @param obj       The update event to handle.
     */
    @Override
    public void MmgHandleUpdate(Object obj) {
        if (update != null) {
            update.MmgHandleUpdate(obj);
        }
    }

    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgSplashScreen(this);
    }

    /**
     * Creates a typed clone of this class.
     *
     * @return      A typed clone of this class.
     */
    @Override
    public MmgSplashScreen CloneTyped() {
        return new MmgSplashScreen(this);
    }    
    
    /**
     * Gets the current display time.
     *
     * @return      The current display time.
     */
    public int GetDisplayTime() {
        return displayTime;
    }

    /**
     * Sets the current display time.
     *
     * @param i   The current display time.
     */
    public void SetDisplayTime(int i) {
        displayTime = i;
    }

    /**
     * Draws this object to the screen.
     *
     * @param p     The MmgPen to draw this object with.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true && pause == false) {
            super.MmgDraw(p);
        }
    }
    
    /**
     * Tests if this object is equal to another MmgSplashScreen object.
     * 
     * @param obj   An MmgSplashScreen object instance to compare to.
     * @return      Returns true if the objects are considered equal and false otherwise.
     */
    public boolean ApiEquals(MmgSplashScreen obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        boolean ret = false;
        if (
            super.ApiEquals((MmgGameScreen)obj)
            && obj.GetDisplayTime() == GetDisplayTime()
        ) {
            ret = true;
        }
        return ret;
    }
}