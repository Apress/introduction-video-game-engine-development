package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.Transparency;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.Arrays;
import java.util.Hashtable;
import java.util.Random;
import java.util.Set;
import javax.imageio.ImageIO;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.Clip;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry.CfgEntryType;

/**
 * Class that provides high level helper methods. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgHelper {

    /**
     * A helper method used to adjust font X coordinate on-the-fly to help normalize the behavior of the Monogame version of this API.
     * 
     * @param x     The X coordinate to take into consideration for font position adjustment.
     * @param f     The actual font to take into consideration for font position adjustment.
     * @return      An adjusted X position.
     */
    public static int NormalizeFontPositionX(int x, MmgFont f)
    {
        return x;
    }
     
    /**
     * A helper method used to adjust font Y coordinate on-the-fly to help normalize the behavior of the Monogame version of this API.
     * 
     * @param y     The Y coordinate to take into consideration for font position adjustment.
     * @param f     The actual font to take into consideration for font position adjustment.
     * @return      An adjusted Y position. 
     */
    public static int NormalizeFontPositionY(int y, MmgFont f)
    {
        return y;
    }    
    
    /**
     * A helper method used to adjust Keyboard key codes to help normalize the behavior of the Monogame version of this API.
     * 
     * @param c             The character representation of the keyboard key.
     * @param keyCode       The key code of the keyboard key.
     * @param extKeyCode    The extended code of the keyboard key taking into account the modifier keys.
     * @param platform      A string representation of the platform, 'c_sharp' or 'java'.
     * @return              A key code based on the provided arguments.
     */
    public static int NormalizeKeyCode(char c, int keyCode, int extKeyCode, String platform) {
        if(extKeyCode != -1) {
            return extKeyCode;
        } else  {
            return keyCode;
        }
    }
    
    /**
     * Converts the specified angle to radians.
     * 
     * @param angle     The angle in degrees to convert to radians.
     * @return          The radian representation of the provided angle in degrees.
     */
    public static double ConvertToRadians(double angle) {
        return (Math.PI / 180) * angle;
    }    
    
    /**
     * Converts the specified angle to radians.
     * 
     * @param angle     The angle in degrees to convert to radians.
     * @return          The radian representation of the provided angle in degrees.
     */
    public static float ConvertToRadians(float angle) {
        return (float)((Math.PI / 180) * (double)angle);
    }    
    
    /**
     * Controls if logging is turned on or off.
     */
    public static boolean LOGGING = true;
    
    /**
     * Controls if the MmgBmp cache is used when loading image resources.
     */
    public static boolean BMP_CACHE_ON = true;
    
    /**
     * Controls if the MmgSound cache is used when loading sound resources.
     */
    public static boolean SND_CACHE_ON = true;    
    
    /**
     * A random number generator.
     */
    private static Random rando = new Random(System.currentTimeMillis());    

    /**
     * Check to see if the class configuration file data contain the specified key with an integer value.
     * 
     * @param key               The class configuration key entry to check for.
     * @param defaultValue      The default value for this class configuration key.
     * @param classConfig       The set of class configuration entries to search.
     * @return                  The integer value store in the specified class config key.
     */
    public static int ContainsKeyInt(String key, int defaultValue, Hashtable<String, MmgCfgFileEntry> classConfig) {
        int ret = defaultValue;
        if(classConfig.containsKey(key)) {
            ret = classConfig.get(key).number.intValue();
        }
        return ret;
    }
    
    /**
     * Check to see if the class configuration file data contain the specified key with a float value.
     * 
     * @param key               The class configuration key entry to check for.
     * @param defaultValue      The default value for this class configuration key.
     * @param classConfig       The set of class configuration entries to search.
     * @return                  The float value store in the specified class config key.
     */
    public static float ContainsKeyFloat(String key, float defaultValue, Hashtable<String, MmgCfgFileEntry> classConfig) {
        float ret = defaultValue;
        if(classConfig.containsKey(key)) {
            ret = classConfig.get(key).number.floatValue();
        }
        return ret;
    }    
    
    /**
     * Check to see if the class configuration file data contain the specified key with a DOUBLE value.
     * 
     * @param key               The class configuration key entry to check for.
     * @param defaultValue      The default value for this class configuration key.
     * @param classConfig       The set of class configuration entries to search.
     * @return                  The double value store in the specified class config key.
     */
    public static double ContainsKeyDouble(String key, double defaultValue, Hashtable<String, MmgCfgFileEntry> classConfig) {
        double ret = defaultValue;
        if(classConfig.containsKey(key)) {
            ret = classConfig.get(key).number.doubleValue();
        }
        return ret;
    }

    /**
     * Check to see if the class configuration file data contain the specified key with a string value.
     * 
     * @param key               The class configuration key entry to check for.
     * @param defaultValue      The default value for this class configuration key.
     * @param classConfig       The set of class configuration entries to search.
     * @return                  The string value store in the specified class config key.
     */
    public static String ContainsKeyString(String key, String defaultValue, Hashtable<String, MmgCfgFileEntry> classConfig) {
        String ret = defaultValue;
        if(classConfig.containsKey(key)) {
            ret = classConfig.get(key).str;
        }
        return ret;
    }

    /**
     * Performs the MmgBmp scale and position based on the provided class configuration key.
     * 
     * @param keyRoot       The root class configuration key to use for processing the MmgBmp scaling and positioning.
     * @param tB            The MmgBmp to process.
     * @param classConfig   The set of class configuration entries to search.
     * @param pos           The default position to use for the MmgBmp object.
     * @return              A reference to a modified MmgBmp based on the tB argument.
     */
    public static MmgBmp ContainsKeyMmgBmpScaleAndPosition(String keyRoot, MmgBmp tB, Hashtable<String, MmgCfgFileEntry> classConfig, MmgVector2 pos) {
        String key = "";
        double scale = 1.0;
        int tmp = 0;
        int tmp1 = 0;
        MmgVector2 tpos;
        int w1, w2;
        int h1, h2;
        
        if (tB != null) {
            key = keyRoot + "Scale";
            scale = ContainsKeyDouble(key, 1.0, classConfig);
            if(scale != 1.0) {
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
            if(tmp != tmp1) {
                MmgHelper.wr(key + " OffsetX: " + tmp + " - " + tmp1);
                tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = keyRoot + "OffsetY";            
            tmp1 = 0;            
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                MmgHelper.wr(key + " OffsetY: " + tmp + " - " + tmp1);                            
                tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = keyRoot + "PosY";
            tmp1 = tB.GetPosition().GetY();
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                MmgHelper.wr(key + " PosY: " + tmp + " - " + tmp1);                            
                tB.GetPosition().SetY(pos.GetY() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = keyRoot + "PosX";
            tmp1 = tB.GetPosition().GetX();            
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                MmgHelper.wr(key + " PosX: " + tmp + " - " + tmp1);                
                tB.GetPosition().SetX(pos.GetX() + MmgHelper.ScaleValue(tmp));                
            }            
            return tB;
        } else {
            return null;
        }
    }    
    
    /**
     * Performs the MmgObj position based on the provided class configuration key.
     * 
     * @param keyRoot       The root class configuration key to use for processing the MmgObj positioning.
     * @param tB            The MmgObj to process.
     * @param classConfig   The set of class configuration entries to search.
     * @param pos           The default position to use for the MmgObj object.
     * @return              A reference to a modified MmgObj based on the tB argument.
     */
    public static MmgObj ContainsKeyMmgObjPosition(String keyRoot, MmgObj tB, Hashtable<String, MmgCfgFileEntry> classConfig, MmgVector2 pos) {
        String key = "";
        int tmp = 0;
        int tmp1 = 0;
        
        if (tB != null) {                        
            key = keyRoot + "OffsetX";  
            tmp1 = 0;
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = keyRoot + "OffsetY";
            tmp1 = 0;
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = keyRoot + "PosY";
            tmp1 = tB.GetPosition().GetY();
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                tB.GetPosition().SetY(pos.GetY() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = keyRoot + "PosX";
            tmp1 = tB.GetPosition().GetX();            
            tmp = ContainsKeyInt(key, tmp1, classConfig);
            if(tmp != tmp1) {
                tB.GetPosition().SetX(pos.GetX() + MmgHelper.ScaleValue(tmp));                
            }  
            return tB;
        } else {
            return null;
        }
    }      
    
    /**
     * A static class method that writes MmgCfgFileEntry objects to a target file.
     * 
     * @param file      The file to write the class config data to.
     * @param data      The array of MmgCfgFileEntry objects to write.
     * @return          A boolean indicating if the write was handled successfully.
     */
    public static boolean WriteClassConfigFile(String file, MmgCfgFileEntry[] data) {
        boolean ret = false;
        
        try {
            if(data != null && data.length > 0) {                
                MmgCfgFileEntry cfe = null;
                FileWriter fw = new FileWriter(file, false);
                BufferedWriter bw = new BufferedWriter(fw);
                Arrays.sort(data);
                int len = data.length;
                
                for(int i = 0; i < len; i++) {
                    cfe = data[i];
                    bw.write(cfe.ApiToString());
                    bw.newLine();
                }

                try {
                    bw.close();
                }catch(Exception ex) {
                    wrErr(ex);
                }                
                
                ret = true;
                
            } else {
                ret = false;
                
            }
            
        }catch(Exception e) {
            ret = false;
            wrErr(e);
            
        }
        
        return ret;
    }    
    
    /**
     * A static class method that writes MmgCfgFileEntry objects to a target file.
     * 
     * @param file      The file to write the class config data to. 
     * @param data      A Hashtable that contains the MmgCfgFileEntry objects to write.
     * @return          A boolean indicating if the write was handled successfully.
     */
    public static boolean WriteClassConfigFile(String file, Hashtable<String, MmgCfgFileEntry> data) {
        boolean ret = false;
        
        try {
            if(data != null && data.size() > 0) {
                MmgCfgFileEntry cfe = null;
                FileWriter fw = new FileWriter(file, false);
                BufferedWriter bw = new BufferedWriter(fw);
                Set<String> keys = data.keySet();                
                String[] nKeys = new String[keys.size()];
                nKeys = keys.toArray(nKeys);
                Arrays.sort(nKeys);
                int len = nKeys.length;
                
                for(int i = 0; i < len; i++) {
                    cfe = data.get(nKeys[i]);
                    bw.write(cfe.ApiToString());
                    bw.newLine();
                }

                try {
                    bw.close();
                }catch(Exception ex) {
                    wrErr(ex);
                }                
                
                ret = true;
                
            } else {
                ret = false;
                
            }
            
        }catch(Exception e) {
            ret = false;
            wrErr(e);
            
        }
        
        return ret;
    }    
    
    /**
     * A static class method that reads a Hashtable of MmgCfgFileEntry objects from a valid class config file.
     * 
     * @param file      The target class config file to read.
     * @return          A Hashtable with key, MmgCfgFileEntry pairs, loading from the class config file.
     */
    public static Hashtable<String, MmgCfgFileEntry> ReadClassConfigFile(String file) {
        Hashtable<String, MmgCfgFileEntry> ret = new Hashtable<String, MmgCfgFileEntry>();
        
        try {
            MmgCfgFileEntry cfe = null;
            File f = null;
            String nFile = file.replace(".txt", MmgScreenData.GetScreenWidth() + "x" + MmgScreenData.GetScreenHeight() + ".txt");
            f = new File(nFile);            
            if(!f.exists()) {
                f = new File(file);
            }
            
            if(f.exists()) {                
                FileReader fr = new FileReader(file);
                BufferedReader br = new BufferedReader(fr);
                String line = br.readLine();
                String[] data = null;
                
                while(line != null) {
                    cfe = new MmgCfgFileEntry();
                    line = line.trim();
                    if(line.equals("") == false && line.charAt(0) != '#') {
                        if(line.indexOf("=") != -1) {
                            data = line.split("=");
                            if(data.length == 2) {
                                cfe.cfgType = CfgEntryType.TYPE_DOUBLE;
                                cfe.number = new Double(data[1]);
                                cfe.name = data[0];
                                ret.put(data[0], cfe);
                            }
                        } else if(line.indexOf("->") != -1) {
                            data = line.split("->");
                            if(data.length == 2) {
                                cfe.cfgType = CfgEntryType.TYPE_STRING;                                
                                cfe.str = data[1];
                                cfe.name = data[0];                                
                                ret.put(data[0], cfe);
                            }                            
                        }
                    }
                    line = br.readLine();
                }
                
                try {
                    br.close();
                }catch(Exception ex) {
                    wrErr(ex);
                }
            }
        }catch(Exception e) {
            wrErr(e);
        }
        
        return ret;
    }    
    
    /**
     * A static method for creating an MmgBmp object filled with the provided color.
     * 
     * @param width     The width of the MmgBmp object created.
     * @param height    The height of the MmgBmp object created.
     * @param color     The MmgColor that is used to fill the MmgBmp object created.
     * @return          An MmgBmp object with the width and height provided filled with the specified color.
     */
    public static MmgBmp CreateFilledBmp(int width, int height, MmgColor color) {
        return CreateDrawableBmpSet(width, height, false, color).img;
    }
    
    /**
     * A static method for creating an MmgDrawableBmpSet of the specified width and height.
     * An MmgDrawableBmpSet contains an MmgPen wrapping a Graphics object and configured to write to the BufferedImage and
     * an MmgBmp object that wraps the BufferedImage.
     * 
     * @param width     The width of the MmgBmp object created.
     * @param height    The height of the MmgBmp object created.
     * @param alpha     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @return          An MmgDrawableBmpSet that contains initialized objects needed to draw on an MmgBmp object.
     */
    public static MmgDrawableBmpSet CreateDrawableBmpSet(int width, int height, boolean alpha) {
        MmgDrawableBmpSet dBmpSet = new MmgDrawableBmpSet();
        dBmpSet.buffImg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(width, height, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
        dBmpSet.graphics = (Graphics2D)dBmpSet.buffImg.getGraphics();
        dBmpSet.p = new MmgPen();
        dBmpSet.p.SetGraphics(dBmpSet.graphics);
        dBmpSet.p.SetAdvRenderHints();
        dBmpSet.img = new MmgBmp(dBmpSet.buffImg);
        return dBmpSet;
    }
    
    /**
     * A static method for creating an MmgDrawableBmpSet of the specified width and height and filled with the specified color.
     * An MmgDrawableBmpSet contains an MmgPen wrapping a Graphics object and configured to write to the BufferedImage and
     * an MmgBmp object that wraps the BufferedImage.
     * 
     * @param width     The width of the MmgBmp object created.
     * @param height    The height of the MmgBmp object created.
     * @param alpha     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @param color     The color used to fill the created MmgBmp object.
     * @return          An MmgDrawableBmpSet that contains initialized objects needed to draw on an MmgBmp object.
     */
    public static MmgDrawableBmpSet CreateDrawableBmpSet(int width, int height, boolean alpha, MmgColor color) {
        MmgDrawableBmpSet dBmpSet = MmgHelper.CreateDrawableBmpSet(width, height, alpha);
        Color c = dBmpSet.graphics.getColor();
        dBmpSet.graphics.setColor(color.GetColor());
        dBmpSet.graphics.fillRect(0, 0, width, height);
        dBmpSet.graphics.setColor(c);
        return dBmpSet;
    }    
    
    /**
     * A static class method used to determine if there is a collision between the X, Y coordinates and the MmgRect.
     * 
     * @param x     The X coordinate used to test for a collision.
     * @param y     The Y coordinate used to test for a collision.
     * @param r     The MmgRect used to test for a collision.
     * @return      A boolean indicating if there has been a collision detected.
     */
    public static boolean RectCollision(int x, int y, MmgRect r) {
        if(x >= r.GetLeft() && x <= r.GetRight()) {
            if(y >= r.GetTop() && y <= r.GetBottom()) {
                return true;
            }
        }
        
        return false;
    }    
    
    /**
     * Tests for collision of two rectangles.
     *
     * @param r1x       Rectangle #1, X coordinate.
     * @param r1y       Rectangle #1, Y coordinate.
     * @param w         Rectangle #1, width.
     * @param h         Rectangle #1, height.
     * @param r         Rectangle #2.
     * @return          True if there is a collision of the two rectangles.
     */
    public static boolean RectCollision(int r1x, int r1y, int w, int h, MmgRect r) {
        int r2x = r.GetLeft();
        int r2y = r.GetTop();
        return RectCollision(r1x, r1y, w, h, r2x, r2y, (r.GetRight() - r.GetLeft()), (r.GetBottom() - r.GetTop()));
    }

    /**
     * Tests for collision of two rectangles.
     *
     * @param src       Rectangle #1.
     * @param dest      Rectangle #2.
     * @return          True if there is a collision of the two rectangles.
     */
    public static boolean RectCollision(MmgRect src, MmgRect dest) {
        return RectCollision(src.GetLeft(), src.GetTop(), src.GetWidth(), src.GetHeight(), dest);
    }
    
    /**
     * A static method that tests for the collision of two MmgObj instances.
     * 
     * @param src       The source MmgObj to test for a collision.
     * @param dest      The destination MmgObj to test for a collision.
     * @return          A boolean indicating if a collision was found or not.
     */
    public static boolean RectCollision(MmgObj src, MmgObj dest) {
        return RectCollision(src.GetX(), src.GetY(), src.GetWidth(), src.GetHeight(), dest.GetX(), dest.GetY(), dest.GetWidth(), dest.GetHeight());
    }    

    /**
     * A static method that tests for a collision using an MmgVector2 and a width and height to define a collision rectangle.
     * 
     * @param src       The source point used in the collision test.
     * @param sW        The width used in the source rectangle definition.
     * @param sH        The height used in the source rectangle definition.
     * @param dest      The destination point used in the collision test.
     * @param dW        The width used in the destination rectangle definition.
     * @param dH        The height used in the destination rectangle definition.
     * @return          A boolean indicating if a collision was found or not.
     */
    public static boolean RectCollision(MmgVector2 src, int sW, int sH, MmgVector2 dest, int dW, int dH) {
        return RectCollision(src.GetX(), src.GetY(), sW, sH, dest.GetX(), dest.GetY(), dW, dH);
    }    
    
    /**
     * Tests for collisions of two rectangles.
     *
     * @param r1x       Rectangle #1, X coordinate.
     * @param r1y       Rectangle #1, Y coordinate.
     * @param r1w       Rectangle #1, width.
     * @param r1h       Rectangle #1, height.
     * @param r2x       Rectangle #2, X coordinate.
     * @param r2y       Rectangle #2, Y coordinate.
     * @param r2w       Rectangle #2, width.
     * @param r2h       Rectangle #2, height.
     * @return          True if there is a collision of the two rectangles.
     */
    public static boolean RectCollision(int r1x, int r1y, int r1w, int r1h, int r2x, int r2y, int r2w, int r2h) {
        if (r1x >= r2x && r1x <= (r2x + r2w) && r1y >= r2y && r1y <= (r2y + r2h)) {
            return true;

        } else if ((r1x + r1w) >= r2x && (r1x + r1w) <= (r2x + r2w) && r1y >= r2y && r1y <= (r2y + r2h)) {
            return true;

        } else if ((r1x + r1w) >= r2x && (r1x + r1w) <= (r2x + r2w) && (r1y + r1h) >= r2y && (r1y + r1h) <= (r2y + r2h)) {
            return true;

        } else if (r1x >= r2x && r1x <= (r2x + r2w) && (r1y + r1h) >= r2y && (r1y + r1h) <= (r2y + r2h)) {
            return true;

        } else if (r2x >= r1x && r2x <= (r1x + r1w) && r2y >= r1y && r2y <= (r1y + r1h)) {
            return true;

        } else if ((r2x + r2w) >= r1x && (r2x + r2w) <= (r1x + r1w) && r2y >= r1y && r2y <= (r1y + r1h)) {
            return true;

        } else if ((r2x + r2w) >= r1x && (r2x + r2w) <= (r1x + r1w) && (r2y + r2h) >= r1y && (r2y + r2h) <= (r1y + r1h)) {
            return true;

        } else if (r2x >= r1x && r2x <= (r1x + r1w) && (r2y + r2h) >= r1y && (r2y + r2h) <= (r1y + r1h)) {
            return true;

        }

        return false;
    }

    /**
     * The absolute value of the distance between two points.
     *
     * @param x1        Point #1, X coordinate.
     * @param x2        Point #2, X coordinate.
     * @param y1        Point #1, Y coordinate.
     * @param y2        Point #2, Y coordinate.
     * @return          The absolute value of the calculated distance.
     */
    public static int AbsDistance(int x1, int x2, int y1, int y2) {
        return (int) Math.sqrt((double) (((y1 - x1) * (y1 - x1)) + ((y2 - x2) * (y2 - x2))));
    }

    /**
     * Centers an MmgObj horizontally.
     *
     * @param obj       The object to center.
     * @return          A centered object.
     * @see             MmgScreenData
     */
    public static MmgObj CenterHor(MmgObj obj) {
        MmgVector2 vec = new MmgVector2((int) (MmgScreenData.GetGameLeft() + (MmgScreenData.GetGameWidth() - obj.GetWidth()) / 2), obj.GetPosition().GetY());
        obj.SetPosition(vec);
        return obj;
    }

    /**
     * Centers an MmgObj vertically.
     *
     * @param obj       The object to center.
     * @return          A centered object.
     * @see             MmgScreenData
     */
    public static MmgObj CenterVert(MmgObj obj) {
        MmgVector2 vec = new MmgVector2(obj.GetPosition().GetX(), (int) (MmgScreenData.GetGameTop() + (MmgScreenData.GetGameHeight() - obj.GetHeight()) / 2));
        obj.SetPosition(vec);
        return obj;
    }

    /**
     * Centers an MmgObj horizontally and vertically.
     *
     * @param obj       The object to center.
     * @return          A centered object.
     * @see             MmgScreenData
     */
    public static MmgObj CenterHorAndVert(MmgObj obj) {
        obj = CenterHor(obj);
        obj = CenterVert(obj);
        return obj;
    }

    /**
     * Centers an MmgObj horizontally and places it at the top of the screen
     * vertically.
     *
     * @param obj       The object to position.
     * @return          A repositioned object.
     * @see             MmgScreenData
     */
    public static MmgObj CenterHorAndTop(MmgObj obj) {
        obj = CenterHor(obj);
        MmgVector2 pos = obj.GetPosition().Clone();
        pos.SetY(MmgScreenData.GetGameTop());
        obj.SetPosition(pos);
        return obj;
    }

    /**
     * Centers an MmgObj horizontally and places it at the bottom of the screen
     * vertically.
     *
     * @param obj       The object to position.
     * @return          A repositioned object.
     */
    public static MmgObj CenterHorAndBot(MmgObj obj) {
        obj = CenterHor(obj);
        MmgVector2 pos = obj.GetPosition().Clone();
        int h = obj.GetHeight();
        pos.SetY((MmgScreenData.GetGameTop() + MmgScreenData.GetGameHeight()) - h);
        obj.SetPosition(pos);
        return obj;
    }

    /**
     * Centers an MmgObj horizontally and vertically.
     *
     * @param obj       The object to position.
     * @return          A repositioned object.
     */
    public static MmgObj CenterHorAndMid(MmgObj obj) {
        return CenterHorAndVert(obj);
    }

    /**
     * Repositions an MmgObj horizontally left and vertically top.
     *
     * @param obj       The object to position.
     * @return          A repositioned object.
     */
    public static MmgObj LeftHorAndTop(MmgObj obj) {
        MmgVector2 pos = obj.GetPosition().Clone();
        pos.SetX(MmgScreenData.GetGameLeft());
        pos.SetY(MmgScreenData.GetGameTop());
        obj.SetPosition(pos);
        return obj;
    }

    /**
     * Repositions an MmgObj horizontally left, and vertically top.
     *
     * @param obj       The object to position.
     * @return          A repositioned object.
     */
    public static MmgObj LeftHorAndMid(MmgObj obj) {
        MmgVector2 pos = obj.GetPosition().Clone();
        pos.SetX(MmgScreenData.GetGameLeft());
        obj.SetPosition(pos);
        return CenterVert(obj);
    }

    /**
     * Repositions an MmgObj horizontally left and vertically bottom.
     *
     * @param obj       The object to reposition.
     * @return          A repositioned object.
     */
    public static MmgObj LeftHorAndBot(MmgObj obj) {
        MmgVector2 pos = obj.GetPosition().Clone();
        int h = obj.GetHeight();
        pos.SetY((MmgScreenData.GetGameTop() + MmgScreenData.GetGameHeight()) - h);
        pos.SetX(MmgScreenData.GetGameLeft());
        obj.SetPosition(pos);
        return obj;
    }

    /**
     * Repositions an MmgObj horizontally right, and vertically top.
     *
     * @param obj       The object to reposition.
     * @return          A repositioned object.
     */
    public static MmgObj RightHorAndTop(MmgObj obj) {
        MmgVector2 pos = obj.GetPosition().Clone();
        int w = obj.GetWidth();
        pos.SetX((MmgScreenData.GetGameLeft() + MmgScreenData.GetGameWidth()) - w);
        pos.SetY(MmgScreenData.GetGameTop());
        obj.SetPosition(pos);
        return obj;
    }

    /**
     * Repositions an MmgObj horizontally right, and vertically middle.
     *
     * @param obj       The object to reposition.
     * @return          A repositioned object.
     */
    public static MmgObj RightHorAndMid(MmgObj obj) {
        MmgVector2 pos = obj.GetPosition().Clone();
        int w = obj.GetWidth();
        pos.SetX((MmgScreenData.GetGameLeft() + MmgScreenData.GetGameWidth()) - w);
        obj.SetPosition(pos);
        return CenterVert(obj);
    }

    /**
     * Repositions an MmgObj horizontally right, and vertically bottom.
     *
     * @param obj       The object to reposition.
     * @return          A repositioned object.
     */
    public static MmgObj RightHorAndBot(MmgObj obj) {
        MmgVector2 pos = obj.GetPosition().Clone();
        int h = obj.GetHeight();
        int w = obj.GetWidth();
        pos.SetY((MmgScreenData.GetGameTop() + MmgScreenData.GetGameHeight()) - h);
        pos.SetX((MmgScreenData.GetGameLeft() + MmgScreenData.GetGameWidth()) - w);
        obj.SetPosition(pos);
        return obj;
    }

    /**
     * Scaling method, applies the scale X to the given argument.
     *
     * @param val       The value to scale.
     * @return          A scaled value.
     */
    public static int ScaleValue(int val) {
        return (int) ((double) val * MmgScreenData.GetScaleX());
    }

    /**
     * Scaling method, applies the scale x to the given argument.
     *
     * @param val       The value to scale.
     * @return          A scaled value.
     */
    public static float ScaleValue(float val) {
        return (float) ((double) val * MmgScreenData.GetScaleX());
    }

    /**
     * Scaling method, applies the scale x to the given argument.
     *
     * @param val       The value to scale.
     * @return          A scaled value.
     */
    public static double ScaleValue(double val) {
        return (double) ((double) val * MmgScreenData.GetScaleX());
    }
    
    /**
     * A static method used to generate a random integer.
     * 
     * @param exclusiveUpperBound       An exclusive upper bound on the random number generated.
     * @return                          An integer between 0 not including the exclusiveUpperBound.
     */
    public static int GetRandomInt(int exclusiveUpperBound) {
        return rando.nextInt(exclusiveUpperBound);
    }
    
    /**
     * A static method used to generate a random integer from the given range.
     * 
     * @param min   An inclusive lower bound.
     * @param max   An exclusive upper bound.
     * @return      A random value greater than or equal to min and less than max.
     */
    public static int GetRandomIntRange(int min, int max) {
        return rando.nextInt(max - min) + min;        
    }

    /**
     * A static method that returns the current time in milliseconds.
     * 
     * @return The current time in milliseconds.
     */
    public static long CtMs() {
        return System.currentTimeMillis();
    }
    
    /**
     * Centralized logging method for standard out logging.
     *
     * @param s     The string to be logged.
     */
    public static void wr(String s) {
        if (LOGGING == true) {
            System.out.println(s);
        }
    }

    /**
     * Centralized logging method for standard error logging.
     *
     * @param e     The exception to be logged.
     */
    public static void wrErr(Exception e) {
        if (LOGGING == true) {
            System.err.println("ErrorLog: " + e.getMessage());
            StackTraceElement[] els = e.getStackTrace();
            int len = els.length;
            for (int i = 0; i < len; i++) {
                System.err.println("ErrorLog: " + els[i].toString());
            }
        }
    }

    /**
     * Centralized logging method for standard err logging.
     *
     * @param s     The string to be logged.
     */
    public static void wrErr(String s) {
        if (LOGGING == true) {
            System.err.println("ErrorLog: " + s);
        }
    }

    /**
     * Fills the specified rectangle region of the buffImg argument with the specified color.
     * 
     * @param x         The X coordinate of the rectangle.
     * @param y         The Y coordinate of the rectangle.
     * @param w         The width of the rectangle.
     * @param h         The height of the rectangle.
     * @param c         The color to fill the rectangle with.
     * @param buffImg   The image to draw the rectangle on.
     */
    public static void FillRectWithColor(int x, int y, int w, int h, Color c, BufferedImage buffImg) {        
        Graphics2D g = (Graphics2D)buffImg.getGraphics();
        g.setColor(c);
        g.fillRect(x, y, w, h);
        g.dispose();
    }
    
    /**
     * A static method used to create an MmgSound object from a sound resource file.
     * 
     * @param path      The path of the sound resource loaded.
     * @param sndId     The id to use when storing the sound resource in the sound resource cache.
     * @return          An MmgSound object created from the specified resource file or loaded from the sound resource cache.
     */
    @SuppressWarnings("UnusedAssignment")
    public static MmgSound GetBasicCachedSound(String path, String sndId) {
        MmgSound lval = null;
        if (SND_CACHE_ON == true) {
            if (MmgMediaTracker.HasSoundKey(sndId) == true) {
                lval = new MmgSound(MmgMediaTracker.GetSoundValue(sndId));
            } else {
                lval = MmgHelper.GetBasicSound(path);
                MmgMediaTracker.CacheSound(sndId, lval.GetSound());
            }
        } else {
            lval = MmgHelper.GetBasicSound(path);
        }
        return lval;
    }
    
    /**
     * Loads a cached sound with the provided sound resource ID, the sndId argument or loads a new resource using the provided binary data.
     * 
     * @param data      A byte array representation of the sound.
     * @param sndId     The ID to use when the sound resource is cached.
     * @return          An MmgSound object instance based on the sound resource.
     */
    @SuppressWarnings("UnusedAssignment")
    public static MmgSound GetBasicCachedSound(byte[] data, String sndId) {
        MmgSound lval = null;
        if (SND_CACHE_ON == true) {
            if (MmgMediaTracker.HasSoundKey(sndId) == true) {
                lval = new MmgSound(MmgMediaTracker.GetSoundValue(sndId));
            } else {
                lval = MmgHelper.GetBinarySound(data);
                MmgMediaTracker.CacheSound(sndId, lval.GetSound());
            }
        } else {
            lval = MmgHelper.GetBinarySound(data);
        }
        return lval;
    }
    
    /**
     * A static method used to create an MmgSound object from a sound resource file.
     * 
     * @param sndId     The id to use when pulling the sound resource from the sound cache.
     * @return          An MmgSound object loaded from the sound resource cache.
     */
    @SuppressWarnings("UnusedAssignment")
    public static MmgSound GetBasicCachedSound(String sndId) {
        MmgSound lval = null;
        if (SND_CACHE_ON == true) {
            if (MmgMediaTracker.HasSoundKey(sndId) == true) {
                lval = new MmgSound(MmgMediaTracker.GetSoundValue(sndId));
            }
        }
        return lval;
    }     
    
    /**
     * A static method used to create an MmgBmp object loaded from an image resource file.
     * 
     * @param path      The path to the image resource file to load.
     * @param imgId     The id used to store the image resource file into the image resource cache.
     * @return          An MmgBmp object loaded from the image file or the image resource cache.
     */ 
    @SuppressWarnings("UnusedAssignment")
    public static MmgBmp GetBasicCachedBmp(String path, String imgId) {
        MmgBmp lval = null;
        if (BMP_CACHE_ON == true) {
            if (MmgMediaTracker.HasBmpKey(imgId) == true) {
                lval = new MmgBmp(MmgMediaTracker.GetBmpValue(imgId));
                lval.SetMmgColor(null);
            } else {
                lval = MmgHelper.GetBasicBmp(path);
                MmgMediaTracker.CacheImage(imgId, lval.GetImage());
            }
        } else {
            lval = MmgHelper.GetBasicBmp(path);
        }
        return lval;
    }

    /**
     * Loads a cached sound with the provided sound resource ID, the sndId argument or loads a new resource using the provided binary data.
     * 
     * @param data      A byte array representation of the sound.
     * @param imgId     The ID to use when the sound resource is cached.
     * @return          An MmgSound object instance based on the sound resource.
     */
    public static MmgBmp GetBasicCachedBmp(byte[] data, String imgId) {
        MmgBmp lval = null;
        if (BMP_CACHE_ON == true) {
            if (MmgMediaTracker.HasBmpKey(imgId) == true) {
                lval = new MmgBmp(MmgMediaTracker.GetBmpValue(imgId));
                lval.SetMmgColor(null);
            } else {
                lval = MmgHelper.GetBinaryBmp(data);
                MmgMediaTracker.CacheImage(imgId, lval.GetImage());
            }
        } else {
            lval = MmgHelper.GetBinaryBmp(data);
        }
        return lval;
    }    
    
    /**
     * A static method used to create an MmgBmp object from an image resource file.
     * 
     * @param imgId     The id used to store the image resource file into the image resource cache.
     * @return          An MmgBmp object loaded from the image file or the image resource cache.
     */
    @SuppressWarnings("UnusedAssignment")
    public static MmgBmp GetBasicCachedBmp(String imgId) {
        MmgBmp lval = null;
        if (BMP_CACHE_ON == true) {
            if (MmgMediaTracker.HasBmpKey(imgId) == true) {
                lval = new MmgBmp(MmgMediaTracker.GetBmpValue(imgId));
                lval.SetMmgColor(null);
            }
        }
        return lval;
    }    
    
    /**
     * A static method to list the cached resources, images and sounds.
     */
    public static void ListCacheEntries() {
        int len;
        Object[] keys;
        String key;
        int i;
        
        if (BMP_CACHE_ON == true) {
            len = MmgMediaTracker.GetBmpCacheSize();
            keys = MmgMediaTracker.cacheBmp.keySet().toArray();
            for (i = 0; i < len; i++) {
                key = keys[i] + "";
                wr("BMP: " + i + " key: " + key);
            }
        }
        
        if (SND_CACHE_ON == true) {
            len = MmgMediaTracker.GetSoundCacheSize();
            keys = MmgMediaTracker.cacheSound.keySet().toArray();
            for (i = 0; i < len; i++) {
                key = keys[i] + "";
                wr("SND: " + i + " key: " + key);
            }
        }        
    }

    /**
     * Gets a basic sound from the file system.
     *
     * @param src       A path to a valid sound resource.
     * @return          A sound loaded from the file path.
     */
    public static MmgSound GetBasicSound(String src) {
        Clip in = null;
        MmgSound snd = null;
        
        try {
            AudioInputStream audioIn = AudioSystem.getAudioInputStream(new File(src));
            in = AudioSystem.getClip();
            in.open(audioIn);
            snd = new MmgSound(in);
        } catch(Exception e) {
            e.printStackTrace();
        }

        return snd;
    }    
    
    /**
     * Gets a basic bitmap from the file system.
     *
     * @param src       A path to a valid bitmap resource.
     * @return          A bitmap loaded from the file path.
     */
    public static MmgBmp GetBasicBmp(String src) {
        Image b = null;
        MmgBmp r = null;

        try {
            b = ImageIO.read(new File(src));
        } catch (Exception e) {
            MmgHelper.wrErr(e);
        }

        if (b != null) {
            b = MmgPen.ScaleImageStatic(b, MmgScreenData.GetScale());
            r = new MmgBmp(b);
            r.SetScaling(MmgVector2.GetUnitVec());
            r.SetPosition(MmgVector2.GetOriginVec());
            r.SetOrigin(MmgVector2.GetOriginVec());
            r.SetMmgColor(null);
        }

        return r;
    }

    /**
     * A static method for converting binary image data into an MmgBmp object.
     * 
     * @param d         The array of bytes representing the image data.
     * @return          An MmgBmp object that is created from the binary image data.
     */
    public static MmgBmp GetBinaryBmp(byte[] d) {
        Image b = null;
        MmgBmp r = null;

        try {
            b = ImageIO.read(new ByteArrayInputStream(d));
        } catch (Exception e) {
            MmgHelper.wrErr(e);
        }

        if (b != null) {
            b = MmgPen.ScaleImageStatic(b, MmgScreenData.GetScale());
            r = new MmgBmp(b);
            r.SetScaling(MmgVector2.GetUnitVec());
            r.SetPosition(MmgVector2.GetOriginVec());
            r.SetOrigin(MmgVector2.GetOriginVec());
            r.SetMmgColor(null);
        }

        return r;
    }
    
    /**
     * A static method for converting binary image data into an MmgSound object.
     * 
     * @param d     The array of bytes representing the sound data.
     * @return      An MmgSound object that is created from the binary sound data.
     */
    public static MmgSound GetBinarySound(byte[] d) {
        Clip in = null;
        MmgSound snd = null;
                
        try {
            AudioInputStream audioIn = AudioSystem.getAudioInputStream(new ByteArrayInputStream(d));
            in = AudioSystem.getClip();
            in.open(audioIn);
            snd = new MmgSound(in);
        } catch(Exception e) {
            e.printStackTrace();
        }

        return snd;
    }    
    

    /**
     * A static method for converting the lower level Java image into an MmgBmp object.
     * 
     * @param b         The Image instance used to create an MmgBmp object.
     * @return          An MmgBmp object that is created from the binary image data.
     */
    public static MmgBmp GetImageBmp(Image b) {
        MmgBmp r = null;

        if (b != null) {
            b = MmgPen.ScaleImageStatic(b, MmgScreenData.GetScale());
            r = new MmgBmp(b);
            r.SetScaling(MmgVector2.GetUnitVec());
            r.SetPosition(MmgVector2.GetOriginVec());
            r.SetOrigin(MmgVector2.GetOriginVec());
            r.SetMmgColor(null);
        }

        return r;
    }

    /**
     * A static method for converting the lower level Java image into an MmgBmp object.
     * 
     * @param b         The Image instance used to create an MmgBmp object.
     * @return          An MmgBmp object that is created from the binary image data.
     */
    public static MmgBmp GetImageCacheBmp(Image b) {
        MmgBmp r = null;

        if (b != null) {
            r = new MmgBmp(b);
            r.SetScaling(MmgVector2.GetUnitVec());
            r.SetPosition(MmgVector2.GetOriginVec());
            r.SetOrigin(MmgVector2.GetOriginVec());
            r.SetMmgColor(null);
        }

        return r;
    }

    /**
     * Gets a basic MmgMenuItem instance.
     *
     * @param handler       The event handler of the menu item.
     * @param name          The name of the menu item.
     * @param eventId       The id of the menu item event.
     * @param eventType     The type of the menu item event.
     * @param img           The image used to display the menu item.
     * @return              A new configured MmgMenuItem.
     */
    public static MmgMenuItem GetBasicMenuItem(MmgEventHandler handler, String name, int eventId, int eventType, MmgBmp img) {
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