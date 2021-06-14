package net.middlemind.MmgGameApiJava.MmgCore;

import net.middlemind.MmgGameApiJava.MmgCore.GamePanel.GameStates;
import java.util.Hashtable;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgCfgFileEntry;
import net.middlemind.MmgGameApiJava.MmgBase.MmgColor;
import net.middlemind.MmgGameApiJava.MmgBase.MmgGameScreen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgBase.MmgPen;
import net.middlemind.MmgGameApiJava.MmgBase.MmgScreenData;

/**
 * A game screen object, Screen, that extends the MmgGameScreen base class. 
 * This game screen is for displaying a main menu screen.
 * Created by Middlemind Games 03/15/2020
 * 
 * @author Victor G. Brusca
 */
public class Screen extends MmgGameScreen implements GenericEventHandler {

    /**
     * The game state this screen has.
     */
    public GameStates state;
    
    /**
     * The GamePanel that owns this game screen. 
     * Usually a JPanel instance that holds a reference to this game screen object.
     */
    public GamePanel owner;
    
    /**
     * A boolean flag that indicates if there is work to be done on the next MmgUpdate method call.
     */
    public boolean isDirty;
    
    /**
     * A private boolean flag used in the drawing routine.
     */
    private boolean lret;
    
    /**
     * A data structure that stores all the class configuration file entries from the target file.
     */
    public Hashtable<String, MmgCfgFileEntry> classConfig;
    
    /**
     * Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
     *
     * @param State         The game state of this game screen.
     * @param Owner         The owner of this game screen.
     */
    @SuppressWarnings("LeakingThisInConstructor")
    public Screen(GameStates State, GamePanel Owner) {
        super();
        isDirty = false;
        pause = false;
        ready = false;
        state = State;
        owner = Owner;
    }
    
    /**
     * A class method for handling GenericEventMessages.
     * 
     * @param obj       The GenericEventMessage to process.
     */
    @Override
    public void HandleGenericEvent(GenericEventMessage obj) {
        
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
        
        MmgBmp tB = null;
        MmgPen p;
        
        p = new MmgPen();
        p.SetCacheOn(false);
        
        tB =  MmgHelper.CreateFilledBmp(w, h, MmgColor.GetBlack());
        if (tB != null) {
            SetCenteredBackground(tB);
        }

        isDirty = true;
        ready = true;
        pause = false;
    }

    /**
     * A callback method used to process A click events.
     * 
     * @param src       The source of the A click event, keyboard, GPIO gamepad, USB gamepad.
     * @return          A boolean flag indicating if work was done.
     */
    @Override
    public boolean ProcessAClick(int src) {
        return true;
    }
    
    /**
     * A callback method used to process dpad release events.
     * 
     * @param dir       The dpad direction of the event.
     * @return          A boolean flag indicating if work was done.
     */
    @Override
    public boolean ProcessDpadRelease(int dir) {
        return true;
    }

    /**
     * Forces this screen to prepare itself for display. 
     * This is the method that handles displaying different game screen text. Calling draw screen prepares the screen for display.
     */
    public void DrawScreen() {
        pause = true;
        isDirty = false;


        pause = false;
    }

    /**
     * Unloads resources needed to display this game screen.
     */
    public void UnloadResources() {
        isDirty = false;
        pause = true;
        SetIsVisible(false);
        SetBackground(null);
        SetMenu(null);
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
     * Gets a boolean flag indicating if there is work to be done on the next MmgUpdate method call.
     * 
     * @return      A flag indicating if there is work to be done on the next MmgUpdate call.
     */
    public boolean GetIsDirty() {
        return isDirty;
    }

    /**
     * Sets a boolean flag indicating if there is work to be done on the next MmgUpdate method call.
     * 
     * @param b     A flag indicating if there is work to be done on the next MmgUpdate call.
     */
    public void SetIsDirty(boolean b) {
        isDirty = b;
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
     * Update the current sprite animation frame index.
     * 
     * @param updateTick            The index of the MmgUpdate call.
     * @param currentTimeMs         The current time in milliseconds of the MmgUpdate call.
     * @param msSinceLastFrame      The number of milliseconds since the last MmgUpdate call.
     * @return                      A boolean flag indicating if any work was done.
     */
    @Override
    public boolean MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame) {
        lret = false;

        if (pause == false && isVisible == true) {
            if (super.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true) {
                lret = true;
            }

            if (isDirty == true) {
                lret = true;
                DrawScreen();
            }
        }

        return lret;
    }
}