package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;
import net.middlemind.MmgGameApiJava.MmgBase.MmgSplashScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgUpdateHandler;

/**
 * A game screen object, ScreenSplash, that extends the MmgGameScreen base class. 
 * This game screen is for displaying a splash screen before the game loading screen. 
 * Created by Middlemind Games 08/01/2015
 * 
 * @author Victor G. Brusca
 */
public class ScreenSplash extends MmgSplashScreen implements MmgUpdateHandler {

    /**
     * Event display time complete id.
     */
    public static int EVENT_DISPLAY_COMPLETE = 0;

    /**
     * The game state this screen has.
     */
    public GameStates state;

    /**
     * Event handler for firing generic events. 
     * Events would fire when the screen has non UI actions to broadcast.
     */
    public GenericEventHandler handler;

    /**
     * The GamePanel that owns this game screen. 
     * Usually a JPanel instance that holds a reference to this game screen object.
     */
    public GamePanel owner;

    /**
     * A data structure that stores all the class configuration file entries from the target file.
     */
    public Hashtable<String, MmgCfgFileEntry> classConfig;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State     The game state of this game screen.
     * @param Owner     The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public ScreenSplash(GameStates State, GamePanel Owner) {
        super();
        pause = false;
        ready = false;
        state = State;
        owner = Owner;
        SetUpdateHandler(this);
    }

    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler   A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        handler = Handler;
    }

    /**
     * Gets a generic event handler that will receive generic events from this object.
     * 
     * @return      A class that implements the GenericEventHandler interface.
     */
    public GenericEventHandler GetGenericEventHandler() {
        return handler;
    }
        
    /**
     * Public method that fires the local generic event, the listener will receive a display complete event.
     *
     * @param obj   The information payload to send along with this message.
     */
    @Override
    public void MmgHandleUpdate(Object obj) {
        if (handler != null) {
            handler.HandleGenericEvent(new GenericEventMessage(ScreenSplash.EVENT_DISPLAY_COMPLETE, null, GetGameState()));
        }
    }

    /**
     * Loads all the resources needed to display this game screen.
     */
    @SuppressWarnings("UnusedAssignment")
    public void LoadResources() {
        pause = true;
        SetHeight(MmgScreenData.GetGameHeight());
        SetWidth(MmgScreenData.GetGameWidth());
        SetPosition(MmgScreenData.GetPosition());

        classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + "screen_splash.txt");
        
        MmgBmp tB = null;
        String key = "";
        double scale = 1.0;
        int tmp = 0;
        String file =  "";
        
        key = "splashScreenDisplayTimeMs";
        if(classConfig.containsKey(key)) {        
            super.SetDisplayTime(classConfig.get(key).number.intValue());        
        }
        
        key = "bmpLogo";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "logo_large.jpg";
        }
            
        tB = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);        
        if (tB != null) {
            key = "splashLogoScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    tB = MmgBmpScaler.ScaleMmgBmp(tB, scale, false);
                }
            }
            
            SetCenteredBackground(tB);
            
            key = "splashLogoPosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "splashLogoPosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "splashLogoOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "splashLogoOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));                
            }            
        }

        ready = true;
        pause = false;
    }

    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        pause = true;
        SetBackground(null);
        ClearObjs();
        ready = false;
    }

    /**
     * Returns the game state of this game screen.
     *
     * @return      The game state of this game screen.
     */
    public GameStates GetGameState() {
        return state;
    }

    /**
     * The main drawing routine.
     *
     * @param p     An MmgPen object to use for drawing this game screen.
     */
    @Override
    public void MmgDraw(MmgPen p) {
        if (pause == false && isVisible == true) {
            super.MmgDraw(p);
        }
    }
}