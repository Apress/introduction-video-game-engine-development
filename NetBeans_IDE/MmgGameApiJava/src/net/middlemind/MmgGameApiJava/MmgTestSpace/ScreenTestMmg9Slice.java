package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import net.middlemind.MmgGameApiJava.MmgCore.GameSettings;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventHandler;

/**
 * A game screen class that extends the MmgGameScreen base class.
 * This class is for testing API classes.
 * Created by Middlemind Games 02/25/2020
 * 
 * @author Victor G. Brusca
 */
public class ScreenTestMmg9Slice extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

    /**
     * The game state this screen has.
     */
    protected final GameStates gameState;

    /**
     * Event handler for firing generic events. Events would fire when the
     * screen has non UI actions to broadcast.
     */
    protected GenericEventHandler handler;

    /**
     * The GamePanel that owns this game screen. Usually a JPanel instance that
     * holds a reference to this game screen object.
     */
    protected final GamePanel owner;
        
    /**
     * An MmgFont class instance used to label the background MmgBmp class.
     */
    private MmgFont bgroundLabel;    
    
    /**
     * An MmgFont class instance used as the title of this test screen.
     */
    private MmgFont title;
    
    /**
     * An MmgBmp class instance used as the source of the Mmg9Slice scaling object.
     */
    private MmgBmp bground;
    
    /**
     * An MmgFont class instance used as the Mmg9Slice label.
     */
    private MmgFont menuBgroundLabel;    
    
    /**
     * An Mmg9Slice class instance used to scale the MmgBmp bground object.
     */
    private Mmg9Slice menuBground;
        
    /**
     * A private boolean flag indicating that there is work to be done on the next MmgUpdate call.
     */
    private boolean isDirty = false;
    
    /**
     * A private boolean flag indicating work was done during the MmgUpdate method call.
     */
    private boolean lret = false;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State         The game state of this game screen.
     * @param Owner         The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenTestMmg9Slice(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmg9Slice.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmg9Slice.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmg9Slice.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());

        MmgPen p;
        p = new MmgPen();
        p.SetCacheOn(false);

        int width = MmgHelper.ScaleValue(345);
        int height = MmgHelper.ScaleValue(300);
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg 9 Slice (2 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);
        
        bground = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
        MmgHelper.CenterHorAndVert(bground);
        bground.SetX(bground.GetX() - MmgHelper.ScaleValue(200));
        bground.SetY(bground.GetY() - MmgHelper.ScaleValue(32));
        AddObj(bground);
        
        bgroundLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bgroundLabel.SetText("Original MmgBmp");
        bgroundLabel.SetPosition(bground.GetPosition().Clone());
        bgroundLabel.SetY(bgroundLabel.GetY() - bgroundLabel.GetHeight());        
        AddObj(bgroundLabel);
        
        menuBground = new Mmg9Slice(MmgHelper.ScaleValue(16), bground, width, height);
        menuBground.SetPosition(MmgVector2.GetOriginVec());
        menuBground.SetWidth(width);
        menuBground.SetHeight(height);
        MmgHelper.CenterHorAndVert(menuBground);
        menuBground.SetX(menuBground.GetX() + MmgHelper.ScaleValue(200));
        menuBground.SetY(menuBground.GetY() + MmgHelper.ScaleValue(36));
        AddObj(menuBground);
        
        menuBgroundLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        menuBgroundLabel.SetText("MmgBmp Resized By Mmg9Slice");
        menuBgroundLabel.SetPosition(menuBground.GetPosition().Clone());
        menuBgroundLabel.SetY(menuBgroundLabel.GetY() - menuBgroundLabel.GetHeight());        
        AddObj(menuBgroundLabel);        
        
        ready = true;
        pause = false;
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_03);
            
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_01);

        }
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessScreenClick");
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
        MmgHelper.wr("ScreenTestMmg9Slice.ProcessKeyClick");
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        bground = null;
        bgroundLabel = null;
        title = null;
        menuBground = null;
        menuBgroundLabel = null;
        super.ClearObjs();
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
     * The callback method to handle GenericEventMessage objects.
     * 
     * @param obj       A GenericEventMessage object instance to process.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        MmgHelper.wr("ScreenTestMmg9Slice.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMmg9Slice.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());        
    }
}