package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.*;

/**
 * Class that wraps the lower level bitmap object.
 * Created by Middlemind Games 08/29/2016
 * 
 * @author Victor G. Brusca
 */
public class MmgBmp extends MmgObj {
    
    /**
     * Drawing mode to determine the best way to handle drawing a bitmap.
     */
    public enum MmgBmpDrawMode {
        DRAW_BMP_FULL,
        DRAW_BMP_BASIC_CACHE,
        DRAW_BMP_BASIC
    };

    /**
     * The initial value to use for bitmap IDs in unique id mode.
     */
    private static int ID_SRC = 0;

    /**
     * The origin of this object.
     */
    private MmgVector2 origin;

    /**
     * The scaling to apply to this object, if defined.
     */
    private MmgVector2 scaling;

    /**
     * The source drawing rectangle if defined.
     */
    private MmgRect srcRect;

    /**
     * The destination drawing rectangle if defined.
     */
    private MmgRect dstRect;

    /**
     * The image representing this object, if defined.
     */
    private Image b;

    /**
     * The rotation to apply to this object, if defined.
     */
    private float rotation;

    /**
     * The string representation of this objects id.
     */
    private String idStr;

    /**
     * The integer representation of this objects id.
     */
    private int id;
    
    /**
     * The strategy to use when drawing bitmaps.
     */
    public MmgBmpDrawMode DRAW_MODE = MmgBmpDrawMode.DRAW_BMP_BASIC;

    /**
     * Generic constructor.
     */
    public MmgBmp() {
        origin = new MmgVector2(0, 0);
        scaling = new MmgVector2(1, 1);
        srcRect = MmgRect.GetUnitRect();
        dstRect = MmgRect.GetUnitRect();
        b = null;
        rotation = 0f;
        SetBmpId();
    }

    /**
     * Construct from a previous instance of MmgObj.
     *
     * @param obj       The object to create this class from.
     */
    public MmgBmp(MmgObj obj) {
        super(obj);
        origin = new MmgVector2(0, 0);
        scaling = new MmgVector2(1, 1);
        srcRect = MmgRect.GetUnitRect();
        dstRect = MmgRect.GetUnitRect();
        b = null;
        rotation = 0f;
        SetBmpId();
    }

    /**
     * Construct from a previous instance of MmgBmp.
     *
     * @param obj       The object to create this class from.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgBmp(MmgBmp obj) {
        super();        
        SetRotation(obj.GetRotation());

        if (obj.GetOrigin() == null) {
            SetOrigin(obj.GetOrigin());
        } else {
            SetOrigin(obj.GetOrigin().Clone());
        }

        if (obj.GetSrcRect() == null) {
            SetSrcRect(obj.GetSrcRect());
        } else {
            SetSrcRect(obj.GetSrcRect().Clone());
        }

        if (obj.GetDstRect() == null) {
            SetDstRect(obj.GetDstRect());
        } else {
            SetDstRect(obj.GetDstRect().Clone());
        }

        SetTexture2D(obj.GetTexture2D());

        if (obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }

        if (obj.GetScaling() == null) {
            SetScaling(obj.GetScaling());
        } else {
            SetScaling(obj.GetScaling().Clone());
        }

        SetWidth(obj.GetUnscaledWidth());
        SetHeight(obj.GetUnscaledHeight());
        SetIsVisible(obj.GetIsVisible());

        if (obj.GetMmgColor() == null) {
            SetMmgColor(obj.GetMmgColor());
        } else {
            SetMmgColor(obj.GetMmgColor().Clone());
        }
        
        SetBmpId();
    }

    /**
     * Construct from a lower level Image objects.
     *
     * @param t     The object to create this instance from.
     * @see         Image
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgBmp(Image t) {
        super();
        SetRotation(0f);
        SetOrigin(MmgVector2.GetOriginVec());
        SetScaling(MmgVector2.GetUnitVec());
        MmgRect r = new MmgRect(MmgVector2.GetOriginVec(), t.getWidth(null), t.getHeight(null));
        SetSrcRect(r);
        SetDstRect(null);
        SetTexture2D(t);

        SetPosition(MmgVector2.GetOriginVec());
        SetWidth(b.getWidth(null));
        SetHeight(b.getHeight(null));
        SetIsVisible(true);
        SetMmgColor(null);
        SetBmpId();
    }

    /**
     * Construct this instance from a lower level image object and some
     * rendering hints.
     *
     * @param t             The lower level Image object to create this instance from.
     * @param Src           The source drawing rectangle.
     * @param Dst           The destination drawing rectangle.
     * @param Origin        The origin this image should be rotated from.
     * @param Scaling       The scaling values to use when drawing this image.
     * @param Rotation      The rotation values to use when drawing this image.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgBmp(Image t, MmgRect Src, MmgRect Dst, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) {
        super();
        SetRotation(Rotation);
        SetOrigin(Origin);
        SetScaling(Scaling);
        SetSrcRect(Src);
        SetDstRect(Dst);
        SetTexture2D(t);

        SetPosition(MmgVector2.GetOriginVec());
        SetWidth(b.getWidth(null));
        SetHeight(b.getHeight(null));
        SetIsVisible(true);
        SetMmgColor(null);
        SetBmpId();
    }

    /**
     * Construct this instance from a lower level image object and some
     * rendering hints.
     *
     * @param t             The lower level Image object to create this instance from.
     * @param Position      The position this object should be drawn at.
     * @param Origin        The origin this image should be rotated from.
     * @param Scaling       The scaling values to use when drawing this image.
     * @param Rotation      The rotation values to use when drawing this image.
     */
    @SuppressWarnings("OverridableMethodCallInConstructor")
    public MmgBmp(Image t, MmgVector2 Position, MmgVector2 Origin, MmgVector2 Scaling, float Rotation) {
        super();
        SetRotation(Rotation);
        SetOrigin(Origin);
        SetScaling(Scaling);
        MmgRect r = new MmgRect(Position, t.getWidth(null), t.getHeight(null));
        SetSrcRect(r);
        SetDstRect(null);
        SetTexture2D(t);

        SetPosition(Position);
        SetWidth(b.getWidth(null));
        SetHeight(b.getHeight(null));
        SetIsVisible(true);
        SetMmgColor(null);
        SetBmpId();
    }

