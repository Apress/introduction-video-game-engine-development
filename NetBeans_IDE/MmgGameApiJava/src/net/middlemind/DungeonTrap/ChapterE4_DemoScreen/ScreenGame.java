package net.middlemind.DungeonTrap.ChapterE4_DemoScreen;

import java.awt.Color;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameType;
import net.middlemind.MmgGameApiJava.MmgCore.GameSettings;
import net.middlemind.MmgGameApiJava.MmgCore.Screen;
import java.util.Random;
import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgContainer;
import net.middlemind.MmgGameApiJava.MmgBase.MmgDir;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSprite;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSpriteMatrix;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A game screen object, ScreenGame, that extends the MmgGameScreen base
 * class. This class is for testing new UI widgets, etc.
 *
 * @author Victor G. Brusca
 * 03/15/2020
 */
public class ScreenGame extends Screen {
            
    /**
     * An enumeration that tracks which number is visible during game start countdown and in-game countdown.
     */
    private enum NumberState {
        NONE,
        NUMBER_1,
        NUMBER_2,
        NUMBER_3
    };
    
    /**
     * An enumeration that tracks which state this Screen is currently rendering.
     * Allows the Screen to support different views like in-game, countdown, game over, game start, etc.
     */
    private enum State {
        NONE,
        SHOW_GAME,
        SHOW_COUNT_DOWN,
        SHOW_COUNT_DOWN_IN_GAME,        
        SHOW_GAME_OVER,
        SHOW_GAME_EXIT
    };
        
    /**
     * The type of game to run.
     */
    private GameType gameType = GameType.GAME_ONE_PLAYER;
    
    /**
     * The previous game state.
     */
    private State statePrev = State.NONE;
    
    /**
     * The current game state.
     */
    private State state = State.NONE;
    
    /**
     * The current state of the count down number.
     */
    private NumberState numberState = NumberState.NONE;
    
    /**
     * The display time of the number in milliseconds.
     */
    private long timeNumberMs = 0L;
    
    /**
     * The total display time of the number in milliseconds.
     */
    private long timeNumberDisplayMs = 1000;
    
    /**
     * A number display temporary value.
     */
    private long timeTmpMs = 0L;
        
    /**
     * The background of the game.
     */
    private MmgBmp bground;
    
    /**
     * The count down number 1.
     */
    private MmgBmp number1;
    
    /**
     * The count down number 2.
     */
    private MmgBmp number2;
    
    /**
     * The count down number 3.
     */
    private MmgBmp number3;
    
    /**
     * A boolean indicating if the level's time is up.
     */
    private boolean scoreTimeUp = false;
       
    /**
     * The player one score.
     */
    private int scorePlayerOne = 0;
    
    /**
     * The player two score.
     */
    private int scorePlayerTwo = 0;
    
    /**
     * A text image for the exit string.
     */
    private MmgFont exit;
    
    /**
     * A background for the text exit image.
     */
    private MmgBmp exitBground;
       
    /**
     * A random number generator.
     */
    private Random rand;
    
    /**
     * The current position of the screen.
     */
    private MmgVector2 screenPos;
       
    /**
     * The source of the popup background image.
     */
    private MmgBmp bgroundPopupSrc;
    
    /**
     * The popup background image.
     */
    private Mmg9Slice bgroundPopup;
    
    /**
     * A text image for the ok string.
     */
    private MmgFont txtOk;
    
    /**
     * A text image for the cancel string.
     */
    private MmgFont txtCancel;
    
    /**
     * A text image for the game's goal string
     */
    private MmgFont txtGoal;
    
    /**
     * A text image for the game's player one directions.
     */
    private MmgFont txtDirecP1;
    
    /**
     * A text image for the game's player two directions.
     */
    private MmgFont txtDirecP2;
 
    /**
     * A text image for the game over text player one.
     */
    private MmgFont txtGameOver1;
    
    /**
     * A text image for the game over text player two.
     */
    private MmgFont txtGameOver2;
    
    /**
     * A text image for the game over time ran out message.
     */
    private MmgFont txtGameOver3;    
    
    /**
     * A padding value used in UI positioning.
     */
    private int padding = MmgHelper.ScaleValue(4);
    
    /**
     * The total width of the popup window.
     */
    private int popupTotalWidth = MmgHelper.ScaleValue(300);
    
    /**
     * The total height of the popup window.
     */
    private int popupTotalHeight = MmgHelper.ScaleValue(120);
    
    /**
     * The player one character.
     */
    private MdtCharInterPlayer player1;
    
    /**
     * The player two character.
     */
    private MdtCharInterPlayer player2;
    
    /**
     * A private boolean value used in internal class methods.
     */    
    private boolean lret;

    /**
     * The top of the game.
     */    
    public static int GAME_TOP = MmgScreenData.GetGameTop();
    
    /**
     * The top of the game's board.
     */    
    public static int BOARD_TOP = GAME_TOP + MmgHelper.ScaleValue(106);

    /**
     * The bottom of the game.
     */    
    public static int GAME_BOTTOM = MmgScreenData.GetGameBottom();

    /**
     * The bottom of the game's board.
     */
    public static int BOARD_BOTTOM = GAME_BOTTOM - MmgHelper.ScaleValue(56);    

    /**
     * The left of the game.
     */    
    public static int GAME_LEFT = MmgScreenData.GetGameLeft();

    /**
     * The left of the game's board.
     */    
    public static int BOARD_LEFT = GAME_LEFT + MmgHelper.ScaleValue(20);

    /**
     * The right of the game.
     */    
    public static int GAME_RIGHT = MmgScreenData.GetGameRight();

    /**
     * The right of the game's board.
     */    
    public static int BOARD_RIGHT = GAME_RIGHT - MmgHelper.ScaleValue(132);

    /**
     * The game's width.
     */    
    public static int GAME_WIDTH = GAME_RIGHT - GAME_LEFT;

    /**
     * The game board's width.
     */    
    public static int BOARD_WIDTH = BOARD_RIGHT - BOARD_LEFT;

    /**
     * The game's height.
     */    
    public static int GAME_HEIGHT = GAME_BOTTOM - GAME_TOP;

    /**
     * The game board's height.
     */    
    public static int BOARD_HEIGHT = BOARD_BOTTOM - BOARD_TOP;    
       
    /**
     * The number of enemy waves in this game.
     */
    public static int WAVE_COUNT = 12;
    
    /**
     * The speed in milliseconds of the player character's frames when moving.
     */
    public int frameMsPerFrameMoving = 100;
    
    /**
     * The speed in milliseconds of the player character's frames when not moving.
     */
    public int frameMsPerFrameNotMoving = 300;
        
    /**
     * A boolean indicating if the player snaps to the front direction.
     */
    public boolean playerSnapToFront = false;    
       
    /**
     * An MmgBmp images used to represent the source of a sprite matrix.
     */
    private MmgBmp spriteMatrixSrc;
    
