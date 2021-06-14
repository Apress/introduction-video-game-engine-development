using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// A class that handles scaling requests from a running MmgSizeTween object.
    /// Created by Middlemind Games 09/14/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public interface MmgScaleHandler
    {
        /// <summary>
        /// A method to handle an image scaling request in response to MmgSizeTween events.
        /// </summary>
        /// <param name="v">The vector that describes how much to scale the MmgObj in each direction.</param>
        /// <param name="orig">The MmgObj to be scaled.</param>
        public void MmgHandleScale(MmgVector2 v, MmgObj orig);
    }
}