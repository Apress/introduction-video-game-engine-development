package net.middlemind.MmgGameApiJava.MmgCore;

/**
 * The GamePadSimple interface is an interface for routing simple gamepad input.
 * The interface is designed to handle direction pad input with press, release, click
 * methods, and A, B, button input with press, release, click methods.
 * Created by Middlemind Games 01/05/2020
 * 
 * @author Victor G. Brusca
 */
public interface GamePadSimple {
    
    /**
     * The ProcessDpadPress method is designed to handle dpad press events and takes a direction code as input.
     * 
     * @param dir       The dir argument is the code for the dpad direction pressed.
     */
    public void ProcessDpadPress(int dir);
    
    /**
     * The ProcessDpadRelease method is designed to handle dpad release events and takes a direction code as input.
     * 
     * @param dir       The dir argument is the code for the dpad direction released.
     */
    public void ProcessDpadRelease(int dir);
    
    /**
     * The ProcessDpadClick method is designed to handle dpad click events and takes a direction code as input.
     * 
     * @param dir       The dir argument is the code for the dpad direction clicked.
     */    
    public void ProcessDpadClick(int dir);
    
    /**
     * The ProcessAPress method is designed to handle A button press events.
     */
    public void ProcessAPress(int src);
    
    /**
     * The ProcessARelease method is designed to handle A button release events.
     */
    public void ProcessARelease(int src);
    
    /**
     * The ProcessAClick method is designed to handle A button click events.
     */
    public void ProcessAClick(int src);
    
    /**
     * The ProcessBPress method is designed to handle B button press events.
     */
    public void ProcessBPress(int src);
    
    /**
     * The ProcessBRelease method is designed to handle B button release events.
     */
    public void ProcessBRelease(int src);
    
    /**
     * The ProcessBClick method is designed to handle B button click events.
     */
    public void ProcessBClick(int src);
}