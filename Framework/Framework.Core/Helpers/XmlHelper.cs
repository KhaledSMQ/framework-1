// ============================================================================
// Project: Framework
// Name/Class: XmlHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper functions for Xml.
// ============================================================================                    

using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Framework.Core.Helpers
{
    public class XmlHelper
    {
        //
        // Escape a Xml string value.
        // TODO: Highly inneficient...
        //

        public static string Escape(string xml)
        {
            if (xml.IndexOf("&") >= 0)
            {
                xml = xml.Replace("&", "&amp;");
            }

            if (xml.IndexOf("'") >= 0)
            {
                xml = xml.Replace("'", "&apos;");
            }

            if (xml.IndexOf("\"") >= 0)
            {
                xml = xml.Replace("\"", "&quot;");
            }

            if (xml.IndexOf("<") >= 0)
            {
                xml = xml.Replace("<", "&lt;");
            }

            if (xml.IndexOf(">") >= 0)
            {
                xml = xml.Replace(">", "&gt;");
            }

            return xml;
        }

        //
        // Unscape a Xml string value.
        // TODO: Highly inneficient...
        //

        public static string Unescape(string xml)
        {
            if (xml.IndexOf("&amp;") >= 0)
            {
                xml = xml.Replace("&amp;", "&");
            }

            if (xml.IndexOf("&apos;") >= 0)
            {
                xml = xml.Replace("&apos;", "'");
            }

            if (xml.IndexOf("&quot;") >= 0)
            {
                xml = xml.Replace("&quot;", "\"");
            }

            if (xml.IndexOf("&lt;") >= 0)
            {
                xml = xml.Replace("&lt;", "<");
            }

            if (xml.IndexOf("&gt;") >= 0)
            {
                xml = xml.Replace("&gt;", ">");
            }

            return xml;
        }
        //
        // Pretty Print the input Xml string, such as adding indentations 
        // to each level of elements and carriage return to each line
        //

        public static string FormatNicely(string xml, Encoding enc = null)
        {
            string output = string.Empty;

            if (!string.IsNullOrWhiteSpace(xml))
            {
                MemoryStream memStream = new MemoryStream();
                XmlTextWriter xmlWriter = new XmlTextWriter(memStream, null != enc ? enc : Encoding.Unicode);
                XmlDocument xmlDoc = new XmlDocument();

                try
                {
                    // 
                    // Load the Xml document with the XML.
                    //

                    xmlDoc.LoadXml(xml);

                    //
                    // Set the indent format option.
                    //

                    xmlWriter.Formatting = Formatting.Indented;

                    // 
                    // Write the XML into a formatting XmlTextWriter
                    //

                    xmlDoc.WriteContentTo(xmlWriter);
                    xmlWriter.Flush();
                    memStream.Flush();

                    //
                    // Have to rewind the MemoryStream in order to read
                    // its contents.
                    //

                    memStream.Position = 0;

                    // 
                    // Read MemoryStream contents into a StreamReader.
                    //

                    StreamReader streamReader = new StreamReader(memStream);

                    // 
                    // Extract the text from the StreamReader.
                    //

                    output = streamReader.ReadToEnd();
                }
                catch (Exception)
                {
                    // 
                    // On any error, return the unchanged Xml text.
                    // Return the original unchanged.
                    //

                    output = xml;
                }
                finally
                {
                    memStream.Close();
                    xmlWriter.Close();
                }
            }

            return output;
        }
    }
}
