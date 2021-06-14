package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.*;
import java.awt.geom.AffineTransform;
import java.awt.image.AffineTransformOp;
import java.awt.image.BufferedImage;

/**
 * Main drawing class, wraps lower level drawing classes.
 * Created by Middlemind Games
 * 
 * @author Victor G. Brusca
 */
public class MmgPen {
    /**
     * A boolean flag that indicates if the font position should be run through a normalization method.
     */
    public static boolean FONT_NORMALIZE_POSITION = false;    
    
    /**
     * The lower level drawing class.
     */
    private Graphics pen;
    
    /**
     * The color to use when drawing.
     */
    private Color color;
    
    /**
     * A class helper variable.
     */
    private Image tmpImg;
    
    /**
     * A class helper variable.
     */
    private String tmpIdStr;
    
    /**
     * Determines if the bitmap cache is on.
     */
    private boolean cacheOn;
    
    /**
     * Determines if advanced render hints is turned on.
     */
    public static boolean ADV_RENDER_HINTS = true;

    /**
     * A private class field used to hold a temporary reference to the Font used.
     */
    private Font tmpF;
    
    /**
     * A private class field used to hold a temporary reference to the Color used.
     */
    private Color tmpC;
    
    /**
     * A static class field that holds a reference to a transparent Color class instance.
     */
    public static Color TRANSPARENT = new Color(0f, 0f, 0f, 1f);
    
    /**
     * Constructor for this class.
     */
    public MmgPen() {
        cacheOn = false;
    }
    
    /**
     * Constructor that sets the local Graphics reference.
     * 
     * @param p     The Graphics reference to use for drawing.
     * @see         Graphics
     */
    public MmgPen(Graphics p) {
        pen = p;
        cacheOn = false;
    }
    
    /**
     * Constructor that sets the local graphics reference from the Image argument.
     * @param img   The Image from which the graphics context is used to create this MmgPen.
     */
    public MmgPen(Image img) {
        pen = img.getGraphics();
        cacheOn = false;
    }    
    
    /**
     * Constructor that sets the local Graphics reference and the color
     * of the pen.
     * 
     * @param p     The Graphics reference to use for drawing.
     * @param c     The color to use for drawing.
     */
    public MmgPen(Graphics p, Color c) {
        pen = p;
        color = c;
        cacheOn = false;
    }
    
    /**
     * Sets the bitmap drawing cache.
     * 
     * @param b     True if the bitmap drawing cache is on, false otherwise.
     */
    public void SetCacheOn(boolean b) {
        cacheOn = b;
    }
    
    /**
     * Gets the bitmap drawing cache.
     * 
     * @return      True if the bitmap drawing cache is on, false otherwise.
     */
    public boolean GetCacheOn() {
        return cacheOn;
    }

    /**
     * Drawing method to use for drawing text to the screen.
     * 
     * @param f     The MmgFont object to draw.
     * @see         MmgFont
     */
    public void DrawText(MmgFont f) {
        tmpF = pen.getFont();
        tmpC = pen.getColor();
                
        pen.setColor(f.GetMmgColor().GetColor());
        pen.setFont(f.GetFont());
        if (FONT_NORMALIZE_POSITION) {
            pen.drawString(f.GetText(), MmgHelper.NormalizeFontPositionX(f.GetPosition().GetX(), f), MmgHelper.NormalizeFontPositionY(f.GetPosition().GetY(), f));            
        } else {
            pen.drawString(f.GetText(), f.GetPosition().GetX(), f.GetPosition().GetY());
        }
        
        pen.setFont(tmpF);
        pen.setColor(tmpC);
    }

    /**
     * Drawing method to use for drawing text to the screen at the specified position.
     * 
     * @param f     The MmgFont object to draw.
     * @param x     The x position to draw the object.
     * @param y     The y position to draw the object.
     * @see         MmgFont
     */
    public void DrawText(MmgFont f, int x, int y) {
        tmpF = pen.getFont();
        tmpC = pen.getColor();
                
        pen.setColor(f.GetMmgColor().GetColor());
        pen.setFont(f.GetFont());
        if (FONT_NORMALIZE_POSITION) {
            pen.drawString(f.GetText(), MmgHelper.NormalizeFontPositionX(x, f), MmgHelper.NormalizeFontPositionY(y, f));
        } else {
            pen.drawString(f.GetText(), x, y);
        }
        
        pen.setFont(tmpF);
        pen.setColor(tmpC);
    }    
    
