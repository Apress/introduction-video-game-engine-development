using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A game screen object, ScreenMainMenu, that extends the MmgGameScreen base class. 
    /// This game screen is for displaying a main menu screen.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class ScreenMainMenu : MmgGameScreen
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        public GameStates state;

        /// <summary>
        /// Helper class for screen UI.
        /// </summary>
        public MmgBmp menuStartGame;

        /// <summary>
        /// Helper class for screen UI.
        /// </summary>
        public MmgBmp menuExitGame;

        /// <summary>
        /// Helper class for screen UI.
        /// </summary>
        public MmgBmp menuTitle;

        /// <summary>
        /// Helper class for screen UI.
        /// </summary>
        public MmgBmp menuSubTitle;

        /// <summary>
        /// Helper class for screen UI.
        /// </summary>
        public MmgBmp menuFooterUrl;

        /// <summary>
        /// The MmgBmp image to use as a menu cursor.
        /// </summary>
        public MmgBmp menuCursor;

        /// <summary>
        /// Helper class for storing game screen menu options.
        /// </summary>
        public MmgMenuContainer menu;

        /// <summary>
        /// The MmgSound to use when a menu item is selected.
        /// </summary>
        public MmgSound menuSound;

        /// <summary>
        /// The MmgFont used to display the version code for the case.
        /// </summary>
        public MmgFont version;

        /// <summary>
        /// Helper class for handling game screen events.
        /// </summary>
        public HandleMainMenuEvent handleMenuEvent = null;

        /// <summary>
        /// The GamePanel that owns this game screen. 
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        public GamePanel owner;

        /// <summary>
        /// A bool flag indicating if work needs to be done on the next MmgUpdate method. 
        /// </summary>
        public bool isDirty;

        /// <summary>
        /// A private bool used in the MmgUpdate method.
        /// </summary>
        private bool lret;

        /// <summary>
        /// A data structure that stores all the class configuration file entries from the target file.
        /// </summary>
        public Dictionary<string, MmgCfgFileEntry> classConfig;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenMainMenu(GameStates State, GamePanel Owner) : base()
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
        public virtual void LoadResources()
        {
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            MmgHelper.wr("ScreenMainMenu: LoadResources: Position: " + GetPosition().ToString());
            MmgHelper.wr("ScreenMainMenu: LoadResources: Width: " + GetWidth());
            MmgHelper.wr("ScreenMainMenu: LoadResources: Height: " + GetHeight());

            classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + "screen_main_menu.txt");

            MmgBmp tB = null;
            MmgPen p;
            string key = "";
            double scale = 1.0;
            string imgId = "";
            string sndId = "";
            MmgBmp lval = null;
            MmgSound sval = null;
            string file = "";
            int tmp = 0;

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
                key = "menuTitleScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number; //.doubleValue();
                    if (scale != 1.0)
                    {
                        menuTitle = MmgBmpScaler.ScaleMmgBmp(menuTitle, scale, false);
                    }
                }

                MmgHelper.CenterHor(menuTitle);
                menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(50));

                key = "menuTitlePosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuTitlePosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuTitle.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuTitleOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuTitle.GetPosition().SetY(menuTitle.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuTitleOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuTitle.GetPosition().SetX(menuTitle.GetX() + MmgHelper.ScaleValue(tmp));
                }

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
                key = "menuSubTitleScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number; //.doubleValue();
                    if (scale != 1.0)
                    {
                        menuSubTitle = MmgBmpScaler.ScaleMmgBmp(menuTitle, scale, false);
                    }
                }

                MmgHelper.CenterHor(menuSubTitle);
                menuSubTitle.GetPosition().SetY(menuTitle.GetY() + menuTitle.GetHeight() + MmgHelper.ScaleValue(50));

                key = "menuSubTitlePosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuSubTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuSubTitlePosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuSubTitle.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuSubTitleOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuSubTitle.GetPosition().SetY(menuSubTitle.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuSubTitleOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number; //;
                    menuSubTitle.GetPosition().SetX(menuSubTitle.GetX() + MmgHelper.ScaleValue(tmp));
                }

                AddObj(menuSubTitle);
            }


            key = "bmpMenuItemStartGame";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "start_game.png";
            }

            imgId = file;
            lval = MmgHelper.GetBasicCachedBmp(imgId);
            menuStartGame = lval;
            if (menuStartGame != null)
            {
                key = "menuStartGameScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number;
                    if (scale != 1.0)
                    {
                        menuStartGame = MmgBmpScaler.ScaleMmgBmp(menuStartGame, scale, false);
                    }
                }

                MmgHelper.CenterHor(menuStartGame);
                menuStartGame.GetPosition().SetY(menuSubTitle.GetY() + menuSubTitle.GetHeight() + MmgHelper.ScaleValue(10));

                key = "menuStartGamePosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuStartGame.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuStartGamePosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuStartGame.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuStartGameOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuStartGame.GetPosition().SetY(menuStartGame.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuStartGameOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuStartGame.GetPosition().SetX(menuStartGame.GetX() + MmgHelper.ScaleValue(tmp));
                }
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
                key = "menuExitGameScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number;
                    if (scale != 1.0)
                    {
                        menuStartGame = MmgBmpScaler.ScaleMmgBmp(menuExitGame, scale, false);
                    }
                }

                MmgHelper.CenterHor(menuExitGame);
                menuExitGame.GetPosition().SetY(menuStartGame.GetY() + menuStartGame.GetHeight() + MmgHelper.ScaleValue(10));

                key = "menuExitGamePosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuExitGame.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuExitGamePosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuExitGame.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuExitGameOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuExitGame.GetPosition().SetY(menuExitGame.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuExitGameOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuExitGame.GetPosition().SetX(menuExitGame.GetX() + MmgHelper.ScaleValue(tmp));
                }
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
                key = "menuFooterUrlScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number;
                    if (scale != 1.0)
                    {
                        menuFooterUrl = MmgBmpScaler.ScaleMmgBmp(menuFooterUrl, scale, false);
                    }
                }

                MmgHelper.CenterHor(menuFooterUrl);
                menuFooterUrl.GetPosition().SetY(menuExitGame.GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(10));

                key = "menuFooterUrlPosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuFooterUrl.GetPosition().SetY(GetPosition().GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuFooterUrlPosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuFooterUrl.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuFooterUrlOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuFooterUrl.GetPosition().SetY(menuFooterUrl.GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(tmp));
                }

                key = "menuFooterUrlOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    menuFooterUrl.GetPosition().SetX(menuFooterUrl.GetX() + MmgHelper.ScaleValue(tmp));
                }

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
        public virtual void DrawScreen()
        {
            pause = true;
            menu = new MmgMenuContainer();
            menu.SetMmgColor(null);
            isDirty = false;

            MmgMenuItem mItm = null;

            if (menuStartGame != null)
            {
                mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Start Game", HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuStartGame);
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
        public virtual void UnloadResources()
        {
            isDirty = false;
            pause = true;
            SetIsVisible(false);
            SetBackground(null);
            SetMenu(null);
            ClearObjs();

            menuStartGame = null;
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
        /// Returns the game state of this game screen.
        /// </summary>
        /// <returns>The game state of this game screen.</returns>
        public virtual GameStates GetGameState()
        {
            return state;
        }

        /// <summary>
        /// Gets a bool flag indicating if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        /// <returns>A flag indicating if there is work to be done on the next MmgUpdate call.</returns>
        public virtual bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Sets a bool flag indicating if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        /// <param name="b">A flag indicating if there is work to be done on the next MmgUpdate call.</param>
        public virtual void SetIsDirty(bool b)
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