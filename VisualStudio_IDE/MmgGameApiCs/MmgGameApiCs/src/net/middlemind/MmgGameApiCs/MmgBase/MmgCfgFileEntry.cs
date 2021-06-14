using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace net.middlemind.MmgGameApiCs.MmgBase
{
    /// <summary>
    /// Class used to store rows of information from a class config text file.
    /// Created by Middlemind Games 03/15/2020
    /// 
    /// @author Victor G. Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public class MmgCfgFileEntry : IComparer<MmgCfgFileEntry>
    {
        /// <summary>
        /// An enumeration that specifies the type of data the CfgEntryType holds.
        /// </summary>
        public enum CfgEntryType
        {
            TYPE_DOUBLE,
            TYPE_STRING,
            NONE
        }

        /// <summary>
        /// The type of data this MmgCfgFileEntry holds.
        /// </summary>
        public CfgEntryType cfgType = CfgEntryType.NONE;

        /// <summary>
        /// The double value this MmgCfgFileEntry holds, if it holds numeric data.
        /// </summary>
        public Double number;

        /// <summary>
        /// The string value this MmgCfgFileEntry holds, if it holds string data.
        /// </summary>
        public string str;

        /// <summary>
        /// The name or key of this MmgCfgFileEntry.
        /// </summary>
        public string name;

        /// <summary>
        /// The base constructor for this class.
        /// </summary>
        public MmgCfgFileEntry()
        {

        }

        /// <summary>
        /// A specialized constructor that creates a new object based on the fields of the constructor argument.
        /// </summary>
        /// <param name="obj">The object to use to create a new MmgCfgFileEntry instance.</param>
        public MmgCfgFileEntry(MmgCfgFileEntry obj)
        {
            number = obj.number;
            str = obj.str;
            name = obj.name;
            cfgType = obj.cfgType;
        }

        /// <summary>
        /// Creates a typed clone of this class.
        /// </summary>
        /// <returns>A typed clone of this class.</returns>
        public virtual MmgCfgFileEntry Clone()
        {
            return new MmgCfgFileEntry(this);
        }

        /// <summary>
        /// A standard method that prints the contents of this MmgCfgFileEntry.
        /// </summary>
        /// <returns>A string representation of this class.</returns>
        public virtual string ApiToString()
        {
            string ret = "";

            if (name != null && name.Equals("") == false)
            {
                if (cfgType == CfgEntryType.TYPE_DOUBLE)
                {
                    ret = name.Trim() + "=" + number.ToString();

                }
                else if (cfgType == CfgEntryType.TYPE_STRING)
                {
                    ret = name.Trim() + "->" + str;

                }
            }

            return ret;
        }

        /// <summary>
        /// A comparison method used when sorting MmgCfgFileEntry objects.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>An integer indicating the order of the objects.</returns>
        public virtual int Compare([AllowNull] MmgCfgFileEntry o1, [AllowNull] MmgCfgFileEntry o2)
        {
            return o1.name.ToLowerInvariant().CompareTo(o2.name.ToLowerInvariant());
        }

        /// <summary>
        /// A method that checks to see if this MmgCfgFileEntry is equal to the passed in MmgCfgFileEntry.
        /// </summary>
        /// <param name="obj">The MmgCfgFileEntry object instance to test for equality.</param>
        /// <returns>Returns true if both MmgCfgFileEntry objects are the same.</returns>
        public virtual bool ApiEquals(MmgCfgFileEntry obj)
        {
            if (obj == null)
            {
                return false;
            }
            else if (obj.Equals(this))
            {
                return true;
            }

            bool ret = false;
            if (obj.cfgType == cfgType
                && ((obj.name == null && name == null) || (obj.name != null && name != null && obj.name.Equals(name)))
                && obj.number == number
                && ((obj.str == null && str == null) || (obj.str != null && str != null && obj.str.Equals(str)))
            )
            {
                ret = true;
            }
            return ret;
        }
    }
}