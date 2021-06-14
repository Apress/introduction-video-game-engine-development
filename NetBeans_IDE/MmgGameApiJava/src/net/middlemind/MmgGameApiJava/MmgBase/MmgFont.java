package net.middlemind.MmgGameApiJava.MmgBase;

import java.awt.*;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;

/**
 * Class that wraps the lower level font class. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgFont extends MmgObj {
    
    /**
     * Font of this class.
     */
    private Font font;

    /**
     * The text this font class is going to display.
     */
    private String text;
    
    /**
     * A render context for calculating font dimensions.
     */
    private final FontRenderContext frc;

    /**
     * The integer value of the current font size.
     * This value gets set only when SetFontSize is called, this is extra info not used in font rendering on the Java version of the API.
     */
    private int fontSize = -1;
        
    /**
     * An enumeration that is used to describe the style of a particular font.
     */
    public enum FontType {
        NORMAL(0),
        BOLD(1),
        ITALIC(2),
        NONE(-1);
        
        private final int val;

        private FontType(int Val) {
            this.val = Val;
        }        
    };    
    
    /**
     * The style of the font.
     * This value gets set only when SetFontSize is called, this is extra info not used in font rendering on the Java version of the API.
     */
    private FontType fontType = FontType.NONE;    
    
    /**
     * Constructor for this class.
     */
    public MmgFont() {
        super();
        frc = new FontRenderContext(null, true, true);
        text = "";
        font = null;
        SetWidth(0);
        SetHeight(0);
    }

   /**
     * Constructor that sets the lower level attributes based on the given
     * argument.
     *
     * @param obj   The MmgObj to use.
     */
    public MmgFont(MmgObj obj) {
        super(obj);
        frc = new FontRenderContext(null, true, true);
        text = "";
        font = null;
        SetWidth(0);
        SetHeight(0);
    }    
    
    /**
     * Constructor that sets the lower level font class.
     *
     * @param tf        Font to use for text drawing.
     * @param fontType  The font type of the given font argument.
     */
    public MmgFont(Font tf, FontType fontType) {
        super();
        frc = new FontRenderContext(null, true, true);
        text = "";
        font = tf;
        SetFontType(fontType);
        SetWidth(0);
        SetHeight(0);
    }

    /**
     * Constructor that sets the lower level font class and descriptive class fields.
     * 
     * @param tf        Font to use for text drawing.
     * @param fontSize  The size of the given font argument.
     * @param fontType  The font type of the given font argument.
     */
    public MmgFont(Font tf, int fontSize, FontType fontType) {
        super();
        frc = new FontRenderContext(null, true, true);
        text = "";
        font = tf;
        SetFontType(fontType);
        SetFontSize(fontSize);
        SetWidth(0);
        SetHeight(0);    
    }    
    
    /**
     * Constructor that sets attributes based on the given argument.
     *
     * @param obj   The MmgFont class instance to use to set all the class fields.
     */
    public MmgFont(MmgFont obj) {
        super();
        frc = new FontRenderContext(null, true, true);
        SetFont(obj.GetFont());
        SetFontType(obj.GetFontType());
        SetFontSize(obj.GetFontSize());        
        SetFont(obj.GetFont());
        SetText(obj.GetText());

        if (obj.GetPosition() == null) {
            SetPosition(obj.GetPosition());
        } else {
            SetPosition(obj.GetPosition().Clone());
        }
        
        SetIsVisible(obj.GetIsVisible());

        if (obj.GetMmgColor() == null) {
            SetMmgColor(obj.GetMmgColor());
        } else {
            SetMmgColor(obj.GetMmgColor().Clone());
        } 
        
        SetHeight(obj.GetHeight());
        SetWidth(obj.GetWidth());
    }

    /**
     * Constructor that sets the font, text, position, and color.
     *
     * @param sf    Low level font class.
     * @param txt   Text to draw.
     * @param pos   Position to draw the text.
     * @param cl    Color to use to draw the text.
     */
    public MmgFont(Font sf, String txt, MmgVector2 pos, MmgColor cl) {
        super();        
        frc = new FontRenderContext(null, true, true);
        SetFont(sf);
        SetText(txt);
        SetPosition(pos);
        SetIsVisible(true);
        SetMmgColor(cl);
    }

    /**
     * Constructor that sets the font, text, position in X, Y, and color.
     *
     * @param sf    Low level font class.
     * @param txt   Text to draw.
     * @param x     Position, on the X axis.
     * @param y     Position, on the Y axis.
     * @param cl    Color to use to draw the text.
     */
    public MmgFont(Font sf, String txt, int x, int y, MmgColor cl) {
        super();
        frc = new FontRenderContext(null, true, true);
        SetFont(sf);
        SetText(txt);
        SetPosition(new MmgVector2(x, y));
        SetIsVisible(true);
        SetMmgColor(cl);
    }

    /**
     * Creates a basic clone of this class.
     *
     * @return      A clone of this class.
     */
    @Override
    public MmgObj Clone() {
        return (MmgObj) new MmgFont(this);
    }

    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    @Override
    public MmgFont CloneTyped() {
        return new MmgFont(this);
    }    
    
    /**
     * Gets the text for this object.
     *
     * @return      The text for this object.
     */
    public String GetText() {
        return text;
    }

    /**
     * Sets the text for this object. 
     * Recalculates the drawing bounds of this
     * object.
     *
     * @param s     The text for this object.
     */
    public void SetText(String s) {
        if (s != null) {
            text = s;
            if ("".equals(text) == false) {
                Rectangle2D r = font.getStringBounds(text, frc);
                Rectangle r2 = r.getBounds();
                SetWidth((int) r2.width);
                SetHeight((int) r2.height);
            } else {
                SetWidth(0);
                SetHeight(0);
            }
        } else {
            text = null;
            SetWidth(0);
            SetHeight(0);
        }
    }

    /**
     * Gets the font type for this MmgFont instance.
     * In the Java API this is only used as extra information and isn't directly tied to font rendering.
     * 
     * @return      The font type for this MmgFont instance.
     */
    public FontType GetFontType() {
        return fontType;
    }
    
    /**
     * Sets the font type for this MmgFont instance.
     * In the Java API this is only used as extra information and isn't directly tied to font rendering.
     * 
     * @param ft    The font type for this MmgFont instance.
     */
    public void SetFontType(FontType ft) {
        fontType = ft;
    }
    
    /**
     * Sets the size of the font.
     *
     * @param sz    The size of the font.
     */
    public void SetFontSize(int sz) {
        if(sz > 0 && sz <= MmgFontData.MAX_FONT_SIZE) {
            fontSize = sz;
            font = font.deriveFont((float) sz);
        } else {
            MmgHelper.wr("MmgFont: Error size must be greater than 0 and less than " + MmgFontData.MAX_FONT_SIZE);
        }
    }

    /**
     * Gets the size of the font.
     *
     * @return      The size of the font.
     */
    public int GetFontSize() {
        return (int) font.getSize();
    }

    /**
     * Sets the sprite font, or font to use to draw text.
     *
     * @param tf    The font to use for this MmgFont object.
     */
    public void SetFont(Font tf) {
        font = tf;
    }
    
    /**
     * Gets the font object used to draw text.
     *
     * @return      The font used to draw text.
     */
    public Font GetFont() {
        return font;
    }
    
    /**
     * The base drawing method used to draw this object.
     *
     * @param p     The MmgPen used to draw this object.
     * @see         MmgPen
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (isVisible == true) {            
            p.DrawText(this);
        }
    }

    /**
     * A class method that tests for equality based on the font and text of the
     * comparison object.
     * 
     * @param obj     The MmgFont object to compare
     * @return      A boolean indicating if the object instance is equal to the argument object instance. 
     */
    public boolean ApiEquals(MmgFont obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
           
        /*
        if(!(super.Equals((MmgObj)obj))) {
           MmgHelper.wr("MmgFont: MmgObj is not equals!"); 
        }
        
        if(!(((obj.GetFont() == null && GetFont() == null) || (obj.GetFont() != null && GetFont() != null && obj.GetFont().equals(GetFont()))))) {
           MmgHelper.wr("MmgFont: Font is not equals!");
        }
        
        if(!(((obj.GetText() == null && GetText() == null) || (obj.GetText() != null && GetText() != null && obj.GetText().equals(GetText()))))) {
           MmgHelper.wr("MmgFont: Text is not equals!");
        }
        */
                
        boolean ret = false;
        if (
            super.ApiEquals((MmgObj)obj)
            && ((obj.GetFont() == null && GetFont() == null) || (obj.GetFont() != null && GetFont() != null && obj.GetFont().equals(GetFont()))) 
            && ((obj.GetText() == null && GetText() == null) || (obj.GetText() != null && GetText() != null && obj.GetText().equals(GetText())))
        ) {
            ret = true;
        }
        return ret;
    }
}