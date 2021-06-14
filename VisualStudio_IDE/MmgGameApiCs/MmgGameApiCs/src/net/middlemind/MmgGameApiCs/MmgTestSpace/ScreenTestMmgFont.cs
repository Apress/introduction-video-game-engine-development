using System;
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
    public class ScreenTestMmgFont : MmgGameScreen, GenericEventHandler, MmgEventHandler
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
        /// An MmgFont class instance that is used as the title for this test game screen.
        /// </summary>
        private MmgFont title;

        /// <summary>
        /// An MmgFont class instance that is used as an example of bold large text.
        /// </summary>
        private MmgFont fontBoldLg;

        /// <summary>
        /// An MmgFont class instance that is used as an example of bold medium text.
        /// </summary>
        private MmgFont fontBoldMd;

        /// <summary>
        /// An MmgFont class instance that is used as an example of bold small text.
        /// </summary>
        private MmgFont fontBoldSm;

        /// <summary>
        /// An MmgFont class instance that is used as an example of normal large text.
        /// </summary>
        private MmgFont fontNormLg;

        /// <summary>
        /// An MmgFont class instance that is used as an example of normal medium text.
        /// </summary>
        private MmgFont fontNormMd;

        /// <summary>
        /// An MmgFont class instance that is used as an example of normal small text.
        /// </summary>
        private MmgFont fontNormSm;

        /// <summary>
        /// An MmgFont class instance that is used as an example of italic large text.
        /// </summary>
        private MmgFont fontItalicLg;

        /// <summary>
        /// An MmgFont class instance that is used as an example of italic medium text.
        /// </summary>
        private MmgFont fontItalicMd;

        /// <summary>
        /// An MmgFont class instance that is used as an example of italic small text.
        /// </summary>
        private MmgFont fontItalicSm;

        /// <summary>
        /// An MmgFont class instance that is used as an example of custom large text.
        /// </summary>
        private MmgFont fontCustomLg;

        /// <summary>
        /// An MmgFont class instance that is used as an example of custom medium text.
        /// </summary>
        private MmgFont fontCustomMd;

        /// <summary>
        /// An MmgFont class instance that is used as an example of custom small text.
        /// </summary>
        private MmgFont fontCustomSm;

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
        public ScreenTestMmgFont(GameStates State, GamePanel Owner) : base()
        {
            pause = false;
            ready = false;
            gameState = State;
            owner = Owner;
            MmgHelper.wr("ScreenTestMmgFont.Constructor");
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            MmgHelper.wr("ScreenTestMmgFont.SetGenericEventHandler");
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
        public void LoadResources()
        {
            MmgHelper.wr("ScreenTestMmgFont.LoadResources");
            pause = true;
            SetHeight(MmgScreenData.GetGameHeight());
            SetWidth(MmgScreenData.GetGameWidth());
            SetPosition(MmgScreenData.GetPosition());

            int y = MmgHelper.ScaleValue(60);

            title = MmgFontData.CreateDefaultBoldMmgFontLg();
            title.SetText("<  Screen Test Mmg Font (3 / " + GamePanel.TOTAL_TESTS + ")  >");
            MmgHelper.CenterHorAndTop(title);
            title.SetY(title.GetY() + MmgHelper.ScaleValue(30));
            AddObj(title);

            fontBoldLg = MmgFontData.CreateDefaultBoldMmgFontLg();
            fontBoldLg.SetText("Font Bold Large");
            fontBoldLg.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 1));
            fontBoldLg.SetX(y);
            AddObj(fontBoldLg);

            fontBoldMd = MmgFontData.CreateDefaultBoldMmgFont(title.GetFontSize() - MmgHelper.ScaleValue(2));
            fontBoldMd.SetText("Font Bold Medium");
            fontBoldMd.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 2));
            fontBoldMd.SetX(y);
            AddObj(fontBoldMd);

            fontBoldSm = MmgFontData.CreateDefaultBoldMmgFontSm();
            fontBoldSm.SetText("Font Bold Small");
            fontBoldSm.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 3));
            fontBoldSm.SetX(y);
            AddObj(fontBoldSm);

            fontNormLg = MmgFontData.CreateDefaultMmgFontLg();
            fontNormLg.SetText("Font Norm Large");
            fontNormLg.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 4));
            fontNormLg.SetX(y);
            AddObj(fontNormLg);

            fontNormMd = MmgFontData.CreateDefaultMmgFont(title.GetFontSize() - MmgHelper.ScaleValue(2));
            fontNormMd.SetText("Font Norm Medium");
            fontNormMd.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 5));
            fontNormMd.SetX(y);
            AddObj(fontNormMd);

            fontNormSm = MmgFontData.CreateDefaultMmgFontSm();
            fontNormSm.SetText("Font Norm Small");
            fontNormSm.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 6));
            fontNormSm.SetX(y);
            AddObj(fontNormSm);

            fontItalicLg = MmgFontData.CreateDefaultItalicMmgFontLg();
            fontItalicLg.SetText("Font Italic Large");
            fontItalicLg.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 1));
            fontItalicLg.SetX(GetWidth() / 2 + y);
            AddObj(fontItalicLg);

            fontItalicMd = MmgFontData.CreateDefaultItalicMmgFont(title.GetFontSize() - MmgHelper.ScaleValue(2));
            fontItalicMd.SetText("Font Italic Medium");
            MmgHelper.CenterHorAndVert(fontItalicMd);
            fontItalicMd.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 2));
            fontItalicMd.SetX(GetWidth() / 2 + y);
            AddObj(fontItalicMd);

            fontItalicSm = MmgFontData.CreateDefaultItalicMmgFontSm();
            fontItalicSm.SetText("Font Italic Small");
            MmgHelper.CenterHorAndVert(fontItalicSm);
            fontItalicSm.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 3));
            fontItalicSm.SetX(GetWidth() / 2 + y);
            AddObj(fontItalicSm);

            fontCustomLg = MmgFontData.CreateDefaultMmgFont(MmgFontData.GetFontSize() + MmgHelper.ScaleValue(12));
            fontCustomLg.SetText("Font Custom Large");
            MmgHelper.CenterHorAndVert(fontCustomLg);
            fontCustomLg.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 4));
            fontCustomLg.SetX(GetWidth() / 2 + y);
            AddObj(fontCustomLg);

            fontCustomMd = MmgFontData.CreateDefaultMmgFont(MmgFontData.GetFontSize() + MmgHelper.ScaleValue(8));
            fontCustomMd.SetText("Font Custom Medium");
            MmgHelper.CenterHorAndVert(fontCustomMd);
            fontCustomMd.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 5));
            fontCustomMd.SetX(GetWidth() / 2 + y);
            AddObj(fontCustomMd);

            fontCustomSm = MmgFontData.CreateDefaultMmgFont(MmgFontData.GetFontSize() + MmgHelper.ScaleValue(4));
            fontCustomSm.SetText("Font Custom Small");
            MmgHelper.CenterHorAndVert(fontCustomSm);
            fontCustomSm.SetY(GetY() + MmgHelper.ScaleValue(15) + (y * 6));
            fontCustomSm.SetX(GetWidth() / 2 + y);
            AddObj(fontCustomSm);

            ready = true;
            pause = false;
        }

        /// <summary>
        /// A method to handle dpad release events.
        /// </summary>
        /// <param name="dir">The direction id for the dpad event.</param>
        /// <returns>A bool indicating if this event was handled or not.</returns>
        public override bool ProcessDpadRelease(int dir)
        {
            MmgHelper.wr("ScreenTestMmgFont.ProcessDpadRelease: " + dir);
            if (dir == GameSettings.RIGHT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_04);

            }
            else if (dir == GameSettings.LEFT_KEYBOARD)
            {
                owner.SwitchGameState(GameStates.GAME_SCREEN_02);

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
            fontBoldLg = null;
            fontBoldMd = null;
            fontBoldSm = null;
            fontCustomLg = null;
            fontCustomMd = null;
            fontCustomSm = null;
            fontItalicLg = null;
            fontItalicMd = null;
            fontItalicSm = null;
            fontNormLg = null;
            fontNormMd = null;
            fontNormSm = null;
            title = null;
            base.ClearObjs();
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
            MmgHelper.wr("ScreenTestMmgFont.HandleGenericEvent: Id: " + obj.id + " GameState: " + obj.gameState);
        }

        /// <summary>
        /// The callback method to handle MmgEvent objects.
        /// </summary>
        /// <param name="e">An MmgEvent object instance to process.</param>
        public virtual void MmgHandleEvent(MmgEvent e)
        {
            MmgHelper.wr("ScreenTestMmgFont.HandleMmgEvent: Msg: " + e.GetMessage() + " Id: " + e.GetEventId());
        }
    }
}