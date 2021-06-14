using System;
using net.middlemind.MmgGameApiCs.MmgTestSpace;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// A centralized main class that can run the different executable classes in the library.
    ///
    /// @author Victor G.Brusca, Middlemind Games
    /// 10/14/2020
    /// </summary>
    public class MmgCentralMain
    {
        /// <summary>
        /// Static main entry point.
        /// </summary>
        /// <param name="args">String array of arguments, append the executable name before its arguments.</param>
        public static void Main(string[] args)
        {
            if(args == null || args.Length == 0)
            {
                Console.WriteLine("No arguments found.");
                return;
            }

            string[] nArgs = new string[args.Length - 1];
            Array.Copy(args, 1, nArgs, 0, nArgs.Length);

            string t = "";
            for(int i = 0; i < nArgs.Length; i++)
            {
                t += (i + 1) + ": " + nArgs[i] + ",";
            }
            MmgHelper.wr("AdjustedArgs: " + t);

            if (args[0] != null && args[0].ToLower().Equals("controllerreadtest"))
            {
                ControllerReadTest.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("mmgtestspace"))
            {
                MmgTestScreens.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("mmgapigame"))
            {
                MmgApiGame.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter16"))
            {
                net.middlemind.PongClone.Chapter16.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chapter17"))
            {
                net.middlemind.PongClone.Chapter17.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && (args[0].ToLower().Equals("chapter18") || args[0] != null && args[0].ToLower().Equals("chapter18_completegame")))
            {
                net.middlemind.PongClone.Chapter18_CompleteGame.PongClone.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere1"))
            {
                net.middlemind.DungeonTrap.ChapterE1.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere2"))
            {
                net.middlemind.DungeonTrap.ChapterE2.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere3"))
            {
                net.middlemind.DungeonTrap.ChapterE3.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere4"))
            {
                net.middlemind.DungeonTrap.ChapterE4.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere4_demoscreen"))
            {
                net.middlemind.DungeonTrap.ChapterE4_DemoScreen.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere5_phase1"))
            {
                net.middlemind.DungeonTrap.ChapterE5_Phase1.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere5_phase2"))
            {
                net.middlemind.DungeonTrap.ChapterE5_Phase2.DungeonTrap.AltMain(nArgs);

            }
            else if (args[0] != null && args[0].ToLower().Equals("chaptere5_phase3") || args[0] != null && args[0].ToLower().Equals("chaptere5_phase3_completegame"))
            {
                net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame.DungeonTrap.AltMain(nArgs);

            }
            else
            {
                MmgTestScreens.AltMain(nArgs);

            }
        }
    }
}