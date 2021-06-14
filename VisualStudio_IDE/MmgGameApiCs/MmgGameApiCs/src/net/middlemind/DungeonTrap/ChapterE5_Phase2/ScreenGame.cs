using System;
using Microsoft.Xna.Framework;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.DungeonTrap.ChapterE5_Phase2
{
    /// <summary>
    /// A game screen object, ScreenGame, that extends the MmgGameScreen base
    /// class. This class is for testing new UI widgets, etc.
    ///
    /// @author Victor G.Brusca
    /// 03/15/2020
    /// </summary>
    public class ScreenGame : Screen
    {
        /// <summary>
        /// An enumeration that tracks which number is visible during game start countdown and in-game countdown.
        /// </summary>
        private enum NumberState
        {
            NONE,
            NUMBER_1,
            NUMBER_2,
            NUMBER_3
        };

        /// <summary>
        /// An enumeration that tracks which state this Screen is currently rendering.
        /// Allows the Screen to support different views like in-game, countdown, game over, game start, etc.
        /// </summary>
        private enum State
        {
            NONE,
            SHOW_GAME,
            SHOW_COUNT_DOWN,
            SHOW_COUNT_DOWN_IN_GAME,
            SHOW_GAME_OVER,
            SHOW_GAME_EXIT
        };

        /// <summary>
        /// The type of game to run.
        /// </summary>
        private GameType gameType = GameType.GAME_ONE_PLAYER;

        /// <summary>
        /// The previous game state. 
        /// </summary>
        private State statePrev = State.NONE;

        /// <summary>
        /// The current game state.
        /// </summary>
        private new State state = State.NONE;

        /// <summary>
        /// The current state of the count down number.
        /// </summary>
        private NumberState numberState = NumberState.NONE;

        /// <summary>
        /// The display time of the number in milliseconds.
        /// </summary>
        private long timeNumberMs = 0L;

        /// <summary>
        /// The total display time of the number in milliseconds.
        /// </summary>
        private long timeNumberDisplayMs = 1000;

        /// <summary>
        /// A number display temporary value.
        /// </summary>
        private long timeTmpMs = 0L;

        /// <summary>
        /// The background of the game.
        /// </summary>
        private MmgBmp bground;

        /// <summary>
        /// The count down number 1.
        /// </summary>
        private MmgBmp number1;

        /// <summary>
        /// The count down number 2.
        /// </summary>
        private MmgBmp number2;

        /// <summary>
        /// The count down number 3.
        /// </summary>
        private MmgBmp number3;

        /// <summary>
        /// A bool indicating if the level's time is up.
        /// </summary>
        private bool scoreTimeUp = false;

        /// <summary>
        /// The player one score.
        /// </summary>
        private int scorePlayerOne = 0;

        /// <summary>
        /// The player two score.
        /// </summary>
        private int scorePlayerTwo = 0;

        /// <summary>
        /// A text image for the exit string.
        /// </summary>
        private MmgFont exit;

        /// <summary>
        /// A background for the text exit image.
        /// </summary>
        private MmgBmp exitBground;

        /// <summary>
        /// A random number generator.
        /// </summary>
        private Random rand;

        /// <summary>
        /// The current position of the screen.
        /// </summary>
        private MmgVector2 screenPos;

        /// <summary>
        /// The source of the popup background image. 
        /// </summary>
        private MmgBmp bgroundPopupSrc;

        /// <summary>
        /// The popup background image. 
        /// </summary>
        private Mmg9Slice bgroundPopup;

        /// <summary>
        /// A text image for the ok string. 
        /// </summary>
        private MmgFont txtOk;

        /// <summary>
        /// A text image for the cancel string.
        /// </summary>
        private MmgFont txtCancel;

        /// <summary>
        /// A text image for the game's goal string. 
        /// </summary>
        private MmgFont txtGoal;

        /// <summary>
        /// A text image for the game's player one directions.
        /// </summary>
        private MmgFont txtDirecP1;

        /// <summary>
        /// A text image for the game's player two directions. 
        /// </summary>
        private MmgFont txtDirecP2;

        /// <summary>
        /// A text image for the game over text player one. 
        /// </summary>
        private MmgFont txtGameOver1;

        /// <summary>
        /// A text image for the game over text player two. 
        /// </summary>
        private MmgFont txtGameOver2;

        /// <summary>
        /// A text image for the game over time ran out message. 
        /// </summary>
        private MmgFont txtGameOver3;

        /// <summary>
        /// A padding value used in UI positioning.
        /// </summary>
        private int padding = MmgHelper.ScaleValue(4);

        /// <summary>
        /// The total width of the popup window.
        /// </summary>
        private int popupTotalWidth = MmgHelper.ScaleValue(300);

        /// <summary>
        /// The total height of the popup window.
        /// </summary>
        private int popupTotalHeight = MmgHelper.ScaleValue(120);

        /// <summary>
        /// The player one character.
        /// </summary>
        private MdtCharInterPlayer player1;

        /// <summary>
        /// The player two character.
        /// </summary>
        private MdtCharInterPlayer player2;

        /// <summary>
        /// A private bool value used in internal class methods.
        /// </summary>
        private bool lret;

        /// <summary>
        /// The top of the game.
        /// </summary>
        public static int GAME_TOP = MmgScreenData.GetGameTop();

        /// <summary>
        /// The top of the game's board.
        /// </summary>
        public static int BOARD_TOP = GAME_TOP + MmgHelper.ScaleValue(106);

        /// <summary>
        /// The bottom of the game. 
        /// </summary>
        public static int GAME_BOTTOM = MmgScreenData.GetGameBottom();

        /// <summary>
        /// The bottom of the game's board.
        /// </summary>
        public static int BOARD_BOTTOM = GAME_BOTTOM - MmgHelper.ScaleValue(56);

        /// <summary>
        /// The left of the game.
        /// </summary>
        public static int GAME_LEFT = MmgScreenData.GetGameLeft();

        /// <summary>
        /// The left of the game's board.
        /// </summary>
        public static int BOARD_LEFT = GAME_LEFT + MmgHelper.ScaleValue(20);

        /// <summary>
        /// The right of the game.
        /// </summary>
        public static int GAME_RIGHT = MmgScreenData.GetGameRight();

        /// <summary>
        /// The right of the game's board.
        /// </summary>
        public static int BOARD_RIGHT = GAME_RIGHT - MmgHelper.ScaleValue(132);

        /// <summary>
        /// The game's width.
        /// </summary>
        public static int GAME_WIDTH = GAME_RIGHT - GAME_LEFT;

        /// <summary>
        /// The game board's width.
        /// </summary>
        public static int BOARD_WIDTH = BOARD_RIGHT - BOARD_LEFT;

        /// <summary>
        /// The game's height.
        /// </summary>
        public static int GAME_HEIGHT = GAME_BOTTOM - GAME_TOP;

        /// <summary>
        /// The game board's height.
        /// </summary>
        public static int BOARD_HEIGHT = BOARD_BOTTOM - BOARD_TOP;

        /// <summary>
        /// The number of enemy waves in this game.
        /// </summary>
        public static int WAVE_COUNT = 12;

        /// <summary>
        /// The speed in milliseconds of the player character's frames when moving.
        /// </summary>
        public int frameMsPerFrameMoving = 100;

        /// <summary>
        /// The speed in milliseconds of the player character's frames when not moving.
        /// </summary>
        public int frameMsPerFrameNotMoving = 300;

        /// <summary>
        /// A bool indicating if the player snaps to the front direction.
        /// </summary>
        public bool playerSnapToFront = false;

        /// <summary>
        /// A UI health bar for the player one health.
        /// </summary>
        public MdtUiHealthBar player1HealthBar = null;

        /// <summary>
        /// A UI health bar for the player two health.
        /// </summary>
        public MdtUiHealthBar player2HealthBar = null;

        /// <summary>
        /// An MmgBmp images used to represent the source of a sprite matrix.
        /// </summary>
        private MmgBmp spriteMatrixSrc;

        /// <summary>
        /// An MmgSpriteMatrix instance used to hold sprite matrix data.
        /// </summary>
        private MmgSpriteMatrix spriteMatrix;

        /// <summary>
        /// An MmgSprite instance used to hold sprite data.
        /// </summary>
        private MmgSprite sprite;

        /// <summary>
        /// A private field used to hold a Color value.
        /// </summary>
        private Color c;

        /// <summary>
        /// A text representation of player 1.
        /// </summary>
        public MmgFont txtPlayer1 = null;

        /// <summary>
        /// A text representation of player 2.
        /// </summary>
        public MmgFont txtPlayer2 = null;

        /// <summary>
        /// A text representation of player 2's score.
        /// </summary>
        public MmgFont txtPlayer1Score = null;

        /// <summary>
        /// A text representation of player 2's score.
        /// </summary>
        public MmgFont txtPlayer2Score = null;

        /// <summary>
        /// A text element for the player 1 HUD section.
        /// </summary>
        public MmgFont txtPlayer1Section = null;

        /// <summary>
        /// A text element for the player 2 HUD section.
        /// </summary>
        public MmgFont txtPlayer2Section = null;

        /// <summary>
        /// A text HUD UI element for player 1 weapons.
        /// </summary>
        public MmgFont txtPlayer1Weapon = null;

        /// <summary>
        /// A text HUD UI element for player 2 weapons.
        /// </summary>
        public MmgFont txtPlayer2Weapon = null;

        /// <summary>
        /// A text HUD UI element for player 1 modifications.
        /// </summary>
        public MmgFont txtPlayer1Mod = null;

        /// <summary>
        /// A text HUD UI element for player 2 modifications.
        /// </summary>
        public MmgFont txtPlayer2Mod = null;

        /// <summary>
        /// A text representation of the player 1 modifier time.
        /// </summary>
        public MmgFont txtPlayer1ModTime = null;

        /// <summary>
        /// A text representation of the player 2 modifier time.
        /// </summary>
        public MmgFont txtPlayer2ModTime = null;

        /// <summary>
        /// A text representation of the current level time.
        /// </summary>
        public MmgFont txtLevelTime = null;

        /// <summary>
        /// A text representation of the current level.
        /// </summary>
        public MmgFont txtLevel = null;

        /// <summary>
        /// The game logo to use on the main menu and game board.
        /// </summary>
        public MmgBmp gameLogo = null;

        /// <summary>
        /// An array of enemy waves. 
        /// </summary>
        private MdtEnemyWave[] waves;

        /// <summary>
        /// The current enemy wave.
        /// </summary>
        private MdtEnemyWave wavesCurrent;

        /// <summary>
        /// The first background torch.
        /// </summary>
        private MdtObjTorch torch1;

        /// <summary>
        /// The second background torch.
        /// </summary>
        private MdtObjTorch torch2;

        /// <summary>
        /// The third background torch.
        /// </summary>
        private MdtObjTorch torch3;

        /// <summary>
        /// The fourth background torch.
        /// </summary>
        private MdtObjTorch torch4;

        /// <summary>
        /// The current enemy wave index.
        /// </summary>
        private int wavesCurrentIdx;

        /// <summary>
        /// Source ID for player 1 input.
        /// </summary>
        public static int SRC_PLAYER_1 = GameSettings.SRC_KEYBOARD;

        /// <summary>
        /// Source ID for player 2 input.
        /// </summary>
        public static int SRC_PLAYER_2 = 255;

        /// <summary>
        /// Player 1 HUD weapon image.
        /// </summary>
        public MmgBmp player1WeaponBmp;

        /// <summary>
        /// Player 1 HUD modifier image.
        /// </summary>
        public MmgBmp player1ModBmp;

        /// <summary>
        /// Player 2 HUD weapon image.
        /// </summary>
        public MmgBmp player2WeaponBmp;

        /// <summary>
        /// Player 2 HUD modifier image.
        /// </summary>
        public MmgBmp player2ModBmp;

        /// <summary>
        /// Generic door lock full.
        /// </summary>
        public MmgBmp doorLockFull;

        /// <summary>
        /// Generic door open full.
        /// </summary>
        public MmgBmp doorOpenFull;

        /// <summary>
        /// Generic door lock icon.
        /// </summary>
        public MmgBmp doorLockIcon;

        /// <summary>
        /// Door locked icon for the top left door.
        /// </summary>
        public MmgBmp doorTopLeftLocked;

        /// <summary>
        /// Door opened icon for the top left door.
        /// </summary>
        public MmgBmp doorTopLeftOpened;

        /// <summary>
        /// Lock icon for the left hand door.
        /// </summary>
        public MmgBmp doorLeftLockIcon;

        /// <summary>
        /// Door locked icon for the top right door. 
        /// </summary>
        public MmgBmp doorTopRightLocked;

        /// <summary>
        /// Door opened icon for the top right door. 
        /// </summary>
        public MmgBmp doorTopRightOpened;

        /// <summary>
        /// Lock icon for the right hand door.
        /// </summary>
        public MmgBmp doorRightLockIcon;

        /// <summary>
        /// Lock icon for the bottom left hand door.
        /// </summary>
        public MmgBmp doorBotLeftLockIcon;

        /// <summary>
        /// Lock icon for the bottom right hand door.
        /// </summary>
        public MmgBmp doorBotRightLockIcon;

        /// <summary>
        /// The random placement rectangle for the left hand side of the board.
        /// </summary>
        public MmgRect randoLeft = null;

        /// <summary>
        /// The random placement rectangle for the right hand side of the board. 
        /// </summary>
        public MmgRect randoRight = null;

        /// <summary>
        /// A background image used to frame the count down numbers. 
        /// </summary>
        public Mmg9Slice numberBground = null;

        /// <summary>
        /// A container that is used to hold object game objects. 
        /// </summary>
        public MmgContainer gameObjects = null;

        /// <summary>
        /// A container that is used to hold item game objects.
        /// </summary>
        public MmgContainer gameItems = null;

        /// <summary>
        /// A container that is used to hold enemy game objects.
        /// </summary>
        public MmgContainer gameEnemies = null;

        /// <summary>
        /// The image animation frames needed to display the demon enemy.
        /// </summary>
        private MmgSprite enemyDemonFrames = null;

        /// <summary>
        /// The image animation frames needed to display the banshee enemy. 
        /// </summary>
        private MmgSprite enemyBansheeFrames = null;

        /// <summary>
        /// The image animation frames needed to display the warlock enemy.
        /// </summary>
        private MmgSprite enemyWarlockFrames = null;

        /// <summary>
        /// The number of player characters that are still alive.
        /// </summary>
        private int playersAliveCount = 0;

        /// <summary>
        /// A bool indicating random level numbers are active.
        /// </summary>
        private bool randomWaves = false;

        /// <summary>
        /// A sound to play when an enemy character is struck with a weapon.
        /// </summary>
        private MmgSound sound1 = null;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets
        /// the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenGame(GameStates State, GamePanel Owner)
            : base(State, Owner)
        {
            pause = false;
            ready = false;
            owner = Owner;
            rand = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen and support all Screen states.
        /// </summary>
        public override void LoadResources()
        {
            pause = true;
            rand = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

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
            if (bground != null)
            {
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
            doorLeftLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(18 + doorLockIcon.GetWidth() / 2), MmgHelper.ScaleValue(adj + 206 + doorLockIcon.GetHeight() / 2)));
            AddObj(doorLeftLockIcon);

            doorRightLockIcon = doorLockIcon.CloneTyped();
            doorRightLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(690 + doorLockIcon.GetWidth() / 2), MmgHelper.ScaleValue(adj + 206 + doorLockIcon.GetHeight() / 2)));
            AddObj(doorRightLockIcon);

            doorBotLeftLockIcon = doorLockIcon.CloneTyped();
            doorBotLeftLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(154 + doorLockIcon.GetWidth() / 2), MmgHelper.ScaleValue(adj + 318 + doorLockIcon.GetHeight() / 2)));
            AddObj(doorBotLeftLockIcon);

            doorBotRightLockIcon = doorLockIcon.CloneTyped();
            doorBotRightLockIcon.SetPosition(new MmgVector2(MmgHelper.ScaleValue(474 + doorLockIcon.GetWidth() / 2), MmgHelper.ScaleValue(adj + 318 + doorLockIcon.GetHeight() / 2)));
            AddObj(doorBotRightLockIcon);

            //Load torches
            MdtObjTorch torch = new MdtObjTorch();
            torch.SetPosition(MmgHelper.ScaleValue(65) - torch.GetWidth() / 2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
            torch.isBurning = true;
            torch1 = torch;
            AddObj(torch1);

            torch = new MdtObjTorch();
            torch.SetPosition(MmgHelper.ScaleValue(290) - torch.GetWidth() / 2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
            torch.isBurning = true;
            torch2 = torch;
            AddObj(torch2);

            torch = new MdtObjTorch();
            torch.SetPosition(MmgHelper.ScaleValue(380) - torch.GetWidth() / 2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
            torch.isBurning = true;
            torch3 = torch;
            AddObj(torch3);

            torch = new MdtObjTorch();
            torch.SetPosition(MmgHelper.ScaleValue(610) - torch.GetWidth() / 2, MmgScreenData.GetGameTop() + MmgHelper.ScaleValue(50));
            torch.isBurning = true;
            torch4 = torch;
            AddObj(torch4);

            //Load random item drop rectangles
            randoLeft = new MmgRect(BOARD_LEFT + MmgHelper.ScaleValue(96), BOARD_TOP + MmgHelper.ScaleValue(64), BOARD_BOTTOM - MmgHelper.ScaleValue(64), BOARD_LEFT + BOARD_WIDTH / 2 - MmgHelper.ScaleValue(32));
            randoRight = new MmgRect(BOARD_LEFT + BOARD_WIDTH / 2 + MmgHelper.ScaleValue(64), BOARD_TOP + MmgHelper.ScaleValue(64), BOARD_BOTTOM - MmgHelper.ScaleValue(64), BOARD_RIGHT - MmgHelper.ScaleValue(96));

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
            for (int i = 0; i < frames.Length; i++)
            {
                file = MmgHelper.ContainsKeyString("bmpPlayer1Frame" + (i + 1), "soldier_frame_" + (i + 1) + ".png", classConfig);
                frames[i] = MmgHelper.GetBasicCachedBmp(file);

                if (frames[i] != null)
                {
                    frames[i] = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("bmpPlayer1Frame" + (i + 1), frames[i], classConfig, MmgVector2.GetOriginVec());
                }
                else
                {
                    MmgHelper.wr("ScreenGame: Error loading player1 frame " + i + ".");
                }
            }

            obj = new MmgObj(frames[0].GetWidth(), frames[0].GetHeight());
            MmgHelper.CenterHorAndVert(obj);
            obj.SetX(obj.GetX() - (GAME_WIDTH - BOARD_WIDTH) / 2 + obj.GetWidth());
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
            for (int i = 0; i < frames.Length; i++)
            {
                file = MmgHelper.ContainsKeyString("bmpPlayer2Frame" + (i + 1), "soldier_frame_" + (i + 1) + "_2p.png", classConfig);
                frames[i] = MmgHelper.GetBasicCachedBmp(file);

                if (frames[i] != null)
                {
                    frames[i] = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("bmpPlayer2Frame" + (i + 1), frames[i], classConfig, MmgVector2.GetOriginVec());
                }
                else
                {
                    MmgHelper.wr("ScreenGame: Error loading player2 frame " + i + ".");
                }
            }

            obj = new MmgObj(frames[0].GetWidth(), frames[0].GetHeight());
            MmgHelper.CenterHorAndVert(obj);
            obj.SetX(obj.GetX() - (GAME_WIDTH - BOARD_WIDTH) / 2 + obj.GetWidth());
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "Press B to Exit";
            }
            exit = MmgFontData.CreateDefaultBoldMmgFontLg();
            exit.SetText(file);
            exit.SetMmgColor(MmgColor.GetRed());
            exit.SetPosition((BOARD_WIDTH - exit.GetWidth()) / 2 + MmgHelper.ScaleValue(22), screenPos.GetY() + exit.GetHeight() + MmgHelper.ScaleValue(5));

            //C# Adjustment
            exit.SetY(exit.GetY() - MmgHelper.ScaleValue(5));
            exit = (MmgFont)MmgHelper.ContainsKeyMmgObjPosition("exitText", exit, classConfig, exit.GetPosition().Clone());

            //Load exit text background config
            key = "exitTextBgroundWidth";
            if (classConfig.ContainsKey(key))
            {
                tmpW = MmgHelper.ScaleValue((int)classConfig[key].number);
            }
            else
            {
                tmpW = exit.GetWidth() + (padding * 2);
            }

            key = "exitTextBgroundHeight";
            if (classConfig.ContainsKey(key))
            {
                tmpH = MmgHelper.ScaleValue((int)classConfig[key].number);
            }
            else
            {
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

            //C# Adjustment
            txtPlayer1.SetY(txtPlayer1.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer1);

            player1HealthBar = new MdtUiHealthBar(MdtPlayerType.PLAYER_1, this, MmgColor.GetRed());
            player1HealthBar.SetPosition(new MmgVector2(txtPlayer1.GetX() + txtPlayer1.GetWidth() + MmgHelper.ScaleValue(5), GAME_BOTTOM - player1HealthBar.GetHeight() - MmgHelper.ScaleValue(5)));
            AddObj(player1HealthBar);

            txtPlayer1Score = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer1Score.SetText("000000");
            txtPlayer1Score.SetPosition(new MmgVector2(player1HealthBar.GetX() + player1HealthBar.GetWidth() + MmgHelper.ScaleValue(5), GAME_BOTTOM - MmgHelper.ScaleValue(8)));
            AddObj(txtPlayer1Score);

            txtPlayer2 = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer2.SetText("Player2:");
            txtPlayer2.SetPosition(new MmgVector2(BOARD_RIGHT - MmgHelper.ScaleValue(250) - txtPlayer2.GetWidth(), GAME_BOTTOM - MmgHelper.ScaleValue(8)));

            //C# Adjustment
            txtPlayer2.SetY(txtPlayer2.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer2);

            player2HealthBar = new MdtUiHealthBar(MdtPlayerType.PLAYER_2, this, MmgColor.GetBlue());
            player2HealthBar.SetPosition(new MmgVector2(txtPlayer2.GetX() + txtPlayer2.GetWidth() + MmgHelper.ScaleValue(15), GAME_BOTTOM - player2HealthBar.GetHeight() - MmgHelper.ScaleValue(5)));
            AddObj(player2HealthBar);

            txtPlayer2Score = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer2Score.SetText("000000");
            txtPlayer2Score.SetPosition(new MmgVector2(player2HealthBar.GetX() + player2HealthBar.GetWidth() + MmgHelper.ScaleValue(5), GAME_BOTTOM - MmgHelper.ScaleValue(8)));
            AddObj(txtPlayer2Score);

            gameLogo = MmgHelper.GetBasicCachedBmp("mdt_game_title.png");
            gameLogo = MmgBmpScaler.ScaleMmgBmp(gameLogo, 0.28, true);
            gameLogo.SetPosition(new MmgVector2(GAME_RIGHT - MmgHelper.ScaleValue(115), GetY() + MmgHelper.ScaleValue(20)));
            AddObj(gameLogo);

            txtLevel = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtLevel.SetText("Level: 00");
            txtLevel.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), gameLogo.GetY() + gameLogo.GetHeight() + MmgHelper.ScaleValue(20)));

            //C# Adjustment
            txtLevel.SetY(txtLevel.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtLevel);

            txtLevelTime = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtLevelTime.SetText("Time: 000");
            txtLevelTime.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtLevel.GetY() + txtLevel.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            txtLevelTime.SetY(txtLevelTime.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtLevelTime);

            txtPlayer1Section = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer1Section.SetText("- Player1 -");
            txtPlayer1Section.SetPosition(new MmgVector2(GAME_RIGHT - txtPlayer1Section.GetWidth() - MmgHelper.ScaleValue(16), txtLevelTime.GetY() + txtLevelTime.GetHeight() + MmgHelper.ScaleValue(20)));

            //C# Adjustment
            txtPlayer1Section.SetY(txtPlayer1Section.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer1Section);

            txtPlayer1Weapon = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer1Weapon.SetText("W:");
            txtPlayer1Weapon.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer1Section.GetY() + txtPlayer1Section.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            //txtPlayer1Weapon.SetY(txtPlayer1Weapon.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer1Weapon);

            player1WeaponBmp.SetPosition(txtPlayer1Weapon.GetPosition().Clone());
            player1WeaponBmp.SetPosition(player1WeaponBmp.GetPosition().GetX() + txtPlayer1Weapon.GetWidth() + MmgHelper.ScaleValue(5), player1WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));

            txtPlayer1Mod = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer1Mod.SetText("M:");
            txtPlayer1Mod.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer1Weapon.GetY() + txtPlayer1Weapon.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            //txtPlayer1Mod.SetY(txtPlayer1Mod.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer1Mod);

            txtPlayer1ModTime = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer1ModTime.SetText("MT:");
            txtPlayer1ModTime.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer1Mod.GetY() + txtPlayer1Mod.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            txtPlayer1ModTime.SetY(txtPlayer1ModTime.GetY() + MmgHelper.ScaleValue(3));
            AddObj(txtPlayer1ModTime);

            txtPlayer2Section = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer2Section.SetText("- Player2 -");
            txtPlayer2Section.SetPosition(new MmgVector2(GAME_RIGHT - txtPlayer2Section.GetWidth() - MmgHelper.ScaleValue(16), txtPlayer1ModTime.GetY() + txtPlayer1ModTime.GetHeight() + MmgHelper.ScaleValue(20)));

            //C# Adjustment
            txtPlayer2Section.SetY(txtPlayer2Section.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer2Section);

            txtPlayer2Weapon = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer2Weapon.SetText("W:");
            txtPlayer2Weapon.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer2Section.GetY() + txtPlayer2Section.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            txtPlayer2Weapon.SetY(txtPlayer2Weapon.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer2Weapon);

            player2WeaponBmp.SetPosition(txtPlayer2Weapon.GetPosition().Clone());
            player2WeaponBmp.SetPosition(player2WeaponBmp.GetPosition().GetX() + txtPlayer2Weapon.GetWidth() + MmgHelper.ScaleValue(5), player2WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));

            txtPlayer2Mod = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer2Mod.SetText("M:");
            txtPlayer2Mod.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer2Weapon.GetY() + txtPlayer2Weapon.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            txtPlayer2Mod.SetY(txtPlayer2Mod.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer2Mod);

            txtPlayer2ModTime = MmgFontData.CreateDefaultBoldMmgFontSm();
            txtPlayer2ModTime.SetText("MT:");
            txtPlayer2ModTime.SetPosition(new MmgVector2(BOARD_RIGHT + MmgHelper.ScaleValue(20), txtPlayer2Mod.GetY() + txtPlayer2Mod.GetHeight() + MmgHelper.ScaleValue(10)));

            //C# Adjustment
            txtPlayer2ModTime.SetY(txtPlayer2ModTime.GetY() - MmgHelper.ScaleValue(3));
            AddObj(txtPlayer2ModTime);

            //Load number one config
            key = "bmpNumberOne";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "num_1_lrg.png";
            }
            lval = MmgHelper.GetBasicCachedBmp(file);

            MmgBmp tlval = MmgHelper.GetBasicCachedBmp("popup_window_base.png");
            numberBground = new Mmg9Slice(MmgHelper.ScaleValue(16), tlval, lval.GetWidth() + MmgHelper.ScaleValue(12), lval.GetHeight() + MmgHelper.ScaleValue(12));
            MmgHelper.CenterHorAndVert(numberBground);
            AddObj(numberBground);

            number1 = lval;
            if (number1 != null)
            {
                MmgHelper.CenterHorAndVert(number1);
                pos = number1.GetPosition().Clone();
                number1 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberOne", number1, classConfig, pos);
                number1.SetIsVisible(false);
                AddObj(number1);
            }

            //Load number two config
            key = "bmpNumberTwo";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "num_2_lrg.png";
            }
            lval = MmgHelper.GetBasicCachedBmp(file);
            number2 = lval;
            if (number2 != null)
            {
                MmgHelper.CenterHorAndVert(number2);
                pos = number2.GetPosition().Clone();
                number2 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberTwo", number2, classConfig, pos);
                number2.SetIsVisible(false);
                AddObj(number2);
            }

            //Load number three config
            key = "bmpNumberThree";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "num_3_lrg.png";
            }
            lval = MmgHelper.GetBasicCachedBmp(file);
            number3 = lval;
            if (number3 != null)
            {
                MmgHelper.CenterHorAndVert(number3);
                pos = number3.GetPosition().Clone();
                number3 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberThree", number3, classConfig, pos);
                number3.SetIsVisible(false);
                AddObj(number3);
            }

            //Load string game win config
            key = "strGoalText";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "popup_window_base.png";
            }
            lval = MmgHelper.GetBasicCachedBmp(file);
            bgroundPopupSrc = lval;
            if (bgroundPopupSrc != null)
            {
                popupTotalWidth = MmgHelper.ScaleValue(300);
                popupTotalHeight = MmgHelper.ScaleValue(120);

                bgroundPopup = new Mmg9Slice(16, bgroundPopupSrc, popupTotalWidth, popupTotalHeight);
                bgroundPopup.SetPosition(MmgVector2.GetOriginVec());

                key = "popupWindowBaseWidth";
                if (classConfig.ContainsKey(key))
                {
                    tmpW = MmgHelper.ScaleValue((int)classConfig[key].number);
                }
                else
                {
                    tmpW = popupTotalWidth;
                }
                bgroundPopup.SetWidth(tmpW);

                key = "popupWindowBaseHeight";
                if (classConfig.ContainsKey(key))
                {
                    tmpH = MmgHelper.ScaleValue((int)classConfig[key].number);
                }
                else
                {
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

                MdtWeaponAxe waxe = new MdtWeaponAxe(player1, MdtWeaponType.AXE, MdtPlayerType.PLAYER_1);
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
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

            MdtWeaponType[] wps = null;
            MdtItemType[] itms = null;
            MdtDoorType[] drs = null;
            int wLen = WAVE_COUNT;
            int cnt = 0;
            waves = new MdtEnemyWave[WAVE_COUNT];

            MmgHelper.wr("Configure enemy waves (" + wLen + ")...");
            for (int i = 0; i < wLen; i++)
            {
                if (i == 0)
                {
                    wps = new MdtWeaponType[] { MdtWeaponType.SWORD, MdtWeaponType.SPEAR };
                    itms = new MdtItemType[] { MdtItemType.COIN_BAG, MdtItemType.POTION_GREEN, MdtItemType.POTION_YELLOW, MdtItemType.POTION_RED };
                    drs = new MdtDoorType[] { MdtDoorType.TOP_LEFT, MdtDoorType.RIGHT };
                }
                else if (i >= 3 && i < 6)
                {
                    wps = new MdtWeaponType[] { MdtWeaponType.SWORD, MdtWeaponType.SPEAR, MdtWeaponType.AXE };
                    itms = new MdtItemType[] { MdtItemType.COIN_BAG, MdtItemType.POTION_GREEN, MdtItemType.POTION_YELLOW, MdtItemType.CHEST };
                    drs = new MdtDoorType[] { MdtDoorType.TOP_LEFT, MdtDoorType.RIGHT, MdtDoorType.LEFT };
                }
                else if (i >= 6 && i < 9)
                {
                    wps = new MdtWeaponType[] { MdtWeaponType.SWORD, MdtWeaponType.SPEAR, MdtWeaponType.AXE };
                    itms = new MdtItemType[] { MdtItemType.COIN_BAG, MdtItemType.POTION_GREEN, MdtItemType.POTION_YELLOW, MdtItemType.CHEST };
                    drs = new MdtDoorType[] { MdtDoorType.TOP_LEFT, MdtDoorType.TOP_RIGHT, MdtDoorType.RIGHT, MdtDoorType.LEFT };
                }
                else if (i >= 9 && i < 12)
                {
                    wps = new MdtWeaponType[] { MdtWeaponType.SWORD, MdtWeaponType.SPEAR, MdtWeaponType.AXE, MdtWeaponType.WAND };
                    itms = new MdtItemType[] { MdtItemType.COIN_BAG, MdtItemType.POTION_GREEN, MdtItemType.POTION_YELLOW, MdtItemType.CHEST, MdtItemType.BOMB };
                    drs = new MdtDoorType[] { MdtDoorType.TOP_LEFT, MdtDoorType.TOP_RIGHT, MdtDoorType.RIGHT, MdtDoorType.LEFT, MdtDoorType.BOTTOM_LEFT, MdtDoorType.BOTTOM_RIGHT };
                }
                cnt = ((i + 1) * 10);
                waves[i] = new MdtEnemyWave(i, (((i + 2) * 30) * 1000), 0, 0, ((((i + 1) * 30) * 1000) / cnt), ((int)(cnt * 0.10) + 1), ((int)(cnt * 0.20) + 1), cnt, wps, itms, drs, ((i % 3) + 3), ((i % 3) + 6), ((i % 3) + 3), ((i % 3) + 6));
                MmgHelper.wr("\n" + waves[i]);
            }
            wavesCurrentIdx = 0;

            sound1 = MmgHelper.GetBasicCachedSound("jump1.wav");
            SetState(State.SHOW_GAME);
            ready = true;
            pause = false;
        }

        /// <summary>
        /// Sets the current game type.
        /// </summary>
        /// <param name="gt">The specified game type.</param>
        public void SetGameType(GameType gt)
        {
            gameType = gt;
        }

        /// <summary>
        /// Gets the current game type.
        /// </summary>
        /// <returns>The specified game type.</returns>
        public GameType GetGameType()
        {
            return gameType;
        }

        /// <summary>
        /// Converts the given speed to a uniform speed per frame so that the game movement will
        /// be the same even if the game runs at different frame rates.
        /// </summary>
        /// <param name="speed">The target speed to convert to a speed per frame.</param>
        /// <returns>A converted speed that represents the speed per frame of the given input speed.</returns>
        public static int GetSpeedPerFrame(int speed)
        {
            return (int)(speed / (DungeonTrap.FPS - 4));
        }

        /// <summary>
        /// Clears objects from the screens object collection and the items, objects, and enemies containers.
        /// </summary>
        private void UpdateClearObjects()
        {
            MmgContainer c = GetObjects();
            int len = c.GetCount();
            MmgObj obj = null;
            for (int i = 0; i < len; i++)
            {
                obj = c.GetChildAt(i);
                if (obj is MdtItemChest || obj is MdtCharInterWarlock || obj is MdtCharInterBanshee || obj is MdtCharInterDemon || obj is MdtWeapon || obj is MdtObjPushTableSmall || obj is MdtObjPushTableLarge || obj is MdtObjPushBarrel || obj is MdtItemBomb || obj is MdtItemCoinBag || obj is MdtItemPotionGreen || obj is MdtItemPotionRed || obj is MdtItemPotionYellow)
                {
                    c.RemoveAt(i);
                    len--;
                    i--;
                }
            }
            gameObjects.Clear();
            gameItems.Clear();
            gameEnemies.Clear();
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public override void UnloadResources()
        {
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
            waves = null;
            wavesCurrent = null;

            ClearObjs();
            base.UnloadResources();

            ready = false;
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
            lret = base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);
            if (pause == false && isVisible == true)
            {
                if (state == State.SHOW_GAME)
                {

                }
                lret = true;
            }
            return lret;
        }

        /// <summary>
        /// The main drawing routine.
        /// </summary>
        /// <param name="p">An MmgPen object to use for drawing this game screen.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.GetObjects().MmgDraw(p);
            }
        }

        /// <summary>
        /// A method to handle A button click events from the MainFrame class.
        /// </summary>
        /// <param name="src">The player source of the input.</param>
        /// <returns>A boolean indicating if this Screen has handled the A click event.</returns>
        public override bool ProcessAClick(int src)
        {
            if (pause || !isVisible)
            {
                return false;
            }

            if (state == State.SHOW_GAME)
            {
                if (gameType == GameType.GAME_ONE_PLAYER || gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (src == ScreenGame.SRC_PLAYER_1)
                    {
                        if (!player1.isAttacking)
                        {
                            if (player1.weaponCurrent.attackType == MdtWeaponAttackType.THROWING && player1.weaponCurrent.weaponType == MdtWeaponType.AXE)
                            {
                                player1.weaponCurrent = player1.weaponCurrent.Clone();
                                player1.weaponCurrent.SetPosition(GetX() + GetWidth() / 2, GetY() + GetHeight() / 2);
                                player1.weaponCurrent.current = null;
                                player1.weaponCurrent.throwingPath = MdtWeaponPathType.NONE;
                                player1.weaponCurrent.screen = this;
                                AddObj(player1.weaponCurrent);
                            }

                            player1.weaponCurrent.animTimeMsCurrent = 0;
                            player1.weaponCurrent.animPrctComplete = 0.0d;
                            player1.isAttacking = true;
                            player1.weaponCurrent.active = true;
                        }
                    }
                    else if (src == ScreenGame.SRC_PLAYER_2)
                    {
                        if (!player2.isAttacking)
                        {
                            if (player2.weaponCurrent.attackType == MdtWeaponAttackType.THROWING && player2.weaponCurrent.weaponType == MdtWeaponType.AXE)
                            {
                                player2.weaponCurrent = player2.weaponCurrent.Clone();
                                player2.weaponCurrent.SetPosition(GetX() + GetWidth() / 2, GetY() + GetHeight() / 2);
                                player2.weaponCurrent.current = null;
                                player2.weaponCurrent.throwingPath = MdtWeaponPathType.NONE;
                                player2.weaponCurrent.screen = this;
                                AddObj(player2.weaponCurrent);
                            }

                            player2.weaponCurrent.animTimeMsCurrent = 0;
                            player2.weaponCurrent.animPrctComplete = 0.0d;
                            player2.isAttacking = true;
                            player2.weaponCurrent.active = true;
                        }
                    }
                }
                return true;
            }
            else if (state == State.SHOW_GAME_EXIT)
            {
                owner.SwitchGameState(GameStates.MAIN_MENU);
                return true;
            }
            else if (state == State.SHOW_GAME_OVER)
            {
                owner.SwitchGameState(GameStates.MAIN_MENU);
                return true;
            }
            return false;
        }

        /// <summary>
        /// A method to handle B button click events from the MainFrame class.
        /// </summary>
        /// <param name="src">The player source of the input.</param>
        /// <returns>A boolean indicating if this Screen has handled the B click event.</returns>
        public override bool ProcessBClick(int src)
        {
            if (pause || !isVisible)
            {
                return false;
            }

            if (state == State.SHOW_GAME_OVER)
            {
                owner.SwitchGameState(GameStates.MAIN_MENU);
                return true;
            }
            else
            {
                if (state != State.SHOW_GAME_EXIT)
                {
                    SetState(State.SHOW_GAME_EXIT);
                    return true;
                }
                else
                {
                    SetState(statePrev);
                    return true;
                }
            }
        }

        /// <summary>
        /// A method to handle debug click events from the MainFrame class, the D key on the keyboard.
        /// You can use this method to turn on different debugging helpers.
        /// </summary>
        public override void ProcessDebugClick()
        {
            randomWaves = !randomWaves;
            MmgHelper.wr("RandomWaves: " + randomWaves);
        }

        /// <summary>
        /// A method to handle key press events from the MainFrame class.
        /// </summary>
        /// <param name="c">The character of the key that was pressed on the keyboard.</param>
        /// <param name="code">An alternate key code.</param>
        /// <returns>A boolean indicating if the key press event was handled by this Screen.</returns>
        public override bool ProcessKeyPress(char c, int code)
        {
            if (pause || !isVisible)
            {
                return false;
            }

            if (state == State.SHOW_GAME)
            {
                if (gameType == GameType.GAME_TWO_PLAYER)
                {
                    bool found = false;

                    if (c == 'x' || c == 'X')
                    {
                        //down
                        if (player2.GetDir() != MmgDir.DIR_FRONT)
                        {
                            player2.SetDir(MmgDir.DIR_FRONT);
                        }
                        found = true;
                    }
                    else if (c == 's' || c == 'S')
                    {
                        //up
                        if (player2.GetDir() != MmgDir.DIR_BACK)
                        {
                            player2.SetDir(MmgDir.DIR_BACK);
                        }
                        found = true;
                    }
                    else if (c == 'z' || c == 'Z')
                    {
                        //left
                        if (player2.GetDir() != MmgDir.DIR_LEFT)
                        {
                            player2.SetDir(MmgDir.DIR_LEFT);
                        }
                        found = true;
                    }
                    else if (c == 'c' || c == 'C')
                    {
                        //right
                        if (player2.GetDir() != MmgDir.DIR_RIGHT)
                        {
                            player2.SetDir(MmgDir.DIR_RIGHT);
                        }
                        found = true;
                    }

                    if (found)
                    {
                        player2.isMoving = true;
                        player2.subj.SetMsPerFrame(frameMsPerFrameMoving);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// A method to handle key release events from the MainFrame class.
        /// </summary>
        /// <param name="c">The character of the key that was released on the keyboard.</param>
        /// <param name="code">An alternate key code.</param>
        /// <returns>A boolean indicating if the key release event was handled by this Screen.</returns>
        public override bool ProcessKeyRelease(char c, int code)
        {
            if (pause || !isVisible)
            {
                return false;
            }

            if (state == State.SHOW_GAME_EXIT)
            {
                if (gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (c == 'v' || c == 'V')
                    {
                        ProcessBClick(SRC_PLAYER_2);
                    }
                    else if (c == 'f' || c == 'F')
                    {
                        ProcessAClick(SRC_PLAYER_2);
                    }
                }

                if (c == '/' || c == '?')
                {
                    ProcessBClick(SRC_PLAYER_1);
                }
                else if (c == '.' || c == '>')
                {
                    ProcessAClick(SRC_PLAYER_1);
                }
            }
            else if (state == State.SHOW_GAME)
            {
                if (gameType == GameType.GAME_TWO_PLAYER)
                {
                    bool found = true;
                    if (c == 'x' || c == 'X')
                    {
                        //down
                        found = true;
                    }
                    else if (c == 's' || c == 'S')
                    {
                        //up
                        found = true;
                    }
                    else if (c == 'z' || c == 'Z')
                    {
                        //left
                        found = true;
                    }
                    else if (c == 'c' || c == 'C')
                    {
                        //right
                        found = true;
                    }
                    else if (c == 'f' || c == 'F')
                    {
                        ProcessAClick(SRC_PLAYER_2);
                    }
                    else if (c == 'v' || c == 'V')
                    {
                        ProcessBClick(SRC_PLAYER_2);
                    }

                    if (found)
                    {
                        if (playerSnapToFront == true)
                        {
                            player2.SetDir(MmgDir.DIR_FRONT);
                        }

                        player2.isMoving = false;
                        player2.isPushStart = false;
                        player2.isPushing = false;
                        player2.subj.SetMsPerFrame(frameMsPerFrameNotMoving);
                    }
                }

                if (c == '.' || c == '>')
                {
                    ProcessAClick(SRC_PLAYER_1);
                }
                else if (c == '/' || c == '?')
                {
                    ProcessBClick(SRC_PLAYER_1);
                }
            }
            return false;
        }

        /// <summary>
        /// A method to handle dpad press events from the MainFrame class.
        /// </summary>
        /// <param name="dir">The dpad code, UP, DOWN, LEFT, RIGHT of the direction that was pressed on the keyboard.</param>
        /// <returns>A boolean indicating if the dpad press was handled by this Screen.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            if (pause || !isVisible)
            {
                return false;
            }

            if (state == State.SHOW_GAME)
            {
                if (gameType == GameType.GAME_ONE_PLAYER || gameType == GameType.GAME_TWO_PLAYER)
                {
                    bool found = false;

                    if (dir == GameSettings.DOWN_KEYBOARD)
                    {
                        if (player1.GetDir() != MmgDir.DIR_FRONT)
                        {
                            player1.SetDir(MmgDir.DIR_FRONT);
                        }
                        found = true;

                    }
                    else if (dir == GameSettings.UP_KEYBOARD)
                    {
                        if (player1.GetDir() != MmgDir.DIR_BACK)
                        {
                            player1.SetDir(MmgDir.DIR_BACK);
                        }
                        found = true;

                    }
                    else if (dir == GameSettings.LEFT_KEYBOARD)
                    {
                        if (player1.GetDir() != MmgDir.DIR_LEFT)
                        {
                            player1.SetDir(MmgDir.DIR_LEFT);
                        }
                        found = true;

                    }
                    else if (dir == GameSettings.RIGHT_KEYBOARD)
                    {
                        if (player1.GetDir() != MmgDir.DIR_RIGHT)
                        {
                            player1.SetDir(MmgDir.DIR_RIGHT);
                        }
                        found = true;
                    }

                    if (found)
                    {
                        player1.isMoving = true;
                        player1.subj.SetMsPerFrame(frameMsPerFrameMoving);
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// A method to handle dpad release events from the MainFrame class.
        /// </summary>
        /// <param name="dir">The dpad code, UP, DOWN, LEFT, RIGHT of the direction that was released on the keyboard.</param>
        /// <returns>A boolean indicating if the dpad release was handled by this Screen.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            if (pause || !isVisible)
            {
                return false;
            }

            if (state == State.SHOW_GAME)
            {
                if (gameType == GameType.GAME_ONE_PLAYER || gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (playerSnapToFront == true)
                    {
                        player1.SetDir(MmgDir.DIR_FRONT);
                    }

                    player1.isMoving = false;
                    player1.isPushStart = false;
                    player1.isPushing = false;
                    player1.subj.SetMsPerFrame(frameMsPerFrameNotMoving);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sets the Screen's current state. The state is used to prepare what MmgObj's are visible for the given state.
        /// </summary>
        /// <param name="inS">The desired State to set the Screen to.</param>
        private void SetState(State inS)
        {
            switch (statePrev)
            {
                case State.NONE:
                    break;

                case State.SHOW_GAME:
                    break;

                case State.SHOW_COUNT_DOWN:
                    break;

                case State.SHOW_COUNT_DOWN_IN_GAME:
                    break;

                case State.SHOW_GAME_OVER:
                    break;

                case State.SHOW_GAME_EXIT:
                    break;
            }

            statePrev = state;
            state = inS;

            switch (state)
            {
                case State.NONE:
                    UpdateHideAllDoors();

                    numberBground.SetIsVisible(false);

                    player1.SetIsVisible(false);
                    player2.SetIsVisible(false);

                    torch1.SetIsVisible(false);
                    torch2.SetIsVisible(false);
                    torch3.SetIsVisible(false);
                    torch4.SetIsVisible(false);

                    txtLevel.SetIsVisible(false);
                    txtLevelTime.SetIsVisible(false);
                    player1HealthBar.SetIsVisible(false);
                    player2HealthBar.SetIsVisible(false);

                    exit.SetIsVisible(false);
                    exitBground.SetIsVisible(false);
                    gameLogo.SetIsVisible(false);

                    bground.SetIsVisible(false);
                    number1.SetIsVisible(false);
                    number2.SetIsVisible(false);
                    number3.SetIsVisible(false);
                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);

                    txtPlayer1.SetIsVisible(false);
                    txtPlayer1Mod.SetIsVisible(false);
                    txtPlayer1ModTime.SetIsVisible(false);
                    txtPlayer1Score.SetIsVisible(false);
                    txtPlayer1Section.SetIsVisible(false);
                    txtPlayer1Weapon.SetIsVisible(false);

                    txtPlayer2.SetIsVisible(false);
                    txtPlayer2Mod.SetIsVisible(false);
                    txtPlayer2ModTime.SetIsVisible(false);
                    txtPlayer2Score.SetIsVisible(false);
                    txtPlayer2Section.SetIsVisible(false);
                    txtPlayer2Weapon.SetIsVisible(false);

                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);
                    txtGameOver3.SetIsVisible(false);

                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);

                    pause = false;
                    isDirty = false;
                    break;
                case State.SHOW_GAME_OVER:
                    UpdateHideAllDoors();
                    numberBground.SetIsVisible(false);
                    player1.SetIsVisible(false);
                    player2.SetIsVisible(false);

                    torch1.SetIsVisible(false);
                    torch2.SetIsVisible(false);
                    torch3.SetIsVisible(false);
                    torch4.SetIsVisible(false);

                    txtLevel.SetIsVisible(false);
                    txtLevelTime.SetIsVisible(false);
                    player1HealthBar.SetIsVisible(false);
                    player2HealthBar.SetIsVisible(false);

                    exit.SetIsVisible(false);
                    exitBground.SetIsVisible(false);
                    gameLogo.SetIsVisible(false);

                    bground.SetIsVisible(false);
                    number1.SetIsVisible(false);
                    number2.SetIsVisible(false);
                    number3.SetIsVisible(false);
                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);

                    txtPlayer1.SetIsVisible(false);
                    txtPlayer1Mod.SetIsVisible(false);
                    txtPlayer1ModTime.SetIsVisible(false);
                    txtPlayer1Score.SetIsVisible(false);
                    txtPlayer1Section.SetIsVisible(false);
                    txtPlayer1Weapon.SetIsVisible(false);

                    if (player1WeaponBmp != null)
                    {
                        player1WeaponBmp.SetIsVisible(false);
                    }

                    if (player1ModBmp != null)
                    {
                        player1ModBmp.SetIsVisible(false);
                    }

                    txtPlayer2.SetIsVisible(false);
                    txtPlayer2Mod.SetIsVisible(false);
                    txtPlayer2ModTime.SetIsVisible(false);
                    txtPlayer2Score.SetIsVisible(false);
                    txtPlayer2Section.SetIsVisible(false);
                    txtPlayer2Weapon.SetIsVisible(false);

                    if (player2WeaponBmp != null)
                    {
                        player2WeaponBmp.SetIsVisible(false);
                    }

                    if (player2ModBmp != null)
                    {
                        player2ModBmp.SetIsVisible(false);
                    }

                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);

                    UpdateClearObjects();

                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);
                    txtGameOver3.SetIsVisible(false);

                    if (scoreTimeUp)
                    {
                        txtGameOver3.SetIsVisible(true);
                    }
                    else
                    {
                        if (gameType == GameType.GAME_TWO_PLAYER)
                        {
                            if (scorePlayerOne >= scorePlayerTwo)
                            {
                                txtGameOver1.SetIsVisible(true);
                            }
                            else
                            {
                                txtGameOver2.SetIsVisible(true);
                            }
                        }
                        else
                        {
                            txtGameOver1.SetIsVisible(true);
                        }
                    }

                    numberState = NumberState.NONE;
                    pause = false;
                    isDirty = true;
                    break;
                case State.SHOW_GAME:
                    numberBground.SetIsVisible(false);

                    torch1.SetIsVisible(true);
                    torch2.SetIsVisible(true);
                    torch3.SetIsVisible(true);
                    torch4.SetIsVisible(true);

                    txtLevel.SetIsVisible(true);
                    txtLevelTime.SetIsVisible(true);
                    exit.SetIsVisible(true);
                    exitBground.SetIsVisible(true);
                    gameLogo.SetIsVisible(true);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }

                    bground.SetIsVisible(true);
                    number1.SetIsVisible(false);
                    number2.SetIsVisible(false);
                    number3.SetIsVisible(false);
                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);

                    if (gameType == GameType.GAME_ONE_PLAYER || gameType == GameType.GAME_TWO_PLAYER)
                    {
                        UpdatePlayerWeapon(player1.playerType, player1.weaponCurrent.weaponType);
                        txtPlayer1.SetIsVisible(true);
                        txtPlayer1Mod.SetIsVisible(true);
                        txtPlayer1ModTime.SetIsVisible(true);
                        txtPlayer1Score.SetIsVisible(true);
                        txtPlayer1Section.SetIsVisible(true);
                        txtPlayer1Weapon.SetIsVisible(true);

                        player1HealthBar.SetIsVisible(true);
                        player1.SetIsVisible(true);
                        player1.isMoving = false;
                        player1.isAttacking = false;
                        player1.isPushStart = false;
                        player1.isPushing = false;
                    }

                    if (gameType == GameType.GAME_TWO_PLAYER)
                    {
                        UpdatePlayerWeapon(player2.playerType, player2.weaponCurrent.weaponType);
                        txtPlayer2.SetIsVisible(true);
                        txtPlayer2Mod.SetIsVisible(true);
                        txtPlayer2ModTime.SetIsVisible(true);
                        txtPlayer2Score.SetIsVisible(true);
                        txtPlayer2Section.SetIsVisible(true);
                        txtPlayer2Weapon.SetIsVisible(true);

                        player2HealthBar.SetIsVisible(true);
                        player2.SetIsVisible(true);
                        player2.isMoving = false;
                        player2.isAttacking = false;
                        player2.isPushStart = false;
                        player2.isPushing = false;
                    }

                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);
                    txtGameOver3.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        UpdateStartEnemyWave(wavesCurrentIdx);
                        UpdateResetPlayers();
                    }
                    else
                    {
                        wavesCurrent.timeStartMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }

                    pause = false;
                    isDirty = true;
                    break;
                case State.SHOW_COUNT_DOWN_IN_GAME:
                    UpdateClearObjects();
                    numberBground.SetIsVisible(true);

                    player1.SetIsVisible(false);
                    player2.SetIsVisible(false);

                    torch1.SetIsVisible(true);
                    torch2.SetIsVisible(true);
                    torch3.SetIsVisible(true);
                    torch4.SetIsVisible(true);

                    txtLevel.SetIsVisible(true);
                    txtLevelTime.SetIsVisible(true);
                    player1HealthBar.SetIsVisible(false);
                    player2HealthBar.SetIsVisible(false);

                    txtPlayer1Score.SetIsVisible(false);
                    txtPlayer2Score.SetIsVisible(false);

                    exit.SetIsVisible(true);
                    exitBground.SetIsVisible(true);
                    gameLogo.SetIsVisible(true);
                    bground.SetIsVisible(true);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        number1.SetIsVisible(false);
                        number2.SetIsVisible(false);
                        number3.SetIsVisible(false);
                    }

                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);

                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);
                    txtGameOver3.SetIsVisible(false);

                    txtPlayer1.SetIsVisible(false);
                    txtPlayer2.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        numberState = NumberState.NONE;
                    }
                    else
                    {
                        timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }

                    pause = false;
                    isDirty = true;
                    break;
                case State.SHOW_COUNT_DOWN:
                    UpdateClearObjects();
                    numberBground.SetIsVisible(false);

                    UpdateHideAllDoors();

                    player1.SetIsVisible(false);
                    player2.SetIsVisible(false);

                    torch1.SetIsVisible(false);
                    torch2.SetIsVisible(false);
                    torch3.SetIsVisible(false);
                    torch4.SetIsVisible(false);

                    txtLevel.SetIsVisible(false);
                    txtLevelTime.SetIsVisible(false);
                    player1HealthBar.SetIsVisible(false);
                    player2HealthBar.SetIsVisible(false);

                    exit.SetIsVisible(false);
                    exitBground.SetIsVisible(false);
                    gameLogo.SetIsVisible(false);
                    bground.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        number1.SetIsVisible(false);
                        number2.SetIsVisible(false);
                        number3.SetIsVisible(false);
                        txtGoal.SetIsVisible(false);
                        txtDirecP1.SetIsVisible(false);
                        txtDirecP2.SetIsVisible(false);
                    }

                    txtPlayer1.SetIsVisible(false);
                    txtPlayer1Mod.SetIsVisible(false);
                    txtPlayer1ModTime.SetIsVisible(false);
                    txtPlayer1Score.SetIsVisible(false);
                    txtPlayer1Section.SetIsVisible(false);
                    txtPlayer1Weapon.SetIsVisible(false);

                    txtPlayer2.SetIsVisible(false);
                    txtPlayer2Mod.SetIsVisible(false);
                    txtPlayer2ModTime.SetIsVisible(false);
                    txtPlayer2Score.SetIsVisible(false);
                    txtPlayer2Section.SetIsVisible(false);
                    txtPlayer2Weapon.SetIsVisible(false);

                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);
                    txtGameOver3.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        numberState = NumberState.NONE;
                    }
                    else
                    {
                        timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }

                    pause = false;
                    isDirty = true;
                    break;
                case State.SHOW_GAME_EXIT:
                    numberBground.SetIsVisible(false);
                    bgroundPopup.SetIsVisible(true);
                    txtOk.SetIsVisible(true);
                    txtCancel.SetIsVisible(true);
                    isDirty = true;
                    break;
            }
        }

        /// <summary>
        /// Updates player2's score, left hand paddle.
        /// </summary>
        /// <param name="score">The score to set for player two.</param>
        private void SetScoreLeftText(int score)
        {
            string tmp = score + "";
            while (tmp.Length < 6)
            {
                tmp = "0" + tmp;
            }
            txtPlayer1Score.SetText(tmp);
        }

        /// <summary>
        /// Updates player1's score, right hand paddle.
        /// </summary>
        /// <param name="score">The score to set for player one.</param>
        private void SetScoreRightText(int score)
        {
            string tmp = score + "";
            while (tmp.Length < 6)
            {
                tmp = "0" + tmp;
            }
            txtPlayer2Score.SetText(tmp);
        }

        /// <summary>
        /// Formats the level number based on the default length of two.
        /// </summary>
        /// <param name="idx">The level number to format.</param>
        /// <returns>A formatted level number.</returns>
        private string FormatLevel(int idx)
        {
            string ret = (idx + 1) + "";
            while (ret.Length < 2)
            {
                ret = "0" + ret;
            }
            return ret;
        }

        /// <summary>
        /// Formats the modifier time based on the milliseconds specified.
        /// </summary>
        /// <param name="ms">The milliseconds specified.</param>
        /// <returns>A formatted time.</returns>
        private string FormatMod(long ms)
        {
            string ret = ms + "";
            while (ret.Length < 4)
            {
                ret = "0" + ret;
            }
            return ret;
        }

        /// <summary>
        /// Formats the current time based on the milliseconds and the default length of three.
        /// </summary>
        /// <param name="ms">The milliseconds to format.</param>
        /// <returns>A formatted time.</returns>
        private string FormatTime(long ms)
        {
            return FormatTime(ms, 3);
        }

        /// <summary>
        /// Formats the current time based on the milliseconds and the length specified.
        /// </summary>
        /// <param name="ms">The milliseconds to format.</param>
        /// <param name="l">The desired number length.</param>
        /// <returns>A formatted time.</returns>
        private string FormatTime(long ms, int l)
        {
            int mul = 1;
            if (ms < 0)
            {
                mul = -1;
            }
            ms *= mul;
            String ret = (ms / 1000) + "";
            while (ret.Length < l)
            {
                ret = "0" + ret;
            }

            if (mul == -1)
            {
                ret = "-" + ret;
            }
            return ret;
        }

        /// <summary>
        /// Clears the modifier image for the given player.
        /// </summary>
        /// <param name="p">The player to clear modifier image for.</param>
        public void UpdateClearPlayerMod(MdtPlayerType p)
        {
            if (p == MdtPlayerType.PLAYER_1)
            {
                RemoveObj(player1ModBmp);
            }
            else
            {
                RemoveObj(player2ModBmp);
            }
        }

        /// <summary>
        /// Updates the modifier HUD UI for the given player and modifier type.
        /// </summary>
        /// <param name="p">The player for which to apply the modifier HUD UI change.</param>
        /// <param name="m">The modifier type to apply to the specified player's HUD UI.</param>
        private void UpdatePlayerMod(MdtPlayerType p, MdtPlayerModType m)
        {
            if (p == MdtPlayerType.PLAYER_1)
            {
                RemoveObj(player1ModBmp);

                if (m == MdtPlayerModType.INVINCIBLE)
                {
                    MdtItemPotionYellow p3 = new MdtItemPotionYellow();
                    player1ModBmp = p3.GetSubj();
                }
                else if (m == MdtPlayerModType.FULL_HEALTH)
                {
                    MdtItemPotionGreen p2 = new MdtItemPotionGreen();
                    player1ModBmp = p2.GetSubj();
                }
                else if (m == MdtPlayerModType.DOUBLE_POINTS)
                {
                    MdtItemPotionRed p1 = new MdtItemPotionRed();
                    player1ModBmp = p1.GetSubj();
                }

                if (player1ModBmp != null)
                {
                    player1ModBmp.SetPosition(txtPlayer1Mod.GetPosition().Clone());
                    player1ModBmp.SetPosition(player1ModBmp.GetPosition().GetX() + txtPlayer1Mod.GetWidth() + MmgHelper.ScaleValue(5), player1ModBmp.GetPosition().GetY() - MmgHelper.ScaleValue(24));
                    player1ModBmp.SetIsVisible(false);
                    AddObj(player1ModBmp);
                }
            }
            else if (p == MdtPlayerType.PLAYER_2)
            {
                RemoveObj(player2ModBmp);

                if (m == MdtPlayerModType.INVINCIBLE)
                {
                    MdtItemPotionYellow p3 = new MdtItemPotionYellow();
                    player2ModBmp = p3.GetSubj();
                }
                else if (m == MdtPlayerModType.FULL_HEALTH)
                {
                    MdtItemPotionGreen p2 = new MdtItemPotionGreen();
                    player2ModBmp = p2.GetSubj();
                }
                else if (m == MdtPlayerModType.DOUBLE_POINTS)
                {
                    MdtItemPotionRed p1 = new MdtItemPotionRed();
                    player2ModBmp = p1.GetSubj();
                }

                if (player2ModBmp != null)
                {
                    player2ModBmp.SetPosition(txtPlayer2Mod.GetPosition().Clone());
                    player2ModBmp.SetPosition(player2ModBmp.GetPosition().GetX() + txtPlayer2Mod.GetWidth() + MmgHelper.ScaleValue(5), player2ModBmp.GetPosition().GetY() - MmgHelper.ScaleValue(24));
                    player2ModBmp.SetIsVisible(false);
                    AddObj(player2ModBmp);
                }
            }
        }

        /// <summary>
        /// Updates and configures the player's weapon.
        /// </summary>
        /// <param name="p">The player to update the weapon for.</param>
        /// <param name="w">The weapon type to set the weapon to.</param>
        public void UpdatePlayerWeapon(MdtPlayerType p, MdtWeaponType w)
        {
            if (p == MdtPlayerType.PLAYER_1)
            {
                RemoveObj(player1WeaponBmp);
                if (w == MdtWeaponType.SPEAR)
                {
                    player1WeaponBmp = player1.weaponCurrent.subjRight.CloneTyped();
                    player1WeaponBmp.SetPosition(txtPlayer1Weapon.GetPosition().Clone());
                    player1WeaponBmp.SetPosition(player1WeaponBmp.GetPosition().GetX() + txtPlayer1Weapon.GetWidth() + MmgHelper.ScaleValue(5), player1WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                }
                else if (w == MdtWeaponType.SWORD)
                {
                    player1WeaponBmp = player1.weaponCurrent.subjRight.CloneTyped();
                    player1WeaponBmp.SetPosition(txtPlayer1Weapon.GetPosition().Clone());
                    player1WeaponBmp.SetPosition(player1WeaponBmp.GetPosition().GetX() + txtPlayer1Weapon.GetWidth() + MmgHelper.ScaleValue(5), player1WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                }
                else if (w == MdtWeaponType.AXE)
                {
                    player1WeaponBmp = player1.weaponCurrent.subjRight.CloneTyped();
                    player1WeaponBmp.SetPosition(txtPlayer1Weapon.GetPosition().Clone());
                    player1WeaponBmp.SetPosition(player1WeaponBmp.GetPosition().GetX() + txtPlayer1Weapon.GetWidth() + MmgHelper.ScaleValue(5), player1WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                }

                if (player1WeaponBmp != null)
                {
                    AddObj(player1WeaponBmp);
                }
            }
            else if (p == MdtPlayerType.PLAYER_2)
            {
                RemoveObj(player2WeaponBmp);
                if (w == MdtWeaponType.SPEAR)
                {
                    player2WeaponBmp = player2.weaponCurrent.subjRight.CloneTyped();
                    player2WeaponBmp.SetPosition(txtPlayer2Weapon.GetPosition().Clone());
                    player2WeaponBmp.SetPosition(player2WeaponBmp.GetPosition().GetX() + txtPlayer2Weapon.GetWidth() + MmgHelper.ScaleValue(5), player2WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                }
                else if (w == MdtWeaponType.SWORD)
                {
                    player2WeaponBmp = player2.weaponCurrent.subjRight.CloneTyped();
                    player2WeaponBmp.SetPosition(txtPlayer2Weapon.GetPosition().Clone());
                    player2WeaponBmp.SetPosition(player2WeaponBmp.GetPosition().GetX() + txtPlayer2Weapon.GetWidth() + MmgHelper.ScaleValue(5), player2WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                }
                else if (w == MdtWeaponType.AXE)
                {
                    player2WeaponBmp = player2.weaponCurrent.subjRight.CloneTyped();
                    player2WeaponBmp.SetPosition(txtPlayer2Weapon.GetPosition().Clone());
                    player2WeaponBmp.SetPosition(player2WeaponBmp.GetPosition().GetX() + txtPlayer2Weapon.GetWidth() + MmgHelper.ScaleValue(5), player2WeaponBmp.GetPosition().GetY() - MmgHelper.ScaleValue(12));
                }

                if (player2WeaponBmp != null)
                {
                    AddObj(player2WeaponBmp);
                }
            }
        }

        /// <summary>
        /// Removes the specified object from the game screen.
        /// </summary>
        /// <param name="obj">The object to remove from this game screen.</param>
        public override void RemoveObj(MmgObj obj)
        {
            if (obj is MdtBase)
            {
                UpdateRemoveObj((MdtBase)obj, MdtPlayerType.NONE);
            }
            else
            {
                base.RemoveObj(obj);
            }
        }

        /// <summary>
        /// Updates the board by removing the specified object from the base set of objects or the items, objects, or enemies collection.
        /// </summary>
        /// <param name="obj">The object to remove from the game.</param>
        /// <param name="p">The player associated with removing this object.</param>
        public void UpdateRemoveObj(MdtBase obj, MdtPlayerType p)
        {
            if (obj.GetMdtType() == MdtObjType.OBJECT)
            {
                gameObjects.Remove(obj);
                if (obj.GetMdtSubType() == MdtObjSubType.OBJECT_BARREL || obj.GetMdtSubType() == MdtObjSubType.OBJECT_TABLE_1 || obj.GetMdtSubType() == MdtObjSubType.OBJECT_TABLE_2)
                {
                    UpdateAddPoints(obj.GetPosition(), MdtPointsType.PTS_100, p);
                }
            }
            else if (obj.GetMdtType() == MdtObjType.ITEM)
            {
                gameItems.Remove(obj);
            }
            else if (obj.GetMdtType() == MdtObjType.ENEMY)
            {
                gameEnemies.Remove(obj);
            }
            else if (obj.GetMdtType() == MdtObjType.WEAPON)
            {
                base.RemoveObj(obj);
            }
            else if (obj.GetMdtType() == MdtObjType.PLAYER)
            {
                if (obj.GetMdtSubType() == MdtObjSubType.PLAYER_1)
                {
                    playersAliveCount--;
                }
                else if (obj.GetMdtSubType() == MdtObjSubType.PLAYER_2)
                {
                    playersAliveCount--;
                }
                base.RemoveObj(obj);
            }
        }

        /// <summary>
        /// Adds points to the board and the specified player's points.
        /// </summary>
        /// <param name="pos">The position to use to generate the floating points.</param>
        /// <param name="pts">The points image to display on the board.</param>
        /// <param name="p">The player associated with the new points.</param>
        public void UpdateAddPoints(MmgVector2 pos, MdtPointsType pts, MdtPlayerType p)
        {
            MmgBmp ptsBmp = null;
            MdtUiPoints ptsUi = null;
            MmgVector2 posC = null;

            if (p == MdtPlayerType.PLAYER_1)
            {
                if (pts == MdtPointsType.PTS_100)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_red_100.png");
                    scorePlayerOne += 100;
                    if (player1.hasDoublePoints)
                    {
                        scorePlayerOne += 100;
                    }
                    SetScoreLeftText(scorePlayerOne);
                }
                else if (pts == MdtPointsType.PTS_250)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_red_250.png");
                    scorePlayerOne += 250;
                    if (player1.hasDoublePoints)
                    {
                        scorePlayerOne += 250;
                    }
                    SetScoreLeftText(scorePlayerOne);
                }
                else if (pts == MdtPointsType.PTS_500)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_red_500.png");
                    scorePlayerOne += 500;
                    if (player1.hasDoublePoints)
                    {
                        scorePlayerOne += 500;
                    }
                    SetScoreLeftText(scorePlayerOne);
                }
                else if (pts == MdtPointsType.PTS_1000)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_red_1000.png");
                    scorePlayerOne += 1000;
                    if (player1.hasDoublePoints)
                    {
                        scorePlayerOne += 1000;
                    }
                    SetScoreLeftText(scorePlayerOne);
                }

                ptsUi = new MdtUiPoints(ptsBmp, p, this, pos);
                AddObj(ptsUi);

                if (player1.hasDoublePoints)
                {
                    posC = pos.Clone();
                    posC.SetY(posC.GetY() + ptsBmp.GetHeight());
                    ptsUi = new MdtUiPoints(ptsBmp.CloneTyped(), p, this, posC);
                    AddObj(ptsUi);
                }
            }
            else
            {
                if (pts == MdtPointsType.PTS_100)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_blue_100.png");
                    scorePlayerTwo += 100;
                    if (player2.hasDoublePoints)
                    {
                        scorePlayerTwo += 100;
                    }
                    SetScoreRightText(scorePlayerTwo);
                }
                else if (pts == MdtPointsType.PTS_250)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_blue_250.png");
                    scorePlayerTwo += 250;
                    if (player2.hasDoublePoints)
                    {
                        scorePlayerTwo += 250;
                    }
                    SetScoreRightText(scorePlayerTwo);
                }
                else if (pts == MdtPointsType.PTS_500)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_blue_500.png");
                    scorePlayerTwo += 500;
                    if (player2.hasDoublePoints)
                    {
                        scorePlayerTwo += 500;
                    }
                    SetScoreRightText(scorePlayerTwo);
                }
                else if (pts == MdtPointsType.PTS_1000)
                {
                    ptsBmp = MmgHelper.GetBasicCachedBmp("pts_blue_1000.png");
                    scorePlayerTwo += 1000;
                    if (player2.hasDoublePoints)
                    {
                        scorePlayerTwo += 1000;
                    }
                    SetScoreRightText(scorePlayerTwo);
                }

                ptsUi = new MdtUiPoints(ptsBmp, p, this, pos);
                AddObj(ptsUi);

                if (player2.hasDoublePoints)
                {
                    posC = pos.Clone();
                    posC.SetY(posC.GetY() + ptsBmp.GetHeight());
                    ptsUi = new MdtUiPoints(ptsBmp.CloneTyped(), p, this, posC);
                    AddObj(ptsUi);
                }
            }
        }

        /// <summary>
        /// Updates the board and hides all the doors.
        /// </summary>
        private void UpdateHideAllDoors()
        {
            doorTopLeftLocked.SetIsVisible(false);
            doorTopLeftOpened.SetIsVisible(false);

            doorTopRightLocked.SetIsVisible(false);
            doorTopRightOpened.SetIsVisible(false);

            doorLeftLockIcon.SetIsVisible(false);
            doorRightLockIcon.SetIsVisible(false);
            doorBotLeftLockIcon.SetIsVisible(false);
            doorBotRightLockIcon.SetIsVisible(false);
        }

        /// <summary>
        /// Updates the board and locks all the doors.
        /// </summary>
        private void UpdateLockAllDoors()
        {
            doorTopLeftLocked.SetIsVisible(true);
            doorTopLeftOpened.SetIsVisible(false);

            doorTopRightLocked.SetIsVisible(true);
            doorTopRightOpened.SetIsVisible(false);

            doorLeftLockIcon.SetIsVisible(true);
            doorRightLockIcon.SetIsVisible(true);
            doorBotLeftLockIcon.SetIsVisible(true);
            doorBotRightLockIcon.SetIsVisible(true);
        }

        /// <summary>
        /// Updates the board and unlocks the specified door.
        /// </summary>
        /// <param name="d">The door specified to unlock.</param>
        private void UpdateUnlockDoor(MdtDoorType d)
        {
            if (d == MdtDoorType.TOP_LEFT)
            {
                doorTopLeftLocked.SetIsVisible(false);
                doorTopLeftOpened.SetIsVisible(true);
            }
            else if (d == MdtDoorType.TOP_RIGHT)
            {
                doorTopRightLocked.SetIsVisible(false);
                doorTopRightOpened.SetIsVisible(true);
            }
            else if (d == MdtDoorType.LEFT)
            {
                doorLeftLockIcon.SetIsVisible(false);
            }
            else if (d == MdtDoorType.RIGHT)
            {
                doorRightLockIcon.SetIsVisible(false);
            }
            else if (d == MdtDoorType.BOTTOM_LEFT)
            {
                doorBotLeftLockIcon.SetIsVisible(false);
            }
            else if (d == MdtDoorType.BOTTOM_RIGHT)
            {
                doorBotRightLockIcon.SetIsVisible(false);
            }
        }

        public MdtBase CanMove(MmgRect r, MdtBase iO)
        {
            return null;
        }

        public void UpdateProcessCollision(MdtBase o1, MdtBase o2)
        {
        }

        public void UpdateProcessWeaponCollision(MdtBase o1, MdtBase o2, MmgRect weapon)
        {
        }

        public MdtBase UpdateGenerateItem(int x, int y)
        {
            return null;
        }

        public MmgVector2 GetPlayer1Pos()
        {
            return null;
        }

        public bool GetPlayer1Broken()
        {
            return false;
        }

        public MmgVector2 GetPlayer2Pos()
        {
            return null;
        }

        public bool GetPlayer2Broken()
        {
            return false;
        }

        private void UpdateResetPlayers()
        {
        }

        private void UpdateStartEnemyWave(int waveIdx)
        {
        }
    }
}