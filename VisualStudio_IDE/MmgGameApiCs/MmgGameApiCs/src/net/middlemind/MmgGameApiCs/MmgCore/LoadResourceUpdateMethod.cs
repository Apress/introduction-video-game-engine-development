using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A class that wraps the LoadDat update information.
    /// Created by Middlemind Games 01/22/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class LoadResourceUpdateMessage
    {
        /// <summary>
        /// The current position of the DAT load process.
        /// </summary>
        public int pos;

        /// <summary>
        /// The length of the DAT binary array.
        /// </summary>
        public int len;

        /// <summary>
        /// Class constructor sets the current position and the current length of the data.
        /// </summary>
        /// <param name="Pos">The current position of the DAT load process.</param>
        /// <param name="Len">The length of the DAT binary array.</param>
        public LoadResourceUpdateMessage(int Pos, int Len)
        {
            pos = Pos;
            len = Len;
        }

        /// <summary>
        /// Getter for the read position.
        /// </summary>
        /// <returns>The read position.</returns>
        public virtual int GetPos()
        {
            return pos;
        }

        /// <summary>
        /// Setter for the read position.
        /// </summary>
        /// <param name="pos">Sets the read position.</param>
        public virtual void SetPos(int Pos)
        {
            pos = Pos;
        }

        /// <summary>
        /// Getter for the total data length.
        /// </summary>
        /// <returns>The total data length.</returns>
        public virtual int GetLen()
        {
            return len;
        }

        /// <summary>
        /// Setter for the total data length.
        /// </summary>
        /// <param name="len">The total data length.</param>
        public virtual void SetLen(int Len)
        {
            len = Len;
        }
    }
}