package net.middlemind.MmgGameApiJava.MmgCore;

import java.awt.*;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.event.MouseMotionListener;
import java.awt.image.BufferStrategy;
import java.awt.image.BufferedImage;
import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;

/**
 * The Canvas used to render the game to. 
 * This is the connection point between native UI rendering and the game rendering.
 * Created by Middlemind Games 08/01/2015
 *
 * @author Victor G. Brusca
 */
@SuppressWarnings("UseOfObsoleteCollectionType")
public class GamePanel implements GenericEventHandler, GamePadSimple {

    /**
     * An enumeration that lists all of the game states.
     * Add new states here or use the general states, GAME_SCREEN_XX to control
     * what the game displays.
     */
    public enum GameStates {
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

    /**
     * The MainFrame that this panel is displayed in.
     */
    public MainFrame mf;

    /**
     * The width of the window this panel is displayed in.
     */
    public int winWidth;

    /**
     * The height of the window this panel is displayed in.
     */
    public int winHeight;

    /**
     * The X coordinate of this panel.
     */
    public int myX;

    /**
     * The Y coordinate of this panel.
     */
    public int myY;

    /**
     * The scaled width of the window this panel is displayed in.
     */
    public int sWinWidth;

    /**
     * The scaled height of the window this panel is displayed in.
     */
    public int sWinHeight;

    /**
     * The scaled X coordinate of this panel.
     */
    public int sMyX;

    /**
     * The scaled Y coordinate of this panel.
     */
    public int sMyY;

    /**
     * The target game width.
     */
    public static int GAME_WIDTH = 854;

    /**
     * The target game height.
     */
    public static int GAME_HEIGHT = 416;

    /**
     * Boolean that pauses the game.
     */
    public static boolean PAUSE = false;

    /**
     * Boolean that exits the game.
     */
    public static boolean EXIT = false;

    /**
     * The gameScreens field is a Hashtable that can be used to hold a reference to all game screens.
     */
    public Hashtable<GameStates, MmgGameScreen> gameScreens;

    /**
     * The current game screen being displayed.
     */
    public MmgGameScreen currentScreen;

    /**
     * An MmgPen class, used to draw Mmg API objects.
     */
    public MmgPen p;

    /**
     * An instance of the GameStates enumeration that holds the previous game state.
     */
    public GameStates prevGameState;

    /**
     * An instance of the GameStates enumeration that holds the current game state.
     */
    public GameStates gameState;

    /**
     * A static Hashtable instance that can be used to store objects for quick, easy access.
     */
    public static Hashtable<String, Object> VARS = new Hashtable<String, Object>();

    /**
     * A string used to store the current frame rate information in the debug header.
     */
    public static String FPS = "Drawing FPS: 0000 Actual FPS: 00";
    
    /**
     * A string used to write data to the debug header.
     */
    public static String VAR1 = "** EMPTY **";
    
    /**
     * A second string used to write data to the debug header.
     */
    public static String VAR2 = "** EMPTY **";

    /**
     * A canvas object used to draw to the JFrame.
     */
    public Canvas canvas;
    
    /**
     * A Java rendering API drawing strategy class.
     */
    public BufferStrategy strategy;
    
    /**
     * A BufferedImage used to render the game screen to. 
     * The background image is then rendered to the panel once it is done drawing.
     */
    public BufferedImage background;
    
    /**
     * A Java rendering API for drawing graphics to a BufferedImage.
     */
    public Graphics2D backgroundGraphics;
    
    /**
     * A Java rendering API for drawing graphics to the JFrame.
     */
    public Graphics2D graphics;
    
    /**
     * An optional scale value that will scale the background image before drawing it to the JFrame.
     */
    public double scale = 1.0;
    
    /**
     * An integer that records how many frames have been drawn. 
     * The updateTick class field is updated on each UpdateGame method call.
     */
    public int updateTick = 0;
    
    /**
     * A class field used to store the current time in ms for passing time information to the update method.
     */
    public long now;
    
    /**
     * A class field used to store the previous time in ms for passing time information to the update method.
     */
    public long prev;
    
    /**
     * A Java rendering API font class used to draw debugging information like the FPS, VAR1, and VAR2 class fields.
     */
    public Font debugFont;
    
    /**
     * The Java rendering API color that is used to draw the game debugging information.
     */
    public Color debugColor = Color.WHITE;
    
