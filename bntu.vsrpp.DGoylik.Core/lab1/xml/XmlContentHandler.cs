using bntu.vsrpp.DGoylik.Core.lab1.xml.exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace bntu.vsrpp.DGoylik.Core.lab1.xml
{
    public static class XmlContentHandler
    {
        private const string STRING_TYPE = "string";
        private const string NUMBER_TYPE = "number";

        private const string FULL_NAME = "FullName";
        private const string FIRST_NAME = "FirstName";
        private const string LAST_NAME = "LastName";
        private const string MIDDLE_NAME = "MiddleName";

        private static XDocument document;
        private static string elementName;

        public static void normalize()
        {
            XmlDocument xmlDoc = createXmlDocument();
            XmlElement root = createRootElement(xmlDoc);

            Dictionary<string, string> keys = getAllKeysWithTheirTypes();
            normalizeFullName(keys);

            var elements = getElements();
            foreach (var item in elements)
            {
                addToXml(xmlDoc, createXmlElement(xmlDoc, root), getXmlElements(item, keys));
            }

            try
            {
                XmlIOHandler.saveXmlFile(xmlDoc);
            }
            catch (XmlIOException ex)
            {
                throw new XmlContentException("Cannot save xml file.", ex);
            }
        }

        private static XmlDocument createXmlDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);
            return xmlDoc;
        }

        private static XmlElement createRootElement(XmlDocument xmlDoc)
        {
            XmlElement root = xmlDoc.CreateElement(document.Root.Name.ToString());
            xmlDoc.AppendChild(root);
            return root;
        }

        private static void normalizeFullName(Dictionary<string, string> keys)
        {
            if (keys.Keys.Contains(FULL_NAME))
            {
                keys.Remove(FULL_NAME);
                if (!keys.Keys.Contains(FIRST_NAME))
                {
                    keys.Add(FIRST_NAME, STRING_TYPE);
                }

                if (!keys.Keys.Contains(LAST_NAME))
                {
                    keys.Add(LAST_NAME, STRING_TYPE);
                }

                if (!keys.Keys.Contains(MIDDLE_NAME))
                {
                    keys.Add(MIDDLE_NAME, STRING_TYPE);
                }
            }
        }

        private static XmlElement createXmlElement(XmlDocument xmlDoc, XmlElement root)
        {
            XmlElement element = xmlDoc.CreateElement(elementName);
            root.AppendChild(element);
            return element;
        }

        private static Dictionary<string, string> getXmlElements(Dictionary<string, string> item, Dictionary<string, string> keys)
        {
            const string defaultNumber = "0";
            const string defaultString = "N/A";
            Dictionary<string, string> xmlElements = new Dictionary<string, string>();
            foreach (var key in keys)
            {
                string value;
                if (item.ContainsKey(FULL_NAME))
                {
                    string fullName = item[FULL_NAME];
                    item.Add(FIRST_NAME, fullName.Split(' ')[1]);
                    item.Add(LAST_NAME, fullName.Split(' ')[0]);
                    item.Add(MIDDLE_NAME, fullName.Split(' ')[2]);
                    item.Remove(FULL_NAME);
                }

                if (item.ContainsKey(key.Key))
                {
                    value = item[key.Key];
                }
                else
                {
                    value = key.Value.Equals(NUMBER_TYPE) ? defaultNumber : defaultString;
                }

                xmlElements.Add(key.Key, value);
            }

            return xmlElements;
        }

        private static void addToXml(XmlDocument doc, XmlElement parent, Dictionary<string, string> elements)
        {
            foreach (var element in elements)
            {
                XmlElement xmlElement = doc.CreateElement(element.Key);
                xmlElement.InnerText = element.Value;
                parent.AppendChild(xmlElement);
            }
        }

        private static Dictionary<string, string> getAllKeysWithTheirTypes()
        {
            Dictionary<string, string> keysWTypes = new Dictionary<string, string>();
            var elements = getElements();
            foreach (var item in elements)
            {
                foreach (var entry in item)
                {
                    if (!keysWTypes.Keys.Contains(entry.Key))
                    {
                        keysWTypes.Add(entry.Key, Regex.IsMatch(entry.Value, @"^\d+(\.\d+)?$") ? NUMBER_TYPE : STRING_TYPE);
                    }
                }
            }

            return keysWTypes;
        }

        public static void setElementNameAndLoad(string name)
        {
            elementName = name;
            try
            {
                document = XmlIOHandler.loadXmlFile();
            }
            catch (XmlIOException e)
            {
                throw new XmlContentException("Exception while loading xml in XmlHandler.", e);
            }
        }

        public static bool isXmlFileSet()
        {
            return document != null;
        }

        public static string getContent()
        {
            return document.ToString();
        }

        public static int getObjectCount()
        {
            if (elementName is null) throw new XmlContentException("Element name is null.");
            return document.Descendants(elementName).Count();
        }

        public static IEnumerable<Dictionary<string, string>> getElements()
        {
            return document.Descendants(elementName).Select(element =>
            {
                var elementData = new Dictionary<string, string>();
                foreach (var attribute in element.Attributes())
                    elementData[attribute.Name.LocalName] = attribute.Value;

                foreach (var childElement in element.Elements())
                    elementData[childElement.Name.LocalName] = childElement.Value;

                return elementData;
            });
        }
    }
}
