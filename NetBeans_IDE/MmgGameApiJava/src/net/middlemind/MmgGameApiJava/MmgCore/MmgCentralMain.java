package net.middlemind.MmgGameApiJava.MmgCore;

import java.util.Arrays;
import net.java.games.input.test.ControllerReadTest;
import net.middlemind.MmgGameApiJava.MmgTestSpace.MmgTestScreens;

/**
 * A centralized main class that can run the different executable classes in the library.
 * 
 * @author Victor G. Brusca, Middlemind Games
 */
public class MmgCentralMain {
    
    /**
     * Static main entry point.
     * 
     * @param args  String array of arguments, append the executable name before its arguments.
     */
    public static void main(String[] args) {
        if(args == null || args.length == 0) {
            System.out.println("No arguments found.");
            return;
        }
            
        if(args[0] != null && args[0].toLowerCase().equals("controllerreadtest")) {
            ControllerReadTest.main(Arrays.copyOfRange(args, 1, args.length));
            
        } else if(args[0] != null && args[0].toLowerCase().equals("mmgtestspace")) {
            MmgTestScreens.main(Arrays.copyOfRange(args, 1, args.length));
            
        } else if(args[0] != null && args[0].toLowerCase().equals("mmgapigame")) {
            MmgApiGame.main(Arrays.copyOfRange(args, 1, args.length));
                        
        } else if(args[0] != null && args[0].toLowerCase().equals("chapter16")) {
            net.middlemind.PongClone.Chapter16.PongClone.main(Arrays.copyOfRange(args, 1, args.length));            

        } else if(args[0] != null && args[0].toLowerCase().equals("chapter17")) {
            net.middlemind.PongClone.Chapter17.PongClone.main(Arrays.copyOfRange(args, 1, args.length));            
            
        } else if(args[0] != null && (args[0].toLowerCase().equals("chapter18") || args[0].toLowerCase().equals("chapter18_completegame"))) {
            net.middlemind.PongClone.Chapter18_CompleteGame.PongClone.main(Arrays.copyOfRange(args, 1, args.length));
            
        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere1") || args[0].toLowerCase().equals("chapter20"))) {
            net.middlemind.DungeonTrap.ChapterE1.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));            

        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere2") || args[0].toLowerCase().equals("chapter21"))) {
            net.middlemind.DungeonTrap.ChapterE2.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));            
                       
        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere3") || args[0].toLowerCase().equals("chapter22"))) {
            net.middlemind.DungeonTrap.ChapterE3.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));                        
        
        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere4") || args[0].toLowerCase().equals("chapter23"))) {
            net.middlemind.DungeonTrap.ChapterE4.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));                    

        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere4_demoscreen") || args[0].toLowerCase().equals("chapter23_demoscreen"))) {
            net.middlemind.DungeonTrap.ChapterE4_DemoScreen.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));            

        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere5_phase1") || args[0].toLowerCase().equals("chapter24_phase1"))) {
            net.middlemind.DungeonTrap.ChapterE5_Phase1.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));                        

        } else if(args[0] != null && (args[0].toLowerCase().equals("chaptere5_phase2") || args[0].toLowerCase().equals("chapter24_phase2"))) {
            net.middlemind.DungeonTrap.ChapterE5_Phase2.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));                        

        } else if(args[0] != null && (args[0].toLowerCase().equals("chapter24_phase3") || args[0].toLowerCase().equals("chapter24_phase3_completegame") || args[0].toLowerCase().equals("chaptere5_phase3") || args[0].toLowerCase().equals("chaptere5_phase3_completegame"))) {
            net.middlemind.DungeonTrap.ChapterE5_Phase3_CompleteGame.DungeonTrap.main(Arrays.copyOfRange(args, 1, args.length));                        
            
        } else {
            MmgTestScreens.main(Arrays.copyOfRange(args, 1, args.length));
        }
    }
}
