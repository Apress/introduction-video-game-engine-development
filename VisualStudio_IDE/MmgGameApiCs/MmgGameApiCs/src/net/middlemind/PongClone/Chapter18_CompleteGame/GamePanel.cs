using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;

namespace net.middlemind.PongClone.Chapter18_CompleteGame
{
    /// <summary>
    /// An application specific extension of the MmgCore API's GamePanel class.
    /// Created by Middlemind Games 02/19/2020
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    public class GamePanel : net.middlemind.MmgGameApiCs.MmgCore.GamePanel
    {

        /// <summary>
        /// The Screen responsible for drawing the game. 
        /// </summary>
        public ScreenGame screenGame;

        /// <summary>
        /// The Screen responsible for drawing the main menu.
        /// </summary>
        public new ScreenMainMenu screenMainMenu;

        /// <summary>
        /// The basic constructor for this GamePanel extended class.
        /// 
        /// <param name="Mf">The MainFrame that is associated with this GamePanel.</param>
        /// <param name="WinWidth">The width to use for this GamePanel.</param>
        /// <param name="WinHeight">The height to use for this GamePanel.</param>
        /// <param name="X">The X position of this GamePanel.</param>
        /// <param name="Y">The Y position of this GamePanel.</param>
        /// <param name="GameWidth">The width of the game drawn on this GamePanel.</param>
        /// <param name="GameHeight">The height of the game drawn on this GamePanel.</param>
        /// </summary>
        public GamePanel(int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight) : base(WinWidth, WinHeight, X, Y, GameWidth, GameHeight)
        {
            screenSplash.SetGenericEventHandler(this);
            screenLoading.SetGenericEventHandler(this);
            screenGame = new ScreenGame(GameStates.MAIN_GAME, this);
            screenMainMenu = new ScreenMainMenu(GameStates.MAIN_MENU, this);
        }

        /// <summary>
        /// Changes the currently visible game screen and cleans up the previously visible game screen.
        /// 
        /// <param name="g">The game state associated with the currently visible game screen.</param>
        /// </summary>
        public override void SwitchGameState(GameStates g)
        {
            if (gameState != prevGameState)
            {
                prevGameState = gameState;
            }

            if (g != gameState)
            {
                gameState = g;
            }
            else
            {
                return;
            }

            //unload
            if (prevGameState == GameStates.BLANK)
            {
                MmgHelper.wr("Hiding BLANK screen.");

            }
            else if (prevGameState == GameStates.SPLASH)
            {
                MmgHelper.wr("Hiding SPLASH screen.");
                screenSplash.Pause();
                screenSplash.SetIsVisible(false);
                screenSplash.UnloadResources();

            }
            else if (prevGameState == GameStates.LOADING)
            {
                MmgHelper.wr("Hiding LOADING screen.");
                screenLoading.Pause();
                screenLoading.SetIsVisible(false);
                screenLoading.UnloadResources();
                MmgHelper.wr("Hiding LOADING screen DONE.");

            }
            else if (prevGameState == GameStates.MAIN_MENU)
            {
                MmgHelper.wr("Hiding MAIN_MENU screen.");
                screenMainMenu.Pause();
                screenMainMenu.SetIsVisible(false);
                screenMainMenu.UnloadResources();

            }
            else if (prevGameState == GameStates.MAIN_GAME_1P || prevGameState == GameStates.MAIN_GAME)
            {
                MmgHelper.wr("Hiding MAIN GAME 1P screen.");
                screenGame.Pause();
                screenGame.SetIsVisible(false);
                screenGame.UnloadResources();

            }
            else if (prevGameState == GameStates.MAIN_GAME_2P)
            {
                MmgHelper.wr("Hiding MAIN GAME 2P screen.");
                screenGame.Pause();
                screenGame.SetIsVisible(false);
                screenGame.UnloadResources();

            }

            //load
            MmgHelper.wr("Switching Game State To: " + gameState);
            if (gameState == GameStates.BLANK)
            {
                MmgHelper.wr("Showing BLANK screen.");

            }
            else if (gameState == GameStates.SPLASH)
            {
                MmgHelper.wr("Showing SPLASH screen.");
                screenSplash.LoadResources();
                screenSplash.UnPause();
                screenSplash.SetIsVisible(true);
                screenSplash.StartDisplay();
                currentScreen = screenSplash;

            }
            else if (gameState == GameStates.LOADING)
            {
                MmgHelper.wr("Showing LOADING screen.");
                screenLoading.LoadResources();
                screenLoading.UnPause();
                screenLoading.SetIsVisible(true);
                screenLoading.StartDatLoad();
                currentScreen = screenLoading;

            }
            else if (gameState == GameStates.MAIN_MENU)
            {
                MmgHelper.wr("Showing MAIN_MENU screen.");
                screenMainMenu.LoadResources();
                screenMainMenu.UnPause();
                screenMainMenu.SetIsVisible(true);
                currentScreen = screenMainMenu;

            }
            else if (gameState == GameStates.MAIN_GAME_1P || gameState == GameStates.MAIN_GAME)
            {
                MmgHelper.wr("Showing MAIN GAME 1P screen.");
                screenGame.SetGameType(GameType.GAME_ONE_PLAYER);
                screenGame.LoadResources();
                screenGame.UnPause();
                screenGame.SetIsVisible(true);
                currentScreen = screenGame;

            }
            else if (gameState == GameStates.MAIN_GAME_2P)
            {
                MmgHelper.wr("Showing MAIN GAME 2P screen.");
                screenGame.SetGameType(GameType.GAME_TWO_PLAYER);
                screenGame.LoadResources();
                screenGame.UnPause();
                screenGame.SetIsVisible(true);
                currentScreen = screenGame;

            }
        }

        /// <summary>
        /// The generic event handler method used to handle events from different game screens like the splash screen and the loading screen.
        /// 
        /// <param name="obj">The generic event message to process.</param>
        /// </summary>
        public override void HandleGenericEvent(GenericEventMessage obj)
        {
            if (obj != null)
            {
                if (obj.GetGameState() == GameStates.LOADING)
                {
                    if (obj.GetId() == ScreenLoading.EVENT_LOAD_COMPLETE)
                    {
                        //Final loading steps
                        DatExternalStrings.LOAD_EXT_STRINGS();
                        SwitchGameState(GameStates.MAIN_MENU);
                    }

                }
                else if (obj.GetGameState() == GameStates.SPLASH)
                {
                    if (obj.GetId() == ScreenSplash.EVENT_DISPLAY_COMPLETE)
                    {
                        SwitchGameState(GameStates.LOADING);
                    }

                }
            }
        }
    }
}