package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.GraphicsConfiguration;
import java.awt.GraphicsEnvironment;

/**
 * A class that represents the screen data of the game.
 * Also provides helper methods for scaling.
 * Created by Middlemind Games 06/01/2005
 *
 * @author Victor G. Brusca
 */
public class MmgScreenData {    

    /**
     * Environment graphics configuration data to use when creating new bitmaps to draw on.
     */
    public static final GraphicsConfiguration GRAPHICS_CONFIG = GraphicsEnvironment.getLocalGraphicsEnvironment().getDefaultScreenDevice().getDefaultConfiguration();
        
    /**
     * An enumeration used to track the scaling mode used by this class.
     */
    public enum ScalingMode {
        AXIS_X,
        AXIS_Y,
        AXIS_X_AND_Y,
        NONE
    }
    
    /**
     * The scaling mode to use by this class when scaling the game screen into the window screen.
     */
    public static ScalingMode scalingMode = ScalingMode.AXIS_X_AND_Y;
            
    /**
     * Default screen width.
     */
    public static int DEFAULT_WIDTH = 1024;

    /**
     * Default screen height.
     */
    public static int DEFAULT_HEIGHT = 768;

    /**
     * Game screen width.
     */
    private static int gameWidth;

    /**
     * Game screen height.
     */
    private static int gameHeight;

    /**
     * Game screen offset, X axis.
     */
    private static int gameLeft;

    /**
     * Game screen offset, Y axis.
     */
    private static int gameTop;

    /**
     * Screen width.
     */
    private static int screenWidth;

    /**
     * Screen height.
     */
    private static int screenHeight;

    /**
     * A class helper variable for scaling the game to match the screen size.
     */
    private static double scaleX;

    /**
     * A class helper variable for scaling the game to match the screen size.
     */
    private static double scaleY;

    /**
     * A class helper variable for setting X axis scaling on.
     */
    private static boolean scaleXOn;

    /**
     * A class helper variable for setting Y axis scaling on.
     */
    private static boolean scaleYOn;

    /**
     * A class helper variable for the scaling vector.
     */
    private static MmgVector2 scaleVec = MmgVector2.GetUnitVec();

    /**
     * A class helper variable for the position vector.
     */
    private static MmgVector2 posVec;

    /**
     * A class helper variable for tracking the original value of the game width;
     */
    private static int origGameWidth;

    /**
     * A class helper variable for tracking the original value of the game height;
     */    
    private static int origGameHeight;    
    