    /**
     * Returns an id string, used in image caching, based on rotation.
     *
     * @param rotation      The rotation value to use in id string creation.
     * @return              A new id string.
     * @see                 MmgPen
     */
    public String GetIdStr(float rotation) {
        return (idStr + "_" + rotation);
    }

    /**
     * Returns an id string, used in image caching, based on scaling.
     *
     * @param scaling       The scaling value to use in id string creation.
     * @return              A new id string.
     * @see                 MmgPen
     */
    public String GetIdStr(MmgVector2 scaling) {
        return (idStr + "_" + scaling.GetXFloat() + "x" + scaling.GetYFloat());
    }

    /**
     * Returns an id string taking the rotation and scaling into consideration.
     * Used in image caching as a unique id to store a local copy of the image.
     *
     * @param rotation      The rotation value to use in id string creation.
     * @param scaling       The scaling value to use in id string creation.
     * @return              A new id string.
     */
    public String GetIdStr(float rotation, MmgVector2 scaling) {
        return (idStr + "_" + rotation + "_" + scaling.GetXFloat() + "x" + scaling.GetYFloat());
    }

    /**
     * Id helper method, takes rotation into account when making an id.
     *
     * @param rotation      The rotation of the bitmap.
     * @return              The unique id of the bitmap.
     */
    public int GetId(float rotation) {
        return Integer.parseInt((id + "0" + (int) (rotation)));
    }

    /**
     * Id helper method, takes scaling into account when making an id.
     *
     * @param scaling       The scaling to apply to the object.
     * @return              The unique id of the bitmap.
     */
    public int GetId(MmgVector2 scaling) {
        return Integer.parseInt((idStr + "0" + (int) (scaling.GetXFloat() * 10) + "0" + (int) (scaling.GetYFloat() * 10)));
    }

    /**
     * If helper method, takes rotation, and scaling into account when making an
     * id.
     *
     * @param rotation      The rotation of the bitmap.
     * @param scaling       The scaling of the bitmap.
     * @return              The unique id of the bitmap.
     */
    public int GetId(float rotation, MmgVector2 scaling) {
        return Integer.parseInt((idStr + "0" + (int) (rotation) + "0" + (int) (scaling.GetXFloat() * 10) + "0" + (int) (scaling.GetYFloat() * 10)));
    }

