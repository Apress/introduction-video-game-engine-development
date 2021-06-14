package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * The base event handler class for event passing. 
 * Created by Middlemind Games 08/29/2016
 *
 * @author Victor G. Brusca
 */
public interface MmgEventHandler {
    
    /**
     * Handles an MmgEvent object.
     *
     * @param e     The event to handle.
     */
    public void MmgHandleEvent(MmgEvent e);
}