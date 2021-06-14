package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import java.io.File;
import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp.MmgBmpDrawMode;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgLoadingBar;
import net.middlemind.MmgGameApiJava.MmgBase.MmgLoadingScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;

/**
 * A game screen object, ScreenLoading, that extends the MmgLoadingScreen base class. 
 * This game screen is for displaying a loading screen.
 * Created by Middlemind Games 08/01/2015
 *
 * @author Victor G. Brusca
 */
public class ScreenLoading extends MmgLoadingScreen implements LoadResourceUpdateHandler {

    /**
     * Event load complete id.
     */
    public static int EVENT_LOAD_COMPLETE = 0;

    /**
     * Wrapper class for running a worker thread.
     */
    public RunResourceLoad datLoad;

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
     * A timing value in milliseconds used to slow down the resource loading process when there are few resources to load.
     */
    public long slowDown;
    
    /**
     * A data structure that stores all the class configuration file entries from the target file.
     */
    public Hashtable<String, MmgCfgFileEntry> classConfig;   
    
    /**
     * Constructor, sets the loading bar, the loading bar offset, the game state of this game screen, and the GamePanel that owns this game screen.
     *
     * @param LoadingBar    A loading bar object, MmgLoadingBar, to use as this screen's loading bar.
     * @param lBarOff       An offset used in drawing the loading bar.
     * @param State         The game state of this game screen.
     * @param Owner         The owner of this game screen.
     */
    public ScreenLoading(MmgLoadingBar LoadingBar, float lBarOff, GameStates State, GamePanel Owner) {
        super(LoadingBar, lBarOff);
        pause = false;
        ready = false;
        state = State;
        owner = Owner;
        slowDown = 0;
    }

    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State     The game state of this game screen.
     * @param Owner     The owner of this game screen.
     */
    public ScreenLoading(GameStates State, GamePanel Owner) {
        pause = false;
        ready = false;
        state = State;
        owner = Owner;
        slowDown = 0;
    }

    /**
     * Gets the slow down value that will slow down the loading process when there are only a few resources to load.
     * 
     * @return      The slow down time in milliseconds.
     */
    public long GetSlowDown() {
        return slowDown;
    }

    /**
     * Sets the slow down value that will slow down the loading process when there are only a few resources to load.
     * 
     * @param l     The slow down time in milliseconds.
     */
    public void SetSlowDown(long l) {
        slowDown = l;
    }
   
    /**
     * Sets a generic event handler that will receive generic events from this object.
     *
     * @param Handler       A class that implements the GenericEventHandler interface.
     */
    public void SetGenericEventHandler(GenericEventHandler Handler) {
        handler = Handler;
    }

    /**
     * Gets the generic event handler.
     * 
     * @return      The generic event handler.
     */
    public GenericEventHandler GetGenericEventHandler() {
        return handler;
    }

    /**
     * Gets the resource loader that handles actually loading resources.
     * 
     * @return      The resource loader.
     */
    public RunResourceLoad GetLoader() {
        return datLoad;
    }

    /**
     * Sets the resource loader that handles actually loading resources.
     * 
     * @param DatLoad       The resource loader.
     */
    public void SetLoader(RunResourceLoad DatLoad) {
        datLoad = DatLoad;
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

        classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + "screen_loading.txt");        
        
        MmgBmp tB = null;
        MmgBmp tB1 = null;        
        MmgLoadingBar lb = null;
        int lbOffSet = MmgHelper.ScaleValue(5);
        String key = "";
        double scale = 1.0;
        int tmp = 0;
        String file = "";
        
        key = "loadingLogoSlowDown";
        if(classConfig.containsKey(key)) {
            slowDown = classConfig.get(key).number.intValue();
        }        
        
