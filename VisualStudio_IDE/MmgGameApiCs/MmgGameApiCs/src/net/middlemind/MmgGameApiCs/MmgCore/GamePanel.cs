using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using net.middlemind.MmgGameApiCs.MmgUnitTests;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The Canvas used to render the game to.
    /// This is the connection point between native UI rendering and the game rendering.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GamePanel : Game, GenericEventHandler, GamePadSimple
    {
        /// <summary>
        /// An enumeration that lists all of the game states.
        /// Add new states here or use the general states, GAME_SCREEN_XX to control
        /// what the game displays.
        /// </summary>
        public enum GameStates
        {
            LOADING,
            BLANK,
            SPLASH,
            MAIN_MENU,
            ABOUT,
            HELP_MENU,
            HELP_PROLOGUE,
            HELP_ITEM_DESC,
            HELP_ENEMY_DESC,
            HELP_ITEM_DESC_ITEM_TEXT,
            HELP_GAME_PLAY_OVERWORLD,
            HELP_GAME_PLAY_BATTLE_MODE,
            HELP_CHAR_DESC,
            HELP_QUEST_DESC,
            HELP_ROOM_DESC,
            HELP_ROOM_DESC_ROOM_DETAILS,
            MAIN_GAME,
            MAIN_GAME_1P,
            MAIN_GAME_2P,
            SETTINGS,
            GAME_SCREEN_01,
            GAME_SCREEN_02,
            GAME_SCREEN_03,
            GAME_SCREEN_04,
            GAME_SCREEN_05,
            GAME_SCREEN_06,
            GAME_SCREEN_07,
            GAME_SCREEN_08,
            GAME_SCREEN_09,
            GAME_SCREEN_10,
            GAME_SCREEN_11,
            GAME_SCREEN_12,
            GAME_SCREEN_13,
            GAME_SCREEN_14,
            GAME_SCREEN_15,
            GAME_SCREEN_16,
            GAME_SCREEN_17,
            GAME_SCREEN_18,
            GAME_SCREEN_19,
            GAME_SCREEN_20,
            GAME_SCREEN_21,
            GAME_SCREEN_22,
            GAME_SCREEN_23,
            GAME_SCREEN_24,
            GAME_SCREEN_25,
            GAME_SCREEN_26,
            GAME_SCREEN_27,
            GAME_SCREEN_28,
            GAME_SCREEN_29,
            GAME_SCREEN_30,
            GAME_SCREEN_31,
            GAME_SCREEN_32,
            GAME_SCREEN_33,
            GAME_SCREEN_34,
            GAME_SCREEN_35,
            GAME_SCREEN_36,
            GAME_SCREEN_37,
            GAME_SCREEN_38,
            GAME_SCREEN_39,
            GAME_SCREEN_40
        }

        /// <summary>
        /// The width of the window this panel is displayed in.
        /// </summary>
        public int winWidth;

        /// <summary>
        /// The height of the window this panel is displayed in.
        /// </summary>
        public int winHeight;

        /// <summary>
        /// The X coordinate of this panel.
        /// </summary>
        public int myX;

        /// <summary>
        /// The Y coordinate of this panel.
        /// </summary>
        public int myY;

        /// <summary>
        /// The scaled width of the window this panel is displayed in.
        /// </summary>
        public int sWinWidth;

        /// <summary>
        /// The scaled height of the window this panel is displayed in.
        /// </summary>
        public int sWinHeight;

        /// <summary>
        /// The scaled X coordinate of this panel.
        /// </summary>
        public int sMyX;

        /// <summary>
        /// The scaled Y coordinate of this panel.
        /// </summary>
        public int sMyY;

        /// <summary>
        /// The target game width.
        /// </summary>
        public static int GAME_WIDTH = 854;

        /// <summary>
        /// The target game height.
        /// </summary>
        public static int GAME_HEIGHT = 416;

        /// <summary>
        /// Boolean that pauses the game.
        /// </summary>
        public static bool PAUSE = false;

        /// <summary>
        /// Boolean that exits the game.
        /// </summary>
        public static bool EXIT = false;

        /// <summary>
        /// The gameScreens field is a Dictionary that can be used to hold a reference to all game screens.
        /// </summary>
        public Dictionary<GameStates, MmgGameScreen> gameScreens;

        /// <summary>
        /// The current game screen being displayed.
        /// </summary>
        public MmgGameScreen currentScreen;

        /// <summary>
        /// An MmgPen class, used to draw Mmg API objects.
        /// </summary>
        public MmgPen p;

        /// <summary>
        /// An instance of the GameStates enumeration that holds the previous game state.
        /// </summary>
        public GameStates prevGameState;

        /// <summary>
        /// An instance of the GameStates enumeration that holds the current game state.
        /// </summary>
        public GameStates gameState;

        /// <summary>
        /// A static Dictionary instance that can be used to store objects for quick, easy access.
        /// </summary>
        public static Dictionary<string, object> VARS = new Dictionary<string, object>();

        /// <summary>
        /// A string used to store the current frame rate information in the debug header.
        /// </summary>
        public static string FPS = "Drawing FPS: 0000 Actual FPS: 00";

        /// <summary>
        /// A string used to write data to the debug header.
        /// </summary>
        public static string VAR1 = "** EMPTY **";

        /// <summary>
        /// A second string used to write data to the debug header.
        /// </summary>
        public static string VAR2 = "** EMPTY **";

        /// <summary>
        /// A canvas object used to draw to the JFrame.
        /// </summary>
        public GameWindow canvas;

        /// <summary>
        /// Monogame implementation specific object used to get access to a graphics device.
        /// </summary>
        private GraphicsDeviceManager gdm;

        /// <summary>
        /// The low level Monogame drawing object.
        /// </summary>
        private SpriteBatch pen;

        /// <summary>
        /// Controls the visibility of the game panel.
        /// </summary>
        private bool visible = true;

        /// <summary>
        /// The name of the game panel.
        /// </summary>
        private string name = "";

        /// <summary>
        /// A BufferedImage used to render the game screen to. 
        /// The background image is then rendered to the panel once it is done drawing.
        /// </summary>
        public RenderTarget2D background;

        /// <summary>
        /// A Java rendering API for drawing graphics to a BufferedImage.
        /// </summary>
        public SpriteBatch backgroundGraphics;

        /// <summary>
        /// A Java rendering API for drawing graphics to the JFrame.
        /// </summary>
        public SpriteBatch graphics;

        /// <summary>
        /// An optional scale value that will scale the background image before drawing it to the JFrame.
        /// </summary>
        public double scale = 1.0;

        /// <summary>
        /// An integer that records how many frames have been drawn. 
        /// The updateTick class field is updated on each UpdateGame method call.
        /// </summary>
        public int updateTick = 0;

        /// <summary>
        /// A class field used to store the current time in ms for passing time information to the update method.
        /// </summary>
        public long now;

        /// <summary>
        /// A class field used to store the previous time in ms for passing time information to the update method.
        /// </summary>
        public long prev;

        /// <summary>
        /// A Java rendering API font class used to draw debugging information like the FPS, VAR1, and VAR2 class fields.
        /// </summary>
        public SpriteFont debugFont;

        /// <summary>
        /// The Java rendering API color that is used to draw the game debugging information.
        /// </summary>
        public Color debugColor = Color.White;

        /// <summary>
        /// A place holder class field for storing the current font of the Java rendering API Pen class. 
        /// Used to hold the Pen's current font, then sets the Pen's font for drawing debug information, then restoring the Pen's previous font.
        /// </summary>
        public SpriteFont tmpF;

        /// <summary>
        /// An instance of the GameType enumeration that can be used to track if the game is a new game or a continuation of an existing game.
        /// </summary>
        public static GameType GAME_TYPE = GameType.GAME_NEW;

        /// <summary>
        /// An enumeration used to help track the type of game that was started.
        /// </summary>
        public enum GameType
        {
            GAME_NEW,
            GAME_CONTINUE,
            GAME_ONE_PLAYER,
            GAME_TWO_PLAYER,
            GAME_NETWORK_TWO_PLAYER,
            GAME_NETWORK_TWO_PLAYER_P1,
            GAME_NETWORK_TWO_PLAYER_P2,
            GAME_NETWORK_TWO_PLAYER_LEFT,
            GAME_NETWORK_TWO_PLAYER_RIGHT
        }

        /// <summary>
        /// A class field that tracks the last X position of the mouse during movement or dragging.
        /// </summary>
        public int lastX;

        /// <summary>
        /// A class field that tracks the last Y position of the mouse during movement or dragging.
        /// </summary>
        public int lastY;

        /// <summary>
        /// A class field that tracks the last time in ms that a key was pressed.
        /// </summary>
        public long lastKeyPressEvent = -1;

        /// <summary>
        /// A Java rendering API instance that is used to draw to the JFrame.
        /// </summary>
        public SpriteBatch bg;

        /// <summary>
        /// A Java rendering API instance that is used to draw the game screen to a buffered image.
        /// </summary>
        public SpriteBatch g;

        /// <summary>
        /// An instance of the ScreenSplash class that is used to draw the game's splash screen.
        /// </summary>
        public ScreenSplash screenSplash;

        /// <summary>
        /// An instance of the ScreenLoading class that is used to draw the game's loading screen.
        /// </summary>
        public ScreenLoading screenLoading;

        /// <summary>
        /// An instance of the ScreenMainMenu class that is used to draw the game's main menu screen.
        /// </summary>
        public ScreenMainMenu screenMainMenu;

        /// <summary>
        /// A class field that is used to add an offset into the mouse input X coordinate.
        /// </summary>
        public int mouseOffsetX = 0;

        /// <summary>
        /// A class field that is used to add an offset into the mouse input Y coordinate.
        /// </summary>
        public int mouseOffsetY = 0;

        /// <summary>
        /// A class field that initializes a static class that holds screen size and position data.
        /// </summary>
        public MmgScreenData screenData;

        /// <summary>
        /// A class field that initializes a static class the holds font creation and size data.
        /// </summary>
        public MmgFontData fontData;

        /// <summary>
        /// A GamePadHub instance used for processing USB gamepad input.
        /// </summary>
        public GamePadHub gamePadHub;

        /// <summary>
        /// A GamePadRunner instance used for polling gamepad input from the GamePadHub.
        /// </summary>
        public GamePadHubRunner gamePadRunner;

        /// <summary>
        /// A Thread used to process the USB gamepad input if threaded polling is enabled in the GameSettings class.
        /// </summary>
        public Thread gpadTr;

        /// <summary>
        /// A GpioPadHub instance used for processing GPIO gamepad input.
        /// </summary>
        public GpioHub gpioHub;

        /// <summary>
        /// A GpioPadRunner instance used for polling gamepad input from the GpioPadHub.
        /// </summary>
        public GpioHubRunner gpioRunner;

        /// <summary>
        /// A Thread used to process the GPIO gamepad input if threaded polling is enabled in the GameSettings class.
        /// </summary>
        public Thread gpioTr;

        /// <summary>
        /// An MmgBmp object used to draw a white square.
        /// </summary>
        private MmgBmp sqrWhite = null;

        /// <summary>
        /// An MmgBmp object used to draw a black square.
        /// </summary>
        private MmgBmp sqrBlack = null;

        /// <summary>
        /// A specific dark gray color used by the Java implementation as a background color.
        /// </summary>
        private Color DarkGray = new Color(64, 64, 64);

        /// <summary>
        /// A helper variable used to hold a debug font.
        /// </summary>
        private MmgFont mmgDebugFont = null;

        /// <summary>
        /// A list of keyboard keys that are in the down position.
        /// </summary>
        private List<int> keysDown;

        /// <summary>
        /// A list of mouse buttons that are in the down position.
        /// </summary>
        private List<string> buttonsDown;

        /// <summary>
        /// A copy of the keyboard state.
        /// </summary>
        private KeyboardState stateK;

        /// <summary>
        /// The previous copy of the keyboard state.
        /// </summary>
        private KeyboardState statePrevK;

        /// <summary>
        /// A boolean indicating a shift key is in the down position.
        /// </summary>
        private bool keyShiftDown = false;

        /// <summary>
        /// A boolean indicating the caps lock key is in the down position.
        /// </summary>
        private bool keyCapsLockOn = false;

        /// <summary>
        /// A copy of the mouse state.
        /// </summary>
        private MouseState stateM;

        /// <summary>
        /// A copy of the previous mouse state.
        /// </summary>
        private MouseState statePrevM;

        /// <summary>
        /// A boolean indicating that unit tests are running.
        /// </summary>
        private bool runningTests = false;

        /// <summary>
        /// Target frames per second.
        /// </summary>
        public readonly long tFps;

        /// <summary>
        /// Target frame time.
        /// </summary>
        public readonly long tFrameTime;

        /// <summary>
        /// Actual frames per second. 
        /// The actual frames the game might run at if it wasn't controlled.
        /// </summary>
        public long aFps;

        /// <summary>
        /// Real frames per second. 
        /// The controlled frames per second.
        /// </summary>
        public long rFps;

        /// <summary>
        /// Last frame stop time.
        /// </summary>
        public long frameStart;

        /// <summary>
        /// Last frame start time.
        /// </summary>
        public long frameStop;

        /// <summary>
        /// Frame time.
        /// </summary>
        public long frameTime;

        /// <summary>
        /// A long value indicating what the target FPS is for the game.
        /// </summary>
        public static long TARGET_FPS = 30L;

        /// <summary>
        /// Constructor, sets the MainFrame, window dimensions, and position of the main drawing surface.
        /// </summary>
        /// <param name="WinWidth"></param>
        /// <param name="WinHeight"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="GameWidth"></param>
        /// <param name="GameHeight"></param>
        public GamePanel(int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight) : base()
        {
            keysDown = new List<int>();
            buttonsDown = new List<string>();
            gdm = new GraphicsDeviceManager(this);

            winWidth = WinWidth;
            winHeight = WinHeight;
            MmgApiGame.GAME_WIDTH = GameWidth;
            MmgApiGame.GAME_HEIGHT = GameHeight;
            sWinWidth = (int)(winWidth * scale);
            sWinHeight = (int)(winHeight * scale);

            MmgHelper.wr("GamePanel: WinWidth: " + WinWidth);
            MmgHelper.wr("GamePanel: WinHeight: " + WinHeight);
            MmgHelper.wr("GamePanel: GameWidth: " + GameWidth);
            MmgHelper.wr("GamePanel: GameHeight: " + GameHeight);
            MmgHelper.wr("TargetFPS: GameHeight: " + TARGET_FPS);

            myX = X;
            myY = Y;
            sMyX = myX + (winWidth - sWinWidth);
            sMyY = myY + (winHeight - sWinHeight);

            now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            prev = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            screenSplash = new ScreenSplash(GameStates.SPLASH, this);
            screenLoading = new ScreenLoading(GameStates.LOADING, this);
            screenMainMenu = new ScreenMainMenu(GameStates.MAIN_MENU, this);

            Exiting += windowClosing;
            Activated += windowActivated;

            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0d / (double)TARGET_FPS);          
        }

        //NOTE: Added to the Monogame port to mimic the Java window closing implementation.
        /// <summary>
        /// An event handler that fires when the window has been activated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        public virtual void windowActivated(object sender, EventArgs e)
        {
            canvas = Window;
            setSize(winWidth, winHeight);
            setResizable(false);
            setVisible(true);
            setName(GameSettings.NAME);

            if (GameSettings.DEVELOPMENT_MODE_ON == false)
            {
                setTitle(GameSettings.TITLE);
            }
            else
            {
                setTitle(GameSettings.TITLE + " - " + GameSettings.DEVELOPER_COMPANY + " (" + GameSettings.VERSION + ")");
            }
        }

        //NOTE: Added to the Monogame port to mimic the Java window closing implementation.
        /// <summary>
        /// An event handler that fires when the window is starting to close.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event arguments.</param>
        private void windowClosing(object sender, EventArgs e)
        {
            try
            {
                MmgHelper.wr("GamePanel: WindowClosing");
                GamePanel.PAUSE = true;
                GamePanel.EXIT = true;
                //RunFrameRate.PAUSE = true;
                //RunFrameRate.RUNNING = false;
                Dispose();
                Environment.Exit(0);
                Environment.FailFast("0");
            }
            catch (Exception ex)
            {
                MmgHelper.wrErr(ex);
            }
        }

        /// <summary>
        /// Sets the dimensions of the current game screen.
        /// </summary>
        /// <param name="w">The width of the game screen.</param>
        /// <param name="h">The height of the game screen.</param>
        public void setSize(int w, int h)
        {
            gdm.PreferredBackBufferWidth = w;
            gdm.PreferredBackBufferHeight = h;
            gdm.ApplyChanges();            
        }

        /// <summary>
        /// Sets a boolean flag indicating if the screen can be resized or not.
        /// </summary>
        /// <param name="b">A boolean indicating if the screen can be resized or not.</param>
        public void setResizable(bool b)
        {
            canvas.AllowUserResizing = b;
        }

        /// <summary>
        /// Sets the name of this game screen.
        /// </summary>
        /// <param name="n">The name of the game screen.</param>
        public void setName(string n)
        {
            name = n;
        }

        /// <summary>
        /// Sets a boolean indicating that this game screen is visible.
        /// </summary>
        /// <param name="b">A boolean flag indicating the screen is visible.</param>
        public void setVisible(bool b)
        {
            visible = b;
        }

        /// <summary>
        /// Sets the title of the game screen.
        /// </summary>
        /// <param name="s">The title of the game screen.</param>
        public void setTitle(string s)
        {
            canvas.Title = s;
        }

        /// <summary>
        /// A Monogame startup method where initialization can take place.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// A method used to load the content used by this class.
        /// </summary>
        protected override void LoadContent()
        {
            MmgHelper.wr("===============LoadContent");

            MmgScreenData.GRAPHICS_CONFIG = gdm.GraphicsDevice;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            MmgScreenData.CONTENT_MANAGER = this.Content;
            graphics = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);

            sqrWhite = MmgHelper.CreateFilledBmp(1, 1, MmgColor.GetWhite());
            sqrBlack = MmgHelper.CreateFilledBmp(1, 1, MmgColor.GetBlack());

            MmgHelper.wr("");
            MmgHelper.wr("GamePanel Window Width: " + winWidth);
            MmgHelper.wr("GamePanel Window Height: " + winHeight);
            MmgHelper.wr("GamePanel Offset X: " + myX);
            MmgHelper.wr("GamePanel Offset Y: " + myY);

            screenData = new MmgScreenData(winWidth, winHeight, MmgApiGame.GAME_WIDTH, MmgApiGame.GAME_HEIGHT);
            MmgHelper.wr("");
            MmgHelper.wr("--- MmgScreenData ---");
            MmgHelper.wr(MmgScreenData.ApiToString());

            fontData = new MmgFontData();
            MmgHelper.wr("");
            MmgHelper.wr("--- MmgFontData ---");
            MmgHelper.wr(MmgFontData.ApiToString());
            debugFont = MmgFontData.CreateDefaultFontSm();
            mmgDebugFont = new MmgFont(debugFont, "Test", 0, 0, MmgColor.GetWhite(), MmgFontData.DEFAULT_FONT_TYPE);

            MmgHelper.wr("FontHeight: " + mmgDebugFont.GetHeight() + ", " + MmgFontData.GetFontSize());

            p = new MmgPen();
            MmgPen.ADV_RENDER_HINTS = true;
            PrepBuffers();

            screenSplash.SetGenericEventHandler(this);
            screenLoading.SetGenericEventHandler(this);
            screenLoading.SetSlowDown(500);

            gameScreens = new Dictionary<GameStates, MmgGameScreen>();
            gameState = GameStates.BLANK;

            if (GameSettings.GAMEPAD_1_ON)
            {
                gamePadHub = new GamePadHub(GameSettings.GAMEPAD_1_INDEX);
                gamePadRunner = new GamePadHubRunner(gamePadHub, GameSettings.GAMEPAD_1_POLLING_INTERVAL_MS, this);
                if (GameSettings.GAMEPAD_1_THREADED_POLLING)
                {
                    ThreadStart ts = new ThreadStart(gamePadRunner.run);
                    gpadTr = new Thread(ts);
                    gpadTr.Start();
                }
            }

            if (GameSettings.GPIO_GAMEPAD_ON)
            {
                gpioHub = new GpioHub();
                gpioRunner = new GpioHubRunner(gpioHub, GameSettings.GPIO_GAMEPAD_POLLING_INTERVAL_MS, this);
                if (GameSettings.GPIO_GAMEPAD_THREADED_POLLING)
                {
                    ThreadStart ts = new ThreadStart(gpioRunner.run);
                    gpioTr = new Thread(ts);
                    gpioTr.Start();
                }
            }

            MmgHelper.wr("GamePanel: RunUnitTests: " + GameSettings.RUN_UNIT_TESTS);
            if (!GameSettings.RUN_UNIT_TESTS)
            {
                SwitchGameState(GameStates.SPLASH);
            }
        }

        /// <summary>
        /// The ProcessDpadPress method is used to pass dpad press information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
        /// The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
        /// </summary>
        /// <param name="dir">The dir argument is a code that represents which dpad direction was processed.</param>
        public virtual void ProcessDpadPress(int dir)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessDpadPress: " + dir);
                currentScreen.ProcessDpadPress(dir);
            }
        }

        /// <summary>
        /// The ProcessDpadRelease method is used to pass dpad release information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
        /// The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
        /// </summary>
        /// <param name="dir">The dir argument is a code that represents which dpad direction was processed.</param>
        public virtual void ProcessDpadRelease(int dir)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessDpadRelease: " + dir);
                currentScreen.ProcessDpadRelease(dir);
            }
        }

        /// <summary>
        /// The ProcessDpadClick method is used to pass dpad click information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
        /// The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
        /// </summary>
        /// <param name="dir">The dir argument is a code that represents which dpad direction was processed.</param>
        public virtual void ProcessDpadClick(int dir)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessDpadClick: " + dir);
                currentScreen.ProcessDpadClick(dir);
            }
        }

        /// <summary>
        /// The ProcessAPress method is used to pass A button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">The source of the A event.</param>
        public virtual void ProcessAPress(int src)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessAPress: " + src);
                currentScreen.ProcessAPress(src);
            }
        }

        /// <summary>
        /// The ProcessARelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">The source of the A event.</param>
        public virtual void ProcessARelease(int src)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessARelease: " + src);
                currentScreen.ProcessARelease(src);
            }
        }

        /// <summary>
        /// The ProcessAClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">The source of the A event.</param>
        public virtual void ProcessAClick(int src)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessAClick: " + src);
                currentScreen.ProcessAClick(src);
            }
        }

        /// <summary>
        /// The ProcessBPress method is used to pass B button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">The source of the B event.</param>
        public virtual void ProcessBPress(int src)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessBPress: " + src);
                currentScreen.ProcessBPress(src);
            }
        }

        /// <summary>
        /// The ProcessBRelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">The source of the B event.</param>
        public virtual void ProcessBRelease(int src)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessBRelease: " + src);
                currentScreen.ProcessBRelease(src);
            }
        }

        /// <summary>
        /// The ProcessBClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="src">The source of the B event.</param>
        public virtual void ProcessBClick(int src)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessBClick: " + src);
                currentScreen.ProcessBClick(src);
            }
        }

        /// <summary>
        /// The ProcessDebugClick method is used to send debug click events to the MmgGameScreen class implementation, currentScreen.
        /// The event can be used to print screen specific information in response to the event.
        /// </summary>
        public virtual void ProcessDebugClick()
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessDebugClick");
                currentScreen.ProcessDebugClick();
            }
        }

        /// <summary>
        /// The ProcessKeyPress method is used to send key press events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard press event.</param>
        /// <param name="code">A key code of the key event.</param>
        public virtual void ProcessKeyPress(char c, int code)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessKeyPress");
                currentScreen.ProcessKeyPress(c, code);
            }
        }

        /// <summary>
        /// The ProcessKeyRelease method is used to send key release events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard release event.</param>
        /// <param name="code">A key code of the key event.</param>
        public virtual void ProcessKeyRelease(char c, int code)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessKeyRelease");
                currentScreen.ProcessKeyRelease(c, code);
            }
        }

        /// <summary>
        /// The ProcessKeyClick method is used to send key click events to the MmgGameScreen class implementation, currentScreen.
        /// </summary>
        /// <param name="c">The c argument is the character of the keyboard click event.</param>
        /// <param name="code">A key code of the key event.</param>
        public virtual void ProcessKeyClick(char c, int code)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessKeyClick");
                currentScreen.ProcessKeyClick(c, code);
            }
        }

        /// <summary>
        /// The ProcessMouseMove method is used to send mouse move information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        public virtual void ProcessMouseMove(int x, int y)
        {
            if (currentScreen != null)
            {
                currentScreen.ProcessMouseMove((x - mouseOffsetX - myX), (y - mouseOffsetY - myY));
            }
        }

        /// <summary>
        /// The ProcessMousePress method is used to send mouse press information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        /// <param name="btnIndex">The button index of the mouse button event.</param>
        public virtual void ProcessMousePress(int x, int y, int btnIndex)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessMousePress");
                currentScreen.ProcessMousePress((x - mouseOffsetX - myX), (y - mouseOffsetY - myY), btnIndex);
            }
        }

        /// <summary>
        /// The ProcessMouseRelease method is used to send mouse release information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        /// <param name="btnIndex">The button index of the mouse button event.</param>
        public virtual void ProcessMouseRelease(int x, int y, int btnIndex)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessMouseRelease");
                currentScreen.ProcessMouseRelease((x - mouseOffsetX - myX), (y - mouseOffsetY - myY), btnIndex);
            }
        }

        /// <summary>
        /// The ProcessMouseClick method is used to send mouse click information to the MmgGameScreen class implementation, currentScreen.
        /// The coordinates are automatically adjusted to the offset of the game screen within the game panel.An optional mouseOffset is applied
        /// to the mouse X, Y coordinates.
        /// </summary>
        /// <param name="x">The x argument is the X position of the mouse as received from the mouse listener.</param>
        /// <param name="y">The y argument is the Y position of the mouse as received from the mouse listener.</param>
        /// <param name="btnIndex">The button index of the mouse button event.</param>
        public virtual void ProcessMouseClick(int x, int y, int btnIndex)
        {
            if (currentScreen != null)
            {
                MmgHelper.wr("ProcessMouseClick");
                currentScreen.ProcessMouseClick((x - mouseOffsetX - myX), (y - mouseOffsetY - myY), btnIndex);
            }
        }

        /// <summary>
        /// The PrepBuffers method is used to create a new buffered image, background. It also sets the canvas
        /// buffer strategy to use double buffering.The drawing strategy is stored in the strategy class field.
        /// Lastly the backgroundGraphics class field is set from the background buffered image.
        /// </summary>
        public virtual void PrepBuffers()
        {
            // Background & Buffer
            background = create(winWidth, winHeight, false);
            backgroundGraphics = new SpriteBatch(MmgScreenData.GRAPHICS_CONFIG);
            MmgScreenData.GRAPHICS_CONFIG.SetRenderTarget(background);
            p.SetGraphics(backgroundGraphics);
            p.SetAdvRenderHints();
        }

        /// <summary>
        /// Create a BufferedImage using the default screen device and configuration.
        /// </summary>
        /// <param name="width">The desired width of the BufferedImage.</param>
        /// <param name="height">The desired height of the BufferedImage.</param>
        /// <param name="alpha">The desired transparency flag of the BufferedImage.</param>
        /// <returns>Returns a BufferedImage with the desired coordinates and transparency. </returns>
        public virtual RenderTarget2D create(int width, int height, bool alpha)
        {
            return new RenderTarget2D(MmgScreenData.GRAPHICS_CONFIG, width, height);
        }

        /// <summary>
        /// Gets the game screen Dictionary.
        /// </summary>
        /// <returns>A Dictionary of game screens, MmgGameScreen.</returns>
        public virtual Dictionary<GameStates, MmgGameScreen> GetGameScreens()
        {
            return gameScreens;
        }

        /// <summary>
        /// Sets the game screen Dictionary.
        /// </summary>
        /// <param name="GameScreens">A Dictionary of game screens, MmgGameScreen.</param>
        public virtual void SetGameScreens(Dictionary<GameStates, MmgGameScreen> GameScreens)
        {
            gameScreens = GameScreens;
        }

        /// <summary>
        /// Gets the Canvas instance for drawing on the JFrame.
        /// </summary>
        /// <returns>The Canvas class instance for drawing on the JFrame.</returns>
        public virtual GameWindow GetCanvas()
        {
            return base.Window;
        }

        /// <summary>
        /// Gets the current game screen.
        /// </summary>
        /// <returns>A game screen object, MmgGameScreen.</returns>
        public virtual MmgGameScreen GetCurrentScreen()
        {
            return currentScreen;
        }

        /// <summary>
        /// Sets the current game screen.
        /// </summary>
        /// <param name="CurrentScreen">A game screen object.</param>
        public virtual void SetCurrentScreen(MmgGameScreen CurrentScreen)
        {
            currentScreen = CurrentScreen;
        }

        /// <summary>
        /// Switches the current game state, cleans up the current state, then loads
        /// up the next state.Currently does not use the gameScreens hash table.
        /// Uses direct references instead, for now.
        /// </summary>
        /// <param name="g">The game state to switch to.</param>
        public virtual void SwitchGameState(GameStates g)
        {
            MmgHelper.wr("GamePanel: Switching Game State To: " + g);

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
            else if (prevGameState == GameStates.LOADING)
            {
                MmgHelper.wr("Hiding LOADING screen.");
                screenLoading.Pause();
                screenLoading.SetIsVisible(false);
                screenLoading.UnloadResources();
                MmgHelper.wr("Hiding LOADING screen DONE.");

            }
            else if (prevGameState == GameStates.SPLASH)
            {
                MmgHelper.wr("Hiding SPLASH screen.");
                screenSplash.Pause();
                screenSplash.SetIsVisible(false);
                screenSplash.UnloadResources();

            }
            else if (prevGameState == GameStates.MAIN_MENU)
            {
                MmgHelper.wr("Hiding MAIN_MENU screen.");
                screenMainMenu.Pause();
                screenMainMenu.SetIsVisible(false);
                screenMainMenu.UnloadResources();

            }
            else if (prevGameState == GameStates.ABOUT)
            {
                MmgHelper.wr("Hiding ABOUT screen.");
                //aboutScreen.Pause();
                //aboutScreen.SetIsVisible(false);
                //aboutScreen.UnloadResources();

            }
            else if (prevGameState == GameStates.HELP_MENU)
            {
                MmgHelper.wr("Hiding HELP screen.");
                //helpScreen.Pause();
                //helpScreen.SetIsVisible(false);
                //helpScreen.UnloadResources();

            }
            else if (prevGameState == GameStates.MAIN_GAME)
            {
                MmgHelper.wr("Hiding MAIN GAME screen.");
                //screenMainMenu.Pause();
                //screenMainMenu.SetIsVisible(false);
                //screenMainMenu.UnloadResources();

            }
            else if (prevGameState == GameStates.SETTINGS)
            {
                MmgHelper.wr("Hiding SETTINGS screen.");
                //settingsScreen.Pause();
                //settingsScreen.SetIsVisible(false);
                //settingsScreen.UnloadResources();

            }

            //load
            MmgHelper.wr("Switching Game State To: " + gameState);
            if (gameState == GameStates.BLANK)
            {
                MmgHelper.wr("Showing BLANK screen.");

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
            else if (gameState == GameStates.SPLASH)
            {
                MmgHelper.wr("Showing SPLASH screen.");
                screenSplash.LoadResources();
                screenSplash.UnPause();
                screenSplash.SetIsVisible(true);
                screenSplash.StartDisplay();
                currentScreen = screenSplash;

            }
            else if (gameState == GameStates.MAIN_MENU)
            {
                MmgHelper.wr("Showing MAIN_MENU screen.");
                screenMainMenu.LoadResources();
                screenMainMenu.UnPause();
                screenMainMenu.SetIsVisible(true);
                currentScreen = screenMainMenu;

            }
            else if (gameState == GameStates.ABOUT)
            {
                MmgHelper.wr("Showing ABOUT screen.");
                //aboutScreen.LoadResources();
                //aboutScreen.UnPause();
                //aboutScreen.SetIsVisible(true);
                //currentScreen = aboutScreen;

            }
            else if (gameState == GameStates.HELP_MENU)
            {
                MmgHelper.wr("Showing HELP screen.");
                //helpScreen.LoadResources();
                //helpScreen.UnPause();
                //helpScreen.SetIsVisible(true);
                //currentScreen = helpScreen;

            }
            else if (gameState == GameStates.MAIN_GAME)
            {
                MmgHelper.wr("Showing MAIN GAME screen.");
                //mainGameScreen.LoadResources();
                //mainGameScreen.UnPause();
                //mainGameScreen.SetIsVisible(true);
                //currentScreen = mainGameScreen;

            }
            else if (gameState == GameStates.SETTINGS)
            {
                MmgHelper.wr("Showing SETTINGS screen.");
                //settingsScreen.LoadResources();
                //settingsScreen.UnPause();
                //settingsScreen.SetIsVisible(true);
                //currentScreen = settingsScreen;

            }
        }

        /// <summary>
        /// A generic event, GenericEventHandler, callback method. Used to handle
        /// generic events from certain game screens, MmgGameScreen.
        /// </summary>
        /// <param name="obj">A GenericEventMessage instance that has information about the generic event that was fired.</param>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("GamePanel: HandleGenericEvent");
            if (obj != null)
            {
                if (obj.GetGameState() == GameStates.LOADING)
                {
                    if (obj.GetId() == ScreenLoading.EVENT_LOAD_COMPLETE)
                    {
                        //Final loading steps
                        DatExternalStrings.LOAD_EXT_STRINGS();
                        MmgHelper.wr("HandleMainMenuEvent: MmgHandleEvent: Switch to MainMenu.");
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

        /// <summary>
        /// Returns a Graphics2D instance that is based on the default screen configuration used for drawing on the JFrame.
        /// </summary>
        /// <returns>A Graphics2D instance that is used to draw on the JFrame.</returns>
        public virtual SpriteBatch GetBuffer()
        {
            return graphics;
        }

        /// <summary>
        /// Returns the application window width.
        /// </summary>
        /// <returns>The application window width.</returns>
        public virtual int GetWinWidth()
        {
            return winWidth;
        }

        /// <summary>
        /// Returns the application window height.
        /// </summary>
        /// <returns>The application window height.</returns>
        public virtual int GetWinHeight()
        {
            return winHeight;
        }

        /// <summary>
        /// Returns the X offset of the GamePanel in the JFrame window.
        /// </summary>
        /// <returns>The X offset of the GamePanel in the JFrame window.</returns>
        public virtual int GetX()
        {
            return myX;
        }

        /// <summary>
        /// Returns the Y offset of the GamePanel in the JFrame window.
        /// </summary>
        /// <returns>The Y offset of the GamePanel in the JFrame window.</returns>
        public virtual int GetY()
        {
            return myY;
        }

        /// <summary>
        /// Updates the Java rendering API Graphics2D instances with the current Canvas buffer.
        /// Resetting the graphics class field and syncing the Canvas drawing strategy is necessary with
        /// a double buffered implementation.
        ///
        /// @return      A bool indicating if the method call was successful.Returns true in the case of a sync exception.
        /// </summary>
        /// <returns>A boolean indicating if the operation was a success. Always returns true in the Monogame port of the game engine.</returns>
        public virtual bool UpdateScreen()
        {
            //NOTE: Monogame port doesn't need this function but it is included for compatability with the Java version.
            return true;
        }

        /// <summary>
        /// The Monogame rendering routine update handler.
        /// </summary>
        /// <param name="gameTime">The current game time of the Update method call.</param>
        protected override void Update(GameTime gameTime)
        {
            if(EXIT == true)
            {
                Exit();
            }
            else if (PAUSE == true)
            {
                return;
            }

            UpdateGame();
            base.Update(gameTime);
        }

        /// <summary>
        /// A method to determine if the specified key has been clicked.
        /// </summary>
        /// <param name="key">The key to check for the click event.</param>
        /// <returns>A boolean indicating if the specified key has been clicked.</returns>
        private bool HasKeyBeenClicked(Keys key, KeyboardState state)
        {
            if (state.IsKeyDown(key))
            {
                //key down
                if (!keysDown.Contains((int)key))
                {
                    MmgHelper.wr("HasKeyBeenPressed: True Key: " + key.ToString() + " KeyDown: " + state.IsKeyDown(key));
                    keysDown.Add((int)key);
                }
                return false;
            }
            else
            {
                //key up
                if (keysDown.Contains((int)key))
                {
                    keysDown.Remove((int)key);
                    MmgHelper.wr("HasKeyBeenReleased: True Key: " + key.ToString());
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A method to determine if the specified mouse button has been clicked.
        /// </summary>
        /// <param name="bState">The previous state of the mouse buttons.</param>
        /// <param name="mState">The current state of the mouse buttons.</param>
        /// <returns>A boolean indicating if the mouse button has been clicked.</returns>
        private bool HasButtonBeenClicked(ButtonState bState, MouseState mState, string key)
        {
            if (bState == ButtonState.Pressed)
            {
                //button down
                if (!buttonsDown.Contains(key))
                {
                    buttonsDown.Add(key);
                }
                return false;
            }
            else
            {
                //button up
                if (buttonsDown.Contains(key))
                {
                    buttonsDown.Remove(key);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A method to convert Monogame key codes to characters.
        /// </summary>
        /// <param name="k">The Monogame key code.</param>
        /// <returns>A new KeyMap instance with the character, key code, and extended key code set.</returns>
        private KeyMap ConvertKeyToChar(Keys k)
        {
            if (k == Keys.Escape)
            {
                return new KeyMap((char)((byte)27), 27, 27);
            }
            else if(k == Keys.F1)
            {
                return new KeyMap((char)((byte)112), 112, 112);
            }
            else if (k == Keys.F2)
            {
                return new KeyMap((char)((byte)113), 113, 113);
            }
            else if (k == Keys.F3)
            {
                return new KeyMap((char)((byte)114), 114, 114);
            }
            else if (k == Keys.F4)
            {
                return new KeyMap((char)((byte)115), 115, 115);
            }
            else if (k == Keys.F5)
            {
                return new KeyMap((char)((byte)116), 116, 116);
            }
            else if (k == Keys.F6)
            {
                return new KeyMap((char)((byte)117), 117, 117);
            }
            else if (k == Keys.F7)
            {
                return new KeyMap((char)((byte)118), 118, 118);
            }
            else if (k == Keys.F8)
            {
                return new KeyMap((char)((byte)119), 119, 119);
            }
            else if (k == Keys.F9)
            {
                return new KeyMap((char)((byte)120), 120, 120);
            }
            else if (k == Keys.F10)
            {
                return new KeyMap((char)((byte)121), 121, 121);
            }
            else if (k == Keys.F11)
            {
                return new KeyMap((char)((byte)122), 122, 122);
            }
            else if (k == Keys.F12)
            {
                return new KeyMap((char)((byte)123), 123, 123);
            }
            else if (k == Keys.OemTilde)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('`', 192, 192);
                }
                else
                {
                    return new KeyMap('~', 192, 16777342);
                }
            }
            else if (k == Keys.NumPad1)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('1', 49, 49);
                }
                else
                {
                    return new KeyMap('!', 49, 517);
                }
            }
            else if (k == Keys.NumPad2)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('2', 50, 50);
                }
                else
                {
                    return new KeyMap('@', 50, 512);
                }
            }
            else if (k == Keys.NumPad3)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('3', 51, 51);
                }
                else
                {
                    return new KeyMap('#', 51, 520);
                }
            }
            else if (k == Keys.NumPad4)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('4', 52, 52);
                }
                else
                {
                    return new KeyMap('$', 52, 515);
                }
            }
            else if (k == Keys.NumPad5)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('5', 53, 53);
                }
                else
                {
                    return new KeyMap('%', 53, 0);
                }
            }
            else if (k == Keys.NumPad6)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('6', 54, 54);
                }
                else
                {
                    return new KeyMap('^', 54, 514);
                }
            }
            else if (k == Keys.NumPad7)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('7', 55, 55);
                }
                else
                {
                    return new KeyMap('&', 55, 150);
                }
            }
            else if (k == Keys.NumPad8)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('8', 56, 56);
                }
                else
                {
                    return new KeyMap('*', 56, 151);
                }
            }
            else if (k == Keys.NumPad9)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('9', 57, 57);
                }
                else
                {
                    return new KeyMap('(', 57, 519);
                }
            }
            else if (k == Keys.NumPad0)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('0', 48, 48);
                }
                else
                {
                    return new KeyMap(')', 48, 522);
                }
            }
            else if (k == Keys.OemMinus)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('-', 45, 45);
                }
                else
                {
                    return new KeyMap('_', 45, 523);
                }
            }
            else if (k == Keys.Add)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('+', 61, 521);
                }
                else
                {
                    return new KeyMap('=', 61, 61);
                }
            }
            else if (k == Keys.Delete)
            {
                return new KeyMap((char)((byte)8), 8, 8);
            }
            else if (k == Keys.Tab)
            {
                return new KeyMap((char)((byte)9), 9, 9);
            }
            else if (k == Keys.Q)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('q', 81, 81);
                }
                else
                {
                    return new KeyMap('Q', 81, 81);
                }
            }
            else if (k == Keys.W)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('w', 87, 87);
                }
                else
                {
                    return new KeyMap('Q', 87, 87);
                }
            }
            else if (k == Keys.E)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('e', 69, 69);
                }
                else
                {
                    return new KeyMap('E', 69, 69);
                }
            }
            else if (k == Keys.R)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('r', 82, 82);
                }
                else
                {
                    return new KeyMap('R', 82, 82);
                }
            }
            else if (k == Keys.T)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('t', 84, 84);
                }
                else
                {
                    return new KeyMap('T', 84, 84);
                }
            }
            else if (k == Keys.Y)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('y', 89, 89);
                }
                else
                {
                    return new KeyMap('Y', 89, 89);
                }
            }
            else if (k == Keys.U)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('u', 85, 85);
                }
                else
                {
                    return new KeyMap('U', 85, 85);
                }
            }
            else if (k == Keys.I)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('i', 73, 73);
                }
                else
                {
                    return new KeyMap('I', 73, 73);
                }
            }
            else if (k == Keys.O)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('o', 79, 79);
                }
                else
                {
                    return new KeyMap('O', 79, 79);
                }
            }
            else if (k == Keys.P)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('p', 80, 80);
                }
                else
                {
                    return new KeyMap('P', 80, 80);
                }
            }
            else if (k == Keys.OemOpenBrackets)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('[', 91, 91);
                }
                else
                {
                    return new KeyMap('{', 91, 161);
                }
            }
            else if (k == Keys.OemCloseBrackets)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap(']', 93, 93);
                }
                else
                {
                    return new KeyMap('}', 93, 162);
                }
            }
            else if (k == Keys.OemBackslash)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('\\', 92, 92);
                }
                else
                {
                    return new KeyMap('|', 92, 16777340);
                }
            }
            else if (k == Keys.CapsLock)
            {
                return new KeyMap((char)((byte)20), 20, 20);
            }
            else if (k == Keys.A)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('a', 65, 65);
                }
                else
                {
                    return new KeyMap('A', 65, 65);
                }
            }
            else if (k == Keys.S)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('s', 83, 83);
                }
                else
                {
                    return new KeyMap('S', 83, 83);
                }
            }
            else if (k == Keys.D)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('d', 68, 68);
                }
                else
                {
                    return new KeyMap('D', 68, 68);
                }
            }
            else if (k == Keys.F)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('f', 70, 70);
                }
                else
                {
                    return new KeyMap('F', 70, 70);
                }
            }
            else if (k == Keys.G)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('g', 71, 71);
                }
                else
                {
                    return new KeyMap('G', 71, 71);
                }
            }
            else if (k == Keys.H)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('h', 72, 72);
                }
                else
                {
                    return new KeyMap('H', 72, 72);
                }
            }
            else if (k == Keys.J)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('j', 74, 74);
                }
                else
                {
                    return new KeyMap('J', 74, 74);
                }
            }
            else if (k == Keys.K)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('k', 75, 75);
                }
                else
                {
                    return new KeyMap('K', 75, 75);
                }
            }
            else if (k == Keys.L)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('l', 76, 76);
                }
                else
                {
                    return new KeyMap('L', 76, 76);
                }
            }
            else if (k == Keys.OemSemicolon)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap(';', 59, 59);
                }
                else
                {
                    return new KeyMap(':', 59, 513);
                }
            }
            else if (k == Keys.OemQuotes)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('\'', 222, 222);
                }
                else
                {
                    return new KeyMap('"', 222, 152);
                }
            }
            else if(k == Keys.Enter)
            {
                return new KeyMap('\n', 10, 10);
            }
            else if (k == Keys.LeftShift || k == Keys.RightShift)
            {
                return new KeyMap((char)((byte)16), 16, 16);
            }
            else if (k == Keys.Z)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('z', 90, 90);
                }
                else
                {
                    return new KeyMap('Z', 90, 90);
                }
            }
            else if (k == Keys.X)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('x', 88, 88);
                }
                else
                {
                    return new KeyMap('X', 88, 88);
                }
            }
            else if (k == Keys.C)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('c', 67, 67);
                }
                else
                {
                    return new KeyMap('C', 67, 67);
                }
            }
            else if (k == Keys.V)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('v', 86, 86);
                }
                else
                {
                    return new KeyMap('V', 86, 86);
                }
            }
            else if (k == Keys.B)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('b', 66, 66);
                }
                else
                {
                    return new KeyMap('B', 66, 66);
                }
            }
            else if (k == Keys.N)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('n', 78, 78);
                }
                else
                {
                    return new KeyMap('N', 78, 78);
                }
            }
            else if (k == Keys.M)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('m', 77, 77);
                }
                else
                {
                    return new KeyMap('M', 77, 77);
                }
            }
            else if(k == Keys.OemComma)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap(',', 44, 44);
                }
                else
                {
                    return new KeyMap('<', 44, 153);
                }
            }
            else if (k == Keys.OemPeriod)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('.', 46, 46);
                }
                else
                {
                    return new KeyMap('>', 46, 160);
                }
            }
            else if (k == Keys.OemQuestion)
            {
                if (!keyShiftDown)
                {
                    return new KeyMap('/', 47, 47);
                }
                else
                {
                    return new KeyMap('?', 47, 0);
                }
            }
            else if(k == Keys.LeftControl || k == Keys.RightControl)
            {
                return new KeyMap((char)((byte)17), 17, 17);
            }
            else if (k == Keys.LeftAlt || k == Keys.RightAlt)
            {
                return new KeyMap((char)((byte)18), 18, 18);
            }
            else if(k == Keys.LeftWindows || k == Keys.RightWindows)
            {
                return new KeyMap((char)((byte)157), 157, 157);
            }
            else if(k == Keys.Space)
            {
                return new KeyMap(' ', 32, 32);
            }
            else if(k == Keys.Up)
            {
                return new KeyMap((char)((byte)38), 38, 38);
            }
            else if (k == Keys.Down)
            {
                return new KeyMap((char)((byte)40), 40, 40);
            }
            else if (k == Keys.Left)
            {
                return new KeyMap((char)((byte)37), 37, 37);
            }
            else if (k == Keys.Right)
            {
                return new KeyMap((char)((byte)39), 39, 39);
            }

            return null;
        }

        //NOTE: Monogame specific implementation to mimic the Java versions input events.
        /// <summary>
        /// Processes all player one input and redirects it to the current game screen.
        /// </summary>
        private void ProcessAllPlayer1Input()
        {
            statePrevM = stateM;
            stateM = Mouse.GetState();

            //handle mouse drag
            if (stateM.LeftButton == ButtonState.Pressed && statePrevM.LeftButton == ButtonState.Pressed)
            {
                lastX = stateM.X;
                lastY = stateM.Y;
            }

            if (stateM.X != statePrevM.X || stateM.Y != statePrevM.Y)
            {
                lastX = stateM.X;
                lastY = stateM.Y;
                ProcessMouseMove(lastX, lastY);
            }

            //handle key typed
            statePrevK = stateK;
            stateK = Keyboard.GetState();

            if(HasKeyBeenClicked(Keys.CapsLock, stateK))
            {
                keyCapsLockOn = !keyCapsLockOn;
            }

            if(stateK.IsKeyDown(Keys.LeftShift) || stateK.IsKeyDown(Keys.RightShift))
            {
                keyShiftDown = true;
            }
            else if(stateK.IsKeyUp(Keys.LeftShift) && stateK.IsKeyUp(Keys.RightShift))
            {
                keyShiftDown = false;
            }

            //handle key pressed
            if(stateK.GetPressedKeyCount() > 0)
            {
                lastKeyPressEvent = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }

            KeyMap c;
            foreach (Keys k in stateK.GetPressedKeys())
            {
                c = ConvertKeyToChar(k);
                HasKeyBeenClicked(k, stateK);

                if (c == null)
                {
                    MmgHelper.wrErr("Error: Could not find KeyMap for key, " + k + ".");
                    continue;
                }

                if (k != Keys.Space && k != Keys.Enter)
                {
                    if (k == Keys.Up)
                    {
                        ProcessDpadPress(GameSettings.UP_KEYBOARD);
                    }
                    else if (k == Keys.Down)
                    {
                        ProcessDpadPress(GameSettings.DOWN_KEYBOARD);
                    }
                    else if (k == Keys.Left)
                    {
                        ProcessDpadPress(GameSettings.LEFT_KEYBOARD);
                    }
                    else if (k == Keys.Right)
                    {
                        ProcessDpadPress(GameSettings.RIGHT_KEYBOARD);
                    }
                    else if (k == Keys.A)
                    {
                        ProcessAPress(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.B)
                    {
                        ProcessBPress(GameSettings.SRC_KEYBOARD);
                    }

                    if (GameSettings.INPUT_NORMALIZE_KEY_CODE)
                    {
                        ProcessKeyPress(c.c, MmgHelper.NormalizeKeyCode(c.c, c.code, c.extCode, "c_sharp"));
                    }
                    else
                    {
                        ProcessKeyPress(c.c, c.extCode);
                    }
                }
                else if (k == Keys.Space)
                {
                    ProcessAPress(GameSettings.SRC_KEYBOARD);
                    ProcessKeyPress(' ', 32);
                }
                else if (k == Keys.Enter)
                {
                    ProcessAPress(GameSettings.SRC_KEYBOARD);
                    ProcessKeyPress(' ', 10);
                }
            }

            foreach (Keys k in keysDown.ToArray())
            {
                c = ConvertKeyToChar(k);

                if (c == null)
                {
                    MmgHelper.wrErr("Error: Could not find KeyMap for key, " + k + ".");
                    continue;
                }

                if (HasKeyBeenClicked(k, stateK))
                {
                    //Click Section
                    if (k == Keys.Up)
                    {
                        ProcessDpadClick(GameSettings.UP_KEYBOARD);
                    }
                    else if (k == Keys.Down)
                    {
                        ProcessDpadClick(GameSettings.DOWN_KEYBOARD);
                    }
                    else if (k == Keys.Left)
                    {
                        ProcessDpadClick(GameSettings.LEFT_KEYBOARD);
                    }
                    else if (k == Keys.Right)
                    {
                        ProcessDpadClick(GameSettings.RIGHT_KEYBOARD);
                    }
                    else if (k == Keys.A)
                    {
                        ProcessAClick(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.B)
                    {
                        ProcessBClick(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.D)
                    {
                        ProcessDebugClick();
                    }
                    else if (k == Keys.Space)
                    {
                        ProcessAClick(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.Enter)
                    {
                        ProcessAClick(GameSettings.SRC_KEYBOARD);
                    }

                    if (GameSettings.INPUT_NORMALIZE_KEY_CODE)
                    {
                        ProcessKeyClick(c.c, MmgHelper.NormalizeKeyCode(c.c, c.code, c.extCode, "c_sharp"));
                    }
                    else
                    {
                        ProcessKeyClick(c.c, c.extCode);
                    }

                    if (k == Keys.Up)
                    {
                        ProcessDpadRelease(GameSettings.UP_KEYBOARD);
                    }
                    else if (k == Keys.Down)
                    {
                        ProcessDpadRelease(GameSettings.DOWN_KEYBOARD);
                    }
                    else if (k == Keys.Left)
                    {
                        ProcessDpadRelease(GameSettings.LEFT_KEYBOARD);
                    }
                    else if (k == Keys.Right)
                    {
                        ProcessDpadRelease(GameSettings.RIGHT_KEYBOARD);
                    }
                    else if (k == Keys.A)
                    {
                        ProcessARelease(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.B)
                    {
                        ProcessBRelease(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.D)
                    {

                    }
                    else if (k == Keys.Space)
                    {
                        ProcessARelease(GameSettings.SRC_KEYBOARD);
                    }
                    else if (k == Keys.Enter)
                    {
                        ProcessARelease(GameSettings.SRC_KEYBOARD);
                    }

                    if (GameSettings.INPUT_NORMALIZE_KEY_CODE)
                    {
                        ProcessKeyRelease(c.c, MmgHelper.NormalizeKeyCode(c.c, c.code, c.extCode, "c_sharp"));
                    }
                    else
                    {
                        ProcessKeyRelease(c.c, c.extCode);
                    }
                }
            }

            if(stateM.LeftButton == ButtonState.Pressed)
            {
                ProcessMousePress(stateM.X, stateM.Y, 1);
            }
            else if (stateM.MiddleButton == ButtonState.Pressed)
            {
                ProcessMousePress(stateM.X, stateM.Y, 2);
            }
            else if (stateM.RightButton == ButtonState.Pressed)
            {
                ProcessMousePress(stateM.X, stateM.Y, 3);
            }

            if (HasButtonBeenClicked(stateM.LeftButton, stateM, "LeftButton"))
            {
                ProcessMouseClick(stateM.X, stateM.Y, 1);
                ProcessMouseRelease(stateM.X, stateM.Y, 1);
            }

            if (HasButtonBeenClicked(stateM.MiddleButton, stateM, "MiddleButton"))
            {
                ProcessMouseClick(stateM.X, stateM.Y, 2);
                ProcessMouseRelease(stateM.X, stateM.Y, 2);
            }

            if (HasButtonBeenClicked(stateM.RightButton, stateM, "RightButton"))
            {
                ProcessMouseClick(stateM.X, stateM.Y, 3);
                ProcessMouseRelease(stateM.X, stateM.Y, 3);
            }
        }

        /// <summary>
        /// The Monogame rendering routine draw call.
        /// </summary>
        /// <param name="gameTime">The current game time the Draw method was called.</param>
        protected override void Draw(GameTime gameTime)
        {
            if(EXIT == true)
            {
                return;
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);
            RenderGame();            
            base.Draw(gameTime);
        }

        /// <summary>
        /// A support method used to boot strap unit testing to the game's startup process.
        /// Because the unit tests need the Monogame screen context that only exists after the game is initialized
        /// we have to run the tests after the resource loading process.
        /// </summary>
        private void RunTests()
        {
            MmgApiTestSuite tests = new MmgApiTestSuite();
            tests.runTestSuite();
            runningTests = false;
            GameSettings.RUN_UNIT_TESTS = false;
            SwitchGameState(GameStates.SPLASH);
        }

        /// <summary>
        /// Sets the display text of the frame rate label.
        /// </summary>
        /// <param name="fr">A long representing the current drawing frame rate, or the frame rate if no time lock is applied.</param>
        /// <param name="rfr">A long representing the locked frame rate.</param>
        public void SetFrameRate(long fr, long rfr)
        {
            if (canvas != null)
            {
                FPS = "Drawing FPS: " + fr + " Actual FPS: " + rfr;
            }
        }

        /// <summary>
        /// The UpdateGame method is used to call the lower level MmgUpdate method of the MmgGameScreen class, currentScreen.
        /// Send the update call count, the current time, and the time difference between this frame and the last frame.
        /// </summary>
        public virtual void UpdateGame()
        {
            frameStart = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            updateTick++;

            if (PAUSE == true || EXIT == true)
            {
                //do nothing
                return;
            }

            prev = now;
            now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            if (GameSettings.RUN_UNIT_TESTS && runningTests == false )
            {
                runningTests = true;
                RunTests();
            }
            else
            {
                if (GameSettings.GAMEPAD_1_ON && GameSettings.GAMEPAD_1_THREADED_POLLING == false)
                {
                    gamePadRunner.PollGamePad();
                }

                if (GameSettings.GPIO_GAMEPAD_ON && GameSettings.GPIO_GAMEPAD_THREADED_POLLING == false)
                {
                    gpioRunner.PollGpio();
                }

                ProcessAllPlayer1Input();

                // update game logic here
                if (currentScreen != null)
                {
                    currentScreen.MmgUpdate(updateTick, now, (now - prev));
                }
            }
        }

        /// <summary>
        /// The RenderGame method is used to draw the entire JFrame Canvas, the debug frame rate, the debug variables, and the game screen.
        /// </summary>
        public virtual void RenderGame()
        {
            if (visible == false)
            {
                return;
            }
            
            if (EXIT == true)
            {
                return;
            }

            //update graphics
            bg = GetBuffer();
            g = backgroundGraphics;

            if (currentScreen == null || currentScreen.IsPaused() == true || currentScreen.IsReady() == false)
            {
                //do nothing
            }
            else
            {
                g.GraphicsDevice.SetRenderTarget(background);
                p.SetGraphics(g);
                p.SetAdvRenderHints();
                g.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

                if (GameSettings.RUN_UNIT_TESTS)
                {
                    //clear background
                    g.GraphicsDevice.Clear(DarkGray);
                    g.Draw(sqrBlack.GetImage(), new Rectangle(0, 0, winWidth, 60), Color.White);
                    g.DrawString(debugFont, "Running Unit Tests...", new Vector2(15, 15 - mmgDebugFont.GetHeight() + 2), Color.White);
                }
                else
                {
                    //clear background
                    g.GraphicsDevice.Clear(DarkGray);
                    g.Draw(sqrWhite.GetImage(), new Rectangle(MmgScreenData.GetGameLeft() - 1, MmgScreenData.GetGameTop() - 1, MmgScreenData.GetGameWidth() + 2, MmgScreenData.GetGameHeight() + 2), new Rectangle(0, 0, sqrWhite.GetWidth(), sqrWhite.GetHeight()), Color.White);
                    g.Draw(sqrBlack.GetImage(), new Rectangle(MmgScreenData.GetGameLeft(), MmgScreenData.GetGameTop(), MmgScreenData.GetGameWidth(), MmgScreenData.GetGameHeight()), new Rectangle(0, 0, sqrBlack.GetWidth(), sqrBlack.GetHeight()), Color.White);

                    currentScreen.MmgDraw(p);

                    if (MmgHelper.LOGGING == true)
                    {
                        g.Draw(sqrBlack.GetImage(), new Rectangle(0, 0, winWidth, 60), Color.White);
                        g.DrawString(debugFont, GamePanel.FPS, new Vector2(15, 15 - mmgDebugFont.GetHeight() + 2), Color.White);
                        g.DrawString(debugFont, "Var1: " + GamePanel.VAR1, new Vector2(15, 35 - mmgDebugFont.GetHeight() + 2), Color.White);
                        g.DrawString(debugFont, "Var2: " + GamePanel.VAR2, new Vector2(15, 55 - mmgDebugFont.GetHeight() + 2), Color.White);
                    }
                }
                g.End();
                g.GraphicsDevice.SetRenderTarget(null);
            }
            
            bg.GraphicsDevice.SetRenderTarget(null);
            p.SetGraphics(bg);
            p.SetAdvRenderHints();

            bg.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            //draws a scaled version of the state of the background buffer to the screen buffer if scaling is enabled
            if (scale != 1.0)
            {
                bg.Draw(background, new Rectangle(sMyX, sMyY, sWinWidth, sWinHeight), new Rectangle(0, 0, winWidth, winHeight), Color.White);
            }
            else
            {
                bg.Draw(background, new Vector2(myX, myY), Color.White);
                //bg.Draw(test.GetImage(), Vector2.One, Color.White);
            }
            bg.End();

            UpdateScreen();

            frameStop = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            frameTime = (frameStop - frameStart) + 1;
            aFps = (1000 / frameTime);
       
            //frameStop = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            //frameTime = (frameStop - frameStart) + 1;
            frameTime = (long)TargetElapsedTime.TotalMilliseconds + 1;
            rFps = (1000 / frameTime);
            SetFrameRate(aFps, rFps);
        }
    }
}
