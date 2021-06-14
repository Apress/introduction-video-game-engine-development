using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that represents the screen data of the game.
    /// Also provides helper methods for scaling.
    /// Created by Middlemind Games 06/01/2005
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgScreenData
    {
        /// <summary>
        /// Environment graphics configuration data to use when creating new bitmaps to draw on.
        /// </summary>
        public static GraphicsDevice GRAPHICS_CONFIG;

        //NOTE: Monogame specific change required for Monogame content loading of fonts.
        /// <summary>
        /// A Monogame based content manager used to load resources from the Monogame resource file.
        /// </summary>
        public static ContentManager CONTENT_MANAGER;

        /// <summary>
        /// An enumeration used to track the scaling mode used by this class.
        /// </summary>
        public enum ScalingMode
        {
            AXIS_X,
            AXIS_Y,
            AXIS_X_AND_Y,
            NONE
        }

        /// <summary>
        /// The scaling mode to use by this class when scaling the game screen into the window screen.
        /// </summary>
        public static ScalingMode scalingMode = ScalingMode.AXIS_X_AND_Y;

        /// <summary>
        /// Default screen width.
        /// </summary>
        public static int DEFAULT_WIDTH = 1024;

        /// <summary>
        /// Default screen height.
        /// </summary>
        public static int DEFAULT_HEIGHT = 768;

        /// <summary>
        /// Game screen width.
        /// </summary>
        private static int gameWidth;

        /// <summary>
        /// Game screen height.
        /// </summary>
        private static int gameHeight;

        /// <summary>
        /// Game screen offset, X axis.
        /// </summary>
        private static int gameLeft;

        /// <summary>
        /// Game screen offset, Y axis.
        /// </summary>
        private static int gameTop;

        /// <summary>
        /// Screen width.
        /// </summary>
        private static int screenWidth;

        /// <summary>
        /// Screen height.
        /// </summary>
        private static int screenHeight;

        /// <summary>
        /// A class helper variable for scaling the game to match the screen size.
        /// </summary>
        private static double scaleX;

        /// <summary>
        /// A class helper variable for scaling the game to match the screen size.
        /// </summary>
        private static double scaleY;

        /// <summary>
        /// A class helper variable for setting X axis scaling on.
        /// </summary>
        private static bool scaleXOn;

        /// <summary>
        /// A class helper variable for setting Y axis scaling on.
        /// </summary>
        private static bool scaleYOn;

        /// <summary>
        /// A class helper variable for the scaling vector.
        /// </summary>
        private static MmgVector2 scaleVec = MmgVector2.GetUnitVec();

        /// <summary>
        /// A class helper variable for the position vector. 
        /// </summary>
        private static MmgVector2 posVec;

        /// <summary>
        /// A class helper variable for tracking the original value of the game width;
        /// </summary>
        private static int origGameWidth;

        /// <summary>
        /// A class helper variable for tracking the original value of the game height;
        /// </summary>
        private static int origGameHeight;

        /// <summary>
        /// Constructor for this class that sets all default values.
        /// </summary>
        public MmgScreenData()
        {
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

        /// <summary>
        /// Constructor for this class that sets the screen width and height to the
        /// same given values as the game width and height.
        /// </summary>
        /// <param name="w">The game and screen width.</param>
        /// <param name="h">The game and screen height.</param>
        public MmgScreenData(int w, int h)
        {
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

        /// <summary>
        /// Constructor for this class that sets the screen dimensions and the game dimensions.
        /// </summary>
        /// <param name="ScreenWidth">The screen width.</param>
        /// <param name="ScreenHeight">The screen height.</param>
        /// <param name="GameWidth">The game width.</param>
        /// <param name="GameHeight">The game height.</param>
        public MmgScreenData(int ScreenWidth, int ScreenHeight, int GameWidth, int GameHeight)
        {
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

        /// <summary>
        /// A string representation of the screen data.
        /// </summary>
        /// <returns>A string representing the screen data state.</returns>
        public static string ApiToString()
        {
            string ret = "";
            ret += "Screen Width: " + MmgScreenData.GetScreenWidth() + System.Environment.NewLine;
            ret += "Screen Height: " + MmgScreenData.GetScreenHeight() + System.Environment.NewLine;
            ret += "Game Width: " + MmgScreenData.GetGameWidth() + System.Environment.NewLine;
            ret += "Game Height: " + MmgScreenData.GetGameHeight() + System.Environment.NewLine;
            ret += "Game Offset X: " + MmgScreenData.GetGameLeft() + System.Environment.NewLine;
            ret += "Game Offset Y: " + MmgScreenData.GetGameTop() + System.Environment.NewLine;
            ret += "Scale X: " + MmgScreenData.GetScaleX() + System.Environment.NewLine;
            ret += "Scale Y: " + MmgScreenData.GetScaleY() + System.Environment.NewLine;
            return ret;
        }

        /// <summary>
        /// Gets the game width.
        /// </summary>
        /// <returns>The game width.</returns>
        public static int GetGameWidth()
        {
            return MmgScreenData.gameWidth;
        }

        /// <summary>
        /// Sets the game width.
        /// </summary>
        /// <param name="w">The game width.</param>
        public static void SetGameWidth(int w)
        {
            MmgScreenData.gameWidth = w;
        }

        /// <summary>
        /// Gets the game top position, Y axis.
        /// </summary>
        /// <returns>The game top position, Y axis.</returns>
        public static int GetGameTop()
        {
            return MmgScreenData.gameTop;
        }

        /// <summary>
        /// Gets the game bottom position, Y axis.
        /// </summary>
        /// <returns>The game bottom position, Y axis.</returns>
        public static int GetGameBottom()
        {
            return (MmgScreenData.gameTop + MmgScreenData.gameHeight);
        }

        /// <summary>
        /// Sets the game top position, Y axis.
        /// </summary>
        /// <param name="t">The game top position, Y axis.</param>
        public static void SetGameTop(int t)
        {
            MmgScreenData.gameTop = t;
        }

        /// <summary>
        /// Gets the game left position, X axis.
        /// </summary>
        /// <returns>The game left position, X axis.</returns>
        public static int GetGameLeft()
        {
            return MmgScreenData.gameLeft;
        }

        /// <summary>
        /// Gets the game right position, X axis.
        /// </summary>
        /// <returns>The game right position, X axis.</returns>
        public static int GetGameRight()
        {
            return (MmgScreenData.gameLeft + MmgScreenData.gameWidth);
        }

        /// <summary>
        /// Sets the game left position, Y axis.
        /// </summary>
        /// <param name="l">The game left position, Y axis.</param>
        public static void SetGameLeft(int l)
        {
            MmgScreenData.gameLeft = l;
        }

        /// <summary>
        /// Gets the game screen height.
        /// </summary>
        /// <returns>The game screen height.</returns>
        public static int GetGameHeight()
        {
            return MmgScreenData.gameHeight;
        }

        /// <summary>
        /// Sets the game screen height.
        /// </summary>
        /// <param name="h">The game screen height.</param>
        public static void SetGameHeight(int h)
        {
            MmgScreenData.gameHeight = h;
        }

        /// <summary>
        /// Sets the screen width.
        /// </summary>
        /// <param name="w">The screen width.</param>
        public static void SetScreenWidth(int w)
        {
            MmgScreenData.screenWidth = w;
        }

        /// <summary>
        /// Gets the screen width.
        /// </summary>
        /// <returns>The screen width.</returns>
        public static int GetScreenWidth()
        {
            return MmgScreenData.screenWidth;
        }

        /// <summary>
        /// Sets the screen height.
        /// </summary>
        /// <param name="h">The screen height.</param>
        public static void SetScreenHeight(int h)
        {
            MmgScreenData.screenHeight = h;
        }

        /// <summary>
        /// Gets the screen height.
        /// </summary>
        /// <returns>The screen height.</returns>
        public static int GetScreenHeight()
        {
            return MmgScreenData.screenHeight;
        }

        /// <summary>
        /// Gets scale X.
        /// </summary>
        /// <returns>The X scale value.</returns>
        public static double GetScaleX()
        {
            return MmgScreenData.scaleX;
        }

        /// <summary>
        /// Sets scale X.
        /// </summary>
        /// <param name="x">The X scale value.</param>
        public static void SetScaleX(double x)
        {
            MmgScreenData.scaleX = x;
        }

        /// <summary>
        /// Gets scale Y.
        /// </summary>
        /// <returns>The scale Y value.</returns>
        public static double GetScaleY()
        {
            return MmgScreenData.scaleY;
        }

        /// <summary>
        /// Sets scale Y.
        /// </summary>
        /// <param name="y">The scale Y value.</param>
        public static void SetScaleY(double y)
        {
            MmgScreenData.scaleY = y;
        }

        /// <summary>
        /// Gets if scale X is on.
        /// </summary>
        /// <returns>If scale X is on.</returns>
        public static bool GetScaleXOn()
        {
            return MmgScreenData.scaleXOn;
        }

        /// <summary>
        /// Sets if scale X is on.
        /// </summary>
        /// <param name="b">If scale X is on.</param>
        public static void SetScaleXOn(bool b)
        {
            MmgScreenData.scaleXOn = b;
        }

        /// <summary>
        /// Gets if scale Y is on.
        /// </summary>
        /// <returns>If scale Y is on.</returns>
        public static bool GetScaleYOn()
        {
            return MmgScreenData.scaleYOn;
        }

        /// <summary>
        /// Sets if scale Y is on.
        /// </summary>
        /// <param name="b">If scale Y is on.</param>
        public static void SetScaleYOn(bool b)
        {
            MmgScreenData.scaleYOn = b;
        }

        /// <summary>
        /// Gets the scale vector.
        /// </summary>
        /// <returns>The scale vector.</returns>
        public static MmgVector2 GetScale()
        {
            return MmgScreenData.scaleVec;
        }

        /// <summary>
        /// Sets the scale vector.
        /// </summary>
        /// <param name="v">The scale vector.</param>
        public static void SetScale(MmgVector2 v)
        {
            MmgScreenData.scaleVec = v;
        }

        /// <summary>
        /// Gets the position vector.
        /// </summary>
        /// <returns>The position vector.</returns>
        public static MmgVector2 GetPosition()
        {
            return MmgScreenData.posVec;
        }

        /// <summary>
        /// Calculates the game screen's top offset.
        /// </summary>
        private static void CalculateTop()
        {
            MmgScreenData.gameTop = (MmgScreenData.screenHeight - MmgScreenData.gameHeight) / 2;
        }

        /// <summary>
        /// Calculates the game screen's left offset.
        /// </summary>
        private static void CalculateLeft()
        {
            MmgScreenData.gameLeft = (MmgScreenData.screenWidth - MmgScreenData.gameWidth) / 2;
        }

        /// <summary>
        /// Calculates the scale value on the X axis for the game. 
        /// Based on the screen dimensions and the default game width and height.
        /// </summary>
        /// <param name="agg">A flag indicating if aggregate value are calculated.</param>
        private static void CalculateScaleX(bool agg)
        {
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

            prctDiffX = ((double)MmgScreenData.screenWidth / (double)MmgScreenData.gameWidth);
            dir = -1;
            resF = test * prctDiffX;
            resI = (float)((int)resF);
            resIi = (int)resI;
            count = 0;
            diff = Math.Abs((resF - resI));

            while ((diff > 0.01 || resIi % 2 != 0) && count < panic)
            {
                prctDiffX += (dir * 0.000250);
                resF = test * prctDiffX;
                resI = (double)((int)resF);
                resIi = (int)resI;
                count++;
                diff = Math.Abs((resF - resI));

                if (diff < diffSm)
                {
                    diffSm = diff;
                    prctDiffXSm = prctDiffX;
                }
            }

            if (count >= panic)
            {
                prctDiffX = prctDiffXSm;
                diff = diffSm;
            }

            MmgScreenData.scaleXOn = true;
            MmgScreenData.scaleYOn = true;
            if (agg)
            {
                MmgScreenData.scaleX += prctDiffX;
                MmgScreenData.scaleY += prctDiffX;
            }
            else
            {
                MmgScreenData.scaleX = prctDiffX;
                MmgScreenData.scaleY = prctDiffX;
            }
            MmgScreenData.gameWidth = (int)(MmgScreenData.gameWidth * prctDiffX);
            MmgScreenData.gameHeight = (int)(MmgScreenData.gameHeight * prctDiffX);
            CalculateTop();
            CalculateLeft();
            MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
            MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);
            MmgHelper.wr("Calculate Scale X: Found X,Y Scale: " + prctDiffX + ", ResF: " + resF + ", ResI: " + resI + ", Diff: " + diff + ", Count: " + count);
        }

        /// <summary>
        /// Calculates the scale value on the Y axis for the game. 
        /// Based on the screen dimensions and the default game width and height.
        /// </summary>
        /// <param name="agg">A flag indicating if aggregate value are calculated.</param>
        private static void CalculateScaleY(bool agg)
        {
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

            prctDiffY = ((double)MmgScreenData.screenHeight / (double)MmgScreenData.gameHeight);
            dir = -1;
            resF = test * prctDiffY;
            resI = (double)((int)resF);
            resIi = (int)resI;
            count = 0;
            diff = Math.Abs((resF - resI));

            while ((diff > 0.01 || resIi % 2 != 0) && count < panic)
            {
                prctDiffY += (dir * 0.000250);
                resF = test * prctDiffY;
                resI = (double)((int)resF);
                resIi = (int)resI;
                count++;
                diff = Math.Abs((resF - resI));

                if (diff < diffSm)
                {
                    diffSm = diff;
                    prctDiffYSm = prctDiffY;
                }
            }

            if (count >= panic)
            {
                prctDiffY = prctDiffYSm;
                diff = diffSm;
            }

            MmgScreenData.scaleXOn = true;
            MmgScreenData.scaleYOn = true;
            if (agg)
            {
                MmgScreenData.scaleX += prctDiffY;
                MmgScreenData.scaleY += prctDiffY;
            }
            else
            {
                MmgScreenData.scaleX = prctDiffY;
                MmgScreenData.scaleY = prctDiffY;
            }
            MmgScreenData.gameWidth = (int)(MmgScreenData.gameWidth * prctDiffY);
            MmgScreenData.gameHeight = (int)(MmgScreenData.gameHeight * prctDiffY);
            CalculateTop();
            CalculateLeft();
            MmgScreenData.scaleVec = new MmgVector2(MmgScreenData.scaleX, MmgScreenData.scaleY);
            MmgScreenData.posVec = new MmgVector2(MmgScreenData.gameLeft, MmgScreenData.gameTop);
            MmgHelper.wr("Calculate Scale Y: Found Updated X, Y Scale: " + prctDiffY + ", ResF: " + resF + ", ResI: " + resI + ", Diff: " + diff + ", Count: " + count);
        }

        /// <summary>
        /// Calculates the scale and offset needed to adjust the game screen inside
        /// the screen dimensions.
        /// </summary>
        public static void CalculateScaleAndOffset()
        {
            MmgScreenData.gameWidth = MmgScreenData.origGameWidth;
            MmgScreenData.gameHeight = MmgScreenData.origGameHeight;

            if (MmgScreenData.screenHeight == MmgScreenData.gameHeight && MmgScreenData.screenWidth == MmgScreenData.gameWidth)
            {
                MmgScreenData.scaleX = 1.0f;
                MmgScreenData.scaleY = 1.0f;
                MmgScreenData.gameTop = 0;
                MmgScreenData.gameLeft = 0;
                MmgScreenData.scaleXOn = false;
                MmgScreenData.scaleYOn = false;
            }
            else
            {
                if (MmgScreenData.scalingMode == ScalingMode.AXIS_X)
                {
                    CalculateScaleX(false);

                }
                else if (MmgScreenData.scalingMode == ScalingMode.AXIS_Y)
                {
                    CalculateScaleY(false);

                }
                else if (MmgScreenData.scalingMode == ScalingMode.AXIS_X_AND_Y)
                {
                    CalculateScaleX(false);
                    if (MmgScreenData.gameHeight > MmgScreenData.screenHeight)
                    {
                        CalculateScaleY(true);
                    }
                }
                else
                {
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
}