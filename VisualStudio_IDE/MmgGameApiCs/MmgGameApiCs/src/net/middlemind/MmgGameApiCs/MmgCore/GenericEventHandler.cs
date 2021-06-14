using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// An interface class for handling generic events. 
    /// Generic events are events that are not necessarily driven by user interaction.
    /// Created by Middlemind Games 08/01/2020
    /// </summary>
    public interface GenericEventHandler
    {
        /// <summary>
        /// Method for handling generic events.
        /// </summary>
        /// <param name="obj">A generic event message used to determine what to do in the actual implementation of this method.</param>
        public void HandleGenericEvent(GenericEventMessage obj);
    }
}