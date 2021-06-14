package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.RenderingHints;
import java.awt.Transparency;
import java.awt.geom.AffineTransform;
import java.awt.image.BufferedImage;

/**
 * A class that provides help with MmgBmp scaling.
 * Created by Middlemind Games 10/12/2016
 * 
 * @author Victor G. Brusca
 */
public class MmgBmpScaler {
    
    /**
     * A static class method that scales an MmgBmp object to the size of the game screen.
     * 
     * @param subj      The MmgBmp object to scale to the size of the screen.
     * @param alpha     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @return          A new MmgBmp object instance scaled to the size of the screen.
     */
    public static MmgBmp ScaleMmgBmpToGameScreen(MmgBmp subj, boolean alpha) {
        int w = subj.GetWidth();
        int h = subj.GetHeight();        
        int nw = MmgScreenData.GetGameWidth();
        int nh = MmgScreenData.GetGameHeight();
        Image img = subj.GetImage();

        BufferedImage bg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(nw, nh, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
        Graphics2D g = (Graphics2D) bg.getGraphics();

        if (MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        g.drawImage(img, 0, 0, nw, nh, 0, 0, w, h, null);
        return new MmgBmp(bg);
    }         
    
    /**
     * A static class method that scales an MmgBmp object to the specified size.
     * 
     * @param subj      The MmgBmp object to scale to the specified size.
     * @param newSize   The size to scale the MmgBmp object to, specified by an MmgVector2 object instance.
     * @param alpha     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @return          A new MmgBmp object instance scaled to the size of the screen.
     */
    public static MmgBmp ScaleMmgBmp(MmgBmp subj, MmgVector2 newSize, boolean alpha) {
        int w = subj.GetWidth();
        int h = subj.GetHeight();        
        int nw = newSize.GetX();
        int nh = newSize.GetY();
        Image img = subj.GetImage();

        BufferedImage bg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(nw, nh, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
        Graphics2D g = (Graphics2D) bg.getGraphics();

        if (MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        g.drawImage(img, 0, 0, nw, nh, 0, 0, w, h, null);
        return new MmgBmp(bg);
    }
    
    /**
     * A static class method that scales an MmgBmp object to the screen's X scaling.
     * 
     * @param subj                      The MmgBmp object to scale to the specified size.
     * @param useScreenDataScaleX       The scaling size of the screen in the X direction.
     * @param alpha                     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @return                          A new MmgBmp object instance scaled to the size of the screen's X coordinate scale.
     */
    public static MmgBmp ScaleMmgBmp(MmgBmp subj, boolean useScreenDataScaleX, boolean alpha) {
        int w = subj.GetWidth();
        int h = subj.GetHeight();
        int nw = 0;
        int nh = 0;
        
        if(useScreenDataScaleX) {
            nw = (int) (w * MmgScreenData.GetScaleX());
            nh = (int) (h * MmgScreenData.GetScaleX());
        }else {
            nw = (int) (w * MmgScreenData.GetScaleY());
            nh = (int) (h * MmgScreenData.GetScaleY());            
        }
        
        Image img = subj.GetImage();

        BufferedImage bg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(nw, nh, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
        Graphics2D g = (Graphics2D) bg.getGraphics();

        if (MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        g.drawImage(img, 0, 0, nw, nh, 0, 0, w, h, null);
        return new MmgBmp(bg);
    }    
    
    /**
     * A static class method that scales an MmgBmp object to the provided scale value.
     * 
     * @param subj      The MmgBmp object to scale to the specified size.
     * @param scale     The value to scale the MmgBmp to.
     * @param alpha     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @return          A new MmgBmp object instance scaled to the size of the provided scale value.
     */
    public static MmgBmp ScaleMmgBmp(MmgBmp subj, double scale, boolean alpha) {
        int w = subj.GetWidth();
        int h = subj.GetHeight();
        int nw = (int) (w * scale);
        int nh = (int) (h * scale);
        Image img = subj.GetImage();

        BufferedImage bg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(nw, nh, alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
        Graphics2D g = (Graphics2D) bg.getGraphics();

        if (MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        g.drawImage(img, 0, 0, nw, nh, 0, 0, w, h, null);
        return new MmgBmp(bg);
    }

    /**
     * A static class method that creates a new rotated image from a subject image and returns in.
     * 
     * @param subj      The MmgBmp object to rotate to the specified angle.
     * @param angle     The angle to rotate the image to.
     * @param alpha     A boolean flag indicating if transparency should be taken into consideration when creating new images.
     * @return          A new MmgBmp rotated to the specified angle.
     */
    public static MmgBmp RotateMmgBmp(MmgBmp subj, int angle, boolean alpha) {
        int w = subj.GetWidth();
        int h = subj.GetHeight();
        Image img = subj.GetImage();

        BufferedImage bg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(w, h, alpha ? Transparency.BITMASK : Transparency.OPAQUE);
        Graphics2D g = (Graphics2D) bg.getGraphics();

        if (MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        AffineTransform at = new AffineTransform();
        at.rotate(Math.toRadians(angle), (w / 2), (h / 2));
        g.drawImage(img, at, null);
        g.dispose();

        MmgBmp r = new MmgBmp(bg);
        r.SetScaling(MmgVector2.GetUnitVec());
        r.SetPosition(MmgVector2.GetOriginVec());
        r.SetOrigin(MmgVector2.GetOriginVec());
        r.SetMmgColor(null);
        return r;
    }
}