    /**
     * Drawing method to use for drawing text to the screen at the specified position.
     * 
     * @param f     The MmgFont object to draw.
     * @param pos   The position to draw the object.
     * @see         MmgFont
     */
    public void DrawText(MmgFont f, MmgVector2 pos) {
        tmpF = pen.getFont();
        tmpC = pen.getColor();
                
        pen.setColor(f.GetMmgColor().GetColor());
        pen.setFont(f.GetFont());
        if (FONT_NORMALIZE_POSITION) {
            pen.drawString(f.GetText(), MmgHelper.NormalizeFontPositionX(pos.GetX(), f), MmgHelper.NormalizeFontPositionY(pos.GetY(), f));
        } else {
            pen.drawString(f.GetText(), pos.GetX(), pos.GetY());            
        }
        
        pen.setFont(tmpF);
        pen.setColor(tmpC);
    }    
    
    /**
     * Rotate the given image by the given degrees.
     * 
     * @param width     The width of the image.
     * @param height    The height of the image.
     * @param img       The image to rotate.
     * @param angle     The angle to rotate the image.
     * @param originX   The origin X to use in rotation.
     * @param originY   The origin Y to use in rotation.
     * @return          A newly rotated image.
     */
    public Image RotateImage(int width, int height, Image img, int angle, int originX, int originY) {
        return MmgPen.RotateImageStatic(width, height, img, angle, originX, originY);
    }

    /**
     * Rotate the given image by the given degrees.
     * 
     * @param width     The width of the image.
     * @param height    The height of the image.
     * @param img       The image to rotate.
     * @param angle     The angle to rotate the image.
     * @param originX   The origin X to use in rotation.
     * @param originY   The origin Y to use in rotation.
     * @return          A newly rotated image.
     */
    public static Image RotateImageStatic(int width, int height, Image img, int angle, int originX, int originY) {
        BufferedImage bi = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g = bi.createGraphics();
        
        if(MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }
        
        AffineTransform at = new AffineTransform();
        
        if(originX == -1 || originY == -1) {
            at.rotate(Math.toRadians(angle), (width/2), (height/2));
        }else{
            at.rotate(Math.toRadians(angle), originX, originY);
        }
        
        g.drawImage(img, 0, 0, null);
        AffineTransformOp op = new AffineTransformOp(at, AffineTransformOp.TYPE_BILINEAR);
        bi = op.filter(bi, null);
        g.dispose();
        return bi;        
    }
    
    /**
     * Scale the given image by the given scale factor.
     * 
     * @param img           The image to scale.
     * @param scaleX        The scale factor in the X axis direction.
     * @param scaleY        The scale factor in the Y axis direction.
     * @return              A scaled image.
     */
    public Image ScaleImage(Image img, double scaleX, double scaleY) {
        return MmgPen.ScaleImageStatic(img, scaleX, scaleY);
    }
    
    /**
     * Scale the given image by the given scale factor.
     * 
     * @param img           The image to scale.
     * @param scale         The scale factor in the X, Y axis directions.
     * @return              A scaled image.
     */
    public static Image ScaleImageStatic(Image img, MmgVector2 scale) {
        return MmgPen.ScaleImageStatic(img, scale.GetXDouble(), scale.GetYDouble());
    }
    
