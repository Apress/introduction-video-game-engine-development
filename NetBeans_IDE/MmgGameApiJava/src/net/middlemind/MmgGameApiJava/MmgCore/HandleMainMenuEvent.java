package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgBase.MmgEvent;
import net.middlemind.MmgGameApiJava.MmgBase.MmgEventHandler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;

/**
 * Handles events that originate from the main menu screen. 
 * Implements the MmgEventHandler. 
 * Created by Middlemind Games 08/01/2015
 *
 * @author Victor G. Brusca
 */
public class HandleMainMenuEvent implements MmgEventHandler {

    /**
     * The main menu screen object, ScreenMainMenu, this event handler belongs to.
     */
    private MmgGameScreen cApp;

    /**
     * The game panel object, GamePanel, that owns the main menu screen object, ScreenMainMenu.
     */
    private GamePanel owner;

    /**
     * Supported event type.
     */
    public static int MAIN_MENU_EVENT_TYPE = 0;

    /**
     * Supported event id for a game start event.
     */
    public static int MAIN_MENU_EVENT_START_GAME = 0;
    
    /**
     * Supported event id for a game settings event.
     */
    public static int MAIN_MENU_EVENT_SETTINGS = 1;

    /**
     * Supported event id for a about event.
     */
    public static int MAIN_MENU_EVENT_ABOUT = 2;

    /**
     * Supported event id for a help event.
     */
    public static int MAIN_MENU_EVENT_HELP = 3;

    /**
     * Supported event id for an exit game event.
     */
    public static int MAIN_MENU_EVENT_EXIT_GAME = 4;    
    
    /**
     * Supported event id for a start one player game event.
     */
    public static int MAIN_MENU_EVENT_START_GAME_1P = 5;
    
    /**
     * Supported event id for a start two player game event.
     */
    public static int MAIN_MENU_EVENT_START_GAME_2P = 6;    
    
    /**
     * Constructor that sets the main menu screen object, ScreenMainMenu, owner and the
     * GamePanel that owns the about screen.
     *
     * @param CApp      The main menu screen object, ScreenMainMenu, that this event handler belongs to.
     * @param Owner     The game panel, GamePanel, that the main menu screen belongs to.
     */
    public HandleMainMenuEvent(MmgGameScreen CApp, GamePanel Owner) {
        cApp = CApp;
        owner = Owner;
    }

    /**
     * Event handler call back, when a UI action event occurs on the owner this
     * event handler can react to that event and either call methods in the
     * screen object that this class belongs to or it can call methods in the
     * GamePanel that owns the screen, in other words switch the current game state.
     *
     * @param e     An MmgEvent object.
     */
    @Override
    public void MmgHandleEvent(MmgEvent e) {
        if (owner != null) {
            if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME) {
                owner.SwitchGameState(GamePanel.GameStates.MAIN_GAME);

            } else if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_1P) {
                owner.SwitchGameState(GamePanel.GameStates.MAIN_GAME_1P);
                
            } else if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_2P) {
                owner.SwitchGameState(GamePanel.GameStates.MAIN_GAME_2P);
                                                
            } else if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_EXIT_GAME) {
                System.exit(0);
                
            }
        }
    }
}