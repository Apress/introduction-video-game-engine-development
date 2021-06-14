package net.middlemind.MmgGameApiJava.MmgCore;

/**
 * A class that wraps the LoadDat update information.
 * Created by Middlemind Games 01/22/2020
 * 
 * @author Victor G. Brusca
 */
public class LoadResourceUpdateMessage {
    
    /**
     * The current position of the DAT load process.
     */
    public int pos;
    
    /**
     * The length of the DAT binary array.
     */
    public int len;
   
    /**
     * Class constructor sets the current position and the current length of the data.
     * 
     * @param Pos       The current position of the DAT load process.
     * @param Len       The length of the DAT binary array.
     */
    public LoadResourceUpdateMessage(int Pos, int Len) {
        pos = Pos;
        len = Len;
    }

    /**
     * Getter for the read position.
     * 
     * @return      The read position.
     */
    public int GetPos() {
        return pos;
    }

    /**
     * Setter for the read position.
     * 
     * @param pos   Sets the read position.
     */
    public void SetPos(int Pos) {
        pos = Pos;
    }

    /**
     * Getter for the total data length.
     * 
     * @return      The total data length.
     */
    public int GetLen() {
        return len;
    }

    /**
     * Setter for the total data length.
     * 
     * @param len   The total data length.
     */
    public void SetLen(int Len) {
        len = Len;
    }  
}