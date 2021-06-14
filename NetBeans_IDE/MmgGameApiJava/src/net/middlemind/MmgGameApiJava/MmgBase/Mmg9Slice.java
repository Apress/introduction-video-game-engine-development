package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.RenderingHints;
import java.awt.Transparency;
import java.awt.image.BufferedImage;

/**
 * A class that provides 9 slice bitmap scaling support. 
 * Created by Middlemind Games 12/01/2016
 *
 * @author Victor G. Brusca
 */
@SuppressWarnings("OverridableMethodCallInConstructor")
public class Mmg9Slice extends MmgObj {
    
    /**
     * The offset to use when slicing the source image.
     */
    private int offset;
    
    /**
     * The source image to slice and expand onto the destination image.
     */
    private MmgBmp src;
    
    /**
     * The destination image the receives the split and expanded source image.
     */
    private MmgBmp dest;
    
    /**
     * Default constructor that takes a source MmgBmp to slice an offset and dimensions for the
     * expanded source bitmap.
     * 
     * @param Offset    The offset to use when slicing the source MmgBmp object.
     * @param Src       The source MmgBmp object that will be sliced and expanded.
     * @param w         The desired width of the resulting expanded source MmgBmp object.
     * @param h         The desired height of the resulting expanded source MmgBmp object.
     */
    public Mmg9Slice(int Offset, MmgBmp Src, int w, int h) {
        super();
        SetOffset(Offset);
        SetSrc(Src);
        SetWidth(w);
        SetHeight(h);
        DrawDest();        
        SetPosition(MmgVector2.GetOriginVec());
        SetIsVisible(true);        
    }

    /**
     * Mmg9Slice constructor that is similar to the default constructor except it also takes position
     * information used to position the resulting images.
     * 
     * @param Offset    The offset to use when slicing the source MmgBmp object.
     * @param Src       The source MmgBmp object that will be sliced and expanded.
     * @param w         The desired width of the resulting expanded source MmgBmp object.
     * @param h         The desired height of the resulting expanded source MmgBmp object.
     * @param Pos       The desired position to set for the expanded MmgBmp object.
     */
    public Mmg9Slice(int Offset, MmgBmp Src, int w, int h, MmgVector2 Pos) {
        super();        
        SetOffset(Offset);
        SetSrc(Src);
        SetWidth(w);
        SetHeight(h);        
        DrawDest();
        SetPosition(Pos);
        SetIsVisible(true);
    }

    /**
     * Mmg9Slice that creates a clean instance from an existing Mmg9Slice object.
     * 
     * @param obj     The Mmg9Slice object to create a clean instance from.
     */
    public Mmg9Slice(Mmg9Slice obj) {
        super();        
        SetOffset(obj.GetOffset());
        
        if(obj.GetSrc() == null) {
            SetSrc(obj.GetSrc());
        } else {    
            SetSrc(obj.GetSrc().CloneTyped());
        }
        
        SetWidth(obj.GetWidth());
        SetHeight(obj.GetHeight());

        DrawDest();
        
        if(obj.GetDest() == null) {
            SetDest(obj.GetDest());
        } else {    
            SetDest(obj.GetDest().CloneTyped());
        }        
        
        if(obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }
        
        SetIsVisible(obj.GetIsVisible());
    }

    /**
     * Sets the offset used when slicing up the source MmgBmp object.
     * DrawDest must be called again to redo any slicing that was done by the constructor.
     * 
     * @param i     The offset to use in the 9 slice process.
     */
    public void SetOffset(int i) {
        offset = i;
    }

    /**
     * The offset used in the 9 slice process.
     * 
     * @return      The offset used in the 9 slice process.
     */
    public int GetOffset() {
        return offset;
    }

    /**
     * The source MmgBmp object used in the 9 slice process and expanded on to the destination MmgBmp.
     * The DrawDest method must be called again to redo any slicing that was done by the constructor.
     * 
     * @param b     The MmgBmp to use as the source object in the 9 slice process.
     */
    public void SetSrc(MmgBmp b) {
        src = b;
    }

    /**
     * The source MmgBmp object used in the 9 slice process.
     * 
     * @return      The source MmgBmp object used in the 9 slice process.
     */
    public MmgBmp GetSrc() {
        return src;
    }

    /**
     * Sets the destination MmgBmp object. This object is normally created by the constructor
     * but you can override that image and set it directly. Position information may need to
     * be updated if you are setting this directly.
     * 
     * @param b     The MmgBmp object to use as the 9 slice destination, i.e. resulting drawable object.
     */
    public void SetDest(MmgBmp b) {
        dest = b;
    }

    /**
     * Returns the destination object created from slicing the source MmgBmp object and expanding it
     * onto the destination object.
     * 
     * @return      The MmgBmp object used as the 9 slice destination, i.e. resulting drawable object.
     */
    public MmgBmp GetDest() {
        return dest;
    }

