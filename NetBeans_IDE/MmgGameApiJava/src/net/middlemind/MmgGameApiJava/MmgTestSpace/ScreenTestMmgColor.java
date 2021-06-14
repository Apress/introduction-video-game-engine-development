package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
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
public class ScreenTestMmgColor extends MmgGameScreen implements GenericEventHandler, MmgEventHandler {

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
     * An MmgFont instance used as a label for the first color entry.
     */
    private MmgFont color1Label;
    
    /**
     * An MmgFont instance used as a label for the second color entry.
     */
    private MmgFont color2Label;
       
    /**
     * An MmgFont instance used as a label for the third color entry.
     */
    private MmgFont color3Label;
    
    /**
     * An MmgFont instance used as a label for the fourth color entry.
     */
    private MmgFont color4Label;
    
    /**
     * An MmgFont instance used as a label for the fifth color entry.
     */
    private MmgFont color5Label;
    
    /**
     * An MmgFont instance used as a label for the sixth color entry.
     */
    private MmgFont color6Label;    

    /**
     * An MmgFont instance used as a label for the seventh color entry.
     */
    private MmgFont color7Label;
    
    /**
     * An MmgFont instance used as a label for the eighth color entry.
     */
    private MmgFont color8Label;

    /**
     * An MmgFont instance used as a label for the ninth color entry.
     */
    private MmgFont color9Label;
    
    /**
     * An MmgFont instance used as a label for the tenth color entry.
     */
    private MmgFont color10Label;
    
    /**
     * An MmgFont class instance used as the title of the test game screen.
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
    public ScreenTestMmgColor(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        gameState = State;
        owner = Owner;
        MmgHelper.wr("ScreenTestMmgColor.Constructor");
    }

    /**
     * Sets a generic event handler that will receive generic events from this
     * object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenTestMmgColor.SetGenericEventHandler");
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
        MmgHelper.wr("ScreenTestMmgColor.LoadResources");
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
        
        title = MmgFontData.CreateDefaultBoldMmgFontLg();
        title.SetText("<  Screen Test Mmg Color (11 / " + GamePanel.TOTAL_TESTS + ")  >");
        MmgHelper.CenterHorAndTop(title);
        title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
        AddObj(title);
                
        int yDiff = MmgHelper.ScaleValue(40);
        int yStrt = GetY() + MmgHelper.ScaleValue(140);
        int xLeft = MmgHelper.ScaleValue(200);
        int i = 0;
        
        color1Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color1Label.SetMmgColor(MmgColor.GetBlueGray());
        color1Label.SetText("Color: BlueGray");
        color1Label.SetX(xLeft);
        color1Label.SetY(yStrt + (yDiff * i));
        AddObj(color1Label);
        i++;
        
        color2Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color2Label.SetMmgColor(MmgColor.GetCarbonGray());
        color2Label.SetText("Color: CarbonGray");
        color2Label.SetX(xLeft);
        color2Label.SetY(yStrt + (yDiff * i));
        AddObj(color2Label);
        i++;
        
        color3Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color3Label.SetMmgColor(MmgColor.GetDarkRed());
        color3Label.SetText("Color: DarkRed");
        color3Label.SetX(xLeft);
        color3Label.SetY(yStrt + (yDiff * i));
        AddObj(color3Label);
        i++;
                
        color4Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color4Label.SetMmgColor(MmgColor.GetIridium());
        color4Label.SetText("Color: Iridium");
        color4Label.SetX(xLeft);
        color4Label.SetY(yStrt + (yDiff * i));
        AddObj(color4Label);
        i++;
        
        color5Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color5Label.SetMmgColor(MmgColor.GetLimeGreen());
        color5Label.SetText("Color: LimeGreen");
        color5Label.SetX(xLeft);
        color5Label.SetY(yStrt + (yDiff * i));
        AddObj(color5Label);
        i++;        
                
        xLeft = GetWidth()/2 + MmgHelper.ScaleValue(70);
        i = 0;
        
        color6Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color6Label.SetMmgColor(MmgColor.GetMaroon());
        color6Label.SetText("Color: Maroon");
        color6Label.SetX(xLeft);
        color6Label.SetY(yStrt + (yDiff * i));
        AddObj(color6Label);
        i++;
        
        color7Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color7Label.SetMmgColor(MmgColor.GetOil());
        color7Label.SetText("Color: Oil");
        color7Label.SetX(xLeft);
        color7Label.SetY(yStrt + (yDiff * i));
        AddObj(color7Label);
        i++;
        
        color8Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color8Label.SetMmgColor(MmgColor.GetOlive());
        color8Label.SetText("Color: Olive");
        color8Label.SetX(xLeft);
        color8Label.SetY(yStrt + (yDiff * i));
        AddObj(color8Label);
        i++;
        
        color9Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color9Label.SetMmgColor(MmgColor.GetOrange());
        color9Label.SetText("Color: Orange");
        color9Label.SetX(xLeft);
        color9Label.SetY(yStrt + (yDiff * i));
        AddObj(color9Label);
        i++;
        
        color10Label = MmgFontData.CreateDefaultBoldMmgFontLg();
        color10Label.SetMmgColor(MmgColor.GetPlatinum());
        color10Label.SetText("Color: Platinum");
        color10Label.SetX(xLeft);
        color10Label.SetY(yStrt + (yDiff * i));
        AddObj(color10Label);
        i++;
        
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessScreenPress");
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessScreenRelease");
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessAClick");
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessBClick");        
        return true;
    }
    
    /**
     * A method to handle special debug events that can be customized for each game.
     */
    @Override
    public void ProcessDebugClick() {
        MmgHelper.wr("ScreenTestMmgColor.ProcessDebugClick");
    }

    /**
     * A method to handle dpad press events.
     * 
     * @param dir       The direction id for the dpad event.
     * @return          A boolean indicating if this event was handled or not.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        MmgHelper.wr("ScreenTestMmgColor.ProcessDpadPress: " + dir);
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessDpadRelease: " + dir);
        if(dir == GameSettings.RIGHT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_12);
        
        } else if(dir == GameSettings.LEFT_KEYBOARD) {
            owner.SwitchGameState(GameStates.GAME_SCREEN_10);
            
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessDpadClick: " + dir);        
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessScreenClick");        
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessScreenClick");
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
        MmgHelper.wr("ScreenTestMmgColor.ProcessKeyClick");
        return true;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
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
        MmgHelper.wr("ScreenTestMmgColor.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
    }

    /**
     * The callback method to handle MmgEvent objects.
     * 
     * @param e         An MmgEvent object instance to process.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        MmgHelper.wr("ScreenTestMmgColor.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
    }
}