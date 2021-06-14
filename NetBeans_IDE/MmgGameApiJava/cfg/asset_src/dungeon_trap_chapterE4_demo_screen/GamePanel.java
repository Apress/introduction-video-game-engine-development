package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgCore.DatExternalStrings;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgCore.MainFrame;
import net.middlemind.MmgGameApiJava.MmgCore.ScreenLoading;
import net.middlemind.MmgGameApiJava.MmgCore.ScreenSplash;

/**
 * A class used to render different MmgGameScreen class instances in the MainFrame, JFrame, class instance.
 * The class is designed to have different states each represented by an MmgGameScreen instance that then
 * becomes the currentScreen, and renders to the MainFrame.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 02/19/2020
 */
public class GamePanel extends net.middlemind.MmgGameApiJava.MmgCore.GamePanel {
    
    /**
     * The Screen responsible for drawing the game.
     */
    public ScreenGame screenGame;
    
    /**
     * The Screen responsible for drawing the main menu.
     */
    public ScreenMainMenu screenMainMenu;
    
    /**
     * The default constructor for the GamePanel class.
     * 
     * @param Mf            The MainFrame class instance that this GamePanel will render to.
     * @param WinWidth      The total window width.
     * @param WinHeight     The total window height.
     * @param X             The X coordinate of the GamePanel.
     * @param Y             The Y coordinate of the GamePanel.
     * @param GameWidth     The total width of the game.
     * @param GameHeight    The total height of the game.
     */
    public GamePanel(MainFrame Mf, int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight) {
        super(Mf, WinWidth, WinHeight, X, Y, GameWidth, GameHeight);
        screenSplash.SetGenericEventHandler(this);
        screenLoading.SetGenericEventHandler(this);
        screenLoading.SetSlowDown(0);
        screenGame = new ScreenGame(GameStates.MAIN_GAME, this);
        screenMainMenu = new ScreenMainMenu(GameStates.MAIN_MENU, this);
    }
        