    /**
     * Slices the source MmgBmp object and expands it onto the desired sized destination MmgBmp object.
     */
    public void DrawDest() {
        boolean alpha = true;
        MmgBmp b = GetSrc();
        Image img = b.GetImage();
        BufferedImage bg = MmgScreenData.GRAPHICS_CONFIG.createCompatibleImage(GetWidth(), GetHeight(), alpha ? Transparency.TRANSLUCENT : Transparency.OPAQUE);
        Graphics2D g = (Graphics2D) bg.getGraphics();

        if (MmgPen.ADV_RENDER_HINTS == true) {
            g.setRenderingHint(RenderingHints.KEY_INTERPOLATION, RenderingHints.VALUE_INTERPOLATION_BILINEAR);
            g.setRenderingHint(RenderingHints.KEY_RENDERING, RenderingHints.VALUE_RENDER_QUALITY);
            g.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
        }

        int fs = offset;

        //TOP
        //draw top left
        g.drawImage(img, 0, 0, fs, fs, 0, 0, fs, fs, null);

        //draw scaled top center
        g.drawImage(img, fs, 0, GetWidth() - fs, fs, fs, 0, b.GetWidth() - fs, fs, null);

        //draw top right
        g.drawImage(img, GetWidth() - fs, 0, GetWidth(), fs, b.GetWidth() - fs, 0, b.GetWidth(), fs, null);

        //MIDDLE
        //draw middle left
        g.drawImage(img, 0, fs, fs, GetHeight() - fs, 0, fs, fs, b.GetHeight() - fs, null);

        //draw middle center
        g.drawImage(img, fs, fs, GetWidth() - fs, GetHeight() - fs, fs, fs, b.GetWidth() - fs, b.GetHeight() - fs, null);

        //draw middle right
        g.drawImage(img, GetWidth() - fs, fs, GetWidth(), GetHeight() - fs, b.GetWidth() - fs, fs, b.GetWidth(), b.GetHeight() - fs, null);

        //BOTTOM
        //draw bottom left
        g.drawImage(img, 0, GetHeight() - fs, fs, GetHeight(), 0, b.GetHeight() - fs, fs, b.GetHeight(), null);

        //draw scaled bottom center
        g.drawImage(img, fs, GetHeight() - fs, GetWidth() - fs, GetHeight(), fs, b.GetHeight() - fs, b.GetWidth() - fs, b.GetHeight(), null);

        //draw bottom right
        g.drawImage(img, GetWidth() - fs, GetHeight() - fs, GetWidth(), GetHeight(), b.GetWidth() - fs, b.GetHeight() - fs, b.GetWidth(), b.GetHeight(), null);

        dest = new MmgBmp(bg);
    }

    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new Mmg9Slice(this);
    }

    /**
     * Creates a typed clone of this class.
     *
     * @return      A typed clone of this class.
     */
    @Override
    public Mmg9Slice CloneTyped() {
        return new Mmg9Slice(this);
    }
    
    /**
     * Gets the MmgColor of the destination object.
     * 
     * @return      The MmgColor of the destination object.
     */
    @Override
    public MmgColor GetMmgColor() {
        return dest.GetMmgColor();
    }
    
    /**
     * Sets the MmgColor of the destination object.
     * 
     * @param c     The MmgColor of the destination object.
     */
    @Override
    public void SetMmgColor(MmgColor c) {
        dest.SetMmgColor(c);
    }    
    
    /**
     * The base drawing method for this object.
     *
     * @param p     The MmgPen used to draw this object.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            p.DrawBmp(dest, GetPosition());
        }
    }

    /**
     * Tests if this object is equal to another Mmg9Slice object.
     * 
     * @param obj     An Mmg9Slice object instance to compare to.
     * @return      Returns true if the objects are considered equal and false otherwise.
     */
    public boolean ApiEquals(Mmg9Slice obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
            MmgHelper.wr("Mmg9Slice MmgObj is not equals!");
        }
        
        if(!(GetOffset() == obj.GetOffset())) {
            MmgHelper.wr("Mmg9Slice Offset is not equals!");            
        }
        
        if(!(((obj.GetSrc() == null && GetSrc() == null) || (obj.GetSrc() != null && GetSrc() != null && obj.GetSrc().Equals(GetSrc()))))) {
            MmgHelper.wr("Mmg9Slice Src is not equals!");                        
        }
        
        if(!(((obj.GetDest() == null && GetDest() == null) || (obj.GetDest() != null && GetDest() != null && obj.GetDest().Equals(GetDest()))))) {
            MmgHelper.wr("Mmg9Slice Dst is not equals!");                                    
        }
        */
        
        boolean ret = false;
        if (
            super.ApiEquals((MmgObj)obj)
            && GetOffset() == obj.GetOffset() 
            && ((obj.GetSrc() == null && GetSrc() == null) || (obj.GetSrc() != null && GetSrc() != null && obj.GetSrc().ApiEquals(GetSrc())))
            && ((obj.GetDest() == null && GetDest() == null) || (obj.GetDest() != null && GetDest() != null && obj.GetDest().ApiEquals(GetDest())))
        ) {
            ret = true;
        }
        return ret;
    }
}