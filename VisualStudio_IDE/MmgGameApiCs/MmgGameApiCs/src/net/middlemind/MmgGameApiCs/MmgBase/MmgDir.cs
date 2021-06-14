using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class used to map simple directions for games.
    /// Created by Middlemind Games 11/17/2016
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgDir
    {
        /// <summary>
        /// A static integer that can be used to map the bottom, down direction, or the front of an RPG character.
        /// </summary>
        public static int DIR_FRONT = 0;

        /// <summary>
        /// A static integer that can be used to map the bottom, down, direction, or the front of an RPG character.
        /// </summary>
        public static int DIR_BOTTOM = 0;

        /// <summary>
        /// A static integer that can be used to map the top, up, direction, of the back of an RPG character.
        /// </summary>
        public static int DIR_BACK = 1;

        /// <summary>
        /// A static integer that can be used to map the top, up, direction, of the back of an RPG character.
        /// </summary>
        public static int DIR_TOP = 1;

        /// <summary>
        /// A static integer that can be used to map the left direction.
        /// </summary>
        public static int DIR_LEFT = 2;

        /// <summary>
        /// A static integer that can be used to map the right direction. 
        /// </summary>
        public static int DIR_RIGHT = 3;

        /// <summary>
        /// A static integer that can be used to map a null direction. 
        /// </summary>
        public static int DIR_NONE = -1;
    }
}