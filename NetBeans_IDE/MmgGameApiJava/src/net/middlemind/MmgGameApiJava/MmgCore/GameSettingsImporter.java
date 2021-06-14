package net.middlemind.MmgGameApiJava.MmgCore;

import java.io.File;
import java.io.IOException;
import java.util.Hashtable;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import net.middlemind.MmgGameApiJava.MmgBase.MmgHelper;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

/**
 * The GameSettingsImporter class is used to load game settings data from an engine config XML file.
 * The file data is stored in the values, Hashtable, class field for processing. Applying the rules 
 * would update class filed values of target classes.
 * Created by Middlemind Games 01/05/2020
 * 
 * @author Victor G. Brusca
 */
public class GameSettingsImporter {

    /**
     * A Hashtable used to store the engine config XML file rules after loading the file.
     */
    public Hashtable<String, DatConstantsEntry> values;
    
    /**
     * A class field used to store a version number.
     * Can be used to differentiate different engine config file loads by version number.
     */
    public String version;
    
    /**
     * The RunImportGameSettings class method is used load engine config rules, XML data used to create a DatConstantsEntry class instance.
     * 
     * @param xmlFile       The target engine config XML file to load.
     * 
     * @throws ParserConfigurationException
     * @throws SAXException
     * @throws IOException
     * @throws Exception 
     */
    public void RunImportGameSettings(String xmlFile) throws ParserConfigurationException, SAXException, IOException, Exception {
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();

        // Load the input XML document, parse it and return an instance of the document class
        Document document = builder.parse(new File(xmlFile));
        values = new Hashtable<String, DatConstantsEntry>();
        Node nodeMain = document.getElementsByTagName("engineconfig").item(0);
        version = nodeMain.getAttributes().getNamedItem("version").getNodeValue();
        NodeList nodeList = nodeMain.getChildNodes();

        if (version != null && version.equals(GameSettings.TARGET_GAME_SETTINGS_XML_VERSION) == true) {
            MmgHelper.wr("GameSettingsImporter: Found " + nodeList.getLength() + " nodes.");
            
            for (int i = 0; i < nodeList.getLength(); i++) {
                Node node = nodeList.item(i);

                if (node.getNodeType() == Node.ELEMENT_NODE && node.getNodeName().equals("entry")) {
                    String key = node.getAttributes().getNamedItem("key").getNodeValue().toUpperCase();
                    String val = node.getAttributes().getNamedItem("val").getNodeValue();
                    String type = "int";
                    String from = "DatConstants";
                    
                    if(node.getAttributes().getNamedItem("type") != null) {
                        type = node.getAttributes().getNamedItem("type").getNodeValue().toLowerCase();
                    }
                    
                    if(node.getAttributes().getNamedItem("from") != null) {
                        from = node.getAttributes().getNamedItem("from").getNodeValue();
                    }
                    
                    DatConstantsEntry ent = new DatConstantsEntry(key, val, type, from);
                    MmgHelper.wr("Found Key: " + key + " Value: " + val + " Type: " + type + " From: " + from);
                    values.put(from + "." + key, ent);
                }
            }
        } else {
            throw new Exception("Currently only supports version 1.0 of engine configuration files.");
        }
    }

    /**
     * The ImportGameSettings method is used to load an engine config XML files in a safe way. 
     * The method returns a boolean value indicating if the XML file load is successful of not.
     * 
     * @param xmlFile       The target engine config XML file to load.
     * @return              Returns a boolean flag indicating if the file load was successful.
     */
    public boolean ImportGameSettings(String xmlFile) {
        boolean res = false;
        try {
            RunImportGameSettings(xmlFile);
            res = true;
        } catch (Exception e) {
            MmgHelper.wrErr(e);
            res = false;
        }

        return res;
    }

    /**
     * Returns a Hashtable of the loaded engine config file rules.
     * 
     * @return      A Hashtable of DatConstantsEntry class instances with engine config rules. 
     */
    public Hashtable<String, DatConstantsEntry> GetValues() {
        return values;
    }

    /**
     * Set the values class field with a Hashtable of DatConstantsEntry class instances.
     * 
     * @param v     A Hashtable of DatConstantsEntry class instances with engine config rules.
     */
    public void SetValues(Hashtable<String, DatConstantsEntry> v) {
        values = v;
    }

    /**
     * Returns the class field version string.
     * 
     * @return      A string with the version code of this class.
     */
    public String GetVersion() {
        return version;
    }

    /**
     * Sets the class field version string.
     * 
     * @param v     A string with the version code for this class.
     */
    public void SetVersion(String v) {
        version = v;
    }
}