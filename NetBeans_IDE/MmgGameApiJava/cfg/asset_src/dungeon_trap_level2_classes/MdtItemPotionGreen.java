package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * A class that represents a green potion, full health.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemPotionGreen extends MdtItemPotion {
    
    /**
     * A basic constructor for the green potion class.
     */
    public MdtItemPotionGreen() {
        super(MmgHelper.GetBasicCachedBmp("potion_green_lg.png"), MdtItemPotionType.GREEN, MdtPointsType.PTS_100);
    }
    
    /**
     * A constructor for the green potion class that let's you specify the subject as an argument.
     * 
     * @param Subj      The subject of the class. 
     */
    public MdtItemPotionGreen(MmgBmp Subj) {
        super(Subj, MdtItemPotionType.GREEN, MdtPointsType.PTS_100);
    }
}