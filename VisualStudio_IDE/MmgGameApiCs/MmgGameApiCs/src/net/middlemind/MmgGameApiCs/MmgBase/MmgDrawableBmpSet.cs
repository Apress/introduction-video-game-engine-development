using System;
using Microsoft.Xna.Framework.Graphics;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class the hold the objects necessary to handle creation of a drawable bitmap.
    /// Created by Middlemind Games 03/10/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgDrawableBmpSet
    {
        /// <summary>
        /// A lower level Monogame texture used for custom image creation and drawing.
        /// </summary>
        public RenderTarget2D buffImg;

        /// <summary>
        /// A lower level Monogame graphics object that handles drawing basic shapes, objects to a BufferedImage.
        /// </summary>
        public SpriteBatch graphics;

        /// <summary>
        /// An MmgApi level object that wraps the lower level Java graphics API and allows for drawing basic shapes and objects.
        /// </summary>
        public MmgPen p;

        /// <summary>
        /// An MmgApi level object that wraps Java graphics objects and can be used to display the drawn shapes and objects.
        /// </summary>
        public MmgBmp img;
    }
}