    /**
     * Constructor for this class that sets all default values.
     */
    public MmgScreenData() {
        MmgScreenData.gameWidth = DEFAULT_WIDTH;
        MmgScreenData.gameHeight = DEFAULT_HEIGHT;
        MmgScreenData.origGameWidth = MmgScreenData.gameWidth;
        MmgScreenData.origGameHeight = MmgScreenData.gameHeight;        
        MmgScreenData.gameLeft = 0;
        MmgScreenData.gameTop = 0;
        MmgScreenData.screenWidth = DEFAULT_WIDTH;
        MmgScreenData.screenHeight = DEFAULT_HEIGHT;
        MmgScreenData.scaleX = 1;
        MmgScreenData.scaleY = 1;
        MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
        MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);
    }

    /**
     * Constructor for this class that sets the screen width and height to the
     * same given values as the game width and height.
     *
     * @param w     The game and screen width.
     * @param h     The game and screen height.
     */
    public MmgScreenData(int w, int h) {
        MmgScreenData.gameWidth = w;
        MmgScreenData.gameHeight = h;
        MmgScreenData.origGameWidth = MmgScreenData.gameWidth;
        MmgScreenData.origGameHeight = MmgScreenData.gameHeight;                
        MmgScreenData.gameLeft = 0;
        MmgScreenData.gameTop = 0;
        MmgScreenData.screenWidth = w;
        MmgScreenData.screenHeight = h;
        MmgScreenData.scaleX = 1.0f;
        MmgScreenData.scaleY = 1.0f;
        MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
        MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);
    }

    /**
     * Constructor for this class that sets the screen dimensions and the game
     * dimensions.
     *
     * @param ScreenWidth       The screen width.
     * @param ScreenHeight      The screen height.
     * @param GameWidth         The game width.
     * @param GameHeight        The game height.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgScreenData(int ScreenWidth, int ScreenHeight, int GameWidth, int GameHeight) {
        MmgScreenData.screenWidth = ScreenWidth;
        MmgScreenData.screenHeight = ScreenHeight;
        MmgScreenData.gameWidth = GameWidth;
        MmgScreenData.gameHeight = GameHeight;
        MmgScreenData.origGameWidth = MmgScreenData.gameWidth;
        MmgScreenData.origGameHeight = MmgScreenData.gameHeight;                
        MmgScreenData.CalculateScaleAndOffset();
        MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
        MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);
    }

    /**
     * A string representation of the screen data.
     *
     * @return      A string representing the screen data state.
     */
    public static String ApiToString() {
        String ret = "";
        ret += "Screen Width: " + MmgScreenData.GetScreenWidth() + System.lineSeparator();
        ret += "Screen Height: " + MmgScreenData.GetScreenHeight() + System.lineSeparator();
        ret += "Game Width: " + MmgScreenData.GetGameWidth() + System.lineSeparator();
        ret += "Game Height: " + MmgScreenData.GetGameHeight() + System.lineSeparator();
        ret += "Game Offset X: " + MmgScreenData.GetGameLeft() + System.lineSeparator();
        ret += "Game Offset Y: " + MmgScreenData.GetGameTop() + System.lineSeparator();
        ret += "Scale X: " + MmgScreenData.GetScaleX() + System.lineSeparator();
        ret += "Scale Y: " + MmgScreenData.GetScaleY() + System.lineSeparator();
        return ret;
    }

    /**
     * Gets the game width.
     *
     * @return      The game width.
     */
    public static int GetGameWidth() {
        return MmgScreenData.gameWidth;
    }

    /**
     * Sets the game width.
     *
     * @param w     The game width.
     */
    public static void SetGameWidth(int w) {
        MmgScreenData.gameWidth = w;
    }

    /**
     * Gets the game top position, Y axis.
     *
     * @return      The game top position, Y axis.
     */
    public static int GetGameTop() {
        return MmgScreenData.gameTop;
    }

    /**
     * Gets the game bottom position, Y axis.
     *
     * @return      The game bottom position, Y axis.
     */    
    public static int GetGameBottom() {
        return (MmgScreenData.gameTop + MmgScreenData.gameHeight);
    }
    
    /**
     * Sets the game top position, Y axis.
     *
     * @param t     The game top position, Y axis.
     */
    public static void SetGameTop(int t) {
        MmgScreenData.gameTop = t;
    }

    /**
     * Gets the game left position, X axis.
     *
     * @return      The game left position, X axis.
     */
    public static int GetGameLeft() {
        return MmgScreenData.gameLeft;
    }

    /**
     * Gets the game right position, X axis.
     *
     * @return      The game right position, X axis.
     */
    public static int GetGameRight() {
        return (MmgScreenData.gameLeft + MmgScreenData.gameWidth);
    }    
    
    /**
     * Sets the game left position, Y axis.
     *
     * @param l     The game left position, Y axis.
     */
    public static void SetGameLeft(int l) {
        MmgScreenData.gameLeft = l;
    }

    /**
     * Gets the game screen height.
     *
     * @return      The game screen height.
     */
    public static int GetGameHeight() {
        return MmgScreenData.gameHeight;
    }

    /**
     * Sets the game screen height.
     *
     * @param h     The game screen height.
     */
    public static void SetGameHeight(int h) {
        MmgScreenData.gameHeight = h;
    }

    /**
     * Sets the screen width.
     *
     * @param w     The screen width.
     */
    public static void SetScreenWidth(int w) {
        MmgScreenData.screenWidth = w;
    }

    /**
     * Gets the screen width.
     *
     * @return      The screen width.
     */
    public static int GetScreenWidth() {
        return MmgScreenData.screenWidth;
    }

    /**
     * Sets the screen height.
     *
     * @param h     The screen height.
     */
    public static void SetScreenHeight(int h) {
        MmgScreenData.screenHeight = h;
    }

    /**
     * Gets the screen height.
     *
     * @return      The screen height.
     */
    public static int GetScreenHeight() {
        return MmgScreenData.screenHeight;
    }

    /**
     * Gets scale X.
     *
     * @return      The X scale value.
     */
    public static double GetScaleX() {
        return MmgScreenData.scaleX;
    }

    /**
     * Sets scale X.
     *
     * @param x     The X scale value.
     */
    public static void SetScaleX(double x) {
        MmgScreenData.scaleX = x;
    }

    /**
     * Gets scale Y.
     *
     * @return      The scale Y value.
     */
    public static double GetScaleY() {
        return MmgScreenData.scaleY;
    }

    /**
     * Sets scale Y.
     *
     * @param y     The scale Y value.
     */
    public static void SetScaleY(double y) {
        MmgScreenData.scaleY = y;
    }

    /**
     * Gets if scale X is on.
     *
     * @return      If scale X is on.
     */
    public static boolean GetScaleXOn() {
        return MmgScreenData.scaleXOn;
    }

    /**
     * Sets if scale X is on.
     *
     * @param b     If scale X is on.
     */
    public static void SetScaleXOn(boolean b) {
        MmgScreenData.scaleXOn = b;
    }

    /**
     * Gets if scale Y is on.
     *
     * @return      If scale Y is on.
     */
    public static boolean GetScaleYOn() {
        return MmgScreenData.scaleYOn;
    }

    /**
     * Sets if scale Y is on.
     *
     * @param b     If scale Y is on.
     */
    public static void SetScaleYOn(boolean b) {
        MmgScreenData.scaleYOn = b;
    }

    /**
     * Gets the scale vector.
     *
     * @return      The scale vector.
     */
    public static MmgVector2 GetScale() {
        return MmgScreenData.scaleVec;
    }

    /**
     * Sets the scale vector.
     * 
     * @param v     The scale vector.
     */
    public static void SetScale(MmgVector2 v) {
        MmgScreenData.scaleVec = v;
    }
    
    /**
     * Gets the position vector.
     *
     * @return      The position vector.
     */
    public static MmgVector2 GetPosition() {
        return MmgScreenData.posVec;
    }

    /**
     * Calculates the game screen's top offset.
     */
    private static void CalculateTop() {
        MmgScreenData.gameTop = (MmgScreenData.screenHeight - MmgScreenData.gameHeight) / 2;
    }

    /**
     * Calculates the game screen's left offset.
     */
    private static void CalculateLeft() {
        MmgScreenData.gameLeft = (MmgScreenData.screenWidth - MmgScreenData.gameWidth) / 2;
    }

    /**
     * Calculates the scale value on the X axis for the game. 
     * Based on the screen dimensions and the default game width and height.
     * 
     * @param agg       A flag indicating if aggregate value are calculated.
     */
    @SuppressWarnings("UnusedAssignment")
    private static void CalculateScaleX(boolean agg) {
        double test = 32.0f;
        double resF;
        double resI;
        double prctDiffX;
        int panic = 5000;
        int count;
        int resIi = 0;
        double dir = -1;
        double diff = 0;
        double diffSm = 1000000;
        double prctDiffXSm = 1.0d;        

        prctDiffX = ((double) MmgScreenData.screenWidth / (double) MmgScreenData.gameWidth);
        dir = -1;
        resF = test * prctDiffX;
        resI = (float) ((int) resF);
        resIi = (int) resI;
        count = 0;
        diff = Math.abs((resF - resI));

        while ((diff > 0.01 || resIi % 2 != 0) && count < panic) {
            prctDiffX += (dir * 0.000250);
            resF = test * prctDiffX;
            resI = (double) ((int) resF);
            resIi = (int) resI;
            count++;
            diff = Math.abs((resF - resI));
            
            if(diff < diffSm) {
                diffSm = diff;
                prctDiffXSm = prctDiffX;
            }
        }

        if(count >= panic) {
            prctDiffX = prctDiffXSm;
            diff = diffSm;
        }
        
        MmgScreenData.scaleXOn = true;
        MmgScreenData.scaleYOn = true;
        if(agg) {
            MmgScreenData.scaleX += prctDiffX;
            MmgScreenData.scaleY += prctDiffX;
        } else {
            MmgScreenData.scaleX = prctDiffX;
            MmgScreenData.scaleY = prctDiffX;
        }
        MmgScreenData.gameWidth *= prctDiffX;
        MmgScreenData.gameHeight *= prctDiffX;
        CalculateTop();
        CalculateLeft();
        MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
        MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);        
        MmgHelper.wr("Calculate Scale X: Found X,Y Scale: " + prctDiffX + ", ResF: " + resF + ", ResI: " + resI + ", Diff: " + diff + ", Count: " + count);
    }

    /**
     * Calculates the scale value on the Y axis for the game. 
     * Based on the screen dimensions and the default game width and height.
     * 
     * @param agg       A flag indicating if aggregate value are calculated.
     */
    @SuppressWarnings("UnusedAssignment")
    private static void CalculateScaleY(boolean agg) {
        double test = 32.0f;
        double resF;
        double resI;
        double prctDiffY;
        int panic = 5000;
        int count;
        int resIi = 0;
        double dir = -1;
        double diff = 0;
        double diffSm = 1000000;
        double prctDiffYSm = 1.0d;

        prctDiffY = ((double) MmgScreenData.screenHeight / (double) MmgScreenData.gameHeight);
        dir = -1;
        resF = test * prctDiffY;
        resI = (double) ((int) resF);
        resIi = (int) resI;
        count = 0;
        diff = Math.abs((resF - resI));

        while ((diff > 0.01 || resIi % 2 != 0) && count < panic) {
            prctDiffY += (dir * 0.000250);
            resF = test * prctDiffY;
            resI = (double) ((int) resF);
            resIi = (int) resI;
            count++;
            diff = Math.abs((resF - resI));
            
            if(diff < diffSm) {
                diffSm = diff;
                prctDiffYSm = prctDiffY;
            }
        }

        if(count >= panic) {
            prctDiffY = prctDiffYSm;
            diff = diffSm;
        }
            
        MmgScreenData.scaleXOn = true;
        MmgScreenData.scaleYOn = true;
        if(agg) {
            MmgScreenData.scaleX += prctDiffY;
            MmgScreenData.scaleY += prctDiffY;
        } else {
            MmgScreenData.scaleX = prctDiffY;
            MmgScreenData.scaleY = prctDiffY;
        }
        MmgScreenData.gameWidth *= prctDiffY;
        MmgScreenData.gameHeight *= prctDiffY;
        CalculateTop();
        CalculateLeft();
        MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
        MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);        
        MmgHelper.wr("Calculate Scale Y: Found Updated X, Y Scale: " + prctDiffY + ", ResF: " + resF + ", ResI: " + resI + ", Diff: " + diff + ", Count: " + count);
    }

    /**
     * Calculates the scale and offset needed to adjust the game screen inside
     * the screen dimensions.
     */
    public static void CalculateScaleAndOffset() {
        MmgScreenData.gameWidth = MmgScreenData.origGameWidth;
        MmgScreenData.gameHeight = MmgScreenData.origGameHeight;
        
        if (MmgScreenData.screenHeight == MmgScreenData.gameHeight && MmgScreenData.screenWidth == MmgScreenData.gameWidth) {
            MmgScreenData.scaleX = 1.0f;
            MmgScreenData.scaleY = 1.0f;
            MmgScreenData.gameTop = 0;
            MmgScreenData.gameLeft = 0;
            MmgScreenData.scaleXOn = false;
            MmgScreenData.scaleYOn = false;
        } else {
            if(MmgScreenData.scalingMode == ScalingMode.AXIS_X) {
                CalculateScaleX(false);

            } else if(MmgScreenData.scalingMode == ScalingMode.AXIS_Y) {
                CalculateScaleY(false);

            } else if(MmgScreenData.scalingMode == ScalingMode.AXIS_X_AND_Y) {
                CalculateScaleX(false);
                if (MmgScreenData.gameHeight > MmgScreenData.screenHeight) {
                    CalculateScaleY(true);
                }
            } else {
                MmgScreenData.scaleX = 1.0f;
                MmgScreenData.scaleY = 1.0f;
                MmgScreenData.gameTop = 0;
                MmgScreenData.gameLeft = 0;
                MmgScreenData.scaleXOn = false;
                MmgScreenData.scaleYOn = false;                
            }
        }
    }
}