    /**
     * An MmgSpriteMatrix instance used to hold sprite matrix data.
     */
    private MmgSpriteMatrix spriteMatrix;    
    
    /**
     * An MmgSprite instance used to hold sprite data.
     */
    private MmgSprite sprite;    
    
    /**
     * A private field used to hold a Color value.
     */
    private Color c;
    
    /**
     * A text representation of player 1.
     */
    public MmgFont txtPlayer1 = null;
    
    /**
     * A text representation of player 2.
     */
    public MmgFont txtPlayer2 = null;
    
    /**
     * A text representation of player 2's score.
     */
    public MmgFont txtPlayer1Score = null;
    
    /**
     * A text representation of player 2's score.
     */
    public MmgFont txtPlayer2Score = null;
    
    /**
     * A text element for the player 1 HUD section.
     */
    public MmgFont txtPlayer1Section = null;
    
    /**
     * A text element for the player 2 HUD section.
     */
    public MmgFont txtPlayer2Section = null;    
    
    /**
     * A text HUD UI element for player 1 weapons.
     */
    public MmgFont txtPlayer1Weapon = null;
    
    /**
     * A text HUD UI element for player 2 weapons.
     */
    public MmgFont txtPlayer2Weapon = null;    
    
    /**
     * A text HUD UI element for player 1 modifications.
     */
    public MmgFont txtPlayer1Mod = null;
    
    /**
     * A text HUD UI element for player 2 modifications.
     */
    public MmgFont txtPlayer2Mod = null;    
    
    /**
     * A text representation of the player 1 modifier time.
     */
    public MmgFont txtPlayer1ModTime = null;
    
    /**
     * A text representation of the player 2 modifier time.
     */
    public MmgFont txtPlayer2ModTime = null;        
    
    /**
     * A text representation of the current level time.
     */
    public MmgFont txtLevelTime = null;
    
    /**
     * A text representation of the current level.
     */
    public MmgFont txtLevel = null;
    
    /**
     * The game logo to use on the main menu and game board.
     */
    public MmgBmp gameLogo = null;
        
    /**
     * The first background torch.
     */
    private MdtObjTorch torch1;
    
    /**
     * The second background torch.
     */
    private MdtObjTorch torch2;    
    
    /**
     * The third background torch.
     */
    private MdtObjTorch torch3;    
    
    /**
     * The fourth background torch.
     */
    private MdtObjTorch torch4;    
    
    /**
     * The current enemy wave index.
     */
    private int wavesCurrentIdx;
    
    /**
     * Source ID for player 1 input.
     */
    public static int SRC_PLAYER_1 = GameSettings.SRC_KEYBOARD;
    
    /**
     * Source ID for player 2 input.
     */
    public static int SRC_PLAYER_2 = 255;    
    
    /**
     * Player 1 HUD weapon image.
     */
    public MmgBmp player1WeaponBmp;
    
    /**
     * Player 1 HUD modifier image.
     */
    public MmgBmp player1ModBmp;
    
    /**
     * Player 2 HUD weapon image.
     */
    public MmgBmp player2WeaponBmp;    
    
    /**
     * Player 2 HUD modifier image.
     */
    public MmgBmp player2ModBmp;    
    
    /**
     * Generic door lock full.
     */
    public MmgBmp doorLockFull;
    
    /**
     * Generic door open full.
     */
    public MmgBmp doorOpenFull;
    
    /**
     * Generic door lock icon.
     */
    public MmgBmp doorLockIcon;    

    /**
     * Door locked icon for the top left door.
     */
    public MmgBmp doorTopLeftLocked;
    
    /**
     * Door opened icon for the top left door.
     */
    public MmgBmp doorTopLeftOpened;
    
    /**
     * Lock icon for the left hand door.
     */    
    public MmgBmp doorLeftLockIcon;        
    
    /**
     * Door locked icon for the top right door.
     */
    public MmgBmp doorTopRightLocked;
    
    /**
     * Door opened icon for the top right door.
     */
    public MmgBmp doorTopRightOpened;    
    
    /**
     * Lock icon for the right hand door.
     */
    public MmgBmp doorRightLockIcon;

    /**
     * Lock icon for the bottom left hand door.
     */
    public MmgBmp doorBotLeftLockIcon;

    /**
     * Lock icon for the bottom right hand door.
     */
    public MmgBmp doorBotRightLockIcon;    
    
    /**
     * The random placement rectangle for the left hand side of the board.
     */
    public MmgRect randoLeft = null;
    
    /**
     * The random placement rectangle for the right hand side of the board.
     */
    public MmgRect randoRight = null;    
    
    /**
     * A background image used to frame the count down numbers.
     */
    public Mmg9Slice numberBground = null;
    
    /**
     * A container that is used to hold object game objects.
     */
    public MmgContainer gameObjects = null;
    
    /**
     * A container that is used to hold item game objects.
     */
    public MmgContainer gameItems = null;
        
    /**
     * A container that is used to hold enemy game objects.
     */
    public MmgContainer gameEnemies = null;    
    
    /**
     * The image animation frames needed to display the demon enemy.
     */
    private MmgSprite enemyDemonFrames = null;
    
    /**
     * The image animation frames needed to display the banshee enemy.
     */
    private MmgSprite enemyBansheeFrames = null;    
    
    /**
     * The image animation frames needed to display the warlock enemy.
     */
    private MmgSprite enemyWarlockFrames = null;        
    
    /**
     * The number of player characters that are still alive.
     */
    private int playersAliveCount = 0;
    
    /**
     * A boolean indicating random level numbers are active.
     */
    private boolean randomWaves = false;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets
     * the owner GamePanel instance.
     *
     * @param State The game state of this game screen.
     * @param Owner The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenGame(GameStates State, GamePanel Owner) {
        super(State, Owner);
        pause = false;
        ready = false;
        owner = Owner;    
        rand = new Random(System.currentTimeMillis());
    }

    /**
     * Loads all the resources needed to display this game screen and support all Screen states.
     */
    @Override
    @SuppressWarnings("UnusedAssignment")
    public void LoadResources() {
        pause = true;        
        rand = new Random((int)System.currentTimeMillis());
        
        classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_game.txt");        
                
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());
        screenPos = GetPosition();
        
        String key = "";
        MmgBmp lval = null;
        String file = "";
        int tmp = 0;
        int tmpW = 0;
        int tmpH = 0;
        MmgBmp[] frames = null;
        MmgObj obj = null;
        MdtItemPotionYellow pTmp = null;
        
        scorePlayerOne = 0;
        scorePlayerTwo = 0;
        scoreTimeUp = false;
        
        //Load game board config
        file = MmgHelper.ContainsKeyString("bmpGameBoard", "dt_level1.png", classConfig);
        bground = MmgHelper.GetBasicCachedBmp(file);
        if (bground != null) {
            MmgHelper.CenterHorAndVert(bground);
            bground = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("gameBoard", bground, classConfig, bground.GetPosition());
            AddObj(bground);
        }
           
