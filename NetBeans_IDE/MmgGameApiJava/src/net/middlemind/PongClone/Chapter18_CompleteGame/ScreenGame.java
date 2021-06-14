package net.middlemind.PongClone.Chapter18_CompleteGame;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameType;
import net.middlemind.MmgGameApiJava.MmgCore.GameSettings;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgCore.Screen;
import java.util.Random;
import net.middlemind.MmgGameApiJava.MmgBase.Mmg9Slice;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFont;
import net.middlemind.MmgGameApiJava.MmgBase.MmgFontData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSound;
import net.middlemind.MmgGameApiJava.MmgBase.MmgVector2;

/**
 * A game screen object, ScreenGame, that extends the MmgGameScreen base
 * class. This class is for testing new UI widgets, etc.
 * Created by Middlemind Games 03/15/2020
 * 
 * @author Victor G. Brusca
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
     * Represents the type of game that is running.
     */
    private GameType gameType = GameType.GAME_ONE_PLAYER;
    
    /**
     * Represents the game screen's previous internal state.
     */
    private State statePrev = State.NONE;
    
    /**
     * Represents the game screen's current internal state.
     */
    private State state = State.NONE;
    
    /**
     * Represents the game screen's current count down number state.
     */    
    private NumberState numberState = NumberState.NONE;

    /**
     * The number of milliseconds the count down number has been displayed.
     */    
    private long timeNumberMs = 0L;

    /**
     * The number of milliseconds the count down number should be displayed.
     */
    private long timeNumberDisplayMs = 1000;

    /**
     * A temporary timing variable.
     */    
    private long timeTmpMs = 0L;

    /**
     * The sound played when the ball bounces at normal speed.
     */    
    private MmgSound bounceNorm;

    /**
     * The sound played when the ball bounces at high speed.
     */    
    private MmgSound bounceSuper;
    
    /**
     * The background image used for the main game screen.
     */    
    private MmgBmp bground;

    /**
     * An MmgBmp image representing the left paddle.
     */
    private MmgBmp paddleLeft;

    /**
     * An MmgBmp image representing the right paddle.
     */
    private MmgBmp paddleRight;

    /**
     * An MmgVector2 object that tracks paddle1's position.
     */
    private MmgVector2 paddle1Pos;

    /**
     * An MmgVector2 object that tracks paddle2's position.
     */
    private MmgVector2 paddle2Pos;    
    
    /**
     * An MmgBmp image representing the ball used in the game.
     */
    private MmgBmp ball;

    /**
     * An MmgVector2 object that tracks the ball's position.
     */
    private MmgVector2 ballPos;

    /**
     * The ball's minimum movement per frame.
     */    
    private int ballMovePerFrameMin = GetSpeedPerFrame(150);

    /**
     * The ball's maximum movement per frame.
     */    
    private int ballMovePerFrameMax = GetSpeedPerFrame(425);

    /**
     * The direction the ball is traveling in on the X axis.
     */
    private int ballDirX = 1;

    /**
     * The direction the ball is traveling in on the Y axis.
     */
    private int ballDirY = 1;

    /**
     * The number of pixel the ball will move per frame on the X axis.
     */
    private int ballMovePerFrameX = 0;

    /**
     * The number of pixel the ball will move per frame on the Y axis.
     */
    private int ballMovePerFrameY = 0;
    
    /**
     * An MmgBmp image that represents the number 1.
     */    
    private MmgBmp number1;

    /**
     * An MmgBmp image that represents the number 2.
     */    
    private MmgBmp number2;

    /**
     * An MmgBmp image that represents the number 3.
     */
    private MmgBmp number3;    

    /**
     * The number of points you need to win the game.
     */    
    private int scoreGameWin = 7;

    /**
     * The left hand side score display.
     */
    private MmgFont scoreLeft;

    /**
     * The score of the right player.
     */
    private int scorePlayerRight = 0;

    /**
     * The right hand side score display.
     */
    private MmgFont scoreRight;

    /**
     * The score of the left player.
     */
    private int scorePlayerLeft = 0;

    /**
     * An MmgFont object used to represent the exit text.
     */
    private MmgFont exit;

    /**
     * An MmgBmp image used as the background of the exit text.
     */
    private MmgBmp exitBground;
        
    /**
     * The number of pixels per frame that paddle1 moves.
     */    
    private int paddle1MovePerFrame = GetSpeedPerFrame(400);

    /**
     * A boolean indicating that paddle1 is moving up.
     */
    private boolean paddle1MoveUp = false;

    /**
     * A boolean indicating that paddle2 is moving down.
     */
    private boolean paddle1MoveDown = false;

    /**
     * The maximum speed the AI player's paddle can reach.
     */    
    private int aiMaxSpeed = 425;

    /**
     * The number of pixels per frame that paddle2 moves.
     */
    private int paddle2MovePerFrame = GetSpeedPerFrame(400);

    /**
     * A boolean indicating that paddle1 is moving up.
     */
    private boolean paddle2MoveUp = false;

    /**
     * A boolean indicating that paddle2 is moving down.
     */
    private boolean paddle2MoveDown = false;        

    /**
     * A random number generator.
     */    
    private Random rand;
    
    /**
     * The calculated new X coordinate position of the ball.
     */    
    private int ballNewX;

    /**
     * The calculated new Y coordinate position of the ball.
     */    
    private int ballNewY;

    /**
     * A boolean indicating that the ball has bounced.
     */
    private boolean bounced = false;

    /**
     * The game screen panel's current position.
     */
    private MmgVector2 screenPos;

    /**
     * The last X value of the mouse input.
     */    
    private int lastX;

    /**
     * The last Y value of the mouse input.
     */
    private int lastY;

    /**
     * A boolean that indicates if the mouse controls a paddle's position.
     */
    private boolean mousePos = true;

    /**
     * An MmgBmp image that is used as the source for a 9 sliced popup window.
     */    
    private MmgBmp bgroundPopupSrc;

    /**
     * An Mmg9Slice object used as a popup's background window.
     */
    private Mmg9Slice bgroundPopup;

    /**
     * Text used in dialogs.
     */
    private MmgFont txtOk;

    /**
     * Text used in dialogs.
     */
    private MmgFont txtCancel;
    
    /**
     * Text used in the game's goal.
     */    
    private MmgFont txtGoal;

    /**
     * Text used in the game's instructions.
     */    
    private MmgFont txtDirecP1;

    /**
     * Text used in the game's instructions.
     */
    private MmgFont txtDirecP2;    

    /**
     * Text used on the game over screen.
     */    
    private MmgFont txtGameOver1;

    /**
     * Text used on the game over screen.
     */    
    private MmgFont txtGameOver2;

    /**
     * Padding used in the UI positioning.
     */    
    private int padding = MmgHelper.ScaleValue(4);
 
    /**
     * Dimension used in the popup dialog display.
     */    
    private int popupTotalWidth = MmgHelper.ScaleValue(300);

    /**
     * Dimension used in the popup dialog display.
     */
    private int popupTotalHeight = MmgHelper.ScaleValue(120); 

    /**
     * A boolean flag used to test the game that causes the ball to bounce infintely.
     */    
    private boolean infiniteBounce = false;
    
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
        
        if(gameType == GameType.GAME_TWO_PLAYER) {
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
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "game_board.png";
        }        
        
        lval = MmgHelper.GetBasicCachedBmp(file);        
        bground = lval;
        if (bground != null) {
            MmgHelper.CenterHorAndVert(bground);            
            bground = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("gameBoard", bground, classConfig, bground.GetPosition());
            AddObj(bground);
        }
        
        //Load bounce normal sound
        key = "soundBounceNorm";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "jump1.wav";
        }          
        
        sval = MmgHelper.GetBasicCachedSound(file);
        bounceNorm = sval;
                
        //Load bounce super sound        
        key = "soundBounceSuper";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "jump2.wav";
        }          
        
        sval = MmgHelper.GetBasicCachedSound(file);
        bounceSuper = sval;
        
        //Load pong ball config
        key = "bmpPongBall";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "pong_ball.png";
        }        
        
        lval = MmgHelper.GetBasicCachedBmp(file);        
        ball = lval;
        if (ball != null) {
            MmgHelper.CenterHorAndVert(ball);            
            ball = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("pongBall", ball, classConfig, ball.GetPosition());
            ball.SetIsVisible(false);
            ballPos = ball.GetPosition();            
            AddObj(ball);
        }        
                
        //Load paddle left config
        key = "paddleLeftWidth";
        if(classConfig.containsKey(key)) {
            tmpW = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
        } else {
            tmpW = MmgHelper.ScaleValue(20);
        }
        
        key = "paddleLeftHeight";
        if(classConfig.containsKey(key)) {
            tmpH = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
        } else {
            tmpH = tmpH = (h / 6);
        }
        
        paddleLeft = MmgHelper.CreateFilledBmp(tmpW, tmpH, MmgColor.GetWhite());
        paddleLeft.SetPosition(MmgHelper.ScaleValue(20), screenPos.GetY() + (h - paddleLeft.GetHeight())/2);
        paddle1Pos = paddleLeft.GetPosition();
        AddObj(paddleLeft);
                
        //Load paddle right config
        key = "paddleRightWidth";
        if(classConfig.containsKey(key)) {
            tmpW = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
        } else {
            tmpW = MmgHelper.ScaleValue(20);
        }
        
        key = "paddleRightHeight";
        if(classConfig.containsKey(key)) {
            tmpH = MmgHelper.ScaleValue(classConfig.get(key).number.intValue());
        } else {
            tmpH = tmpH = (h / 6);
        }
        
        paddleRight = MmgHelper.CreateFilledBmp(tmpW, tmpH, MmgColor.GetLightGray());
        paddleRight.SetPosition((w - paddleRight.GetWidth() - MmgHelper.ScaleValue(20)), screenPos.GetY() + (h - paddleLeft.GetHeight())/2);                
        paddle2Pos = paddleRight.GetPosition();
        AddObj(paddleRight);
                    
        //Load score left config
        scoreLeft = MmgFontData.CreateDefaultBoldMmgFontLg();
        scoreLeft.SetText("00");
        scoreLeft.SetMmgColor(MmgColor.GetRed());
        scoreLeft.SetPosition(MmgHelper.ScaleValue(10) + paddleLeft.GetX() + paddleLeft.GetWidth(), screenPos.GetY() + scoreLeft.GetHeight() + MmgHelper.ScaleValue(5));

        key = "scoreLeftPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            scoreLeft.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "scoreLeftPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            scoreLeft.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "scoreLeftOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            scoreLeft.GetPosition().SetY(scoreLeft.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "scoreLeftOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            scoreLeft.GetPosition().SetX(scoreLeft.GetX() + MmgHelper.ScaleValue(tmp));
        }
        AddObj(scoreLeft);
                
        //Load score right config        
        scoreRight = MmgFontData.CreateDefaultBoldMmgFontLg();
        scoreRight.SetText("00");
        scoreRight.SetMmgColor(MmgColor.GetRed());
        scoreRight.SetPosition(w - scoreRight.GetWidth() - MmgHelper.ScaleValue(10) - paddleLeft.GetX() - paddleRight.GetWidth(), screenPos.GetY() + scoreRight.GetHeight() + MmgHelper.ScaleValue(5));

        key = "scoreRightPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            scoreRight.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "scoreRightPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            scoreRight.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "scoreRightOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            scoreRight.GetPosition().SetY(scoreRight.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "scoreRightOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            scoreRight.GetPosition().SetX(scoreRight.GetX() + MmgHelper.ScaleValue(tmp));
        }        
        AddObj(scoreRight);        
                   
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
        exit.SetPosition((w - exit.GetWidth())/2, screenPos.GetY() + exit.GetHeight() + MmgHelper.ScaleValue(5));
        
        key = "exitTextPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            exit.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "exitTextPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            exit.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "exitTextOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            exit.GetPosition().SetY(exit.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "exitTextOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            exit.GetPosition().SetX(exit.GetX() + MmgHelper.ScaleValue(tmp));
        }         
        
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
        
        key = "exitTextBgroundPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            exitBground.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "exitTextBgroundPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            exitBground.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "exitTextBgroundOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            exitBground.GetPosition().SetY(exitBground.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "exitTextBgroundOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            exitBground.GetPosition().SetX(exitBground.GetX() + MmgHelper.ScaleValue(tmp));
        } 
        AddObj(exitBground);        
        AddObj(exit);
                  
        //Load number one config
        key = "bmpNumberOne";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "num_1_lrg.png";
        }
        
        lval = MmgHelper.GetBasicCachedBmp(file);
        number1 = lval;
        if(number1 != null) {
            MmgHelper.CenterHorAndVert(number1);            
            number1 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberOne", number1, classConfig, number1.GetPosition());
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
            number2 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberTwo", number2, classConfig, number2.GetPosition());
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
            number3 = MmgHelper.ContainsKeyMmgBmpScaleAndPosition("numberThree", number3, classConfig, number3.GetPosition());
            number3.SetIsVisible(false);
            AddObj(number3);
        }
                
        //Load string game win config
        key = "strGoalText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Goal: First player to " + scoreGameWin + " points wins.";
        }         
        txtGoal = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGoal.SetText(file);
        txtGoal.SetMmgColor(MmgColor.GetWhite());        
        MmgHelper.CenterHorAndVert(txtGoal);
        txtGoal.SetY(number1.GetY() - txtGoal.GetHeight() + MmgHelper.ScaleValue(5));
        
        key = "goalTextPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtGoal.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "goalTextPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGoal.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "goalTextOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGoal.GetPosition().SetY(txtGoal.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "goalTextOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGoal.GetPosition().SetX(txtGoal.GetX() + MmgHelper.ScaleValue(tmp));
        }        
        
        txtGoal.SetIsVisible(false);
        AddObj(txtGoal);        
                
        //Load string player 1 direction config
        key = "strPlayer1DirectionText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 1: Right paddle, use UP, DOWN keys to move paddle.";
        }        
        txtDirecP1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtDirecP1.SetText(file);
        txtDirecP1.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtDirecP1);
        txtDirecP1.SetY(number1.GetY() + number1.GetHeight() + txtDirecP1.GetHeight() + MmgHelper.ScaleValue(10));
        
        key = "player1DirectionTextPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtDirecP1.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "player1DirectionTextPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtDirecP1.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "player1DirectionTextOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtDirecP1.GetPosition().SetY(txtDirecP1.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "player1DirectionTextOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtDirecP1.GetPosition().SetX(txtDirecP1.GetX() + MmgHelper.ScaleValue(tmp));
        }        
        
        txtDirecP1.SetIsVisible(false);
        AddObj(txtDirecP1);
                
        //Load string player 2 direction config
        key = "strPlayer2DirectionText";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 2: Left paddle, use MOUSE or S, X keys to move paddle.";
        }        
        txtDirecP2 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtDirecP2.SetText(file);
        txtDirecP2.SetMmgColor(MmgColor.GetWhite());
        MmgHelper.CenterHorAndVert(txtDirecP2);
        txtDirecP2.SetY(txtDirecP1.GetY() + txtDirecP1.GetHeight() + MmgHelper.ScaleValue(10));

        key = "player2DirectionTextPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtDirecP2.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "player2DirectionTextPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtDirecP2.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "player2DirectionTextOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtDirecP2.GetPosition().SetY(txtDirecP2.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "player2DirectionTextOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtDirecP2.GetPosition().SetX(txtDirecP2.GetX() + MmgHelper.ScaleValue(tmp));
        }

        txtDirecP2.SetIsVisible(false);        
        AddObj(txtDirecP2);
                
        //Load game over player 1 config
        key = "strTextGameOver1";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 1 has won the game. Press A or B to exit.";
        }        
        txtGameOver1 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGameOver1.SetText(file);
        txtGameOver1.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtGameOver1);
        
        key = "textGameOver1PosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtGameOver1.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "textGameOver1PosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGameOver1.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "textGameOver1OffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGameOver1.GetPosition().SetY(txtGameOver1.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "textGameOver1OffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGameOver1.GetPosition().SetX(txtGameOver1.GetX() + MmgHelper.ScaleValue(tmp));
        }
        
        txtGameOver1.SetIsVisible(false);
        AddObj(txtGameOver1);
                
        //Load game over player 2 config
        key = "strTextGameOver2";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Player 2 has won the game. Press A or B to exit.";
        }        
        txtGameOver2 = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtGameOver2.SetText(file);
        txtGameOver2.SetMmgColor(MmgColor.GetWhite());  
        MmgHelper.CenterHorAndVert(txtGameOver2);
        
        key = "textGameOver2PosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtGameOver2.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "textGameOver2PosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGameOver2.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "textGameOver2OffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGameOver2.GetPosition().SetY(txtGameOver2.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "textGameOver2OffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtGameOver2.GetPosition().SetX(txtGameOver2.GetX() + MmgHelper.ScaleValue(tmp));
        }        
        
        txtGameOver2.SetIsVisible(false);
        AddObj(txtGameOver2);        
                
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
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Exit Game (A)";
        }
        
        txtOk = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtOk.SetText(file);
        txtOk.SetMmgColor(MmgColor.GetWhite());        
        MmgHelper.CenterHorAndVert(txtOk);
        txtOk.SetY(bgroundPopup.GetY() + txtOk.GetHeight() + MmgHelper.ScaleValue(20));

        key = "popupWindowTextExitPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtOk.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "popupWindowTextExitPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtOk.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "popupWindowTextExitOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtOk.GetPosition().SetY(txtOk.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "popupWindowTextExitOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtOk.GetPosition().SetX(txtOk.GetX() + MmgHelper.ScaleValue(tmp));
        }

        txtOk.SetIsVisible(false);
        AddObj(txtOk);
                
        //Load popup window text cancel
        key = "strPopupWindowTextCancel";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "Cancel Exit (B)";
        }
        
        txtCancel = MmgFontData.CreateDefaultBoldMmgFontLg();
        txtCancel.SetText(file);
        txtCancel.SetMmgColor(MmgColor.GetWhite()); 
        MmgHelper.CenterHorAndVert(txtCancel);
        txtCancel.SetY(txtOk.GetY() + txtOk.GetHeight() + MmgHelper.ScaleValue(20));
        
        key = "popupWindowTextCancelPosY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();
            txtCancel.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "popupWindowTextCancelPosX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtCancel.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
        }

        key = "popupWindowTextCancelOffsetY";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
            txtCancel.GetPosition().SetY(txtCancel.GetY() + MmgHelper.ScaleValue(tmp));
        }

        key = "popupWindowTextCancelOffsetX";
        if(classConfig.containsKey(key)) {
            tmp = classConfig.get(key).number.intValue();                
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

    /**
     * Sets the current game type.
     * 
     * @param gt    The current game type.
     */
    public void SetGameType(GameType gt) {
        gameType = gt;
    }
    
    /**
     * Gets the current game type.
     * 
     * @return      The current game type.
     */
    public GameType GetGameType() {
        return gameType;
    }
    
    /**
     * Converts the given speed to a uniform speed per frame so that the game movement will
     * be the same even if the game runs at different frame rates.
     * 
     * @param speed     The target speed to convert to a speed per frame.
     * 
     * @return          A converted speed that represents the speed per frame of the given input speed. 
     */
    private static int GetSpeedPerFrame(int speed) {
        return (int)(speed/(PongClone.FPS - 4));        
    }

    /**
     * A method to handle A button click events from the MainFrame class.
     * 
     * @return      A boolean indicating if this Screen has handled the A click event.
     */
    @Override
    public boolean ProcessAClick(int src) {
        if(state == State.SHOW_GAME_EXIT) {
            owner.SwitchGameState(GameStates.MAIN_MENU);
            return true;
            
        } else if(state == State.SHOW_GAME_OVER) {
            owner.SwitchGameState(GameStates.MAIN_MENU);
            return true;
            
        }
        
        return false;
    }
    
    /**
     * A method to handle B button click events from the MainFrame class.
     * 
     * @return      A boolean indicating if this Screen has handled the B click event.
     */    
    @Override
    public boolean ProcessBClick(int src) {
        if(state == State.SHOW_GAME_OVER) {
            owner.SwitchGameState(GameStates.MAIN_MENU);
            return true;
            
        } else {
            if(state != State.SHOW_GAME_EXIT) {        
                SetState(State.SHOW_GAME_EXIT);
                return true;
            
            } else {
                SetState(statePrev);
                return true;
            }
        }
    }
    
    /**
     * A method to handle debug click events from the MainFrame class, the D key on the keyboard.
     * You can use this method to turn on different debugging helpers.
     */
    @Override
    public void ProcessDebugClick() {
        if(scoreGameWin > 1) {
            MmgHelper.wr("Setting game win score to 1.");
            scoreGameWin = 1;
        } else if(scoreGameWin == 1 && infiniteBounce == false) {
            MmgHelper.wr("Setting infinite bounce to true.");
            infiniteBounce = true;
        } else if(scoreGameWin == 1 && infiniteBounce == true) {
            MmgHelper.wr("Setting game win score to 7 and infinite bounce to false.");
            scoreGameWin = 7;
            infiniteBounce = false;
        }
    }

    /**
     * A method to handle key press events from the MainFrame class.
     * 
     * @param c     The character of the key that was pressed on the keyboard.
     * 
     * @return      A boolean indicating if the key press event was handled by this Screen.
     */
    @Override
    public boolean ProcessKeyPress(char c, int code) {
        if(state == State.SHOW_GAME && pause == false) {
            if(gameType == GameType.GAME_TWO_PLAYER) {
                if(c == 'x' || c == 'X') {            
                    paddle1MoveUp = false;
                    paddle1MoveDown = true;
                    return true;

                } else if(c == 's' || c == 'S') {            
                    paddle1MoveUp = true;
                    paddle1MoveDown = false;            
                    return true;

                }
            }
        }
        
        return false;        
    }
    
    /**
     * A method to handle key release events from the MainFrame class.
     * 
     * @param c     The character of the key that was released on the keyboard.
     * 
     * @return      A boolean indicating if the key release event was handled by this Screen.
     */    
    @Override
    public boolean ProcessKeyRelease(char c, int code) {
        if(state == State.SHOW_GAME && pause == false) {        
            if(gameType == GameType.GAME_TWO_PLAYER) {        
                if(c == 'x' || c == 'X') {
                    paddle1MoveDown = false;
                    return true;

                } else if(c == 's' || c == 'S') {
                    paddle1MoveUp = false;
                    return true;

                }
            }
        }
        
        return false;       
    }   
    
    /**
     * A method to handle dpad press events from the MainFrame class.
     * 
     * @param dir   The dpad code, UP, DOWN, LEFT, RIGHT of the direction that was pressed on the keyboard.
     * 
     * @return      A boolean indicating if the dpad press was handled by this Screen.
     */
    @Override
    public boolean ProcessDpadPress(int dir) {
        if(state == State.SHOW_GAME && pause == false) {
            if(dir == GameSettings.DOWN_KEYBOARD) {
                paddle2MoveUp = false;
                paddle2MoveDown = true;
                return true;

            } else if(dir == GameSettings.UP_KEYBOARD) {            
                paddle2MoveUp = true;
                paddle2MoveDown = false;            
                return true;

            } else if(this.gameType == GameType.GAME_TWO_PLAYER) {
                if(dir == GameSettings.DOWN_GAMEPAD_1 || dir == GameSettings.DOWN_GPIO) {
                    if(dir == GameSettings.DOWN_GPIO) {
                        MmgHelper.wr(("GPIO Gamepad Down Button Event"));
                    }
                    
                    paddle1MoveUp = false;
                    paddle1MoveDown = true;
                    return true;
                    
                } else if(dir == GameSettings.UP_GAMEPAD_1 || dir == GameSettings.UP_GPIO) {
                    if(dir == GameSettings.UP_GPIO) {
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

    /**
     * A method to handle dpad release events from the MainFrame class.
     * 
     * @param dir   The dpad code, UP, DOWN, LEFT, RIGHT of the direction that was released on the keyboard.
     * 
     * @return      A boolean indicating if the dpad release was handled by this Screen.
     */    
    @Override
    public boolean ProcessDpadRelease(int dir) {
        if(state == State.SHOW_GAME && pause == false) {        
            if(dir == GameSettings.DOWN_KEYBOARD) {
                paddle2MoveDown = false;
                return true;

            } else if(dir == GameSettings.UP_KEYBOARD) {
                paddle2MoveUp = false;
                return true;

            } else if(this.gameType == GameType.GAME_TWO_PLAYER) {
                if(dir == GameSettings.DOWN_GAMEPAD_1 || dir == GameSettings.DOWN_GPIO) {
                    paddle1MoveDown = false;
                    return true;
                    
                } else if(dir == GameSettings.UP_GAMEPAD_1 || dir == GameSettings.UP_GPIO) {
                    paddle1MoveUp = false;
                    return true;
                
                }                
            }
        }
        
        return false;
    }  
    
    /**
     * Processes mouse movement for player 2's input, the left hand paddle.
     * 
     * @param x     The X position of the mouse with the Screen's offset taken into account.
     * @param y     The Y position of the mouse with the Screen's offset taken into account.
     * 
     * @return      Returns a boolean indicating if the event was consumed by this game Screen. 
     */
    @Override
    public boolean ProcessMouseMove(int x, int y) {
        if(state == State.SHOW_GAME && pause == false) {        
            if(gameType == GameType.GAME_TWO_PLAYER) {
                if(y >= screenPos.GetY() && y <= (screenPos.GetY() + GetHeight() - paddleLeft.GetHeight())) {
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
    
    /**
     * Resets certain aspects of the UI that are related to the actual game.
     * Some aspects of the UI are left visible during the in-game count down.
     */
    private void ResetGame() {
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
    
    /**
     * Sets the Screen's current state. The state is used to prepare what MmgObj's are visible for the given state.
     * 
     * @param inS        The desired State to set the Screen to.
     */
    private void SetState(State inS) {        
        //clean up prev state
        switch(statePrev) {
            case NONE:
                break;
                
            case SHOW_GAME:
                break;
                
            case SHOW_COUNT_DOWN:
                break;
                
            case SHOW_COUNT_DOWN_IN_GAME:
                break;                
                
            case SHOW_GAME_OVER:
                break;
                
            case SHOW_GAME_EXIT:
                break;                
        }
        
        statePrev = state;
        state = inS;
        
        switch(state) {
            case NONE:
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
                
            case SHOW_GAME_OVER:
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
                
                if(scorePlayerRight == scoreGameWin) {
                    txtGameOver1.SetIsVisible(true);
                    txtGameOver2.SetIsVisible(false);
                    
                } else if(scorePlayerLeft == scoreGameWin) {
                    txtGameOver1.SetIsVisible(false);
                    txtGameOver2.SetIsVisible(true);
                    
                }
                numberState = NumberState.NONE;
                
                pause = false;
                isDirty = true;                
                break;
                
            case SHOW_GAME:
                if(statePrev != State.SHOW_GAME_EXIT) {
                    timeNumberMs = System.currentTimeMillis();
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
                
                if(statePrev != State.SHOW_GAME_EXIT) {                
                    if(rand.nextInt(11) % 2 == 0) {
                        ballDirX = 1;
                    } else {
                        ballDirX = -1;
                    }
                    ballMovePerFrameX = ballMovePerFrameMin;

                    if(rand.nextInt(11) % 2 == 0) {
                        ballDirY = 1;
                    } else {
                        ballDirY = -1;
                    }         
                    ballMovePerFrameY = ballMovePerFrameMin;                 
                }
                
                pause = false;
                isDirty = true;
                break;
                
            case SHOW_COUNT_DOWN_IN_GAME:                
                ball.SetIsVisible(true);               
                paddleLeft.SetIsVisible(true);
                paddleRight.SetIsVisible(true);
                bground.SetIsVisible(true);
                
                if(statePrev != State.SHOW_GAME_EXIT) {
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
                
                if(statePrev != State.SHOW_GAME_EXIT) {
                    numberState = NumberState.NONE;
                } else {
                    //reset this number count down
                    timeNumberMs = System.currentTimeMillis();
                }
                
                pause = false;
                isDirty = true;                
                break;
                
            case SHOW_COUNT_DOWN:
                ball.SetIsVisible(false);
                paddleLeft.SetIsVisible(false);
                paddleRight.SetIsVisible(false);
                bground.SetIsVisible(false);
                
                if(statePrev != State.SHOW_GAME_EXIT) {                
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
                
                if(statePrev != State.SHOW_GAME_EXIT) {                
                    numberState = NumberState.NONE;
                } else {
                    //reset this number count down
                    timeNumberMs = System.currentTimeMillis();
                }
                
                pause = false;
                isDirty = true;
                break;
                                
            case SHOW_GAME_EXIT:
                bgroundPopup.SetIsVisible(true);
                txtOk.SetIsVisible(true);
                txtCancel.SetIsVisible(true);
                isDirty = true;                
                break;                
        }        
    }
    
    /**
     * Updates player2's score, left hand paddle.
     * 
     * @param score     The score to set for player two.
     */    
    private void SetScoreLeftText(int score) {
        String tmp = score + "";
        if(tmp.length() != 2) {
            tmp = "0" + tmp;
        }
        scoreLeft.SetText(tmp);
    }
    
    /**
     * Updates player1's score, right hand paddle.
     * 
     * @param score     The score to set for player one.
     */
    private void SetScoreRightText(int score) {
        String tmp = score + "";
        if(tmp.length() != 2) {
            tmp = "0" + tmp;
        }
        scoreRight.SetText(tmp);
    }    
    
    /**
     * The DrawScreen method gets called by the MmgUpdate method if the Screen is not paused and is responsible for drawing the current screen state.
     */
    @Override
    public void DrawScreen() {
        //ran each game frame
        pause = true;
        
        switch(state) {
            case NONE:
                break;
                
            case SHOW_GAME_EXIT:
                break;
                
            case SHOW_COUNT_DOWN_IN_GAME:
            case SHOW_COUNT_DOWN:
                // <editor-fold>
                switch(numberState) {
                    case NONE:
                        // <editor-fold>                        
                        timeNumberMs = System.currentTimeMillis();
                        numberState = NumberState.NUMBER_3;
                        number1.SetIsVisible(false);
                        number2.SetIsVisible(false);
                        number3.SetIsVisible(true);
                        if(state == State.SHOW_COUNT_DOWN) {
                            txtGoal.SetIsVisible(true);                            
                            txtDirecP1.SetIsVisible(true);
                            if(gameType == GameType.GAME_TWO_PLAYER) {
                                txtDirecP2.SetIsVisible(true);
                            } else {
                                txtDirecP2.SetIsVisible(false);
                            }
                        } else {
                            txtGoal.SetIsVisible(false);
                            txtDirecP1.SetIsVisible(false);
                            txtDirecP2.SetIsVisible(false);
                        }
                        break;
                        // </editor-fold>                        
                        
                    case NUMBER_1:
                        // <editor-fold>
                        timeTmpMs = System.currentTimeMillis();
                        if(timeTmpMs - timeNumberMs >= timeNumberDisplayMs) {
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
                        // </editor-fold>
                        
                    case NUMBER_2:
                        // <editor-fold>
                        timeTmpMs = System.currentTimeMillis();
                        if(timeTmpMs - timeNumberMs >= timeNumberDisplayMs) {
                            timeNumberMs = timeTmpMs;
                            numberState = NumberState.NUMBER_1;                            
                            number1.SetIsVisible(true);
                            number2.SetIsVisible(false);
                            number3.SetIsVisible(false);
                            txtDirecP1.SetIsVisible(true);
                            if(state == State.SHOW_COUNT_DOWN) {
                                txtGoal.SetIsVisible(true);
                                if(gameType == GameType.GAME_TWO_PLAYER) {
                                    txtDirecP2.SetIsVisible(true);
                                } else {
                                    txtDirecP2.SetIsVisible(false);
                                }
                            } else {
                                txtGoal.SetIsVisible(false);
                                txtDirecP1.SetIsVisible(false);
                                txtDirecP2.SetIsVisible(false);
                            }
                            bounceNorm.Play();                            
                        }
                        break;
                        // </editor-fold>
                        
                    case NUMBER_3:
                        // <editor-fold>
                        timeTmpMs = System.currentTimeMillis();
                        if(timeTmpMs - timeNumberMs >= timeNumberDisplayMs) {
                            timeNumberMs = timeTmpMs;
                            numberState = NumberState.NUMBER_2;
                            number1.SetIsVisible(false);
                            number2.SetIsVisible(true);
                            number3.SetIsVisible(false);
                            if(state == State.SHOW_COUNT_DOWN) {
                                txtGoal.SetIsVisible(true);
                                if(gameType == GameType.GAME_TWO_PLAYER) {
                                    txtDirecP2.SetIsVisible(true);
                                } else {
                                    txtDirecP2.SetIsVisible(false);
                                }
                            } else {
                                txtGoal.SetIsVisible(false);
                                txtDirecP1.SetIsVisible(false);
                                txtDirecP2.SetIsVisible(false);
                            }                                
                            bounceNorm.Play();
                        }
                        break;
                        // </editor-fold>
                        
                }
                // </editor-fold>
                break;
                
            case SHOW_GAME:
                // <editor-fold>
                //player two movement
                if(gameType == GameType.GAME_TWO_PLAYER) {
                    // <editor-fold>
                    if(mousePos) {
                        paddle1Pos.SetY(lastY);
                    }

                    if(paddle1MoveUp) {
                        if(paddle1Pos.GetY() - paddle1MovePerFrame < screenPos.GetY()) {
                            paddle1Pos.SetY(screenPos.GetY());                
                        } else {
                            paddle1Pos.SetY(paddle1Pos.GetY() - paddle1MovePerFrame);
                        }

                    } else if(paddle1MoveDown) {
                        if(paddle1Pos.GetY() + paddleLeft.GetHeight() + paddle1MovePerFrame > screenPos.GetY() + GetHeight()) {
                            paddle1Pos.SetY(screenPos.GetY() + GetHeight() - paddleLeft.GetHeight());
                        } else {
                           paddle1Pos.SetY(paddle1Pos.GetY() + paddle1MovePerFrame);                            
                        }

                    }
                    // </editor-fold>
                } else {                    
                    //AI
                    // <editor-fold>
                    if(ballPos.GetY() + ball.GetHeight()/2 < paddleLeft.GetY()) {
                        if(paddle1Pos.GetY() - paddle1MovePerFrame < screenPos.GetY()) {
                            paddle1Pos.SetY(screenPos.GetY());                
                        } else {
                            paddle1Pos.SetY(paddle1Pos.GetY() - paddle1MovePerFrame);
                        }
                        
                    }else if(ballPos.GetY() + ball.GetHeight()/2 > paddleLeft.GetY() + paddleLeft.GetHeight()) {
                        if(paddle1Pos.GetY() + paddleLeft.GetHeight() + paddle1MovePerFrame > screenPos.GetY() + GetHeight()) {
                            paddle1Pos.SetY(screenPos.GetY() + GetHeight() - paddleLeft.GetHeight());
                        } else {
                           paddle1Pos.SetY(paddle1Pos.GetY() + paddle1MovePerFrame);                            
                        }
                        
                    }
                    // </editor-fold>
                }
                
                //player one movement
                if(paddle2MoveUp) {
                    // <editor-fold>
                    if(paddle2Pos.GetY() - paddle2MovePerFrame < screenPos.GetY()) {
                        paddle2Pos.SetY(screenPos.GetY());                
                    } else {
                        paddle2Pos.SetY(paddle2Pos.GetY() - paddle2MovePerFrame);
                    }
                    // </editor-fold>
                } else if(paddle2MoveDown) {
                    // <editor-fold>
                    if(paddle2Pos.GetY() + paddleRight.GetHeight() + paddle2MovePerFrame > screenPos.GetY() + GetHeight()) {
                        paddle2Pos.SetY(screenPos.GetY() + GetHeight() - paddleRight.GetHeight());
                    } else {
                       paddle2Pos.SetY(paddle2Pos.GetY() + paddle2MovePerFrame);                            
                    }
                    // </editor-fold>
                }
                
                //calculate where the ball will be
                ballNewX = ballPos.GetX() + (ballMovePerFrameX * ballDirX);
                ballNewY = ballPos.GetY() + (ballMovePerFrameY * ballDirY);

                //board collision
                if(ballNewY < screenPos.GetY()) {
                    //top
                    // <editor-fold>
                    ballDirY = 1;
                    ballNewX = (ballPos.GetX() + (ballMovePerFrameX * ballDirX));
                    ballNewY = ((screenPos.GetY()));
                    // </editor-fold>
                } else if(ballNewY + ball.GetHeight() > screenPos.GetY() + GetHeight()) {
                    //bottom
                    // <editor-fold>
                    ballDirY = -1;
                    ballNewX = (ballPos.GetX() + (ballMovePerFrameX * ballDirX));
                    ballNewY = ((screenPos.GetY() + GetHeight() - ball.GetHeight()));
                    // </editor-fold>
                }else if(ballNewX < screenPos.GetX()) {
                    //left
                    // <editor-fold>
                    ballDirX = 1;
                    ballNewX = ((screenPos.GetX()));
                    ballNewY = (ballPos.GetY() + (ballMovePerFrameY * ballDirY));
                    scorePlayerRight += 1;
                    SetScoreRightText(scorePlayerRight);
                    
                    if(infiniteBounce == false) {
                        if(scorePlayerRight == scoreGameWin) {
                            SetState(State.SHOW_GAME_OVER);                        
                        } else {
                            SetState(State.SHOW_COUNT_DOWN_IN_GAME);
                        }
                    }
                    // </editor-fold>
                } else if(ballNewX + ball.GetWidth() > screenPos.GetX() + GetWidth()) {
                    //right
                    // <editor-fold>
                    ballDirX = -1;
                    ballNewX = ((screenPos.GetX() + GetWidth() - ball.GetWidth()));
                    ballNewY = (ballPos.GetY() + (ballMovePerFrameY * ballDirY));                                                                            
                    scorePlayerLeft += 1;
                    SetScoreLeftText(scorePlayerLeft);
                    
                    if(infiniteBounce == false) {
                        if(scorePlayerLeft == scoreGameWin) {
                            SetState(State.SHOW_GAME_OVER);                        
                        } else {
                            SetState(State.SHOW_COUNT_DOWN_IN_GAME);
                        }
                    }
                    // </editor-fold>
                }
                
                bounced = false;
                //paddle1 collision
                if(ballNewX <= paddle1Pos.GetX() + paddleLeft.GetWidth() && ballDirX == -1) {
                    // <editor-fold>
                    if(ballNewY + ball.GetHeight()/2 >= paddle1Pos.GetY() + paddleLeft.GetHeight()/3 && ballNewY + ball.GetHeight()/2 <= paddle1Pos.GetY() + ((paddleLeft.GetHeight()/3) * 2)) {
                        //middle
                        ballMovePerFrameX *= 1.5;
                        ballMovePerFrameY = rand.nextInt(ballMovePerFrameMin);
                        ballDirX = 1;
                        if(rand.nextInt() % 2 == 0) {
                            ballDirY = 1;
                        } else {
                            ballDirY = -1;
                        }
                        bounced = true;
                        ballNewX = (paddle1Pos.GetX() + paddleLeft.GetWidth());

                    } else if(ballNewY + ball.GetHeight() >= paddle1Pos.GetY() && ballNewY + ball.GetHeight() <= paddle1Pos.GetY() + paddleLeft.GetHeight()/2) {
                        //top
                        ballMovePerFrameX *= 1.5;
                        ballDirX = 1;
                        ballDirY = -1;

                        if(ballMovePerFrameY == 0) {
                            ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.nextInt(ballMovePerFrameMin);
                        } else {                                                
                            ballMovePerFrameY *= 1.5;
                        }
                        bounced = true;
                        ballNewX = (paddle1Pos.GetX() + paddleLeft.GetWidth());

                    } else if(ballNewY >= paddle1Pos.GetY() + paddleLeft.GetHeight()/2 && ballNewY <= paddle1Pos.GetY() + paddleLeft.GetHeight()) {
                        //bottom
                        ballMovePerFrameX *= 1.5;
                        ballDirX = 1;                        
                        ballDirY = 1;

                        if(ballMovePerFrameY == 0) {
                            ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.nextInt(ballMovePerFrameMin);
                        } else {                        
                            ballMovePerFrameY *= 1.5;
                        }
                        bounced = true;
                        ballNewX = (paddle1Pos.GetX() + paddleLeft.GetWidth());

                    }
                    // </editor-fold>
                }

                //paddle2 collision
                if(ballNewX + ball.GetWidth() >= paddle2Pos.GetX() && ballDirX == 1) {
                    // <editor-fold>
                    if(ballNewY + ball.GetHeight()/2 >= paddle2Pos.GetY() + paddleRight.GetHeight()/3 && ballNewY + ball.GetHeight()/2 <= paddle2Pos.GetY() + ((paddleRight.GetHeight()/3) * 2)) {
                        //middle
                        ballMovePerFrameX *= 1.5;
                        ballMovePerFrameY =  rand.nextInt(ballMovePerFrameMin);
                        ballDirX = -1;
                        if(rand.nextInt() % 2 == 0) {
                            ballDirY = 1;
                        } else {
                            ballDirY = -1;
                        }
                        bounced = true;
                        ballNewX = (paddle2Pos.GetX() - ball.GetWidth());

                    } else if(ballNewY + ball.GetHeight() >= paddle2Pos.GetY() && ballNewY + ball.GetHeight() <= paddle2Pos.GetY() + paddleRight.GetHeight()/2) {
                        //top
                        ballMovePerFrameX *= 1.5;
                        ballDirX = -1;
                        ballDirY = -1;

                        if(ballMovePerFrameY == 0) {
                            ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.nextInt(ballMovePerFrameMin);
                        } else {                       
                            ballMovePerFrameY *= 1.5;                            
                        }
                        bounced = true;
                        ballNewX = (paddle2Pos.GetX() - ball.GetWidth());

                    } else if(ballNewY >= paddle2Pos.GetY() + paddleRight.GetHeight()/2 && ballNewY <= paddle2Pos.GetY() + paddleRight.GetHeight()) {
                        //bottom
                        ballMovePerFrameX *= 1.5;
                        ballDirX = -1;
                        ballDirY = 1;

                        if(ballMovePerFrameY == 0) {
                            ballMovePerFrameY = ballMovePerFrameMin + paddle1MovePerFrame + rand.nextInt(ballMovePerFrameMin);
                        } else {                       
                            ballMovePerFrameY *= 1.5;                            
                        }
                        bounced = true;
                        ballNewX = (paddle2Pos.GetX() - ball.GetWidth());

                    }
                    // </editor-fold>
                }                

                //set limits on the ball's speed
                if(ballMovePerFrameX > ballMovePerFrameMax) {
                    ballMovePerFrameX = ballMovePerFrameMax;
                }

                if(ballMovePerFrameY > ballMovePerFrameMax) {
                    ballMovePerFrameY = ballMovePerFrameMax;
                }

                //handle bounce sound
                if(bounced) {
                    if(ballMovePerFrameY == ballMovePerFrameMax || ballMovePerFrameX == ballMovePerFrameMax) {
                        bounceSuper.Play();
                    } else {
                        bounceNorm.Play();
                    }
                }
                      
                //update ball's position
                ballPos.SetX(ballNewX);
                ballPos.SetY(ballNewY);                
                break;
                // </editor-fold>
        }
        
        pause = false;
    }
    
    /**
     * Unloads resources needed to display this game screen.
     */
    @Override
    public void UnloadResources() {
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
        
        super.UnloadResources();
        
        ClearObjs();
        ready = false;
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
}