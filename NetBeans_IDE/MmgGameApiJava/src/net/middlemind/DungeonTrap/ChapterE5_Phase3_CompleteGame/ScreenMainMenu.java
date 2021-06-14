package net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame;

import net.middlemind.MmgGameApiJava.MmgCore.GameSettings;
import net.middlemind.MmgGameApiJava.MmgCore.HandleMainMenuEvent;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgMenuItem;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSound;

/**
 * The main menu screen of the Mmg Dungeon Trap game.
 * 
 * @author Victor G. Brusca
 * 03/22/2020
 */
public class ScreenMainMenu extends net.middlemind.MmgGameApiJava.MmgCore.ScreenMainMenu {

    /**
     * An MmgBmp instance that provides custom menu items for one player games.
     */
    private MmgBmp menuStartGame1P;

    /**
     * An MmgBmp instance that provides custom menu items for two player games.
     */
    private MmgBmp menuStartGame2P;    
       
    /**
     * An internal variable used in private class methods.
     */
    private boolean lret;    
    
    /**
     * Constructor, sets the game state associated with this screen, and sets
     * the owner GamePanel instance.
     *
     * @param State The game state of this game screen.
     * @param Owner The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenMainMenu(GameStates State, GamePanel Owner) {
        super(State, Owner);
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

        classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_main_menu.txt");
        
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

        MmgHelper.wr("Background Image Position: " + GetBackground().GetPosition().ApiToString());

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
            menuTitle.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(40));
                
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
            menuSubTitle.GetPosition().SetY(menuTitle.GetY() + menuTitle.GetHeight() + MmgHelper.ScaleValue(10));            
            
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
        
        key = "bmpMenuItemStartGame1p";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "start_game_1p.png";
        }        
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuStartGame1P = lval;
        if (menuStartGame1P != null) {
            key = "menuStartGame1pScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuStartGame1P = MmgBmpScaler.ScaleMmgBmp(menuStartGame1P, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuStartGame1P);
            menuStartGame1P.GetPosition().SetY(menuSubTitle.GetY() + menuSubTitle.GetHeight() + MmgHelper.ScaleValue(10));            
            
            key = "menuStartGame1pPosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame1P.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuStartGame1pPosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame1P.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }  
            
            key = "menuStartGame1pOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame1P.GetPosition().SetY(menuStartGame1P.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuStartGame1pOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame1P.GetPosition().SetX(menuStartGame1P.GetX() + MmgHelper.ScaleValue(tmp));
            }         
        }
                
        key = "bmpMenuItemStartGame2p";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "start_game_2p.png";
        }        
        
        imgId = file;
        lval = MmgHelper.GetBasicCachedBmp(imgId);
        menuStartGame2P = lval;
        if (menuStartGame2P != null) {
            key = "menuStartGame2pScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    menuStartGame2P = MmgBmpScaler.ScaleMmgBmp(menuStartGame2P, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuStartGame2P);
            menuStartGame2P.GetPosition().SetY(menuStartGame1P.GetY() + menuStartGame1P.GetHeight() + MmgHelper.ScaleValue(10));            
            
            key = "menuStartGame2pPosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame2P.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuStartGame2pPosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame2P.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }  
            
            key = "menuStartGame2pOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame2P.GetPosition().SetY(menuStartGame2P.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "menuStartGame2pOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                menuStartGame2P.GetPosition().SetX(menuStartGame2P.GetX() + MmgHelper.ScaleValue(tmp));
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
                    menuExitGame = MmgBmpScaler.ScaleMmgBmp(menuExitGame, scale, false);
                }
            }
            
            MmgHelper.CenterHor(menuExitGame);
            menuExitGame.GetPosition().SetY(menuStartGame2P.GetY() + menuStartGame2P.GetHeight() + MmgHelper.ScaleValue(10));
                
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
                menuFooterUrl.GetPosition().SetY(menuFooterUrl.GetY() + MmgHelper.ScaleValue(tmp));                
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
     * A method to handle A click events from the MainFrame.
     * 
     * @return      A boolean indicating if the click event was handled by this Screen.
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
        
        return false;
    }
    
    /**
     * A method to handle dpad release events from the MainFrame.
     * 
     * @param dir       A dpad code indicating if the UP, DOWN, LEFT, RIGHT direction was released.
     * 
     * @return          A boolean indicating if the Screen handled the dpad release event.
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
     * This is the method that handles displaying different game screen text. Calling draw screen
     * prepares the screen for display.
     */
    public void DrawScreen() {
        //int mainY;
        pause = true;
        menu = new MmgMenuContainer();
        menu.SetMmgColor(null);
        isDirty = false;

        MmgMenuItem mItm = null;
        
        if (menuStartGame1P != null) {
            mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Start Game 1P", HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_1P, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuStartGame1P);
            mItm.SetSound(menuSound);
            menu.Add(mItm);
        }

        if (menuStartGame2P != null) {
            mItm = MmgHelper.GetBasicMenuItem(handleMenuEvent, "Main Menu Start Game 2P", HandleMainMenuEvent.MAIN_MENU_EVENT_START_GAME_2P, HandleMainMenuEvent.MAIN_MENU_EVENT_TYPE, menuStartGame2P);
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
    @Override
    public void UnloadResources() {
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
        
        super.UnloadResources();        
        
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
     * Returns the dirty state of the Screen.
     * If a Screen is dirty it will be redrawn via the DrawScreen method on the next update call.
     * 
     * @return      A boolean indicating the state of the class' dirty flag.
     */
    public boolean GetIsDirty() {
        return isDirty;
    }

    /**
     * Sets the state of the Screen's dirty flag.
     * 
     * @param b     A boolean used to set the Screen class' dirty flag.
     */
    public void SetIsDirty(boolean b) {
        isDirty = b;
    }

    /**
     * A method that sets the Screen's dirty flag to true forcing a redraw on the next update call.
     */
    public void MakeDirty() {
        isDirty = true;
    }

    /**
     * The main drawing routine.
     *
     * @param p An MmgPen object to use for drawing this game screen.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (pause == false && isVisible == true) {
            super.MmgDraw(p);
        }
    }

    /**
     * The main update routine responsible for calling DrawnScreen when game updates are processed.
     * 
     * @param updateTick            A value indicating the number of the update call.
     * @param currentTimeMs         The current time in ms of the update call.
     * @param msSinceLastFrame      The number of ms between this update call and the previous update call.
     * @return      A boolean indicating if the update was processed.
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