using System;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// The base event class for event handling. 
    /// Created by Middlemind Games 08/29/2016
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgEvent
    {
        /// <summary>
        /// The parent MmgEventHandler of this event.
        /// </summary>
        private MmgEventHandler parentHandler;

        /// <summary>
        /// The message of this event.
        /// </summary>
        private string message;

        /// <summary>
        /// The id of this event.
        /// </summary>
        private int id;

        /// <summary>
        /// The type of this event.
        /// </summary>
        private int type;

        /// <summary>
        /// The target MmgEventHandler of this event.
        /// </summary>
        private MmgEventHandler targetHandler;

        /// <summary>
        /// An extra object to pass along with the event.
        /// </summary>
        private object extra;

        /// <summary>
        /// The previous event that fired before this event, if applicable.
        /// </summary>
        private MmgEvent prevEvent;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_UP = 0;

        /// <summary>
        /// Basic event IDs for form navigation, movement. 
        /// </summary>
        public static int EVENT_ID_DOWN = 1;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_LEFT = 2;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_RIGHT = 3;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_ENTER = 4;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_SPACE = 5;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_BACK = 6;

        /// <summary>
        /// Basic event IDs for form navigation, movement.
        /// </summary>
        public static int EVENT_ID_ESC = 7;

        /// <summary>
        /// Constructor that sets the parent handler, the message, the id, the type,
        /// and the target event handler, with optional payload object.
        /// </summary>
        /// <param name="ParentHandler">The parent event handler.</param>
        /// <param name="Msg">The event message.</param>
        /// <param name="Id">The event id.</param>
        /// <param name="Type">The event type.</param>
        /// <param name="TargetHandler">The target event handler.</param>
        /// <param name="Ex">The payload object to pass with the event.</param>
        public MmgEvent(MmgEventHandler ParentHandler, string Msg, int Id, int Type, MmgEventHandler TargetHandler, object Ex)
        {
            parentHandler = ParentHandler;
            message = Msg;
            id = Id;
            type = Type;
            targetHandler = TargetHandler;
            extra = Ex;
            prevEvent = null;
        }

        /// <summary>
        /// Gets the previous event in the event sequence.
        /// </summary>
        /// <returns>The previous event.</returns>
        public virtual MmgEvent GetPrevEvent()
        {
            return prevEvent;
        }

        /// <summary>
        /// Sets the previous event in the event sequence.
        /// </summary>
        /// <param name="p">The previous event.</param>
        public virtual void SetPrevEvent(MmgEvent p)
        {
            prevEvent = p;
        }

        /// <summary>
        /// Sets the parent event handler.
        /// </summary>
        /// <param name="e">The parent event handler.</param>
        public virtual void SetParentEventHandler(MmgEventHandler e)
        {
            parentHandler = e;
        }

        /// <summary>
        /// Gets the parent event handler.
        /// </summary>
        /// <returns>The parent event handler.</returns>
        public virtual MmgEventHandler GetParentEventHandler()
        {
            return parentHandler;
        }

        /// <summary>
        /// Sets the target event handler.
        /// </summary>
        /// <param name="e">The target event handler.</param>
        public virtual void SetTargetEventHandler(MmgEventHandler e)
        {
            targetHandler = e;
        }

        /// <summary>
        /// Gets the target event handler.
        /// </summary>
        /// <returns>The target event handler.</returns>
        public virtual MmgEventHandler GetTargetEventHandler()
        {
            return targetHandler;
        }

        /// <summary>
        /// Gets the event message.
        /// </summary>
        /// <returns>The event message.</returns>
        public virtual string GetMessage()
        {
            return message;
        }

        /// <summary>
        /// Sets the event message.
        /// </summary>
        /// <param name="s">The event message.</param>
        public virtual void SetMessage(string s)
        {
            message = s;
        }

        /// <summary>
        /// Gets the event id.
        /// </summary>
        /// <returns>The event id.</returns>
        public virtual int GetEventId()
        {
            return id;
        }

        /// <summary>
        /// Sets the event id.
        /// </summary>
        /// <param name="s">The event id.</param>
        public virtual void SetEventId(int s)
        {
            id = s;
        }

        /// <summary>
        /// Gets the event type.
        /// </summary>
        /// <returns>The event type.</returns>
        public virtual int GetEventType()
        {
            return type;
        }

        /// <summary>
        /// Sets the event type.
        /// </summary>
        /// <param name="s">An integer value to set the type to.</param>
        public virtual void SetEventType(int s)
        {
            type = s;
        }

        /// <summary>
        /// Gets the payload object.
        /// </summary>
        /// <returns>The payload object.</returns>
        public virtual object GetExtra()
        {
            return extra;
        }

        /// <summary>
        /// Sets the payload object.
        /// </summary>
        /// <param name="obj">The payload object.</param>
        public virtual void SetExtra(object obj)
        {
            extra = obj;
        }

        /// <summary>
        /// Fires the event, calling the target event handler's MmgHandleEvent method.
        /// </summary>
        public virtual void Fire()
        {
            if (targetHandler != null)
            {
                targetHandler.MmgHandleEvent(this);
            }
            else
            {
                MmgHelper.wr("cannot fire event because event handler is null");
            }
        }

        /// <summary>
        /// An API level ToString method that returns a string representation of this class.
        /// </summary>
        /// <returns>A string representation of this class.</returns>
        public string ApiToString()
        {
            return "MmgEvent: Msg: " + message + " Id: " + id + " Type: " + type;
        }
    }
}