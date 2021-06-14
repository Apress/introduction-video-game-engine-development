using System;
using Microsoft.Xna.Framework.Graphics;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgFont;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that wraps the MmgFont class and makes a label value pair.
    /// Created by Middlemind Games 08/29/2016
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgLabelValuePair : MmgObj
    {
        /// <summary>
        /// The MmgFont to use to draw the label.
        /// </summary>
        private MmgFont lbl;

        /// <summary>
        /// The MmgFont to use to draw the value.
        /// </summary>
        private MmgFont val;

        /// <summary>
        /// A padding value to use in positioning on the X axis.
        /// </summary>
        private int paddingX;

        /// <summary>
        /// A boolean flag that prevents the object from being reset with a call to the Reset method.
        /// </summary>
        private bool skipReset;

        /// <summary>
        /// A static class field that holds the default X axis padding.
        /// </summary>
        public static int DEFAULT_PADDING_X = MmgHelper.ScaleValue(8);

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        public MmgLabelValuePair() : base()
        {
            skipReset = true;
            SetLabel(new MmgFont(MmgFontData.GetFontBold(), FontType.BOLD));
            SetValue(new MmgFont(MmgFontData.GetFontNorm(), FontType.NORMAL));
            SetPaddingX(DEFAULT_PADDING_X);
            SetWidth(0);
            SetHeight(0);
            skipReset = false;
            Reset();
        }

        /// <summary>
        /// Constructor that sets the lower level font classes with Font class instances.
        /// </summary>
        /// <param name="fontLbl">The Font to use for the label.</param>
        /// <param name="fontVal">The Font to use for the value.</param>
        /// <param name="fontLblType">The font type of the label font argument.</param>
        /// <param name="fontValType">The font type of the value font argument.</param>
        public MmgLabelValuePair(SpriteFont fontLbl, SpriteFont fontVal, FontType fontLblType, FontType fontValType) : base()
        {
            skipReset = true;
            SetLabel(new MmgFont(fontLbl, fontLblType));
            SetValue(new MmgFont(fontVal, fontValType));
            SetPaddingX(DEFAULT_PADDING_X);
            SetWidth(0);
            SetHeight(0);
            skipReset = false;
            Reset();
        }

        /// <summary>
        /// Constructor that sets the lower level font classes with MmgFont class instances.
        /// </summary>
        /// <param name="fontLbl">The MmgFont to use for the label.</param>
        /// <param name="fontVal">The MmgFont to use for the value.</param>
        public MmgLabelValuePair(MmgFont fontLbl, MmgFont fontVal) : base()
        {
            skipReset = true;
            SetLabel(fontLbl);
            SetValue(fontVal);
            SetPaddingX(DEFAULT_PADDING_X);
            SetWidth(0);
            SetHeight(0);
            skipReset = false;
            Reset();
        }

        /// <summary>
        /// Constructor that sets the lower level attributes based on the given argument.
        /// </summary>
        /// <param name="obj">The MmgObj to use.</param>
        public MmgLabelValuePair(MmgObj obj) : base(obj)
        {
            skipReset = true;
            SetLabel(new MmgFont());
            SetValue(new MmgFont());
            SetPaddingX(DEFAULT_PADDING_X);
            SetWidth(0);
            SetHeight(0);
            skipReset = false;
            Reset();
        }

        /// <summary>
        /// Constructor that sets attributes based on the given argument.
        /// </summary>
        /// <param name="obj">The MmgLabelValuePair to use to initialize this class instance.</param>
        public MmgLabelValuePair(MmgLabelValuePair obj) : base()
        {
            skipReset = true;
            if (obj.GetLabel() == null)
            {
                SetLabel(obj.GetLabel());
            }
            else
            {
                SetLabel(obj.GetLabel().CloneTyped());
            }

            if (obj.GetValue() == null)
            {
                SetValue(obj.GetValue());
            }
            else
            {
                SetValue(obj.GetValue().CloneTyped());
            }

            SetPaddingX(obj.GetPaddingX());
            SetFontSize(obj.GetFontSize());

            if (obj.GetLabel() == null)
            {
                SetLabel(obj.GetLabel());
            }
            else
            {
                SetLabel(obj.GetLabel().CloneTyped());
            }

            if (obj.GetValue() == null)
            {
                SetValue(obj.GetValue());
            }
            else
            {
                SetValue(obj.GetValue().CloneTyped());
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }

            if (obj.GetValue() != null)
            {
                GetValue().SetMmgColor(obj.GetValue().GetMmgColor().Clone());
            }

            if (obj.GetLabel() != null)
            {
                GetLabel().SetMmgColor(obj.GetLabel().GetMmgColor().Clone());
            }

            skipReset = false;
        }

        /// <summary>
        /// Constructor that sets the font, text, position, and color.
        /// </summary>
        /// <param name="fontLbl">The font to use for the label.</param>
        /// <param name="txtLbl">The text to set the label to.</param>
        /// <param name="fontVal">The position to draw the label value pair.</param>
        /// <param name="txtVal">The text to set the value to.</param>
        /// <param name="pos">The font to use for the value.</param>
        /// <param name="cl">The color to use to draw the text.</param>
        /// <param name="fontLblType">The font type of the label font argument.</param>
        /// <param name="fontValType">The font type of the value font argument.</param>
        public MmgLabelValuePair(SpriteFont fontLbl, string txtLbl, SpriteFont fontVal, string txtVal, MmgVector2 pos, MmgColor cl, FontType fontLblType, FontType fontValType) : base()
        {
            skipReset = true;
            SetLabel(new MmgFont(fontLbl, fontLblType));
            SetValue(new MmgFont(fontVal, fontValType));
            SetLabelText(txtLbl);
            SetValueText(txtVal);
            SetPosition(pos);
            SetIsVisible(true);
            SetMmgColor(cl);
            SetPaddingX(DEFAULT_PADDING_X);
            skipReset = false;
            Reset();
        }

        /// <summary>
        /// Constructor that sets the font, text, position in X, Y, and color.
        /// </summary>
        /// <param name="fontLbl">The font to use for the label.</param>
        /// <param name="txtLbl">The text to set the label to.</param>
        /// <param name="fontVal">The font to use for the value.</param>
        /// <param name="txtVal">The text to set the value to.</param>
        /// <param name="x">Position, on the X axis.</param>
        /// <param name="y">Position, on the Y axis.</param>
        /// <param name="cl">The color to use to draw the text.</param>
        /// <param name="fontLblType">The font type of the label font argument.</param>
        /// <param name="fontValType">The font type of the value font argument.</param>
        public MmgLabelValuePair(SpriteFont fontLbl, string txtLbl, SpriteFont fontVal, string txtVal, int x, int y, MmgColor cl, FontType fontLblType, FontType fontValType) : base()
        {
            skipReset = true;
            SetLabel(new MmgFont(fontLbl, fontLblType));
            SetValue(new MmgFont(fontVal, fontValType));
            SetLabelText(txtLbl);
            SetValueText(txtVal);
            SetPosition(new MmgVector2(x, y));
            SetIsVisible(true);
            SetMmgColor(cl);
            SetPaddingX(DEFAULT_PADDING_X);
            skipReset = false;
            Reset();
        }

        /// <summary>
        /// Creates a basic clone of this class.
        /// </summary>
        /// <returns>A clone of this class.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgLabelValuePair(this);
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual new MmgLabelValuePair CloneTyped()
        {
            return new MmgLabelValuePair(this);
        }

        /// <summary>
        /// Gets the X axis padding.
        /// </summary>
        /// <returns>The X axis padding of this object.</returns>
        public virtual int GetPaddingX()
        {
            return paddingX;
        }

        /// <summary>
        /// Sets the X axis padding.
        /// </summary>
        /// <param name="p">The X axis padding to use for this object.</param>
        public virtual void SetPaddingX(int p)
        {
            paddingX = p;
            Reset();
        }

        /// <summary>
        /// Gets the value text of this object.
        /// </summary>
        /// <returns>The value text to use for this object.</returns>
        public virtual string GetValueText()
        {
            return val.GetText();
        }

        /// <summary>
        /// Sets the value text of this object.
        /// </summary>
        /// <param name="s">The value text to use for this object.</param>
        public virtual void SetValueText(string s)
        {
            val.SetText(s);
            Reset();
        }

        /// <summary>
        /// Gets the label text of this object.
        /// </summary>
        /// <returns>The label text to use for this object.</returns>
        public virtual string GetLabelText()
        {
            return lbl.GetText();
        }

        /// <summary>
        /// Sets the label text of this object.
        /// </summary>
        /// <param name="s">The label text to use for this object.</param>
        public virtual void SetLabelText(String s)
        {
            lbl.SetText(s);
            Reset();
        }

        /// <summary>
        /// Resets the width, height and position of this object if skipReset is false.
        /// </summary>
        private void Reset()
        {
            if (skipReset == false)
            {
                SetWidth(lbl.GetWidth() + paddingX + val.GetWidth());
                SetHeight(lbl.GetHeight());
                val.SetPosition(lbl.GetPosition().Clone());
                val.SetX(val.GetX() + lbl.GetWidth() + paddingX);
            }
        }

        /// <summary>
        /// A get method that returns the value of the skipReset field.
        /// </summary>
        /// <returns>The value of the skipReset field.</returns>
        public virtual bool GetSkipReset()
        {
            return skipReset;
        }

        /// <summary>
        /// A set method that sets the skipReset field's value.
        /// </summary>
        /// <param name="b">The value to set the skipReset field to.</param>
        public virtual void SetSkipReset(bool b)
        {
            skipReset = b;
        }

        /// <summary>
        /// Sets the size of the font.
        /// </summary>
        /// <param name="sz">The size of the font.</param>
        public virtual void SetFontSize(int sz)
        {
            val.SetFontSize(sz);
            lbl.SetFontSize(sz);
            Reset();
        }

        /// <summary>
        /// Gets the size of the font.
        /// </summary>
        /// <returns>The size of the font.</returns>
        public virtual int GetFontSize()
        {
            if (lbl != null)
            {
                return (int)lbl.GetFontSize();

            }
            else if (val != null)
            {
                return (int)val.GetFontSize();

            }
            else
            {
                return 0;

            }
        }

        /// <summary>
        /// Gets the MmgFont of the label of this object.
        /// </summary>
        /// <returns>The MmgFont of the label of this object.</returns>
        public virtual MmgFont GetLabel()
        {
            return lbl;
        }

        /// <summary>
        /// Sets the MmgFont of the label of this object.
        /// </summary>
        /// <param name="ft">The MmgFont of the label of this object.</param>
        public virtual void SetLabel(MmgFont ft)
        {
            lbl = ft;
            Reset();
        }

        /// <summary>
        /// Gets the MmgFont of the value of this object.
        /// </summary>
        /// <returns>The MmgFont of the value of this object.</returns>
        public virtual MmgFont GetValue()
        {
            return val;
        }

        /// <summary>
        /// Sets the MmgFont of the value of this object.
        /// </summary>
        /// <param name="ft">The MmgFont of the value of this object.</param>
        public virtual void SetValue(MmgFont ft)
        {
            val = ft;
            Reset();
        }

        /// <summary>
        /// Gets the Font object used used to draw the label text.
        /// </summary>
        /// <returns>The font used to draw the label text.</returns>
        public virtual SpriteFont GetLabelFont()
        {
            return lbl.GetFont();
        }

        /// <summary>
        /// Sets the Font object used to draw the label text.
        /// </summary>
        /// <param name="ft">The font used to draw the label text.</param>
        public virtual void SetLabelFont(SpriteFont ft)
        {
            lbl.SetFont(ft);
            Reset();
        }

        /// <summary>
        /// Gets the Font object used to draw the value text.
        /// </summary>
        /// <returns>The font used to draw the value text.</returns>
        public virtual SpriteFont GetValueFont()
        {
            return val.GetFont();
        }

        /// <summary>
        /// Sets the Font object used to draw the value text.
        /// </summary>
        /// <param name="ft">The font used to draw the value text.</param>
        public virtual void SetValueFont(SpriteFont ft)
        {
            val.SetFont(ft);
            Reset();
        }

        /// <summary>
        /// Sets the position of this object and resets the label, value pair positioning.
        /// </summary>
        /// <param name="v">The position of this object.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            lbl.SetPosition(v);
            Reset();
        }

        /// <summary>
        /// Sets the position of this object and resets the label, value pair positioning.
        /// </summary>
        /// <param name="x">The X coordinate to set in the position.</param>
        /// <param name="y">The Y coordinate to set in the position.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            lbl.SetPosition(x, y);
            Reset();
        }

        /// <summary>
        /// Sets the MmgColor to use for drawing the label, value pair text.
        /// </summary>
        /// <param name="c">The color to use for drawing this object's text.</param>
        public override void SetMmgColor(MmgColor c)
        {
            base.SetMmgColor(c);
            lbl.SetMmgColor(c);
            val.SetMmgColor(c);
        }

        /// <summary>
        /// Sets the X coordinate of this object and resets the position of the label, value pair.
        /// </summary>
        /// <param name="x">The X position of this object.</param>
        public override void SetX(int x)
        {
            base.SetX(x);
            lbl.SetX(x);
            Reset();
        }

        /// <summary>
        /// Sets the Y coordinate of this object and resets the position of the label, value pair.
        /// </summary>
        /// <param name="y">The Y position of this object.</param>
        public override void SetY(int y)
        {
            base.SetY(y);
            lbl.SetY(y);
            Reset();
        }

        /// <summary>
        /// The base drawing method used to draw this object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                p.DrawText(lbl);
                p.DrawText(val);
            }
        }

        /// <summary>
        /// A method used to determine equality for MmgLabelValuePair objects.
        /// Equality is based on having the same label, value, and padding.
        /// </summary>
        /// <param name="obj">The MmgLabelValuePair to compare to.</param>
        /// <returns>A boolean value indicating if the two objects are equal.</returns>
        public bool ApiEquals(MmgLabelValuePair obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            /*
            MmgHelper.wr("MmgLabelValuePair: MmgObj");
            if(!(base.ApiEquals((MmgObj)obj))) {
                MmgHelper.wr("MmgLabelValuePair: MmgObj is not equals!");
            }

            MmgHelper.wr("MmgLabelValuePair: Label");        
            if(!(((obj.GetLabel() == null && GetLabel() == null) || (obj.GetLabel() != null && GetLabel() != null && obj.GetLabel().ApiEquals(GetLabel()))))) {
                MmgHelper.wr("MmgLabelValuePair: Label is not equals!");
            }

            MmgHelper.wr("MmgLabelValuePair: Value");        
            if(!(((obj.GetValue() == null && GetValue() == null) || (obj.GetValue() != null && GetValue() != null && obj.GetValue().ApiEquals(GetValue()))))) {
                MmgHelper.wr("MmgLabelValuePair: Value is not equals!");            
            }

            if(!(GetPaddingX() == obj.GetPaddingX())) {
                MmgHelper.wr("MmgLabelValuePair: PaddingX is not equals!");                        
            }
            */

            bool ret = false;
            if (
                base.ApiEquals((MmgObj)obj)
                && ((obj.GetLabel() == null && GetLabel() == null) || (obj.GetLabel() != null && GetLabel() != null && obj.GetLabel().ApiEquals(GetLabel())))
                && ((obj.GetValue() == null && GetValue() == null) || (obj.GetValue() != null && GetValue() != null && obj.GetValue().ApiEquals(GetValue())))
                && GetPaddingX() == obj.GetPaddingX()
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}