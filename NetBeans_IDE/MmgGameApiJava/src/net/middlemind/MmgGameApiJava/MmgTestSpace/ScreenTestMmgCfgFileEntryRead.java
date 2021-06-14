package net.middlemind.MmgGameApiJava.MmgTestSpace;

import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry;
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
public class ScreenTestMmgCfgFileEntryRead extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

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
     * An MmgFont class instance that is used to label the String value pulled from the class configuration file.
     */
    private MmgFont cfgFileStringLabel;
    
    /**
     * An MmgFont class instance that is used to label the float value pulled from the class configuration file.
     */
    private MmgFont cfgFileFloatLabel;
        
    /**
     * An MmgFont class instance that is used to label the int value pulled from the class configuration file.
     */
    private MmgFont cfgFileIntLabel;    
    
    /**
     * An MmgFont class instance that is used to label the class configuration entries with information about the file used to load the values.
     */
    private MmgFont infoLabel;
    
    /**
     * An MmgFont class instance used as the title of the test game screen.
     */
    private MmgFont title;
    
    /**
     * A data structure that stores all the class configuration file entries from the target file.
     */
    public Hashtable<String, MmgCfgFileEntry> classConfig;    
    
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
    public ScreenTestMmgCfgFileEntryRead(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
        
        classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_test_mmg_cfg_file_entry.txt");        
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Cfg File Entry Read (10 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);
            
        String val = "";
        float fval = 0.0f;
        int ival = 0;
        
        cfgFileStringLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        if(classConfig.containsKey("example_string")) {
            val = classConfig.get("example_string").str;
        } else {
            val = "Unknown Example String";
        }
        cfgFileStringLabel.SetText("Config File Entry String Value: " + val);
        MmgHelper.CenterHorAndVert(cfgFileStringLabel);
        cfgFileStringLabel.SetY(cfgFileStringLabel.GetY() - MmgHelper.ScaleValue(60));
        AddObj(cfgFileStringLabel);
        
        cfgFileFloatLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        if(classConfig.containsKey("example_float")) {
            fval = classConfig.get("example_float").number.floatValue();
            val = (fval + "");
        } else {
            val = "Unknown Example Float";
        }
        cfgFileFloatLabel.SetText("Config File Entry Float Value: " + val);
        MmgHelper.CenterHorAndVert(cfgFileFloatLabel);
        cfgFileFloatLabel.SetY(cfgFileStringLabel.GetY() + MmgHelper.ScaleValue(40));
        AddObj(cfgFileFloatLabel);
        
        cfgFileIntLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        if(classConfig.containsKey("example_int")) {
            ival = classConfig.get("example_int").number.intValue();
            val = (ival + "");
        } else {
            val = "Unknown Example Integer";
        }
        cfgFileIntLabel.SetText("Config File Entry Int Value: " + val);
        MmgHelper.CenterHorAndVert(cfgFileIntLabel);
        cfgFileIntLabel.SetY(cfgFileFloatLabel.GetY() + MmgHelper.ScaleValue(40));
        AddObj(cfgFileIntLabel);
        
        infoLabel = MmgFontData.CreateDefaultBoldMmgFontLg(); 
        infoLabel.SetText("Class config loaded from: screen_test_mmg_cfg_file_entry.txt");
        MmgHelper.CenterHorAndVert(infoLabel);
        infoLabel.SetY(cfgFileIntLabel.GetY() + MmgHelper.ScaleValue(40));
        AddObj(infoLabel);        
        
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_11);
        
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_09);
            
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenClick");
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessKeyClick");
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        title = null;
        
        cfgFileFloatLabel = null;
        cfgFileIntLabel = null;
        cfgFileStringLabel = null;
        classConfig = null;
        infoLabel = null;
                
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
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

   /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
    }
}