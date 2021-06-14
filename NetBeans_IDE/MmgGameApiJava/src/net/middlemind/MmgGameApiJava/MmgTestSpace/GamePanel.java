package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgCore.DatExternalStrings;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgCore.MainFrame;
import net.middlemind.MmgGameApiJava.MmgCore.ScreenLoading;
import net.middlemind.MmgGameApiJava.MmgCore.ScreenSplash;

/**
 * An application specific extension of the MmgCore API's GamePanel class.
 * Created by Middlemind Games 02/19/2020
 * 
 * @author Victor G. Brusca
 */
public class GamePanel extends net.middlemind.MmgGameApiJava.MmgCore.GamePanel {
            
    /**
     * A reference to a game screen used for testing.
     */
    public ScreenTest screenTest;
    
    /**
     * A reference to a game screen used for testing the Mmg9Slice class.
     */
    public ScreenTestMmg9Slice screenTestMmg9Slice;
    
    /**
     * A reference to a game screen used for testing the MmgFont class.
     */
    public ScreenTestMmgFont screenTestMmgFont;
    
    /**
     * A reference to a game screen used for testing the MmgTextField class.
     */
    public ScreenTestMmgTextField screenTestMmgTextField;    
    
    /**
     * A reference to a game screen used for testing the MmgBmp class.
     */
    public ScreenTestMmgBmp screenTestMmgBmp;
    
    /**
     * A reference to a game screen used for testing the MmgSound class.
     */
    public ScreenTestMmgSound screenTestMmgSound;
    
    /**
     * A reference to a game screen used for testing the MmgMainMenu class.
     */
    public ScreenTestMmgMainMenu screenTestMmgMainMenu;
    
    /**
     * A reference to a game screen used for testing the MmgSprite class.
     */
    public ScreenTestMmgSprite screenTestMmgSprite;    
    
    /**
     * A reference to a game screen used for testing basic keyboard and mouse input.
     */
    public ScreenTestMmgBasicInput screenTestMmgBasicInput;
    
    /**
     * A reference to a game screen used for testing the MmgCfgFileEntry class during configuration file reading.
     */
    public ScreenTestMmgCfgFileEntryRead screenTestMmgCfgFileEntryRead;
    
    /**
     * A reference to a game screen used for testing the MmgScreenData class.
     */
    public ScreenTestMmgScreenData screenTestMmgScreenData;
    
    /**
     * A reference to a game screen used for testing the MmgColor class.
     */
    public ScreenTestMmgColor screenTestMmgColor;
    
    /**
     * A reference to a game screen used for testing the MmgContainer class.
     */
    public ScreenTestMmgContainer screenTestMmgContainer;
    
    /**
     * A reference to a game screen used for testing the MmgLabelValuePair class.
     */
    public ScreenTestMmgLabelValuePair screenTestMmgLabelValuePair;
    
    /**
     * A reference to a game screen used for testing the MmgScrollHor class.
     */
    public ScreenTestMmgScrollHor screenTestMmgScrollHor;
    
    /**
     * A reference to a game screen used for testing the MmgScrollVert class.
     */
    public ScreenTestMmgScrollVert screenTestMmgScrollVert;
    
    /**
     * A reference to a game screen used for testing the MmgScrollHorVert class.
     */
    public ScreenTestMmgScrollHorVert screenTestMmgScrollHorVert;    

    /**
     * A reference to a game screen used for testing the MmgPositionTween class.
     */
    public ScreenTestMmgPositionTween screenTestMmgPositionTween;
    
    /**
     * A reference to a game screen used for testing the MmgRect class.
     */
    public ScreenTestMmgRect screenTestMmgRect;
    
    /**
     * A reference to a game screen used for testing the MmgTextBlock class.
     */
    public ScreenTestMmgTextBlock screenTestMmgTextBlock;
    
    /**
     * A reference to a game screen used for testing the MmgCfgFileEntry class during configuration file writing.
     */
    public ScreenTestMmgCfgFileEntryWrite screenTestMmgCfgFileEntryWrite;    
    
    /**
     * A reference to a game screen used for testing the MmgObj class.
     */
    public ScreenTestMmgObj screenTestMmgObj;
    
    /**
     * A reference to a game screen used for testing the MmgSpriteSheet class.
     */
    public ScreenTestMmgSpriteSheet screenTestMmgSpriteSheet;
    
