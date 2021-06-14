using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.DungeonTrap.ChapterE2
{
    /// <summary>
    /// A game screen object, ScreenMainMenu, that extends the MmgGameScreen base class. 
    /// This game screen is for displaying a main menu screen.
    /// Created by Middlemind Games 01/31/2021
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class ScreenMainMenu : net.middlemind.MmgGameApiCs.MmgCore.ScreenMainMenu
    {
        /// <summary>
        /// An MmgBmp instance that provides custom menu items for one player games.
        /// </summary>
        private MmgBmp menuStartGame1P;

        /// <summary>
        /// An MmgBmp instance that provides custom menu items for two player games.
        /// </summary>
        private MmgBmp menuStartGame2P;

        /// <summary>
        /// A private variable used in drawing routine methods.
        /// </summary>
        private bool lret;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenMainMenu(GameStates State, GamePanel Owner) : base(State, Owner)
        {
            isDirty = false;
            pause = false;
            ready = false;
            state = State;
            owner = Owner;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public override void LoadResources()
        {
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_main_menu.txt");

            MmgDebug.wr("ClassConfigFile: " + GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_main_menu.txt");

            MmgBmp tB = null;
            MmgPen p;
            String key = "";
            String imgId = "";
            String sndId = "";
            MmgBmp lval = null;
            MmgSound sval = null;
            String file = "";

            p = new MmgPen();
            p.SetCacheOn(false);
            handleMenuEvent = new HandleMainMenuEvent(this, owner);

            key = "soundMenuSelect";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "jump1.wav";
            }

            sndId = file;
            sval = MmgHelper.GetBasicCachedSound(sndId);
            menuSound = sval;

            tB = MmgHelper.CreateFilledBmp(w, h, MmgColor.GetBlack());
            if (tB != null)
            {
                SetCenteredBackground(tB);
            }

            key = "bmpGameTitle";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "game_title.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuTitle = lval;
            if (menuTitle != null)
            {
                MmgHelper.CenterHor(menuTitle);
                menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(40));
                menuTitle = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuTitle", menuTitle, classConfig, menuTitle.GetPosition());
                AddObj(menuTitle);
            }

            key = "bmpGameSubTitle";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "game_sub_title.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuSubTitle = lval;
            if (menuSubTitle != null)
            {
                MmgHelper.CenterHor(menuSubTitle);
                menuSubTitle.GetPosition().SetY(menuTitle.GetY() + menuTitle.GetHeight() + MmgHelper.ScaleValue(10));
                menuSubTitle = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuSubTitle", menuSubTitle, classConfig, menuSubTitle.GetPosition());
                AddObj(menuSubTitle);
            }

            key = "bmpMenuItemStartGame1p";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "start_game_1p.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuStartGame1P = lval;
            if (menuStartGame1P != null)
            {
                MmgHelper.CenterHor(menuStartGame1P);
                menuStartGame1P.GetPosition().SetY(menuSubTitle.GetY() + menuSubTitle.GetHeight() + MmgHelper.ScaleValue(10));
                menuStartGame1P = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuStartGame1p", menuStartGame1P, classConfig, menuStartGame1P.GetPosition());
            }

            key = "bmpMenuItemStartGame2p";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "start_game_2p.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuStartGame2P = lval;
            if (menuStartGame2P != null)
            {
                MmgHelper.CenterHor(menuStartGame2P);
                menuStartGame2P.GetPosition().SetY(menuStartGame1P.GetY() + menuStartGame1P.GetHeight() + MmgHelper.ScaleValue(10));
                menuStartGame2P = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuStartGame2p", menuStartGame2P, classConfig, menuStartGame2P.GetPosition());
            }

            key = "bmpMenuItemExitGame";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "exit_game.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuExitGame = lval;
            if (menuExitGame != null)
            {
                MmgHelper.CenterHor(menuExitGame);
                menuExitGame.GetPosition().SetY(menuStartGame2P.GetY() + menuStartGame2P.GetHeight() + MmgHelper.ScaleValue(10));
                menuExitGame = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuExitGame", menuExitGame, classConfig, menuExitGame.GetPosition());
            }

            key = "bmpFooterUrl";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "footer_url.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuFooterUrl = lval;
            if (menuFooterUrl != null)
            {
                MmgHelper.CenterHor(menuFooterUrl);
                menuFooterUrl.GetPosition().SetY(menuExitGame.GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(10));
                menuFooterUrl = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuFooterUrl", menuFooterUrl, classConfig, menuFooterUrl.GetPosition());
                AddObj(menuFooterUrl);
            }

            key = "bmpMenuCursorLeft";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "cursor_hand_sm_right.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuCursor = lval;
            SetLeftCursor(menuCursor);

            key = "version";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "version0.0.1";
            }

            version = MmgFontData.CreateDefaultBoldMmgFontSm();
            version.SetText(file);
            version.SetPosition(MmgHelper.ScaleValue(10), GetY() + (h - version.GetHeight() + MmgHelper.ScaleValue(10)));
            AddObj(version);

            isDirty = true;
            ready = true;
            pause = false;
        }

        /// <summary>
        /// A callback method used to process A click events.
        /// </summary>
        /// <param name="src">The source of the A click event, keyboard, GPIO gamepad, USB gamepad.</param>
        /// <returns>A bool flag indicating if work was done.</returns>
        public override bool ProcessAClick(int src)
        {
            int idx = GetMenuIdx();
            MmgMenuItem mmi;
            mmi = (MmgMenuItem)menu.GetContainer()[idx];

            if (mmi != null)
            {
                ProcessMenuItemSel(mmi);
                return true;
            }

            return true;
        }

        /// <summary>
        /// A callback method used to process dpad release events.
        /// </summary>
        /// <param name="dir">The dpad direction of the event.</param>
        /// <returns>A bool flag indicating if work was done.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            if (dir == GameSettings.UP_KEYBOARD || dir == GameSettings.UP_GAMEPAD_1)
            {
                MoveMenuSelUp();
            }
            else if (dir == GameSettings.DOWN_KEYBOARD || dir == GameSettings.DOWN_GAMEPAD_1)
            {
                MoveMenuSelDown();
            }

            return true;
        }

        /// <summary>
        /// Forces this screen to prepare itself for display. 
        /// This is the method that handles displaying different game screen text.Calling draw screen prepares the screen for display.
        /// </summary>
        public override void DrawScreen()
        {
            pause = true;
            menu = new MmgMenuContainer();
            menu.SetMmgColor(null);
            isDirty = false;

            MmgMenuItem mItm = null;

            if (menuStartGame1P != null)
            {
                mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Start Game 1P", HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_1P, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuStartGame1P);
                mItm.SetSound(menuSound);
                menu.Add(mItm);
            }

            if (menuStartGame2P != null)
            {
                mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Start Game 2P", HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_2P, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuStartGame2P);
                mItm.SetSound(menuSound);
                menu.Add(mItm);
            }

            if (menuExitGame != null)
            {
                mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Exit Game", HandleMainMenuEvent.MAIN_MENU_EVENT_EXIT_GAME, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuExitGame);
                mItm.SetSound(menuSound);
                menu.Add(mItm);
            }

            SetMenuStart(0);
            SetMenuStop(menu.GetCount() - 1);

            SetMenu(menu);
            SetMenuOn(true);
            pause = false;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public override void UnloadResources()
        {
            isDirty = false;
            pause = true;

            SetIsVisible(false);
            SetBackground(null);
            SetMenu(null);
            ClearObjs();

            menuStartGame = null;
            menuStartGame1P = null;
            menuStartGame2P = null;
            menuExitGame = null;
            menuTitle = null;
            menuFooterUrl = null;
            menuCursor = null;
            menuSound = null;

            handleMenuEvent = null;
            classConfig = null;

            base.UnloadResources();

            menu = null;
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// </summary>
        /// <returns>The game state of this game screen.</returns>
        public override GameStates GetGameState()
        {
            return state;
        }

        /// <summary>
        /// Gets a bool flag indicating if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        /// <returns>A flag indicating if there is work to be done on the next MmgUpdate call.</returns>
        public override bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Sets a bool flag indicating if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        /// <param name="b">A flag indicating if there is work to be done on the next MmgUpdate call.</param>
        public override void SetIsDirty(bool b)
        {
            isDirty = b;
        }

        /// <summary>
        /// The main drawing routine.
        /// </summary>
        /// <param name="p">An MmgPen object to use for drawing this game screen.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// Update the current sprite animation frame index.
        /// </summary>
        /// <param name="updateTick">The index of the MmgUpdate call.</param>
        /// <param name="currentTimeMs">The current time in milliseconds of the MmgUpdate call.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds since the last MmgUpdate call.</param>
        /// <returns>A bool flag indicating if any work was done.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                if (base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                {
                    lret = true;
                }

                if (isDirty == true)
                {
                    lret = true;
                    DrawScreen();
                }

            }

            return lret;
        }
    }
}