        //Load door lock source
        doorLockFull = MmgHelper.GetBasicCachedBmp("door_locked.png");
        doorOpenFull = MmgHelper.GetBasicCachedBmp("door_opened.png");
        doorLockIcon = MmgHelper.GetBasicCachedBmp("door_lock_icon.png");
        
        //Load door locks
        int adj = 90;
        doorTopLeftLocked = doorLockFull.CloneTyped();
        doorTopLeftLocked.SetPosition(new MmgVector2(MmgHelper.ScaleValue(146), MmgHelper.ScaleValue(adj + 43)));
        AddObj(doorTopLeftLocked);
        
        doorTopLeftOpened = doorOpenFull.CloneTyped();
        doorTopLeftOpened.SetPosition(new MmgVector2(MmgHelper.ScaleValue(146), MmgHelper.ScaleValue(adj + 43)));
        AddObj(doorTopLeftOpened);        
        
        doorTopRightLocked = doorLockFull.CloneTyped();
        doorTopRightLocked.SetPosition(new MmgVector2(MmgHelper.ScaleValue(466), MmgHelper.ScaleValue(adj + 43)));
        AddObj(doorTopRightLocked);
        
        doorTopRightOpened = doorOpenFull.CloneTyped();
        doorTopRightOpened.SetPosition(new MmgVector2(MmgHelper.ScaleValue(466), MmgHelper.ScaleValue(adj + 43)));
        AddObj(doorTopRightOpened);
        
