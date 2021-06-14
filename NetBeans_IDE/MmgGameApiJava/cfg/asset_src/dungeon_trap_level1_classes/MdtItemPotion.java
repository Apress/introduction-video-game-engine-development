package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgBmp;

/**
 * A class that represents a yellow potion.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtItemPotion extends MdtItem {
    
    /**
     * The type of potion this class represents.
     */
    public MdtItemPotionType potionType = MdtItemPotionType.NONE;
        
    /**
     * A basic constructor for the yellow potion class.
     * 
     * @param Subj          The subject to use for this potion.
     * @param PotionType    The potion type to use for this item.
     * @param Points        The points type to use for this potion.
     */
    public MdtItemPotion(MmgBmp Subj, MdtItemPotionType PotionType, MdtPointsType Points) {
        super(Subj, MdtObjType.ITEM, MdtObjSubType.ITEM_POTION, Points);
        SetPotionType(PotionType);
    }

    /**
     * Gets the subject of the class.
     * 
     * @return      The subject of the class. 
     */
    @Override
    public MmgBmp GetSubj() {
        return (MmgBmp)subj;
    }

    /**
     * Gets the potion type of this object.
     * 
     * @return      The potion type of this object.
     */
    public MdtItemPotionType GetPotionType() {
        return potionType;
    }
    
    /**
     * Sets the potion type of this object.
     * 
     * @param PotionType    The potion type of this object. 
     */
    public void SetPotionType(MdtItemPotionType PotionType) {
        potionType = PotionType;
    }
}