package net.middlemind.MmgGameApiJava.MmgCore;

/**
 * The DatConstantsEntry class is used to hold data from an engine_config.xml file entry.
 * The data is used to set class field values at runtime from an XML file.
 * Created by Middlemind Games 01/05/2020
 * 
 * @author Victor G. Brusca
 */
public class DatConstantsEntry {

    /**
     * The key field holds the target class field's name that will receive the defined value. 
     */
    public String key;

    /**
     * The val field holds the value that the target class field will receive. 
     */
    public String val;
    
    /**
     * The type field holds a specified basic data type of the target class field.
     * Supported data types are int, float, double, short, string, bool.
     */
    public String type;     //int, float, double, short, string, bool
    
    /**
     * The from field holds a specified target class. This is the class that has the
     * field whose value we want to set. Supported classes are the GameSettings and Helper class.
     */
    public String from;     //GameSettings, Helper
    
    /**
     * DatConstantEntry constructor that defines the key, value, and type fields.
     * 
     * @param k     The key argument holds the target class field's name.
     * @param v     The value argument holds the desired value, in string form, for the target class field.
     * @param t     The type argument holds the basic data type of the target class field.
     */
    public DatConstantsEntry(String k, String v, String t) {
        key = k;
        val = v;
        type = t;
    }
    
    /**
     * DatConstantsEntry constructor that defines the key, value, type, and from fields.
     * 
     * @param k     The key argument holds the target class field's name.
     * @param v     The value argument holds the desired value, in string form, for the target class field.
     * @param t     The type argument holds the basic data type of the target class field, int, float, double, short, string, bool.
     * @param f     The from arguments holds the target class to work on, GameSettings or Helper class.
     */
    public DatConstantsEntry(String k, String v, String t, String f) {
        key = k;
        val = v;
        type = t;
        from = f;
    }
    
    /**
     * DatConstantsEntry constructor that defines the key, and value fields. This constructor sets
     * the type and from fields to default values int and GameSettings.
     * 
     * @param k     The key argument holds the target class field's name. 
     * @param v     The value argument holds the desired value, in string form, for the target class field.
     */
    public DatConstantsEntry(String k, String v) {
        key = k;
        val = v;
        type = "int";
        from = "GameSettings";
    }
}