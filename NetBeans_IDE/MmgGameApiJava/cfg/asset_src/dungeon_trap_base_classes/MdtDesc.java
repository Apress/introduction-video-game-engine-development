package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;

/**
 * The interface for the MdtObj class.
 * Should be the super class of all Mmg Dungeon Trap game classes.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public interface MdtDesc {
    
    /**
     * Gets the type of this MdtObj instance.
     * 
     * @return      The type of this MdtObj instance.
     */
    public MdtObjType GetMdtType(); 
    
    /**
     * Sets the type of this MdtObj instance.
     * 
     * @param obj   The type of this MdtObj instance. 
     */
    public void SetMdtType(MdtObjType obj);
    
    /**
     * Gets the sub type of the MdtObj instance.
     * 
     * @return      The sub type of the MdtObj instance.
     */
    public MdtObjSubType GetMdtSubType();  
    
    /**
     * Sets the sub type of the MdtObj instance.
     * 
     * @param obj   The sub type of the MdtObj instance.
     */
    public void SetMdtSubType(MdtObjSubType obj);
    
    /**
     * Gets a rectangle representation of this MdtObj object instance.
     * 
     * @return      A rectangle representation of this MdtObj object instance. 
     */
    public MmgRect GetRect();
}