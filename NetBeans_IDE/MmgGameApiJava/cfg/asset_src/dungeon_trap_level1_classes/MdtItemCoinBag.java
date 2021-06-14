package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;
import net.middlemind.MmgGameApiJava.MmgBase.MmgBmpScaler;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;

/**
 * A class that represents a purse full of coins.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemCoinBag extends MdtItem {
        
    /**
     * A basic constructor for the coin bag class.
     */
    public MdtItemCoinBag() {
        super(MmgBmpScaler.ScaleMmgBmp(MmgHelper.GetBasicCachedBmp("bag_coins_lg.png"), 1.5d, true), MdtObjType.ITEM, MdtObjSubType.ITEM_COINS, MdtPointsType.PTS_1000);
    }
    
    /**
     * A constructor for the coin bag class that lets you specify the subject as an argument.
     * 
     * @param Subj      The subject of the class. 
     */
    public MdtItemCoinBag(MmgBmp Subj) {
        super(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_COINS, MdtPointsType.PTS_1000);
    }
}