        doorLeftLockIcon = doorLockIcon.CloneTyped();
        doorLeftLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(18 + doorLockIcon.GetWidth()/2), MmgHelper.ScaleValue(adj + 206 + doorLockIcon.GetHeight()/2)));
        AddObj(doorLeftLockIcon);
        
        doorRightLockIcon = doorLockIcon.CloneTyped();
        doorRightLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(690 + doorLockIcon.GetWidth()/2), MmgHelper.ScaleValue(adj + 206 + doorLockIcon.GetHeight()/2)));        
        AddObj(doorRightLockIcon);
        
        doorBotLeftLockIcon = doorLockIcon.CloneTyped();
        doorBotLeftLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(154 + doorLockIcon.GetWidth()/2), MmgHelper.ScaleValue(adj + 318 + doorLockIcon.GetHeight()/2)));
        AddObj(doorBotLeftLockIcon);
        
        doorBotRightLockIcon = doorLockIcon.CloneTyped();
        doorBotRightLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(474 + doorLockIcon.GetWidth()/2), MmgHelper.ScaleValue(adj + 318 + doorLockIcon.GetHeight()/2)));
        AddObj(doorBotRightLockIcon);        
        
        //Load torches
        MdtObjTorch torch = new MdtObjTorch();
        torch.SetPosition(MmgHelper.ScaleValue(65) - torch.GetWidth()/2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
        torch.isBurning = true;
        torch1 = torch;
        AddObj(torch1);
        
        torch = new MdtObjTorch();
        torch.SetPosition(MmgHelper.ScaleValue(290) - torch.GetWidth()/2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
        torch.isBurning = true;
        torch2 = torch;
        AddObj(torch2);
        
        torch = new MdtObjTorch();
        torch.SetPosition(MmgHelper.ScaleValue(380) - torch.GetWidth()/2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
        torch.isBurning = true;
        torch3 = torch;
        AddObj(torch3);

        torch = new MdtObjTorch();
        torch.SetPosition(MmgHelper.ScaleValue(610) - torch.GetWidth()/2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
        torch.isBurning = true;
        torch4 = torch;
        AddObj(torch4);        
        
        //Load random item drop rectangles
        randoLeft = new MmgRect(BOARD_LEFT + MmgHelper.ScaleValue(96), BOARD_TOP + MmgHelper.ScaleValue(64), BOARD_BOTTOM - MmgHelper.ScaleValue(64), BOARD_LEFT + BOARD_WIDTH/2 - MmgHelper.ScaleValue(32));
        randoRight = new MmgRect(BOARD_LEFT + BOARD_WIDTH/2 + MmgHelper.ScaleValue(64), BOARD_TOP + MmgHelper.ScaleValue(64), BOARD_BOTTOM - MmgHelper.ScaleValue(64), BOARD_RIGHT - MmgHelper.ScaleValue(96));
        
        //These containers ensure these items are visible below the player        
        //Load game items container
        gameItems = new MmgContainer();
        gameItems.SetX(BOARD_LEFT);
        gameItems.SetY(BOARD_TOP);
        gameItems.SetWidth(BOARD_WIDTH);
        gameItems.SetHeight(BOARD_HEIGHT);        
        AddObj(gameItems);        
        
        //Load game objects container
        gameObjects = new MmgContainer();
        gameObjects.SetX(BOARD_LEFT);
        gameObjects.SetY(BOARD_TOP);
        gameObjects.SetWidth(BOARD_WIDTH);
        gameObjects.SetHeight(BOARD_HEIGHT);        
        AddObj(gameObjects);

        //Load game objects container
        gameEnemies = new MmgContainer();
        gameEnemies.SetX(BOARD_LEFT);
        gameEnemies.SetY(BOARD_TOP);
        gameEnemies.SetWidth(BOARD_WIDTH);
        gameEnemies.SetHeight(BOARD_HEIGHT);        
        AddObj(gameEnemies);        
        
        //Load player movement speeds
        tmp = MmgHelper.ContainsKeyInt("bmpPlayerFrameMsPerFrameMoving", 250, classConfig);        
        frameMsPerFrameMoving = tmp;
        tmp = MmgHelper.ContainsKeyInt("bmpPlayerFrameMsPerFrameNotMoving", 500, classConfig);                
        frameMsPerFrameNotMoving = tmp;        
                
        //Load player1 frames
        tmp = MmgHelper.ContainsKeyInt("bmpPlayerFrameCount", 16, classConfig);
        frames = new MmgBmp[tmp];
        for(int i = 0; i < frames.length; i++) {
            file = MmgHelper.ContainsKeyString("bmpPlayer1Frame" + (i + 1), "soldier_frame_" + (i + 1) + ".png", classConfig);
            frames[i] = MmgHelper.GetBasicCachedBmp(file);

            if (frames[i] != null) {
                frames[i] = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("bmpPlayer1Frame" + (i + 1), frames[i], classConfig, MmgVector2.GetOriginVec());
            } else {
                MmgHelper.wr("ScreenGame: Error loading player1 frame " + i + ".");                
            }
        }
                
        obj = new MmgObj(frames[0].GetWidth(), frames[0].GetHeight());
        MmgHelper.CenterHorAndVert(obj);
        obj.SetX(obj.GetX() - (GAME_WIDTH - BOARD_WIDTH)/2 + obj.GetWidth());
        obj.SetY(obj.GetY() - frames[0].GetHeight() - MmgHelper.ScaleValue(20));
        
        player1 = new MdtCharInterPlayer(new MmgSprite(frames), 0, 3, 12, 15, 4, 7, 8, 11, this, MdtPlayerType.PLAYER_1);
        player1.SetMmgColor(null);
        player1.SetDir(MmgDir.DIR_FRONT);
        player1.SetIsVisible(true);
        player1.SetPosition(obj.GetPosition().Clone());
        player1.SetPosition(new MmgVector2(player1.GetX(), player1.GetY() + MmgHelper.ScaleValue(10)));
        
        tmp = MmgHelper.ContainsKeyInt("bmpPlayerFrameMsPerFrame", 250, classConfig);
        player1.subj.SetMsPerFrame(tmp);
        player1.speed = ScreenGame.GetSpeedPerFrame(120);
        player1WeaponBmp = player1.weaponCurrent.subjRight;        
        AddObj(player1);
        
        //Load player2 frames
        tmp = MmgHelper.ContainsKeyInt("bmpPlayerFrameCount", 16, classConfig);
        frames = new MmgBmp[tmp];
        for(int i = 0; i < frames.length; i++) {
            file = MmgHelper.ContainsKeyString("bmpPlayer2Frame" + (i + 1), "soldier_frame_" + (i + 1) + "_2p.png", classConfig);
            frames[i] = MmgHelper.GetBasicCachedBmp(file);

            if (frames[i] != null) {
                frames[i] = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("bmpPlayer2Frame" + (i + 1), frames[i], classConfig, MmgVector2.GetOriginVec());
            } else {
                MmgHelper.wr("ScreenGame: Error loading player2 frame " + i + ".");                
            }
        }                
                
        obj = new MmgObj(frames[0].GetWidth(), frames[0].GetHeight());
        MmgHelper.CenterHorAndVert(obj);
        obj.SetX(obj.GetX() - (GAME_WIDTH - BOARD_WIDTH)/2 + obj.GetWidth());        
        obj.SetY(obj.GetY() + frames[0].GetHeight() + MmgHelper.ScaleValue(20));
        
        player2 = new MdtCharInterPlayer(new MmgSprite(frames), 0, 3, 12, 15, 4, 7, 8, 11, this, MdtPlayerType.PLAYER_2);
        player2.SetMmgColor(null);
        player2.SetDir(MmgDir.DIR_FRONT);
        player2.SetIsVisible(true);
        player2.SetPosition(obj.GetPosition().Clone());
        
        tmp = MmgHelper.ContainsKeyInt("bmpPlayerFrameMsPerFrame", 250, classConfig);
        player2.subj.SetMsPerFrame(tmp);
        player2.speed = ScreenGame.GetSpeedPerFrame(120);
        player2WeaponBmp = player2.weaponCurrent.subjRight;
        AddObj(player2);        
            
        //Load enemy demon frames
        spriteMatrixSrc = MmgHelper.GetBasicCachedBmp("enemy_demon_spritematrix_w_shadow.png");
        spriteMatrixSrc = MmgBmpScaler.ScaleMmgBmp(spriteMatrixSrc, 1.5f, true);
        
        MmgHelper.CenterHor(spriteMatrixSrc);
        spriteMatrixSrc.SetPosition(new MmgVector2(25, MmgHelper.ScaleValue(160)));        
        spriteMatrix = new MmgSpriteMatrix(spriteMatrixSrc.CloneTyped(), 48, 51, 4, 3);        
        MmgObj tmpObj = new MmgObj();
        tmpObj.SetHeight(68);
        tmpObj.SetWidth(64);
        MmgHelper.CenterHorAndVert(tmpObj);
        
        MmgVector2 tmpPos = tmpObj.GetPosition().Clone();
        tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(15));
        tmpPos.SetX(MmgScreenData.GetGameWidth() - 64 - 25);
        
        MmgBmp[] tEnm = new MmgBmp[16];
        //Enemy Front
        tEnm[0] = spriteMatrix.GetFrame(0);
        tEnm[1] = spriteMatrix.GetFrame(1);
        tEnm[2] = spriteMatrix.GetFrame(2);
        tEnm[3] = spriteMatrix.GetFrame(1);
        
        //Enemy Left
        tEnm[4] = spriteMatrix.GetFrame(3);
        tEnm[5] = spriteMatrix.GetFrame(4);
        tEnm[6] = spriteMatrix.GetFrame(5);
        tEnm[7] = spriteMatrix.GetFrame(4);                
        
        //Enemy Right
        tEnm[8] = spriteMatrix.GetFrame(6);
        tEnm[9] = spriteMatrix.GetFrame(7);
        tEnm[10] = spriteMatrix.GetFrame(8);
        tEnm[11] = spriteMatrix.GetFrame(7);        
        
        //Enemy Back
        tEnm[12] = spriteMatrix.GetFrame(9);
        tEnm[13] = spriteMatrix.GetFrame(10);
        tEnm[14] = spriteMatrix.GetFrame(11);
        tEnm[15] = spriteMatrix.GetFrame(10);
        
        enemyDemonFrames = new MmgSprite(tEnm, tmpPos);
        enemyDemonFrames.SetMsPerFrame(tmp);
                
        //Load enemy banshee frames
        spriteMatrixSrc = MmgHelper.GetBasicCachedBmp("enemy_banshee_spritematrix_w_shadow.png");
        spriteMatrixSrc = MmgBmpScaler.ScaleMmgBmp(spriteMatrixSrc, 1.5f, true);
        
        MmgHelper.CenterHor(spriteMatrixSrc);
        spriteMatrixSrc.SetPosition(new MmgVector2(25, MmgHelper.ScaleValue(160)));        
        spriteMatrix = new MmgSpriteMatrix(spriteMatrixSrc.CloneTyped(), 48, 51, 4, 3);        
        tmpObj = new MmgObj();
        tmpObj.SetHeight(68);
        tmpObj.SetWidth(64);
        MmgHelper.CenterHorAndVert(tmpObj);
        
        tmpPos = tmpObj.GetPosition().Clone();
        tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(15));
        tmpPos.SetX(MmgScreenData.GetGameWidth() - 64 - 25);
        
        tEnm = new MmgBmp[16];
        //Enemy Front
        tEnm[0] = spriteMatrix.GetFrame(0);
        tEnm[1] = spriteMatrix.GetFrame(1);
        tEnm[2] = spriteMatrix.GetFrame(2);
        tEnm[3] = spriteMatrix.GetFrame(1);
        
        //Enemy Left
        tEnm[4] = spriteMatrix.GetFrame(3);
        tEnm[5] = spriteMatrix.GetFrame(4);
        tEnm[6] = spriteMatrix.GetFrame(5);
        tEnm[7] = spriteMatrix.GetFrame(4);                
        
        //Enemy Right
        tEnm[8] = spriteMatrix.GetFrame(6);
        tEnm[9] = spriteMatrix.GetFrame(7);
        tEnm[10] = spriteMatrix.GetFrame(8);
        tEnm[11] = spriteMatrix.GetFrame(7);        
        
        //Enemy Back
        tEnm[12] = spriteMatrix.GetFrame(9);
        tEnm[13] = spriteMatrix.GetFrame(10);
        tEnm[14] = spriteMatrix.GetFrame(11);
        tEnm[15] = spriteMatrix.GetFrame(10);
        
        enemyBansheeFrames = new MmgSprite(tEnm, tmpPos);
        enemyBansheeFrames.SetMsPerFrame(tmp);
        
        //Load enemy warlock frames
        spriteMatrixSrc = MmgHelper.GetBasicCachedBmp("enemy_warlock_spritematrix_w_shadow.png");
        spriteMatrixSrc = MmgBmpScaler.ScaleMmgBmp(spriteMatrixSrc, 1.5f, true);
        
        MmgHelper.CenterHor(spriteMatrixSrc);
        spriteMatrixSrc.SetPosition(new MmgVector2(25, MmgHelper.ScaleValue(160)));        
        spriteMatrix = new MmgSpriteMatrix(spriteMatrixSrc.CloneTyped(), 48, 51, 4, 3);        
        tmpObj = new MmgObj();
        tmpObj.SetHeight(68);
        tmpObj.SetWidth(64);
        MmgHelper.CenterHorAndVert(tmpObj);
        
        tmpPos = tmpObj.GetPosition().Clone();
        tmpPos.SetY(tmpPos.GetY() + MmgHelper.ScaleValue(15));
        tmpPos.SetX(MmgScreenData.GetGameWidth() - 64 - 25);
        
        tEnm = new MmgBmp[16];
        //Enemy Front
        tEnm[0] = spriteMatrix.GetFrame(0);
        tEnm[1] = spriteMatrix.GetFrame(1);
        tEnm[2] = spriteMatrix.GetFrame(2);
        tEnm[3] = spriteMatrix.GetFrame(1);
        
        //Enemy Left
        tEnm[4] = spriteMatrix.GetFrame(3);
        tEnm[5] = spriteMatrix.GetFrame(4);
        tEnm[6] = spriteMatrix.GetFrame(5);
        tEnm[7] = spriteMatrix.GetFrame(4);                
        
        //Enemy Right
        tEnm[8] = spriteMatrix.GetFrame(6);
        tEnm[9] = spriteMatrix.GetFrame(7);
        tEnm[10] = spriteMatrix.GetFrame(8);
        tEnm[11] = spriteMatrix.GetFrame(7);        
        
        //Enemy Back
        tEnm[12] = spriteMatrix.GetFrame(9);
        tEnm[13] = spriteMatrix.GetFrame(10);
        tEnm[14] = spriteMatrix.GetFrame(11);
        tEnm[15] = spriteMatrix.GetFrame(10);
        
        enemyWarlockFrames = new MmgSprite(tEnm, tmpPos);
        enemyWarlockFrames.SetMsPerFrame(tmp);        
        
        //Load string exit config
        key = "strExitText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Press B to Exit";
        }        
        exit = MmgFontData.CreateDefaultBoldMmgFontLg();
        exit.SetText(file);
        exit.SetMmgColor(MmgColor.GetRed());
        exit.SetPosition((BOARD_WIDTH - exit.GetWidth())/2 + MmgHelper.ScaleValue(22), screenPos.GetY() + exit.GetHeight() + MmgHelper.ScaleValue(5));
        exit = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("exitText", exit, classConfig, exit.GetPosition().Clone());
                
        //Load exit text background config
        key = "exitTextBgroundWidth";
        if(classConfig.containsKey(key)) {
            tmpW = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
        } else {
            tmpW = exit.GetWidth() + (padding * 2);
        }
        
        key = "exitTextBgroundHeight";
        if(classConfig.containsKey(key)) {
            tmpH = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
        } else {
            tmpH = exit.GetHeight() + (padding * 2);
        }        
        
        exitBground = MmgHelper.CreateFilledBmp(tmpW, tmpH, MmgColor.GetBlack());
        exitBground.SetPosition(exit.GetX() - padding, exit.GetY() - exit.GetHeight());
        exitBground = (MmgBmp)MmgHelper.ContainsKeyMmgObjPosition("exitTextBground", exitBground, classConfig, exitBground.GetPosition().Clone());
        AddObj(exitBground);        
        AddObj(exit);
                           
        txtPlayer1 = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer1.SetText("Player1:");
        txtPlayer1.SetPosition(new MmgVector2(MmgHelper.ScaleValue(30), GAME_BOTTOM - MmgHelper.ScaleValue(8)));       
        AddObj(txtPlayer1);
                
        txtPlayer2 = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer2.SetText("Player2:");
        txtPlayer2.SetPosition(new MmgVector2(BOARD_RIGHT - MmgHelper.ScaleValue(250) - txtPlayer2.GetWidth(), GAME_BOTTOM - MmgHelper.ScaleValue(8)));      
        AddObj(txtPlayer2);        
                       
        gameLogo = MmgHelper.GetBasicCachedBmp("mdt_game_title.png");
        gameLogo = MmgBmpScaler.ScaleMmgBmp(gameLogo, 0.28, true);
        gameLogo.SetPosition(new MmgVector2(GAME_RIGHT - MmgHelper.ScaleValue(115), GetY() + MmgHelper.ScaleValue(20)));
        AddObj(gameLogo);
        
        txtLevel = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtLevel.SetText("Level: 00");
        txtLevel.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), gameLogo.GetY() + gameLogo.GetHeight() + MmgHelper.ScaleValue(20)));               
        AddObj(txtLevel);        
        
        txtLevelTime = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtLevelTime.SetText("Time: 000");
        txtLevelTime.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtLevel.GetY() + txtLevel.GetHeight() + MmgHelper.ScaleValue(10)));               
        AddObj(txtLevelTime);        
        
        txtPlayer1Section = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer1Section.SetText("- Player1 -");
        txtPlayer1Section.SetPosition(new MmgVector2(GAME_RIGHT - txtPlayer1Section.GetWidth() - MmgHelper.ScaleValue(16), txtLevelTime.GetY() + txtLevelTime.GetHeight() + MmgHelper.ScaleValue(20)));       
        AddObj(txtPlayer1Section);         
        
        txtPlayer1Weapon = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer1Weapon.SetText("W:");
        txtPlayer1Weapon.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer1Section.GetY() + txtPlayer1Section.GetHeight() + MmgHelper.ScaleValue(10)));       
        AddObj(txtPlayer1Weapon);                 
        
        player1WeaponBmp.SetPosition(txtPlayer1Weapon.GetPosition().Clone());
        player1WeaponBmp.SetPosition(player1WeaponBmp.GetPosition().GetX() + txtPlayer1Weapon.GetWidth() + MmgHelper.ScaleValue(5), player1WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                        
        txtPlayer1Mod = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer1Mod.SetText("M:");
        txtPlayer1Mod.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer1Weapon.GetY() + txtPlayer1Weapon.GetHeight() + MmgHelper.ScaleValue(10)));       
        AddObj(txtPlayer1Mod);
                
        txtPlayer1ModTime = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer1ModTime.SetText("MT:");
        txtPlayer1ModTime.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer1Mod.GetY() + txtPlayer1Mod.GetHeight() + MmgHelper.ScaleValue(10)));       
        AddObj(txtPlayer1ModTime);
                
        txtPlayer2Section = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer2Section.SetText("- Player2 -");
        txtPlayer2Section.SetPosition(new MmgVector2(GAME_RIGHT - txtPlayer2Section.GetWidth() - MmgHelper.ScaleValue(16), txtPlayer1ModTime.GetY() + txtPlayer1ModTime.GetHeight() + MmgHelper.ScaleValue(20)));       
        AddObj(txtPlayer2Section);          
        
        txtPlayer2Weapon = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer2Weapon.SetText("W:");
        txtPlayer2Weapon.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer2Section.GetY() + txtPlayer2Section.GetHeight() + MmgHelper.ScaleValue(10)));       
        AddObj(txtPlayer2Weapon);                 
        
        player2WeaponBmp.SetPosition(txtPlayer2Weapon.GetPosition().Clone());
        player2WeaponBmp.SetPosition(player2WeaponBmp.GetPosition().GetX() + txtPlayer2Weapon.GetWidth() + MmgHelper.ScaleValue(5), player2WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                
        txtPlayer2Mod = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer2Mod.SetText("M:");
        txtPlayer2Mod.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer2Weapon.GetY() + txtPlayer2Weapon.GetHeight() + MmgHelper.ScaleValue(10)));       
        AddObj(txtPlayer2Mod);                
                
        txtPlayer2ModTime = MmgFontData.CreateDefaultBoldMmgFontSm();
        txtPlayer2ModTime.SetText("MT:");
        txtPlayer2ModTime.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer2Mod.GetY() + txtPlayer2Mod.GetHeight() + MmgHelper.ScaleValue(10)));       
        AddObj(txtPlayer2ModTime);        
                        
        //Load number one config
        key = "bmpNumberOne";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "num_1_lrg.png";
        }        
        lval = MmgHelper.GetBasicCachedBmp(file);
        
        MmgBmp tlval = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
        numberBground = new Mmg9Slice(MmgHelper.ScaleValue(16), tlval, lval.GetWidth() + MmgHelper.ScaleValue(12), lval.GetHeight() + MmgHelper.ScaleValue(12));
        MmgHelper.CenterHorAndVert(numberBground);
        AddObj(numberBground);         
                
        number1 = lval;
        if(number1 != null) {
            MmgHelper.CenterHorAndVert(number1);
            pos = number1.GetPosition().Clone();
            number1 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberOne", number1, classConfig, pos);
            number1.SetIsVisible(false);
            AddObj(number1);
        }
                
        //Load number two config
        key = "bmpNumberTwo";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "num_2_lrg.png";
        }         
        lval = MmgHelper.GetBasicCachedBmp(file);
        number2 = lval;
        if(number2 != null) {
            MmgHelper.CenterHorAndVert(number2);
            pos = number2.GetPosition().Clone();
            number2 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberTwo", number2, classConfig, pos);
            number2.SetIsVisible(false);
            AddObj(number2);
        }
                
        //Load number three config
        key = "bmpNumberThree";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "num_3_lrg.png";
        }        
        lval = MmgHelper.GetBasicCachedBmp(file);
        number3 = lval;        
        if(number3 != null) {
            MmgHelper.CenterHorAndVert(number3);
            pos = number3.GetPosition().Clone();
            number3 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberThree", number3, classConfig, pos);
            number3.SetIsVisible(false);
            AddObj(number3);
        }

        //Load string game win config
        key = "strGoalText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Goal: Survive for as long as you can!";
        }         
        txtGoal = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGoal.SetText(file);
        txtGoal.SetMmgColor(MmgColor.GetWhite());        
        MmgHelper.CenterHorAndVert(txtGoal);
        txtGoal.SetY(number1.GetY() - txtGoal.GetHeight() + MmgHelper.ScaleValue(5));
        pos = txtGoal.GetPosition().Clone();
        txtGoal = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("goalText", txtGoal, classConfig, pos);
        txtGoal.SetIsVisible(false);
        AddObj(txtGoal);
                
        //Load string player 1 direction config
        key = "strPlayer1DirectionText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 1: Red visor, D-PAD to move, '.' to attack, '/' to exit.";
        }        
        txtDirecP1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtDirecP1.SetText(file);
        txtDirecP1.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtDirecP1);
        txtDirecP1.SetY(number1.GetY() + number1.GetHeight() + txtDirecP1.GetHeight() + MmgHelper.ScaleValue(10));
        pos = txtDirecP1.GetPosition().Clone();
        txtDirecP1 = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("player1DirectionText", txtDirecP1, classConfig, pos);
        txtDirecP1.SetIsVisible(false);
        AddObj(txtDirecP1);
                
        //Load string player 2 direction config
        key = "strPlayer2DirectionText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 2: Green visor, 's', 'x', 'z', 'c' to move, 'f' to attack, 'v' to exit.";
        }        
        txtDirecP2 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtDirecP2.SetText(file);
        txtDirecP2.SetMmgColor(MmgColor.GetWhite());
        MmgHelper.CenterHorAndVert(txtDirecP2);
        txtDirecP2.SetY(txtDirecP1.GetY() + txtDirecP1.GetHeight() + MmgHelper.ScaleValue(10));
        pos = txtDirecP2.GetPosition().Clone();
        txtDirecP2 = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("player2DirectionText", txtDirecP2, classConfig, pos);
        txtDirecP2.SetIsVisible(false);        
        AddObj(txtDirecP2);
                
        //Load game over player 1 config
        key = "strTextGameOver1";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 1 has won the game! Press ('a', '.') or ('b', '/') to exit.";
        }        
        txtGameOver1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGameOver1.SetText(file);
        txtGameOver1.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtGameOver1);
        pos = txtGameOver1.GetPosition().Clone();
        txtGameOver1 = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("textGameOver1", txtGameOver1, classConfig, pos);
        txtGameOver1.SetIsVisible(false);
        AddObj(txtGameOver1);
                
        //Load game over player 2 config
        key = "strTextGameOver2";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 2 has won the game! Press ('a', 'f') or ('b', 'v') to exit.";
        }        
        txtGameOver2 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGameOver2.SetText(file);
        txtGameOver2.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtGameOver2);
        pos = txtGameOver2.GetPosition().Clone();
        txtGameOver2 = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("textGameOver2", txtGameOver2, classConfig, pos);        
        txtGameOver2.SetIsVisible(false);
        AddObj(txtGameOver2);        
                
        //Load game over player 3 config
        key = "strTextGameOver3";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Game over! You ran out of time! Press ('a', 'f') or ('b', 'v') to exit.";
        }        
        txtGameOver3 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGameOver3.SetText(file);
        txtGameOver3.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtGameOver3);
        pos = txtGameOver3.GetPosition().Clone();
        txtGameOver3 = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("textGameOver3", txtGameOver3, classConfig, pos);        
        txtGameOver3.SetIsVisible(false);
        AddObj(txtGameOver3);        
        
        //Load popup base
        key = "bmpPopupWindowBase";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "popup_window_base.png";
        }        
        lval = MmgHelper.GetBasicCachedBmp(file);
        bgroundPopupSrc = lval;        
        if(bgroundPopupSrc != null) {
            bgroundPopup = new Mmg9Slice(16, bgroundPopupSrc, popupTotalWidth, popupTotalHeight);
            bgroundPopup.SetPosition(MmgVector2.GetOriginVec());
            
            key = "popupWindowBaseWidth";
            if(classConfig.containsKey(key)) {
                tmpW = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
            } else {
                tmpW = popupTotalWidth;
            }
            bgroundPopup.SetWidth(tmpW);
            
            key = "popupWindowBaseHeight";
            if(classConfig.containsKey(key)) {
                tmpH = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
            } else {
                tmpH = popupTotalHeight;
            }                        
            bgroundPopup.SetHeight(tmpH);
            
            MmgHelper.CenterHorAndVert(bgroundPopup);
            pos = bgroundPopup.GetPosition().Clone();
            bgroundPopup = (Mmg9Slice)MmgHelper.ContainsKeyMmgObjPosition("popupWindowBase", bgroundPopup, classConfig, pos);
            
            AddObj(bgroundPopup);
            bgroundPopup.SetIsVisible(false);
            
            numberBground.SetIsVisible(false);
            
            MdtWeaponSpear wspr = new MdtWeaponSpear(player1, MdtWeaponType.SPEAR, MdtPlayerType.PLAYER_1);
            wspr.SetScreen(this);
            wspr.SetAttackType(MdtWeaponAttackType.STABBING);
            wspr.SetPosition(100, BOARD_TOP + 50);
            wspr.GetSubjRight().SetPosition(100, BOARD_TOP + 50);
            AddObj(wspr.GetSubjRight());
            
            MdtWeaponSword wswd = new MdtWeaponSword(player1, MdtWeaponType.SWORD, MdtPlayerType.PLAYER_1);
            wswd.SetScreen(this);
            wswd.SetAttackType(MdtWeaponAttackType.STABBING);
            wswd.SetPosition(100, BOARD_TOP + 100);
            wswd.GetSubjRight().SetPosition(100, BOARD_TOP + 100);
            AddObj(wswd.GetSubjRight());

            MdtWeaponAxe waxe= new MdtWeaponAxe(player1, MdtWeaponType.AXE, MdtPlayerType.PLAYER_1);
            waxe.SetScreen(this);
            waxe.SetAttackType(MdtWeaponAttackType.STABBING);
            waxe.SetPosition(100, BOARD_TOP + 150);
            waxe.GetSubjRight().SetPosition(100, BOARD_TOP + 150);
            AddObj(waxe.GetSubjRight());             
            
            MdtItemBomb bomb = new MdtItemBomb();
            bomb.SetScreen(this);
            bomb.SetPosition(200, BOARD_TOP + 50);
            AddObj(bomb);
            
            MdtItemCoinBag cbag = new MdtItemCoinBag();
            cbag.SetScreen(this);
            cbag.SetPosition(200, BOARD_TOP + 100);
            AddObj(cbag);
            
            MdtItemChest chst = new MdtItemChest();
            chst.SetScreen(this);
            chst.SetPosition(200, BOARD_TOP + 150);
            AddObj(chst);
            
            MdtItemPotionGreen potion1 = new MdtItemPotionGreen();
            potion1.SetScreen(this);
            potion1.SetPosition(300, BOARD_TOP + 50);
            AddObj(potion1);
            
            MdtItemPotionRed potion2 = new MdtItemPotionRed();
            potion2.SetScreen(this);
            potion2.SetPosition(300, BOARD_TOP + 100);
            AddObj(potion2);
            
            MdtItemPotionYellow potion3 = new MdtItemPotionYellow();
            potion3.SetScreen(this);
            potion3.SetPosition(300, BOARD_TOP + 150);
            AddObj(potion3);
            
            MdtObjPushBarrel barrel = new MdtObjPushBarrel(this);
            barrel.SetScreen(this);
            barrel.SetPosition(450, BOARD_TOP + 50);
            AddObj(barrel);
            
            MdtObjPushTableSmall table1 = new MdtObjPushTableSmall(this);
            table1.SetScreen(this);
            table1.SetPosition(450, BOARD_TOP + 100);
            AddObj(table1);
            
            MdtObjPushTableLarge table2 = new MdtObjPushTableLarge(this);
            table2.SetScreen(this);
            table2.SetPosition(450, BOARD_TOP + 150);
            AddObj(table2);
            
            MdtCharInterDemon dmn1 = new MdtCharInterDemon(enemyDemonFrames.CloneTyped(), 0, 3, 12, 15, 4, 7, 8, 11, this);
            dmn1.SetScreen(this);
            dmn1.SetPosition(600, BOARD_TOP + 50);
            AddObj(dmn1);
            
            MdtCharInterWarlock dmn2 = new MdtCharInterWarlock(enemyWarlockFrames.CloneTyped(), 0, 3, 12, 15, 4, 7, 8, 11, this);
            dmn2.SetScreen(this);
            dmn2.SetPosition(600, BOARD_TOP + 100);
            AddObj(dmn2);            
            
            MdtCharInterBanshee dmn3 = new MdtCharInterBanshee(enemyBansheeFrames.CloneTyped(), 0, 3, 12, 15, 4, 7, 8, 11, this);
            dmn3.SetScreen(this);
            dmn3.SetPosition(600, BOARD_TOP + 150);
            AddObj(dmn3);           
        }
                
        //Load popup window text exit
        key = "strPopupWindowTextExit";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Exit Game ('A', 'F', '.')";
        }
        txtOk = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtOk.SetText(file);
        txtOk.SetMmgColor(MmgColor.GetWhite());        
        MmgHelper.CenterHorAndVert(txtOk);
        txtOk.SetY(bgroundPopup.GetY() + txtOk.GetHeight() + MmgHelper.ScaleValue(20));
        pos = txtOk.GetPosition().Clone();
        txtOk = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("popupWindowTextExit", txtOk, classConfig, pos);
        txtOk.SetIsVisible(false);
        AddObj(txtOk);
                
        //Load popup window text cancel
        key = "strPopupWindowTextCancel";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Cancel Exit ('B', 'V', '/')";
        }
        txtCancel = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtCancel.SetText(file);
        txtCancel.SetMmgColor(MmgColor.GetWhite()); 
        MmgHelper.CenterHorAndVert(txtCancel);
        txtCancel.SetY(txtOk.GetY() + txtOk.GetHeight() + MmgHelper.ScaleValue(20));
        pos = txtCancel.GetPosition().Clone();
        txtCancel = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("popupWindowTextCancel", txtCancel, classConfig, pos);
        txtCancel.SetIsVisible(false);
        AddObj(txtCancel);        
                
        wavesCurrentIdx = 0;
        ready = true;
        pause = false;
    }
   
    /**
     * Sets the current game type.
     * 
     * @param gt    The specified game type.
     */
    public void SetGameType(GameType gt) {
        gameType = gt;
    }
    
    /**
     * Gets the current game type
     * 
     * @return      The specified game type. 
     */
    public GameType GetGameType() {
        return gameType;
    }
    
    /**
     * Converts the given speed to a uniform speed per frame so that the game movement will
     * be the same even if the game runs at different frame rates.
     * 
     * @param speed     The target speed to convert to a speed per frame.
     * @return          A converted speed that represents the speed per frame of the given input speed. 
     */
    public static int GetSpeedPerFrame(int speed) {
        return (int)(speed/(DungeonTrap.FPS - 4));        
    }
            
    /**
     * A method to handle B button click events from the MainFrame class.
     * 
     * @param src   The player source of the input.
     * @return      A boolean indicating if this Screen has handled the B click event.
     */    
    @Override
    public boolean ProcessBClick(int src) {
        if(pause || !isVisible) {
            return false;
        }        
        
        owner.SwitchGameState(GameStates.MAIN_MENU);
        return true;
    }
    
    /**
     * A method to handle debug click events from the MainFrame class, the D key on the keyboard.
     * You can use this method to turn on different debugging helpers.
     */
    @Override
    public void ProcessDebugClick() {
        randomWaves = !randomWaves;
        MmgHelper.wr("RandomWaves: " + randomWaves);
    }

    /**
     * Clears objects from the screens object collection and the items, objects, and enemies containers.
     */
    private void UpdateClearObjects() {
        MmgContainer c = GetObjects();
        int len = c.GetCount();
        MmgObj obj = null;
        for(int i = 0; i  < len; i++) {
            obj = c.GetChildAt(i);
            if(obj instanceof MdtItemChest || obj instanceof MdtCharInterWarlock || obj instanceof MdtCharInterBanshee || obj instanceof MdtCharInterDemon || obj instanceof MdtWeapon || obj instanceof MdtObjPushTableSmall || obj instanceof MdtObjPushTableLarge || obj instanceof MdtObjPushBarrel || obj instanceof MdtItemBomb || obj instanceof MdtItemCoinBag || obj instanceof MdtItemPotionGreen || obj instanceof MdtItemPotionRed || obj instanceof MdtItemPotionYellow) {
                c.RemoveAt(i);
                len--;
                i--;
            }
        }
        gameObjects.Clear();
        gameItems.Clear();
        gameEnemies.Clear();
    }    
    
    /**
     * Unloads resources needed to display this game screen.
     */
    @Override
    public void UnloadResources() {
        pause = true;

        SetBackground(null);        
        state = State.NONE;
        statePrev = State.NONE;
        UpdateClearObjects();
        
        bground = null;
        doorLockFull = null;
        doorOpenFull = null;
        doorLockIcon = null;
        doorTopLeftLocked = null;
        doorTopLeftOpened = null;
        doorTopRightLocked = null;
        doorTopRightOpened = null;
        doorLeftLockIcon = null;
        doorRightLockIcon = null;
        doorBotLeftLockIcon = null;
        doorBotRightLockIcon = null;
        torch1 = null;
        torch2 = null;
        torch3 = null;
        torch4 = null;
        randoLeft = null;
        randoRight = null;
        gameItems = null;
        gameObjects = null;
        gameEnemies = null;
        player1 = null;
        player1WeaponBmp = null;
        player2 = null;
        player2WeaponBmp = null;
        spriteMatrixSrc = null;
        enemyDemonFrames = null;
        spriteMatrix = null;
        enemyBansheeFrames = null;
        enemyWarlockFrames = null;
        exit = null;
        classConfig = null;
        exitBground = null;
        txtPlayer1 = null;
        txtPlayer1Score = null;
        txtPlayer2 = null;
        txtPlayer2Score = null;
        gameLogo = null;
        txtLevel = null;
        txtLevelTime = null;
        txtPlayer1Section = null;
        txtPlayer1Weapon = null;
        txtPlayer1Mod = null;
        txtPlayer1ModTime = null;
        txtPlayer2Section = null;
        txtPlayer2Weapon = null;
        txtPlayer2Mod = null;
        txtPlayer2ModTime = null;
        numberBground = null;
        number1 = null;
        number2 = null;
        number3 = null;
        txtGoal = null;
        pos = null;
        txtDirecP1 = null;
        txtDirecP2 = null;
        txtGameOver1 = null;
        txtGameOver2 = null;
        txtGameOver3 = null;
        bgroundPopupSrc = null;
        txtOk = null;
        txtCancel = null;
        
        ClearObjs();
        super.UnloadResources();
        
        ready = false;
    }

   /**
     * The MmgUpdate method used to call the update method of the child objects.
     * 
     * @param updateTick            The update tick number. 
     * @param currentTimeMs         The current time in the game in milliseconds.
     * @param msSinceLastFrame      The number of milliseconds between the last frame and this frame.
     * @return                      A boolean indicating if any work was done this game frame.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = super.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
        if (pause == false && isVisible == true) {
            if(state == State.SHOW_GAME) {

            }
            lret = true;
        }        
        return lret;
    }
    
    /**
     * The main drawing routine.
     *
     * @param p An MmgPen object to use for drawing this game screen.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (pause == false && isVisible == true) {
            super.GetObjects().MmgDraw(p);
        }
    }
        
    @Override
    public void RemoveObj(MmgObj obj) {
    }
    
    public void UpdateRemoveObj(MdtBase obj, MdtPlayerType p) {
    }
    
    public MdtBase CanMove(MmgRect r, MdtBase iO) {
        return null;
    }
    
    public void UpdateProcessCollision(MdtBase o1, MdtBase o2) {
    }
    
    public void UpdateProcessWeaponCollision(MdtBase o1, MdtBase o2, MmgRect weapon) {
    }
    
    public void UpdateClearPlayerMod(MdtPlayerType p) {
    }
    
    public MdtBase UpdateGenerateItem(int x, int y) {
        return null;
    }
    
    public MmgVector2 GetPlayer1Pos() {
        return null;
    }
    
    public boolean GetPlayer1Broken() {
        return false;
    }
    
    public MmgVector2 GetPlayer2Pos() {
        return null;
    }
    
    public boolean GetPlayer2Broken() {
        return false;
    }    
}