    /**
     * A place holder class field for storing the current font of the Java rendering API Pen class. 
     * Used to hold the Pen's current font, then sets the Pen's font for drawing debug information, then restoring the Pen's previous font. 
     */
    public Font tmpF;
    
    /**
     * An instance of the GameType enumeration that can be used to track if the game is a new game or a continuation of an existing game.
     */
    public static GameType GAME_TYPE = GameType.GAME_NEW;

    /**
     * An enumeration used to help track the type of game that was started.
     */
    public enum GameType {
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

    /**
     * A class field that tracks the last X position of the mouse during movement or dragging.
     */
    public int lastX;
    
    /**
     * A class field that tracks the last Y position of the mouse during movement or dragging.
     */    
    public int lastY;
    
    /**
     * A class field that tracks the last time in ms that a key was pressed. 
     */
    public long lastKeyPressEvent = -1;
    
    /**
     * A Java rendering API instance that is used to draw to the JFrame.
     */
    public Graphics2D bg;
    
    /**
     * A Java rendering API instance that is used to draw the game screen to a buffered image.
     */
    public Graphics2D g;
    
    /**
     * An instance of the ScreenSplash class that is used to draw the game's splash screen.
     */
    public ScreenSplash screenSplash;
    
    /**
     * An instance of the ScreenLoading class that is used to draw the game's loading screen.
     */
    public ScreenLoading screenLoading;
    
    /**
     * An instance of the ScreenMainMenu class that is used to draw the game's main menu screen.
     */
    public ScreenMainMenu screenMainMenu;
    
    /**
     * A class field that is used to add an offset into the mouse input X coordinate.
     */
    public int mouseOffsetX = 0;
    
    /**
     * A class field that is used to add an offset into the mouse input Y coordinate.
     */
    public int mouseOffsetY = 0;    
        
    /**
     * A class field that initializes a static class that holds screen size and position data.
     */
    public MmgScreenData screenData;
    
    /**
     * A class field that initializes a static class the holds font creation and size data. 
     */
    public MmgFontData fontData;
    
    /**
     * A GamePadHub instance used for processing USB gamepad input.
     */
    public GamePadHub gamePadHub;
    
    /**
     * A GamePadRunner instance used for polling gamepad input from the GamePadHub.
     */
    public GamePadHubRunner gamePadRunner;
    
    /**
     * A Thread used to process the USB gamepad input if threaded polling is enabled in the GameSettings class.
     */
    public Thread gpadTr;
    
    /**
     * A GpioPadHub instance used for processing GPIO gamepad input.
     */
    public GpioHub gpioHub;
    
    /**
     * A GpioPadRunner instance used for polling gamepad input from the GpioPadHub.
     */
    public GpioHubRunner gpioRunner;
    
    /**
     * A Thread used to process the GPIO gamepad input if threaded polling is enabled in the GameSettings class.
     */
    public Thread gpioTr;    
    
    /**
     * A helper variable used to hold a debug font.
     */
    private MmgFont mmgDebugFont = null;    
    