        key = "bmpLogo";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "odroid_logo2.png";
        }        
        
        tB = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);
        if (tB != null) {
            tB = MmgBmpScaler.ScaleMmgBmp(tB, 0.5, true);                    
            
            key = "loadingLogoScale";
            if(classConfig.containsKey(key)) {
                scale = classConfig.get(key).number.doubleValue();
                if(scale != 1.0) {
                    tB = MmgBmpScaler.ScaleMmgBmp(tB, scale, false);
                }
            }
            
            SetCenteredBackground(tB);
            
            key = "loadingLogoPosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "loadingLogoPosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));                
            }            
            
            key = "loadingLogoOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
            }
            
            key = "loadingLogoOffsetX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));                
            }
        }
                
        key = "imgLoadingBar";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "loading_bar.png";
        }
        
        tB = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);
        
        key = "imgLoadingBarFill";
        if(classConfig.containsKey(key)) {
            file = classConfig.get(key).str;
        } else {
            file = "blue_square.png";
        }                
        
        tB1 = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);
        if (tB1 != null) {
            tB1.DRAW_MODE = MmgBmpDrawMode.DRAW_BMP_FULL;
        }
        
        if (tB != null && tB1 != null) {
            lb = new MmgLoadingBar(tB1, tB);
            lb.SetMmgColor(null);
            lb.SetWidth(tB.GetWidth() - MmgHelper.ScaleValue(10));
            lb.SetHeight(tB.GetHeight() - MmgHelper.ScaleValue(12));
            lb.SetFillAmt(0.0f);
            lb.SetPaddingX(MmgHelper.ScaleValue(8));
            lb.SetPaddingY(MmgHelper.ScaleValue(4));
            lb.SetFillHeight(tB.GetHeight() - MmgHelper.ScaleValue(10));
            lb.SetFillWidth(tB.GetWidth() - MmgHelper.ScaleValue(12));
            super.SetLoadingBar(lb, lbOffSet);
                        
            MmgHelper.CenterHorAndVert(lb);
            
            key = "loadingBarPosY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();
                GetLoadingBar().GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "loadingBarPosX";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                GetLoadingBar().GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "loadingBarOffsetY";
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                GetLoadingBar().GetPosition().SetY(GetLoadingBar().GetY() + MmgHelper.ScaleValue(tmp));                
            }
            
            key = "loadingBarOffsetX";            
            if(classConfig.containsKey(key)) {
                tmp = classConfig.get(key).number.intValue();                
                GetLoadingBar().GetPosition().SetX(GetLoadingBar().GetX() + MmgHelper.ScaleValue(tmp));                
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
        SetLoadingBar(null, 0f);
        SetBackground(null);
        ClearObjs();
        datLoad = null;
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

    /**
     * Loads the DAT file data from the file system.
     *
     * @return      A byte array representation of the DAT file.
     */
    public boolean GetResourceFileData() {
        try {
            File ald = new File(GameSettings.AUTO_IMAGE_LOAD_DIR);
            File[] files = ald.listFiles();
            
            if(files != null && files.length > 0) {
                return true;
            } else {
                ald = new File(GameSettings.AUTO_SOUND_LOAD_DIR);
                files = ald.listFiles();
                
                if(files != null && files.length > 0) {
                    return true;
                } else {
                    ald = new File(GameSettings.PROGRAM_IMAGE_LOAD_DIR);
                    files = ald.listFiles();
                    
                    if(files != null && files.length > 0) {
                        return true;
                    } else {
                        ald = new File(GameSettings.PROGRAM_SOUND_LOAD_DIR);
                        files = ald.listFiles();

                        if(files != null && files.length > 0) {
                            return true;
                        }
                    }
                }
            }            
        } catch (Exception e) {
            MmgHelper.wrErr(e);
        }

        return false;
    }

    /**
     * Starts the DAT loading worker thread.
     */
    public void StartDatLoad() {
        if (GetResourceFileData()) {
            datLoad = new RunResourceLoad();
            datLoad.SetSlowDown(slowDown);
            datLoad.SetUpdateHandler(this);

            Runnable r = datLoad;
            Thread t = new Thread(r);
            t.start();
        } else {
            MmgHelper.wr("ScreenLoading: StartDatLoad: No data found to load!!");
        }
    }

    /**
     * Stops the DAT load process.
     */
    public void StopDatLoad() {
        if (datLoad != null) {
            datLoad.StopLoad();
        }
    }

    /**
     * Handles load DAT update events, LoadDatUpdateMessage. 
     * Fires a generic event when the load has completed.
     *
     * @param obj       The load DAT update message sent.
     */
    @Override
    public void HandleUpdate(LoadResourceUpdateMessage obj) {
        if (obj != null) {
            float prct = (float) obj.GetPos() / (float) obj.GetLen();

            if (GetLoadingBar() != null) {
                GetLoadingBar().SetFillAmt(prct);
            }

            if (GetLoadComplete() == true) {
                if (handler != null) {
                    handler.HandleGenericEvent(new GenericEventMessage(ScreenLoading.EVENT_LOAD_COMPLETE, null, GetGameState()));
                }
            }
            
            MmgHelper.wr("LoadingScreen: POS: " + obj.GetPos() + " LEN: " + obj.GetLen() + " PRCT: " + prct + " LR: " + GetLoadResult() + " LC: " + GetLoadComplete());
        }
    }

    /**
     * Gets the DAT read result value.
     *
     * @return      True if the read was successful, false otherwise.
     */
    public boolean GetLoadResult() {
        if (datLoad != null) {
            return datLoad.GetReadResult();
        } else {
            MmgHelper.wr("ScreenLoading: GetLoadResult: The datLoad field is NULL!!");
            return false;
        }
    }

    /**
     * Gets the DAT load complete value.
     *
     * @return      True if the load was successful, false otherwise.
     */
    public boolean GetLoadComplete() {
        if (datLoad != null) {
            return datLoad.GetReadComplete();
        } else {
            MmgHelper.wr("ScreenLoading: GetLoadComplete: The datLoad field is NULL!!");
            return false;
        }
    }
}