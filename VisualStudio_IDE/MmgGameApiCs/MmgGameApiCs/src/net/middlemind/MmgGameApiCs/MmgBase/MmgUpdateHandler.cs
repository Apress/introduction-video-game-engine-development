using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class template for handling update events.
    /// Created by Middlemind Games 06/01/2005
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public interface MmgUpdateHandler
    {
        /// <summary>
        /// Handle the incoming update event.
        /// </summary>
        /// <param name="obj">The update event object.</param>
        public void MmgHandleUpdate(Object obj);
    }
}