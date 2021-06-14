package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
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
public class ScreenTestMmgSprite extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

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
     * An MmgFont class instance used to provide information about the MmgSprite test on this test game screen.
     */
    private MmgFont spriteLabel1;
        
    /**
     * An MmgFont class instance used to provide information about the MmgSprite test on this test game screen.
     */
    private MmgFont spriteLabel2;    
    
    /**
     * An MmgBmp class instance that is the first frame in an animated series of MmgBmp frames.
     */
    private MmgBmp frame1;
    
    /**
     * An MmgBmp class instance that is the second frame in an animated series of MmgBmp frames.
     */
    private MmgBmp frame2;
    
    /**
     * An MmgBmp class instance that is the third frame in an animated series of MmgBmp frames.
     */
    private MmgBmp frame3;
    
    /**
     * An array used to store the MmgBmp frames used in the animation.
     */
    private MmgBmp[] frames1;
    
    /**
     * An array used to store the MmgBmp frames used in the animation.
     */
    private MmgBmp[] frames2;    
    
    /**
     * An MmgSprite class instance used to demonstrate multi-frame image in this test game screen.
     */
    private MmgSprite sprite1;
    
    /**
     * An MmgSprite class instance used to demonstrate multi-frame image in this test game screen.
     */
    private MmgSprite sprite2;    
    
    /**
     * An MmgFont class instance used as the title for the test game screen.
     */
    private MmgFont title;
    
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
    public ScreenTestMmgSprite(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmgSprite.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmgSprite.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmgSprite.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Sprite (8 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);
               
        frame1 = MmgHelper.GetBasicCachedBmp("soldier_frame_1.png");
        frame1 = MmgBmpScaler.ScaleMmgBmp(frame1, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame1);
        
        frame2 = MmgHelper.GetBasicCachedBmp("soldier_frame_2.png");    
        frame2 = MmgBmpScaler.ScaleMmgBmp(frame2, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame2);
        
        frame3 = MmgHelper.GetBasicCachedBmp("soldier_frame_3.png");
        frame3 = MmgBmpScaler.ScaleMmgBmp(frame3, 2.0f, true);
        MmgHelper.CenterHorAndVert(frame3);
        
        frames1 = new MmgBmp[4];
        frames1[0] = frame1;
        frames1[1] = frame2;
        frames1[2] = frame3;
        frames1[3] = frame2;
        
        frames2 = new MmgBmp[4];
        frames2[0] = frame1.CloneTyped();
        frames2[1] = frame2.CloneTyped();
        frames2[2] = frame3.CloneTyped();
        frames2[3] = frame2.CloneTyped();     
        
        MmgVector2 tmpPos = frame1.GetPosition().Clone();
        tmpPos.SetY(tmpPos.GetY() - MmgHelper.ScaleValue(30));
        sprite1 = new MmgSprite(frames1, tmpPos);
        sprite1.SetMsPerFrame(200l);
        AddObj(sprite1);
        
        spriteLabel1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        spriteLabel1.SetText("MmgSprite Example with 4 Frames");
        MmgHelper.CenterHorAndVert(spriteLabel1);
        spriteLabel1.SetY(sprite1.GetY() - MmgHelper.ScaleValue(20));
        AddObj(spriteLabel1);
        
        tmpPos = frame1.GetPosition().Clone();
        tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(90));
        sprite2 = new MmgSprite(frames2,  new MmgRect(0, 0, frame1.GetHeight()/2, frame1.GetWidth()/2), new MmgRect(tmpPos.GetX(), tmpPos.GetY(), tmpPos.GetY() + frame1.GetHeight()/2, tmpPos.GetX() + frame1.GetWidth()/2), MmgVector2.GetOriginVec(), MmgVector2.GetUnitVec(), 0.0f);
        sprite2.SetFrameTime(200l);
        sprite2.SetPosition(tmpPos);
        sprite2.SetSimpleRendering(false);
        AddObj(sprite2);
        
        spriteLabel2 = MmgFontData.CreateDefaultBoldMmgFontLg();
        spriteLabel2.SetText("MmgSprite Example with 4 Frames and Source/Destination Rectangles");        
        MmgHelper.CenterHorAndVert(spriteLabel2);
        spriteLabel2.SetY(sprite2.GetY() - MmgHelper.ScaleValue(20));
        AddObj(spriteLabel2);        
        
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmgSprite.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmgSprite.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_09);
        
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_07);
            
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessScreenClick");
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
        MmgHelper.wr("ScreenTestMmgSprite.ProcessKeyClick");
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        
        spriteLabel1 = null;
        spriteLabel2 = null;
        frame1 = null;
        frame2 = null;
        frame3 = null;
        frames1 = null;
        sprite1 = null;
        frames2 = null;
        sprite2 = null;        
        title = null;
        
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
            sprite1.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
            sprite2.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);            
        }

        return lret;
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
        MmgHelper.wr("ScreenTestMmgSprite.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMmgSprite.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
    }
}