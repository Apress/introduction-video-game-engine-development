package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * A class that represents a red potion.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemPotionRed extends MdtItemPotion {
    
    /**
     * A basic constructor for the red potion class.
     */
    public MdtItemPotionRed() {
        super(MmgHelper.GetBasicCachedBmp("potion_red_lg.png"), MdtItemPotionType.RED, MdtPointsType.PTS_100);
    }
    
    /**
     * A constructor for the red potion class that let's you specify the subject as an argument.
     * 
     * @param Subj      The subject of the class. 
     */
    public MdtItemPotionRed(MmgBmp Subj) {
        super(Subj, MdtItemPotionType.RED, MdtPointsType.PTS_100);
    }
}