package net.middlemind.PongClone.Chapter17;

import net.middlemind.MmgGameApiJava.MmgCore.DatConstantsEntry;
import net.middlemind.MmgGameApiJava.MmgCore.GameSettings;
import net.middlemind.MmgGameApiJava.MmgCore.GameSettingsImporter;
import java.lang.reflect.Field;
import javax.swing.JFrame;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import net.middlemind.MmgGameApiJava.MmgCore.RunFrameRate;

/**
 * Java swing game that runs on the MmgApi. 
 * Created on August 1, 2015, 10:57 PM by Middlemind Games
 * 
 * @author Victor G. Brusca
 */
public final class PongClone {

    /**
     * The main JFrame that houses the different game screens.
     */
    public static MainFrame mf;

    /**
     * The frame rate worker thread.
     */
    public static RunFrameRate fr;

    /**
     * The thread that is associated with the frame rate worker thread.
     */
    public static Thread t;

    /**
     * The target window width.
     */
    public static int WIN_WIDTH = 858;

    /**
     * The target window height.
     */
    public static int WIN_HEIGHT = 600;

    /**
     * The game panel width.
     */
    public static int PANEL_WIDTH = 856;

    /**
     * The game panel height.
     */
    public static int PANEL_HEIGHT = 598; //416;

    /**
     * The game width.
     */
    public static int GAME_WIDTH = 854;

    /**
     * The game height.
     */
    public static int GAME_HEIGHT = 416;    
    
    /**
     * The frame rate for the game, frames per second.
     */
    public static long FPS = 30l;

    /**
     * Base engine config files.
     */
    public static String ENGINE_CONFIG_FILE = "../cfg/engine_config_mmg_pong_clone.xml";

    /**
     * The GamePanel used to render the game in a MainFrame instance.
     */    
    public static GamePanel pnlGame;
    
    /**
     * A copy of the command line arguments passed to the Java application.
     */    
    public static String[] ARGS = null;
        
    /**
     * Method that searches an array for a string match.
     *
     * @param v     The string to find a match for.
     * @param s     The array of string to search through.
     * 
     * @return      The command line argument that matched the test string, v.
     */
    public static String ArrayHasEntryLike(String v, String[] s) {
        if(v == null || s == null) {
            return null;
        }
        
        String tmp = v.toLowerCase();
        int len = s.length;
        for (int i = 0; i < len; i++) {
            if(s[i] != null) {
                if (s[i].toLowerCase().contains(tmp) == true || s[i].toLowerCase().equals(tmp) == true) {
                    return s[i];
                }
            }
        }
        return null;
    }

    /**
     * Run OS specific code on startup before the native libraries are loaded and the game engine
     * config XML file.
     */
    public static void RunOsSpecificCode() {
        try {
            String OS = System.getProperty("os.name").toLowerCase();
            MmgHelper.wr("Found platform: " + OS);
            
            if (isWindows(OS)) {
                MmgHelper.wr("This is Windows");
                
            } else if (isMac(OS)) {
                MmgHelper.wr("This is Mac");
                GameSettings.LOAD_NATIVE_LIBRARIES = true;
                GameSettings.GAMEPAD_1_ON = true;
                GameSettings.GAMEPAD_1_THREADED_POLLING = false;
                GameSettings.GAMEPAD_2_ON = false;
                GameSettings.GPIO_GAMEPAD_ON = false;
                
            } else if (isUnix(OS)) {
                MmgHelper.wr("This is Unix or Linux");
                GameSettings.LOAD_NATIVE_LIBRARIES = false;
                GameSettings.GAMEPAD_1_ON = false;
                GameSettings.GAMEPAD_2_ON = false;
                GameSettings.GPIO_GAMEPAD_ON = true;
                GameSettings.GPIO_GAMEPAD_THREADED_POLLING = true;
                
            } else if (isSolaris(OS)) {
                MmgHelper.wr("This is Solaris");
                
            } else {
                MmgHelper.wr("Your OS is not supported!!");

            }
            
        } catch(Exception e) {
            MmgHelper.wrErr(e);
        }
    }    
    
