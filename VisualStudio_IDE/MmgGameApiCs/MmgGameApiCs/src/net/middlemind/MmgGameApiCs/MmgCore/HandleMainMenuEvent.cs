using System;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// Handles events that originate from the main menu screen. 
    /// Implements the MmgEventHandler.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class HandleMainMenuEvent : MmgEventHandler
    {
        /// <summary>
        /// The main menu screen object, ScreenMainMenu, this event handler belongs to.
        /// </summary>
        private MmgGameScreen cApp;

        /// <summary>
        /// The game panel object, GamePanel, that owns the main menu screen object, ScreenMainMenu.
        /// </summary>
        private GamePanel owner;

        /// <summary>
        /// Supported event type.
        /// </summary>
        public static int MAIN_MENU_EVENT_TYPE = 0;

        /// <summary>
        /// Supported event id for a game start event.
        /// </summary>
        public static int MAIN_MENU_EVENT_START_GAME = 0;

        /// <summary>
        /// Supported event id for a game settings event.
        /// </summary>
        public static int MAIN_MENU_EVENT_SETTINGS = 1;

        /// <summary>
        /// Supported event id for a about event.
        /// </summary>
        public static int MAIN_MENU_EVENT_ABOUT = 2;

        /// <summary>
        /// Supported event id for a help event.
        /// </summary>
        public static int MAIN_MENU_EVENT_HELP = 3;

        /// <summary>
        /// Supported event id for an exit game event.
        /// </summary>
        public static int MAIN_MENU_EVENT_EXIT_GAME = 4;

        /// <summary>
        /// Supported event id for a start one player game event. 
        /// </summary>
        public static int MAIN_MENU_EVENT_START_GAME_1P = 5;

        /// <summary>
        /// Supported event id for a start two player game event.
        /// </summary>
        public static int MAIN_MENU_EVENT_START_GAME_2P = 6;

        /// <summary>
        /// Constructor that sets the main menu screen object, ScreenMainMenu, owner and the
        /// GamePanel that owns the about screen.
        /// </summary>
        /// <param name="CApp">The main menu screen object, ScreenMainMenu, that this event handler belongs to.</param>
        /// <param name="Owner">The game panel, GamePanel, that the main menu screen belongs to.</param>
        public HandleMainMenuEvent(MmgGameScreen CApp, GamePanel Owner)
        {
            cApp = CApp;
            owner = Owner;
        }

        /// <summary>
        /// Event handler call back, when a UI action event occurs on the owner this
        /// event handler can react to that event and either call methods in the
        /// screen object that this class belongs to or it can call methods in the
        /// GamePanel that owns the screen, in other words switch the current game state.
        /// </summary>
        /// <param name="e">An MmgEvent object.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            if (owner != null)
            {
                if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME)
                {
                    owner.SwitchGameState(GamePanel.GameStates.MAIN_GAME);

                }
                else if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_1P)
                {
                    owner.SwitchGameState(GamePanel.GameStates.MAIN_GAME_1P);

                }
                else if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_2P)
                {
                    owner.SwitchGameState(GamePanel.GameStates.MAIN_GAME_2P);

                }
                else if (e.GetEventId() == HandleMainMenuEvent.MAIN_MENU_EVENT_EXIT_GAME)
                {
                    System.Environment.Exit(0);
                }
            }
        }
    }
}