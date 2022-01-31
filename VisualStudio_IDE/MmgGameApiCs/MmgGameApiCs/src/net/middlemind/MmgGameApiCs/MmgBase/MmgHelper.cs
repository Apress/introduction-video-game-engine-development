using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgCfgFileEntry;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that provides high level helper methods. 
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
    public class MmgHelper
    {
        /// <summary>
        /// A helper method used to adjust font X coordinate on-the-fly to help normalize the behavior of the Monogame version of this API.
        /// </summary>
        /// <param name="x">The X coordinate to take into consideration for font position adjustment.</param>
        /// <param name="f">The actual font to take into consideration for font position adjustment.</param>
        /// <returns>An adjusted X position.</returns>
        public static int NormalizeFontPositionX(int x, MmgFont f)
        {
            return x;
        }

        /// <summary>
        /// A helper method used to adjust font Y coordinate on-the-fly to help normalize the behavior of the Monogame version of this API.
        /// </summary>
        /// <param name="y">The Y coordinate to take into consideration for font position adjustment.</param>
        /// <param name="f">The actual font to take into consideration for font position adjustment.</param>
        /// <returns>An adjusted Y position.</returns>
        public static int NormalizeFontPositionY(int y, MmgFont f)
        {
            if (f.GetFontType() == MmgFont.FontType.BOLD)
            {
                if (f.GetFontSize() >= 38)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ) + (MmgPen.FONT_VERT_POS_ADJ / 3));
                }
                else if (f.GetFontSize() >= 28)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ));
                }
                else if (f.GetFontSize() >= 18)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ / 2));
                }
                else
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ / 3));
                }
            }
            else if (f.GetFontType() == MmgFont.FontType.ITALIC)
            {
                if (f.GetFontSize() >= 38)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ) + (MmgPen.FONT_VERT_POS_ADJ / 3));
                }
                else if (f.GetFontSize() >= 28)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ));
                }
                else if (f.GetFontSize() >= 18)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ / 2));
                }
                else
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ / 3));
                }
            }
            else if (f.GetFontType() == MmgFont.FontType.NORMAL)
            {
                if (f.GetFontSize() >= 38)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ) + (MmgPen.FONT_VERT_POS_ADJ / 3));
                }
                else if (f.GetFontSize() >= 28)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ));
                }
                else if (f.GetFontSize() >= 18)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ / 2));
                }
                else
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + (MmgPen.FONT_VERT_POS_ADJ / 3));
                }
            }
            else
            {
                if (f.GetFontSize() >= 38)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + MmgPen.FONT_VERT_POS_ADJ + MmgPen.FONT_VERT_POS_ADJ / 3);
                }
                else if (f.GetFontSize() >= 28)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + MmgPen.FONT_VERT_POS_ADJ);
                }
                else if (f.GetFontSize() >= 18)
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + MmgPen.FONT_VERT_POS_ADJ / 2);
                }
                else
                {
                    return (y - f.GetHeight() + MmgPen.FONT_VERT_POS_ADJ + MmgPen.FONT_VERT_POS_ADJ / 3);
                }
            }
        }

        /// <summary>
        /// A helper method used to adjust Keyboard key codes to help normalize the behavior of the Monogame version of this API.
        /// </summary>
        /// <param name="c">The character representation of the keyboard key.</param>
        /// <param name="keyCode">The key code of the keyboard key.</param>
        /// <param name="extKeyCode">The extended code of the keyboard key taking into account the modifier keys.</param>
        /// <param name="platform">A string representation of the platform, 'c_sharp' or 'java'.</param>
        /// <returns>A key code based on the provided arguments.</returns>
        public static int NormalizeKeyCode(char c, int keyCode, int extKeyCode, string platform)
        {
            if (extKeyCode != -1)
            {
                return extKeyCode;
            }
            else
            {
                return keyCode;
            }
        }

        /// <summary>
        /// Converts the specified angle to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees to convert to radians.</param>
        /// <returns>The radian representation of the provided angle in degrees.</returns>
        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        /// <summary>
        /// Converts the specified angle to radians.
        /// </summary>
        /// <param name="angle">The angle in degrees to convert to radians.</param>
        /// <returns>The radian representation of the provided angle in degrees.</returns>
        public static float ConvertToRadians(float angle)
        {
            return (float)((Math.PI / 180) * (double)angle);
        }

        /// <summary>
        /// Controls if logging is turned on or off.
        /// </summary>
        public static bool LOGGING = true;

        /// <summary>
        /// Controls if the MmgBmp cache is used when loading image resources.
        /// </summary>
        public static bool BMP_CACHE_ON = true;

        /// <summary>
        /// Controls if the MmgSound cache is used when loading sound resources.
        /// </summary>
        public static bool SND_CACHE_ON = true;

        /// <summary>
        /// A random number generator.
        /// </summary>
        private static Random rando = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

        /// <summary>
        /// Check to see if the class configuration file data contain the specified key with an integer value.
        /// </summary>
        /// <param name="key">The class configuration key entry to check for.</param>
        /// <param name="defaultValue">The default value for this class configuration key.</param>
        /// <param name="classConfig">The set of class configuration entries to search.</param>
        /// <returns>The integer value store in the specified class config key.</returns>
        public static int ContainsKeyInt(string key, int defaultValue, Dictionary<string, MmgCfgFileEntry> classConfig)
        {
            int ret = defaultValue;
            if (classConfig.ContainsKey(key))
            {
                ret = (int)classConfig[key].number;
            }
            return ret;
        }

        /// <summary>
        /// Check to see if the class configuration file data contain the specified key with a float value.
        /// </summary>
        /// <param name="key">The class configuration key entry to check for.</param>
        /// <param name="defaultValue">The default value for this class configuration key.</param>
        /// <param name="classConfig">The set of class configuration entries to search.</param>
        /// <returns>The float value store in the specified class config key.</returns>
        public static float ContainsKeyFloat(string key, float defaultValue, Dictionary<string, MmgCfgFileEntry> classConfig)
        {
            float ret = defaultValue;
            if (classConfig.ContainsKey(key))
            {
                ret = (float)classConfig[key].number;
            }
            return ret;
        }

        /// <summary>
        /// Check to see if the class configuration file data contain the specified key with a DOUBLE value.
        /// </summary>
        /// <param name="key">The class configuration key entry to check for.</param>
        /// <param name="defaultValue">The default value for this class configuration key.</param>
        /// <param name="classConfig">The set of class configuration entries to search.</param>
        /// <returns>The double value store in the specified class config key.</returns>
        public static double ContainsKeyDouble(string key, double defaultValue, Dictionary<string, MmgCfgFileEntry> classConfig)
        {
            double ret = defaultValue;
            if (classConfig.ContainsKey(key))
            {
                ret = classConfig[key].number;
            }
            return ret;
        }

        /// <summary>
        /// Check to see if the class configuration file data contain the specified key with a string value.
        /// </summary>
        /// <param name="key">The class configuration key entry to check for.</param>
        /// <param name="defaultValue">The default value for this class configuration key.</param>
        /// <param name="classConfig">The set of class configuration entries to search.</param>
        /// <returns>The string value store in the specified class config key.</returns>
        public static string ContainsKeyString(string key, string defaultValue, Dictionary<string, MmgCfgFileEntry> classConfig)
        {
            string ret = defaultValue;
            if (classConfig.ContainsKey(key))
            {
                ret = classConfig[key].str;
            }
            return ret;
        }

        /// <summary>
        /// Performs the MmgBmp scale and position based on the provided class configuration key.
        /// </summary>
        /// <param name="keyRoot">The root class configuration key to use for processing the MmgBmp scaling and positioning.</param>
        /// <param name="tB">The MmgBmp to process.</param>
        /// <param name="classConfig">The set of class configuration entries to search.</param>
        /// <param name="pos">The default position to use for the MmgBmp object.</param>
        /// <returns>A reference to a modified MmgBmp based on the tB argument.</returns>
        public static MmgBmp ContainsKeyMmgBmpScaleAndPosition(string keyRoot, MmgBmp tB, Dictionary<string, MmgCfgFileEntry> classConfig, MmgVector2 pos)
        {
            string key = "";
            double scale = 1.0;
            int tmp = 0;
            int tmp1 = 0;
            MmgVector2 tpos;
            int w1, w2;
            int h1, h2;

            if (tB != null)
            {
                key = keyRoot + "Scale";
                scale = ContainsKeyDouble(key, 1.0, classConfig);
                if (scale != 1.0)
                {
                    MmgHelper.wr(key + " Scale: " + scale);
                    tpos = tB.GetPosition();
                    w1 = tB.GetWidth();
                    h1 = tB.GetHeight();
                    tB = MmgBmpScaler.ScaleMmgBmp(tB, scale, true);
                    w2 = tB.GetWidth();
                    h2 = tB.GetHeight();
                    tB.SetPosition(new MmgVector2(tpos.GetX() - ((w2 - w1) / 2), tpos.GetY()));
                }

                key = keyRoot + "OffsetX";
                tmp1 = 0;
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    MmgHelper.wr(key + " OffsetX: " + tmp + " - " + tmp1);
                    tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = keyRoot + "OffsetY";
                tmp1 = 0;
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    MmgHelper.wr(key + " OffsetY: " + tmp + " - " + tmp1);
                    tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = keyRoot + "PosY";
                tmp1 = tB.GetPosition().GetY();
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    MmgHelper.wr(key + " PosY: " + tmp + " - " + tmp1);
                    tB.GetPosition().SetY(pos.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = keyRoot + "PosX";
                tmp1 = tB.GetPosition().GetX();
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    MmgHelper.wr(key + " PosX: " + tmp + " - " + tmp1);
                    tB.GetPosition().SetX(pos.GetX() + MmgHelper.ScaleValue(tmp));
                }
                return tB;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Performs the MmgObj position based on the provided class configuration key.
        /// </summary>
        /// <param name="keyRoot">The root class configuration key to use for processing the MmgObj positioning.</param>
        /// <param name="tB">The MmgObj to process.</param>
        /// <param name="classConfig">The set of class configuration entries to search.</param>
        /// <param name="pos">The default position to use for the MmgObj object.</param>
        /// <returns>A reference to a modified MmgObj based on the tB argument.</returns>
        public static MmgObj ContainsKeyMmgObjPosition(string keyRoot, MmgObj tB, Dictionary<string, MmgCfgFileEntry> classConfig, MmgVector2 pos)
        {
            string key = "";
            int tmp = 0;
            int tmp1 = 0;

            if (tB != null)
            {
                key = keyRoot + "OffsetX";
                tmp1 = 0;
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = keyRoot + "OffsetY";
                tmp1 = 0;
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = keyRoot + "PosY";
                tmp1 = tB.GetPosition().GetY();
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    tB.GetPosition().SetY(pos.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = keyRoot + "PosX";
                tmp1 = tB.GetPosition().GetX();
                tmp = ContainsKeyInt(key, tmp1, classConfig);
                if (tmp != tmp1)
                {
                    tB.GetPosition().SetX(pos.GetX() + MmgHelper.ScaleValue(tmp));
                }
                return tB;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// A static class method that writes MmgCfgFileEntry objects to a target file.
        /// </summary>
        /// <param name="file">The file to write the class config data to.</param>
        /// <param name="data">The array of MmgCfgFileEntry objects to write.</param>
        /// <returns>A bool indicating if the write was handled successfully.</returns>
        public static bool WriteClassConfigFile(string file, MmgCfgFileEntry[] data)
        {
            bool ret = false;

            try
            {
                if (data != null && data.Length > 0)
                {
                    MmgCfgFileEntry cfe = null;
                    FileStream fw = new FileStream(file, FileMode.Create, FileAccess.Write);
                    StreamWriter bw = new StreamWriter(fw);

                    Array.Sort(data);
                    int len = data.Length;

                    for (int i = 0; i < len; i++)
                    {
                        cfe = data[i];
                        bw.WriteLine(cfe.ApiToString());
                    }

                    try
                    {
                        bw.Close();
                    }
                    catch (Exception ex)
                    {
                        wrErr(ex);
                    }

                    ret = true;

                }
                else
                {
                    ret = false;

                }

            }
            catch (Exception e)
            {
                ret = false;
                wrErr(e);

            }

            return ret;
        }

        /// <summary>
        /// A static class method that writes MmgCfgFileEntry objects to a target file.
        /// </summary>
        /// <param name="file">The file to write the class config data to. </param>
        /// <param name="data">A Hashtable that contains the MmgCfgFileEntry objects to write.</param>
        /// <returns>A bool indicating if the write was handled successfully.</returns>
        public static bool WriteClassConfigFile(string file, Dictionary<string, MmgCfgFileEntry> data)
        {
            bool ret = false;

            try
            {
                if (data != null && data.Count > 0)
                {
                    MmgCfgFileEntry cfe = null;
                    FileStream fw = new FileStream(file, FileMode.Create, FileAccess.Write);
                    StreamWriter bw = new StreamWriter(fw);
                    Dictionary<string, MmgCfgFileEntry>.KeyCollection keys = data.Keys;
                    string[] nKeys = new string[keys.Count];
                    keys.CopyTo(nKeys, 0);
                    Array.Sort(nKeys);
                    int len = nKeys.Length;

                    for (int i = 0; i < len; i++)
                    {
                        cfe = data[nKeys[i]];
                        bw.WriteLine(cfe.ApiToString());
                    }

                    try
                    {
                        bw.Close();
                    }
                    catch (Exception ex)
                    {
                        wrErr(ex);
                    }

                    ret = true;

                }
                else
                {
                    ret = false;

                }

            }
            catch (Exception e)
            {
                ret = false;
                wrErr(e);

            }

            return ret;
        }

        /// <summary>
        /// A static class method that reads a Hashtable of MmgCfgFileEntry objects from a valid class config file.
        /// </summary>
        /// <param name="file">The target class config file to read.</param>
        /// <returns>A Hashtable with key, MmgCfgFileEntry pairs, loading from the class config file.</returns>
        public static Dictionary<string, MmgCfgFileEntry> ReadClassConfigFile(string file)
        {
            Dictionary<string, MmgCfgFileEntry> ret = new Dictionary<string, MmgCfgFileEntry>();

            try
            {
                MmgCfgFileEntry cfe = null;
                FileInfo f = null;
                string nFile = file.Replace(".txt", MmgScreenData.GetScreenWidth() + "x" + MmgScreenData.GetScreenHeight() + ".txt");
                f = new FileInfo(nFile);
                if (!f.Exists)
                {
                    f = new FileInfo(file);
                }

                if (f.Exists)
                {
                    FileStream fr = new FileStream(file, FileMode.Open, FileAccess.Read);
                    StreamReader br = new StreamReader(fr);
                    string line = br.ReadLine();
                    string[] data = null;

                    while (line != null)
                    {
                        cfe = new MmgCfgFileEntry();
                        line = line.Trim();
                        if (line.Equals("") == false && line.ToCharArray()[0] != '#')
                        {
                            if (line.IndexOf("=") != -1)
                            {
                                data = line.Split("=");
                                if (data.Length == 2)
                                {
                                    cfe.cfgType = CfgEntryType.TYPE_DOUBLE;
                                    cfe.number = Double.Parse(data[1]);
                                    cfe.name = data[0];
                                    ret.Add(data[0], cfe);
                                }
                            }
                            else if (line.IndexOf("->") != -1)
                            {
                                data = line.Split("->");
                                if (data.Length == 2)
                                {
                                    cfe.cfgType = CfgEntryType.TYPE_STRING;
                                    cfe.str = data[1];
                                    cfe.name = data[0];
                                    ret.Add(data[0], cfe);
                                }
                            }
                        }
                        line = br.ReadLine();
                    }

                    try
                    {
                        br.Close();
                    }
                    catch (Exception ex)
                    {
                        wrErr(ex);
                    }
                }
            }
            catch (Exception e)
            {
                wrErr(e);
            }

            return ret;
        }

        /// <summary>
        /// A static method for creating an MmgBmp object filled with the provided color.
        /// </summary>
        /// <param name="width">The width of the MmgBmp object created.</param>
        /// <param name="height">The height of the MmgBmp object created.</param>
        /// <param name="color">The MmgColor that is used to fill the MmgBmp object created.</param>
        /// <returns>An MmgBmp object with the width and height provided filled with the specified color.</returns>
        public static MmgBmp CreateFilledBmp(int width, int height, MmgColor color)
        {
            return CreateDrawableBmpSet(width, height, false, color).img;
        }

        /// <summary>
        /// A static method for creating an MmgDrawableBmpSet of the specified width and height.
        /// An MmgDrawableBmpSet contains an MmgPen wrapping a Graphics object and configured to write to the BufferedImage and
        /// an MmgBmp object that wraps the BufferedImage.
        /// </summary>
        /// <param name="width">The width of the MmgBmp object created.</param>
        /// <param name="height">The height of the MmgBmp object created.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <returns>An MmgDrawableBmpSet that contains initialized objects needed to draw on an MmgBmp object.</returns>
        public static MmgDrawableBmpSet CreateDrawableBmpSet(int width, int height, bool alpha)
        {
            MmgDrawableBmpSet dBmpSet = new MmgDrawableBmpSet();
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            dBmpSet.buffImg = new RenderTarget2D(gd, width, height);
            dBmpSet.graphics = new SpriteBatch(gd);
            dBmpSet.p = new MmgPen();
            dBmpSet.p.SetGraphics(dBmpSet.graphics);
            dBmpSet.p.SetAdvRenderHints();
            dBmpSet.img = new MmgBmp(dBmpSet.buffImg);

            if (alpha)
            {
                dBmpSet.graphics.GraphicsDevice.SetRenderTarget(dBmpSet.buffImg);
                dBmpSet.graphics.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                dBmpSet.graphics.GraphicsDevice.Clear(Color.Transparent);
                dBmpSet.graphics.End();
                dBmpSet.graphics.GraphicsDevice.SetRenderTarget(null);
            }

            return dBmpSet;
        }

        /// <summary>
        /// A static method for creating an MmgDrawableBmpSet of the specified width and height and filled with the specified color.
        /// An MmgDrawableBmpSet contains an MmgPen wrapping a Graphics object and configured to write to the BufferedImage and
        /// an MmgBmp object that wraps the BufferedImage.
        /// </summary>
        /// <param name="width">The width of the MmgBmp object created.</param>
        /// <param name="height">The height of the MmgBmp object created.</param>
        /// <param name="alpha">A bool flag indicating if transparency should be taken into consideration when creating new images.</param>
        /// <param name="color">The color used to fill the created MmgBmp object.</param>
        /// <returns>An MmgDrawableBmpSet that contains initialized objects needed to draw on an MmgBmp object.</returns>
        public static MmgDrawableBmpSet CreateDrawableBmpSet(int width, int height, bool alpha, MmgColor color)
        {
            MmgDrawableBmpSet dBmpSet = MmgHelper.CreateDrawableBmpSet(width, height, alpha);
            dBmpSet.graphics.GraphicsDevice.SetRenderTarget(dBmpSet.buffImg);
            dBmpSet.graphics.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            dBmpSet.graphics.GraphicsDevice.Clear(color.GetColor());
            dBmpSet.graphics.End();
            dBmpSet.graphics.GraphicsDevice.SetRenderTarget(null);
            return dBmpSet;
        }

        /// <summary>
        /// A static class method used to determine if there is a collision between the X, Y coordinates and the MmgRect.
        /// </summary>
        /// <param name="x">The X coordinate used to test for a collision.</param>
        /// <param name="y">The Y coordinate used to test for a collision.</param>
        /// <param name="r">The MmgRect used to test for a collision.</param>
        /// <returns>A boolean indicating if there has been a collision detected.</returns>
        public static bool RectCollision(int x, int y, MmgRect r)
        {
            if (x >= r.GetLeft() && x <= r.GetRight())
            {
                if (y >= r.GetTop() && y <= r.GetBottom())
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Tests for collision of two rectangles.
        /// </summary>
        /// <param name="r1x">Rectangle #1, X coordinate.</param>
        /// <param name="r1y">Rectangle #1, Y coordinate.</param>
        /// <param name="w">Rectangle #1, width.</param>
        /// <param name="h">Rectangle #1, height.</param>
        /// <param name="r">Rectangle #2.</param>
        /// <returns>True if there is a collision of the two rectangles.</returns>
        public static bool RectCollision(int r1x, int r1y, int w, int h, MmgRect r)
        {
            int r2x = r.GetLeft();
            int r2y = r.GetTop();
            return RectCollision(r1x, r1y, w, h, r2x, r2y, (r.GetRight() - r.GetLeft()), (r.GetBottom() - r.GetTop()));
        }

        /// <summary>
        /// Tests for collision of two rectangles.
        /// </summary>
        /// <param name="src">Rectangle #1.</param>
        /// <param name="dest">Rectangle #2.</param>
        /// <returns>True if there is a collision of the two rectangles.</returns>
        public static bool RectCollision(MmgRect src, MmgRect dest)
        {
            return RectCollision(src.GetLeft(), src.GetTop(), src.GetWidth(), src.GetHeight(), dest);
        }

        /// <summary>
        /// A static method that tests for the collision of two MmgObj instances.
        /// </summary>
        /// <param name="src">The source MmgObj to test for a collision.</param>
        /// <param name="dest">The destination MmgObj to test for a collision.</param>
        /// <returns>A boolean indicating if a collision was found or not.</returns>
        public static bool RectCollision(MmgObj src, MmgObj dest)
        {
            return RectCollision(src.GetX(), src.GetY(), src.GetWidth(), src.GetHeight(), dest.GetX(), dest.GetY(), dest.GetWidth(), dest.GetHeight());
        }

        /// <summary>
        /// A static method that tests for a collision using an MmgVector2 and a width and height to define a collision rectangle.
        /// </summary>
        /// <param name="src">The source point used in the collision test.</param>
        /// <param name="sW">The width used in the source rectangle definition.</param>
        /// <param name="sH">The height used in the source rectangle definition.</param>
        /// <param name="dest">The destination point used in the collision test.</param>
        /// <param name="dW">The width used in the destination rectangle definition.</param>
        /// <param name="dH">The height used in the destination rectangle definition.</param>
        /// <returns>A boolean indicating if a collision was found or not.</returns>
        public static bool RectCollision(MmgVector2 src, int sW, int sH, MmgVector2 dest, int dW, int dH)
        {
            return RectCollision(src.GetX(), src.GetY(), sW, sH, dest.GetX(), dest.GetY(), dW, dH);
        }

        /// <summary>
        /// Tests for collisions of two rectangles.
        /// </summary>
        /// <param name="r1x">Rectangle #1, X coordinate.</param>
        /// <param name="r1y">Rectangle #1, Y coordinate.</param>
        /// <param name="r1w">Rectangle #1, width.</param>
        /// <param name="r1h">Rectangle #1, height.</param>
        /// <param name="r2x">Rectangle #2, X coordinate.</param>
        /// <param name="r2y">Rectangle #2, Y coordinate.</param>
        /// <param name="r2w">Rectangle #2, width.</param>
        /// <param name="r2h">Rectangle #2, height.</param>
        /// <returns>True if there is a collision of the two rectangles.</returns>
        public static bool RectCollision(int r1x, int r1y, int r1w, int r1h, int r2x, int r2y, int r2w, int r2h)
        {
            if (r1x >= r2x && r1x <= (r2x + r2w) && r1y >= r2y && r1y <= (r2y + r2h))
            {
                return true;

            }
            else if ((r1x + r1w) >= r2x && (r1x + r1w) <= (r2x + r2w) && r1y >= r2y && r1y <= (r2y + r2h))
            {
                return true;

            }
            else if ((r1x + r1w) >= r2x && (r1x + r1w) <= (r2x + r2w) && (r1y + r1h) >= r2y && (r1y + r1h) <= (r2y + r2h))
            {
                return true;

            }
            else if (r1x >= r2x && r1x <= (r2x + r2w) && (r1y + r1h) >= r2y && (r1y + r1h) <= (r2y + r2h))
            {
                return true;

            }
            else if (r2x >= r1x && r2x <= (r1x + r1w) && r2y >= r1y && r2y <= (r1y + r1h))
            {
                return true;

            }
            else if ((r2x + r2w) >= r1x && (r2x + r2w) <= (r1x + r1w) && r2y >= r1y && r2y <= (r1y + r1h))
            {
                return true;

            }
            else if ((r2x + r2w) >= r1x && (r2x + r2w) <= (r1x + r1w) && (r2y + r2h) >= r1y && (r2y + r2h) <= (r1y + r1h))
            {
                return true;

            }
            else if (r2x >= r1x && r2x <= (r1x + r1w) && (r2y + r2h) >= r1y && (r2y + r2h) <= (r1y + r1h))
            {
                return true;

            }

            return false;
        }

        /// <summary>
        /// The absolute value of the distance between two points.
        /// </summary>
        /// <param name="x1">Point #1, X coordinate.</param>
        /// <param name="x2">Point #2, X coordinate.</param>
        /// <param name="y1">Point #1, Y coordinate.</param>
        /// <param name="y2">Point #2, Y coordinate.</param>
        /// <returns>The absolute value of the calculated distance.</returns>
        public static int AbsDistance(int x1, int x2, int y1, int y2)
        {
            return (int)Math.Sqrt((double)(((y1 - x1) * (y1 - x1)) + ((y2 - x2) * (y2 - x2))));
        }

        /// <summary>
        /// Centers an MmgObj horizontally.
        /// </summary>
        /// <param name="obj">The object to center.</param>
        /// <returns>A centered object.</returns>
        public static MmgObj CenterHor(MmgObj obj)
        {
            MmgVector2 vec = new MmgVector2((int)(MmgScreenData.GetGameLeft() + (MmgScreenData.GetGameWidth() - obj.GetWidth()) / 2), obj.GetPosition().GetY());
            obj.SetPosition(vec);
            return obj;
        }

        /// <summary>
        /// Centers an MmgObj vertically.
        /// </summary>
        /// <param name="obj">The object to center.</param>
        /// <returns>A centered object.</returns>
        public static MmgObj CenterVert(MmgObj obj)
        {
            MmgVector2 vec = new MmgVector2(obj.GetPosition().GetX(), (int)(MmgScreenData.GetGameTop() + (MmgScreenData.GetGameHeight() - obj.GetHeight()) / 2));
            obj.SetPosition(vec);
            return obj;
        }

        /// <summary>
        /// Centers an MmgObj horizontally and vertically.
        /// </summary>
        /// <param name="obj">The object to center.</param>
        /// <returns>A centered object.</returns>
        public static MmgObj CenterHorAndVert(MmgObj obj)
        {
            obj = CenterHor(obj);
            obj = CenterVert(obj);
            return obj;
        }

        /// <summary>
        /// Centers an MmgObj horizontally and places it at the top of the screen vertically.
        /// </summary>
        /// <param name="obj">The object to position.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj CenterHorAndTop(MmgObj obj)
        {
            obj = CenterHor(obj);
            MmgVector2 pos = obj.GetPosition().Clone();
            pos.SetY(MmgScreenData.GetGameTop());
            obj.SetPosition(pos);
            return obj;
        }

        /// <summary>
        /// Centers an MmgObj horizontally and places it at the bottom of the screen vertically.
        /// </summary>
        /// <param name="obj">The object to position.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj CenterHorAndBot(MmgObj obj)
        {
            obj = CenterHor(obj);
            MmgVector2 pos = obj.GetPosition().Clone();
            int h = obj.GetHeight();
            pos.SetY((MmgScreenData.GetGameTop() + MmgScreenData.GetGameHeight()) - h);
            obj.SetPosition(pos);
            return obj;
        }

        /// <summary>
        /// Centers an MmgObj horizontally and vertically.
        /// </summary>
        /// <param name="obj">The object to position.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj CenterHorAndMid(MmgObj obj)
        {
            return CenterHorAndVert(obj);
        }

        /// <summary>
        /// Repositions an MmgObj horizontally left and vertically top.
        /// </summary>
        /// <param name="obj">The object to position.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj LeftHorAndTop(MmgObj obj)
        {
            MmgVector2 pos = obj.GetPosition().Clone();
            pos.SetX(MmgScreenData.GetGameLeft());
            pos.SetY(MmgScreenData.GetGameTop());
            obj.SetPosition(pos);
            return obj;
        }

        /// <summary>
        /// Repositions an MmgObj horizontally left, and vertically top.
        /// </summary>
        /// <param name="obj">The object to position.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj LeftHorAndMid(MmgObj obj)
        {
            MmgVector2 pos = obj.GetPosition().Clone();
            pos.SetX(MmgScreenData.GetGameLeft());
            obj.SetPosition(pos);
            return CenterVert(obj);
        }

        /// <summary>
        /// Repositions an MmgObj horizontally left and vertically bottom.
        /// </summary>
        /// <param name="obj">The object to reposition.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj LeftHorAndBot(MmgObj obj)
        {
            MmgVector2 pos = obj.GetPosition().Clone();
            int h = obj.GetHeight();
            pos.SetY((MmgScreenData.GetGameTop() + MmgScreenData.GetGameHeight()) - h);
            pos.SetX(MmgScreenData.GetGameLeft());
            obj.SetPosition(pos);
            return obj;
        }

        /// <summary>
        /// Repositions an MmgObj horizontally right, and vertically top.
        /// </summary>
        /// <param name="obj">The object to reposition.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj RightHorAndTop(MmgObj obj)
        {
            MmgVector2 pos = obj.GetPosition().Clone();
            int w = obj.GetWidth();
            pos.SetX((MmgScreenData.GetGameLeft() + MmgScreenData.GetGameWidth()) - w);
            pos.SetY(MmgScreenData.GetGameTop());
            obj.SetPosition(pos);
            return obj;
        }

        /// <summary>
        /// Repositions an MmgObj horizontally right, and vertically middle.
        /// </summary>
        /// <param name="obj">The object to reposition.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj RightHorAndMid(MmgObj obj)
        {
            MmgVector2 pos = obj.GetPosition().Clone();
            int w = obj.GetWidth();
            pos.SetX((MmgScreenData.GetGameLeft() + MmgScreenData.GetGameWidth()) - w);
            obj.SetPosition(pos);
            return CenterVert(obj);
        }

        /// <summary>
        /// Repositions an MmgObj horizontally right, and vertically bottom.
        /// </summary>
        /// <param name="obj">The object to reposition.</param>
        /// <returns>A repositioned object.</returns>
        public static MmgObj RightHorAndBot(MmgObj obj)
        {
            MmgVector2 pos = obj.GetPosition().Clone();
            int h = obj.GetHeight();
            int w = obj.GetWidth();
            pos.SetY((MmgScreenData.GetGameTop() + MmgScreenData.GetGameHeight()) - h);
            pos.SetX((MmgScreenData.GetGameLeft() + MmgScreenData.GetGameWidth()) - w);
            obj.SetPosition(pos);
            return obj;
        }

        /// <summary>
        /// Scaling method, applies the scale X to the given argument.
        /// </summary>
        /// <param name="val">The value to scale.</param>
        /// <returns>A scaled value.</returns>
        public static int ScaleValue(int val)
        {
            return (int)((double)val * MmgScreenData.GetScaleX());
        }

        /// <summary>
        /// Scaling method, applies the scale x to the given argument.
        /// </summary>
        /// <param name="val">The value to scale.</param>
        /// <returns>A scaled value.</returns>
        public static float ScaleValue(float val)
        {
            return (float)((double)val * MmgScreenData.GetScaleX());
        }

        /// <summary>
        /// Scaling method, applies the scale x to the given argument.
        /// </summary>
        /// <param name="val">The value to scale.</param>
        /// <returns>A scaled value.</returns>
        public static double ScaleValue(double val)
        {
            return (double)((double)val * MmgScreenData.GetScaleX());
        }

        /// <summary>
        /// A static method used to generate a random integer.
        /// </summary>
        /// <param name="exclusiveUpperBound">An exclusive upper bound on the random number generated.</param>
        /// <returns>An integer between 0 not including the exclusiveUpperBound.</returns>
        public static int GetRandomInt(int exclusiveUpperBound)
        {
            return rando.Next(exclusiveUpperBound);
        }

        /// <summary>
        /// A static method used to generate a random integer from the given range.
        /// </summary>
        /// <param name="min">An inclusive lower bound.</param>
        /// <param name="max">An exclusive upper bound.</param>
        /// <returns>A random value greater than or equal to min and less than max.</returns>
        public static int GetRandomIntRange(int min, int max)
        {
            return rando.Next(max - min) + min;
        }

        /// <summary>
        /// A static method that returns the current time in milliseconds. 
        /// </summary>
        /// <returns>The current time in milliseconds.</returns>
        public static long CtMs()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// Centralized logging method for standard out logging.
        /// </summary>
        /// <param name="s">The string to be logged.</param>
        public static void wr(string s)
        {
            if (LOGGING == true)
            {
                System.Diagnostics.Debug.WriteLine(s);
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Centralized logging method for standard error logging.
        /// </summary>
        /// <param name="e">The exception to be logged.</param>
        public static void wrErr(Exception e)
        {
            if (LOGGING == true)
            {
                System.Diagnostics.Debug.WriteLine("ErrorLog: " + e.Message);
                Console.WriteLine("ErrorLog: " + e.Message);

                System.Diagnostics.Debug.WriteLine("ErrorLog: " + e.StackTrace);
                Console.WriteLine("ErrorLog: " + e.StackTrace);
            }
        }

        /// <summary>
        /// Centralized logging method for standard err logging.
        /// </summary>
        /// <param name="s">The string to be logged.</param>
        public static void wrErr(string s)
        {
            if (LOGGING == true)
            {
                System.Diagnostics.Debug.WriteLine("ErrorLog: " + s);
                Console.WriteLine("ErrorLog: " + s);
            }
        }

        /// <summary>
        /// Fills the specified rectangle region of the buffImg argument with the specified color.
        /// </summary>
        /// <param name="x">The X coordinate of the rectangle.</param>
        /// <param name="y">The Y coordinate of the rectangle.</param>
        /// <param name="w">The width of the rectangle.</param>
        /// <param name="h">The height of the rectangle.</param>
        /// <param name="c">The color to fill the rectangle with.</param>
        /// <param name="dBmp">The image to draw the rectangle on.</param>
        public static void FillRectWithColor(int x, int y, int w, int h, Color c, Texture2D buffImg)
        {
            int len = w * h;
            Color[] pixels = new Color[len];
            buffImg.GetData<Color>(0, new Rectangle(x, y, w, h), pixels, 0, len);
            for(int i = 0; i < len; i ++)
            {
                pixels[i] = c;
            }
            buffImg.SetData<Color>(0, new Rectangle(x, y, w, h), pixels, 0, len);
        }

        /// <summary>
        /// A static method used to create an MmgSound object from a sound resource file.
        /// </summary>
        /// <param name="path">The path of the sound resource loaded.</param>
        /// <param name="sndId">The id to use when storing the sound resource in the sound resource cache.</param>
        /// <returns>An MmgSound object created from the specified resource file or loaded from the sound resource cache.</returns>
        public static MmgSound GetBasicCachedSound(string path, string sndId)
        {
            MmgSound lval = null;
            if (SND_CACHE_ON == true)
            {
                if (MmgMediaTracker.HasSoundKey(sndId) == true)
                {
                    lval = new MmgSound(MmgMediaTracker.GetSoundValue(sndId));
                }
                else
                {
                    lval = MmgHelper.GetBasicSound(path);
                    MmgMediaTracker.CacheSound(sndId, lval.GetSound());
                }
            }
            else
            {
                lval = MmgHelper.GetBasicSound(path);
            }
            return lval;
        }

        /// <summary>
        /// Loads a cached sound with the provided sound resource ID, the sndId argument or loads a new resource using the provided binary data.
        /// </summary>
        /// <param name="data">A byte array representation of the sound.</param>
        /// <param name="sndId">The ID to use when the sound resource is cached.</param>
        /// <returns>An MmgSound object instance based on the sound resource.</returns>
        public static MmgSound GetBasicCachedSound(byte[] data, string sndId)
        {
            MmgSound lval = null;
            if (SND_CACHE_ON == true)
            {
                if (MmgMediaTracker.HasSoundKey(sndId) == true)
                {
                    lval = new MmgSound(MmgMediaTracker.GetSoundValue(sndId));
                }
                else
                {
                    lval = MmgHelper.GetBinarySound(data);
                    MmgMediaTracker.CacheSound(sndId, lval.GetSound());
                }
            }
            else
            {
                lval = MmgHelper.GetBinarySound(data);
            }
            return lval;
        }

        /// <summary>
        /// A static method used to create an MmgSound object from a sound resource file.
        /// </summary>
        /// <param name="sndId">The id to use when pulling the sound resource from the sound cache.</param>
        /// <returns>An MmgSound object loaded from the sound resource cache.</returns>
        public static MmgSound GetBasicCachedSound(string sndId)
        {
            MmgSound lval = null;
            if (SND_CACHE_ON == true)
            {
                if (MmgMediaTracker.HasSoundKey(sndId) == true)
                {
                    lval = new MmgSound(MmgMediaTracker.GetSoundValue(sndId));
                }
            }
            return lval;
        }

        /// <summary>
        /// A static method used to create an MmgBmp object loaded from an image resource file.
        /// </summary>
        /// <param name="path">The path to the image resource file to load.</param>
        /// <param name="imgId">The id used to store the image resource file into the image resource cache.</param>
        /// <returns>An MmgBmp object loaded from the image file or the image resource cache.</returns>
        public static MmgBmp GetBasicCachedBmp(string path, string imgId)
        {
            MmgBmp lval = null;
            if (BMP_CACHE_ON == true)
            {
                if (MmgMediaTracker.HasBmpKey(imgId) == true)
                {
                    lval = new MmgBmp(MmgMediaTracker.GetBmpValue(imgId));
                    lval.SetMmgColor(null);
                }
                else
                {
                    lval = MmgHelper.GetBasicBmp(path);
                    MmgMediaTracker.CacheImage(imgId, lval.GetImage());
                }
            }
            else
            {
                lval = MmgHelper.GetBasicBmp(path);
            }
            return lval;
        }

        /// <summary>
        /// Loads a cached sound with the provided sound resource ID, the sndId argument or loads a new resource using the provided binary data.
        /// </summary>
        /// <param name="data">A byte array representation of the sound.</param>
        /// <param name="sndId">The ID to use when the sound resource is cached.</param>
        /// <returns>An MmgSound object instance based on the sound resource.</returns>
        public static MmgBmp GetBasicCachedBmp(byte[] data, string imgId)
        {
            MmgBmp lval = null;
            if (BMP_CACHE_ON == true)
            {
                if (MmgMediaTracker.HasBmpKey(imgId) == true)
                {
                    lval = new MmgBmp(MmgMediaTracker.GetBmpValue(imgId));
                    lval.SetMmgColor(null);
                }
                else
                {
                    lval = MmgHelper.GetBinaryBmp(data);
                    MmgMediaTracker.CacheImage(imgId, lval.GetImage());
                }
            }
            else
            {
                lval = MmgHelper.GetBinaryBmp(data);
            }
            return lval;
        }

        /// <summary>
        /// A static method used to create an MmgBmp object from an image resource file.
        /// </summary>
        /// <param name="imgId">The id used to store the image resource file into the image resource cache.</param>
        /// <returns>An MmgBmp object loaded from the image file or the image resource cache.</returns>
        public static MmgBmp GetBasicCachedBmp(string imgId)
        {
            MmgBmp lval = null;
            if (BMP_CACHE_ON == true)
            {
                if (MmgMediaTracker.HasBmpKey(imgId) == true)
                {
                    lval = new MmgBmp(MmgMediaTracker.GetBmpValue(imgId));
                    lval.SetMmgColor(null);
                }
            }
            return lval;
        }

        /// <summary>
        /// A static method to list the cached resources, images and sounds.
        /// </summary>
        public static void ListCacheEntries()
        {
            int len;
            Dictionary<string, Texture2D>.KeyCollection keysI;
            Dictionary<string, SoundEffect>.KeyCollection keysS;
            string[] keys;
            string key;
            int i;

            if (BMP_CACHE_ON == true)
            {
                len = MmgMediaTracker.GetBmpCacheSize();
                keysI = MmgMediaTracker.cacheBmp.Keys;
                keys = new string[keysI.Count];
                keysI.CopyTo(keys, 0);
                for (i = 0; i < len; i++)
                {
                    key = keys[i] + "";
                    wr("BMP: " + i + " key: " + key);
                }
            }

            if (SND_CACHE_ON == true)
            {
                len = MmgMediaTracker.GetSoundCacheSize();
                keysS = MmgMediaTracker.cacheSound.Keys;
                keys = new string[keysS.Count];
                keysS.CopyTo(keys, 0);
                for (i = 0; i < len; i++)
                {
                    key = keys[i] + "";
                    wr("SND: " + i + " key: " + key);
                }
            }
        }

        /// <summary>
        /// Gets a basic sound from the file system.
        /// </summary>
        /// <param name="src">A path to a valid sound resource.</param>
        /// <returns>A sound loaded from the file path.</returns>
        public static MmgSound GetBasicSound(string src)
        {
            SoundEffect inS = null;
            MmgSound snd = null;

            try
            {
                inS = SoundEffect.FromFile(src);
                snd = new MmgSound(inS);
            }
            catch (Exception e)
            {
                wrErr(e);
            }

            return snd;
        }

        /// <summary>
        /// Gets a basic bitmap from the file system.
        /// </summary>
        /// <param name="src">A path to a valid bitmap resource.</param>
        /// <returns>A bitmap loaded from the file path.</returns>
        public static MmgBmp GetBasicBmp(string src)
        {
            Texture2D b = null;
            MmgBmp r = null;

            try
            {
                b = Texture2D.FromFile(MmgScreenData.GRAPHICS_CONFIG, src);
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            if (b != null)
            {
                b = MmgPen.ScaleImageStatic(b, MmgScreenData.GetScale());
                r = new MmgBmp(b);
                r.SetScaling(MmgVector2.GetUnitVec());
                r.SetPosition(MmgVector2.GetOriginVec());
                r.SetOrigin(MmgVector2.GetOriginVec());
                r.SetMmgColor(null);
            }

            return r;
        }

        /// <summary>
        /// A static method for converting binary image data into an MmgBmp object.
        /// </summary>
        /// <param name="d">The array of bytes representing the image data.</param>
        /// <returns>An MmgBmp object that is created from the binary image data.</returns>
        public static MmgBmp GetBinaryBmp(byte[] d)
        {
            Texture2D b = null;
            MmgBmp r = null;

            try
            {
                b = Texture2D.FromStream(MmgScreenData.GRAPHICS_CONFIG, new MemoryStream(d));
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            if (b != null)
            {
                b = MmgPen.ScaleImageStatic(b, MmgScreenData.GetScale());
                r = new MmgBmp(b);
                r.SetScaling(MmgVector2.GetUnitVec());
                r.SetPosition(MmgVector2.GetOriginVec());
                r.SetOrigin(MmgVector2.GetOriginVec());
                r.SetMmgColor(null);
            }

            return r;
        }

        /// <summary>
        /// A static method for converting binary image data into an MmgSound object.
        /// </summary>
        /// <param name="d">The array of bytes representing the sound data.</param>
        /// <returns>An MmgSound object that is created from the binary sound data.</returns>
        public static MmgSound GetBinarySound(byte[] d)
        {
            SoundEffect inS = null;
            MmgSound snd = null;

            try
            {
                inS = SoundEffect.FromStream(new MemoryStream(d));
                snd = new MmgSound(inS);
            }
            catch (Exception e)
            {
                wrErr(e);
            }

            return snd;
        }

        /// <summary>
        /// A static method for converting the lower level Java image into an MmgBmp object.
        /// </summary>
        /// <param name="b">The Image instance used to create an MmgBmp object.</param>
        /// <returns>An MmgBmp object that is created from the binary image data.</returns>
        public static MmgBmp GetImageBmp(Texture2D b)
        {
            MmgBmp r = null;

            if (b != null)
            {
                b = MmgPen.ScaleImageStatic(b, MmgScreenData.GetScale());
                r = new MmgBmp(b);
                r.SetScaling(MmgVector2.GetUnitVec());
                r.SetPosition(MmgVector2.GetOriginVec());
                r.SetOrigin(MmgVector2.GetOriginVec());
                r.SetMmgColor(null);
            }

            return r;
        }

        /// <summary>
        /// A static method for converting the lower level Java image into an MmgBmp object.
        /// </summary>
        /// <param name="b">The Image instance used to create an MmgBmp object.</param>
        /// <returns>An MmgBmp object that is created from the binary image data.</returns>
        public static MmgBmp GetImageCacheBmp(Texture2D b)
        {
            MmgBmp r = null;

            if (b != null)
            {
                r = new MmgBmp(b);
                r.SetScaling(MmgVector2.GetUnitVec());
                r.SetPosition(MmgVector2.GetOriginVec());
                r.SetOrigin(MmgVector2.GetOriginVec());
                r.SetMmgColor(null);
            }

            return r;
        }

        /// <summary>
        /// Gets a basic MmgMenuItem instance.
        /// </summary>
        /// <param name="handler">The event handler of the menu item.</param>
        /// <param name="name">The name of the menu item.</param>
        /// <param name="eventId">The id of the menu item event.</param>
        /// <param name="eventType">The type of the menu item event.</param>
        /// <param name="img">The image used to display the menu item.</param>
        /// <returns>A new configured MmgMenuItem.</returns>
        public static MmgMenuItem GetBasicMenuItem(MmgEventHandler handler, string name, int eventId, int eventType, MmgBmp img)
        {
            MmgMenuItem itm;
            itm = new MmgMenuItem();
            itm.SetNormal(img);
            itm.SetSelected(img);
            itm.SetInactive(img);
            itm.SetPosition(img.GetPosition());
            itm.SetState(MmgMenuItem.STATE_NORMAL);
            itm.SetEventPress(new MmgEvent(handler, name, eventId, eventType, handler, null));
            itm.SetMmgColor(null);
            return itm;
        }
    }
}