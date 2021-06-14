package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * Class template for handling update events.
 * Created by Middlemind Games 06/01/2005
 *
 * @author Victor G. Brusca
 */
public interface MmgUpdateHandler {

    /**
     * Handle the incoming update event.
     *
     * @param obj   The update event object.
     */
    public void MmgHandleUpdate(Object obj);
}