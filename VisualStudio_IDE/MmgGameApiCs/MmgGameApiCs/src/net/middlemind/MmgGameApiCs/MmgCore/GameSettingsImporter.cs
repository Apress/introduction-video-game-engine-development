using System;
using System.Collections.Generic;
using System.Xml;
using net.middlemind.MmgGameApiCs.MmgBase;

namespace net.middlemind.MmgGameApiCs.MmgCore
{
    /// <summary>
    /// The GameSettingsImporter class is used to load game settings data from an engine config XML file.
    /// The file data is stored in the values, Dictionary, class field for processing.Applying the rules
    /// would update class filed values of target classes.
    /// Created by Middlemind Games 01/05/2020
    /// 
    /// @author Victor G.Brusca
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
    public class GameSettingsImporter
    {
        /// <summary>
        /// A Dictionary used to store the engine config XML file rules after loading the file.
        /// </summary>
        public Dictionary<string, DatConstantsEntry> values;

        /// <summary>
        /// A class field used to store a version number.
        /// Can be used to differentiate different engine config file loads by version number.
        /// </summary>
        public string version;

        /// <summary>
        /// The RunImportGameSettings class method is used load engine config rules, XML data used to create a DatConstantsEntry class instance.
        /// </summary>
        /// <param name="xmlFile">The target engine config XML file to load.</param>
        public void RunImportGameSettings(string xmlFile)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlFile);
            values = new Dictionary<string, DatConstantsEntry>();
            XmlNode nodeMain = document.GetElementsByTagName("engineconfig")[0];
            version = nodeMain.Attributes["version"].Value;
            XmlNodeList nodeList = nodeMain.ChildNodes;

            if (version != null && version.Equals(GameSettings.TARGET_GAME_SETTINGS_XML_VERSION) == true)
            {
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];

                    if (node.NodeType == XmlNodeType.Element && node.Name.Equals("entry"))
                    {
                        XmlElement elem = (XmlElement)node;
                        string key = node.Attributes["key"].Value.ToUpper();
                        string val = node.Attributes["val"].Value;
                        string type = "int";
                        string from = "DatConstants";

                        if (node.Attributes["type"] != null)
                        {
                            type = node.Attributes["type"].Value.ToLower();
                        }

                        if (node.Attributes["from"] != null)
                        {
                            from = node.Attributes["from"].Value;
                        }

                        DatConstantsEntry ent = new DatConstantsEntry(key, val, type, from);
                        MmgHelper.wr("Found Key: " + key + " Value: " + val + " Type: " + type + " From: " + from);
                        values.Add(from + "." + key, ent);
                    }
                }
            }
            else
            {
                throw new Exception("Currently only supports version 1.0 of engine configuration files.");
            }
        }

        /// <summary>
        /// The ImportGameSettings method is used to load an engine config XML files in a safe way. 
        /// The method returns a bool value indicating if the XML file load is successful of not.
        /// </summary>
        /// <param name="xmlFile">The target engine config XML file to load.</param>
        /// <returns>Returns a bool flag indicating if the file load was successful.</returns>
        public virtual bool ImportGameSettings(string xmlFile)
        {
            bool res = false;
            try
            {
                RunImportGameSettings(xmlFile);
                res = true;
            }
            catch (Exception e)
            {
                MmgHelper.wrErr(e);
                res = false;
            }

            return res;
        }

        /// <summary>
        /// Returns a Dictionary of the loaded engine config file rules.
        /// </summary>
        /// <returns>A Dictionary of DatConstantsEntry class instances with engine config rules.</returns>
        public virtual Dictionary<string, DatConstantsEntry> GetValues()
        {
            return values;
        }

        /// <summary>
        /// Set the values class field with a Dictionary of DatConstantsEntry class instances.
        /// </summary>
        /// <param name="v">A Dictionary of DatConstantsEntry class instances with engine config rules.</param>
        public virtual void SetValues(Dictionary<string, DatConstantsEntry> v)
        {
            values = v;
        }

        /// <summary>
        /// Returns the class field version string.
        /// </summary>
        /// <returns>A string with the version code of this class.</returns>
        public virtual string GetVersion()
        {
            return version;
        }

        /// <summary>
        /// Sets the class field version string.
        /// </summary>
        /// <param name="v">A string with the version code for this class.</param>
        public virtual void SetVersion(string v)
        {
            version = v;
        }
    }
}