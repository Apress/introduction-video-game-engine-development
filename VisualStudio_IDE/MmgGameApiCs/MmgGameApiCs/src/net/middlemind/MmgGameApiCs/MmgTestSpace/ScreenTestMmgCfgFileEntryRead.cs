using System;
using System.Collections.Generic;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen class that extends the MmgGameScreen base class.
    /// This class is for testing API classes.
    /// Created by Middlemind Games 02/25/2020
    ///
    /// @author Victor G.Brusca
    /// </summary>
    public class ScreenTestMmgCfgFileEntryRead : MmgGameScreen, GenericEventHandler, MmgEventHandler
    {
        /// <summary>
        /// The game state this screen has.
        /// </summary>
        protected readonly GameStates gameState;

        /// <summary>
        /// Event handler for firing generic events. Events would fire when the
        /// screen has non UI actions to broadcast.
        /// </summary>
        protected GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen. Usually a JPanel instance that
        /// holds a reference to this game screen object.
        /// </summary>
        protected readonly GamePanel owner;

        /// <summary>
        /// An MmgFont class instance that is used to label the String value pulled from the class configuration file.
        /// </summary>
        private MmgFont cfgFileStringLabel;

        /// <summary>
        /// An MmgFont class instance that is used to label the float value pulled from the class configuration file.
        /// </summary>
        private MmgFont cfgFileFloatLabel;

        /// <summary>
        /// An MmgFont class instance that is used to label the int value pulled from the class configuration file.
        /// </summary>
        private MmgFont cfgFileIntLabel;

        /// <summary>
        /// An MmgFont class instance that is used to label the class configuration entries with information about the file used to load the values.
        /// </summary>
        private MmgFont infoLabel;

        /// <summary>
        /// An MmgFont class instance used as the title of the test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// A data structure that stores all the class configuration file entries from the target file.
        /// </summary>
        public Dictionary<string, MmgCfgFileEntry> classConfig;

        /// <summary>
        /// A bool flag indicating if there is work to do in the next MmgUpdate call.
        /// </summary>
        private bool isDirty = false;

        /// <summary>
        /// A private bool flag used in the MmgUpdate method during the update process.
        /// </summary>
        private bool lret = false;

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenTestMmgCfgFileEntryRead(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// </summary>
        /// <returns>The GenericEventHandler this screen uses to handle GenericEvents.</returns>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + GameSettings.NAME + "/screen_test_mmg_cfg_file_entry.txt");

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Cfg File Entry Read (10 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            String val = "";
            float fval = 0.0f;
            int ival = 0;

            cfgFileStringLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            if (classConfig.ContainsKey("example_string"))
            {
                val = classConfig["example_string"].str;
            }
            else
            {
                val = "Unknown Example String";
            }
            cfgFileStringLabel.SetText("Config File Entry String Value: " + val);
            MmgHelper.CenterHorAndVert(cfgFileStringLabel);
            cfgFileStringLabel.SetY(cfgFileStringLabel.GetY() - MmgHelper.ScaleValue(60));
            AddObj(cfgFileStringLabel);

            cfgFileFloatLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            if (classConfig.ContainsKey("example_float"))
            {
                fval = (float)classConfig["example_float"].number;
                val = (fval + "");
            }
            else
            {
                val = "Unknown Example Float";
            }
            cfgFileFloatLabel.SetText("Config File Entry Float Value: " + val);
            MmgHelper.CenterHorAndVert(cfgFileFloatLabel);
            cfgFileFloatLabel.SetY(cfgFileStringLabel.GetY() + MmgHelper.ScaleValue(40));
            AddObj(cfgFileFloatLabel);

            cfgFileIntLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            if (classConfig.ContainsKey("example_int"))
            {
                ival = (int)classConfig["example_int"].number;
                val = (ival + "");
            }
            else
            {
                val = "Unknown Example Integer";
            }
            cfgFileIntLabel.SetText("Config File Entry Int Value: " + val);
            MmgHelper.CenterHorAndVert(cfgFileIntLabel);
            cfgFileIntLabel.SetY(cfgFileFloatLabel.GetY() + MmgHelper.ScaleValue(40));
            AddObj(cfgFileIntLabel);

            infoLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            infoLabel.SetText("Class config loaded from: screen_test_mmg_cfg_file_entry.txt");
            MmgHelper.CenterHorAndVert(infoLabel);
            infoLabel.SetY(cfgFileIntLabel.GetY() + MmgHelper.ScaleValue(40));
            AddObj(infoLabel);

            ready = true;
            pause = false;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMousePress(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenPress");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMousePress(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenRelease");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// </summary>
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        public override bool ProcessMouseRelease(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// </summary>
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_11);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_09);

            }
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadClick(int dir)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click. 
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// </summary>
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessScreenClick");
            return true;
        }

        /// <summary>
        /// A method to handle keyboard click events.
        /// </summary>
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessKeyClick(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.ProcessKeyClick");
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);
            title = null;

            cfgFileFloatLabel = null;
            cfgFileIntLabel = null;
            cfgFileStringLabel = null;
            classConfig = null;
            infoLabel = null;

            ClearObjs();
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// </summary>
        /// <returns>The game state of this game screen.</returns>
        public virtual GameStates GetGameState()
        {
            return gameState;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// </summary>
        /// <param name="p">The MmgPen used to draw this object.</param>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// The callback method to handle GenericEventMessage objects.
        /// </summary>
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgCfgFileEntryRead.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}