    /**
     * A reference to a game screen used for testing the MmgBmpFont class.
     */
    public ScreenTestMmgBmpFont screenTestMmgBmpFont;
    
    /**
     * A reference to a game screen used for testing the MmgLoadingBar class.
     */
    public ScreenTestMmgLoadingBar screenTestMmgLoadingBar;
    
    /**
     * A reference to a game screen used for testing the MmgSizeTween class.
     */
    public ScreenTestMmgSizeTween screenTestMmgSizeTween;
    
    /**
     * A reference to a game screen used for testing the MmgSpriteMatrix class.
     */
    public ScreenTestMmgSpriteMatrix screenTestMmgSpriteMatrix;    
    
    /**
     * A static class field that contains the total number of test game screens.
     */
    public static int TOTAL_TESTS = 26;
    
    /**
     * The basic constructor for this GamePanel extended class.
     * 
     * @param Mf                The MainFrame that is associated with this GamePanel.
     * @param WinWidth          The width to use for this GamePanel.
     * @param WinHeight         The height to use for this GamePanel.
     * @param X                 The X position of this GamePanel.
     * @param Y                 The Y position of this GamePanel.
     * @param GameWidth         The width of the game drawn on this GamePanel.
     * @param GameHeight        The height of the game drawn on this GamePanel.
     */
    public GamePanel(MainFrame Mf, int WinWidth, int WinHeight, int X, int Y, int GameWidth, int GameHeight) {
        super(Mf, WinWidth, WinHeight, X, Y, GameWidth, GameHeight);
        MmgHelper.wr("TestSpace.GamePanel.Constructor");
        screenSplash.SetGenericEventHandler(this);
        
        screenLoading.SetGenericEventHandler(this);
        screenLoading.SetSlowDown(500);
        
        screenTest = new ScreenTest(GameStates.GAME_SCREEN_01, this);
        screenTest.Pause();
        screenTest.SetIsVisible(false);
        
        screenTestMmgScreenData = new ScreenTestMmgScreenData(GameStates.GAME_SCREEN_01, this);
        screenTestMmgScreenData.Pause();
        screenTestMmgScreenData.SetIsVisible(false);
        
        screenTestMmg9Slice = new ScreenTestMmg9Slice(GameStates.GAME_SCREEN_02, this);
        screenTestMmg9Slice.Pause();
        screenTestMmg9Slice.SetIsVisible(false);

        screenTestMmgFont = new ScreenTestMmgFont(GameStates.GAME_SCREEN_03, this);
        screenTestMmgFont.Pause();
        screenTestMmgFont.SetIsVisible(false);

        screenTestMmgTextField = new ScreenTestMmgTextField(GameStates.GAME_SCREEN_04, this);
        screenTestMmgTextField.Pause();
        screenTestMmgTextField.SetIsVisible(false);
        
        screenTestMmgBmp = new ScreenTestMmgBmp(GameStates.GAME_SCREEN_05, this);
        screenTestMmgBmp.Pause();
        screenTestMmgBmp.SetIsVisible(false);
        
        screenTestMmgSound = new ScreenTestMmgSound(GameStates.GAME_SCREEN_06, this);
        screenTestMmgSound.Pause();
        screenTestMmgSound.SetIsVisible(false);
        
        screenTestMmgMainMenu = new ScreenTestMmgMainMenu(GameStates.GAME_SCREEN_07, this);
        screenTestMmgMainMenu.Pause();
        screenTestMmgMainMenu.SetIsVisible(false);
        
        screenTestMmgSprite = new ScreenTestMmgSprite(GameStates.GAME_SCREEN_08, this);
        screenTestMmgSprite.Pause();
        screenTestMmgSprite.SetIsVisible(false);
        
        screenTestMmgBasicInput = new ScreenTestMmgBasicInput(GameStates.GAME_SCREEN_09, this);
        screenTestMmgBasicInput.Pause();
        screenTestMmgBasicInput.SetIsVisible(false);
        
        screenTestMmgCfgFileEntryRead = new ScreenTestMmgCfgFileEntryRead(GameStates.GAME_SCREEN_10, this);
        screenTestMmgCfgFileEntryRead.Pause();
        screenTestMmgCfgFileEntryRead.SetIsVisible(false);
        
        screenTestMmgColor = new ScreenTestMmgColor(GameStates.GAME_SCREEN_11, this);
        screenTestMmgColor.Pause();
        screenTestMmgColor.SetIsVisible(false);    
        
        screenTestMmgContainer = new ScreenTestMmgContainer(GameStates.GAME_SCREEN_12, this);
        screenTestMmgContainer.Pause();
        screenTestMmgContainer.SetIsVisible(false);
        
        screenTestMmgLabelValuePair = new ScreenTestMmgLabelValuePair(GameStates.GAME_SCREEN_13, this);
        screenTestMmgLabelValuePair.Pause();
        screenTestMmgLabelValuePair.SetIsVisible(false);

        screenTestMmgScrollHor = new ScreenTestMmgScrollHor(GameStates.GAME_SCREEN_14, this);
        screenTestMmgScrollHor.Pause();
        screenTestMmgScrollHor.SetIsVisible(false);
        
        screenTestMmgScrollVert = new ScreenTestMmgScrollVert(GameStates.GAME_SCREEN_15, this);
        screenTestMmgScrollVert.Pause();
        screenTestMmgScrollVert.SetIsVisible(false);

        screenTestMmgScrollHorVert = new ScreenTestMmgScrollHorVert(GameStates.GAME_SCREEN_16, this);
        screenTestMmgScrollHorVert.Pause();
        screenTestMmgScrollHorVert.SetIsVisible(false);
        
        screenTestMmgRect = new ScreenTestMmgRect(GameStates.GAME_SCREEN_17, this);
        screenTestMmgRect.Pause();
        screenTestMmgRect.SetIsVisible(false);
        
        screenTestMmgPositionTween = new ScreenTestMmgPositionTween(GameStates.GAME_SCREEN_18, this);
        screenTestMmgPositionTween.Pause();
        screenTestMmgPositionTween.SetIsVisible(false);
        
        screenTestMmgTextBlock = new ScreenTestMmgTextBlock(GameStates.GAME_SCREEN_19, this);
        screenTestMmgTextBlock.Pause();
        screenTestMmgTextBlock.SetIsVisible(false);
        
        screenTestMmgCfgFileEntryWrite = new ScreenTestMmgCfgFileEntryWrite(GameStates.GAME_SCREEN_20, this);
        screenTestMmgCfgFileEntryWrite.Pause();
        screenTestMmgCfgFileEntryWrite.SetIsVisible(false);

        screenTestMmgObj = new ScreenTestMmgObj(GameStates.GAME_SCREEN_21, this);
        screenTestMmgObj.Pause();
        screenTestMmgObj.SetIsVisible(false);
        
        screenTestMmgSpriteSheet = new ScreenTestMmgSpriteSheet(GameStates.GAME_SCREEN_22, this);
        screenTestMmgSpriteSheet.Pause();
        screenTestMmgSpriteSheet.SetIsVisible(false);
        
        screenTestMmgBmpFont = new ScreenTestMmgBmpFont(GameStates.GAME_SCREEN_23, this);
        screenTestMmgBmpFont.Pause();
        screenTestMmgBmpFont.SetIsVisible(false);
        
        screenTestMmgLoadingBar = new ScreenTestMmgLoadingBar(GameStates.GAME_SCREEN_24, this);
        screenTestMmgLoadingBar.Pause();
        screenTestMmgLoadingBar.SetIsVisible(false);
        
        screenTestMmgSizeTween = new ScreenTestMmgSizeTween(GameStates.GAME_SCREEN_25, this);
        screenTestMmgSizeTween.Pause();
        screenTestMmgSizeTween.SetIsVisible(false);
        
        screenTestMmgSpriteMatrix = new ScreenTestMmgSpriteMatrix(GameStates.GAME_SCREEN_26, this);
        screenTestMmgSpriteMatrix.Pause();
        screenTestMmgSpriteMatrix.SetIsVisible(false);        
    }

