using System;
using System.IO;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Deprecated class the was used as a BMP based font on the original XNA implementation of this API.
    /// @author Victor G. Brusca
    /// Middlemind Games 01/13/2012
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgBmpFontXna : MmgObj
    {
        /// <summary>
        /// The X position of the image font characters.
        /// </summary>
        private int[] font_xpos;

        /// <summary>
        /// The width of the image font characters.
        /// </summary>
        private int[] font_width;

        /// <summary>
        /// The height of the image font characters. 
        /// </summary>
        private int font_height;

        /// <summary>
        /// The font image used to parse and create the individual font characters.
        /// </summary>
        private MmgBmp fontimg;

        /// <summary>
        /// The text to render using the image font.
        /// </summary>
        private string text;

        /// <summary>
        /// A binary array that holds information about the image font characters.
        /// </summary>
        private byte[] carddata;

        /// <summary>
        /// An array of characters
        /// </summary>
        private char[] c;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int tx;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int i;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int tmp;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int n;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private int len;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private BinaryReader ifile;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MemoryStream bai;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgRect tmpDstRect;

        /// <summary>
        /// TODO: Add comments
        /// </summary>
        private MmgRect tmpSrcRect;

        /// <summary>
        /// Generic constructor for this class.
        /// </summary>
        public MmgBmpFontXna() : base()
        {
            font_xpos = null;
            font_width = null;
            font_height = 0;
            fontimg = null;
            text = "";
            carddata = null;
            c = null;
        }

        /// <summary>
        /// Constructor that takes an MmgObj as an argument.
        /// </summary>
        /// <param name="obj">An MmgObj class used as an argument.</param>
        public MmgBmpFontXna(MmgObj obj) : base(obj)
        {
            font_xpos = null;
            font_width = null;
            font_height = 0;
            fontimg = null;
            text = "";
            carddata = null;
            c = null;
        }

        /// <summary>
        /// Specialized constructor that takes an MmgBmpFontXna class as an argument.
        /// </summary>
        /// <param name="obj">An instance of the MmgBmpFontXna class used as an argument to set the values of this class instance.</param>
        public MmgBmpFontXna(MmgBmpFontXna obj)
        {
            SetFontXpos(obj.GetFontXpos());
            SetFontWidth(obj.GetFontWidth());
            SetFontHeight(obj.GetFontHeight());

            if (obj.GetFontImg() == null)
            {
                SetFontImg(obj.GetFontImg());
            }
            else
            {
                SetFontImg((MmgBmp)obj.GetFontImg().Clone());
            }

            SetText(obj.GetText());
            SetCardData(obj.GetCardData());
            SetCharArray(obj.GetCharArray());

            if (obj.GetPosition() == null)
            {
                SetPosition(obj.GetPosition());
            }
            else
            {
                SetPosition(obj.GetPosition().Clone());
            }

            SetWidth(obj.GetWidth());
            SetHeight(obj.GetHeight());
            SetIsVisible(obj.GetIsVisible());

            if (obj.GetMmgColor() == null)
            {
                SetMmgColor(obj.GetMmgColor());
            }
            else
            {
                SetMmgColor(obj.GetMmgColor().Clone());
            }
        }

        /// <summary>
        /// Constructor that takes a font image, binary description data, and text to render.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="cd"></param>
        /// <param name="Text"></param>
        public MmgBmpFontXna(MmgBmp img, byte[] cd, string Text)
        {
            LoadFont(img, cd);
            text = Text;

            SetWidth(GetTextWidth(text));
            SetHeight(fontimg.GetHeight());
            font_height = GetHeight();

            SetPosition(new MmgVector2(0, 0));
            SetIsVisible(true);
            SetMmgColor(MmgColor.GetWhite());
        }

        /// <summary>
        /// Returns an array of characters represented by the image file and binary descriptor.
        /// </summary>
        /// <returns></returns>
        public virtual char[] GetCharArray()
        {
            return c;
        }

        /// <summary>
        /// Sets an array of characters used by this class to render text using an image font.
        /// </summary>
        /// <param name="chr"></param>
        public virtual void SetCharArray(char[] chr)
        {
            c = chr;
        }

        /// <summary>
        /// Gets the image font binary description data.
        /// </summary>
        /// <returns>A byte array representing the binary description data.</returns>
        public virtual byte[] GetCardData()
        {
            return carddata;
        }

        /// <summary>
        /// Sets the image font binary description data.
        /// </summary>
        /// <param name="b">A byte array representing the binary description data.</param>
        public virtual void SetCardData(byte[] b)
        {
            carddata = b;
        }

        /// <summary>
        /// Returns the text that this class represents using the specified image font.
        /// </summary>
        /// <returns></returns>
        public virtual string GetText()
        {
            return text;
        }

        /// <summary>
        /// Set the text that this class represents using the specified image font.
        /// </summary>
        /// <param name="s"></param>
        public virtual void SetText(string s)
        {
            text = s;
        }

        /// <summary>
        /// Gets the image representation of the font.
        /// </summary>
        /// <returns>An image with a series of character printed with a pink dividing line next to each characters.</returns>
        public virtual MmgBmp GetFontImg()
        {
            return fontimg;
        }

        /// <summary>
        /// Sets the image representation of the font.
        /// </summary>
        /// <param name="i">An image with a series of character printed with a pink dividing line next to each characters.</param>
        public virtual void SetFontImg(MmgBmp i)
        {
            fontimg = i;
        }

        /// <summary>
        /// Gets the height of the image font.
        /// </summary>
        /// <returns>The height of the image font.</returns>
        public virtual int GetFontHeight()
        {
            return font_height;
        }

        /// <summary>
        /// Sets the height of the image font.
        /// </summary>
        /// <param name="h">The height of the image font.</param>
        public virtual void SetFontHeight(int h)
        {
            font_height = h;
        }

        /// <summary>
        /// Gets the font width of the characters specified by the image font.
        /// </summary>
        /// <returns>An array of integer widths used to mark the width of each character in the image font.</returns>
        public virtual int[] GetFontWidth()
        {
            return font_width;
        }

        /// <summary>
        /// Sets the font width of the characters specified by the image font.
        /// </summary>
        /// <param name="h">An array of integer widths used to mark the width of each character in the image font.</param>
        public virtual void SetFontWidth(int[] h)
        {
            font_width = h;
        }

        /// <summary>
        /// Gets the image font's X position of each character in the image font.
        /// </summary>
        /// <returns>An array of integer offsets used to mark the X position of each character in the image font.</returns>
        public virtual int[] GetFontXpos()
        {
            return font_xpos;
        }

        /// <summary>
        /// Sets the image font's X position of each character in the image font.
        /// </summary>
        /// <param name="h">An array of integer offsets used to mark the X position of each character in the image font.</param>
        public virtual void SetFontXpos(int[] h)
        {
            font_xpos = h;
        }

        /// <summary>
        /// Clones the current class by calling the specialized contructor with this object instance as an argument.
        /// </summary>
        /// <returns>A new MmgBmpFontXna instance that is based on the current instance.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgBmpFontXna(this);
        }

        /// <summary>
        /// Converts the specified byte array to a short integer.
        /// </summary>
        /// <param name="abyte0">The byte array to convert to a short integer.</param>
        /// <returns>A short integer representation of the specified byte array.</returns>
        private short ToShort(byte[] abyte0)
        {
            return ToShort(abyte0, false);
        }

        /// <summary>
        /// Converts the specified byte array to a short integer.
        /// </summary>
        /// <param name="abyte0">The byte array to convert to a short integer.</param>
        /// <param name="flag">A boolean flag to determine if the byte array should be reversed.</param>
        /// <returns>A short integer representation of the specified byte array.</returns>
        private short ToShort(byte[] abyte0, bool flag)
        {
            short word0 = 0;
            if (flag)
            {
                abyte0 = reverse_order(abyte0, 2);
            }

            for (byte byte0 = 0; byte0 <= 1; byte0++)
            {
                short word1;
                if (abyte0[byte0] < 0)
                {
                    abyte0[byte0] = (byte)(abyte0[byte0] & 0x7f);
                    word1 = abyte0[byte0];
                    word1 |= 0x80;
                }
                else
                {
                    word1 = abyte0[byte0];
                }

                word0 |= word1;
                if (byte0 < 1)
                {
                    word0 <<= 8;
                }
            }

            return word0;
        }

        /// <summary>
        /// Reverse the order of the bytes in the specified array.
        /// </summary>
        /// <param name="abyte0">An array of bytes to reverse.</param>
        /// <param name="i">The length of the bytes to reverse.</param>
        /// <returns></returns>
        private byte[] reverse_order(byte[] abyte0, int i)
        {
            byte[] abyte1 = new byte[i];
            for (byte byte0 = 0; byte0 <= i - 1; byte0++)
            {
                abyte1[byte0] = abyte0[i - 1 - byte0];
            }
            return abyte1;
        }

        /// <summary>
        /// Loads the image font specified by the MmgBmp image file and the binary specification data.
        /// </summary>
        /// <param name="img">An MmgBmp that contains the image font, a series of character images in a file.</param>
        /// <param name="cd">A binary descriptor that includes information on how to parse the font image.</param>
        public virtual void LoadFont(MmgBmp img, byte[] cd)
        {
            try
            {
                fontimg = img;
                carddata = cd;
                bai = new MemoryStream(carddata);
                ifile = new BinaryReader(bai);
                MmgDebug.wr("Data Len: " + carddata.Length);

                len = (int)ToShort(ifile.ReadBytes(2), false);
                MmgDebug.wr("Number of Chars: " + len);

                font_height = (int)ToShort(ifile.ReadBytes(2), false); ;
                MmgDebug.wr("Font Height: " + font_height);

                font_width = new int[len];
                font_xpos = new int[len];

                for (int i = 0; i < len; i++)
                {
                    font_xpos[i] = (int)ToShort(ifile.ReadBytes(2), false); ;
                    font_width[i] = (int)ToShort(ifile.ReadBytes(2), false); ;
                    MmgDebug.wr("Index: " + i + " Width: " + font_width[i] + " xpos: " + font_xpos[i]);
                }

                try
                {
                    ifile.Close();
                }
                catch (Exception ex1)
                {
                    MmgHelper.wrErr(ex1);
                }

                ifile = null;

                try
                {
                    bai.Close();
                }
                catch (Exception ex2)
                {
                    MmgHelper.wrErr(ex2);
                }

                bai = null;
            }
            catch (Exception e)
            {
                MmgDebug.wr(e.StackTrace);
            }
        }

        /// <summary>
        /// Creates an image representation of the specified text using the loaded image font.
        /// </summary>
        /// <param name="pen">An MmgPen instance used to draw the rendered image font on a new image representation of the specified text.</param>
        public virtual void CreateTextImg(MmgPen pen)
        {
            if (text == null || text.Equals(""))
            {
                return;
            }

            tx = 0;
            c = text.ToCharArray();
            tmpDstRect = null;
            tmpSrcRect = null;

            for (i = 0; i < text.Length; i++)
            {
                tmp = (int)c[i];
                tmp -= 32;
                if (tmp < 0 || tmp >= font_width.Length)
                {
                    Console.WriteLine("Missing key  " + i + "] " + tmp + " skipped (" + (char)tmp + ")");
                }
                else
                {
                    tmpSrcRect = new MmgRect(new MmgVector2(font_xpos[tmp], 0), font_width[tmp], font_height);
                    tmpDstRect = new MmgRect(new MmgVector2(GetPosition().GetX() + tx, GetPosition().GetY()), font_width[tmp], font_height);

                    //MmgDebug.wr("Idx: " + i + " SrcRect: " + srcRect.GetRect() + " DstRect: " + dstRect.GetRect());

                    fontimg.SetSrcRect(tmpSrcRect);
                    fontimg.SetDstRect(tmpDstRect);

                    //pen.drawBitmap(font_xpos[tmp], 0, (font_xpos[tmp] + font_width[tmp]), (0 + font_height), tx, y, (tx + font_width[tmp]), (y + font_height), fontimg);
                    pen.DrawBmp(fontimg);

                    tx += font_width[tmp];
                }
            }
        }

        /// <summary>
        /// Returns the calculated width of the text using the image font representation.
        /// </summary>
        /// <param name="str">The string used to calculate the text width of this image font.</param>
        /// <returns>The width of the specified string using this image font.</returns>
        private int GetTextWidth(string str)
        {
            n = 0;
            char[] c = str.ToCharArray();
            for (i = 0; i < str.Length; i++)
            {
                tmp = (int)c[i];
                tmp -= 32;
                if (tmp < 0 || tmp >= font_width.Length)
                {

                }
                else
                {
                    n += (int)(font_width[tmp]);
                }
            }
            return n;
        }

        /// <summary>
        /// The base drawing method for the bitmap object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this bitmap.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                CreateTextImg(p);
            }
        }
    }
}