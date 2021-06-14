package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgCore.GamePanel;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventMessage;
import net.middlemind.MmgGameApiJava.MmgCore.GenericEventHandler;

/**
 * An application specific extension of the MmgCore API's ScreenSplash class.
 * Created by Middlemind Games 02/19/2020
 * 
 * @author Victor G. Brusca, Middlemind Games
 */
public class ScreenSplash extends net.middlemind.MmgGameApiJava.MmgCore.ScreenSplash {
    
    /**
     * The default constructor that takes a GameStates enumeration entry and an instance of the GamePanel that will display this screen.
     * 
     * @param State     The GameStates enumeration entry associated with this game screen.
     * @param Owner     The GamePanel that will display this game screen.
     */
    public ScreenSplash(GamePanel.GameStates State, GamePanel Owner) {
        super(State, Owner);
    }
  
    /**
     * Sets the GenericEventHandler for this class.
     * 
     * @param Handler       The GenericEventHandler for this class.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        MmgHelper.wr("ScreenSplash.SetGenericEventHandler");
        handler = Handler;
    }    
    
    /**
     * A method to handle update calls from the MmgCore API's ScreenPlash class.
     * 
     * @param obj 
     */
    @Override
    public void MmgHandleUpdate(Object obj) {
        MmgHelper.wr("ScreenSplash.MmgHandleUpdate");
        if (handler != null) {
            handler.HandleGenericEvent(new GenericEventMessage(net.middlemind.MmgGameApiJava.MmgCore.ScreenSplash.EVENT_DISPLAY_COMPLETE, null, GetGameState()));
        }
    }    
}