    /**
     * Changes the currently visible game screen and cleans up the previously visible game screen.
     * 
     * @param g         The game state associated with the currently visible game screen.
     */
    @Override
    public void SwitchGameState(GameStates g) {
        MmgHelper.wr("TestSpace.Switching Game State To: " + g);

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
            screenTestMmgScreenData.Pause();
            screenTestMmgScreenData.SetIsVisible(false);
            screenTestMmgScreenData.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_02) {
            MmgHelper.wr("Hiding GAME_SCREEN_02 screen.");
            screenTestMmg9Slice.Pause();
            screenTestMmg9Slice.SetIsVisible(false);
            screenTestMmg9Slice.UnloadResources();            
                        
        } else if (prevGameState == GameStates.GAME_SCREEN_03) {
            MmgHelper.wr("Hiding GAME_SCREEN_03 screen.");
            screenTestMmgFont.Pause();
            screenTestMmgFont.SetIsVisible(false);
            screenTestMmgFont.UnloadResources();                        
            
        } else if (prevGameState == GameStates.GAME_SCREEN_04) {
            MmgHelper.wr("Hiding GAME_SCREEN_04 screen.");
            screenTestMmgTextField.Pause();
            screenTestMmgTextField.SetIsVisible(false);
            screenTestMmgTextField.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_05) {
            MmgHelper.wr("Hiding GAME_SCREEN_05 screen.");
            screenTestMmgBmp.Pause();
            screenTestMmgBmp.SetIsVisible(false);
            screenTestMmgBmp.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_06) {
            MmgHelper.wr("Hiding GAME_SCREEN_06 screen.");
            screenTestMmgSound.Pause();
            screenTestMmgSound.SetIsVisible(false);
            screenTestMmgSound.UnloadResources();            
            
        } else if (prevGameState == GameStates.GAME_SCREEN_07) {
            MmgHelper.wr("Hiding GAME_SCREEN_07 screen.");
            screenTestMmgMainMenu.Pause();
            screenTestMmgMainMenu.SetIsVisible(false);
            screenTestMmgMainMenu.UnloadResources();                        

        } else if (prevGameState == GameStates.GAME_SCREEN_08) {
            MmgHelper.wr("Hiding GAME_SCREEN_08 screen.");
            screenTestMmgSprite.Pause();
            screenTestMmgSprite.SetIsVisible(false);
            screenTestMmgSprite.UnloadResources();

        } else if (prevGameState == GameStates.GAME_SCREEN_09) {
            MmgHelper.wr("Hiding GAME_SCREEN_09 screen.");
            screenTestMmgBasicInput.Pause();
            screenTestMmgBasicInput.SetIsVisible(false);
            screenTestMmgBasicInput.UnloadResources();            
            
        } else if (prevGameState == GameStates.GAME_SCREEN_10) {
            MmgHelper.wr("Hiding GAME_SCREEN_10 screen.");
            screenTestMmgCfgFileEntryRead.Pause();
            screenTestMmgCfgFileEntryRead.SetIsVisible(false);
            screenTestMmgCfgFileEntryRead.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_11) {
            MmgHelper.wr("Hiding GAME_SCREEN_11 screen.");
            screenTestMmgColor.Pause();
            screenTestMmgColor.SetIsVisible(false);
            screenTestMmgColor.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_12) {
            MmgHelper.wr("Hiding GAME_SCREEN_12 screen.");
            screenTestMmgContainer.Pause();
            screenTestMmgContainer.SetIsVisible(false);
            screenTestMmgContainer.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_13) {
            MmgHelper.wr("Hiding GAME_SCREEN_13 screen.");
            screenTestMmgLabelValuePair.Pause();
            screenTestMmgLabelValuePair.SetIsVisible(false);
            screenTestMmgLabelValuePair.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_14) {
            MmgHelper.wr("Hiding GAME_SCREEN_14 screen.");
            screenTestMmgScrollHor.Pause();
            screenTestMmgScrollHor.SetIsVisible(false);
            screenTestMmgScrollHor.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_15) {
            MmgHelper.wr("Hiding GAME_SCREEN_15 screen.");
            screenTestMmgScrollVert.Pause();
            screenTestMmgScrollVert.SetIsVisible(false);
            screenTestMmgScrollVert.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_16) {
            MmgHelper.wr("Hiding GAME_SCREEN_16 screen.");
            screenTestMmgScrollHorVert.Pause();
            screenTestMmgScrollHorVert.SetIsVisible(false);
            screenTestMmgScrollHorVert.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_17) {
            MmgHelper.wr("Hiding GAME_SCREEN_17 screen.");
            screenTestMmgRect.Pause();
            screenTestMmgRect.SetIsVisible(false);
            screenTestMmgRect.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_18) {
            MmgHelper.wr("Hiding GAME_SCREEN_18 screen.");
            screenTestMmgPositionTween.Pause();
            screenTestMmgPositionTween.SetIsVisible(false);
            screenTestMmgPositionTween.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_19) {
            MmgHelper.wr("Hiding GAME_SCREEN_19 screen.");
            screenTestMmgTextBlock.Pause();
            screenTestMmgTextBlock.SetIsVisible(false);
            screenTestMmgTextBlock.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_20) {
            MmgHelper.wr("Hiding GAME_SCREEN_20 screen.");
            screenTestMmgCfgFileEntryWrite.Pause();
            screenTestMmgCfgFileEntryWrite.SetIsVisible(false);
            screenTestMmgCfgFileEntryWrite.UnloadResources();            
            
        } else if (prevGameState == GameStates.GAME_SCREEN_21) {
            MmgHelper.wr("Hiding GAME_SCREEN_21 screen.");
            screenTestMmgObj.Pause();
            screenTestMmgObj.SetIsVisible(false);
            screenTestMmgObj.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_22) {
            MmgHelper.wr("Hiding GAME_SCREEN_22 screen.");
            screenTestMmgSpriteSheet.Pause();
            screenTestMmgSpriteSheet.SetIsVisible(false);
            screenTestMmgSpriteSheet.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_23) {
            MmgHelper.wr("Hiding GAME_SCREEN_23 screen.");
            screenTestMmgBmpFont.Pause();
            screenTestMmgBmpFont.SetIsVisible(false);
            screenTestMmgBmpFont.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_24) {
            MmgHelper.wr("Hiding GAME_SCREEN_24 screen.");
            screenTestMmgLoadingBar.Pause();
            screenTestMmgLoadingBar.SetIsVisible(false);
            screenTestMmgLoadingBar.UnloadResources();            
            
        } else if (prevGameState == GameStates.GAME_SCREEN_25) {
            MmgHelper.wr("Hiding GAME_SCREEN_25 screen.");
            screenTestMmgSizeTween.Pause();
            screenTestMmgSizeTween.SetIsVisible(false);
            screenTestMmgSizeTween.UnloadResources();
            
        } else if (prevGameState == GameStates.GAME_SCREEN_26) {
            MmgHelper.wr("Hiding GAME_SCREEN_26 screen.");
            screenTestMmgSpriteMatrix.Pause();
            screenTestMmgSpriteMatrix.SetIsVisible(false);
            screenTestMmgSpriteMatrix.UnloadResources();            
            
        } else if (prevGameState == GameStates.MAIN_MENU) {
            MmgHelper.wr("Hiding MAIN_MENU screen.");
            //mainMenuScreen.Pause();
            //mainMenuScreen.SetIsVisible(false);
            //mainMenuScreen.UnloadResources();

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
            //mainGameScreen.Pause();
            //mainGameScreen.SetIsVisible(false);
            //mainGameScreen.UnloadResources();

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
            screenTestMmgScreenData.LoadResources();
            screenTestMmgScreenData.UnPause();
            screenTestMmgScreenData.SetIsVisible(true);
            currentScreen = screenTestMmgScreenData;
                        
        } else if (gameState == GameStates.GAME_SCREEN_02) {
            MmgHelper.wr("Showing GAME_SCREEN_02 screen.");
            screenTestMmg9Slice.LoadResources();
            screenTestMmg9Slice.UnPause();
            screenTestMmg9Slice.SetIsVisible(true);
            currentScreen = screenTestMmg9Slice;            
            
        } else if (gameState == GameStates.GAME_SCREEN_03) {
            MmgHelper.wr("Showing GAME_SCREEN_03 screen.");
            screenTestMmgFont.LoadResources();
            screenTestMmgFont.UnPause();
            screenTestMmgFont.SetIsVisible(true);
            currentScreen = screenTestMmgFont;                        
            
        } else if (gameState == GameStates.GAME_SCREEN_04) {
            MmgHelper.wr("Showing GAME_SCREEN_04 screen.");
            screenTestMmgTextField.LoadResources();
            screenTestMmgTextField.UnPause();
            screenTestMmgTextField.SetIsVisible(true);
            currentScreen = screenTestMmgTextField;
            
        } else if (gameState == GameStates.GAME_SCREEN_05) {
            MmgHelper.wr("Showing GAME_SCREEN_05 screen.");
            screenTestMmgBmp.LoadResources();
            screenTestMmgBmp.UnPause();
            screenTestMmgBmp.SetIsVisible(true);
            currentScreen = screenTestMmgBmp;
            
        } else if (gameState == GameStates.GAME_SCREEN_06) {
            MmgHelper.wr("Showing GAME_SCREEN_06 screen.");
            screenTestMmgSound.LoadResources();
            screenTestMmgSound.UnPause();
            screenTestMmgSound.SetIsVisible(true);
            currentScreen = screenTestMmgSound;            
            
        } else if (gameState == GameStates.GAME_SCREEN_07) {
            MmgHelper.wr("Showing GAME_SCREEN_07 screen.");
            screenTestMmgMainMenu.LoadResources();
            screenTestMmgMainMenu.UnPause();
            screenTestMmgMainMenu.SetIsVisible(true);
            currentScreen = screenTestMmgMainMenu;
            
        } else if (gameState == GameStates.GAME_SCREEN_08) {
            MmgHelper.wr("Showing GAME_SCREEN_08 screen.");
            screenTestMmgSprite.LoadResources();
            screenTestMmgSprite.UnPause();
            screenTestMmgSprite.SetIsVisible(true);
            currentScreen = screenTestMmgSprite;
            
        } else if (gameState == GameStates.GAME_SCREEN_09) {
            MmgHelper.wr("Showing GAME_SCREEN_09 screen.");
            screenTestMmgBasicInput.LoadResources();
            screenTestMmgBasicInput.UnPause();
            screenTestMmgBasicInput.SetIsVisible(true);
            currentScreen = screenTestMmgBasicInput;
            
        } else if (gameState == GameStates.GAME_SCREEN_10) {
            MmgHelper.wr("Showing GAME_SCREEN_10 screen.");
            screenTestMmgCfgFileEntryRead.LoadResources();
            screenTestMmgCfgFileEntryRead.UnPause();
            screenTestMmgCfgFileEntryRead.SetIsVisible(true);
            currentScreen = screenTestMmgCfgFileEntryRead;
            
        } else if (gameState == GameStates.GAME_SCREEN_11) {
            MmgHelper.wr("Showing GAME_SCREEN_11 screen.");
            screenTestMmgColor.LoadResources();
            screenTestMmgColor.UnPause();
            screenTestMmgColor.SetIsVisible(true);
            currentScreen = screenTestMmgColor;            
            
        } else if (gameState == GameStates.GAME_SCREEN_12) {
            MmgHelper.wr("Showing GAME_SCREEN_12 screen.");
            screenTestMmgContainer.LoadResources();
            screenTestMmgContainer.UnPause();
            screenTestMmgContainer.SetIsVisible(true);
            currentScreen = screenTestMmgContainer;
            
        } else if (gameState == GameStates.GAME_SCREEN_13) {
            MmgHelper.wr("Showing GAME_SCREEN_13 screen.");
            screenTestMmgLabelValuePair.LoadResources();
            screenTestMmgLabelValuePair.UnPause();
            screenTestMmgLabelValuePair.SetIsVisible(true);
            currentScreen = screenTestMmgLabelValuePair;                        
            
        } else if (gameState == GameStates.GAME_SCREEN_14) {
            MmgHelper.wr("Showing GAME_SCREEN_14 screen.");
            screenTestMmgScrollHor.LoadResources();
            screenTestMmgScrollHor.UnPause();
            screenTestMmgScrollHor.SetIsVisible(true);
            currentScreen = screenTestMmgScrollHor;
            
        } else if (gameState == GameStates.GAME_SCREEN_15) {
            MmgHelper.wr("Showing GAME_SCREEN_15 screen.");
            screenTestMmgScrollVert.LoadResources();
            screenTestMmgScrollVert.UnPause();
            screenTestMmgScrollVert.SetIsVisible(true);
            currentScreen = screenTestMmgScrollVert;
            
        } else if (gameState == GameStates.GAME_SCREEN_16) {
            MmgHelper.wr("Showing GAME_SCREEN_16 screen.");
            screenTestMmgScrollHorVert.LoadResources();
            screenTestMmgScrollHorVert.UnPause();
            screenTestMmgScrollHorVert.SetIsVisible(true);
            currentScreen = screenTestMmgScrollHorVert;
            
        } else if (gameState == GameStates.GAME_SCREEN_17) {
            MmgHelper.wr("Showing GAME_SCREEN_17 screen.");
            screenTestMmgRect.LoadResources();
            screenTestMmgRect.UnPause();
            screenTestMmgRect.SetIsVisible(true);
            currentScreen = screenTestMmgRect;

        } else if (gameState == GameStates.GAME_SCREEN_18) {
            MmgHelper.wr("Showing GAME_SCREEN_18 screen.");
            screenTestMmgPositionTween.LoadResources();
            screenTestMmgPositionTween.UnPause();
            screenTestMmgPositionTween.SetIsVisible(true);
            currentScreen = screenTestMmgPositionTween;

        } else if (gameState == GameStates.GAME_SCREEN_19) {
            MmgHelper.wr("Showing GAME_SCREEN_19 screen.");
            screenTestMmgTextBlock.LoadResources();
            screenTestMmgTextBlock.UnPause();
            screenTestMmgTextBlock.SetIsVisible(true);
            currentScreen = screenTestMmgTextBlock;
            
        } else if (gameState == GameStates.GAME_SCREEN_20) {
            MmgHelper.wr("Showing GAME_SCREEN_20 screen.");
            screenTestMmgCfgFileEntryWrite.LoadResources();
            screenTestMmgCfgFileEntryWrite.UnPause();
            screenTestMmgCfgFileEntryWrite.SetIsVisible(true);
            currentScreen = screenTestMmgCfgFileEntryWrite;
            
        } else if (gameState == GameStates.GAME_SCREEN_21) {
            MmgHelper.wr("Showing GAME_SCREEN_21 screen.");
            screenTestMmgObj.LoadResources();
            screenTestMmgObj.UnPause();
            screenTestMmgObj.SetIsVisible(true);
            currentScreen = screenTestMmgObj;            
            
        } else if (gameState == GameStates.GAME_SCREEN_22) {
            MmgHelper.wr("Showing GAME_SCREEN_22 screen.");
            screenTestMmgSpriteSheet.LoadResources();
            screenTestMmgSpriteSheet.UnPause();
            screenTestMmgSpriteSheet.SetIsVisible(true);
            currentScreen = screenTestMmgSpriteSheet;
            
        } else if (gameState == GameStates.GAME_SCREEN_23) {
            MmgHelper.wr("Showing GAME_SCREEN_23 screen.");
            screenTestMmgBmpFont.LoadResources();
            screenTestMmgBmpFont.UnPause();
            screenTestMmgBmpFont.SetIsVisible(true);
            currentScreen = screenTestMmgBmpFont;
            
        } else if (gameState == GameStates.GAME_SCREEN_24) {
            MmgHelper.wr("Showing GAME_SCREEN_24 screen.");
            screenTestMmgLoadingBar.LoadResources();
            screenTestMmgLoadingBar.UnPause();
            screenTestMmgLoadingBar.SetIsVisible(true);
            currentScreen = screenTestMmgLoadingBar;            
            
        } else if (gameState == GameStates.GAME_SCREEN_25) {
            MmgHelper.wr("Showing GAME_SCREEN_25 screen.");
            screenTestMmgSizeTween.LoadResources();
            screenTestMmgSizeTween.UnPause();
            screenTestMmgSizeTween.SetIsVisible(true);
            currentScreen = screenTestMmgSizeTween;
            
        } else if (gameState == GameStates.GAME_SCREEN_26) {
            MmgHelper.wr("Showing GAME_SCREEN_26 screen.");
            screenTestMmgSpriteMatrix.LoadResources();
            screenTestMmgSpriteMatrix.UnPause();
            screenTestMmgSpriteMatrix.SetIsVisible(true);
            currentScreen = screenTestMmgSpriteMatrix;            
            
        } else if (gameState == GameStates.MAIN_MENU) {
            MmgHelper.wr("Showing MAIN_MENU screen.");
            //mainMenuScreen.LoadResources();
            //mainMenuScreen.UnPause();
            //mainMenuScreen.SetIsVisible(true);
            //currentScreen = mainMenuScreen;

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
     * The generic event handler method used to handle events from different game screens like the splash screen and the loading screen.
     * 
     * @param obj       The generic event message to process.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        if (obj != null) {
            MmgHelper.wr("TestSpace.HandleGenericEvent " + obj.GetGameState());
            if (obj.GetGameState() == GameStates.LOADING) {
                if (obj.GetId() == ScreenLoading.EVENT_LOAD_COMPLETE) {
                    //Final loading steps
                    DatExternalStrings.LOAD_EXT_STRINGS();
                    if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("1")) {
                        //Test MmgScreenData
                        SwitchGameState(GameStates.GAME_SCREEN_01);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("2")) {
                        //Test Mmg9Slice
                        SwitchGameState(GameStates.GAME_SCREEN_02);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("3")) {
                        //Test MmgFont
                        SwitchGameState(GameStates.GAME_SCREEN_03);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("4")) {
                        //Test MmgTextField
                        SwitchGameState(GameStates.GAME_SCREEN_04);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("5")) {
                        //Test MmgBmp
                        SwitchGameState(GameStates.GAME_SCREEN_05);

                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("6")) {
                        //Test MmgSound
                        SwitchGameState(GameStates.GAME_SCREEN_06);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("7")) {
                        //Test MmgMainMenu
                        SwitchGameState(GameStates.GAME_SCREEN_07);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("8")) {
                        //Test MmgSprite
                        SwitchGameState(GameStates.GAME_SCREEN_08);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("9")) {
                        //Test MmgBasicInput
                        SwitchGameState(GameStates.GAME_SCREEN_09);                        
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("10")) {
                        //Test MmgCfgFileEntryRead
                        SwitchGameState(GameStates.GAME_SCREEN_10);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("11")) {
                        //Test MmgColor
                        SwitchGameState(GameStates.GAME_SCREEN_11);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("12")) {
                        //Test MmgContainer
                        SwitchGameState(GameStates.GAME_SCREEN_12);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("13")) {
                        //Test MmgLabelValuePair
                        SwitchGameState(GameStates.GAME_SCREEN_13);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("14")) {
                        //Test MmgScrollHor
                        SwitchGameState(GameStates.GAME_SCREEN_14);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("15")) {
                        //Test MmgScrollVert
                        SwitchGameState(GameStates.GAME_SCREEN_15);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("16")) {
                        //Test MmgScrollHorVert
                        SwitchGameState(GameStates.GAME_SCREEN_16);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("17")) {
                        //Test MmgRect
                        SwitchGameState(GameStates.GAME_SCREEN_17);                        

                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("18")) {
                        //Test MmgPositionTween
                        SwitchGameState(GameStates.GAME_SCREEN_18);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("19")) {
                        //Test MmgTextBlock
                        SwitchGameState(GameStates.GAME_SCREEN_19);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("20")) {
                        //Test MmgCfgFileEntryWrite
                        SwitchGameState(GameStates.GAME_SCREEN_20);                        
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("21")) {
                        //Test MmgObj
                        SwitchGameState(GameStates.GAME_SCREEN_21);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("22")) {
                        //Test MmgSpriteSheet
                        SwitchGameState(GameStates.GAME_SCREEN_22);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("23")) {
                        //Test MmgBmpFont
                        SwitchGameState(GameStates.GAME_SCREEN_23);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("24")) {
                        //Test MmgLoadingBar
                        SwitchGameState(GameStates.GAME_SCREEN_24);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("25")) {
                        //Test MmgSizeTween
                        SwitchGameState(GameStates.GAME_SCREEN_25);
                        
                    } else if(MmgTestScreens.TEST_TO_RUN != null && MmgTestScreens.TEST_TO_RUN.equals("26")) {
                        //Test MmgSpriteMatrix
                        SwitchGameState(GameStates.GAME_SCREEN_26);                        
                        
                    }
                }
                
            } else if (obj.GetGameState() == GameStates.SPLASH) {
                if (obj.GetId() == ScreenSplash.EVENT_DISPLAY_COMPLETE) {
                    SwitchGameState(GameStates.LOADING);
                }
                
            }
        }
    }    
}