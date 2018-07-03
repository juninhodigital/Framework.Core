using System;
using System.Collections;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Framework.Core
{
    /// <summary>
    /// Contains XDocument Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Convert a XDocument element into a XmlDocument
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this XDocument @this)
        {
            var oXmlDocument = new XmlDocument();
            
            oXmlDocument.Load(@this.CreateReader());

            return oXmlDocument;
        }
        
        /// <summary>
        /// Converts a XmlDocument element into a XDocument
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static XDocument ToXDocument(this XmlDocument @this)
        {
            using (var oNodeReader = new XmlNodeReader(@this))
            {
                oNodeReader.MoveToContent();
                return XDocument.Load(oNodeReader);
            }
        }
        
        /// <summary>
        /// Converts a XmlNode element into XElement
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static XElement GetXElement(this XmlNode @this)
        {
            var oXDocument = new XDocument();

            using (XmlWriter xmlWriter = oXDocument.CreateWriter())
                @this.WriteTo(xmlWriter);
            return oXDocument.Root;
        }
        
        /// <summary>
        /// Converts the XElemento element into XmlNode
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static XmlNode GetXmlNode(this XElement @this)
        {
            using (var oXmlReader = @this.CreateReader())
            {
                var oXmlDocument = new XmlDocument();
                oXmlDocument.Load(oXmlReader);
                return oXmlDocument;
            }
        }

        /// <summary>
        /// Creates a new XDocument with UTF-8 encoding as it's default 
        /// </summary>
        /// <returns></returns>
        public static XDocument NewDocument()
        {
            var doc = new XDocument(new XDeclaration("1.0", "UTF-8", null));
            return doc;
        }

        /// <summary>
        /// Adds a new XElement with given name to the document and returns the added element
        /// </summary>
        public static XElement NewElement(this XDocument doc, string name)
        {
            if (null == doc)
            {
                throw new ArgumentNullException("doc");
            }
            if (null == name)
            {
                throw new ArgumentNullException("name");
            }
            var el = new XElement((XName)name);
            doc.Add(el);
            return el;
        }

        /// <summary>
        /// Adds a new XElement with given name to the element and returns the added element
        /// </summary>
        public static XElement NewElement(this XElement node, string name, bool returnNewElement = true)
        {
            if (null == node)
            {
                throw new ArgumentNullException("node");
            }
            if (null == name)
            {
                throw new ArgumentNullException("name");
            }
            var el = new XElement((XName)name);
            node.Add(el);
            return returnNewElement ? el : node;
        }

        /// <summary>
        /// Adds a new XElement with given name to the element, content and returns the added element
        /// </summary>
        public static XElement NewElement(this XElement node, string name, string content, bool returnNewElement = true)
        {
            var el = node.NewElement(name);
            el.SetValue(content);
            return returnNewElement ? el : node;
        }

        /// <summary>
        /// Adds an XElement node to the document
        /// </summary>
        public static XDocument AddChild(this XDocument doc, XElement child)
        {
            if (null == doc)
            {
                throw new ArgumentNullException("doc");
            }
            if (null == child)
            {
                throw new ArgumentNullException("child");
            }
            doc.Add(child);
            return doc;
        }

        /// <summary>
        /// Adds an XElement node to the XElement node
        /// </summary>
        public static XElement AddChild(this XElement node, XElement child)
        {
            if (null == node)
            {
                throw new ArgumentNullException("node");
            }
            if (null == child)
            {
                throw new ArgumentNullException("child");
            }
            node.Add(child);
            return node;
        }

        /// <summary>
        /// Adds an XAttribute node to the XElement node
        /// </summary>
        public static XElement AddChild(this XElement node, XAttribute attrib)
        {
            if (null == node)
            {
                throw new ArgumentNullException("node");
            }
            if (null == attrib)
            {
                throw new ArgumentNullException("attrib");
            }
            node.Add(attrib);
            return node;
        }

        /// <summary>
        /// Adds an XAttribute node to the XElement node
        /// </summary>
        public static XElement AddAttribute(this XElement node, string name, string value)
        {
            if (node.IsNull())
            {
                throw new ArgumentNullException("node");
            }

            if (name.IsNull())
            {
                throw new ArgumentNullException("name");
            }

            node.SetAttributeValue(name, value);

            return node;
        }

        /// <summary>
        /// Remove all the namespace from a XDocument
        /// </summary>
        /// <param name="document"></param>
        public static void StripNamespace(this XDocument document)
        {
            if (document.Root == null)
            {
                return;
            }
            foreach (var element in document.Root.DescendantsAndSelf())
            {
                element.Name = element.Name.LocalName;
                element.ReplaceAttributes(GetAttributes(element));
            }
        }

        /// <summary>
        /// Get a attribute from a XElement
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        static IEnumerable GetAttributes(XElement xElement)
        {
            return xElement.Attributes()
                .Where(x => !x.IsNamespaceDeclaration)
                .Select(x => new XAttribute(x.Name.LocalName, x.Value));
        }

        #endregion
    }
}
