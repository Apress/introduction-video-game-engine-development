using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// Class to define the LoadDatUpdateHandler interface.
    /// Created by Middlemind Games 01/22/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public interface LoadResourceUpdateHandler
    {
        /// <summary>
        /// The message handling method to override.
        /// </summary>
        /// <param name="obj">A LoadDatUpdateMessage.</param>
        public void HandleUpdate(LoadResourceUpdateMessage obj);
    }
}