using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The GamePadSimple interface is an interface for routing simple gamepad input.
    /// The interface is designed to handle direction pad input with press, release, click
    /// methods, and A, B, button input with press, release, click methods.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public interface GamePadSimple
    {
        /// <summary>
        /// The ProcessDpadPress method is designed to handle dpad press events and takes a direction code as input.
        /// </summary>
        /// <param name="dir">The dir argument is the code for the dpad direction pressed.</param>
        public void ProcessDpadPress(int dir);

        /// <summary>
        /// The ProcessDpadRelease method is designed to handle dpad release events and takes a direction code as input.
        /// </summary>
        /// <param name="dir">The dir argument is the code for the dpad direction released.</param>
        public void ProcessDpadRelease(int dir);

        /// <summary>
        /// The ProcessDpadClick method is designed to handle dpad click events and takes a direction code as input.
        /// </summary>
        /// <param name="dir">The dir argument is the code for the dpad direction clicked.</param>
        public void ProcessDpadClick(int dir);

        /// <summary>
        /// The ProcessAPress method is designed to handle A button press events.
        /// </summary>
        /// <param name="src"></param>
        public void ProcessAPress(int src);

        /// <summary>
        /// The ProcessARelease method is designed to handle A button release events.
        /// </summary>
        /// <param name="src"></param>
        public void ProcessARelease(int src);

        /// <summary>
        /// The ProcessAClick method is designed to handle A button click events.
        /// </summary>
        /// <param name="src"></param>
        public void ProcessAClick(int src);

        /// <summary>
        /// The ProcessBPress method is designed to handle B button press events.
        /// </summary>
        /// <param name="src"></param>
        public void ProcessBPress(int src);

        /// <summary>
        /// The ProcessBRelease method is designed to handle B button release events.
        /// </summary>
        /// <param name="src"></param>
        public void ProcessBRelease(int src);

        /// <summary>
        /// The ProcessBClick method is designed to handle B button click events.
        /// </summary>
        /// <param name="src"></param>
        public void ProcessBClick(int src);
    }
}