    /**
     * Constructor, sets the MainFrame, window dimensions, and position of this Canvas.
     *
     * @param Mf            The MainFrame class this panel belongs to.
     * @param WinWidth      The target window width.
     * @param WinHeight     The target window height.
     * @param X             The X coordinate of this Canvas.
     * @param Y             The Y coordinate of this Canvas.
     * @param GameWidth     The width of the game.
     * @param GameHeight    The height of the game.
     */
    @SuppressWarnings({"LeakingThisInConstructor", "OverridableMethodCallInConstructor"})
    public GamePanel(MainFrame Mf, int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight) {
        mf = Mf;
        winWidth = WinWidth;
        winHeight = WinHeight;
        GamePanel.GAME_WIDTH = GameWidth;
        GamePanel.GAME_HEIGHT = GameHeight;                        
        sWinWidth = (int) (winWidth * scale);
        sWinHeight = (int) (winHeight * scale);

        MmgHelper.wr("GamePanel: WinWidth: " + WinWidth);
        MmgHelper.wr("GamePanel: WinHeight: " + WinHeight);
        MmgHelper.wr("GamePanel: GameWidth: " + GameWidth);
        MmgHelper.wr("GamePanel: GameHeight: " + GameHeight);        
        
        myX = X;
        myY = Y;
        sMyX = myX + (winWidth - sWinWidth);
        sMyY = myY + (winHeight - sWinHeight);

        now = System.currentTimeMillis();
        prev = System.currentTimeMillis();

        canvas = new Canvas(MmgScreenData.GRAPHICS_CONFIG);
        canvas.setSize(winWidth, winHeight);

        MmgHelper.wr("");        
        MmgHelper.wr("GamePanel Window Width: " + winWidth);
        MmgHelper.wr("GamePanel Window Height: " + winHeight);
        MmgHelper.wr("GamePanel Offset X: " + myX);
        MmgHelper.wr("GamePanel Offset Y: " + myY);

        screenData = new MmgScreenData(winWidth, winHeight, GamePanel.GAME_WIDTH, GamePanel.GAME_HEIGHT);
        MmgHelper.wr("");
        MmgHelper.wr("--- MmgScreenData ---");
        MmgHelper.wr(MmgScreenData.ApiToString());

        fontData = new MmgFontData();
        MmgHelper.wr("");
        MmgHelper.wr("--- MmgFontData ---");
        MmgHelper.wr(MmgFontData.ApiToString());
        debugFont = MmgFontData.CreateDefaultFontSm();
        mmgDebugFont = new MmgFont(debugFont, "Test", 0, 0, MmgColor.GetWhite());

        MmgHelper.wr("FontHeight: " + mmgDebugFont.GetHeight() + ", " + MmgFontData.GetFontSize());        
        
        p = new MmgPen();
        MmgPen.ADV_RENDER_HINTS = true;
        
        screenSplash = new ScreenSplash(GameStates.SPLASH, this);
        screenLoading = new ScreenLoading(GameStates.LOADING, this);
        screenMainMenu = new ScreenMainMenu(GameStates.MAIN_MENU, this);        
        
        screenSplash.SetGenericEventHandler(this);
        screenLoading.SetGenericEventHandler(this);
        screenLoading.SetSlowDown(500);        
        
        gameScreens = new Hashtable<GameStates, MmgGameScreen>();
        gameState = GameStates.BLANK;

        canvas.addMouseMotionListener(new MouseMotionListener() {
            @Override
            public void mouseDragged(MouseEvent e) {
                lastX = e.getX();
                lastY = e.getY();
            }

            @Override
            public void mouseMoved(MouseEvent e) {
                lastX = e.getX();
                lastY = e.getY();
                ProcessMouseMove(lastX, lastY);
            }
        });

        canvas.addKeyListener(new KeyListener() {
            @Override
            public void keyTyped(KeyEvent e) {
                if (e.getKeyChar() == ' ' || e.getKeyChar() == '\n') {
                    ProcessAClick(GameSettings.SRC_KEYBOARD);
                    
                } else if (e.getKeyChar() == '+') {
                    //increase speed

                } else if (e.getKeyChar() == '-') {
                    //decrease speed

                } else if (e.getKeyChar() == 'p' || e.getKeyChar() == 'P') {
                    if (gameState == GameStates.MAIN_GAME) {
                        //pause game
                    }
                    
                } else if (e.getKeyChar() == 'f' || e.getKeyChar() == 'F') {  
                    //clear game flags
                    
                } else if (e.getKeyChar() == 'a' || e.getKeyChar() == 'A') {
                    ProcessAClick(GameSettings.SRC_KEYBOARD);
                    
                } else if (e.getKeyChar() == 'b' || e.getKeyChar() == 'B') {
                    ProcessBClick(GameSettings.SRC_KEYBOARD);
                    
                } else if (e.getKeyChar() == 'd' || e.getKeyChar() == 'D') {
                    ProcessDebugClick();
                    
                }
                
                if(GameSettings.INPUT_NORMALIZE_KEY_CODE) {
                    ProcessKeyClick(e.getKeyChar(), MmgHelper.NormalizeKeyCode(e.getKeyChar(), e.getKeyCode(), e.getExtendedKeyCode(), "java"));                    
                } else {
                    ProcessKeyClick(e.getKeyChar(), e.getExtendedKeyCode());
                }
            }

            @Override
            public void keyPressed(KeyEvent e) {
                //Ignore Enter and Space bar presses, handle them as A and B button clicks.
                lastKeyPressEvent = System.currentTimeMillis();
                if (e.getKeyCode() == 40) {
                    ProcessDpadPress(GameSettings.DOWN_KEYBOARD);

                } else if (e.getKeyCode() == 38) {
                    ProcessDpadPress(GameSettings.UP_KEYBOARD);

                } else if (e.getKeyCode() == 37) {
                    ProcessDpadPress(GameSettings.LEFT_KEYBOARD);

                } else if (e.getKeyCode() == 39) {
                    ProcessDpadPress(GameSettings.RIGHT_KEYBOARD);

                } else if (e.getKeyChar() == 'a' || e.getKeyChar() == 'A') {
                    ProcessAPress(GameSettings.SRC_KEYBOARD);

                } else if (e.getKeyChar() == 'b' || e.getKeyChar() == 'B') {
                    ProcessBPress(GameSettings.SRC_KEYBOARD);

                } else if (e.getKeyCode() == 32) {
                    ProcessAPress(GameSettings.SRC_KEYBOARD);                
                    
                } else if (e.getKeyCode() == 10) {
                    ProcessAPress(GameSettings.SRC_KEYBOARD);
                    
                }

                if(GameSettings.INPUT_NORMALIZE_KEY_CODE) {
                    ProcessKeyPress(e.getKeyChar(), MmgHelper.NormalizeKeyCode(e.getKeyChar(), e.getKeyCode(), e.getExtendedKeyCode(), "java"));                    
                } else {
                    ProcessKeyPress(e.getKeyChar(), e.getExtendedKeyCode());
                }
            }

            @Override
            public void keyReleased(KeyEvent e) {
                //Ignore Enter and Space bar releases, handle them as A and B button clicks.
                if (e.getKeyCode() == 40) {
                    ProcessDpadClick(GameSettings.DOWN_KEYBOARD);
                    ProcessKeyClick(e.getKeyChar(), 40);
                    ProcessDpadRelease(GameSettings.DOWN_KEYBOARD);


                } else if (e.getKeyCode() == 38) {
                    ProcessDpadClick(GameSettings.UP_KEYBOARD);
                    ProcessKeyClick(e.getKeyChar(), 38);
                    ProcessDpadRelease(GameSettings.UP_KEYBOARD);

                } else if (e.getKeyCode() == 37) {
                    ProcessDpadClick(GameSettings.LEFT_KEYBOARD);
                    ProcessKeyClick(e.getKeyChar(), 37);
                    ProcessDpadRelease(GameSettings.LEFT_KEYBOARD);                        

                } else if (e.getKeyCode() == 39) {
                    ProcessDpadClick(GameSettings.RIGHT_KEYBOARD);
                    ProcessKeyClick(e.getKeyChar(), 39);
                    ProcessDpadRelease(GameSettings.RIGHT_KEYBOARD);

                } else if (e.getKeyChar() == 'a' || e.getKeyChar() == 'A') {
                    ProcessARelease(GameSettings.SRC_KEYBOARD);

                } else if (e.getKeyChar() == 'b' || e.getKeyChar() == 'B') {
                    ProcessBRelease(GameSettings.SRC_KEYBOARD);

                } else if (e.getKeyCode() == 32) {
                    ProcessARelease(GameSettings.SRC_KEYBOARD);                
                    
                } else if (e.getKeyCode() == 10) {
                    ProcessARelease(GameSettings.SRC_KEYBOARD);
                    
                }                  

                if(GameSettings.INPUT_NORMALIZE_KEY_CODE) {
                    ProcessKeyRelease(e.getKeyChar(), MmgHelper.NormalizeKeyCode(e.getKeyChar(), e.getKeyCode(), e.getExtendedKeyCode(), "java"));                    
                } else {
                    ProcessKeyRelease(e.getKeyChar(), e.getExtendedKeyCode());
                }
            }
        });

        canvas.addMouseListener(new MouseListener() {
            @Override
            public void mouseClicked(MouseEvent e) {
                ProcessMouseRelease(e.getX(), e.getY(), e.getButton());
            }

            @Override
            public void mousePressed(MouseEvent e) {
                ProcessMousePress(e.getX(), e.getY(), e.getButton());
            }

            @Override
            public void mouseReleased(MouseEvent e) {
                ProcessMouseClick(e.getX(), e.getY(), e.getButton());
            }

            @Override
            public void mouseEntered(MouseEvent e) {
            }

            @Override
            public void mouseExited(MouseEvent e) {
            }

        });
    
        if(GameSettings.GAMEPAD_1_ON) {
            gamePadHub = new GamePadHub(GameSettings.GAMEPAD_1_INDEX);
            gamePadRunner = new GamePadHubRunner(gamePadHub, GameSettings.GAMEPAD_1_POLLING_INTERVAL_MS, this);
            if(GameSettings.GAMEPAD_1_THREADED_POLLING) {
                gpadTr = new Thread(gamePadRunner);
                gpadTr.start();
            }
        }
        
        if(GameSettings.GPIO_GAMEPAD_ON) {
            gpioHub = new GpioHub();
            gpioRunner = new GpioHubRunner(gpioHub, GameSettings.GPIO_GAMEPAD_POLLING_INTERVAL_MS, this);
            if(GameSettings.GPIO_GAMEPAD_THREADED_POLLING) {
                gpioTr = new Thread(gpioRunner);
                gpioTr.start();
            }
        }        
        
        SwitchGameState(GameStates.SPLASH);
    }

