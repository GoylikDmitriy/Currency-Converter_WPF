using bntu.vsrpp.DGoylik.Core.lab1.xml.exceptions;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace bntu.vsrpp.DGoylik.Core.lab1.xml
{
    public static class XmlIOHandler
    {
        public static string FILE_NAME;
        public static XDocument loadXmlFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                InitialDirectory = "D:\\university stuffs\\VDTPA\\xml files"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FILE_NAME = openFileDialog.FileName;
                try
                {
                    return XDocument.Load(FILE_NAME);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading XML file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                throw new XmlIOException("You havent selected a file.");
            }

            throw new XmlIOException("Exception while loading xml.");
        }

        public static void saveXmlFile(XmlDocument document)
        {
            if (FILE_NAME is null)
            {
                throw new XmlIOException("Cant save xml, cause FILE NAME is null.");
            } 

            document.Save(FILE_NAME.Replace(".xml", "_output.xml"));
        }
    }
}