    /**
     * Static scale method, scales the given image by the given X,Y axis directions.
     * 
     * @param img           The image to scale.
     * @param scaleX        The scale factor in the X axis direction.
     * @param scaleY        The scale factor in the Y axis direction.
     * @return              A scaled image.
     */
    public static Image ScaleImageStatic(Image img, double scaleX, double scaleY) {
        int w = (int)(img.getWidth(null) * scaleX);
        int h = (int)(img.getHeight(null) * scaleY);
        BufferedImage rImage = new BufferedImage(w, h, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g = rImage.createGraphics();
        
        if(MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        g.drawImage(img, 0, 0, w, h, null);
        g.dispose();
        return rImage;
    }
    
    /**
     * Creates an Image that is filled with the specified color.
     * 
     * @param w         The width of the image to create.
     * @param h         The height of the image to create.
     * @param c         The color to use for filling the image.
     * @return          A colored image with the width and height specified and filled with the specified color.
     */
    public static Image CreateColorTile(int w, int h, MmgColor c) {
        BufferedImage rImage = new BufferedImage(w, h, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g = rImage.createGraphics();
        g.setColor(c.GetColor());
        g.fillRect(0, 0, w, h);
        g.dispose();
        return rImage;
    }
    
    /**
     * Sets the advanced render hints flags in the current Graphics context.
     * @see             Graphics
     */
    public void SetAdvRenderHints() {
        if(MmgPen.ADV_RENDER_HINTS == true) {
            Graphics2D g = (Graphics2D)pen;
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);            
        } else {
            MmgHelper.wr("ADV_RENDER_HINTS is set to false.");
        }
    }
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param idStr         The id in string form of the image to draw.
     * @param position      The position to draw the image.
     */
    public void DrawBmpBasic(String idStr, MmgVector2 position) {
        tmpImg = MmgMediaTracker.GetBmpValue(idStr);
        if(tmpImg != null) {
            DrawBmp(tmpImg, position.GetX(), position.GetY());
        }
    }
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param img       The image to be drawn.
     * @param x         The X axis offset to draw the image at.
     * @param y         The Y axis offset to draw the image at.
     */
    public void DrawBmp(Image img, int x, int y) {
        pen.drawImage(img, x, y, null);
    }
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b     The MmgBmp object to draw.
     * @see         MmgBmp
     */
    public void DrawBmpBasic(MmgBmp b) {
        DrawBmp(b, b.GetPosition());
    }
    
    /**
     * Drawing method for drawing a bitmap from the central cache.
     * 
     * @param b     The MmgBmp object to draw.
     * @see         MmgBmp
     */
    public void DrawBmpFromCache(MmgBmp b) {
        DrawBmpBasic(b.GetBmpIdStr(), b.GetPosition());
    }
    
    /**
     * A method to check if the specified Color is considered to be the empty color.
     * 
     * @param c     The Color with which to check equivalence to the empty color.
     * @return      A boolean indicating if the provided Color is empty or not.
     */
    public boolean IsEmptyColor(Color c) {
        if(c == null) {
            return true;
        } else {
            return false;
        }
    }
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b             The MmgBmp object to draw.
     * @param position      The position to draw the object at.
     */
    public void DrawBmp(MmgBmp b, MmgVector2 position) {
        if (color != null) {
            pen.drawImage(b.GetTexture2D(), position.GetX(), position.GetY(), color, null);
        } else if(b.GetMmgColor() != null) {
            pen.drawImage(b.GetTexture2D(), position.GetX(), position.GetY(), b.GetMmgColor().GetColor(), null);
        } else {
            pen.drawImage(b.GetTexture2D(), position.GetX(), position.GetY(), null);
        }
    }
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b     The MmgBmp object to draw.
     * @param x     The X coordinate to draw the image to.
     * @param y     The Y coordinate to draw the image to.
     */
    public void DrawBmp(MmgBmp b, int x, int y) {
        if (color != null) {
            pen.drawImage(b.GetTexture2D(), x, y, color, null);
        } else if(b.GetMmgColor() != null) {
            pen.drawImage(b.GetTexture2D(), x, y, b.GetMmgColor().GetColor(), null);
        } else {
            pen.drawImage(b.GetTexture2D(), x, y, null);
        }
    }    
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b             The MmgBmp object to draw.
     * @param position      The position to draw the object at.
     * @param rotation      The rotation to apply to the object.
     */
    public void DrawBmp(MmgBmp b, MmgVector2 position, float rotation) {
        DrawBmp(b, position, new MmgVector2(b.GetWidth() / 2, b.GetHeight() / 2), rotation);
    }
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b             The MmgBmp object to draw.
     * @param position      The position to draw the object at.
     * @param origin        The origin to draw the object from.
     * @param rotation      The rotation to apply to the object.
     */
    public void DrawBmp(MmgBmp b, MmgVector2 position, MmgVector2 origin, float rotation) {
        tmpIdStr = b.GetIdStr(rotation);
        
        if(rotation != 0) {
            if(cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true) {
                tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
            } else {
                tmpImg = RotateImage(b.GetWidth(), b.GetHeight(), b.GetTexture2D(), (int)rotation, origin.GetX(), origin.GetY());
                if(cacheOn == true) {
                    MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                }
            }
        } else {
            tmpImg = b.GetTexture2D();
        }
        
        if(color != null) {
            pen.drawImage(tmpImg, position.GetX(), position.GetY(), color, null);
        } else if(b.GetMmgColor() != null) {
            pen.drawImage(tmpImg, position.GetX(), position.GetY(), b.GetMmgColor().GetColor(), null);
        } else {
            pen.drawImage(tmpImg, position.GetX(), position.GetY(), null);
        }
    }

    /**
     * Draw a bitmap image onto another bitmap image using source and destination rectangles.
     * 
     * @param b         The MmgBmp object used to draw the source rectangle to the destination rectangle.
     * @param srcRect   The source rectangle to use.
     * @param dstRect   The destination rectangle to use.
     */
    public void DrawBmp(MmgBmp b, MmgRect srcRect, MmgRect dstRect) {
        tmpIdStr = b.GetBmpIdStr();
        
        if(cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true) {
            tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);       
        } else {
            tmpImg = b.GetTexture2D();
        }
        
        if(srcRect != null && dstRect != null) {
            pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), null);
        } else if(srcRect == null) {
            pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), 0, 0, b.GetWidth(), b.GetHeight(), null);            
        } else if(dstRect == null) {
            pen.drawImage(tmpImg, 0, 0, b.GetWidth(), b.GetHeight(), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), null);
        } else {
            pen.drawImage(tmpImg, 0, 0, b.GetWidth(), b.GetHeight(), 0, 0, b.GetWidth(), b.GetHeight(), null);                        
        }
    }    
    
    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b             The MmgBmp object to draw.
     * @param position      The position to draw the object at.
     * @param srcRect       The source rectangle to draw the image from.
     * @param dstRect       The destination rectangle to draw the image to.
     * @param scaling       The scaling to apply to the image.
     * @param origin        The origin to use to draw the image.
     * @param rotation      The rotation to apply to the image.
     * @see                 MmgBmp
     */
    public void DrawBmp(MmgBmp b, MmgVector2 position, MmgRect srcRect, MmgRect dstRect, MmgVector2 scaling, MmgVector2 origin, float rotation) {
        if(rotation != 0 && scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0)) {
            tmpIdStr = b.GetIdStr(rotation, scaling);
        } else if(rotation != 0) {
            tmpIdStr = b.GetIdStr(rotation);
        } else if(scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0)) {
            tmpIdStr = b.GetIdStr(scaling);
        } else{
            tmpIdStr = b.GetBmpIdStr();
        }
        
        if(cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true) {
            tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
        } else if(rotation != 0 && scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0)) {
            if(cacheOn == true && MmgMediaTracker.HasBmpKey(b.GetIdStr(rotation)) == true) {
                tmpImg = MmgMediaTracker.GetBmpValue(b.GetIdStr(rotation));
            } else {
                tmpImg = RotateImage(b.GetWidth(), b.GetHeight(), b.GetTexture2D(), (int)rotation, origin.GetX(), origin.GetY());
                if(cacheOn == true) {
                    MmgMediaTracker.CacheImage(b.GetIdStr(rotation), tmpImg);
                }
            }
            
            tmpImg = this.ScaleImage(tmpImg, scaling.GetXDouble(), scaling.GetYDouble());
            if(cacheOn == true) {
                MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
            }
        } else if(rotation != 0) {
            if(cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true) {
                tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
            } else {
                tmpImg = RotateImage(b.GetWidth(), b.GetHeight(), b.GetTexture2D(), (int)rotation, origin.GetX(), origin.GetY());
                if(cacheOn == true) {
                    MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                }
            }
        } else if(scaling != null && (scaling.GetXDouble() != 1.0 || scaling.GetYDouble() != 1.0)) {
           if(cacheOn == true && MmgMediaTracker.HasBmpKey(tmpIdStr) == true) {
               tmpImg = MmgMediaTracker.GetBmpValue(tmpIdStr);
           } else {
                tmpImg = ScaleImage(tmpImg, scaling.GetXDouble(), scaling.GetYDouble());
                if(cacheOn == true) {
                    MmgMediaTracker.CacheImage(tmpIdStr, tmpImg);
                }
           }
        } else {
            tmpImg = b.GetTexture2D();
        }
        
        if(dstRect == null) {
            if(srcRect == null) {
                if(color != null) {
                    pen.drawImage(tmpImg, position.GetX(), position.GetY(), color, null);
                } else if(b.GetMmgColor() != null) {
                    pen.drawImage(tmpImg, position.GetX(), position.GetY(), b.GetMmgColor().GetColor(), null);
                } else {
                    pen.drawImage(tmpImg, position.GetX(), position.GetY(), null);
                }
            } else {
                //src rect is not null
                if(color != null) {
                    pen.drawImage(tmpImg, position.GetX(), position.GetY(), (position.GetX() + srcRect.GetWidth()), (position.GetY() + srcRect.GetHeight()), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), color, null);
                } else if(b.GetMmgColor() != null) {
                    pen.drawImage(tmpImg, position.GetX(), position.GetY(), (position.GetX() + srcRect.GetWidth()), (position.GetY() + srcRect.GetHeight()), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), b.GetMmgColor().GetColor(), null);
                } else {
                    pen.drawImage(tmpImg, position.GetX(), position.GetY(), (position.GetX() + srcRect.GetWidth()), (position.GetY() + srcRect.GetHeight()), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), null);
                }
            }
        } else {
            if(srcRect == null) {
                if(color != null) {
                    pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), 0, 0, b.GetWidth(), b.GetHeight(), color, null);
                } else if(b.GetMmgColor() != null) {
                    pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), 0, 0, b.GetWidth(), b.GetHeight(), b.GetMmgColor().GetColor(), null);
                } else{
                    pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), 0, 0, b.GetWidth(), b.GetHeight(), null);
                }
            } else {
                if(color != null) {
                    pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), color, null);
                } else if(b.GetMmgColor() != null) {
                    pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), b.GetMmgColor().GetColor(), null);
                } else {
                    pen.drawImage(tmpImg, dstRect.GetLeft(), dstRect.GetTop(), dstRect.GetRight(), dstRect.GetBottom(), srcRect.GetLeft(), srcRect.GetTop(), srcRect.GetRight(), srcRect.GetBottom(), null);
                }
            }
        }
    }

    /**
     * Drawing method for drawing bitmap images.
     * 
     * @param b         The MmgBmp object to draw.
     * @see             MmgBmp
     */
    public void DrawBmp(MmgBmp b) {
        DrawBmp(b, b.GetPosition(), b.GetSrcRect(), b.GetDstRect(), b.GetScaling(), b.GetOrigin(), b.GetRotation());
    }

    /**
     * Drawing method for drawing rectangles.
     * 
     * @param obj       The MmgObj to draw a rectangle for.
     * @see             MmgObj
     */
    public void DrawRect(MmgObj obj) {
        DrawRect(obj.GetPosition().GetX(), obj.GetPosition().GetY(), obj.GetWidth(), obj.GetHeight());
    }
    
    /**
     * Drawing method for drawing rectangles.
     * 
     * @param obj       The MmgObj to draw a rectangle for.
     * @param pos       The position to use when drawing the rectangle.
     */
    public void DrawRect(MmgObj obj, MmgVector2 pos) {
        DrawRect(pos.GetX(), pos.GetY(), obj.GetWidth(), obj.GetHeight());
    }    
    
    /**
     * Drawing method for drawing rectangles.
     * 
     * @param r         The MmgRect object to draw.
     */
    public void DrawRect(MmgRect r) {
        DrawRect(r.GetLeft(), r.GetTop(), r.GetWidth(), r.GetHeight());
    }
    
    /**
     * Drawing method for drawing rectangles.
     * 
     * @param x     The X axis offset.
     * @param y     The Y axis offset.
     * @param w     The width of the rectangle.
     * @param h     The height of the rectangle.
     */
    public void DrawRect(int x, int y, int w, int h) {
        pen.drawRect(x, y, w, h);
    }
    
    /**
     * Gets the lower level drawing class.
     * 
     * @return      A Graphics object. 
     */
    public Graphics GetSpriteBatch() {
        return pen;
    }

    /**
     * Sets the lower level drawing class.
     * 
     * @param sp    A Graphic object. 
     */
    public void SetSpriteBatch(Graphics sp) {
        pen = sp;
    }

    /**
     * Sets the lower level drawing class.
     * 
     * @param sp    A Graphic object. 
     */  
    public void SetGraphics(Graphics sp) {
        SetSpriteBatch(sp);
    }

    /**
     * Gets the lower level drawing class.
     * 
     * @return      A Graphics object. 
     */
    public Graphics GetGraphics() {
        return GetSpriteBatch();
    }
    
    /**
     * Sets the color of the drawing pen.
     * 
     * @param c     The color to set the pen to.
     */
    public void SetColor(Color c) {
        color = c;
    }
    
    /**
     * Gets the color of the drawing pen.
     * 
     * @return      The color to set the pen to.
     */
    public Color GetColor() {
        return color;
    }
    
    /**
     * Sets the color of this object and the lower level Java pen.
     * 
     * @param c     The color of the pen.
     */
    public void SetGraphicsColor(Color c) {
        pen.setColor(c);
    }
    
    /**
     * Gets the color of the lower level Java pen.
     * 
     * @return      The color of the pen.
     */
    public Color GetGraphicsColor() {
        return pen.getColor();
    }    
}