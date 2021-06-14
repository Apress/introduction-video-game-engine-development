package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * A class that represents a yellow potion.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemPotionYellow extends MdtItemPotion {
    
    /**
     * A basic constructor for the yellow potion class.
     */
    public MdtItemPotionYellow() {
        super(MmgHelper.GetBasicCachedBmp("potion_yellow_lg.png"), MdtItemPotionType.YELLOW, MdtPointsType.PTS_100);
    }
    
    /**
     * A constructor for the yellow potion class that let's you specify the subject as an argument.
     * 
     * @param Subj      The subject of the class.
     */
    public MdtItemPotionYellow(MmgBmp Subj) {
        super(Subj, MdtItemPotionType.YELLOW, MdtPointsType.PTS_100);
    }
}