package net.middlemind.MmgGameApiJava.MmgTestSpace;

import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * An application specific extension of the MmgCore's MainFrame class.
 * Created by Middlemind Games 02/19/2020
 * 
 * @author Victor G. Brusca
 */
public class MainFrame extends net.middlemind.MmgGameApiJava.MmgCore.MainFrame {
    
    /**
     * Constructor that sets the window width and height, the JFrame width and height, and the game width and height.
     * 
     * @param WinWidth      The desired window width.
     * @param WinHeight     The desired window height.
     * @param PanWidth      The desired JFrame width.
     * @param PanHeight     The desired JFrame height.
     * @param GameWidth     The desired game width.
     * @param GameHeight    The desired game height.
     */
    public MainFrame(int WinWidth, int WinHeight, int PanWidth, int PanHeight, int GameWidth, int GameHeight) {
        super(WinWidth, WinHeight, PanWidth, PanHeight, GameWidth, GameHeight);
        MmgHelper.wr("MainFrame.Constructor");
    }
    
    /**
     * Constructor that sets the window width and height, and defaults the X, Y offsets to 0. 
     * It also sets the JFrame and game width and height to that of the window width and height.
     *
     * @param WinWidth      The desired window width.
     * @param WinHeight     The desired window height.
     */
    public MainFrame(int WinWidth, int WinHeight) {
        super(WinWidth, WinHeight);
        MmgHelper.wr("MainFrame.Constructor");        
    }    
    
}
