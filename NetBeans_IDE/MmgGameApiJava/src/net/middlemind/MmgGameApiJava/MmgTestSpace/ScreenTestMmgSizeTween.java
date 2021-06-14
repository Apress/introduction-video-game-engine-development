package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPositionTween;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScaleHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSizeTween;
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
public class ScreenTestMmgSizeTween extends MmgGameScreen implements GenericEventHandler, MmgEventHandler, MmgScaleHandler {

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
     * An MmgBmp class instance used to hold a frame in an MmgBmp animation.
     */
    private MmgBmp frame1;
    
    /**
     * An MmgBmp class instance used to hold a frame in an MmgBmp animation.
     */
    private MmgBmp frame2;
    
    /**
     * An MmgBmp class instance used to hold a frame in an MmgBmp animation.
     */
    private MmgBmp frame3;
    
    /**
     * An array of MmgBmp instances that is used to hold references to a series of frames in the animation.
     */
    private MmgBmp[] frames;
    
    /**
     * An MmgSprite class instance used to animate an array of MmgBmp frames.
     */
    private MmgSprite sprite1;    
    
    /**
     * An MmgSprite class instance used to animate an array of MmgBmp frames.
     */
    private MmgSprite sprite2;        
    
    /**
     * An MmgPositionTween class instance used to move an MmgObj between positions.
     */
    private MmgSizeTween sizeTween;
                
    /**
     * An MmgFont class instance that is used to label the MmgPositionTween in this test game screen.
     */
    private MmgFont posTweenLabel;
    
    /**
     * An MmgFont class instance that is used to label the event associated with the MmgPositionTween.
     */
    private MmgFont eventLabel;    
        
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
    public ScreenTestMmgSizeTween(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmgSizeTween.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmgSizeTween.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
                
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Size Tween (25 / " + GamePanel.TOTAL_TESTS + ")  >");
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
        
        frames = new MmgBmp[4];
        frames[0] = frame1;
        frames[1] = frame2;
        frames[2] = frame3;
        frames[3] = frame2;        
        
        MmgVector2 tmpPos = frame1.GetPosition().Clone();
        tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(15));
        sprite1 = new MmgSprite(frames, tmpPos);
        sprite1.SetFrameTime(200l);
        AddObj(sprite1);
        
        sprite2 = sprite1.CloneTyped();
        
        posTweenLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        posTweenLabel.SetText("MmgSprite Example with 4 Frames Attached to an MmgSizeTween");
        MmgHelper.CenterHorAndVert(posTweenLabel);
        posTweenLabel.SetY(GetY() + MmgHelper.ScaleValue(70));
        AddObj(posTweenLabel);
        
        MmgVector2 start = new MmgVector2(MmgHelper.ScaleValue(64), MmgHelper.ScaleValue(64));
        MmgVector2 stop = new MmgVector2(MmgHelper.ScaleValue(128), MmgHelper.ScaleValue(128));
        
        sizeTween = new MmgSizeTween(sprite1, 5000, start, stop);
        sizeTween.SetOnReachStart(this);
        sizeTween.SetOnReachFinish(this);
        sizeTween.SetMsStartChange(System.currentTimeMillis());
        sizeTween.SetChanging(true);
        sizeTween.SetOnSubjScale(this);
        sizeTween.SetSubjOrig(sprite2);
        
        eventLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        eventLabel.SetText("Event:");
        MmgHelper.CenterHor(eventLabel);
        eventLabel.SetY(GetY() + GetHeight() - MmgHelper.ScaleValue(30));
        AddObj(eventLabel); 
        
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_26);
        
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_24);
            
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessScreenClick");
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
        MmgHelper.wr("ScreenTestMmgSizeTween.ProcessKeyClick");
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);

        title = null;
        frame1 = null;
        frame2 = null;
        frame3 = null;
        frames = null;
        sprite1 = null;
        sizeTween = null;
        posTweenLabel = null;
        eventLabel = null;
        
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
            sizeTween.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
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
        MmgHelper.wr("ScreenTestMmgSizeTween.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMmgSizeTween.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        eventLabel.SetText("Event: " + e.GetMessage() + " Id: " + e.GetEventId() + " Type: " + e.GetEventType());
        MmgHelper.CenterHor(eventLabel);
        if(e.GetEventId() == MmgPositionTween.MMG_POSITION_TWEEN_REACH_FINISH) {
            sizeTween.SetDirStartToFinish(false);
            sizeTween.SetMsStartChange(System.currentTimeMillis());
            sizeTween.SetChanging(true);
            
        } else {
            sizeTween.SetDirStartToFinish(true);
            sizeTween.SetMsStartChange(System.currentTimeMillis());        
            sizeTween.SetChanging(true);            
        
        }
    }

    /**
     * An event handler used to handle scaling events.
     * 
     * @param v     The scaling parameters for the X and Y axis.
     * @param orig  An MmgObj object instance that is the original, unscaled object.
     */
    @Override
    public void MmgHandleScale(MmgVector2 v, MmgObj orig) {
        if(orig instanceof MmgBmp) {
            sizeTween.SetSubj(MmgBmpScaler.ScaleMmgBmp((MmgBmp)orig, v, true));
        } else if(orig instanceof MmgSprite) {
            MmgSprite s = ((MmgSprite)orig);
            MmgBmp b = s.GetCurrentFrame().CloneTyped();
            b = MmgBmpScaler.ScaleMmgBmp(b, v, true);
            s = ((MmgSprite)sizeTween.GetSubj());
            s.SetCurrentFrame(b);            
        } else if(orig instanceof MmgObj) {
            orig.SetWidth(v.GetX());
            orig.SetWidth(v.GetY());
        }
        MmgHelper.CenterHor(sizeTween.GetSubj());        
    }
}