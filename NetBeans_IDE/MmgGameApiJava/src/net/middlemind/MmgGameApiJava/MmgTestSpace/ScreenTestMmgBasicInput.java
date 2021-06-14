package net.middlemind.MmgGameApiJava.MmgTestSpace;

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
public class ScreenTestMmgBasicInput extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

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
     * An MmgFont class instance for tracking A button press events.
     */
    private MmgFont processABtnPress;    
    
    /**
     * An MmgFont class instance for tracking A button release events.
     */
    private MmgFont processABtnRelease;
    
    /**
     * An MmgFont class instance for tracking A button click events.
     */
    private MmgFont processABtnClick;
        
    /**
     * An MmgFont class instance for tracking A button press events.
     */
    private MmgFont processBBtnPress;    
    
    /**
     * An MmgFont class instance for tracking A button release events.
     */
    private MmgFont processBBtnRelease;    
    
    /**
     * An MmgFont class instance for tracking A button click events.
     */
    private MmgFont processBBtnClick;
    
    /**
     * An MmgFont class instance for tracking "Debug" events.
     */
    private MmgFont processDebugClick;    
    
    /**
     * An MmgFont class instance for tracking Up button press events.
     */
    private MmgFont processUpBtnPress;
    
    /**
     * An MmgFont class instance for tracking Up button release events.
     */
    private MmgFont processUpBtnRelease;    
    
    /**
     * An MmgFont class instance for tracking Up button click events.
     */
    private MmgFont processUpBtnClick;    
    
    /**
     * An MmgFont class instance for tracking Down button press events.
     */
    private MmgFont processDownBtnPress;
    
    /**
     * An MmgFont class instance for tracking Down button release events.
     */
    private MmgFont processDownBtnRelease;    
    
    /**
     * An MmgFont class instance for tracking Down button click events.
     */
    private MmgFont processDownBtnClick;    
    
    /**
     * An MmgFont class instance for tracking Left button press events.
     */
    private MmgFont processLeftBtnPress;
    
    /**
     * An MmgFont class instance for tracking Left button release events.
     */
    private MmgFont processLeftBtnRelease;    
    
    /**
     * An MmgFont class instance for tracking Left button click events.
     */
    private MmgFont processLeftBtnClick;    
    
    /**
     * An MmgFont class instance for tracking Right button press events.
     */
    private MmgFont processRightBtnPress;
    
    /**
     * An MmgFont class instance for tracking Right button release events.
     */
    private MmgFont processRightBtnRelease;    
    
    /**
     * An MmgFont class instance for tracking Right button click events.
     */
    private MmgFont processRightBtnClick;    
    
    /**
     * An MmgFont class instance for tracking keyboard press events.
     */
    private MmgFont processKeyPress;
    
    /**
     * An MmgFont class instance for tracking keyboard release events.
     */
    private MmgFont processKeyRelease;    
    
    /**
     * An MmgFont class instance for tracking keyboard click events.
     */
    private MmgFont processKeyClick;
    
    /**
     * An MmgFont class instance for tracking mouse press events.
     */
    private MmgFont processMousePress;
    
    /**
     * An MmgFont class instance for tracking mouse release events.
     */
    private MmgFont processMouseRelease;    
    
    /**
     * An MmgFont class instance for tracking mouse click events.
     */
    private MmgFont processMouseClick;
    
    /**
     * An MmgFont class instance for tracking mouse move events.
     */
    private MmgFont processMouseMove;    
        
    /**
     * A private temporary MmgFont class instance used internally.
     */
    private MmgFont instr;
    
    /**
     * An MmgFont class instance used as the title for the test game screen.
     */
    private MmgFont title;
    
    /**
     * A private boolean flag used to indicate work has to be done on the next MmgUpdate method call.
     */
    private boolean isDirty = false;
    
    /**
     * A private boolean flag used in the MmgUpdate method to indicate that work has been done this MmgUpdate call.
     */
    private boolean lret = false;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State         The game state of this game screen.
     * @param Owner         The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenTestMmgBasicInput(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmgBasicInput.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmgBasicInput.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmgBasicInput.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Basic Input (9 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);

        int yDiff = MmgHelper.ScaleValue(25);
        int yStrt = GetY() + MmgHelper.ScaleValue(60);
        int xLeft = MmgHelper.ScaleValue(20);
        int i = 0;
                
        processABtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processABtnPress.SetText("ProcessABtnPress (A): ");
        processABtnPress.SetX(xLeft);
        processABtnPress.SetY(yStrt + (yDiff * i));
        AddObj(processABtnPress);
        i++;
        
        processABtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processABtnRelease.SetText("ProcessABtnRelease (A): ");
        processABtnRelease.SetX(xLeft);
        processABtnRelease.SetY(yStrt + (yDiff * i));
        AddObj(processABtnRelease);
        i++;
        
        processABtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processABtnClick.SetText("ProcessABtnClick (A): ");
        processABtnClick.SetX(xLeft);
        processABtnClick.SetY(yStrt + (yDiff * i));
        AddObj(processABtnClick);
        i++;
                
        processBBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processBBtnPress.SetText("ProcessBBtnPress (A): ");
        processBBtnPress.SetX(xLeft);
        processBBtnPress.SetY(yStrt + (yDiff * i));
        AddObj(processBBtnPress);
        i++;
        
        processBBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processBBtnRelease.SetText("ProcessBBtnRelease (A): ");
        processBBtnRelease.SetX(xLeft);
        processBBtnRelease.SetY(yStrt + (yDiff * i));
        AddObj(processBBtnRelease);
        i++;
        
        processBBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processBBtnClick.SetText("ProcessBBtnClick (B): ");
        processBBtnClick.SetX(xLeft);
        processBBtnClick.SetY(yStrt + (yDiff * i));
        AddObj(processBBtnClick);
        i++;
        
        processDebugClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processDebugClick.SetText("ProcessDebugClick (D): ");
        processDebugClick.SetX(xLeft);
        processDebugClick.SetY(yStrt + (yDiff * i));
        AddObj(processDebugClick);
        i++;        
        
        processUpBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processUpBtnPress.SetText("ProcessUpBtnPress: ");
        processUpBtnPress.SetX(xLeft);
        processUpBtnPress.SetY(yStrt + (yDiff * i));
        AddObj(processUpBtnPress);
        i++;
        
        processUpBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processUpBtnRelease.SetText("ProcessUpBtnRelease: ");
        processUpBtnRelease.SetX(xLeft);
        processUpBtnRelease.SetY(yStrt + (yDiff * i));
        AddObj(processUpBtnRelease);
        i++;
        
        processUpBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processUpBtnClick.SetText("ProcessUpBtnClick: ");
        processUpBtnClick.SetX(xLeft);
        processUpBtnClick.SetY(yStrt + (yDiff * i));
        AddObj(processUpBtnClick);
        i++;
        
        processDownBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processDownBtnPress.SetText("ProcessDownBtnPress: ");
        processDownBtnPress.SetX(xLeft);
        processDownBtnPress.SetY(yStrt + (yDiff * i));
        AddObj(processDownBtnPress);
        i++;
        
        processDownBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processDownBtnRelease.SetText("ProcessDownBtnRelease: ");
        processDownBtnRelease.SetX(xLeft);
        processDownBtnRelease.SetY(yStrt + (yDiff * i));
        AddObj(processDownBtnRelease);
        i++;
        
        processDownBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processDownBtnClick.SetText("ProcessDownBtnClick: ");
        processDownBtnClick.SetX(xLeft);
        processDownBtnClick.SetY(yStrt + (yDiff * i));
        AddObj(processDownBtnClick);
        i++;
        
        xLeft = GetWidth()/2 + MmgHelper.ScaleValue(50);
        i = 0;        
        processLeftBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processLeftBtnPress.SetText("ProcessLeftBtnPress: ");
        processLeftBtnPress.SetX(xLeft);
        processLeftBtnPress.SetY(yStrt + (yDiff * i));
        AddObj(processLeftBtnPress);
        i++;
        
        processLeftBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processLeftBtnRelease.SetText("ProcessLeftBtnRelease: ");
        processLeftBtnRelease.SetX(xLeft);
        processLeftBtnRelease.SetY(yStrt + (yDiff * i));
        AddObj(processLeftBtnRelease);
        i++;
        
        processLeftBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processLeftBtnClick.SetText("ProcessLeftBtnClick: ");
        processLeftBtnClick.SetX(xLeft);
        processLeftBtnClick.SetY(yStrt + (yDiff * i));
        AddObj(processLeftBtnClick);
        i++;
        
        processRightBtnPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processRightBtnPress.SetText("ProcessRightBtnPress: ");
        processRightBtnPress.SetX(xLeft);
        processRightBtnPress.SetY(yStrt + (yDiff * i));
        AddObj(processRightBtnPress);
        i++;
        
        processRightBtnRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processRightBtnRelease.SetText("ProcessRightBtnRelease: ");
        processRightBtnRelease.SetX(xLeft);
        processRightBtnRelease.SetY(yStrt + (yDiff * i));
        AddObj(processRightBtnRelease);
        i++;
        
        processRightBtnClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processRightBtnClick.SetText("ProcessRightBtnClick: ");
        processRightBtnClick.SetX(xLeft);
        processRightBtnClick.SetY(yStrt + (yDiff * i));
        AddObj(processRightBtnClick);
        i++;
                
        processKeyPress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processKeyPress.SetText("ProcessKeyPress: ");
        processKeyPress.SetX(xLeft);
        processKeyPress.SetY(yStrt + (yDiff * i));
        AddObj(processKeyPress);
        i++;
        
        processKeyRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processKeyRelease.SetText("ProcessKeyRelease: ");
        processKeyRelease.SetX(xLeft);
        processKeyRelease.SetY(yStrt + (yDiff * i));
        AddObj(processKeyRelease);
        i++;
        
        processKeyClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processKeyClick.SetText("ProcessKeyClick: ");
        processKeyClick.SetX(xLeft);
        processKeyClick.SetY(yStrt + (yDiff * i));
        AddObj(processKeyClick);
        i++;
        
        processMousePress = MmgFontData.CreateDefaultBoldMmgFontSm();
        processMousePress.SetText("ProcessMousePress: ");
        processMousePress.SetX(xLeft);
        processMousePress.SetY(yStrt + (yDiff * i));
        AddObj(processMousePress);
        i++;
        
        processMouseRelease = MmgFontData.CreateDefaultBoldMmgFontSm();
        processMouseRelease.SetText("ProcessMouseRelease: ");
        processMouseRelease.SetX(xLeft);
        processMouseRelease.SetY(yStrt + (yDiff * i));
        AddObj(processMouseRelease);
        i++;
        
        processMouseClick = MmgFontData.CreateDefaultBoldMmgFontSm();
        processMouseClick.SetText("ProcessMouseClick: ");
        processMouseClick.SetX(xLeft);
        processMouseClick.SetY(yStrt + (yDiff * i));
        AddObj(processMouseClick);
        i++; 
        
        processMouseMove = MmgFontData.CreateDefaultBoldMmgFontSm();
        processMouseMove.SetText("ProcessMouseMove: ");
        processMouseMove.SetX(xLeft);
        processMouseMove.SetY(yStrt + (yDiff * i));
        AddObj(processMouseMove);
        i++;         
        
        instr = MmgFontData.CreateDefaultMmgFontSm();
        instr.SetText("Press 'L' to navigate left, press 'R' to navigate right.");
        MmgHelper.CenterHor(instr);
        instr.SetY(GetY() + GetHeight() - MmgHelper.ScaleValue(25));
        AddObj(instr);
        
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenPress");
        processMousePress.SetText("ProcessMousePress: X: " + x + " Y: " + y);
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessScreenRelease");
        processMouseRelease.SetText("ProcessMouseRelease: X: " + x + " Y: " + y);        
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessMouseClick");        
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessMouseClick");
        processMouseClick.SetText("ProcessMouseClick: X: " + x + " Y: " + y);
        return true;
    }    
    
    /**
     * Expects a relative X, Y coordinate that takes into account the game's offset and the current panel's offset.
     * 
     * @param x     The X coordinate of the mouse.
     * @param y     The Y coordinate of the mouse.
     * @return      A boolean indicating if the event was handled or not.
     */
    @Override
    public boolean ProcessMouseMove(int x, int y) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessMouseMove");
        processMouseMove.SetText("ProcessMouseMove: X: " + x + " Y: " + y);
        return true;
    }         
    
    /**
     * A method to handle A press events.
     * 
     * @param src       The source gamepad, keyboard of the A event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessAPress(int src) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessAPress");
        processABtnPress.SetText("ProcessABtnPress (A): " + System.currentTimeMillis());
        return true;
    }
    
    /**
     * A method to handle A release events.
     * 
     * @param src       The source gamepad, keyboard of the A event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessARelease(int src) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessARelease");
        processABtnRelease.SetText("ProcessABtnRelease (A): " + System.currentTimeMillis());
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessAClick");
        processABtnClick.SetText("ProcessABtnClick (A): " + System.currentTimeMillis());
        return true;
    }
    
    /**
     * A method to handle B press events.
     * 
     * @param src       The source gamepad, keyboard of the B event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessBPress(int src) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessBPress");
        processBBtnPress.SetText("ProcessBBtnPress (A): " + System.currentTimeMillis());
        return true;
    }
    
    /**
     * A method to handle B release events.
     * 
     * @param src       The source gamepad, keyboard of the B event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessBRelease(int src) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessBRelease");
        processBBtnRelease.SetText("ProcessBBtnRelease (A): " + System.currentTimeMillis());
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessBClick");
        processBBtnClick.SetText("ProcessBBtnClick (B): " + System.currentTimeMillis());       
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDebugClick");
        processDebugClick.SetText("ProcessDebugClick (D): " + System.currentTimeMillis()); 
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDpadPress: " + dir);
        if(dir == GameSettings.UP_KEYBOARD) {
            processUpBtnPress.SetText("ProcessUpBtnPress: " + System.currentTimeMillis());
        
        } else if(dir == GameSettings.DOWN_KEYBOARD) {
            processDownBtnPress.SetText("ProcessDownBtnPress: " + System.currentTimeMillis());            
            
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            processLeftBtnPress.SetText("ProcessLeftBtnPress: " + System.currentTimeMillis());

        } else if(dir == GameSettings.RIGHT_KEYBOARD) {
            processRightBtnPress.SetText("ProcessRightBtnPress: " + System.currentTimeMillis());            
            
        }
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.UP_KEYBOARD) {
            processUpBtnRelease.SetText("ProcessUpBtnRelease: " + System.currentTimeMillis());
        
        } else if(dir == GameSettings.DOWN_KEYBOARD) {
            processDownBtnRelease.SetText("ProcessDownBtnRelease: " + System.currentTimeMillis());            
            
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            processLeftBtnRelease.SetText("ProcessLeftBtnRelease: " + System.currentTimeMillis());

        } else if(dir == GameSettings.RIGHT_KEYBOARD) {
            processRightBtnRelease.SetText("ProcessRightBtnRelease: " + System.currentTimeMillis());            
            
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessDpadClick: " + dir);
        if(dir == GameSettings.UP_KEYBOARD) {
            processUpBtnClick.SetText("ProcessUpBtnClick: " + System.currentTimeMillis());
        
        } else if(dir == GameSettings.DOWN_KEYBOARD) {
            processDownBtnClick.SetText("ProcessDownBtnClick: " + System.currentTimeMillis());            
            
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            processLeftBtnClick.SetText("ProcessLeftBtnClick: " + System.currentTimeMillis());

        } else if(dir == GameSettings.RIGHT_KEYBOARD) {
            processRightBtnClick.SetText("ProcessRightBtnClick: " + System.currentTimeMillis());            
            
        }        
        return true;
    }
        
    /**
     * A method to handle keyboard press events.
     * 
     * @param c         The key used in the event.
     * @param code      The code of the key used in the event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessKeyPress(char c, int code) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessKeyPress: " + code);
        processKeyPress.SetText(("ProcessKeyPress: " + System.currentTimeMillis()));
        return true;
    }

    /**
     * A method to handle keyboard release events.
     * 
     * @param c         The key used in the event.
     * @param code      The code of the key used in the event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessKeyRelease(char c, int code) {
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessKeyRelease: " + code);
        processKeyRelease.SetText(("ProcessKeyRelease: " + System.currentTimeMillis()));
        if(c == 'l' || c == 'L') {
            owner.SwitchGameState(GameStates.GAME_SCREEN_08);
        } else if(c == 'r' || c == 'R') {
            owner.SwitchGameState(GameStates.GAME_SCREEN_10);            
        }
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
        MmgHelper.wr("ScreenTestMmgBasicInput.ProcessKeyClick: " + code);
        processKeyClick.SetText(("ProcessKeyClick: " + System.currentTimeMillis()));
        return true;
    }
            
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        
        title = null;        
        processABtnClick = null;
        processBBtnClick = null;
        processDownBtnClick = null;
        processDownBtnPress = null;
        processDownBtnRelease = null;
        processKeyClick = null;
        processKeyPress = null;
        processKeyRelease = null;
        processLeftBtnClick = null;
        processLeftBtnPress = null;
        processLeftBtnRelease = null;
        processRightBtnClick = null;
        processRightBtnPress = null;
        processRightBtnRelease = null;
        processUpBtnClick = null;
        processUpBtnPress = null;
        processUpBtnRelease = null;
        
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
        MmgHelper.wr("ScreenTestMmgBasicInput.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMmgBasicInput.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
    }
}