package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuItem;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSound;

/**
 * A game screen object, ScreenMainMenu, that extends the MmgGameScreen base class. 
 * This game screen is for displaying a main menu screen.
 * Created by Middlemind Games 08/01/2015
 *
 * @author Victor G. Brusca
 */
public class ScreenMainMenu extends MmgGameScreen {

    /**
     * The game state this screen has.
     */
    public GameStates state;

    /**
     * Helper class for screen UI.
     */
    public MmgBmp menuStartGame;

    /**
     * Helper class for screen UI.
     */
    public MmgBmp menuExitGame;    
    
    /**
     * Helper class for screen UI.
     */
    public MmgBmp menuTitle;

    /**
     * Helper class for screen UI.
     */
    public MmgBmp menuSubTitle;    
    
    /**
     * Helper class for screen UI.
     */
    public MmgBmp menuFooterUrl;

    /**
     * The MmgBmp image to use as a menu cursor.
     */
    public MmgBmp menuCursor;

    /**
     * Helper class for storing game screen menu options.
     */
    public MmgMenuContainer menu;

    /**
     * The MmgSound to use when a menu item is selected.
     */
    public MmgSound menuSound;
    
    /**
     * The MmgFont used to display the version code for the case.
     */
    public MmgFont version;
    
    /**
     * Helper class for handling game screen events.
     */
    public HandleMainMenuEvent handleMenuEvent = null;

    /**
     * The GamePanel that owns this game screen. 
     * Usually a JPanel instance that holds a reference to this game screen object.
     */
    public GamePanel owner;
    
    /**
     * A boolean flag indicating if work needs to be done on the next MmgUpdate method.
     */
    public boolean isDirty;
    
    /**
     * A private boolean used in the MmgUpdate method.
     */
    private boolean lret;
    
    /**
     * A data structure that stores all the class configuration file entries from the target file.
     */
    public Hashtable<String, MmgCfgFileEntry> classConfig;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State     The game state of this game screen.
     * @param Owner     The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenMainMenu(GameStates State, GamePanel Owner) {
        super();
        isDirty = false;
        pause = false;
        ready = false;
        state = State;
        owner = Owner;
    }

    /**
     * Loads all the resources needed to display this game screen.
     */
    @SuppressWarnings("UnusedAssignment")
    public void LoadResources() {
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());

        MmgHelper.wr("ScreenMainMenu: LoadResources: Position: " + GetPosition().ApiToString());
        MmgHelper.wr("ScreenMainMenu: LoadResources: Width: " + GetWidth());
        MmgHelper.wr("ScreenMainMenu: LoadResources: Height: " + GetHeight());

        classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + "screen_main_menu.txt");
        
        MmgBmp tB = null;
        MmgPen p;
        String key = "";
        double scale = 1.0;
        String imgId = "";
        String sndId = "";        
        MmgBmp lval = null;
        MmgSound sval = null;
        String file = "";
        int tmp = 0;
        
        p = new MmgPen();
        p.SetCacheOn(false);
        handleMenuEvent = new HandleMainMenuEvent(this, owner);
        
        key = "soundMenuSelect";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "jump1.wav";
        }          
        
        sndId = file;
        sval = MmgHelper.GetBasicCachedSound(sndId);
        menuSound = sval;
        
        tB =  MmgHelper.CreateFilledBmp(w, h, MmgColor.GetBlack());
        if (tB != null) {
            SetCenteredBackground(tB);
        }

        
        key = "bmpGameTitle";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "game_title.png";
        }        
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuTitle = lval;
        if (menuTitle != null) {
            key = "menuTitleScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuTitle = MmgBmpScaler.ScaleMmgBmp(menuTitle, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuTitle);
            menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(50));
                
            key = "menuTitlePosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuTitlePosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                menuTitle.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuTitleOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                menuTitle.GetPosition().SetY(menuTitle.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuTitleOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                menuTitle.GetPosition().SetX(menuTitle.GetX() + MmgHelper.ScaleValue(tmp));
            }            
            
            AddObj(menuTitle);
        }

        
        key = "bmpGameSubTitle";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "game_sub_title.png";
        }       
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuSubTitle = lval;
        if (menuSubTitle != null) {
            key = "menuSubTitleScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuSubTitle = MmgBmpScaler.ScaleMmgBmp(menuTitle, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuSubTitle);
            menuSubTitle.GetPosition().SetY(menuTitle.GetY() + menuTitle.GetHeight() + MmgHelper.ScaleValue(50));            
            
            key = "menuSubTitlePosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuSubTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuSubTitlePosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuSubTitle.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }            
            
            key = "menuSubTitleOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuSubTitle.GetPosition().SetY(menuSubTitle.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuSubTitleOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuSubTitle.GetPosition().SetX(menuSubTitle.GetX() + MmgHelper.ScaleValue(tmp));
            }            
            
            AddObj(menuSubTitle);
        }        
        
        
        key = "bmpMenuItemStartGame";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "start_game.png";
        }        
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuStartGame = lval;
        if (menuStartGame != null) {
            key = "menuStartGameScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuStartGame = MmgBmpScaler.ScaleMmgBmp(menuStartGame, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuStartGame);
            menuStartGame.GetPosition().SetY(menuSubTitle.GetY() + menuSubTitle.GetHeight() + MmgHelper.ScaleValue(10));            
            
            key = "menuStartGamePosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuStartGamePosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }  
            
            key = "menuStartGameOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame.GetPosition().SetY(menuStartGame.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuStartGameOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame.GetPosition().SetX(menuStartGame.GetX() + MmgHelper.ScaleValue(tmp));
            }         
        }
        
        
        key = "bmpMenuItemExitGame";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "exit_game.png";
        }        
                
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuExitGame = lval;
        if (menuExitGame != null) {
            key = "menuExitGameScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuStartGame = MmgBmpScaler.ScaleMmgBmp(menuExitGame, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuExitGame);
            menuExitGame.GetPosition().SetY(menuStartGame.GetY() + menuStartGame.GetHeight() + MmgHelper.ScaleValue(10));
                
            key = "menuExitGamePosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                menuExitGame.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "menuExitGamePosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();    
                menuExitGame.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuExitGameOffsetY";
            if(classConfig.containsKey(key)) { 
                tmp = classConfig.get(key).number.intValue();    
                menuExitGame.GetPosition().SetY(menuExitGame.GetY() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "menuExitGameOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();    
                menuExitGame.GetPosition().SetX(menuExitGame.GetX() + MmgHelper.ScaleValue(tmp));
            }            
        }        
        
        
        key = "bmpFooterUrl";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "footer_url.png";
        }
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuFooterUrl = lval;
        if (menuFooterUrl != null) {
            key = "menuFooterUrlScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuFooterUrl = MmgBmpScaler.ScaleMmgBmp(menuFooterUrl, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuFooterUrl);
            menuFooterUrl.GetPosition().SetY(menuExitGame.GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(10));
                
            key = "menuFooterUrlPosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue(); 
                menuFooterUrl.GetPosition().SetY(GetPosition().GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "menuFooterUrlPosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue(); 
                menuFooterUrl.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }            
            
            key = "menuFooterUrlOffsetY";
            if(classConfig.containsKey(key)) {        
                tmp = classConfig.get(key).number.intValue(); 
                menuFooterUrl.GetPosition().SetY(menuFooterUrl.GetY() + menuExitGame.GetHeight() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "menuFooterUrlOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue(); 
                menuFooterUrl.GetPosition().SetX(menuFooterUrl.GetX() + MmgHelper.ScaleValue(tmp));
            }            
            
            AddObj(menuFooterUrl);
        }          
        
        
        key = "bmpMenuCursorLeft";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "cursor_hand_sm_right.png";
        }        
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuCursor = lval;
        SetLeftCursor(menuCursor);        

        
        key = "version";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
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

    /**
     * A callback method used to process A click events.
     * 
     * @param src       The source of the A click event, keyboard, GPIO gamepad, USB gamepad.
     * @return          A boolean flag indicating if work was done.
     */
    @Override
    public boolean ProcessAClick(int src) {
        int idx = GetMenuIdx();
        MmgMenuItem mmi;
        mmi = (MmgMenuItem) menu.GetContainer().get(idx);
        
        if (mmi != null) {
            ProcessMenuItemSel(mmi);
            return true;
        }
        
        return true;
    }
    
    /**
     * A callback method used to process dpad release events.
     * 
     * @param dir       The dpad direction of the event.
     * @return          A boolean flag indicating if work was done.
     */
    @Override
    public boolean ProcessDpadRelease(int dir) {
        if (dir == GameSettings.UP_KEYBOARD || dir == GameSettings.UP_GAMEPAD_1) {            
            MoveMenuSelUp();
        } else if (dir == GameSettings.DOWN_KEYBOARD || dir == GameSettings.DOWN_GAMEPAD_1) {
            MoveMenuSelDown();
        }

        return true;
    }

    /**
     * Forces this screen to prepare itself for display. 
     * This is the method that handles displaying different game screen text. Calling draw screen prepares the screen for display.
     */
    public void DrawScreen() {
        pause = true;
        menu = new MmgMenuContainer();
        menu.SetMmgColor(null);
        isDirty = false;

        MmgMenuItem mItm = null;
        
        if (menuStartGame != null) {
            mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Start Game", HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuStartGame);
            mItm.SetSound(menuSound);
            menu.Add(mItm);
        }

        if (menuExitGame != null) {
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

    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
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

    /**
     * Returns the game state of this game screen.
     *
     * @return      The game state of this game screen.
     */
    public GameStates GetGameState() {
        return state;
    }

    /**
     * Gets a boolean flag indicating if there is work to be done on the next MmgUpdate method call.
     * 
     * @return      A flag indicating if there is work to be done on the next MmgUpdate call.
     */
    public boolean GetIsDirty() {
        return isDirty;
    }

    /**
     * Sets a boolean flag indicating if there is work to be done on the next MmgUpdate method call.
     * 
     * @param b     A flag indicating if there is work to be done on the next MmgUpdate call.
     */
    public void SetIsDirty(boolean b) {
        isDirty = b;
    }

    /**
     * The main drawing routine.
     *
     * @param p     An MmgPen object to use for drawing this game screen.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (pause == false && isVisible == true) {
            super.MmgDraw(p);
        }
    }

    /**
     * Update the current sprite animation frame index.
     * 
     * @param updateTick            The index of the MmgUpdate call.
     * @param currentTimeMs         The current time in milliseconds of the MmgUpdate call.
     * @param msSinceLastFrame      The number of milliseconds since the last MmgUpdate call.
     * @return                      A boolean flag indicating if any work was done.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;

        if (pause == false && isVisible == true) {
            if (super.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true) {
                lret = true;
            }

            if (isDirty == true) {
                lret = true;
                DrawScreen();
            }

        }

        return lret;
    }
}