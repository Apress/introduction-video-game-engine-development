package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;

/**
 * A base class used to represent a generic event message. 
 * This is the event message argument used by the GenericEventHandler class.
 * Created by Middlemind Games 08/01/2020
 *
 * @author Victor G. Brusca
 */
public class GenericEventMessage {

    /**
     * The identifier of this generic event message.
     */
    public int id;

    /**
     * The information payload of this generic event message.
     */
    public Object payload;

    /**
     * The game state of this generic event message.
     */
    public GameStates gameState;

    /**
     * Constructor for the generic event message object, sets the message id, the message payload, and the game state the message is associated with.
     *
     * @param Id            The id of the message.
     * @param Payload       The information payload of the message.
     * @param GameState     The game state of the message.
     */
    public GenericEventMessage(int Id, Object Payload, GameStates GameState) {
        id = Id;
        payload = Payload;
        gameState = GameState;
    }

    /**
     * Gets the id of this message.
     *
     * @return      The id of the message.
     */
    public int GetId() {
        return id;
    }

    /**
     * Gets the payload of the message.
     *
     * @return      The payload of the message.
     */
    public Object GetPayload() {
        return payload;
    }

    /**
     * The game state of the message.
     *
     * @return      The game state of the message.
     */
    public GameStates GetGameState() {
        return gameState;
    }
}