    /**
     * A method that handles cleaning up the current game state and switching to the given game state.
     * The method will then set the currentScreen class field to the new game Screen.
     * 
     * @param g     The target GameState to switch to.
     */
    @Override
    public void SwitchGameState(GameStates g) {
        if (gameState != prevGameState) {
            prevGameState = gameState;
        }

        if (g != gameState) {
            gameState = g;
        } else {
            return;
        }

        //unload
        if (prevGameState == GameStates.BLANK) {
            MmgHelper.wr("Hiding BLANK screen.");

        } else if (prevGameState == GameStates.SPLASH) {
            MmgHelper.wr("Hiding SPLASH screen.");
            screenSplash.Pause();
            screenSplash.SetIsVisible(false);
            screenSplash.UnloadResources();
            
        } else if (prevGameState == GameStates.LOADING) {
            MmgHelper.wr("Hiding LOADING screen.");
            screenLoading.Pause();
            screenLoading.SetIsVisible(false);
            screenLoading.UnloadResources();
            MmgHelper.wr("Hiding LOADING screen DONE.");

        } else if (prevGameState == GameStates.GAME_SCREEN_01) {
            MmgHelper.wr("Hiding GAME_SCREEN_01 screen.");
            //screenTest.Pause();
            //screenTest.SetIsVisible(false);
            //screenTest.UnloadResources();
                        
        } else if (prevGameState == GameStates.MAIN_MENU) {
            MmgHelper.wr("Hiding MAIN_MENU screen.");
            screenMainMenu.Pause();
            screenMainMenu.SetIsVisible(false);
            screenMainMenu.UnloadResources();

        } else if (prevGameState == GameStates.ABOUT) {
            MmgHelper.wr("Hiding ABOUT screen.");
            //aboutScreen.Pause();
            //aboutScreen.SetIsVisible(false);
            //aboutScreen.UnloadResources();

        } else if (prevGameState == GameStates.HELP_MENU) {
            MmgHelper.wr("Hiding HELP screen.");
            //helpScreen.Pause();
            //helpScreen.SetIsVisible(false);
            //helpScreen.UnloadResources();

        } else if (prevGameState == GameStates.MAIN_GAME_1P || gameState == GameStates.MAIN_GAME) {
            MmgHelper.wr("Hiding MAIN GAME 1P screen.");
            screenGame.Pause();
            screenGame.SetIsVisible(false);
            screenGame.UnloadResources();

        } else if (prevGameState == GameStates.MAIN_GAME_2P) {
            MmgHelper.wr("Hiding MAIN GAME 2P screen.");
            screenGame.Pause();
            screenGame.SetIsVisible(false);
            screenGame.UnloadResources();            
            
        } else if (prevGameState == GameStates.SETTINGS) {
            MmgHelper.wr("Hiding SETTINGS screen.");
            //settingsScreen.Pause();
            //settingsScreen.SetIsVisible(false);
            //settingsScreen.UnloadResources();

        }

        //load
        MmgHelper.wr("Switching Game State To: " + gameState);
        if (gameState == GameStates.BLANK) {
            MmgHelper.wr("Showing BLANK screen.");

        } else if (gameState == GameStates.SPLASH) {
            MmgHelper.wr("Showing SPLASH screen.");
            screenSplash.LoadResources();
            screenSplash.UnPause();
            screenSplash.SetIsVisible(true);
            screenSplash.StartDisplay();
            currentScreen = screenSplash;
                        
        } else if (gameState == GameStates.LOADING) {
            MmgHelper.wr("Showing LOADING screen.");
            screenLoading.LoadResources();
            screenLoading.UnPause();
            screenLoading.SetIsVisible(true);
            screenLoading.StartDatLoad();
            currentScreen = screenLoading;

        } else if (gameState == GameStates.GAME_SCREEN_01) {
            MmgHelper.wr("Showing GAME_SCREEN_01 screen.");
            //screenTest.LoadResources();
            //screenTest.UnPause();
            //screenTest.SetIsVisible(true);
            //currentScreen = screenTest;
                        
        } else if (gameState == GameStates.MAIN_MENU) {
            MmgHelper.wr("Showing MAIN_MENU screen.");
            screenMainMenu.LoadResources();
            screenMainMenu.UnPause();
            screenMainMenu.SetIsVisible(true);
            currentScreen = screenMainMenu;

        } else if (gameState == GameStates.ABOUT) {
            MmgHelper.wr("Showing ABOUT screen.");
            //aboutScreen.LoadResources();
            //aboutScreen.UnPause();
            //aboutScreen.SetIsVisible(true);
            //currentScreen = aboutScreen;

        } else if (gameState == GameStates.HELP_MENU) {
            MmgHelper.wr("Showing HELP screen.");
            //helpScreen.LoadResources();
            //helpScreen.UnPause();
            //helpScreen.SetIsVisible(true);
            //currentScreen = helpScreen;

        } else if (gameState == GameStates.MAIN_GAME_1P || gameState == GameStates.MAIN_GAME) {
            MmgHelper.wr("Showing MAIN GAME 1P screen.");
            screenGame.SetGameType(GameType.GAME_ONE_PLAYER);
            screenGame.LoadResources();
            screenGame.UnPause();
            screenGame.SetIsVisible(true);
            currentScreen = screenGame;

        } else if (gameState == GameStates.MAIN_GAME_2P) {
            MmgHelper.wr("Showing MAIN GAME 2P screen.");
            screenGame.SetGameType(GameType.GAME_TWO_PLAYER);
            screenGame.LoadResources();
            screenGame.UnPause();
            screenGame.SetIsVisible(true);
            currentScreen = screenGame;            
            
        } else if (gameState == GameStates.SETTINGS) {
            //settingsScreen.LoadResources();
            //settingsScreen.UnPause();
            //settingsScreen.SetIsVisible(true);
            //currentScreen = settingsScreen;

        }
    }    
    
    /**
     * A method to handle generic events sent to the GamePanel class instance.
     * 
     * @param obj       A GenericEventMessage with information about what event occurred.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        if (obj != null) {
            if (obj.GetGameState() == GameStates.LOADING) {
                if (obj.GetId() == ScreenLoading.EVENT_LOAD_COMPLETE) {
                    //Final loading steps
                    DatExternalStrings.LOAD_EXT_STRINGS();                    
                    SwitchGameState(GameStates.MAIN_MENU);
                }
                
            } else if (obj.GetGameState() == GameStates.SPLASH) {
                if (obj.GetId() == ScreenSplash.EVENT_DISPLAY_COMPLETE) {
                    SwitchGameState(GameStates.LOADING);
                }
                
            }
        }
    }    
}