    /**
     * A static method that loads native libraries that allow access to gamepads and controllers.
     */    
    public static void LoadNativeLibraries() {
        try {
            String OS = System.getProperty("os.name").toLowerCase();
            MmgHelper.wr("Found platform: " + OS);
            MmgHelper.wr("LibPath: " + System.getProperty("java.library.path"));
            //System.load("/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/lib/jinput-platform/native-libs/libjinput-osx.jnilib");
            //-Djava.library.path=/Users/victor/Documents/files/netbeans_workspace/MmgGameApiJava/lib/jinput-platform/native-libs/
            
            if (isWindows(OS)) {
                MmgHelper.wr("This is Windows");
                System.loadLibrary("jinput-dx8_64");
                
            } else if (isMac(OS)) {
                MmgHelper.wr("This is Mac");
                System.loadLibrary("jinput-osx");

            } else if (isUnix(OS)) {
                MmgHelper.wr("This is Unix or Linux");
                System.loadLibrary("jinput-linux64");
                
            } else if (isSolaris(OS)) {
                MmgHelper.wr("This is Solaris");
                System.loadLibrary("jinput-linux");
                
            } else {
                MmgHelper.wr("Your OS is not supported!!");

            }
            
        } catch(Exception e) {
            MmgHelper.wrErr(e);
        }
    }
    
    /**
     * A static class method for checking if this Java application is running on Windows.
     * 
     * @param OS        The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.
     * 
     * @return          A boolean value indicating if the Java application is running on Windows.
     */
    public static boolean isWindows(String OS) {
        return (OS.indexOf("win") >= 0);
    }

    /**
     * A static class method for checking if this Java application is running on a Mac.
     * 
     * @param OS        The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.
     * 
     * @return          A boolean value indicating if the Java application is running on a Mac.
     */
    public static boolean isMac(String OS) {
        return (OS.indexOf("mac") >= 0);
    }

    /**
     * A static class method for checking if this Java application is running on Linux.
     * 
     * @param OS        The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.
     * 
     * @return          A boolean value indicating if the Java application is running on Linux.
     */
    public static boolean isUnix(String OS) {
        return (OS.indexOf("nix") >= 0 || OS.indexOf("nux") >= 0 || OS.indexOf("aix") > 0 );
    }

    /**
     * A static class method for checking if this Java application is running on Sun OS.
     * 
     * @param OS        The current OS, System.getProperty("os.name").toLowerCase(), that this Java application is running on.
     * 
     * @return          A boolean value indicating if the Java application is running on Sun OS.
     */
    public static boolean isSolaris(String OS) {
        return (OS.indexOf("sunos") >= 0);
    } 
    
    /**
     * Sets the value of the field specified by the field reflection object.
     *
     * @param ent       Entry object that wraps the XML entry.
     * @param f         Class member that needs to be updated.
     * 
     * @throws Exception
     */
    public static void SetField(DatConstantsEntry ent, Field f) throws Exception {
        if (ent.type != null && ent.type.equals("int") == true) {
            f.setInt(null, Integer.parseInt(ent.val));

        } else if (ent.type != null && ent.type.equals("long") == true) {
            f.setLong(null, Long.parseLong(ent.val));

        } else if (ent.type != null && ent.type.equals("float") == true) {
            f.setFloat(null, Float.parseFloat(ent.val));

        } else if (ent.type != null && ent.type.equals("double") == true) {
            f.setDouble(null, Double.parseDouble(ent.val));

        } else if (ent.type != null && ent.type.equals("short") == true) {
            f.setShort(null, Short.parseShort(ent.val));

        } else if (ent.type != null && ent.type.equals("string") == true) {
            f.set(null, ent.val);

        } else if (ent.type != null && ent.type.equals("bool") == true) {
            f.setBoolean(null, Boolean.parseBoolean(ent.val));

        } else {
            f.setInt(null, Integer.parseInt(ent.val));
        }
    }

