package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import java.awt.Color;
import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDrawableBmpSet;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScrollHor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScrollHorVert;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScrollVert;
import net.middlemind.MmgGameApiJava.MmgBase.MmgTextField;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventHandler;

/**
 * A game screen object, ScreenTest, that extends the MmgGameScreen base class.
 * This class is for testing new UI widgets, etc.
 * Created by Middlemind Games 02/25/2020
 * 
 * @author Victor G. Brusca
 */
public class ScreenTest extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

    /**
     * The game state this screen has.
     */
    protected final GameStates gameState;

    /**
     * Event handler for firing generic events. 
     * Events would fire when the screen has non UI actions to broadcast.
     */
    protected GenericEventHandler handler;

    /**
     * The GamePanel that owns this game screen. 
     * Usually a JPanel instance that holds a reference to this game screen object.
     */
    protected final GamePanel owner;
    
    /**
     * An instance of the MmgScrollVert class for functionality testing.
     */
    protected MmgScrollVert scrollVert;
    
    /**
     * An instance of the MmgScrollHor class for functionality testing.
     */
    protected MmgScrollHor scrollHor;
    
    /**
     * An instance of the MmgScrollHorVert class for functionality testing.
     */
    protected MmgScrollHorVert scrollBoth;
    
    /**
     * An instance of the MmgBmp class to use as the scaled background source for an Mmg9Slice instance.
     */
    private MmgBmp bground;
    
    /**
     * An instance of the Mmg9Slice class used as the background image for the scroll panels.
     */
    private Mmg9Slice menuBground;
    
    /**
     * An instance of the MmgTextField class for functionality testing.
     */
    private MmgTextField txtField;
    
    /**
     * A boolean flag indicating if there is work to do in the next MmgUpdate call.
     */
    private boolean isDirty = false;
    
    /**
     * A private boolean flag used in the MmgUpdate method during the update process.
     */
    private boolean lret = false;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State         The game state of this game screen.
     * @param Owner         The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenTest(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        //SetMmgUpdateHandler(this);
        MmgHelper.wr("ScreenTest: Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTest.SetGenericEventHandler");
        handler = Handler;
    }

    /**
     * Gets the GenericEventHandler this game screen uses to handle GenericEvents.
     * 
     * @return      The GenericEventHandler this screen uses to handle GenericEvents.
     */
    public GenericEventHandler GetGenericEventHandler() {
        return handler;
    }
       
    /**
     * Loads all the resources needed to display this game screen.
     */
    @SuppressWarnings("UnusedAssignment")
    public void LoadResources() {
        MmgHelper.wr("ScreenTest.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());

        //MmgBmp tB = null;
        MmgPen p;
        p = new MmgPen();
        p.SetCacheOn(false);

        int totalWidth = MmgHelper.ScaleValue(210);
        int totalHeight = MmgHelper.ScaleValue(235);
        bground = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
        menuBground = new Mmg9Slice(16, bground, totalWidth, totalHeight);
        menuBground.SetPosition(MmgVector2.GetOriginVec());
        menuBground.SetWidth(totalWidth);
        menuBground.SetHeight(totalHeight);
        MmgHelper.CenterHorAndVert(menuBground);
        //AddObj(menuBground);
        
        int sWidth = 0;
        int sHeight = 0;
        MmgBmp vPort = null;
        MmgBmp sPane = null;
        MmgDrawableBmpSet dBmpSetScrollPane = null;
        MmgDrawableBmpSet dBmpSetViewPort = null;
        MmgColor sBarColor;
        MmgColor sBarSldrColor;
        int sBarWidth = 0;
        int sBarSldrHeight = 0;     
        int interval = 0;                
        int hund2 = MmgHelper.ScaleValue(200);
        int hund4 = MmgHelper.ScaleValue(400);
                
        sWidth = MmgHelper.ScaleValue(200);
        sHeight = MmgHelper.ScaleValue(200);
        
        dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund2, hund4, false, MmgColor.GetBlack());
        dBmpSetScrollPane.graphics.setColor(Color.RED);
        dBmpSetScrollPane.graphics.fillRect(0, 0, hund2, hund4 / 4);
        dBmpSetScrollPane.graphics.setColor(Color.BLUE);
        dBmpSetScrollPane.graphics.fillRect(0, hund4 / 4, hund2, hund4 / 4);
        dBmpSetScrollPane.graphics.setColor(Color.GREEN);
        dBmpSetScrollPane.graphics.fillRect(0, hund4 / 2, hund2, hund4 / 4);
        
        dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
        dBmpSetViewPort.graphics.setColor(Color.LIGHT_GRAY);
        dBmpSetViewPort.graphics.fillRect(0, 0, hund2, hund2);
        
        //vPort = new MmgBmp(new MmgObj(0, 0, hund2, hund2, true, MmgColor.GetRed()));        
        //sPane = new MmgBmp(new MmgObj(0, 0, hund2, hund4, true, MmgColor.GetBlue()));        
        vPort = dBmpSetViewPort.img;
        sPane = dBmpSetScrollPane.img;
        
        sBarColor = MmgColor.GetLightGray();
        sBarSldrColor = MmgColor.GetGray();
        sBarWidth = MmgHelper.ScaleValue(15);
        sBarSldrHeight = MmgHelper.ScaleValue(30);
        interval = 10;
        
        scrollVert = new MmgScrollVert(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarSldrHeight, interval);
        //scrollVert = new MmgScrollVert(vPort, sPane, sBarColor, sBarSldrColor, interval, state);        
        scrollVert.SetIsVisible(true);
        scrollVert.SetWidth(sWidth + scrollVert.GetScrollBarWidth());
        scrollVert.SetHeight(sHeight);
        //scrollVert.SetHandler(this);    
        MmgScrollVert.SHOW_CONTROL_BOUNDING_BOX = true;
        MmgHelper.CenterHorAndVert(scrollVert);
        //AddObj(scrollVert);
        
        dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund4, hund2, false, MmgColor.GetBlack());
        dBmpSetScrollPane.graphics.setColor(Color.RED);
        dBmpSetScrollPane.graphics.fillRect(0, 0, hund4 / 4, hund2);
        dBmpSetScrollPane.graphics.setColor(Color.BLUE);
        dBmpSetScrollPane.graphics.fillRect(hund4 / 4, 0, hund4 / 4, hund2);
        dBmpSetScrollPane.graphics.setColor(Color.GREEN);
        dBmpSetScrollPane.graphics.fillRect(hund4 / 2, 0, hund4 / 4, hund2);
        
        dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
        dBmpSetViewPort.graphics.setColor(Color.LIGHT_GRAY);
        dBmpSetViewPort.graphics.fillRect(0, 0, hund2, hund2);
                        
        //vPort = new MmgBmp(new MmgObj(0, 0, hund2, hund2, true, MmgColor.GetRed()));
        //sPane = new MmgBmp(new MmgObj(0, 0, hund4, hund2, true, MmgColor.GetBlue()));        
        vPort = dBmpSetViewPort.img;
        sPane = dBmpSetScrollPane.img;
        
        sBarColor = MmgColor.GetLightGray();
        sBarSldrColor = MmgColor.GetGray();
        sBarWidth = MmgHelper.ScaleValue(15);
        sBarSldrHeight = MmgHelper.ScaleValue(30);
        interval = 10;        
        
        scrollHor = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarSldrHeight, interval);
        //scrollHor = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, interval, state);        
        scrollHor.SetIsVisible(true);
        scrollHor.SetWidth(sWidth);
        scrollHor.SetHeight(sHeight + scrollHor.GetScrollBarHeight());
        //scrollHor.SetHandler(this);
        MmgScrollHor.SHOW_CONTROL_BOUNDING_BOX = true;
        MmgHelper.CenterHorAndVert(scrollHor);
        //AddObj(scrollHor);

        dBmpSetScrollPane = MmgHelper.CreateDrawableBmpSet(hund4, hund4, false, MmgColor.GetBlack());
        dBmpSetScrollPane.graphics.setColor(Color.RED);
        dBmpSetScrollPane.graphics.fillRect(0, 0, hund4 / 4, hund4 / 4);
        dBmpSetScrollPane.graphics.setColor(Color.BLUE);
        dBmpSetScrollPane.graphics.fillRect(hund4 / 4, hund4 / 4, hund4 / 4, hund4 / 4);
        dBmpSetScrollPane.graphics.setColor(Color.GREEN);
        dBmpSetScrollPane.graphics.fillRect(hund4 / 2, hund4 / 2, hund4 / 4, hund4 / 4);
        
        dBmpSetViewPort = MmgHelper.CreateDrawableBmpSet(hund2, hund2, false, MmgColor.GetBlack());
        dBmpSetViewPort.graphics.setColor(Color.LIGHT_GRAY);
        dBmpSetViewPort.graphics.fillRect(0, 0, hund2, hund2);
                        
        vPort = new MmgBmp(new MmgObj(0, 0, hund2, hund2, true, MmgColor.GetRed()));
        sPane = new MmgBmp(new MmgObj(0, 0, hund4, hund4, true, MmgColor.GetBlue()));
        vPort = dBmpSetViewPort.img;
        sPane = dBmpSetScrollPane.img;
        
        sBarColor = MmgColor.GetLightGray();
        sBarSldrColor = MmgColor.GetGray();       
        sBarWidth = MmgHelper.ScaleValue(15);
        sBarSldrHeight = MmgHelper.ScaleValue(30);
        interval = 10;         
       
        scrollBoth = new MmgScrollHorVert(vPort, sPane, sBarColor, sBarSldrColor, sBarWidth, sBarWidth, sBarSldrHeight, sBarSldrHeight, interval, interval);
        //scrollBoth = new MmgScrollHor(vPort, sPane, sBarColor, sBarSldrColor, interval, state);        
        scrollBoth.SetIsVisible(true);
        scrollBoth.SetWidth(sWidth + scrollBoth.GetScrollBarVertWidth());
        scrollBoth.SetHeight(sHeight + scrollBoth.GetScrollBarHorHeight());
        //scrollBoth.SetHandler(this);
        scrollBoth.SetEventHandler(this);
        MmgScrollHorVert.SHOW_CONTROL_BOUNDING_BOX = true;
        MmgHelper.CenterHorAndVert(scrollBoth);
        AddObj(scrollBoth);
        
        txtField = new MmgTextField(bground, MmgFontData.CreateDefaultMmgFontLg(), 200, 50, 12, 15);
        txtField.SetPosition(50, 100);
        AddObj(txtField);
        
        ready = true;
        pause = false;
        MmgHelper.wr("ScreenTest: LoadResources");
    }

    /**
     * Expects a relative X, Y vector that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param v     The coordinates of the mouse event.
     * @return      A boolean indicating if the event was handled or not.
     */    
    @Override
    public boolean ProcessMousePress(MmgVector2 v) {
        MmgHelper.wr("ScreenTest.ProcessScreenPress");
        return ProcessMousePress(v.GetX(), v.GetY());
    }

    /**
     * Expects a relative X, Y values that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param x     The X coordinate of the mouse.
     * @param y     The Y coordinate of the mouse.
     * @return      A boolean indicating if the event was handled or not.
     */    
    @Override
    public boolean ProcessMousePress(int x, int y) {
        MmgHelper.wr("ScreenTest.ProcessScreenPress");
        return true;
    }

    /**
     * Expects a relative X, Y vector that takes into account the game's offset and the current panel's
     * offset.
     * 
     * @param v     The coordinates of the mouse event.
     * @return      A boolean indicating if the event was handled or not.
     */    
    @Override
    public boolean ProcessMouseRelease(MmgVector2 v) {
        MmgHelper.wr("ScreenTest.ProcessScreenRelease");
        return ProcessMousePress(v.GetX(), v.GetY());
    }

    /**
     * Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
     * 
     * @param x     The X coordinate of the event.
     * @param y     The Y coordinate of the event.
     * @return      A boolean indicating if the event was handled or not.      
     */    
    @Override
    public boolean ProcessMouseRelease(int x, int y) {
        MmgHelper.wr("ScreenTest.ProcessScreenRelease");
        return true;
    }
    
    /**
     * A method to handle A click events.
     * 
     * @param src       The source gamepad, keyboard of the A event.
     * @return          A boolean indicating if this event was handled or not.
     */    
    @Override
    public boolean ProcessAClick(int src) {
        MmgHelper.wr("ScreenTest.ProcessAClick");
        return true;
    }
    
    /**
     * A method to handle B click events.
     * 
     * @param src       The source gamepad, keyboard of the B event.
     * @return          A boolean indicating if this event was handled or not.
     */    
    @Override
    public boolean ProcessBClick(int src) {
        MmgHelper.wr("ScreenTest.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */    
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTest.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */    
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTest.ProcessDpadPress: " + dir);
        return true;
    }

    /**
     * A method to handle dpad release events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */    
    @Override
    public boolean ProcessDpadRelease(int dir) {
        MmgHelper.wr("ScreenTest.ProcessDpadRelease: " + dir);
        scrollVert.ProcessDpadRelease(dir);
        scrollHor.ProcessDpadRelease(dir);
        scrollBoth.ProcessDpadRelease(dir);
        isDirty = true;
        return true;
    }
    
    /**
     * A method to handle dpad click events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */    
    @Override
    public boolean ProcessDpadClick(int dir) {
        MmgHelper.wr("ScreenTest.ProcessDpadClick: " + dir);        
        return true;
    }
    
    /**
     * Process a screen click. 
     * Expects coordinate that don't take into account the offset of the game and panel.
     *
     * @param v     The coordinates of the click.
     * @return      Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.
     */    
    @Override
    public boolean ProcessMouseClick(MmgVector2 v) {
        MmgHelper.wr("ScreenTest.ProcessScreenClick");        
        return ProcessMouseClick(v.GetX(), v.GetY());
    }

    /**
     * Process a screen click. 
     * Expects coordinate that don't take into account the offset of the game and panel.
     *
     * @param x     The X axis coordinate of the screen click.
     * @param y     The Y axis coordinate of the screen click.
     * @return      Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.
     */    
    @Override
    public boolean ProcessMouseClick(int x, int y) {
        MmgHelper.wr("ScreenTest.ProcessScreenClick");
        scrollVert.ProcessScreenClick(x, y);
        scrollHor.ProcessScreenClick(x, y);
        scrollBoth.ProcessScreenClick(x, y);
        isDirty = true;
        return true;
    }    
    
    /**
     * A method to handle keyboard click events.
     * 
     * @param c         The key used in the event.
     * @param code      The code of the key used in the event.
     * @return          A boolean indicating if this event was handled or not.
     */    
    @Override
    public boolean ProcessKeyClick(char c, int code) {
        if(Character.isLetterOrDigit(c)) {
            txtField.ProcessKeyClick(c, code);            
        } else if(code == 8) {
            txtField.DeleteChar();
        }
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        ClearObjs();
        ready = false;
    }

    /**
     * Returns the game state of this game screen.
     *
     * @return      The game state of this game screen.
     */
    public GameStates GetGameState() {
        return gameState;
    }
    
    /**
     * Base draw method, handles drawing this class.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (pause == false && isVisible == true) {
            super.MmgDraw(p);
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
            //always run this update
            txtField.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
            
            if (isDirty == true) {
                super.GetObjects().SetIsDirty(true);            

                if (super.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true) {
                    lret = true;
                }
            }
        }

        return lret;
    }

    /**
     * The callback method to handle GenericEventMessage objects.
     * 
     * @param obj       A GenericEventMessage object instance to process.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        MmgHelper.wr("ScreenTest.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        if(obj.id == MmgScrollVert.SCROLL_VERT_CLICK_EVENT_ID || obj.id == MmgScrollHor.SCROLL_HOR_CLICK_EVENT_ID || obj.id == MmgScrollHorVert.SCROLL_BOTH_CLICK_EVENT_ID) {
            MmgVector2 v2 = (MmgVector2)obj.payload;
            MmgHelper.wr("ScreenTest.HandleGenericEvent: " + v2.ApiToString());
        }
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr(e.ApiToString());
    }
}