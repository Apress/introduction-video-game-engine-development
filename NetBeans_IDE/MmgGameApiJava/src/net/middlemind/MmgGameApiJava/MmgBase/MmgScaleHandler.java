package net.middlemind.MmgGameApiJava.MmgBase;

/**
 * A class that handles scaling requests from a running MmgSizeTween object.
 * Created by Middlemind Games 09/14/2020
 *
 * @author Victor G. Brusca
 */
public interface MmgScaleHandler {

    /**
     * A method to handle an image scaling request in response to MmgSizeTween events.
     * 
     * @param v     The vector that describes how much to scale the MmgObj in each direction.
     * @param orig  The MmgObj to be scaled.    
     */
    public void MmgHandleScale(MmgVector2 v, MmgObj orig);
}