    /**
     * Get the unique id of the bitmap in string form.
     *
     * @return      The string form of the unique id.
     */
    public String GetBmpIdStr() {
        return idStr;
    }

    /**
     * Sets the string form of the id.
     *
     * @param IdStr     A unique id string.
     */
    public void SetBmpIdStr(String IdStr) {
        idStr = IdStr;
    }

    /**
     * Gets the string form of the id.
     *
     * @return      A unique id integer.
     */
    public int GetBmpId() {
        return id;
    }

    /**
     * Sets the unique id integer and string representations using a common method.
     */
    private void SetBmpId() {
        id = MmgBmp.ID_SRC;
        idStr = (id + "");
        MmgBmp.ID_SRC++;
    }

    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgBmp(this);
    }

    /**
     * Creates a typed clone of this class.
     *
     * @return      A typed clone of this class.
     */
    @Override
    public MmgBmp CloneTyped() {
        return new MmgBmp(this);
    }    
    
    /**
     * Returns the image of this bitmap.
     *
     * @return      This bitmaps image.
     */
    public Image GetTexture2D() {
        return b;
    }

    /**
     * Sets the image of this bitmap.
     *
     * @param d     The image to set for this bitmap.
     */
    public void SetTexture2D(Image d) {
        b = d;
    }

    /**
     * Gets the image of this bitmap. Same as GetTexture2D.
     *
     * @return      The image of this bitmap.
     */
    public Image GetImage() {
        return GetTexture2D();
    }

    /**
     * Sets the image of this bitmap. Same as SetTexture2D.
     *
     * @param d     The image to set for this bitmap.
     */
    public void SetImage(Image d) {
        SetTexture2D(d);
    }

    /**
     * Gets the source drawing rectangle of this bitmap. Only used by drawing
     * methods in the MmgPen class that supports, source, or source, destination
     * drawing methods.
     *
     * @return      The source drawing rectangle.
     * @see         MmgPen
     */
    public MmgRect GetSrcRect() {
        return srcRect;
    }

    /**
     * Sets the source drawing rectangle. Only used by drawing methods in the
     * MmgPen class that supports, source, or source, destination drawing
     * methods.
     *
     * @param r     The source drawing rectangle.
     * @see         MmgPen
     */
    public void SetSrcRect(MmgRect r) {
        srcRect = r;
    }

    /**
     * Gets the destination drawing rectangle.
     *
     * @return      The destination drawing rectangle.
     */
    public MmgRect GetDstRect() {
        return dstRect;
    }

    /**
     * Sets the destination drawing rectangle.
     *
     * @param r     The destination drawing rectangle.
     */
    public void SetDstRect(MmgRect r) {
        dstRect = r;
    }

    /**
     * Gets the rotation of the bitmap.
     *
     * @return      The rotation of the bitmap.
     */
    public float GetRotation() {
        return rotation;
    }

    /**
     * Sets the rotation of the bitmap.
     *
     * @param r     The rotation of the bitmap.
     */
    public void SetRotation(float r) {
        rotation = r;
    }

    /**
     * Gets the origin used in drawing the bitmap.
     *
     * @return      The drawing origin of the bitmap.
     */
    public MmgVector2 GetOrigin() {
        return origin;
    }

    /**
     * Sets the origin used in drawing the bitmap.
     *
     * @param v     The drawing origin of the bitmap.
     */
    public void SetOrigin(MmgVector2 v) {
        origin = v;
    }

    /**
     * Gets the scaling value used to scale the bitmap.
     *
     * @return      The drawing scaling value.
     */
    public MmgVector2 GetScaling() {
        return scaling;
    }

    /**
     * Sets the scaling value used to scale the bitmap.
     *
     * @param v     The drawing scaling value.
     */
    public void SetScaling(MmgVector2 v) {
        scaling = v;
    }

    /**
     * Gets the scaled height of this bitmap.
     *
     * @return      The scaled height of this bitmap.
     */
    public double GetScaledHeight() {
        if (GetScaling() == null) {
            return super.GetHeight();
        } else {
            return ((double) super.GetHeight() * GetScaling().GetXDouble());
        }
    }

    /**
     * Gets the unscaled, original height of the bitmap.
     *
     * @return      The unscaled, original height of the bitmap.
     */
    public int GetUnscaledHeight() {
        return super.GetHeight();
    }

    /**
     * Gets the scaled height of the bitmap.
     *
     * @return      The scaled height of the bitmap.
     */
    @Override
    public int GetHeight() {
        return (int) GetScaledHeight();
    }

    /**
     * Gets the scaled height of the bitmap in float form.
     *
     * @return      The scaled height of the bitmap.
     */
    public float GetHeightFloat() {
        return (float) GetScaledHeight();
    }

    /**
     * Gets the un-scaled, original width of the bitmap.
     *
     * @return      The un-scaled, original width of the bitmap.
     */
    public int GetUnscaledWidth() {
        return super.GetWidth();
    }

    /**
     * Gets the scaled width of the bitmap.
     *
     * @return      The scaled width of the bitmap.
     */
    public double GetScaledWidth() {
        if (GetScaling() == null) {
            return super.GetWidth();
        } else {
            return ((double) super.GetWidth() * GetScaling().GetYDouble());
        }
    }

    /**
     * Gets the scaled width of the bitmap.
     *
     * @return      The scaled width of the bitmap.
     */
    @Override
    public int GetWidth() {
        return (int) GetScaledWidth();
    }

    /**
     * Gets the scaled width of the bitmap in float form.
     *
     * @return      The scaled width of the bitmap.
     */
    public float GetWidthFloat() {
        return (float) GetScaledWidth();
    }

    /**
     * The base drawing method for the bitmap object.
     *
     * @param p     The MmgPen used to draw this bitmap.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {
            if (DRAW_MODE == MmgBmpDrawMode.DRAW_BMP_FULL) {
                p.DrawBmp(this);
            } else if (DRAW_MODE == MmgBmpDrawMode.DRAW_BMP_BASIC) {
                p.DrawBmpBasic(this);
            } else if (DRAW_MODE == MmgBmpDrawMode.DRAW_BMP_BASIC_CACHE) {
                p.DrawBmpFromCache(this);
            }
        }
    }
        
    /**
     * A method for testing equality with other MmgBmp objects.
     * Takes into account the MmgObj Equals method if nothing different is
     * found in the MmgBmp comparison.
     * 
     * @param obj     An MmgBmp object to check equality with.
     * @return      Returns true if the determination is made that the two objects are the same, false otherwise.
     */
    public boolean ApiEquals(MmgBmp obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
        
        /*
        if(!(super.Equals((MmgObj)obj))) {
            MmgHelper.wr("MmgBmp: MmgObj is not equals!");
        }
        */
        
        boolean ret = false;
        if(
            super.ApiEquals((MmgObj)obj)
            && ((obj.GetDstRect() == null && GetDstRect() == null) || (obj.GetDstRect() != null && GetDstRect() != null && obj.GetDstRect().ApiEquals(GetDstRect())))
            && obj.GetHeight() == GetHeight()
            && obj.GetHeightFloat() == GetHeightFloat()
            && ((obj.GetImage() == null && GetImage() == null) || (obj.GetImage() != null && GetImage() != null && obj.GetImage().equals(GetImage())))
            && ((obj.GetOrigin() == null && GetOrigin() == null) || (obj.GetOrigin() != null && GetOrigin() != null && obj.GetOrigin().ApiEquals(GetOrigin())))
            && obj.GetRotation() == GetRotation()
            && obj.GetScaledHeight() == GetScaledHeight()
            && obj.GetScaledWidth() == GetScaledWidth()
            && ((obj.GetScaling() == null && GetScaling() == null) || (obj.GetScaling() != null && GetScaling() != null && obj.GetScaling().ApiEquals(GetScaling())))
            && ((obj.GetSrcRect() == null && GetSrcRect() == null) || (obj.GetSrcRect() != null && GetSrcRect() != null && obj.GetSrcRect().ApiEquals(GetSrcRect())))
            && ((obj.GetTexture2D() == null && GetTexture2D() == null) || (obj.GetTexture2D() != null && GetTexture2D() != null && obj.GetTexture2D().equals(GetTexture2D())))
            && obj.GetUnscaledHeight() == GetUnscaledHeight()
            && obj.GetUnscaledWidth() == GetUnscaledWidth()
            && obj.GetWidth() == GetWidth()
            && obj.GetWidthFloat() == GetWidthFloat()
            && obj.DRAW_MODE == DRAW_MODE
        ) {
            ret = true;
        }
        return ret;
    }
}