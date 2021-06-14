using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A game screen object, Screen, that extends the MmgGameScreen base class. 
    /// This game screen is for displaying a main menu screen.
    /// Created by Middlemind Games 03/15/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class Screen : MmgGameScreen, GenericEventHandler
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        public GameStates state;

        /// <summary>
        /// The GamePanel that owns this game screen. 
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        public GamePanel owner;

        /// <summary>
        /// A bool flag that indicates if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        public bool isDirty;

        /// <summary>
        /// A bool flag that indicates if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        private bool lret;

        /// <summary>
        /// A data structure that stores all the class configuration file entries from the target file.
        /// </summary>
        public Dictionary<string, MmgCfgFileEntry> classConfig;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public Screen(GameStates State, GamePanel Owner) : base()
        {
            isDirty = false;
            pause = false;
            ready = false;
            state = State;
            owner = Owner;
        }

        /// <summary>
        /// A class method for handling GenericEventMessages.
        /// </summary>
        /// <param name="obj">The GenericEventMessage to process.</param>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {

        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            MmgBmp tB = null;
            MmgPen p;

            p = new MmgPen();
            p.SetCacheOn(false);

            tB = MmgHelper.CreateFilledBmp(w, h, MmgColor.GetBlack());
            if (tB != null)
            {
                SetCenteredBackground(tB);
            }

            isDirty = true;
            ready = true;
            pause = false;
        }

        /// <summary>
        /// A callback method used to process A click events.
        /// </summary>
        /// <param name="src">The source of the A click event, keyboard, GPIO gamepad, USB gamepad.</param>
        /// <returns>A bool flag indicating if work was done.</returns>
        public override bool ProcessAClick(int src)
        {
            return true;
        }

        /// <summary>
        /// A callback method used to process dpad release events.
        /// </summary>
        /// <param name="dir">The dpad direction of the event.</param>
        /// <returns>A bool flag indicating if work was done.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            return true;
        }

        /// <summary>
        /// Forces this screen to prepare itself for display. 
        /// This is the method that handles displaying different game screen text.Calling draw screen prepares the screen for display.
        /// </summary>
        public virtual void DrawScreen()
        {
            pause = true;
            isDirty = false;


            pause = false;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            isDirty = false;
            pause = true;
            SetIsVisible(false);
            SetBackground(null);
            SetMenu(null);
            ClearObjs();

            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// </summary>
        /// <returns>The game state of this game screen.</returns>
        public virtual GameStates GetGameState()
        {
            return state;
        }

        /// <summary>
        /// Gets a bool flag indicating if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        /// <returns>A flag indicating if there is work to be done on the next MmgUpdate call.</returns>
        public virtual bool GetIsDirty()
        {
            return isDirty;
        }

        /// <summary>
        /// Sets a bool flag indicating if there is work to be done on the next MmgUpdate method call.
        /// </summary>
        /// <param name="b">A flag indicating if there is work to be done on the next MmgUpdate call.</param>
        public virtual void SetIsDirty(bool b)
        {
            isDirty = b;
        }

        /// <summary>
        /// The main drawing routine.
        /// </summary>
        /// <param name="p">An MmgPen object to use for drawing this game screen.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// Update the current sprite animation frame index.
        /// </summary>
        /// <param name="updateTick">The index of the MmgUpdate call.</param>
        /// <param name="currentTimeMs">The current time in milliseconds of the MmgUpdate call.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds since the last MmgUpdate call.</param>
        /// <returns>A bool flag indicating if any work was done.</returns>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                if (base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                {
                    lret = true;
                }

                if (isDirty == true)
                {
                    lret = true;
                    DrawScreen();
                }
            }

            return lret;
        }
    }
}