    /**
     * Static main method.
     *
     * @param args      The command line arguments
     */
    public static final void main(String[] args) {
        if(GameSettings.RUN_OS_SPECIFIC_CODE) {
            RunOsSpecificCode();
        }
        
        if(GameSettings.LOAD_NATIVE_LIBRARIES) {
            LoadNativeLibraries();
        }

        //Store program arguments for future reference
        ARGS = args;        
        if (args != null && args.length > 0) {
            MmgHelper.wr("Found command line arguments!");
            String res = null;

            res = ArrayHasEntryLike("WIN_WIDTH=", args);
            if (res != null) {
                WIN_WIDTH = Integer.parseInt(res.split("=")[1]);
            }

            res = ArrayHasEntryLike("WIN_HEIGHT=", args);
            if (res != null) {
                WIN_HEIGHT = Integer.parseInt(res.split("=")[1]);
            }

            res = ArrayHasEntryLike("PANEL_WIDTH=", args);
            if (res != null) {
                PANEL_WIDTH = Integer.parseInt(res.split("=")[1]);
            }

            res = ArrayHasEntryLike("PANEL_HEIGHT=", args);
            if (res != null) {
                PANEL_HEIGHT = Integer.parseInt(res.split("=")[1]);
            }

            res = ArrayHasEntryLike("FPS=", args);
            if (res != null) {
                FPS = Integer.parseInt(res.split("=")[1]);
            }

            res = ArrayHasEntryLike("OPENGL=false", args);
            if(res == null) {
                System.setProperty("sun.java2d.opengl", "true");
                System.setProperty("sun.java2d.pmoffscreen", "false");
            }
            
            res = ArrayHasEntryLike("ENGINE_CONFIG_FILE=", args);
            if (res != null) {
                ENGINE_CONFIG_FILE = res.split("=")[1];
            }
            
            res = ArrayHasEntryLike("ODROID=true", args);
            if(res != null) {
                WIN_WIDTH = 480;
                WIN_HEIGHT = 320;
                PANEL_WIDTH = 478;
                PANEL_HEIGHT = 318;
                GAME_WIDTH = 478;
                GAME_HEIGHT = 318;
            }
        }

        //LOAD ENGINE CONFIG FILE
        try {
            if (PongClone.ENGINE_CONFIG_FILE != null && PongClone.ENGINE_CONFIG_FILE.equals("") == false) {
                GameSettingsImporter dci = new GameSettingsImporter();
                boolean r = dci.ImportGameSettings(PongClone.ENGINE_CONFIG_FILE);
                System.out.println("Engine config load result: " + r);

                if(r == true) {
                    int len = dci.GetValues().keySet().size();
                    String[] keys = dci.GetValues().keySet().toArray(new String[len]);
                    String key;
                    DatConstantsEntry ent = null;
                    Field f = null;

                    for (int i = 0; i < len; i++) {
                        try {
                            key = keys[i];
                            ent = dci.GetValues().get(key);

                            if (ent.from != null && ent.from.equals("GameSettings") == true) {
                                f = GameSettings.class.getField(ent.key);
                                if (f != null) {
                                    System.out.println("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                    SetField(ent, f);
                                }
                            } else if(ent.from != null && ent.from.equals("MmgHelper") == true) {
                                f = MmgHelper.class.getField(ent.key);
                                if (f != null) {
                                    System.out.println("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                    SetField(ent, f);
                                }
                            } else if(ent.from != null && ent.from.equals("StaticMain") == true) {
                                f = PongClone.class.getField(ent.key);
                                if (f != null) {
                                    System.out.println("Importing " + ent.from + " field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type + " from: " + ent.from);
                                    SetField(ent, f);
                                }             
                            }
                        } catch (Exception e) {
                            System.out.println("Ignoring dat constants field: " + ent.key + " with value: " + ent.val + " with type: " + ent.type);
                            MmgHelper.wrErr(e);
                        }
                    }
                }
            }
        } catch (Exception e) {
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

        mf = new MainFrame(PongClone.WIN_WIDTH, PongClone.WIN_HEIGHT, PongClone.PANEL_WIDTH, PongClone.PANEL_HEIGHT, PongClone.GAME_WIDTH, PongClone.GAME_HEIGHT);
        pnlGame = new GamePanel(mf, PongClone.PANEL_WIDTH, PongClone.PANEL_HEIGHT, (PongClone.WIN_WIDTH - PongClone.PANEL_WIDTH) / 2, (PongClone.WIN_HEIGHT - PongClone.PANEL_HEIGHT) / 2, PongClone.GAME_WIDTH, PongClone.GAME_HEIGHT);
        mf.SetGamePanel(pnlGame);
        mf.InitComponents();
        fr = new RunFrameRate(mf, FPS);

        mf.setSize(PongClone.WIN_WIDTH, PongClone.WIN_HEIGHT);
        mf.setResizable(false);
        mf.setVisible(true);
        mf.setName(GameSettings.NAME);

        if (GameSettings.DEVELOPMENT_MODE_ON == false) {
            mf.setTitle(GameSettings.TITLE);
        } else {
            mf.setTitle(GameSettings.TITLE + " - " + GameSettings.DEVELOPER_COMPANY + " (" + GameSettings.VERSION + ")");
        }
        
        mf.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        mf.GetGamePanel().PrepBuffers();
        t = new Thread(fr);
        t.start();
    }
}
