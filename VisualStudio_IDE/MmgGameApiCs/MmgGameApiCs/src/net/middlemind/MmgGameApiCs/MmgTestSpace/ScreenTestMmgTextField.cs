using System;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgTestSpace
{
    /// <summary>
    /// A game screen object, ScreenTest, that : the MmgGameScreen base class.
    /// This class is for testing new UI widgets, etc.
    /// Created by Middlemind Games 02/25/2020
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    public class ScreenTestMmgTextField : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgBmp class instance used as the background for the MmgTextField test object.
        /// </summary>
        private MmgBmp bground;

        /// <summary>
        /// An MmgTextField class instance used as the example object in this test game screen.
        /// </summary>
        private MmgTextField txtField;

        /// <summary>
        /// An MmgFont class instance used as a label for the text field.
        /// </summary>
        private MmgFont txtFieldLabel;

        /// <summary>
        /// An MmgFont class instance used as a label for the maximum length of the text field.
        /// </summary>
        private MmgFont maxLenLabel;

        /// <summary>
        /// An MmgFont class instance that displays the text held by the MmgTextField.
        /// </summary>
        private MmgFont txtFieldText;

        /// <summary>
        /// An MmgFont class instance that displays error information when a maximum length error occurs in the MmgTextField test object.
        /// </summary>
        private MmgFont txtFieldMaxLenError;

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
        public ScreenTestMmgTextField(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMsgTextField.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// 
        /// <param name="Handler">A class that , the GenericEventHandler interface.</param>
        /// </summary>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMsgTextField.SetGenericEventHandler");
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
            MmgHelper.wr("ScreenTestMsgTextField.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            int width = MmgHelper.ScaleValue(256);
            int height = MmgHelper.ScaleValue(50);

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Text Field (4 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            bground = MmgHelper.GetBasicCachedBmp("popup_window_base.png");

            //Monogame implementation adjustment
            int adj = MmgHelper.ScaleValue(4);
            txtField = new MmgTextField(bground, MmgFontData.CreateDefaultMmgFontLg(), width, height, MmgHelper.ScaleValue(12) + adj, 15);
            MmgHelper.CenterHorAndVert(txtField);
            txtField.SetMaxLengthOn(true);
            txtField.SetEventHandler(this);
            txtField.SetY(txtField.GetY() - MmgHelper.ScaleValue(30));
            AddObj(txtField);

            txtFieldLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtFieldLabel.SetText("MmgTextField Example");
            MmgHelper.CenterHorAndVert(txtFieldLabel);
            txtFieldLabel.SetY(txtFieldLabel.GetY() - MmgHelper.ScaleValue(55));
            AddObj(txtFieldLabel);

            txtFieldText = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtFieldText.SetText("Text Field Text: ");
            MmgHelper.CenterHorAndVert(txtFieldText);
            txtFieldText.SetY(txtFieldText.GetY() + MmgHelper.ScaleValue(40));
            AddObj(txtFieldText);

            maxLenLabel = MmgFontData.CreateDefaultBoldMmgFontLg();
            maxLenLabel.SetText("Max Len Error On: " + txtField.GetMaxLengthOn() + " Max Len: " + MmgTextField.DEFAULT_MAX_LENGTH);
            MmgHelper.CenterHorAndVert(maxLenLabel);
            maxLenLabel.SetY(maxLenLabel.GetY() + MmgHelper.ScaleValue(70));
            AddObj(maxLenLabel);

            txtFieldMaxLenError = MmgFontData.CreateDefaultBoldMmgFontLg();
            txtFieldMaxLenError.SetText("Max Len Error Current Time MS: ");
            MmgHelper.CenterHorAndVert(txtFieldMaxLenError);
            txtFieldMaxLenError.SetY(txtFieldMaxLenError.GetY() + MmgHelper.ScaleValue(100));
            AddObj(txtFieldMaxLenError);

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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenPress");
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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenRelease");
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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessAClick");
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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessBClick");
            return true;
        }

        /// <summary>
        /// A method to handle special debug events that can be customized for each game.
        /// </summary>
        public override void ProcessDebugClick()
        {
            MmgHelper.wr("ScreenTestMsgTextField.ProcessDebugClick");
        }

        /// <summary>
        /// A method to handle dpad press events.
        /// 
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        /// </summary>
        public override bool ProcessDpadPress(int dir)
        {
            MmgHelper.wr("ScreenTestMsgTextField.ProcessDpadPress: " + dir);
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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_05);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_03);

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
            MmgHelper.wr("ScreenTestMsgTextField.ProcessDpadClick: " + dir);
            return true;
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="v">The coordinates of the click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(MmgVector2 v)
        {
            MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenClick");
            return ProcessMouseClick(v.GetX(), v.GetY());
        }

        /// <summary>
        /// Process a screen click.
        /// Expects coordinate that don't take into account the offset of the game and panel.
        /// 
        /// <param name="x">The X axis coordinate of the screen click.</param>
        /// <param name="y">The Y axis coordinate of the screen click.</param>
        /// <returns>Boolean indicating if a menu item was the target of the click, menu item event is fired automatically by this class.</returns>
        /// </summary>
        public override bool ProcessMouseClick(int x, int y)
        {
            MmgHelper.wr("ScreenTestMsgTextField.ProcessScreenClick");
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
            if (Char.IsLetter(c) || Char.IsDigit(c))
            {
                txtField.ProcessKeyClick(c, code);
            }
            else if (code == 8)
            {
                txtField.DeleteChar();
            }
            txtFieldText.SetText("Text Field Text: " + txtField.GetTextFieldString());
            MmgHelper.CenterHor(txtFieldText);
            return true;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen.
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetBackground(null);

            bground = null;
            txtField = null;
            title = null;
            txtFieldLabel = null;
            txtFieldMaxLenError = null;
            txtFieldText = null;

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
        /// The MmgUpdate method used to call the update method of the child objects.
        /// 
        /// <param name="updateTicks">The update tick number.</param>
        /// <param name="currentTimeMs">The current time in the game in milliseconds.</param>
        /// <param name="msSinceLastFrame">The number of milliseconds between the last frame and this frame.</param>
        /// <returns>A bool indicating if any work was done this game frame.</returns>
        /// </summary>
        public override bool MmgUpdate(int updateTick, long currentTimeMs, long msSinceLastFrame)
        {
            lret = false;

            if (pause == false && isVisible == true)
            {
                //always run this update
                txtField.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);

                if (isDirty == true)
                {
                    base.GetObjects().SetIsDirty(true);

                    if (base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame) == true)
                    {
                        lret = true;
                    }
                }
            }

            return lret;
        }

        /// <summary>
        /// The callback method to handle GenericEventMessage objects.
        /// 
        /// <param name="obj">A GenericEventMessage object instance to process.</param>
        /// </summary>
        public virtual void HandleGenericEvent(GenericEventMessage obj)
        {
            MmgHelper.wr("ScreenTestMsgTextField.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// 
        /// <param name="e">An MmgEvent object instance to process.</param>
        /// </summary>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMsgTextField.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
            if (e.GetMessage() != null && e.GetMessage().Equals("error_max_length") == true)
            {
                txtFieldMaxLenError.SetText("Max Len Error Current Time MS: " + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                MmgHelper.CenterHor(txtFieldMaxLenError);
            }
        }
    }
}