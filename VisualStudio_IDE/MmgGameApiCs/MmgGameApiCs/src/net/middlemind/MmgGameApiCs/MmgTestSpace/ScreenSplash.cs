using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// An application specific extension of the MmgCore API's ScreenSplash class.
    /// Created by Middlemind Games 02/19/2020
    ///
    /// @author Victor G. Brusca, Middlemind Games
    /// </summary>
    public class ScreenSplash : net.middlemind.MmgGameApiCs.MmgCore.ScreenSplash
    {
        /// <summary>
        /// The default constructor that takes a GameStates enumeration entry and an instance of the GamePanel that will display this screen.
        /// </summary>
        /// <param name="State">The GameStates enumeration entry associated with this game screen.</param>
        /// <param name="Owner">The GamePanel that will display this game screen.</param>
        public ScreenSplash(GamePanel.GameStates State, GamePanel Owner) : base(State, Owner)
        {
        }

        /// <summary>
        /// Sets the GenericEventHandler for this class.
        /// </summary>
        /// <param name="Handler">The GenericEventHandler for this class.</param>
        public virtual new void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenSplash.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// A method to handle update calls from the MmgCore API's ScreenPlash class.
        /// </summary>
        /// <param name="obj"></param>
        public override void MmgHandleUpdate(Object obj)
        {
            MmgHelper.wr("ScreenSplash.MmgHandleUpdate");
            if (handler != null)
            {
                handler.HandleGenericEvent(new GenericEventMessage(net.middlemind.MmgGameApiCs.MmgCore.ScreenSplash.EVENT_DISPLAY_COMPLETE, null, GetGameState()));
            }
        }
    }
}