using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen class that extends the MmgGameScreen base class.
    /// This class is for testing API classes.
    /// Created by Middlemind Games 03/22/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class ScreenTestMmgMainMenu : net.middlemind.MmgGameApiCs.MmgCore.ScreenMainMenu
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
        /// An MmgFont class instance used as the title of this test screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// A private bool flag used in the MmgUpdate method during the update process.
        /// </summary>
        private bool lret;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenTestMmgMainMenu(GameStates State, GamePanel Owner) : base(State, Owner)
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

            MmgBmp tB = null;
            String key = "";
            String imgId = "";
            String sndId = "";
            MmgBmp lval = null;
            MmgSound sval = null;

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Main Menu (7 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);
            handleMenuEvent = null;         //handleMenuEvent = new HandleMainMenuEvent(this, owner); 

            key = "soundMenuSelect";
            sndId = MmgHelper.ContainsKeyString(key, "jump1.wav", classConfig);
            sval = MmgHelper.GetBasicCachedSound(sndId);
            menuSound = sval;

            tB = MmgHelper.CreateFilledBmp(w, h, MmgColor.GetBlack());
            if (tB != null)
            {
                SetCenteredBackground(tB);
            }

            key = "bmpGameTitle";
            imgId = MmgHelper.ContainsKeyString(key, "game_title.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuTitle = lval;
            if (menuTitle != null)
            {
                MmgHelper.CenterHor(menuTitle);
                menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(40));
                menuTitle = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuTitle", menuTitle, classConfig, GetPosition());
                AddObj(menuTitle);
            }

            key = "bmpGameSubTitle";
            imgId = MmgHelper.ContainsKeyString(key, "game_sub_title.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuSubTitle = lval;
            if (menuSubTitle != null)
            {
                MmgHelper.CenterHor(menuSubTitle);
                menuSubTitle.GetPosition().SetY(menuTitle.GetY() + menuTitle.GetHeight() + MmgHelper.ScaleValue(10));
                menuSubTitle = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuSubTitle", menuSubTitle, classConfig, GetPosition());
                AddObj(menuSubTitle);
            }

            key = "bmpMenuItemStartGame1p";
            imgId = MmgHelper.ContainsKeyString(key, "start_game_1p.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuStartGame1P = lval;
            if (menuStartGame1P != null)
            {
                MmgHelper.CenterHor(menuStartGame1P);
                menuStartGame1P.GetPosition().SetY(menuSubTitle.GetY() + menuSubTitle.GetHeight() + MmgHelper.ScaleValue(10));
                menuStartGame1P = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuStartGame1p", menuStartGame1P, classConfig, GetPosition());
            }

            key = "bmpMenuItemStartGame2p";
            imgId = MmgHelper.ContainsKeyString(key, "start_game_2p.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuStartGame2P = lval;
            if (menuStartGame2P != null)
            {
                MmgHelper.CenterHor(menuStartGame2P);
                menuStartGame2P.GetPosition().SetY(menuStartGame1P.GetY() + menuStartGame1P.GetHeight() + MmgHelper.ScaleValue(10));
                menuStartGame2P = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuStartGame2p", menuStartGame2P, classConfig, GetPosition());
            }

            key = "bmpMenuItemExitGame";
            imgId = MmgHelper.ContainsKeyString(key, "exit_game.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuExitGame = lval;
            if (menuExitGame != null)
            {
                MmgHelper.CenterHor(menuExitGame);
                menuExitGame.GetPosition().SetY(menuStartGame2P.GetY() + menuStartGame2P.GetHeight() + MmgHelper.ScaleValue(10));
                menuExitGame = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuExitGame", menuExitGame, classConfig, GetPosition());
            }

            key = "bmpFooterUrl";
            imgId = MmgHelper.ContainsKeyString(key, "footer_url.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuFooterUrl = lval;
            if (menuFooterUrl != null)
            {
                MmgHelper.CenterHor(menuFooterUrl);
                menuFooterUrl.GetPosition().SetY(menuExitGame.GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(10));
                menuFooterUrl = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("menuFooterUrl", menuFooterUrl, classConfig, GetPosition());
                AddObj(menuFooterUrl);
            }

            key = "bmpMenuCursorLeft";
            imgId = MmgHelper.ContainsKeyString(key, "cursor_hand_sm_right.png", classConfig);
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuCursor = lval;
            SetLeftCursor(menuCursor);

            key = "version";
            imgId = MmgHelper.ContainsKeyString(key, "version0.0.1", classConfig);
            version = MmgFontData.CreateDefaultBoldMmgFontSm();
            version.SetText(imgId);
            version.SetPosition(MmgHelper.ScaleValue(10), GetY() + (h - version.GetHeight() + MmgHelper.ScaleValue(10)));
            AddObj(version);

            isDirty = true;
            ready = true;
            pause = false;
        }

        /// <summary>
        /// A method to handle A click events from the MainFrame.
        /// </summary>
        /// <param name="src">TODO: Add comment</param>
        /// <returns>A bool indicating if the click event was handled by this Screen.</returns>
        public override bool ProcessAClick(int src)
        {
            int idx = GetMenuIdx();
            MmgMenuItem mmi;
            mmi = (MmgMenuItem)menu.GetContainer()[idx];

            if (mmi != null)
            {
                ProcessMenuItemSel(mmi);
                isDirty = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// A method to handle dpad release events from the MainFrame.
        /// </summary>
        /// <param name="dir">A dpad code indicating if the UP, DOWN, LEFT, RIGHT direction was released.</param>
        /// <returns>A bool indicating if the Screen handled the dpad release event.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            if (dir == GameSettings.UP_KEYBOARD || dir == GameSettings.UP_GAMEPAD_1)
            {
                MoveMenuSelUp();
                isDirty = true;

            }
            else if (dir == GameSettings.DOWN_KEYBOARD || dir == GameSettings.DOWN_GAMEPAD_1)
            {
                MoveMenuSelDown();
                isDirty = true;

            }
            else if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_08);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_06);

            }

            return true;
        }

        /// <summary>
        /// Forces this screen to prepare itself for display. 
        /// This is the method that handles displaying different game screen text.Calling draw screen
        /// prepares the screen for display.
        /// </summary>
        public override void DrawScreen()
        {
            pause = true;
            if (menu == null)
            {
                menu = new MmgMenuContainer();
                menu.SetMmgColor(null);
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
            }
            isDirty = false;
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
            menu = null;
            ready = false;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// The MmgUpdate method used to call the update method of the child objects.
        /// </summary>
        /// <param name="updateTick">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
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
                    isDirty = false;
                }
            }
            return lret;
        }
    }
}