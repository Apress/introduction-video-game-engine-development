using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// The base event handler class for event passing. 
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public interface MmgEventHandler
    {
        /// <summary>
        /// Handles an MmgEvent object.
        /// </summary>
        /// <param name="e">The event to handle.</param>
        public void MmgHandleEvent(MmgEvent e);
    }
}