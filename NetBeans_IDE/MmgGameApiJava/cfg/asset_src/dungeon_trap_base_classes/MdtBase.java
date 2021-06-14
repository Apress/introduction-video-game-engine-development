package game.jam.DungeonTrap;

import net.middlemind.MmgGameApiJava.MmgBase.MmgObj;
import net.middlemind.MmgGameApiJava.MmgBase.MmgRect;

/**
 * An MdtBase object that extends the MmgObj class and implements the MdtDesc interface.
 * 
 * @author Victor G. Brusca, Middlemind Games
 * 09/19/2020
 */
public class MdtBase extends MmgObj implements MdtDesc {
    
    /**
     * The type of this MdtObj instance.
     */
    private MdtObjType mdtType = MdtObjType.NONE;
        
    /**
     * The sub type of this MdtObj instance.
     */
    private MdtObjSubType mdtSubType = MdtObjSubType.NONE;    
    
    /**
     * A generic constructor that takes no arguments.
     */
    public MdtBase() {
        
    }
    
    /**
     * Gets the type of this MdtObj instance.
     * 
     * @return      The type of this MdtObj instance.
     */
    public MdtObjType GetMdtType() {
        return mdtType;
    }

    /**
     * Sets the type of this MdtObj instance.
     * 
     * @param obj   The type of this MdtObj instance. 
     */
    public void SetMdtType(MdtObjType obj) {
        mdtType = obj;
    }

    /**
     * Gets the sub type of the MdtObj instance.
     * 
     * @return      The sub type of the MdtObj instance. 
     */
    @Override
    public MdtObjSubType GetMdtSubType() {
        return mdtSubType;
    }

    /**
     * Sets the sub type of the MdtObj instance.
     * 
     * @param obj   The sub type of the MdtObj instance. 
     */
    @Override
    public void SetMdtSubType(MdtObjSubType obj) {
        mdtSubType = obj;
    }

    /**
     * Gets a rectangle representation of this MdtObj object instance.
     * 
     * @return      A rectangle representation of this MdtObj object instance.
     */
    @Override
    public MmgRect GetRect() {
        return new MmgRect(GetPosition(), GetWidth(), GetHeight());
    }
}