package net.middlemind.MmgGameApiJava.MmgBase;

import java.util.Comparator;

/**
 * Class used to store rows of information from a class config text file.
 * Created by Middlemind Games 03/15/2020
 * 
 * @author Victor G. Brusca
 */
public class MmgCfgFileEntry implements Comparator<MmgCfgFileEntry> {
    
    /**
     * An enumeration that specifies the type of data the CfgEntryType holds.
     */
    public enum CfgEntryType {
        TYPE_DOUBLE,
        TYPE_STRING,
        NONE
    }
    
    /**
     * The type of data this MmgCfgFileEntry holds.
     */
    public CfgEntryType cfgType = CfgEntryType.NONE;
    
    /**
     * The double value this MmgCfgFileEntry holds, if it holds numeric data.
     */
    public Double number;
    
    /**
     * The string value this MmgCfgFileEntry holds, if it holds string data.
     */
    public String str;
    
    /**
     * The name or key of this MmgCfgFileEntry.
     */
    public String name;
    
    /**
     * The base constructor for this class.
     */
    public MmgCfgFileEntry() {
        
    }
    
    /**
     * A specialized constructor that creates a new object based on the fields of the constructor argument.
     * 
     * @param obj       The object to use to create a new MmgCfgFileEntry instance.
     */
    public MmgCfgFileEntry(MmgCfgFileEntry obj) {
        number = obj.number;
        str = obj.str;
        name = obj.name;
        cfgType = obj.cfgType;
    }
    
    /**
     * Creates a typed clone of this class.
     * 
     * @return      A typed clone of this class.
     */
    public MmgCfgFileEntry Clone() {
        return new MmgCfgFileEntry(this);
    }
        
    /**
     * A standard method that prints the contents of this MmgCfgFileEntry.
     * 
     * @return      A string representation of this class.
     */
    public String ApiToString() {
        String ret = "";

        if(name != null && name.equals("") == false) {
            if(cfgType == CfgEntryType.TYPE_DOUBLE) {
                ret = name.trim() + "=" + number.toString();

            } else if(cfgType == CfgEntryType.TYPE_STRING) {
                ret = name.trim() + "->" + str;

            }
        }
        
        return ret;
    }
    
    /**
     * A comparison method used when sorting MmgCfgFileEntry objects.
     * 
     * @param o1        The first object to compare. 
     * @param o2        The second object to compare.
     * @return          An integer indicating the order of the objects.
     */
    @Override
    public int compare(MmgCfgFileEntry o1, MmgCfgFileEntry o2) {
        return o1.name.compareToIgnoreCase(o2.name);
    }

    /**
     * A method that checks to see if this MmgCfgFileEntry is equal to the passed in MmgCfgFileEntry.
     * 
     * @param c     The MmgCfgFileEntry object instance to test for equality.
     * @return      Returns true if both MmgCfgFileEntry objects are the same.
     */
    public boolean ApiEquals(MmgCfgFileEntry obj) {
        if(obj == null) {
            return false;
        } else if(obj.equals(this)) {
            return true;
        }
                
        boolean ret = false;
        if(obj.cfgType == cfgType 
            && ((obj.name == null && name == null) || (obj.name != null && name != null && obj.name.equals(name)))
            && obj.number == number 
            && ((obj.str == null && str == null) || (obj.str != null && str != null && obj.str.equals(str)))
        ) {
            ret = true;
        }
        return ret;
    }    
}