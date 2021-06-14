using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen class that : the MmgGameScreen base class.
    /// This class is for testing API classes.
    /// Created by Middlemind Games 02/25/2020
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    public class ScreenTestMmgSound : MmgGameScreen, GenericEventHandler, MmgEventHandler
    {

        /// <summary>
        /// The game state this screen has.
        /// </summary>
        protected readonly GameStates gameState;

        /// <summary>
        /// Event handler for firing generic events.
        /// Events would fire when the screen has non UI actions to broadcast.
        /// </summary>
        protected GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen.
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        protected readonly GamePanel owner;

        /// <summary>
        /// A MmgSound class instance used to play a sound on this test game screen.
        /// </summary>
        private MmgSound sound1;

        /// <summary>
        /// A MmgSound class instance used to play a sound on this test game screen.
        /// </summary>
        private MmgSound sound2;

        /// <summary>
        /// An MmgFont class instance used to provide information on how to play a sound on this test game screen.
        /// </summary>
        private MmgFont soundLabel1;

        /// <summary>
        /// An MmgFont class instance used to provide information on how to play a sound on this test game screen.
        /// </summary>
        private MmgFont soundLabel2;

        /// <summary>
        /// An MmgFont class instance used as the title for the test game screen.
        /// </summary>
        private MmgFont title;

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
        /// 
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        /// </summary>
        public ScreenTestMmgSound(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgSound.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// 
        /// <param name="Handler">A class that , the GenericEventHandler interface.</param>
        /// </summary>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgSound.SetGenericEventHandler");
            handler = Handler;
        }

        /// <summary>
        /// Gets the GenericEventHandler this game screen uses to handle GenericEvents.
        /// 
        /// <returns>The GenericEventHandler this screen uses to handle GenericEvents.</returns>
        /// </summary>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Loads all the resources needed to display this game screen.
        /// </summary>
        public virtual void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgSound.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Sound (6 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            sound1 = MmgHelper.GetBasicCachedSound("jump1.wav");
            sound2 = MmgHelper.GetBasicCachedSound("jump2.wav");

            soundLabel1 = MmgFontData.CreateDefaultBoldMmgFontLg();
            soundLabel1.SetText("MmgSound Example");
            MmgHelper.CenterHorAndVert(soundLabel1);
            soundLabel1.SetY(soundLabel1.GetY() - MmgHelper.ScaleValue(20));
            AddObj(soundLabel1);

            soundLabel2 = MmgFontData.CreateDefaultBoldMmgFontLg();
            soundLabel2.SetText("Press Enter or Space to Play a Sound");
            MmgHelper.CenterHorAndVert(soundLabel2);
            soundLabel2.SetY(soundLabel2.GetY() + MmgHelper.ScaleValue(20));
            AddObj(soundLabel2);

            ready = true;
            pause = false;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMousePress(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessScreenPress");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="x">The X coordinate of the mouse.</param>
        /// <param name="y">The Y coordinate of the mouse.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMousePress(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessScreenPress");
            return true;
        }

        /// <summary>
        /// Expects a relative X, Y vector that takes into account the game's offset and the current panel's
        /// offset.
        /// 
        /// <param name="v">The coordinates of the mouse event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMouseRelease(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessScreenRelease");
            return ProcessMousePress(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Expects a relative X, Y values that takes into account the game's offset and the current panel's offset.
        /// 
        /// <param name="x">The X coordinate of the event.</param>
        /// <param name="y">The Y coordinate of the event.</param>
        /// <returns>A bool indicating if the event was handled or not.</returns>
        /// </summary>
        public override bool ProcessMouseRelease(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessScreenRelease");
            return true;
        }

        /// <summary>
        /// A method to handle A click events.
        /// 
        /// <param name="src">The source gamepad, keyboard of the A event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessAClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessAClick");
            return true;
        }

        /// <summary>
        /// A method to handle B click events.
        /// 
        /// <param name="src">The source gamepad, keyboard of the B event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessBClick(int src)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessDpadPress: " + dir);
            return true;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_07);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_05);

            }
            return true;
        }

        /// <summary>
        /// A method to handle dpad click events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadClick(int dir)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>bool indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessScreenClick");
            return true;
        }

        /// <summary>
        /// A method to handle keyboard click events.
        /// 
        /// <param name="c">The key used in the event.</param>
        /// <param name="code">The code of the key used in the event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessKeyClick(char c, int code)
        {
            MmgHelper.wr("ScreenTestMmgSound.ProcessKeyClick: Char: " + c + " Code: " + code);
            if (c == '\n')
            {
                sound1.Play();

            }
            else if (c == ' ')
            {
                sound2.Play();

            }
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            sound1 = null;
            sound2 = null;
            title = null;
            soundLabel1 = null;
            soundLabel2 = null;

            ClearObjs();
            ready = false;
        }

        /// <summary>
        /// Returns the game state of this game screen.
        /// 
        /// <returns>The game state of this game screen.</returns>
        /// </summary>
        public virtual GameStates GetGameState()
        {
            return gameState;
        }

        /// <summary>
        /// Base draw method, handles drawing this class.
        /// 
        /// <param name="p">The MmgPen used to draw this object.</param>
        /// </summary>
        public override void MmgDraw(MmgPen p)
        {
            if (pause == false && isVisible == true)
            {
                base.MmgDraw(p);
            }
        }

        /// <summary>
        /// The callback method to handle GenericEventMessage objects.
        /// 
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        /// </summary>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTestMmgSound.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// 
        /// <param name="e">An MmgEvent object instance to process.</param>
        /// </summary>
        //     @Override
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgSound.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}