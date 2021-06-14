package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDrawableBmpSet;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
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
public class ScreenTestMmgBmp extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

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
     * An MmgBmp class instance that is loaded from the MmgBmp cache.
     */
    private MmgBmp bmpCache;
    
    /**
     * An MmgFont class instance used as a label for the MmgBmp loaded from the cache.
     */
    private MmgFont bmpCacheLabel;
    
    /**
     * An MmgBmp class instance that is loaded from a file path.
     */
    private MmgBmp bmpFile;
    
    /**
     * An MmgFont class instance used as a label for the MmgBmp loaded from a file.
     */
    private MmgFont bmpFileLabel;    
    
    /**
     * An MmgBmp class instance that is an example of a custom color fill.
     */
    private MmgBmp bmpCustomFill;
    
    /**
     * An MmgFont class instance used as a label for the MmgBmp that is an example of a custom color fill.
     */
    private MmgFont bmpCustomFillLabel;
    
    /**
     * An MmgBmp class instance that is an example of a partial copy of another MmgBmp.
     */
    private MmgBmp bmpPartialCopy;
    
    /**
     * An MmgFont class instance used as a label for the MmgBmp that is an example of a partial copy of another MmgBmp.
     */
    private MmgFont bmpPartialCopyLabel;    
        
    /**
     * An MmgDrawableBmpSet class instance that is an example of creating a custom bitmap crawing set.
     */
    private MmgDrawableBmpSet bmpSet;
    
    /**
     * An MmgRect class instance used as the source rectangle for a custom bitmap copy.
     */
    private MmgRect srcRect;
    
    /**
     * An MmgRect class instance used as the destination rectangle for a custom bitmap copy.
     */
    private MmgRect dstRect;
    
    /**
     * An MmgFont class instance used as the title of the test game screen.
     */
    private MmgFont title;
    
    /**
     * An MmgBmp class instance used as an example of the MmgBmp scaling process.
     */
    private MmgBmp bmpScaled;
    
    /**
     * An MmgFont class instance used as a label for the MmgBmp that is an example of bitmap scaling.
     */
    private MmgFont bmpScaledLabel;
    
    /**
     * An MmgFont class instance used as an example of the MmgBmp rotation process.
     */
    private MmgBmp bmpRotate;
    
    /**
     * An MmgFont class instance used as a label for the MmgBmp that is an example of the MmgBmp rotation process.
     */
    private MmgFont bmpRotateLabel;
    
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
    public ScreenTestMmgBmp(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmgBmp.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmgBmp.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmgBmp.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Bmp (5 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);         
        
        bmpCache = MmgHelper.GetBasicCachedBmp("soldier_frame_1.png");
        bmpCache.SetY(GetY() + MmgHelper.ScaleValue(90));
        bmpCache.SetX(MmgHelper.ScaleValue(220));
        AddObj(bmpCache);

        bmpCacheLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bmpCacheLabel.SetText("MmgBmp From Auto Load Cache");
        bmpCacheLabel.SetPosition(MmgHelper.ScaleValue(50), GetY() + MmgHelper.ScaleValue(70));
        AddObj(bmpCacheLabel);
        
        bmpFile = MmgHelper.GetBasicCachedBmp("../cfg/drawable/loading_bar.png", "loading_bar.png");
        bmpFile.SetY(GetY() + MmgHelper.ScaleValue(90));
        bmpFile.SetX(MmgHelper.ScaleValue(560));
        AddObj(bmpFile);
        
        bmpFileLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bmpFileLabel.SetText("MmgBmp From Path");
        bmpFileLabel.SetPosition(MmgHelper.ScaleValue(545), GetY() + MmgHelper.ScaleValue(70));
        AddObj(bmpFileLabel);
        
        bmpCustomFill = MmgHelper.CreateFilledBmp(MmgHelper.ScaleValue(50), MmgHelper.ScaleValue(50), MmgColor.GetCalmBlue());
        bmpCustomFill.SetY(GetY() + MmgHelper.ScaleValue(210));
        bmpCustomFill.SetX(MmgHelper.ScaleValue(205));
        AddObj(bmpCustomFill);        
        
        bmpCustomFillLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bmpCustomFillLabel.SetText("MmgBmp Created Custom with Fill");
        bmpCustomFillLabel.SetPosition(MmgHelper.ScaleValue(45), GetY() + MmgHelper.ScaleValue(190));
        AddObj(bmpCustomFillLabel);
                
        bmpSet = MmgHelper.CreateDrawableBmpSet(bmpCache.GetWidth()/2, bmpCache.GetHeight()/2, true);
        srcRect = new MmgRect(0, 0, bmpCache.GetHeight()/2, bmpCache.GetWidth()/2);
        dstRect = new MmgRect(0, 0, bmpCache.GetHeight()/2, bmpCache.GetWidth()/2);        
        bmpSet.p.DrawBmp(bmpCache, srcRect, dstRect);
        
        bmpSet.img.SetY(GetY() + MmgHelper.ScaleValue(210));
        bmpSet.img.SetX(MmgHelper.ScaleValue(650));
        AddObj(bmpSet.img);        
        
        bmpPartialCopyLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bmpPartialCopyLabel.SetText("MmgBmp Custom with Copy");
        bmpPartialCopyLabel.SetPosition(MmgHelper.ScaleValue(505), GetY() + MmgHelper.ScaleValue(190));
        AddObj(bmpPartialCopyLabel);        
        
        bmpScaled = MmgBmpScaler.ScaleMmgBmp(bmpCache, 1.50, true);
        bmpScaled.SetPosition(MmgHelper.ScaleValue(213), GetY() + MmgHelper.ScaleValue(330));
        AddObj(bmpScaled);
        
        bmpScaledLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bmpScaledLabel.SetText("MmgBmp Custom Scaled");
        bmpScaledLabel.SetPosition(MmgHelper.ScaleValue(90), GetY() + MmgHelper.ScaleValue(310));
        AddObj(bmpScaledLabel);
        
        bmpRotate = MmgBmpScaler.RotateMmgBmp(bmpCache, 90, true);
        bmpRotate.SetPosition(MmgHelper.ScaleValue(645), GetY() + MmgHelper.ScaleValue(330));
        AddObj(bmpRotate);        
        
        bmpRotateLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        bmpRotateLabel.SetText("MmgBmp Custom Rotated");
        bmpRotateLabel.SetPosition(MmgHelper.ScaleValue(515), GetY() + MmgHelper.ScaleValue(310));
        AddObj(bmpRotateLabel);        
        
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmgBmp.ProcessDebugClick");
    }

   /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmgBmp.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_06);            
            
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_04);
            
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessScreenClick");
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
        MmgHelper.wr("ScreenTestMmgBmp.ProcessKeyClick");
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        
        bmpCache = null;
        bmpCacheLabel = null;
        bmpCustomFill = null;
        bmpCustomFillLabel = null;
        bmpFile = null;
        bmpFileLabel = null;
        bmpPartialCopy = null;
        bmpPartialCopyLabel = null;
        bmpRotate = null;
        bmpRotateLabel = null;
        bmpScaled = null;
        bmpScaledLabel = null;
        bmpSet = null;
        
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
     * The callback method to handle GenericEventMessage objects.
     * 
     * @param obj       A GenericEventMessage object instance to process.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        MmgHelper.wr("ScreenTestMmgBmp.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
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