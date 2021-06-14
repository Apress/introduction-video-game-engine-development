package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * The base event class for event handling. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public class MmgEvent {
    
    /**
     * The parent MmgEventHandler of this event.
     */
    private MmgEventHandler parentHandler;

    /**
     * The message of this event.
     */
    private String message;

    /**
     * The id of this event.
     */
    private int id;

    /**
     * The type of this event.
     */
    private int type;

    /**
     * The target MmgEventHandler of this event.
     */
    private MmgEventHandler targetHandler;

    /**
     * An extra object to pass along with the event.
     */
    private Object extra;

    /**
     * The previous event that fired before this event, if applicable.
     */
    private MmgEvent prevEvent;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_UP = 0;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_DOWN = 1;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_LEFT = 2;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_RIGHT = 3;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_ENTER = 4;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_SPACE = 5;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_BACK = 6;

    /**
     * Basic event IDs for form navigation, movement.
     */
    public static int EVENT_ID_ESC = 7;

    /**
     * Constructor that sets the parent handler, the message, the id, the type,
     * and the target event handler, with optional payload object.
     *
     * @param ParentHandler     The parent event handler.
     * @param Msg               The event message.
     * @param Id                The event id.
     * @param Type              The event type.
     * @param TargetHandler     The target event handler.
     * @param Ex                The payload object to pass with the event.
     */
    public MmgEvent(MmgEventHandler ParentHandler, String Msg, int Id, int Type, MmgEventHandler TargetHandler, Object Ex) {
        parentHandler = ParentHandler;
        message = Msg;
        id = Id;
        type = Type;
        targetHandler = TargetHandler;
        extra = Ex;
        prevEvent = null;
    }

    /**
     * Gets the previous event in the event sequence.
     *
     * @return      The previous event.
     */
    public MmgEvent GetPrevEvent() {
        return prevEvent;
    }

    /**
     * Sets the previous event in the event sequence.
     *
     * @param p     The previous event.
     */
    public void SetPrevEvent(MmgEvent p) {
        prevEvent = p;
    }

    /**
     * Sets the parent event handler.
     *
     * @param e     The parent event handler.
     */
    public void SetParentEventHandler(MmgEventHandler e) {
        parentHandler = e;
    }

    /**
     * Gets the parent event handler.
     *
     * @return      The parent event handler.
     */
    public MmgEventHandler GetParentEventHandler() {
        return parentHandler;
    }

    /**
     * Sets the target event handler.
     *
     * @param e     The target event handler.
     */
    public void SetTargetEventHandler(MmgEventHandler e) {
        targetHandler = e;
    }

    /**
     * Gets the target event handler.
     *
     * @return      The target event handler.
     */
    public MmgEventHandler GetTargetEventHandler() {
        return targetHandler;
    }

    /**
     * Gets the event message.
     *
     * @return      The event message.
     */
    public String GetMessage() {
        return message;
    }

    /**
     * Sets the event message.
     * 
     * @param s     The event message.
     */
    public void SetMessage(String s) {
        message = s;
    }
    
    /**
     * Gets the event id.
     *
     * @return      The event id.
     */
    public int GetEventId() {
        return id;
    }

    /**
     * Sets the event id.
     * 
     * @param s     The event id.
     */
    public void SetEventId(int s) {
        id = s;
    }

    /**
     * Gets the event type.
     *
     * @return      The event type.
     */
    public int GetEventType() {
        return type;
    }

    /**
     * Sets the event type.
     * 
     * @param s     An integer value to set the type to.
     */
    public void SetEventType(int s) {
        type = s;
    }

    /**
     * Gets the payload object.
     *
     * @return      The payload object.
     */
    public Object GetExtra() {
        return extra;
    }

    /**
     * Sets the payload object.
     * 
     * @param obj   The payload object.
     */
    public void SetExtra(Object obj) {
        extra = obj;
    }
    
    /**
     * Fires the event, calling the target event handler's MmgHandleEvent
     * method.
     */
    public void Fire() {
        if (targetHandler != null) {
            targetHandler.MmgHandleEvent(this);
        } else {
            MmgHelper.wr("cannot fire event because event handler is null");
        }
    }
    
    /**
     * An API level ToString method that returns a string representation of this class.
     * 
     * @return      A string representation of this class.
     */
    public String ApiToString() {
        return "MmgEvent: Msg: " + message + " Id: " + id + " Type: " + type;
    }
}