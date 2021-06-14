using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.PongClone.Chapter18_CompleteGame
{
    /// <summary>
    /// A game screen object, ScreenGame, that extends the MmgGameScreen base
    /// class. This class is for testing new UI widgets, etc.
    /// Created by Middlemind Games 03/15/2020
    ///
    /// @author Victor G.Brusca
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
        /// Represents the type of game that is running.
        /// </summary>
        private GameType gameType = GameType.GAME_ONE_PLAYER;

        /// <summary>
        /// Represents the game screen's previous internal state.
        /// </summary>
        private State statePrev = State.NONE;

        /// <summary>
        /// Represents the game screen's current internal state. 
        /// </summary>
        private new State state = State.NONE;

        /// <summary>
        /// Represents the game screen's current count down number state. 
        /// </summary>
        private NumberState numberState = NumberState.NONE;

        /// <summary>
        /// The number of milliseconds the count down number has been displayed. 
        /// </summary>
        private long timeNumberMs = 0L;

        /// <summary>
        /// The number of milliseconds the count down number should be displayed. 
        /// </summary>
        private long timeNumberDisplayMs = 1000;

        /// <summary>
        /// A temporary timing variable. 
        /// </summary>
        private long timeTmpMs = 0L;

        /// <summary>
        /// The sound played when the ball bounces at normal speed. 
        /// </summary>
        private MmgSound bounceNorm;

        /// <summary>
        /// The sound played when the ball bounces at high speed.
        /// </summary>
        private MmgSound bounceSuper;

        /// <summary>
        /// The background image used for the main game screen.
        /// </summary>
        private MmgBmp bground;

        /// <summary>
        /// An MmgBmp image representing the left paddle.
        /// </summary>
        private MmgBmp paddleLeft;

        /// <summary>
        /// An MmgBmp image representing the right paddle.
        /// </summary>
        private MmgBmp paddleRight;

        /// <summary>
        /// An MmgVector2 object that tracks paddle1's position.
        /// </summary>
        private MmgVector2 paddle1Pos;

        /// <summary>
        /// An MmgVector2 object that tracks paddle2's position.
        /// </summary>
        private MmgVector2 paddle2Pos;

        /// <summary>
        /// An MmgBmp image representing the ball used in the game.
        /// </summary>
        private MmgBmp ball;

        /// <summary>
        /// An MmgVector2 object that tracks the ball's position.
        /// </summary>
        private MmgVector2 ballPos;

        /// <summary>
        /// The ball's minimum movement per frame.
        /// </summary>
        private int ballMovePerFrameMin = GetSpeedPerFrame(150);

        /// <summary>
        /// The ball's maximum movement per frame.
        /// </summary>
        private int ballMovePerFrameMax = GetSpeedPerFrame(425);

        /// <summary>
        /// The direction the ball is traveling in on the X axis.
        /// </summary>
        private int ballDirX = 1;

        /// <summary>
        /// The direction the ball is traveling in on the Y axis.
        /// </summary>
        private int ballDirY = 1;

        /// <summary>
        /// The number of pixel the ball will move per frame on the X axis.
        /// </summary>
        private int ballMovePerFrameX = 0;

        /// <summary>
        /// The number of pixel the ball will move per frame on the Y axis.
        /// </summary>
        private int ballMovePerFrameY = 0;

        /// <summary>
        /// An MmgBmp image that represents the number 1.
        /// </summary>
        private MmgBmp number1;

        /// <summary>
        /// An MmgBmp image that represents the number 2.
        /// </summary>
        private MmgBmp number2;

        /// <summary>
        /// An MmgBmp image that represents the number 3.
        /// </summary>
        private MmgBmp number3;

        /// <summary>
        /// The number of points you need to win the game.
        /// </summary>
        private int scoreGameWin = 7;

        /// <summary>
        /// The left hand side score display.
        /// </summary>
        private MmgFont scoreLeft;

        /// <summary>
        /// The score of the right player.
        /// </summary>
        private int scorePlayerRight = 0;

        /// <summary>
        /// The right hand side score display.
        /// </summary>
        private MmgFont scoreRight;

        /// <summary>
        /// The score of the left player.
        /// </summary>
        private int scorePlayerLeft = 0;

        /// <summary>
        /// An MmgFont object used to represent the exit text.
        /// </summary>
        private MmgFont exit;

        /// <summary>
        /// An MmgBmp image used as the background of the exit text.
        /// </summary>
        private MmgBmp exitBground;

        /// <summary>
        /// The number of pixels per frame that paddle1 moves.
        /// </summary>
        private int paddle1MovePerFrame = GetSpeedPerFrame(400);

        /// <summary>
        /// A boolean indicating that paddle1 is moving up.
        /// </summary>
        private bool paddle1MoveUp = false;

        /// <summary>
        /// A boolean indicating that paddle2 is moving down.
        /// </summary>
        private bool paddle1MoveDown = false;

        /// <summary>
        /// The maximum speed the AI player's paddle can reach.
        /// </summary>
        private int aiMaxSpeed = 425;

        /// <summary>
        /// The number of pixels per frame that paddle2 moves.
        /// </summary>
        private int paddle2MovePerFrame = GetSpeedPerFrame(400);

        /// <summary>
        /// A boolean indicating that paddle1 is moving up.
        /// </summary>
        private bool paddle2MoveUp = false;

        /// <summary>
        /// A boolean indicating that paddle2 is moving down.
        /// </summary>
        private bool paddle2MoveDown = false;

        /// <summary>
        /// A random number generator. 
        /// </summary>
        private Random rand;

        /// <summary>
        /// The calculated new X coordinate position of the ball.
        /// </summary>
        private int ballNewX;

        /// <summary>
        /// The calculated new Y coordinate position of the ball.
        /// </summary>
        private int ballNewY;

        /// <summary>
        /// A boolean indicating that the ball has bounced.
        /// </summary>
        private bool bounced = false;

        /// <summary>
        /// The game screen panel's current position.
        /// </summary>
        private MmgVector2 screenPos;

        /// <summary>
        /// The last X value of the mouse input.
        /// </summary>
        private int lastX;

        /// <summary>
        /// The last Y value of the mouse input.
        /// </summary>
        private int lastY;

        /// <summary>
        /// A boolean that indicates if the mouse controls a paddle's position.
        /// </summary>
        private bool mousePos = true;

        /// <summary>
        /// An MmgBmp image that is used as the source for a 9 sliced popup window.
        /// </summary>
        private MmgBmp bgroundPopupSrc;

        /// <summary>
        /// An Mmg9Slice object used as a popup's background window.
        /// </summary>
        private Mmg9Slice bgroundPopup;

        /// <summary>
        /// Text used in dialogs.
        /// </summary>
        private MmgFont txtOk;

        /// <summary>
        /// Text used in dialogs.
        /// </summary>
        private MmgFont txtCancel;

        /// <summary>
        /// Text used in the game's goal.
        /// </summary>
        private MmgFont txtGoal;

        /// <summary>
        /// Text used in the game's instructions.
        /// </summary>
        private MmgFont txtDirecP1;

        /// <summary>
        /// Text used in the game's instructions. 
        /// </summary>
        private MmgFont txtDirecP2;

        /// <summary>
        /// Text used on the game over screen. 
        /// </summary>
        private MmgFont txtGameOver1;

        /// <summary>
        /// Text used on the game over screen.
        /// </summary>
        private MmgFont txtGameOver2;

        /// <summary>
        /// Padding used in the UI positioning. 
        /// </summary>
        private int padding = MmgHelper.ScaleValue(4);

        /// <summary>
        /// Dimension used in the popup dialog display.
        /// </summary>
        private int popupTotalWidth = MmgHelper.ScaleValue(300);

        /// <summary>
        /// Dimension used in the popup dialog display.
        /// </summary>
        private int popupTotalHeight = MmgHelper.ScaleValue(120);

        /// <summary>
        /// A boolean flag used to test the game that causes the ball to bounce infintely.
        /// </summary>
        private bool infiniteBounce = false;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenGame(GameStates State, GamePanel Owner) : base(State, Owner)
        {
            pause = false;
            ready = false;
            owner = Owner;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen and support all Screen states.
        /// </summary>
        public override void LoadResources()
        {
            pause = true;
            rand = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

            classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_game.txt");

            if (gameType == GameType.GAME_TWO_PLAYER)
            {
                paddle2MovePerFrame = GetSpeedPerFrame(aiMaxSpeed);
            }

            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());
            screenPos = GetPosition();

            String key = "";
            MmgBmp lval = null;
            MmgSound sval = null;
            String file = "";
            int tmp = 0;
            int tmpW = 0;
            int tmpH = 0;

            //Load game board config
            key = "bmpGameBoard";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "game_board.png";
            }

            lval = MmgHelper.GetBasicCachedBmp(file);
            bground = lval;
            if (bground != null)
            {
                MmgHelper.CenterHorAndVert(bground);
                bground = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("gameBoard", bground, classConfig, bground.GetPosition());
                AddObj(bground);
            }

            //Load bounce normal sound
            key = "soundBounceNorm";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "jump1.wav";
            }

            sval = MmgHelper.GetBasicCachedSound(file);
            bounceNorm = sval;

            //Load bounce super sound        
            key = "soundBounceSuper";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "jump2.wav";
            }

            sval = MmgHelper.GetBasicCachedSound(file);
            bounceSuper = sval;

            //Load pong ball config
            key = "bmpPongBall";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "pong_ball.png";
            }

            lval = MmgHelper.GetBasicCachedBmp(file);
            ball = lval;
            if (ball != null)
            {
                MmgHelper.CenterHorAndVert(ball);
                ball = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("pongBall", ball, classConfig, ball.GetPosition());
                ball.SetIsVisible(false);
                ballPos = ball.GetPosition();
                AddObj(ball);
            }

            //Load paddle left config
            key = "paddleLeftWidth";
            if (classConfig.ContainsKey(key))
            {
                tmpW = MmgHelper.ScaleValue((int)classConfig[key].number);
            }
            else
            {
                tmpW = MmgHelper.ScaleValue(20);
            }

            key = "paddleLeftHeight";
            if (classConfig.ContainsKey(key))
            {
                tmpH = MmgHelper.ScaleValue((int)classConfig[key].number);
            }
            else
            {
                tmpH = tmpH = (h / 6);
            }

            paddleLeft = MmgHelper.CreateFilledBmp(tmpW, tmpH, MmgColor.GetWhite());
            paddleLeft.SetPosition(MmgHelper.ScaleValue(20), screenPos.GetY() + (h - paddleLeft.GetHeight()) / 2);
            paddle1Pos = paddleLeft.GetPosition();
            AddObj(paddleLeft);

            //Load paddle right config
            key = "paddleRightWidth";
            if (classConfig.ContainsKey(key))
            {
                tmpW = MmgHelper.ScaleValue((int)classConfig[key].number);
            }
            else
            {
                tmpW = MmgHelper.ScaleValue(20);
            }

            key = "paddleRightHeight";
            if (classConfig.ContainsKey(key))
            {
                tmpH = MmgHelper.ScaleValue((int)classConfig[key].number);
            }
            else
            {
                tmpH = tmpH = (h / 6);
            }

            paddleRight = MmgHelper.CreateFilledBmp(tmpW, tmpH, MmgColor.GetLightGray());
            paddleRight.SetPosition((w - paddleRight.GetWidth() - MmgHelper.ScaleValue(20)), screenPos.GetY() + (h - paddleLeft.GetHeight()) / 2);
            paddle2Pos = paddleRight.GetPosition();
            AddObj(paddleRight);

            //Load score left config
            scoreLeft = MmgFontData.CreateDefaultBoldMmgFontLg();
            scoreLeft.SetText("00");
            scoreLeft.SetMmgColor(MmgColor.GetRed());
            scoreLeft.SetPosition(MmgHelper.ScaleValue(10) + paddleLeft.GetX() + paddleLeft.GetWidth(), screenPos.GetY() + scoreLeft.GetHeight() + MmgHelper.ScaleValue(5));

            key = "scoreLeftPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreLeft.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "scoreLeftPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreLeft.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "scoreLeftOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreLeft.GetPosition().SetY(scoreLeft.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "scoreLeftOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreLeft.GetPosition().SetX(scoreLeft.GetX() + MmgHelper.ScaleValue(tmp));
            }
            AddObj(scoreLeft);

            //Load score right config        
            scoreRight = MmgFontData.CreateDefaultBoldMmgFontLg();
            scoreRight.SetText("00");
            scoreRight.SetMmgColor(MmgColor.GetRed());
            scoreRight.SetPosition(w - scoreRight.GetWidth() - MmgHelper.ScaleValue(10) - paddleLeft.GetX() - paddleRight.GetWidth(), screenPos.GetY() + scoreRight.GetHeight() + MmgHelper.ScaleValue(5));

            key = "scoreRightPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreRight.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "scoreRightPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreRight.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "scoreRightOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreRight.GetPosition().SetY(scoreRight.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "scoreRightOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                scoreRight.GetPosition().SetX(scoreRight.GetX() + MmgHelper.ScaleValue(tmp));
            }
            AddObj(scoreRight);

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
            exit.SetPosition((w - exit.GetWidth()) / 2, screenPos.GetY() + exit.GetHeight() + MmgHelper.ScaleValue(5));

            key = "exitTextPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exit.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "exitTextPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exit.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "exitTextOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exit.GetPosition().SetY(exit.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "exitTextOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exit.GetPosition().SetX(exit.GetX() + MmgHelper.ScaleValue(tmp));
            }

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

            key = "exitTextBgroundPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exitBground.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "exitTextBgroundPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exitBground.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "exitTextBgroundOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exitBground.GetPosition().SetY(exitBground.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "exitTextBgroundOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                exitBground.GetPosition().SetX(exitBground.GetX() + MmgHelper.ScaleValue(tmp));
            }
            AddObj(exitBground);
            AddObj(exit);

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
            number1 = lval;
            if (number1 != null)
            {
                MmgHelper.CenterHorAndVert(number1);
                number1 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberOne", number1, classConfig, number1.GetPosition());
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
                number2 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberTwo", number2, classConfig, number2.GetPosition());
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
                number3 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberThree", number3, classConfig, number3.GetPosition());
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
                file = "Goal: First player to " + scoreGameWin + " points wins.";
            }
            txtGoal = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtGoal.SetText(file);
            txtGoal.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtGoal);
            txtGoal.SetY(number1.GetY() - txtGoal.GetHeight() + MmgHelper.ScaleValue(5));

            key = "goalTextPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGoal.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "goalTextPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGoal.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "goalTextOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGoal.GetPosition().SetY(txtGoal.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "goalTextOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGoal.GetPosition().SetX(txtGoal.GetX() + MmgHelper.ScaleValue(tmp));
            }

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
                file = "Player 1: Right paddle, use UP, DOWN keys to move paddle.";
            }
            txtDirecP1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtDirecP1.SetText(file);
            txtDirecP1.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtDirecP1);
            txtDirecP1.SetY(number1.GetY() + number1.GetHeight() + txtDirecP1.GetHeight() + MmgHelper.ScaleValue(10));

            key = "player1DirectionTextPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP1.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "player1DirectionTextPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP1.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "player1DirectionTextOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP1.GetPosition().SetY(txtDirecP1.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "player1DirectionTextOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP1.GetPosition().SetX(txtDirecP1.GetX() + MmgHelper.ScaleValue(tmp));
            }

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
                file = "Player 2: Left paddle, use MOUSE or S, X keys to move paddle.";
            }
            txtDirecP2 = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtDirecP2.SetText(file);
            txtDirecP2.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtDirecP2);
            txtDirecP2.SetY(txtDirecP1.GetY() + txtDirecP1.GetHeight() + MmgHelper.ScaleValue(10));

            key = "player2DirectionTextPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP2.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "player2DirectionTextPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP2.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "player2DirectionTextOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP2.GetPosition().SetY(txtDirecP2.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "player2DirectionTextOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtDirecP2.GetPosition().SetX(txtDirecP2.GetX() + MmgHelper.ScaleValue(tmp));
            }

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
                file = "Player 1 has won the game. Press A or B to exit.";
            }
            txtGameOver1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtGameOver1.SetText(file);
            txtGameOver1.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtGameOver1);

            key = "textGameOver1PosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver1.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "textGameOver1PosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver1.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "textGameOver1OffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver1.GetPosition().SetY(txtGameOver1.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "textGameOver1OffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver1.GetPosition().SetX(txtGameOver1.GetX() + MmgHelper.ScaleValue(tmp));
            }

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
                file = "Player 2 has won the game. Press A or B to exit.";
            }
            txtGameOver2 = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtGameOver2.SetText(file);
            txtGameOver2.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtGameOver2);

            key = "textGameOver2PosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver2.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "textGameOver2PosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver2.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "textGameOver2OffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver2.GetPosition().SetY(txtGameOver2.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "textGameOver2OffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtGameOver2.GetPosition().SetX(txtGameOver2.GetX() + MmgHelper.ScaleValue(tmp));
            }

            txtGameOver2.SetIsVisible(false);
            AddObj(txtGameOver2);

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
                MmgHelper.CenterHorAndVert(bgroundPopupSrc);
                bgroundPopupSrc = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("popupWindowBase", bgroundPopupSrc, classConfig, bgroundPopupSrc.GetPosition());
                popupTotalWidth = MmgHelper.ScaleValue(300);
                popupTotalHeight = MmgHelper.ScaleValue(120);
                bgroundPopup = new Mmg9Slice(16, bgroundPopupSrc, popupTotalWidth, popupTotalHeight);
                bgroundPopup.SetPosition(MmgVector2.GetOriginVec());
                MmgHelper.CenterHorAndVert(bgroundPopup);
                AddObj(bgroundPopup);
                bgroundPopup.SetIsVisible(false);
            }

            //Load popup window text exit
            key = "strPopupWindowTextExit";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "Exit Game (A)";
            }

            txtOk = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtOk.SetText(file);
            txtOk.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtOk);
            txtOk.SetY(bgroundPopup.GetY() + txtOk.GetHeight() + MmgHelper.ScaleValue(20));

            key = "popupWindowTextExitPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtOk.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "popupWindowTextExitPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtOk.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "popupWindowTextExitOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtOk.GetPosition().SetY(txtOk.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "popupWindowTextExitOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtOk.GetPosition().SetX(txtOk.GetX() + MmgHelper.ScaleValue(tmp));
            }

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
                file = "Cancel Exit (B)";
            }

            txtCancel = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtCancel.SetText(file);
            txtCancel.SetMmgColor(MmgColor.GetWhite());
            MmgHelper.CenterHorAndVert(txtCancel);
            txtCancel.SetY(txtOk.GetY() + txtOk.GetHeight() + MmgHelper.ScaleValue(20));

            key = "popupWindowTextCancelPosY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtCancel.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "popupWindowTextCancelPosX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtCancel.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
            }

            key = "popupWindowTextCancelOffsetY";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtCancel.GetPosition().SetY(txtCancel.GetY() + MmgHelper.ScaleValue(tmp));
            }

            key = "popupWindowTextCancelOffsetX";
            if (classConfig.ContainsKey(key))
            {
                tmp = (int)classConfig[key].number;
                txtCancel.GetPosition().SetX(txtCancel.GetX() + MmgHelper.ScaleValue(tmp));
            }

            txtCancel.SetIsVisible(false);
            AddObj(txtCancel);

            //Set score text
            scorePlayerRight = 0;
            scorePlayerLeft = 0;
            SetScoreRightText(scorePlayerRight);
            SetScoreLeftText(scorePlayerLeft);

            SetState(State.SHOW_COUNT_DOWN);
            ready = true;
            pause = false;
        }

        /// <summary>
        /// Sets the current game type.
        /// </summary>
        /// <param name="gt">The current game type.</param>
        public void SetGameType(GameType gt)
        {
            gameType = gt;
        }

        /// <summary>
        /// Gets the current game type.
        /// </summary>
        /// <returns>The current game type.</returns>
        public GameType GetGameType()
        {
            return gameType;
        }

        /// <summary>
        /// Converts the given speed to a uniform speed per frame so that the game movement will be the same even if the game runs at different frame rates.
        /// </summary>
        /// <param name="speed">The target speed to convert to a speed per frame.</param>
        /// <returns>A converted speed that represents the speed per frame of the given input speed.</returns>
        private static int GetSpeedPerFrame(int speed)
        {
            return (int)(speed / (PongClone.FPS - 4));
        }

        /// <summary>
        /// A boolean indicating if this Screen has handled the A click event.
        /// </summary>
        /// <param name="src">An integer value indicating the source of the A click event.</param>
        /// <returns>A method to handle A button click events from the MainFrame class.</returns>
        public override bool ProcessAClick(int src)
        {
            if (state == State.SHOW_GAME_EXIT)
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
        /// <param name="src">An integer value indicating the source of the B click event.</param>
        /// <returns>A boolean indicating if this Screen has handled the B click event.</returns>
        public override bool ProcessBClick(int src)
        {
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
            if (scoreGameWin > 1)
            {
                MmgHelper.wr("Setting game win score to 1.");
                scoreGameWin = 1;
            }
            else if (scoreGameWin == 1 && infiniteBounce == false)
            {
                MmgHelper.wr("Setting infinite bounce to true.");
                infiniteBounce = true;
            }
            else if (scoreGameWin == 1 && infiniteBounce == true)
            {
                MmgHelper.wr("Setting game win score to 7 and infinite bounce to false.");
                scoreGameWin = 7;
                infiniteBounce = false;
            }
        }

        /// <summary>
        /// A method to handle key press events from the MainFrame class.
        /// </summary>
        /// <param name="c">The character of the key that was pressed on the keyboard.</param>
        /// <param name="code">An integer value indicating the source of the event.</param>
        /// <returns>A boolean indicating if the key press event was handled by this Screen.</returns>
        public override bool ProcessKeyPress(char c, int code)
        {
            if (state == State.SHOW_GAME && pause == false)
            {
                if (gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (c == 'x' || c == 'X')
                    {
                        paddle1MoveUp = false;
                        paddle1MoveDown = true;
                        return true;

                    }
                    else if (c == 's' || c == 'S')
                    {
                        paddle1MoveUp = true;
                        paddle1MoveDown = false;
                        return true;

                    }
                }
            }

            return false;
        }

        /// <summary>
        /// A method to handle key release events from the MainFrame class.
        /// </summary>
        /// <param name="c">The character of the key that was released on the keyboard.</param>
        /// <param name="code">An integer value indicating the source of the event.</param>
        /// <returns>A boolean indicating if the key release event was handled by this Screen.</returns>
        public override bool ProcessKeyRelease(char c, int code)
        {
            if (state == State.SHOW_GAME && pause == false)
            {
                if (gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (c == 'x' || c == 'X')
                    {
                        paddle1MoveDown = false;
                        return true;

                    }
                    else if (c == 's' || c == 'S')
                    {
                        paddle1MoveUp = false;
                        return true;

                    }
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
            if (state == State.SHOW_GAME && pause == false)
            {
                if (dir == GameSettings.DOWN_KEYBOARD)
                {
                    paddle2MoveUp = false;
                    paddle2MoveDown = true;
                    return true;

                }
                else if (dir == GameSettings.UP_KEYBOARD)
                {
                    paddle2MoveUp = true;
                    paddle2MoveDown = false;
                    return true;

                }
                else if (this.gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (dir == GameSettings.DOWN_GAMEPAD_1 || dir == GameSettings.DOWN_GPIO)
                    {
                        if (dir == GameSettings.DOWN_GPIO)
                        {
                            MmgHelper.wr(("GPIO Gamepad Down Button Event"));
                        }

                        paddle1MoveUp = false;
                        paddle1MoveDown = true;
                        return true;

                    }
                    else if (dir == GameSettings.UP_GAMEPAD_1 || dir == GameSettings.UP_GPIO)
                    {
                        if (dir == GameSettings.UP_GPIO)
                        {
                            MmgHelper.wr(("GPIO Gamepad Up Button Event"));
                        }

                        paddle1MoveUp = true;
                        paddle1MoveDown = false;
                        return true;

                    }
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
            if (state == State.SHOW_GAME && pause == false)
            {
                if (dir == GameSettings.DOWN_KEYBOARD)
                {
                    paddle2MoveDown = false;
                    return true;

                }
                else if (dir == GameSettings.UP_KEYBOARD)
                {
                    paddle2MoveUp = false;
                    return true;

                }
                else if (this.gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (dir == GameSettings.DOWN_GAMEPAD_1 || dir == GameSettings.DOWN_GPIO)
                    {
                        paddle1MoveDown = false;
                        return true;

                    }
                    else if (dir == GameSettings.UP_GAMEPAD_1 || dir == GameSettings.UP_GPIO)
                    {
                        paddle1MoveUp = false;
                        return true;

                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Processes mouse movement for player 2's input, the left hand paddle.
        /// </summary>
        /// <param name="x">The X position of the mouse with the Screen's offset taken into account.</param>
        /// <param name="y">The Y position of the mouse with the Screen's offset taken into account.</param>
        /// <returns>Returns a boolean indicating if the event was consumed by this game Screen.</returns>
        public override bool ProcessMouseMove(int x, int y)
        {
            if (state == State.SHOW_GAME && pause == false)
            {
                if (gameType == GameType.GAME_TWO_PLAYER)
                {
                    if (y >= screenPos.GetY() && y <= (screenPos.GetY() + GetHeight() - paddleLeft.GetHeight()))
                    {
                        lastX = x;
                        lastY = y;
                        mousePos = true;
                        return true;
                    }
                }
            }

            mousePos = false;
            return false;
        }

        /// <summary>
        /// Resets certain aspects of the UI that are related to the actual game.
        /// Some aspects of the UI are left visible during the in-game count down.
        /// </summary>
        private void ResetGame()
        {
            ball.SetIsVisible(true);
            MmgHelper.CenterHorAndVert(ball);
            ballPos = ball.GetPosition();
            ballMovePerFrameX = ballMovePerFrameMin;
            ballMovePerFrameY = ballMovePerFrameMin;

            paddleLeft.SetIsVisible(true);
            MmgHelper.CenterVert(paddleLeft);
            paddle1Pos = paddleLeft.GetPosition();
            paddle1MoveDown = false;
            paddle1MoveUp = false;

            paddleRight.SetIsVisible(true);
            MmgHelper.CenterVert(paddleRight);
            paddle2Pos = paddleRight.GetPosition();
            paddle2MoveDown = false;
            paddle2MoveUp = false;

            lastX = 0;
            lastY = 0;
            mousePos = false;
        }

        /// <summary>
        /// Sets the Screen's current state. The state is used to prepare what MmgObj's are visible for the given state.
        /// </summary>
        /// <param name="inS">The desired State to set the Screen to.</param>
        private void SetState(State inS)
        {
            //clean up prev state
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
                    ResetGame();

                    ball.SetIsVisible(false);
                    paddleLeft.SetIsVisible(false);
                    paddleRight.SetIsVisible(false);
                    bground.SetIsVisible(false);
                    number1.SetIsVisible(false);
                    number2.SetIsVisible(false);
                    number3.SetIsVisible(false);
                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);
                    scoreLeft.SetIsVisible(false);
                    scoreRight.SetIsVisible(false);
                    exit.SetIsVisible(false);
                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);

                    scorePlayerRight = 0;
                    scorePlayerLeft = 0;
                    SetScoreRightText(scorePlayerRight);
                    SetScoreLeftText(scorePlayerLeft);

                    pause = false;
                    isDirty = false;
                    break;

                case State.SHOW_GAME_OVER:
                    ball.SetIsVisible(true);
                    paddleLeft.SetIsVisible(true);
                    paddleRight.SetIsVisible(true);
                    bground.SetIsVisible(false);
                    number1.SetIsVisible(false);
                    number2.SetIsVisible(false);
                    number3.SetIsVisible(false);
                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);
                    scoreLeft.SetIsVisible(true);
                    scoreRight.SetIsVisible(true);
                    exit.SetIsVisible(true);
                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);

                    if (scorePlayerRight == scoreGameWin)
                    {
                        txtGameOver1.SetIsVisible(true);
                        txtGameOver2.SetIsVisible(false);

                    }
                    else if (scorePlayerLeft == scoreGameWin)
                    {
                        txtGameOver1.SetIsVisible(false);
                        txtGameOver2.SetIsVisible(true);

                    }
                    numberState = NumberState.NONE;

                    pause = false;
                    isDirty = true;
                    break;

                case State.SHOW_GAME:
                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        ResetGame();
                    }

                    ball.SetIsVisible(true);
                    paddleLeft.SetIsVisible(true);
                    paddleRight.SetIsVisible(true);
                    bground.SetIsVisible(true);
                    number1.SetIsVisible(false);
                    number2.SetIsVisible(false);
                    number3.SetIsVisible(false);
                    txtGoal.SetIsVisible(false);
                    txtDirecP1.SetIsVisible(false);
                    txtDirecP2.SetIsVisible(false);
                    scoreLeft.SetIsVisible(true);
                    scoreRight.SetIsVisible(true);
                    exit.SetIsVisible(true);
                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        if (rand.Next(11) % 2 == 0)
                        {
                            ballDirX = 1;
                        }
                        else
                        {
                            ballDirX = -1;
                        }
                        ballMovePerFrameX = ballMovePerFrameMin;

                        if (rand.Next(11) % 2 == 0)
                        {
                            ballDirY = 1;
                        }
                        else
                        {
                            ballDirY = -1;
                        }
                        ballMovePerFrameY = ballMovePerFrameMin;
                    }

                    pause = false;
                    isDirty = true;
                    break;

                case State.SHOW_COUNT_DOWN_IN_GAME:
                    ball.SetIsVisible(true);
                    paddleLeft.SetIsVisible(true);
                    paddleRight.SetIsVisible(true);
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
                    scoreLeft.SetIsVisible(true);
                    scoreRight.SetIsVisible(true);
                    exit.SetIsVisible(true);
                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        numberState = NumberState.NONE;
                    }
                    else
                    {
                        //reset this number count down
                        timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }

                    pause = false;
                    isDirty = true;
                    break;

                case State.SHOW_COUNT_DOWN:
                    ball.SetIsVisible(false);
                    paddleLeft.SetIsVisible(false);
                    paddleRight.SetIsVisible(false);
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

                    scoreLeft.SetIsVisible(true);
                    scoreRight.SetIsVisible(true);
                    exit.SetIsVisible(true);
                    bgroundPopup.SetIsVisible(false);
                    txtOk.SetIsVisible(false);
                    txtCancel.SetIsVisible(false);
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(false);

                    if (statePrev != State.SHOW_GAME_EXIT)
                    {
                        numberState = NumberState.NONE;
                    }
                    else
                    {
                        //reset this number count down
                        timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    }

                    pause = false;
                    isDirty = true;
                    break;

                case State.SHOW_GAME_EXIT:
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
            if (tmp.Length != 2)
            {
                tmp = "0" + tmp;
            }
            scoreLeft.SetText(tmp);
        }

        /// <summary>
        /// Updates player1's score, right hand paddle.
        /// </summary>
        /// <param name="score">The score to set for player one.</param>
        private void SetScoreRightText(int score)
        {
            string tmp = score + "";
            if (tmp.Length != 2)
            {
                tmp = "0" + tmp;
            }
            scoreRight.SetText(tmp);
        }

        /// <summary>
        /// The DrawScreen method gets called by the MmgUpdate method if the Screen is not paused and is responsible for drawing the current screen state.
        /// </summary>
        public override void DrawScreen()
        {
            //ran each game frame
            pause = true;

            switch (state)
            {
                case State.NONE:
                    break;

                case State.SHOW_GAME_EXIT:
                    break;

                case State.SHOW_COUNT_DOWN_IN_GAME:
                case State.SHOW_COUNT_DOWN:
                    switch (numberState)
                    {
                        case NumberState.NONE:
                            timeNumberMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                            numberState = NumberState.NUMBER_3;
                            number1.SetIsVisible(false);
                            number2.SetIsVisible(false);
                            number3.SetIsVisible(true);
                            if (state == State.SHOW_COUNT_DOWN)
                            {
                                txtGoal.SetIsVisible(true);
                                txtDirecP1.SetIsVisible(true);
                                if (gameType == GameType.GAME_TWO_PLAYER)
                                {
                                    txtDirecP2.SetIsVisible(true);
                                }
                                else
                                {
                                    txtDirecP2.SetIsVisible(false);
                                }
                            }
                            else
                            {
                                txtGoal.SetIsVisible(false);
                                txtDirecP1.SetIsVisible(false);
                                txtDirecP2.SetIsVisible(false);
                            }
                            break;

                        case NumberState.NUMBER_1:
                            timeTmpMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                            if (timeTmpMs - timeNumberMs >= timeNumberDisplayMs)
                            {
                                timeNumberMs = timeTmpMs;
                                numberState = NumberState.NONE;
                                number1.SetIsVisible(false);
                                number2.SetIsVisible(false);
                                number3.SetIsVisible(false);
                                txtDirecP1.SetIsVisible(false);
                                txtDirecP2.SetIsVisible(false);
                                SetState(State.SHOW_GAME);
                                bounceNorm.Play();
                            }
                            break;

                        case NumberState.NUMBER_2:
                            timeTmpMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                            if (timeTmpMs - timeNumberMs >= timeNumberDisplayMs)
                            {
                                timeNumberMs = timeTmpMs;
                                numberState = NumberState.NUMBER_1;
                                number1.SetIsVisible(true);
                                number2.SetIsVisible(false);
                                number3.SetIsVisible(false);
                                txtDirecP1.SetIsVisible(true);
                                if (state == State.SHOW_COUNT_DOWN)
                                {
                                    txtGoal.SetIsVisible(true);
                                    if (gameType == GameType.GAME_TWO_PLAYER)
                                    {
                                        txtDirecP2.SetIsVisible(true);
                                    }
                                    else
                                    {
                                        txtDirecP2.SetIsVisible(false);
                                    }
                                }
                                else
                                {
                                    txtGoal.SetIsVisible(false);
                                    txtDirecP1.SetIsVisible(false);
                                    txtDirecP2.SetIsVisible(false);
                                }
                                bounceNorm.Play();
                            }
                            break;

                        case NumberState.NUMBER_3:
                            timeTmpMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                            if (timeTmpMs - timeNumberMs >= timeNumberDisplayMs)
                            {
                                timeNumberMs = timeTmpMs;
                                numberState = NumberState.NUMBER_2;
                                number1.SetIsVisible(false);
                                number2.SetIsVisible(true);
                                number3.SetIsVisible(false);
                                if (state == State.SHOW_COUNT_DOWN)
                                {
                                    txtGoal.SetIsVisible(true);
                                    if (gameType == GameType.GAME_TWO_PLAYER)
                                    {
                                        txtDirecP2.SetIsVisible(true);
                                    }
                                    else
                                    {
                                        txtDirecP2.SetIsVisible(false);
                                    }
                                }
                                else
                                {
                                    txtGoal.SetIsVisible(false);
                                    txtDirecP1.SetIsVisible(false);
                                    txtDirecP2.SetIsVisible(false);
                                }
                                bounceNorm.Play();
                            }
                            break;

                    }
                    break;

                case State.SHOW_GAME:
                    //player two movement
                    if (gameType == GameType.GAME_TWO_PLAYER)
                    {
                        if (mousePos)
                        {
                            paddle1Pos.SetY(lastY);
                        }

                        if (paddle1MoveUp)
                        {
                            if (paddle1Pos.GetY() - paddle1MovePerFrame < screenPos.GetY())
                            {
                                paddle1Pos.SetY(screenPos.GetY());
                            }
                            else
                            {
                                paddle1Pos.SetY(paddle1Pos.GetY() - paddle1MovePerFrame);
                            }

                        }
                        else if (paddle1MoveDown)
                        {
                            if (paddle1Pos.GetY() + paddleLeft.GetHeight() + paddle1MovePerFrame > screenPos.GetY() + GetHeight())
                            {
                                paddle1Pos.SetY(screenPos.GetY() + GetHeight() - paddleLeft.GetHeight());
                            }
                            else
                            {
                                paddle1Pos.SetY(paddle1Pos.GetY() + paddle1MovePerFrame);
                            }

                        }
                    }
                    else
                    {
                        //AI
                        if (ballPos.GetY() + ball.GetHeight() / 2 < paddleLeft.GetY())
                        {
                            if (paddle1Pos.GetY() - paddle1MovePerFrame < screenPos.GetY())
                            {
                                paddle1Pos.SetY(screenPos.GetY());
                            }
                            else
                            {
                                paddle1Pos.SetY(paddle1Pos.GetY() - paddle1MovePerFrame);
                            }

                        }
                        else if (ballPos.GetY() + ball.GetHeight() / 2 > paddleLeft.GetY() + paddleLeft.GetHeight())
                        {
                            if (paddle1Pos.GetY() + paddleLeft.GetHeight() + paddle1MovePerFrame > screenPos.GetY() + GetHeight())
                            {
                                paddle1Pos.SetY(screenPos.GetY() + GetHeight() - paddleLeft.GetHeight());
                            }
                            else
                            {
                                paddle1Pos.SetY(paddle1Pos.GetY() + paddle1MovePerFrame);
                            }

                        }
                    }

                    //player one movement
                    if (paddle2MoveUp)
                    {
                        if (paddle2Pos.GetY() - paddle2MovePerFrame < screenPos.GetY())
                        {
                            paddle2Pos.SetY(screenPos.GetY());
                        }
                        else
                        {
                            paddle2Pos.SetY(paddle2Pos.GetY() - paddle2MovePerFrame);
                        }
                    }
                    else if (paddle2MoveDown)
                    {
                        if (paddle2Pos.GetY() + paddleRight.GetHeight() + paddle2MovePerFrame > screenPos.GetY() + GetHeight())
                        {
                            paddle2Pos.SetY(screenPos.GetY() + GetHeight() - paddleRight.GetHeight());
                        }
                        else
                        {
                            paddle2Pos.SetY(paddle2Pos.GetY() + paddle2MovePerFrame);
                        }
                    }

                    //calculate where the ball will be
                    ballNewX = ballPos.GetX() + (ballMovePerFrameX * ballDirX);
                    ballNewY = ballPos.GetY() + (ballMovePerFrameY * ballDirY);

                    //board collision
                    if (ballNewY < screenPos.GetY())
                    {
                        //top
                        ballDirY = 1;
                        ballNewX = (ballPos.GetX() + (ballMovePerFrameX * ballDirX));
                        ballNewY = ((screenPos.GetY()));
                    }
                    else if (ballNewY + ball.GetHeight() > screenPos.GetY() + GetHeight())
                    {
                        //bottom
                        ballDirY = -1;
                        ballNewX = (ballPos.GetX() + (ballMovePerFrameX * ballDirX));
                        ballNewY = ((screenPos.GetY() + GetHeight() - ball.GetHeight()));
                    }
                    else if (ballNewX < screenPos.GetX())
                    {
                        //left
                        ballDirX = 1;
                        ballNewX = ((screenPos.GetX()));
                        ballNewY = (ballPos.GetY() + (ballMovePerFrameY * ballDirY));
                        scorePlayerRight += 1;
                        SetScoreRightText(scorePlayerRight);

                        if (infiniteBounce == false)
                        {
                            if (scorePlayerRight == scoreGameWin)
                            {
                                SetState(State.SHOW_GAME_OVER);
                            }
                            else
                            {
                                SetState(State.SHOW_COUNT_DOWN_IN_GAME);
                            }
                        }
                    }
                    else if (ballNewX + ball.GetWidth() > screenPos.GetX() + GetWidth())
                    {
                        //right
                        ballDirX = -1;
                        ballNewX = ((screenPos.GetX() + GetWidth() - ball.GetWidth()));
                        ballNewY = (ballPos.GetY() + (ballMovePerFrameY * ballDirY));
                        scorePlayerLeft += 1;
                        SetScoreLeftText(scorePlayerLeft);

                        if (infiniteBounce == false)
                        {
                            if (scorePlayerLeft == scoreGameWin)
                            {
                                SetState(State.SHOW_GAME_OVER);
                            }
                            else
                            {
                                SetState(State.SHOW_COUNT_DOWN_IN_GAME);
                            }
                        }
                    }

                    bounced = false;
                    //paddle1 collision
                    if (ballNewX <= paddle1Pos.GetX() + paddleLeft.GetWidth() && ballDirX == -1)
                    {
                        if (ballNewY + ball.GetHeight() / 2 >= paddle1Pos.GetY() + paddleLeft.GetHeight() / 3 && ballNewY + ball.GetHeight() / 2 <= paddle1Pos.GetY() + ((paddleLeft.GetHeight() / 3) * 2))
                        {
                            //middle
                            ballMovePerFrameX = (int)(ballMovePerFrameX * 1.5);
                            ballMovePerFrameY = rand.Next(ballMovePerFrameMin);
                            ballDirX = 1;
                            if (rand.Next() % 2 == 0)
                            {
                                ballDirY = 1;
                            }
                            else
                            {
                                ballDirY = -1;
                            }
                            bounced = true;
                            ballNewX = (paddle1Pos.GetX() + paddleLeft.GetWidth());

                        }
                        else if (ballNewY + ball.GetHeight() >= paddle1Pos.GetY() && ballNewY + ball.GetHeight() <= paddle1Pos.GetY() + paddleLeft.GetHeight() / 2)
                        {
                            //top
                            ballMovePerFrameX = (int)(ballMovePerFrameX * 1.5);
                            ballDirX = 1;
                            ballDirY = -1;

                            if (ballMovePerFrameY == 0)
                            {
                                ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.Next(ballMovePerFrameMin);
                            }
                            else
                            {
                                ballMovePerFrameY = (int)(ballMovePerFrameY * 1.5);
                            }
                            bounced = true;
                            ballNewX = (paddle1Pos.GetX() + paddleLeft.GetWidth());

                        }
                        else if (ballNewY >= paddle1Pos.GetY() + paddleLeft.GetHeight() / 2 && ballNewY <= paddle1Pos.GetY() + paddleLeft.GetHeight())
                        {
                            //bottom
                            ballMovePerFrameX = (int)(ballMovePerFrameX * 1.5);
                            ballDirX = 1;
                            ballDirY = 1;

                            if (ballMovePerFrameY == 0)
                            {
                                ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.Next(ballMovePerFrameMin);
                            }
                            else
                            {
                                ballMovePerFrameY = (int)(ballMovePerFrameY * 1.5);
                            }
                            bounced = true;
                            ballNewX = (paddle1Pos.GetX() + paddleLeft.GetWidth());

                        }
                    }

                    //paddle2 collision
                    if (ballNewX + ball.GetWidth() >= paddle2Pos.GetX() && ballDirX == 1)
                    {
                        if (ballNewY + ball.GetHeight() / 2 >= paddle2Pos.GetY() + paddleRight.GetHeight() / 3 && ballNewY + ball.GetHeight() / 2 <= paddle2Pos.GetY() + ((paddleRight.GetHeight() / 3) * 2))
                        {
                            //middle
                            ballMovePerFrameX = (int)(ballMovePerFrameX * 1.5);
                            ballMovePerFrameY = rand.Next(ballMovePerFrameMin);
                            ballDirX = -1;
                            if (rand.Next() % 2 == 0)
                            {
                                ballDirY = 1;
                            }
                            else
                            {
                                ballDirY = -1;
                            }
                            bounced = true;
                            ballNewX = (paddle2Pos.GetX() - ball.GetWidth());

                        }
                        else if (ballNewY + ball.GetHeight() >= paddle2Pos.GetY() && ballNewY + ball.GetHeight() <= paddle2Pos.GetY() + paddleRight.GetHeight() / 2)
                        {
                            //top
                            ballMovePerFrameX = (int)(ballMovePerFrameX * 1.5);
                            ballDirX = -1;
                            ballDirY = -1;

                            if (ballMovePerFrameY == 0)
                            {
                                ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.Next(ballMovePerFrameMin);
                            }
                            else
                            {
                                ballMovePerFrameY = (int)(ballMovePerFrameY * 1.5);
                            }
                            bounced = true;
                            ballNewX = (paddle2Pos.GetX() - ball.GetWidth());

                        }
                        else if (ballNewY >= paddle2Pos.GetY() + paddleRight.GetHeight() / 2 && ballNewY <= paddle2Pos.GetY() + paddleRight.GetHeight())
                        {
                            //bottom
                            ballMovePerFrameX = (int)(ballMovePerFrameX * 1.5);
                            ballDirX = -1;
                            ballDirY = 1;

                            if (ballMovePerFrameY == 0)
                            {
                                ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.Next(ballMovePerFrameMin);
                            }
                            else
                            {
                                ballMovePerFrameY = (int)(ballMovePerFrameY * 1.5);
                            }
                            bounced = true;
                            ballNewX = (paddle2Pos.GetX() - ball.GetWidth());

                        }
                    }

                    //set limits on the ball's speed
                    if (ballMovePerFrameX > ballMovePerFrameMax)
                    {
                        ballMovePerFrameX = ballMovePerFrameMax;
                    }

                    if (ballMovePerFrameY > ballMovePerFrameMax)
                    {
                        ballMovePerFrameY = ballMovePerFrameMax;
                    }

                    //handle bounce sound
                    if (bounced)
                    {
                        if (ballMovePerFrameY == ballMovePerFrameMax || ballMovePerFrameX == ballMovePerFrameMax)
                        {
                            bounceSuper.Play();
                        }
                        else
                        {
                            bounceNorm.Play();
                        }
                    }

                    //update ball's position
                    ballPos.SetX(ballNewX);
                    ballPos.SetY(ballNewY);
                    break;
            }

            pause = false;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public override void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            ResetGame();
            state = State.NONE;
            statePrev = State.NONE;

            bounceNorm = null;
            bounceSuper = null;
            bground = null;

            paddleLeft = null;
            paddleRight = null;
            paddle1Pos = null;
            paddle2Pos = null;

            ball = null;
            ballPos = null;
            number1 = null;
            number2 = null;
            number3 = null;

            scoreLeft = null;
            scoreRight = null;
            exit = null;
            exitBground = null;

            rand = null;
            screenPos = null;
            bgroundPopupSrc = null;
            bgroundPopup = null;

            txtOk = null;
            txtCancel = null;
            txtGoal = null;
            txtDirecP1 = null;
            txtDirecP2 = null;
            txtGameOver1 = null;
            txtGameOver2 = null;
            classConfig = null;

            base.UnloadResources();

            ClearObjs();
            ready = false;
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
    }
}