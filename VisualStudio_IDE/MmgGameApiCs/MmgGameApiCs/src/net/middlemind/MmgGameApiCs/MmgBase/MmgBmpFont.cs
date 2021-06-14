using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class that can display text as images using an image source.
    /// Created by Middlemind Games 09/10/2020
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0066:Convert switch statement to expression", Justification = "<Pending>")]
    public class MmgBmpFont : MmgObj
    {
        /// <summary>
        /// The source image to use as the basis for the font.
        /// </summary>
        private MmgBmp src;

        /// <summary>
        /// The destination image used to store the rendered text.
        /// </summary>
        private MmgBmp dst;

        /// <summary>
        /// The individual images for each character of the font.
        /// </summary>
        private MmgBmp[] chars;

        /// <summary>
        /// The text to render using the loaded font.
        /// </summary>
        private string text;

        /// <summary>
        /// An array of widths for the loaded font characters.
        /// </summary>
        private int[] widths;

        /// <summary>
        /// A boolean flag that turns on more logging when set to true.
        /// </summary>
        private bool verbose = true;

        /// <summary>
        /// A static value for the expected length, in characters, of the loaded font.
        /// </summary>
        public static int EXPECTED_CHAR_LENGTH = 95;

        /// <summary>
        /// A static value for the default width to use for null values.
        /// </summary>
        public static int DEFAULT_NULL_WIDTH = MmgHelper.ScaleValue(20);

        /// <summary>
        /// A static value for the default height to use for null values.
        /// </summary>
        public static int DEFAULT_NULL_HEIGHT = MmgHelper.ScaleValue(20);

        /// <summary>
        /// A constructor for the MmgBmpFont class that takes a font source image and a string of text to render using the font as arguments.
        /// </summary>
        /// <param name="Src">A source MmgBmp object that holds the font as individual images of characters in a series.</param>
        /// <param name="Text">The test to render using the loaded font.</param>
        public MmgBmpFont(MmgBmp Src, string Text) : base()
        {
            SetSrc(Src);
            Prep();
            SetText(Text);
        }

        /// <summary>
        /// A constructor for the MmgBmpFont class that takes a font source image as an argument.
        /// </summary>
        /// <param name="Src">A source MmgBmp object that holds the font as individual images of characters in a series.</param>
        public MmgBmpFont(MmgBmp Src) : base()
        {
            SetSrc(Src);
            Prep();
            SetText(" ");
        }

        /// <summary>
        /// A constructor that creates a new MmgBmpFont object instance from an existing one.
        /// </summary>
        /// <param name="obj">The MmgBmpFont object to use as the basis for a new MmgBmpFont object instance.</param>
        public MmgBmpFont(MmgBmpFont obj) : base()
        {
            if (obj.GetSrc() == null)
            {
                SetSrc(obj.GetSrc());
            }
            else
            {
                SetSrc(obj.GetSrc().CloneTyped());
            }

            Prep();

            if (obj.GetText() != null && obj.GetText().Equals("") == false)
            {
                SetText(obj.GetText());
            }
            else
            {
                SetText(" ");
            }

            if (obj.GetDst() == null)
            {
                SetDst(obj.GetDst());
            }
            else
            {
                SetDst(obj.GetDst().CloneTyped());
            }

            int len = 0;
            if (obj.GetChars() == null)
            {
                SetChars(obj.GetChars());
            }
            else
            {
                len = obj.GetCharCount();
                SetChars(new MmgBmp[len]);
                for (int i = 0; i < len; i++)
                {
                    SetChar(obj.GetChar(i).CloneTyped(), i);
                }
            }

            if (obj.GetWidths() == null)
            {
                SetWidths(obj.GetWidths());
            }
            else
            {
                len = obj.GetWidths().Length;
                SetWidths(new int[len]);
                for (int i = 0; i < len; i++)
                {
                    widths[i] = obj.GetWidths()[i];
                }
            }
        }

        /// <summary>
        /// Clones the current object instance and returns an MmgObj object.
        /// </summary>
        /// <returns>An MmgObj that is a clone of the current object.</returns>
        public override MmgObj Clone()
        {
            return (MmgObj)new MmgBmpFont(this);
        }

        /// <summary>
        /// Clones the current object instance and returns an MmgBmpFont object.
        /// </summary>
        /// <returns>An MmgBmpFont that is a clone of the current object.</returns>
        public virtual new MmgBmpFont CloneTyped()
        {
            return new MmgBmpFont(this);
        }

        /// <summary>
        /// Gets the value of the boolean flag controlling verbose logging.
        /// </summary>
        /// <returns>A boolean indicating if verbose logging is on.</returns>
        public virtual bool GetVerbose()
        {
            return verbose;
        }

        /// <summary>
        /// Sets the value of the boolean flag controlling verbose logging.
        /// </summary>
        /// <param name="b">A boolean indicating if verbose logging is on.</param>
        public virtual void SetVerbose(bool b)
        {
            verbose = b;
        }

        /// <summary>
        /// A method that is needed to prep the font from the source image. 
        /// </summary>
        public virtual void Prep()
        {
            Texture2D imgT = src.GetImage();
            GraphicsDevice gd = MmgScreenData.GRAPHICS_CONFIG;
            SpriteBatch g = new SpriteBatch(gd);
            RenderTarget2D img = new RenderTarget2D(gd, imgT.Width, imgT.Height);

            g.GraphicsDevice.SetRenderTarget(img);
            g.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            g.Draw(imgT, new Vector2(0, 0), Color.White);
            g.End();
            g.GraphicsDevice.SetRenderTarget(null);

            int width = src.GetWidth();
            int height = src.GetHeight();
            MmgDrawableBmpSet bmpSet;

            int i = 1;
            int start = i;
            int found = 0;
            int pos;
            int w;
            chars = new MmgBmp[MmgBmpFont.EXPECTED_CHAR_LENGTH];
            widths = new int[MmgBmpFont.EXPECTED_CHAR_LENGTH];
            Color[] pixels = new Color[img.Width * img.Height];
            img.GetData<Color>(pixels);

            for (i = 1; i < width; i++)
            {
                Color ct = pixels[i];
                if (ct.R == 255 && ct.G == 0 && ct.B == 255)
                {
                    pos = start;
                    w = (i - start);

                    bmpSet = MmgHelper.CreateDrawableBmpSet(w, height, true);
                    bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(bmpSet.buffImg);
                    bmpSet.p.GetGraphics().Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
                    bmpSet.p.DrawBmp(src, new MmgRect(start, 0, height, start + w), new MmgRect(0, 0, height, w));
                    bmpSet.p.GetGraphics().End();
                    bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(null);

                    chars[found] = bmpSet.img;
                    widths[found] = w;

                    if (verbose)
                    {
                        MmgHelper.wr("Index: " + found + ", Found char at " + pos + " with width " + w);
                    }

                    start = i + 1;
                    found++;
                }
            }
        }

        /// <summary>
        /// Returns the index for a given character.
        /// </summary>
        /// <param name="c">The character to look up the index for.</param>
        /// <returns>The index of the given character.</returns>
        public virtual int GetIndexOf(char c)
        {
            // !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~
            switch (c)
            {
                case ' ':
                    return 0;
                case '!':
                    return 1;
                case '\"':
                    return 2;
                case '#':
                    return 3;
                case '$':
                    return 4;
                case '%':
                    return 5;
                case '&':
                    return 6;
                case '\'':
                    return 7;
                case '(':
                    return 8;
                case ')':
                    return 9;
                case '*':
                    return 10;
                case '+':
                    return 11;
                case ',':
                    return 12;
                case '-':
                    return 13;
                case '.':
                    return 14;
                case '/':
                    return 15;
                case '0':
                    return 16;
                case '1':
                    return 17;
                case '2':
                    return 18;
                case '3':
                    return 19;
                case '4':
                    return 20;
                case '5':
                    return 21;
                case '6':
                    return 22;
                case '7':
                    return 23;
                case '8':
                    return 24;
                case '9':
                    return 25;
                case ':':
                    return 26;
                case ';':
                    return 27;
                case '<':
                    return 28;
                case '=':
                    return 29;
                case '>':
                    return 30;
                case '?':
                    return 31;
                case '@':
                    return 32;
                case 'A':
                    return 33;
                case 'B':
                    return 34;
                case 'C':
                    return 35;
                case 'D':
                    return 36;
                case 'E':
                    return 37;
                case 'F':
                    return 38;
                case 'G':
                    return 39;
                case 'H':
                    return 40;
                case 'I':
                    return 41;
                case 'J':
                    return 42;
                case 'K':
                    return 43;
                case 'L':
                    return 44;
                case 'M':
                    return 45;
                case 'N':
                    return 46;
                case 'O':
                    return 47;
                case 'P':
                    return 48;
                case 'Q':
                    return 49;
                case 'R':
                    return 50;
                case 'S':
                    return 51;
                case 'T':
                    return 52;
                case 'U':
                    return 53;
                case 'V':
                    return 54;
                case 'W':
                    return 55;
                case 'X':
                    return 56;
                case 'Y':
                    return 57;
                case 'Z':
                    return 58;
                case '[':
                    return 59;
                case '\\':
                    return 60;
                case ']':
                    return 61;
                case '^':
                    return 62;
                case '_':
                    return 63;
                case '`':
                    return 64;
                case 'a':
                    return 65;
                case 'b':
                    return 66;
                case 'c':
                    return 67;
                case 'd':
                    return 68;
                case 'e':
                    return 69;
                case 'f':
                    return 70;
                case 'g':
                    return 71;
                case 'h':
                    return 72;
                case 'i':
                    return 73;
                case 'j':
                    return 74;
                case 'k':
                    return 75;
                case 'l':
                    return 76;
                case 'm':
                    return 77;
                case 'n':
                    return 78;
                case 'o':
                    return 79;
                case 'p':
                    return 80;
                case 'q':
                    return 81;
                case 'r':
                    return 82;
                case 's':
                    return 83;
                case 't':
                    return 84;
                case 'u':
                    return 85;
                case 'v':
                    return 86;
                case 'w':
                    return 87;
                case 'x':
                    return 88;
                case 'y':
                    return 89;
                case 'z':
                    return 90;
                case '{':
                    return 91;
                case '|':
                    return 92;
                case '}':
                    return 93;
                case '~':
                    return 94;
                default:
                    MmgHelper.wr("MmgBmpFont: GetIndexOf: Unknown character, using default value '-1'.");
                    return -1;
            }
        }

        /// <summary>
        /// Returns the index of the given character represented as a single character string.
        /// </summary>
        /// <param name="s">The string to use to determine the character index for.</param>
        /// <returns>The index of the given character.</returns>
        public virtual int GetIndexOf(string s)
        {
            char c = s.ToCharArray()[0];
            return GetIndexOf(c);
        }

        /// <summary>
        /// Returns the character at the given index but casts the character to a string.
        /// </summary>
        /// <param name="i">The index used to lookup the character.</param>
        /// <returns>The character associated with the given index converted to a string.</returns>
        public virtual string GetStrAt(int i)
        {
            return GetCharAt(i) + "";
        }


        /// <summary>
        /// Returns the character for the given index.
        /// </summary>
        /// <param name="i">The index used to lookup the character.</param>
        /// <returns>The character associated with the given index.</returns>
        public virtual char GetCharAt(int i)
        {
            switch (i)
            {
                case 0:
                    return ' ';
                case 1:
                    return '!';
                case 2:
                    return '\"';
                case 3:
                    return '#';
                case 4:
                    return '$';
                case 5:
                    return '%';
                case 6:
                    return '&';
                case 7:
                    return '\'';
                case 8:
                    return '(';
                case 9:
                    return ')';
                case 10:
                    return '*';
                case 11:
                    return '+';
                case 12:
                    return ',';
                case 13:
                    return '-';
                case 14:
                    return '.';
                case 15:
                    return '/';
                case 16:
                    return '0';
                case 17:
                    return '1';
                case 18:
                    return '2';
                case 19:
                    return '3';
                case 20:
                    return '4';
                case 21:
                    return '5';
                case 22:
                    return '6';
                case 23:
                    return '7';
                case 24:
                    return '8';
                case 25:
                    return '9';
                case 26:
                    return ':';
                case 27:
                    return ';';
                case 28:
                    return '<';
                case 29:
                    return '=';
                case 30:
                    return '>';
                case 31:
                    return '?';
                case 32:
                    return '@';
                case 33:
                    return 'A';
                case 34:
                    return 'B';
                case 35:
                    return 'C';
                case 36:
                    return 'D';
                case 37:
                    return 'E';
                case 38:
                    return 'F';
                case 39:
                    return 'G';
                case 40:
                    return 'H';
                case 41:
                    return 'I';
                case 42:
                    return 'J';
                case 43:
                    return 'K';
                case 44:
                    return 'L';
                case 45:
                    return 'M';
                case 46:
                    return 'N';
                case 47:
                    return 'O';
                case 48:
                    return 'P';
                case 49:
                    return 'Q';
                case 50:
                    return 'R';
                case 51:
                    return 'S';
                case 52:
                    return 'T';
                case 53:
                    return 'U';
                case 54:
                    return 'V';
                case 55:
                    return 'W';
                case 56:
                    return 'X';
                case 57:
                    return 'Y';
                case 58:
                    return 'Z';
                case 59:
                    return '[';
                case 60:
                    return '\\';
                case 61:
                    return ']';
                case 62:
                    return '^';
                case 63:
                    return '_';
                case 64:
                    return '`';
                case 65:
                    return 'a';
                case 66:
                    return 'b';
                case 67:
                    return 'c';
                case 68:
                    return 'd';
                case 69:
                    return 'e';
                case 70:
                    return 'f';
                case 71:
                    return 'g';
                case 72:
                    return 'h';
                case 73:
                    return 'i';
                case 74:
                    return 'j';
                case 75:
                    return 'k';
                case 76:
                    return 'l';
                case 77:
                    return 'm';
                case 78:
                    return 'n';
                case 79:
                    return 'o';
                case 80:
                    return 'p';
                case 81:
                    return 'q';
                case 82:
                    return 'r';
                case 83:
                    return 's';
                case 84:
                    return 't';
                case 85:
                    return 'u';
                case 86:
                    return 'v';
                case 87:
                    return 'w';
                case 88:
                    return 'x';
                case 89:
                    return 'y';
                case 90:
                    return 'z';
                case 91:
                    return '{';
                case 92:
                    return '|';
                case 93:
                    return '}';
                case 94:
                    return '~';
                default:
                    MmgHelper.wr("MmgBmpFont: GetCharAt: Unknown character index, using default character '_'.");
                    return '_';
            }
        }

        /// <summary>
        /// Gets the text associated with this MmgBmpFont instance.
        /// </summary>
        /// <returns>The text associated with this MmgBmpFont instance.</returns>
        public virtual string GetText()
        {
            return text;
        }

        /// <summary>
        /// Sets the text associated with the MmgBmpFont instance.
        /// </summary>
        /// <param name="s">The string used to render using the loaded font.</param>
        public virtual void SetText(string s)
        {
            if (s != null)
            {
                if(s.Length == 0)
                {
                    s = " ";
                }

                int len = s.Length;
                char c;
                int idx = 0;
                int totalWidth = 0;
                int i = 0;

                for (i = 0; i < len; i++)
                {
                    c = s.ToCharArray()[i];
                    idx = GetIndexOf(c);
                    w = GetWidthAt(idx);
                    if(w == -1)
                    {
                        MmgHelper.wr("MmgBmpFont: Could not find index of character: " + c + " With Code: " + (int)((byte)c));
                    }
                    totalWidth += w;
                }

                if(totalWidth <= 0)
                {
                    //MmgHelper.wr("MmgBmpFont: Error: totalWidth value is incorrect: " + totalWidth);
                    s = " ";
                    c = s.ToCharArray()[i];
                    idx = GetIndexOf(c);
                    w = GetWidthAt(idx);
                    totalWidth = w;
                }

                int posX = 0;
                MmgDrawableBmpSet bmpSet = MmgHelper.CreateDrawableBmpSet(totalWidth, src.GetHeight(), true);
                //MmgHelper.wr("MmgBmpFont: New MmgBmpFont destination image Width: " + totalWidth + " Height: " + src.GetHeight());

                bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(bmpSet.buffImg);
                bmpSet.p.GetGraphics().Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

                MmgBmp img = null;
                for (i = 0; i < len; i++)
                {
                    c = s.ToCharArray()[i];
                    idx = GetIndexOf(c);
                    img = chars[idx];
                    //MmgHelper.wr("MmgBmpFont: PosX: " + posX + " LetterWidth: " + img.GetWidth() + " Height: " + img.GetHeight() + " Index: " + idx + " WidthsVal: " + widths[idx]);
                    bmpSet.p.DrawBmp(img, new MmgRect(0, 0, img.GetHeight(), img.GetWidth()), new MmgRect(posX, 0, img.GetHeight(), posX + img.GetWidth()));
                    posX += widths[idx];
                }

                bmpSet.p.GetGraphics().End();
                bmpSet.p.GetGraphics().GraphicsDevice.SetRenderTarget(null);

                bmpSet.img = new MmgBmp(bmpSet.buffImg);
                dst = bmpSet.img;
                text = s;
            }
            else
            {
                dst = MmgHelper.CreateFilledBmp(DEFAULT_NULL_WIDTH, DEFAULT_NULL_HEIGHT, MmgColor.GetDarkRed());
            }
        }

        /// <summary>
        /// Gets the MmgColor of the rendered font image.
        /// </summary>
        /// <returns>The MmgColor of the rendered font MmgBmp.</returns>
        public override MmgColor GetMmgColor()
        {
            return dst.GetMmgColor();
        }

        /// <summary>
        /// Sets the MmgColor of the rendered font image.
        /// </summary>
        /// <param name="c">The MmgColor of the rendered font MmgBmp.</param>
        public override void SetMmgColor(MmgColor c)
        {
            base.SetMmgColor(c);
            dst.SetMmgColor(c);
        }

        /// <summary>
        /// Gets the X coordinate of the destination MmgBmp.
        /// </summary>
        /// <returns>The X coordinate of the destination MmgBmp.</returns>
        public override int GetX()
        {
            return dst.GetX();
        }

        /// <summary>
        /// Sets the X coordinate of the destination MmgBmp.
        /// </summary>
        /// <param name="x">The X coordinate of the destination MmgBmp.</param>
        public override void SetX(int x)
        {
            base.SetX(x);
            dst.SetX(x);
        }

        /// <summary>
        /// Gets the Y coordinate of the destination MmgBmp.
        /// </summary>
        /// <returns>The Y coordinate of the destination MmgBmp.</returns>
        public override int GetY()
        {
            return dst.GetY();
        }

        /// <summary>
        /// Sets the Y coordinate of the destination MmgBmp.
        /// </summary>
        /// <param name="y">The Y coordinate of the destination MmgBmp.</param>
        public override void SetY(int y)
        {
            base.SetY(y);
            dst.SetY(y);
        }

        /// <summary>
        /// Gets the position of the destination MmgBmp.
        /// </summary>
        /// <returns>The position of the destination MmgBmp.</returns>
        public override MmgVector2 GetPosition()
        {
            return dst.GetPosition();
        }

        /// <summary>
        /// Sets the position of the destination MmgBmp.
        /// </summary>
        /// <param name="x">The X coordinate of the destination MmgBmp.</param>
        /// <param name="y">The Y coordinate of the destination MmgBmp.</param>
        public override void SetPosition(int x, int y)
        {
            base.SetPosition(x, y);
            dst.SetPosition(x, y);
        }

        /// <summary>
        /// Sets the position of the destination MmgBmp.
        /// </summary>
        /// <param name="v">The position of the destination MmgBmp.</param>
        public override void SetPosition(MmgVector2 v)
        {
            base.SetPosition(v);
            dst.SetPosition(v);
        }

        /// <summary>
        /// Gets the width of the destination MmgBmp.
        /// </summary>
        /// <returns>The width of the destination MmgBmp.</returns>
        public override int GetWidth()
        {
            return dst.GetWidth();
        }

        /// <summary>
        /// Sets the width of the destination MmgBmp.
        /// </summary>
        /// <param name="w">The width of the destination MmgBmp.</param>
        public override void SetWidth(int w)
        {
            base.SetWidth(w);
            dst.SetWidth(w);
        }

        /// <summary>
        /// Gets the height of the destination MmgBmp.
        /// </summary>
        /// <returns>The height of the destination MmgBmp.</returns>
        public override int GetHeight()
        {
            return dst.GetHeight();
        }

        /// <summary>
        /// Sets the height of the destination MmgBmp.
        /// </summary>
        /// <param name="h">The height of the destination MmgBmp.</param>
        public override void SetHeight(int h)
        {
            base.SetHeight(h);
            dst.SetHeight(h);
        }

        /// <summary>
        /// Gets the widths of the characters loaded from the font source image.
        /// </summary>
        /// <returns>An array of widths of the characters loaded from the font source image.</returns>
        public virtual int[] GetWidths()
        {
            return widths;
        }

        /// <summary>
        /// Gets the width of the character at the specified index.
        /// </summary>
        /// <param name="i">The index used to lookup a character's width.</param>
        /// <returns>The width of the character at the specified index.</returns>
        public virtual int GetWidthAt(int i)
        {
            return widths[i];
        }

        /// <summary>
        /// Sets the widths of the characters loaded from the font source image.
        /// </summary>
        /// <param name="ws">An array of widths of the characters loaded from the font source image. </param>
        public virtual void SetWidths(int[] ws)
        {
            widths = ws;
        }

        /// <summary>
        /// Gets the source image for the font.
        /// </summary>
        /// <returns>The source image for the font.</returns>
        public virtual MmgBmp GetSrc()
        {
            return src;
        }

        /// <summary>
        /// Sets the source image for the font.
        /// </summary>
        /// <param name="b">The source image for the font.</param>
        public virtual void SetSrc(MmgBmp b)
        {
            src = b;
        }

        /// <summary>
        /// Gets the destination image for the font.
        /// </summary>
        /// <returns>The destination image for the font.</returns>
        public virtual MmgBmp GetDst()
        {
            return dst;
        }

        /// <summary>
        /// Sets the destination image for the font.
        /// </summary>
        /// <param name="b">The destination image for the font.</param>
        public virtual void SetDst(MmgBmp b)
        {
            dst = b;
        }

        /// <summary>
        /// Gets an array of MmgBmp images, one for each character in the loaded font.
        /// </summary>
        /// <returns>An array of MmgBmp images, one for each character in the loaded font.</returns>
        public virtual MmgBmp[] GetChars()
        {
            return chars;
        }

        /// <summary>
        /// Sets an array of MmgBmp images, one for each character in the loaded font.
        /// </summary>
        /// <param name="c">An array of MmgBmp images, one for each character in the loaded font.</param>
        public virtual void SetChars(MmgBmp[] c)
        {
            chars = c;
        }

        /// <summary>
        /// Gets the count of characters in the loaded font.
        /// </summary>
        /// <returns>The count of characters in the loaded font.</returns>
        public virtual int GetCharCount()
        {
            return chars.Length;
        }

        /// <summary>
        /// Gets the MmgBmp of the character located at the given index.
        /// </summary>
        /// <param name="i">The index of the character to lookup an MmgBmp object for.</param>
        /// <returns>The MmgBmp of the character located at the given index.</returns>
        public virtual MmgBmp GetChar(int i)
        {
            return chars[i];
        }

        /// <summary>
        /// Sets the MmgBmp of the character located at the given index.
        /// </summary>
        /// <param name="b">The MmgBmp of the character located at the given index.</param>
        /// <param name="i">The index of the character to lookup an MmgBmp object for.</param>
        public virtual void SetChar(MmgBmp b, int i)
        {
            chars[i] = b;
        }

        /// <summary>
        /// The base drawing method used to draw this object.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (isVisible == true)
            {
                p.DrawBmp(dst, GetPosition());
            }
        }

        /// <summary>
        /// A method used to check the equality of this MmgBmpFont when compared to another MmgBmpFont.
        /// Compares object fields to determine equality.
        /// </summary>
        /// <param name="obj">The MmgBmpFont object to compare to.</param>
        /// <returns>A boolean indicating if the two objects are equal or not.</returns>
        public virtual bool ApiEquals(MmgBmpFont obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = true;
            if (
                base.ApiEquals((MmgObj)obj)
                && ((obj.GetSrc() == null && GetSrc() == null) || (obj.GetSrc() != null && GetSrc() != null && obj.GetSrc().ApiEquals(GetSrc())))
                && ((obj.GetDst() == null && GetDst() == null) || (obj.GetDst() != null && GetDst() != null && obj.GetDst().ApiEquals(GetDst())))
                && ((obj.GetText() == null && GetText() == null) || (obj.GetText() != null && GetText() != null && obj.GetText().Equals(GetText())))
            )
            {
                int len = obj.GetCharCount();
                int i = 0;
                for (i = 0; i < len; i++)
                {
                    if (!obj.GetChar(i).ApiEquals(GetChar(i)))
                    {
                        ret = false;
                        break;
                    }
                }

                len = obj.GetWidths().Length;
                for (i = 0; i < len; i++)
                {
                    if (!(obj.GetWidths()[i] == GetWidths()[i]))
                    {
                        ret = false;
                        break;
                    }
                }
            }
            else
            {
                ret = false;
            }
            return ret;
        }
    }
}