    /**
     * The ProcessDpadPress method is used to pass dpad press information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
     * The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
     * 
     * @param dir       The dir argument is a code that represents which dpad direction was processed.
     */
    @Override    
    public void ProcessDpadPress(int dir) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessDpadPress: " + dir);
            currentScreen.ProcessDpadPress(dir);
        }
    }

    /**
     * The ProcessDpadRelease method is used to pass dpad release information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
     * The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
     * 
     * @param dir        The dir argument is a code that represents which dpad direction was processed.
     */
    @Override    
    public void ProcessDpadRelease(int dir) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessDpadRelease: " + dir);
            currentScreen.ProcessDpadRelease(dir);
        }
    }    
    
    /**
     * The ProcessDpadClick method is used to pass dpad click information from the GamePanel class down to the MmgGameScreen class implementation, currentScreen. 
     * The dir code can come from different sources, keyboard, GPIO gamepad, or a USB game controller.
     * 
     * @param dir       The dir argument is a code that represents which dpad direction was processed.
     */
    @Override
    public void ProcessDpadClick(int dir) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessDpadClick: " + dir);
            currentScreen.ProcessDpadClick(dir);
        }
    }

    /**
     * The ProcessAPress method is used to pass A button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param src   The source of the A event. 
     */
    @Override
    public void ProcessAPress(int src) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessAPress: " + src);
            currentScreen.ProcessAPress(src);
        }
    }

    /**
     * The ProcessARelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param src   The source of the A event.
     */
    @Override
    public void ProcessARelease(int src) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessARelease: " + src);
            currentScreen.ProcessARelease(src);
        }
    }

    /**
     * The ProcessAClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param src   The source of the A event.
     */
    @Override    
    public void ProcessAClick(int src) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessAClick: " + src);
            currentScreen.ProcessAClick(src);
        }
    }    
    
    /**
     * The ProcessBPress method is used to pass B button press events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param src   The source of the B event.
     */
    @Override
    public void ProcessBPress(int src) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessBPress: " + src);
            currentScreen.ProcessBPress(src);
        }
    }

    /**
     * The ProcessBRelease method is used to pass A button release events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param src   The source of the B event.
     */
    @Override
    public void ProcessBRelease(int src) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessBRelease: " + src);
            currentScreen.ProcessBRelease(src);
        }
    }
    
    /**
     * The ProcessBClick method is used to pass A button click events from the GamePanel class down to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param src   The source of the B event.
     */
    @Override    
    public void ProcessBClick(int src) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessBClick: " + src);
            currentScreen.ProcessBClick(src);
        }
    }

    /**
     * The ProcessDebugClick method is used to send debug click events to the MmgGameScreen class implementation, currentScreen.
     * The event can be used to print screen specific information in response to the event.
     */
    public void ProcessDebugClick() {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessDebugClick");
            currentScreen.ProcessDebugClick();
        }
    }

    /**
     * The ProcessKeyPress method is used to send key press events to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param c     The c argument is the character of the keyboard press event.
     * @param code  A key code of the key event.
     */
    public void ProcessKeyPress(char c, int code) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessKeyPress");
            currentScreen.ProcessKeyPress(c, code);
        }
    }
    
    /**
     * The ProcessKeyRelease method is used to send key release events to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param c     The c argument is the character of the keyboard release event.
     * @param code  A key code of the key event.
     */
    public void ProcessKeyRelease(char c, int code) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessKeyRelease");
            currentScreen.ProcessKeyRelease(c, code);
        }
    }    
    
    /**
     * The ProcessKeyClick method is used to send key click events to the MmgGameScreen class implementation, currentScreen.
     * 
     * @param c     The c argument is the character of the keyboard click event.
     * @param code  A key code of the key event.
     */
    public void ProcessKeyClick(char c, int code) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessKeyClick");
            currentScreen.ProcessKeyClick(c, code);
        }
    }    
    
    /**
     * The ProcessMouseMove method is used to send mouse move information to the MmgGameScreen class implementation, currentScreen.
     * The coordinates are automatically adjusted to the offset of the game screen within the game panel. An optional mouseOffset is applied
     * to the mouse X, Y coordinates.
     * 
     * @param x     The x argument is the X position of the mouse as received from the mouse listener.
     * @param y     The y argument is the Y position of the mouse as received from the mouse listener.
     */
    public void ProcessMouseMove(int x, int y) {
        if (currentScreen != null) {            
            currentScreen.ProcessMouseMove((x - mouseOffsetX - myX), (y - mouseOffsetY - myY));
        }
    }
    
    /**
     * The ProcessMousePress method is used to send mouse press information to the MmgGameScreen class implementation, currentScreen.
     * The coordinates are automatically adjusted to the offset of the game screen within the game panel. An optional mouseOffset is applied
     * to the mouse X, Y coordinates.
     * 
     * @param x         The x argument is the X position of the mouse as received from the mouse listener.
     * @param y         The y argument is the Y position of the mouse as received from the mouse listener.
     * @param btnIndex  The button index of the mouse button event.
     */
    public void ProcessMousePress(int x, int y, int btnIndex) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessMousePress: " + btnIndex);
            currentScreen.ProcessMousePress((x - mouseOffsetX - myX), (y - mouseOffsetY - myY), btnIndex);
        }
    }

    /**
     * The ProcessMouseRelease method is used to send mouse release information to the MmgGameScreen class implementation, currentScreen.
     * The coordinates are automatically adjusted to the offset of the game screen within the game panel. An optional mouseOffset is applied
     * to the mouse X, Y coordinates.
     * 
     * @param x     The x argument is the X position of the mouse as received from the mouse listener.
     * @param y     The y argument is the Y position of the mouse as received from the mouse listener.
     * @param btnIndex  The button index of the mouse button event.
     */
    public void ProcessMouseRelease(int x, int y, int btnIndex) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessMouseRelease: " + btnIndex);
            currentScreen.ProcessMouseRelease((x - mouseOffsetX - myX), (y - mouseOffsetY - myY), btnIndex);
        }
    }

    /**
     * The ProcessMouseClick method is used to send mouse click information to the MmgGameScreen class implementation, currentScreen.
     * The coordinates are automatically adjusted to the offset of the game screen within the game panel. An optional mouseOffset is applied
     * to the mouse X, Y coordinates.
     * 
     * @param x     The x argument is the X position of the mouse as received from the mouse listener.
     * @param y     The y argument is the Y position of the mouse as received from the mouse listener.
     */     
    public void ProcessMouseClick(int x, int y, int btnIndex) {
        if (currentScreen != null) {
            MmgHelper.wr("ProcessMouseClick: " + btnIndex);
            currentScreen.ProcessMouseClick((x - mouseOffsetX - myX), (y - mouseOffsetY - myY), btnIndex);
        }
    }

    /**
     * The PrepBuffers method is used to create a new buffered image, background. It also sets the canvas
     * buffer strategy to use double buffering. The drawing strategy is stored in the strategy class field.
     * Lastly the backgroundGraphics class field is set from the background buffered image.
     */
    public void PrepBuffers() {
        // Background & Buffer
        background = create(winWidth, winHeight, false);
        canvas.createBufferStrategy(2);

        do {
            strategy = canvas.getBufferStrategy();
        } while (strategy == null);

        backgroundGraphics = (Graphics2D) background.getGraphics();
    }

    /**
     * Create a BufferedImage using the default screen device and configuration.
     * 
     * @param width     The desired width of the BufferedImage.
     * @param height    The desired height of the BufferedImage.
     * @param alpha     The desired transparency flag of the BufferedImage.
     * @return          Returns a BufferedImage with the desired coordinates and transparency. 
     */
    public BufferedImage create(int width, int height, boolean alpha) {
        return MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(width, height, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
    }

    /**
     * Gets the game screen Hashtable.
     *
     * @return          A Hashtable of game screens, MmgGameScreen.
     */
    public Hashtable<GameStates, MmgGameScreen> GetGameScreens() {
        return gameScreens;
    }

    /**
     * Sets the game screen Hashtable.
     *
     * @param GameScreens       A Hashtable of game screens, MmgGameScreen.
     */
    public void SetGameScreens(Hashtable<GameStates, MmgGameScreen> GameScreens) {
        gameScreens = GameScreens;
    }

    /**
     * Gets the Canvas instance for drawing on the JFrame.
     * 
     * @return      The Canvas class instance for drawing on the JFrame.
     */
    public Canvas GetCanvas() {
        return canvas;
    }
    
    /**
     * Gets the current game screen.
     *
     * @return      A game screen object, MmgGameScreen.
     */
    public MmgGameScreen GetCurrentScreen() {
        return currentScreen;
    }

    /**
     * Sets the current game screen.
     *
     * @param CurrentScreen         A game screen object.
     */
    public void SetCurrentScreen(MmgGameScreen CurrentScreen) {
        currentScreen = CurrentScreen;
    }

    /**
     * Switches the current game state, cleans up the current state, then loads
     * up the next state. Currently does not use the gameScreens hash table.
     * Uses direct references instead, for now.
     *
     * @param g         The game state to switch to.
     */
    public void SwitchGameState(GameStates g) {
        MmgHelper.wr("GamePanel: Switching Game State To: " + g);

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

        } else if (prevGameState == GameStates.LOADING) {
            MmgHelper.wr("Hiding LOADING screen.");
            screenLoading.Pause();
            screenLoading.SetIsVisible(false);
            screenLoading.UnloadResources();
            MmgHelper.wr("Hiding LOADING screen DONE.");

        } else if (prevGameState == GameStates.SPLASH) {
            MmgHelper.wr("Hiding SPLASH screen.");
            screenSplash.Pause();
            screenSplash.SetIsVisible(false);
            screenSplash.UnloadResources();

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

        } else if (prevGameState == GameStates.MAIN_GAME) {
            MmgHelper.wr("Hiding MAIN GAME screen.");
            //screenMainMenu.Pause();
            //screenMainMenu.SetIsVisible(false);
            //screenMainMenu.UnloadResources();

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

        } else if (gameState == GameStates.LOADING) {
            MmgHelper.wr("Showing LOADING screen.");
            screenLoading.LoadResources();
            screenLoading.UnPause();
            screenLoading.SetIsVisible(true);
            screenLoading.StartDatLoad();
            currentScreen = screenLoading;

        } else if (gameState == GameStates.SPLASH) {
            MmgHelper.wr("Showing SPLASH screen.");
            screenSplash.LoadResources();
            screenSplash.UnPause();
            screenSplash.SetIsVisible(true);
            screenSplash.StartDisplay();
            currentScreen = screenSplash;

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

        } else if (gameState == GameStates.MAIN_GAME) {
            MmgHelper.wr("Showing MAIN GAME screen.");
            //mainGameScreen.LoadResources();
            //mainGameScreen.UnPause();
            //mainGameScreen.SetIsVisible(true);
            //currentScreen = mainGameScreen;

        } else if (gameState == GameStates.SETTINGS) {
            MmgHelper.wr("Showing SETTINGS screen.");
            //settingsScreen.LoadResources();
            //settingsScreen.UnPause();
            //settingsScreen.SetIsVisible(true);
            //currentScreen = settingsScreen;

        }
    }

    /**
     * A generic event, GenericEventHandler, callback method. Used to handle
     * generic events from certain game screens, MmgGameScreen.
     *
     * @param obj       A GenericEventMessage instance that has information about the generic event that was fired.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        MmgHelper.wr("GamePanel: HandleGenericEvent");
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

    /**
     * Returns a Graphics2D instance that is based on the default screen configuration used for drawing on the JFrame.
     * 
     * @return      A Graphics2D instance that is used to draw on the JFrame.
     */
    public Graphics2D GetBuffer() {
        if (graphics == null) {
            try {
                graphics = (Graphics2D) strategy.getDrawGraphics();
            } catch (IllegalStateException e) {
                return null;
            }
        }
        return graphics;
    }

    /**
     * Returns the application window width.
     * 
     * @return      The application window width.
     */
    public int GetWinWidth() {
        return winWidth;
    }

    /**
     * Returns the application window height.
     * 
     * @return      The application window height.
     */    
    public int GetWinHeight() {
        return winHeight;
    }

    /**
     * Returns the X offset of the GamePanel in the JFrame window.
     * 
     * @return      The X offset of the GamePanel in the JFrame window.
     */
    public int GetX() {
        return myX;
    }

    /**
     * Returns the Y offset of the GamePanel in the JFrame window.
     * 
     * @return      The Y offset of the GamePanel in the JFrame window.
     */    
    public int GetY() {
        return myY;
    }

    /**
     * Updates the Java rendering API Graphics2D instances with the current Canvas buffer.
     * Resetting the graphics class field and syncing the Canvas drawing strategy is necessary with
     * a double buffered implementation.
     * 
     * @return      A boolean indicating if the method call was successful. Returns true in the case of a sync exception.
     */
    public boolean UpdateScreen() {
        graphics.dispose();
        graphics = null;
        try {
            strategy.show();
            Toolkit.getDefaultToolkit().sync();
            return (!strategy.contentsLost());

        } catch (Exception e) {
            return true;
        }
    }

    /**
     * The UpdateGame method is used to call the lower level MmgUpdate method of the MmgGameScreen class, currentScreen.
     * Send the update call count, the current time, and the time difference between this frame and the last frame.
     * 
     */
    public void UpdateGame() {
        updateTick++;

        prev = now;
        now = System.currentTimeMillis();

        if(GameSettings.GAMEPAD_1_ON && GameSettings.GAMEPAD_1_THREADED_POLLING == false) {
            gamePadRunner.PollGamePad();
        }
        
        if(GameSettings.GPIO_GAMEPAD_ON && GameSettings.GPIO_GAMEPAD_THREADED_POLLING == false) {
            gpioRunner.PollGpio();
        }        
        
        // update game logic here
        if (currentScreen != null) {
            currentScreen.MmgUpdate(updateTick, now, (now - prev));
        }
    }

    /**
     * The RenderGame method is used to draw the entire JFrame Canvas, the debug frame rate, the debug variables, and the game screen.
     */
    public void RenderGame() {
        if (PAUSE == true || EXIT == true) {
            //do nothing
        } else {
            UpdateGame();
        }

        //update graphics
        bg = GetBuffer();
        g = backgroundGraphics;

        if (currentScreen == null || currentScreen.IsPaused() == true || currentScreen.IsReady() == false) {
            //do nothing
        } else {
            //clear background
            g.setColor(Color.DARK_GRAY);
            g.fillRect(0, 0, winWidth, winHeight);

            //draw border
            g.setColor(Color.WHITE);
            g.drawRect(MmgScreenData.GetGameLeft() - 1, MmgScreenData.GetGameTop() - 1, MmgScreenData.GetGameWidth() + 1, MmgScreenData.GetGameHeight() + 1);

            g.setColor(Color.BLACK);
            g.fillRect(MmgScreenData.GetGameLeft(), MmgScreenData.GetGameTop(), MmgScreenData.GetGameWidth(), MmgScreenData.GetGameHeight());

            p.SetGraphics(g);
            p.SetAdvRenderHints();
            currentScreen.MmgDraw(p);

            if (MmgHelper.LOGGING == true) {
                tmpF = g.getFont();
                g.setFont(debugFont);
                g.setColor(debugColor);
                g.drawString(GamePanel.FPS, 15, 15);
                g.drawString("Var1: " + GamePanel.VAR1, 15, 35);
                g.drawString("Var2: " + GamePanel.VAR2, 15, 55);
                g.setFont(tmpF);
            }
        }

        //draws a scaled version of the state of the background buffer to the screen buffer if scaling is enabled
        if (scale != 1.0) {
            bg.drawImage(background, sMyX, sMyY, sWinWidth, sWinHeight, 0, 0, winWidth, winHeight, null);
        } else {
            bg.drawImage(background, myX, myY, null);
        }

        bg.dispose();
        UpdateScreen();
    }
}