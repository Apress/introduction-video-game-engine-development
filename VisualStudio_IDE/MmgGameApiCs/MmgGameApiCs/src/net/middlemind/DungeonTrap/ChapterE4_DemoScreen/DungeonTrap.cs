using System;
using System.Reflection;
using System.Runtime.InteropServices;
using net.middlemind.MmgGameApiCs.MmgBase;
using net.middlemind.MmgGameApiCs.MmgCore;

namespace net.middlemind.DungeonTrap.ChapterE4_DemoScreen
{
    /// <summary>
    /// C# Monogame game that runs the MmgApi. 
    /// STATIC MAIN ENTRY POINT
    /// Created by Middlemind Games 01/31/2021
    ///
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public static class DungeonTrap
    {
        /// <summary>
        /// The target window width.
        /// </summary>
        public static int WIN_WIDTH = 862;

        /// <summary>
        /// The target window height. 
        /// </summary>
        public static int WIN_HEIGHT = 604;

        /// <summary>
        /// The game panel width. 
        /// </summary>
        public static int PANEL_WIDTH = 856;

        /// <summary>
        /// The game panel height.
        /// </summary>
        public static int PANEL_HEIGHT = 598; //416;

        /// <summary>
        /// The game width.
        /// </summary>
        public static int GAME_WIDTH = 854;

        /// <summary>
        /// The game height.
        /// </summary>
        public static int GAME_HEIGHT = 416;

        /// <summary>
        /// The frame rate for the game, frames per second.
        /// </summary>
        public static long FPS = 30L;

        /// <summary>
        /// Base engine config files.
        /// </summary>
        public static string ENGINE_CONFIG_FILE = "../../../cfg/engine_config_mmg_dungeon_trap.xml";

        /// <summary>
        /// A copy of the command line arguments passed to the Java application.
        /// </summary>
        public static string[] ARGS = null;

        /// <summary>
        /// The GamePanel used to render the game.
        /// </summary>
        public static GamePanel pnlGame = null;

        /// <summary>
        /// Method that searches an array for a string match.
        /// </summary>
        /// <param name="v">The string to find a match for.</param>
        /// <param name="s">The array of string to search through.</param>
        /// <returns>The command line argument that matched the test string, v.</returns>
        public static string ArrayHasEntryLike(string v, string[] s)
        {
            if (v == null || s == null)
            {
                return null;
            }

            string tmp = v.ToLower();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                if (s[i] != null)
                {
                    if (s[i].ToLower().Contains(tmp) == true || s[i].ToLower().Equals(tmp) == true)
                    {
                        return s[i];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Run OS specific code on startup before the native libraries are loaded and the game engine config XML file. 
        /// </summary>
        public static void RunOsSpecificCode()
        {
            try
            {
                int p = (int)Environment.OSVersion.Platform;
                string OS = "win";

                if (p == 4 || p == 128 || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                {
                    OS = "linux";
                }
                else if (p == 6 || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    OS = "mac";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    OS = "win";
                }

                MmgHelper.wr("Found platform: " + OS);

                if (isWindows(OS))
                {
                    MmgHelper.wr("This is Windows");

                }
                else if (isMac(OS))
                {
                    MmgHelper.wr("This is Mac");
                    GameSettings.LOAD_NATIVE_LIBRARIES = true;
                    GameSettings.GAMEPAD_1_ON = true;
                    GameSettings.GAMEPAD_1_THREADED_POLLING = false;
                    GameSettings.GAMEPAD_2_ON = false;
                    GameSettings.GPIO_GAMEPAD_ON = false;

                }
                else if (isUnix(OS))
                {
                    MmgHelper.wr("This is Unix or Linux");
                    GameSettings.LOAD_NATIVE_LIBRARIES = false;
                    GameSettings.GAMEPAD_1_ON = false;
                    GameSettings.GAMEPAD_2_ON = false;
                    GameSettings.GPIO_GAMEPAD_ON = true;
                    GameSettings.GPIO_GAMEPAD_THREADED_POLLING = true;

                }
                else if (isSolaris(OS))
                {
                    MmgHelper.wr("This is Solaris");

                }
                else
                {
                    MmgHelper.wr("Your OS is not supported!!");

                }

            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }
        }

        /// <summary>
        /// A static method that loads native libraries that allow access to gamepads and controllers.
        /// </summary>
        public static void LoadNativeLibraries()
        {
            try
            {
                int p = (int)Environment.OSVersion.Platform;
                string OS = "win"; //System.getProperty("os.name").toLowerCase();

                if (p == 4 || p == 128 || RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                {
                    OS = "linux";
                }
                else if (p == 6 || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    OS = "mac";
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    OS = "win";
                }

                MmgHelper.wr("Found platform: " + OS);

                if (isWindows(OS))
                {
                    MmgHelper.wr("This is Windows");

                }
                else if (isMac(OS))
                {
                    MmgHelper.wr("This is Mac");

                }
                else if (isUnix(OS))
                {
                    MmgHelper.wr("This is Unix or Linux");

                }
                else if (isSolaris(OS))
                {
                    MmgHelper.wr("This is Solaris");

                }
                else
                {
                    MmgHelper.wr("Your OS is not supported!!");

                }

            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on Windows.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on Windows.</returns>
        public static bool isWindows(string OS)
        {
            return (OS.IndexOf("win") >= 0);
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on a Mac.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on a Mac.</returns>
        public static bool isMac(string OS)
        {
            return (OS.IndexOf("mac") >= 0);
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on Linux.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on Linux.</returns>
        public static bool isUnix(string OS)
        {
            return (OS.IndexOf("nix") >= 0 || OS.IndexOf("nux") >= 0 || OS.IndexOf("aix") > 0);
        }

        /// <summary>
        /// A static class method for checking if this Java application is running on Sun OS.
        /// </summary>
        /// <param name="OS">The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.</param>
        /// <returns>A bool value indicating if the Java application is running on Sun OS.</returns>
        public static bool isSolaris(string OS)
        {
            return (OS.IndexOf("sunos") >= 0);
        }

        //NOTES: Added to the Monogame port to mimic the Java reflection implementation.
        /// <summary>
        /// Searches through the list of provided fields for a field with the name specified by the key argument.
        /// </summary>
        /// <param name="key">The name of the field to search for.</param>
        /// <param name="fields">The list of available fields to search.</param>
        /// <returns>The field info if found otherwise null.</returns>
        public static FieldInfo getField(string key, FieldInfo[] fields)
        {
            if (fields != null && fields.Length > 0)
            {
                int len = fields.Length;
                for (int i = 0; i < len; i++)
                {
                    if (fields[i].Name.Equals(key))
                    {
                        return fields[i];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Sets the value of the field specified by the field reflection object.
        /// </summary>
        /// <param name="ent">Entry object that wraps the XML entry.</param>
        /// <param name="f">Class member that needs to be updated.</param>
        public static void SetField(DatConstantsEntry ent, FieldInfo f)
        {
            if (ent.type != null && ent.type.Equals("int") == true)
            {
                f.SetValue(null, int.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("long") == true)
            {
                f.SetValue(null, long.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("float") == true)
            {
                f.SetValue(null, float.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("double") == true)
            {
                f.SetValue(null, double.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("short") == true)
            {
                f.SetValue(null, Int16.Parse(ent.val));

            }
            else if (ent.type != null && ent.type.Equals("string") == true)
            {
                f.SetValue(null, ent.val);

            }
            else if (ent.type != null && ent.type.Equals("bool") == true)
            {
                f.SetValue(null, bool.Parse(ent.val));

            }
            else
            {
                f.SetValue(null, int.Parse(ent.val));
            }
        }

        /// <summary>
        /// Static main method.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        [STAThread]
        public static void AltMain(string[] args)
        {
            if (GameSettings.RUN_OS_SPECIFIC_CODE)
            {
                RunOsSpecificCode();
            }

            if (GameSettings.LOAD_NATIVE_LIBRARIES)
            {
                LoadNativeLibraries();
            }

            //Store program arguments for future reference
            ARGS = args;
            if (args != null && args.Length > 0)
            {
                MmgHelper.wr("Found command line arguments!");
                string res = null;

                res = ArrayHasEntryLike("WIN_WIDTH=", args);
                if (res != null)
                {
                    WIN_WIDTH = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("WIN_HEIGHT=", args);
                if (res != null)
                {
                    WIN_HEIGHT = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("PANEL_WIDTH=", args);
                if (res != null)
                {
                    PANEL_WIDTH = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("PANEL_HEIGHT=", args);
                if (res != null)
                {
                    PANEL_HEIGHT = int.Parse(res.Split("=")[1]);
                }

                res = ArrayHasEntryLike("FPS=", args);
                if (res != null)
                {
                    FPS = int.Parse(res.Split("=")[1]);
                    GamePanel.TARGET_FPS = FPS;
                }

                res = ArrayHasEntryLike("OPENGL=false", args);
                if (res == null)
                {
                    Console.WriteLine("OpenGL command line option is not available on MonoGame DesktopGL projects.");
                }

                res = ArrayHasEntryLike("ENGINE_CONFIG_FILE=", args);
                if (res != null)
                {
                    ENGINE_CONFIG_FILE = res.Split("=")[1];
                }

                res = ArrayHasEntryLike("ODROID=true", args);
                if (res != null)
                {
                    WIN_WIDTH = 480;
                    WIN_HEIGHT = 320;
                    PANEL_WIDTH = 478;
                    PANEL_HEIGHT = 318;
                    GAME_WIDTH = 478;
                    GAME_HEIGHT = 318;
                }

                res = ArrayHasEntryLike("RUN_UNIT_TESTS=", args);
                if (res != null)
                {
                    GameSettings.RUN_UNIT_TESTS = true;
                }
            }

            //LOAD ENGINE CONFIG FILE
            try
            {
                MmgHelper.wr("Found engine config file: " + ENGINE_CONFIG_FILE);
                if (ENGINE_CONFIG_FILE != null && ENGINE_CONFIG_FILE.Equals("") == false)
                {
                    GameSettingsImporter dci = new GameSettingsImporter();
                    bool r = dci.ImportGameSettings(ENGINE_CONFIG_FILE);
                    MmgHelper.wr("Engine config load result: " + r);

                    if (r == true)
                    {
                        int len = dci.GetValues().Keys.Count;
                        string[] keys = new string[len];
                        dci.GetValues().Keys.CopyTo(keys, 0);
                        string key;
                        DatConstantsEntry ent = null;
                        FieldInfo f = null;

                        for (int i = 0; i < len; i++)
                        {
                            try
                            {
                                key = keys[i];
                                ent = dci.GetValues()[key];

                                if (ent.from != null && ent.from.Equals("GameSettings") == true)
                                {
                                    Type myType = typeof(GameSettings);
                                    FieldInfo[] myFields = myType.GetFields();

                                    f = getField(ent.key, myFields);
                                    if (f != null)
                                    {
                                        MmgHelper.wr("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                        SetField(ent, f);
                                    }
                                }
                                else if (ent.from != null && ent.from.Equals("MmgHelper") == true)
                                {
                                    Type myType = typeof(MmgHelper);
                                    FieldInfo[] myFields = myType.GetFields();

                                    f = getField(ent.key, myFields);
                                    if (f != null)
                                    {
                                        MmgHelper.wr("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                        SetField(ent, f);
                                    }
                                }
                                else if (ent.from != null && ent.from.Equals("StaticMain") == true)
                                {
                                    Type myType = typeof(DungeonTrap);
                                    FieldInfo[] myFields = myType.GetFields();

                                    f = getField(ent.key, myFields);
                                    if (f != null)
                                    {
                                        MmgHelper.wr("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                        SetField(ent, f);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                MmgHelper.wr("Ignoring field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type);
                                MmgHelper.wrErr(e);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }

            //Set program specific resource loading directories
            GameSettings.PROGRAM_IMAGE_LOAD_DIR += GameSettings.NAME;
            GameSettings.PROGRAM_SOUND_LOAD_DIR += GameSettings.NAME;

            MmgHelper.wr("Window Width: " + WIN_WIDTH);
            MmgHelper.wr("Window Height: " + WIN_HEIGHT);
            MmgHelper.wr("Panel Width: " + PANEL_WIDTH);
            MmgHelper.wr("Panel Height: " + PANEL_HEIGHT);
            MmgHelper.wr("Game Width: " + GAME_WIDTH);
            MmgHelper.wr("Game Height: " + GAME_HEIGHT);

            try
            {
                pnlGame = new GamePanel(PANEL_WIDTH, PANEL_HEIGHT, (WIN_WIDTH - PANEL_WIDTH) / 2, (WIN_HEIGHT - PANEL_HEIGHT) / 2, GAME_WIDTH, GAME_HEIGHT);
                pnlGame.Run();
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
            }
        }
    }
}