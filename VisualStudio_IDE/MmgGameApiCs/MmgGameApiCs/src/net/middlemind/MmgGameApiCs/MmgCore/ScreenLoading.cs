using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using net.middlemind.MmgGameApiCs.MmgBase;
using static net.middlemind.MmgGameApiCs.MmgBase.MmgBmp;
using static net.middlemind.MmgGameApiCs.MmgCore.GamePanel;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A game screen object, ScreenLoading, that extends the MmgLoadingScreen base class. 
    /// This game screen is for displaying a loading screen.
    /// Created by Middlemind Games 08/01/2015
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class ScreenLoading : MmgLoadingScreen, LoadResourceUpdateHandler
    {
        /// <summary>
        /// Event load complete id.
        /// </summary>
        public static int EVENT_LOAD_COMPLETE = 0;

        /// <summary>
        /// Wrapper class for running a worker thread.
        /// </summary>
        public RunResourceLoad datLoad;

        /// <summary>
        /// The game state this screen has.
        /// </summary>
        public GameStates state;

        /// <summary>
        /// Event handler for firing generic events. 
        /// Events would fire when the screen has non UI actions to broadcast.
        /// </summary>
        public GenericEventHandler handler;

        /// <summary>
        /// The GamePanel that owns this game screen. 
        /// Usually a JPanel instance that holds a reference to this game screen object.
        /// </summary>
        public GamePanel owner;

        /// <summary>
        /// A timing value in milliseconds used to slow down the resource loading process when there are few resources to load.
        /// </summary>
        public long slowDown;

        /// <summary>
        /// A data structure that stores all the class configuration file entries from the target file.
        /// </summary>
        public Dictionary<string, MmgCfgFileEntry> classConfig;

        //NOTE: Cross thread read, write, and command classes are used to overcome cross thread limitations in the Monogame framework.
        /// <summary>
        /// A cross thread reader used to pull cross thread commands from a list and execute them.
        /// </summary>
        public CrossThreadRead xTrdR;

        /// <summary>
        /// A cross thread command variable used by the class when processing cross thread commands.
        /// </summary>
        private CrossThreadCommand xTrdC;

        /// <summary>
        /// Constructor, sets the loading bar, the loading bar offset, the game state of this game screen, and the GamePanel that owns this game screen.
        /// </summary>
        /// <param name="LoadingBar">A loading bar object, MmgLoadingBar, to use as this screen's loading bar.</param>
        /// <param name="lBarOff">An offset used in drawing the loading bar.</param>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenLoading(MmgLoadingBar LoadingBar, float lBarOff, GameStates State, GamePanel Owner) : base(LoadingBar, lBarOff)
        {
            pause = false;
            ready = false;
            state = State;
            owner = Owner;
            slowDown = 0;
        }

        /// <summary>
        /// Constructor, sets the game state associated with this screen, and sets the owner GamePanel instance.
        /// </summary>
        /// <param name="State">The game state of this game screen.</param>
        /// <param name="Owner">The owner of this game screen.</param>
        public ScreenLoading(GameStates State, GamePanel Owner)
        {
            pause = false;
            ready = false;
            state = State;
            owner = Owner;
            slowDown = 0;
        }

        /// <summary>
        /// Gets the slow down value that will slow down the loading process when there are only a few resources to load.
        /// </summary>
        /// <returns>The slow down time in milliseconds.</returns>
        public virtual long GetSlowDown()
        {
            return slowDown;
        }

        /// <summary>
        /// Sets the slow down value that will slow down the loading process when there are only a few resources to load.
        /// </summary>
        /// <param name="l">The slow down time in milliseconds.</param>
        public virtual void SetSlowDown(long l)
        {
            slowDown = l;
        }

        /// <summary>
        /// Sets a generic event handler that will receive generic events from this object.
        /// </summary>
        /// <param name="Handler">A class that implements the GenericEventHandler interface.</param>
        public virtual void SetGenericEventHandler(GenericEventHandler Handler)
        {
            handler = Handler;
        }

        /// <summary>
        /// Gets the generic event handler.
        /// </summary>
        /// <returns>The generic event handler.</returns>
        public virtual GenericEventHandler GetGenericEventHandler()
        {
            return handler;
        }

        /// <summary>
        /// Gets the resource loader that handles actually loading resources.
        /// </summary>
        /// <returns>The resource loader.</returns>
        public virtual RunResourceLoad GetLoader()
        {
            return datLoad;
        }

        /// <summary>
        /// Sets the resource loader that handles actually loading resources.
        /// </summary>
        /// <param name="DatLoad">The resource loader.</param>
        public virtual void SetLoader(RunResourceLoad DatLoad)
        {
            datLoad = DatLoad;
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

            classConfig = MmgHelper.ReadClassConfigFile(GameSettings.CLASS_CONFIG_DIR + "screen_loading.txt");

            MmgBmp tB = null;
            MmgBmp tB1 = null;
            MmgLoadingBar lb = null;
            int lbOffSet = MmgHelper.ScaleValue(5);
            string key = "";
            double scale = 1.0;
            int tmp = 0;
            string file = "";

            key = "loadingLogoSlowDown";
            if (classConfig.ContainsKey(key))
            {
                slowDown = (int)classConfig[key].number;
            }

            key = "bmpLogo";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "odroid_logo2.png";
            }

            tB = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);
            if (tB != null)
            {
                tB = MmgBmpScaler.ScaleMmgBmp(tB, 0.5, true);

                key = "loadingLogoScale";
                if (classConfig.ContainsKey(key))
                {
                    scale = (double)classConfig[key].number;
                    if (scale != 1.0)
                    {
                        tB = MmgBmpScaler.ScaleMmgBmp(tB, scale, false);
                    }
                }

                SetCenteredBackground(tB);

                key = "loadingLogoPosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "loadingLogoPosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "loadingLogoOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetY(tB.GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "loadingLogoOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    tB.GetPosition().SetX(tB.GetX() + MmgHelper.ScaleValue(tmp));
                }
            }

            key = "imgLoadingBar";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "loading_bar.png";
            }

            tB = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);

            key = "imgLoadingBarFill";
            if (classConfig.ContainsKey(key))
            {
                file = classConfig[key].str;
            }
            else
            {
                file = "blue_square.png";
            }

            tB1 = MmgHelper.GetBasicBmp(GameSettings.IMAGE_LOAD_DIR + file);
            if (tB1 != null)
            {
                tB1.DRAW_MODE = MmgBmpDrawMode.DRAW_BMP_FULL;
            }

            if (tB != null && tB1 != null)
            {
                lb = new MmgLoadingBar(tB1, tB);
                lb.SetMmgColor(null);
                lb.SetWidth(tB.GetWidth() - MmgHelper.ScaleValue(10));
                lb.SetHeight(tB.GetHeight() - MmgHelper.ScaleValue(12));
                lb.SetFillAmt(0.0f);
                lb.SetPaddingX(MmgHelper.ScaleValue(8));
                lb.SetPaddingY(MmgHelper.ScaleValue(4));
                lb.SetFillHeight(tB.GetHeight() - MmgHelper.ScaleValue(10));
                lb.SetFillWidth(tB.GetWidth() - MmgHelper.ScaleValue(12));
                base.SetLoadingBar(lb, lbOffSet);

                MmgHelper.CenterHorAndVert(lb);

                key = "loadingBarPosY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    GetLoadingBar().GetPosition().SetY(GetPosition().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "loadingBarPosX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    GetLoadingBar().GetPosition().SetX(GetPosition().GetX() + MmgHelper.ScaleValue(tmp));
                }

                key = "loadingBarOffsetY";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    GetLoadingBar().GetPosition().SetY(GetLoadingBar().GetY() + MmgHelper.ScaleValue(tmp));
                }

                key = "loadingBarOffsetX";
                if (classConfig.ContainsKey(key))
                {
                    tmp = (int)classConfig[key].number;
                    GetLoadingBar().GetPosition().SetX(GetLoadingBar().GetX() + MmgHelper.ScaleValue(tmp));
                }
            }

            ready = true;
            pause = false;
        }

        /// <summary>
        /// Unloads resources needed to display this game screen. 
        /// </summary>
        public virtual void UnloadResources()
        {
            pause = true;
            SetLoadingBar(null, 0f);
            SetBackground(null);
            ClearObjs();
            datLoad = null;
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
        /// Loads the DAT file data from the file system.
        /// </summary>
        /// <returns>A byte array representation of the DAT file.</returns>
        public virtual bool GetResourceFileData()
        {
            try
            {
                DirectoryInfo ald = new DirectoryInfo(GameSettings.AUTO_IMAGE_LOAD_DIR);
                FileInfo[] files = ald.GetFiles();

                if (files != null && files.Length > 0)
                {
                    return true;
                }
                else
                {
                    ald = new DirectoryInfo(GameSettings.AUTO_SOUND_LOAD_DIR);
                    files = ald.GetFiles();

                    if (files != null && files.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        ald = new DirectoryInfo(GameSettings.PROGRAM_IMAGE_LOAD_DIR);
                        files = ald.GetFiles();

                        if (files != null && files.Length > 0)
                        {
                            return true;
                        }
                        else
                        {
                            ald = new DirectoryInfo(GameSettings.PROGRAM_SOUND_LOAD_DIR);
                            files = ald.GetFiles();

                            if (files != null && files.Length > 0)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            return false;
        }

        /// <summary>
        /// Starts the DAT loading worker thread.
        /// </summary>
        public virtual void StartDatLoad()
        {
            if (GetResourceFileData())
            {
                datLoad = new RunResourceLoad();
                datLoad.SetSlowDown(slowDown);
                datLoad.SetUpdateHandler(this);

                xTrdR = new CrossThreadRead(datLoad.xTrdW);
                //datLoad.run();
                
                ThreadStart r = new ThreadStart(datLoad.run);
                Thread t = new Thread(r);
                t.Start();                
            }
            else
            {
                MmgHelper.wr("ScreenLoading: StartDatLoad: No data found to load!!");
            }
        }

        /// <summary>
        /// Stops the DAT load process.
        /// </summary>
        public virtual void StopDatLoad()
        {
            if (datLoad != null)
            {
                datLoad.StopLoad();
            }
        }

        /// <summary>
        /// Handles load DAT update events, LoadDatUpdateMessage. 
        /// Fires a generic event when the load has completed.
        /// </summary>
        /// <param name="obj">The load DAT update message sent.</param>
        public virtual void HandleUpdate(LoadResourceUpdateMessage obj)
        {
            if (obj != null)
            {
                float prct = (float)obj.GetPos() / (float)obj.GetLen();

                if (GetLoadingBar() != null)
                {
                    GetLoadingBar().SetFillAmt(prct);
                }

                /*
                if (GetLoadComplete() == true)
                {
                    if (handler != null)
                    {
                        handler.HandleGenericEvent(new GenericEventMessage(ScreenLoading.EVENT_LOAD_COMPLETE, null, GetGameState()));
                    }
                }
                */

                MmgHelper.wr("LoadingScreen: POS: " + obj.GetPos() + " LEN: " + obj.GetLen() + " PRCT: " + prct + " LR: " + GetLoadResult() + " LC: " + GetLoadComplete());
            }
        }

        /// <summary>
        /// Gets the DAT read result value.
        /// </summary>
        /// <returns>True if the read was successful, false otherwise.</returns>
        public virtual bool GetLoadResult()
        {
            if (datLoad != null)
            {
                return datLoad.GetReadResult();
            }
            else
            {
                MmgHelper.wr("ScreenLoading: GetLoadResult: The datLoad field is NULL!!");
                return false;
            }
        }

        /// <summary>
        /// Gets the DAT load complete value.
        /// </summary>
        /// <returns>True if the load was successful, false otherwise.</returns>
        public virtual bool GetLoadComplete()
        {
            if (datLoad != null)
            {
                return datLoad.GetReadComplete();
            }
            else
            {
                MmgHelper.wr("ScreenLoading: GetLoadComplete: The datLoad field is NULL!!");
                return false;
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
            if (isVisible)
            {
                base.MmgUpdate(updateTick, currentTimeMs, msSinceLastFrame);

                if (xTrdR != null)
                {
                    xTrdC = xTrdR.GetNextCommand();
                    if (xTrdC != null && xTrdC.name.Equals("GetBasicCachedSound"))
                    {
                        MmgHelper.wr("ByteArrayLength: " + ((byte[])xTrdC.payload[1]).Length);
                        MmgHelper.wr("FileName: " + ((string)xTrdC.payload[0]));
                        MmgHelper.GetBasicCachedSound((byte[])xTrdC.payload[1], (string)xTrdC.payload[0]);
                    }
                    else if (xTrdC != null && xTrdC.name.Equals("GetBasicCachedBmp") && xTrdC.payload != null && xTrdC.payload.Length >= 2)
                    {
                        MmgHelper.wr("ByteArrayLength: " + ((byte[])xTrdC.payload[1]).Length);
                        MmgHelper.wr("FileName: " + ((string)xTrdC.payload[0]));
                        MmgHelper.GetBasicCachedBmp((byte[])xTrdC.payload[1], (string)xTrdC.payload[0]);
                    }
                }
                
                if (GetLoadComplete() == true && xTrdR.IsEmpty())
                {
                    if (handler != null)
                    {
                        handler.HandleGenericEvent(new GenericEventMessage(ScreenLoading.EVENT_LOAD_COMPLETE, null, GetGameState()));
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}