using System;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A base class used to represent a generic event message. 
    /// This is the event message argument used by the GenericEventHandler class.
    /// Created by Middlemind Games 08/01/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class GenericEventMessage
    {
        /// <summary>
        /// The identifier of this generic event message.
        /// </summary>
        public int id;

        /// <summary>
        /// The information payload of this generic event message.
        /// </summary>
        public object payload;

        /// <summary>
        /// The game state of this generic event message.
        /// </summary>
        public GameStates gameState;

        /// <summary>
        /// Constructor for the generic event message object, sets the message id, the message payload, and the game state the message is associated with.
        /// </summary>
        /// <param name="Id">The id of the message.</param>
        /// <param name="Payload">The information payload of the message.</param>
        /// <param name="GameState">The game state of the message.</param>
        public GenericEventMessage(int Id, object Payload, GameStates GameState)
        {
            id = Id;
            payload = Payload;
            gameState = GameState;
        }

        /// <summary>
        /// Gets the id of this message.
        /// </summary>
        /// <returns>The id of the message.</returns>
        public virtual int GetId()
        {
            return id;
        }

        /// <summary>
        /// Gets the payload of the message.
        /// </summary>
        /// <returns>The payload of the message.</returns>
        public virtual object GetPayload()
        {
            return payload;
        }

        /// <summary>
        /// The game state of the message.
        /// </summary>
        /// <returns>The game state of the message.</returns>
        public virtual GameStates GetGameState()
        {
            return gameState;
        }
    }
}