package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgTextField;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;
import net.middlemind.MmgGameApiJava.MmgCore.GameSettings;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventHandler;

/**
 * A game screen object, ScreenTest, that extends the MmgGameScreen base class.
 * This class is for testing new UI widgets, etc.
 * Created by Middlemind Games 02/25/2020
 * 
 * @author Victor G. Brusca
 */
public class ScreenTestMmgTextField extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

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
     * An MmgBmp class instance used as the background for the MmgTextField test object.
     */
    private MmgBmp bground;
        
    /**
     * An MmgTextField class instance used as the example object in this test game screen.
     */
    private MmgTextField txtField;
    
    /**
     * An MmgFont class instance used as a label for the text field.
     */
    private MmgFont txtFieldLabel;
    
    /**
     * An MmgFont class instance used as a label for the maximum length of the text field.
     */
    private MmgFont maxLenLabel;
    
    /**
     * An MmgFont class instance that displays the text held by the MmgTextField.
     */
    private MmgFont txtFieldText;
    
    /**
     * An MmgFont class instance that displays error information when a maximum length error occurs in the MmgTextField test object.
     */
    private MmgFont txtFieldMaxLenError;
    
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
    public ScreenTestMmgTextField(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMsgTextField.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMsgTextField.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMsgTextField.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());

        int width = MmgHelper.ScaleValue(256);
        int height = MmgHelper.ScaleValue(64);
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Text Field (4 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);        
        
        bground = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
        
        txtField = new MmgTextField(bground, MmgFontData.CreateDefaultMmgFontLg(), width, height, 12, 15);
        MmgHelper.CenterHorAndVert(txtField);
        txtField.SetMaxLengthOn(true);
        txtField.SetEventHandler(this);
        txtField.SetY(txtField.GetY() - MmgHelper.ScaleValue(30));
        AddObj(txtField);
        
        txtFieldLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtFieldLabel.SetText("MmgTextField Example");
        MmgHelper.CenterHorAndVert(txtFieldLabel);
        txtFieldLabel.SetY(txtFieldLabel.GetY() - MmgHelper.ScaleValue(55));
        AddObj(txtFieldLabel);
        
        txtFieldText = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtFieldText.SetText("Text Field Text: ");
        MmgHelper.CenterHorAndVert(txtFieldText);
        txtFieldText.SetY(txtFieldText.GetY() + MmgHelper.ScaleValue(40));
        AddObj(txtFieldText);
        
        maxLenLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
        maxLenLabel.SetText("Max Len Error On: " + txtField.GetMaxLengthOn() + " Max Len: " + MmgTextField.DEFAULT_MAX_LENGTH);
        MmgHelper.CenterHorAndVert(maxLenLabel);
        maxLenLabel.SetY(maxLenLabel.GetY() + MmgHelper.ScaleValue(70));
        AddObj(maxLenLabel);
        
        txtFieldMaxLenError = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtFieldMaxLenError.SetText("Max Len Error Current Time MS: ");
        MmgHelper.CenterHorAndVert(txtFieldMaxLenError);
        txtFieldMaxLenError.SetY(txtFieldMaxLenError.GetY() + MmgHelper.ScaleValue(100));
        AddObj(txtFieldMaxLenError);
        
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMsgTextField.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMsgTextField.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_05);
        
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_03);
            
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenClick");
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
        txtFieldText.SetText("Text Field Text: " + txtField.GetTextFieldString());
        MmgHelper.CenterHor(txtFieldText);
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        
        bground = null;
        txtField = null;
        title = null;
        txtFieldLabel = null;
        txtFieldMaxLenError = null;
        txtFieldText = null;
        
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
        MmgHelper.wr("ScreenTestMsgTextField.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMsgTextField.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());   
        if(e.GetMessage() != null && e.GetMessage().equals("error_max_length") == true) {
            txtFieldMaxLenError.SetText("Max Len Error Current Time MS: " + System.currentTimeMillis());
            MmgHelper.CenterHor(txtFieldMaxLenError);
        }
    }
}