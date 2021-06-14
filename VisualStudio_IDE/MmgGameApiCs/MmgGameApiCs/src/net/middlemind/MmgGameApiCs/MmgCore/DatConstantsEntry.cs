using System;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The DatConstantsEntry class is used to hold data from an engine_config.xml file entry.
    /// The data is used to set class field values at runtime from an XML file.
    /// Created by Middlemind Games 01/05/2020
    ///
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class DatConstantsEntry
    {
        /// <summary>
        /// The key field holds the target class field's name that will receive the defined value. 
        /// </summary>
        public string key;

        /// <summary>
        /// The val field holds the value that the target class field will receive.
        /// </summary>
        public string val;

        /// <summary>
        /// The type field holds a specified basic data type of the target class field.
        /// Supported data types are int, float, double, short, string, bool.
        /// </summary>
        public string type;     //int, float, double, short, string, bool

        /// <summary>
        /// The from field holds a specified target class. This is the class that has the
        /// field whose value we want to set.Supported classes are the GameSettings and Helper class.
        /// </summary>
        public string from;     //GameSettings, Helper

        /// <summary>
        /// DatConstantEntry constructor that defines the key, value, and type fields.
        /// </summary>
        /// <param name="k">The key argument holds the target class field's name.</param>
        /// <param name="v">The value argument holds the desired value, in string form, for the target class field.</param>
        /// <param name="t">The type argument holds the basic data type of the target class field.</param>
        public DatConstantsEntry(string k, string v, string t)
        {
            key = k;
            val = v;
            type = t;
        }

        /// <summary>
        /// DatConstantsEntry constructor that defines the key, value, type, and from fields.
        /// </summary>
        /// <param name="k">The key argument holds the target class field's name.</param>
        /// <param name="v">The value argument holds the desired value, in string form, for the target class field.</param>
        /// <param name="t">The type argument holds the basic data type of the target class field, int, float, double, short, string, bool.</param>
        /// <param name="f">The from arguments holds the target class to work on, GameSettings or Helper class.</param>
        public DatConstantsEntry(string k, string v, string t, string f)
        {
            key = k;
            val = v;
            type = t;
            from = f;
        }

        /// <summary>
        /// DatConstantsEntry constructor that defines the key, and value fields. This constructor sets
        /// the type and from fields to default values int and GameSettings.
        /// </summary>
        /// <param name="k">The key argument holds the target class field's name.</param>
        /// <param name="v">The value argument holds the desired value, in string form, for the target class field.</param>
        public DatConstantsEntry(string k, string v)
        {
            key = k;
            val = v;
            type = "int";
            from = "GameSettings";
        }
    }
}