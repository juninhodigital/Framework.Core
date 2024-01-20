using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Framework.Core
{
    /// <summary>
    /// Contains XML Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        /// Determines whether the XML List is null
        /// </summary>
        /// <param name="XmlDocument">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNull<T>(this XmlDocument @XmlDocument)
        {
            return @XmlDocument == null;
        }

        /// <summary>
        /// Determines whether the XML List is not null
        /// </summary>
        /// <param name="XmlDocument">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNotNull<T>(this XmlDocument @XmlDocument)
        {
            return @XmlDocument == null;
        }


        /// <summary>
        /// Determines whether the XmlNode List is null or Empty
        /// </summary>
        /// <param name="XmlNode">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNull(this XmlNode @XmlNode)
        {
            if (@XmlNode == null || @XmlNode.ChildNodes == null || @XmlNode.ChildNodes.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the XmlNode List is not null and not Empty
        /// </summary>
        /// <param name="XmlNode">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNotNull(this XmlNode @XmlNode)
        {
            return !@XmlNode.IsNull();
        }

        /// <summary>
        /// TODO: COMENTAR
        /// </summary>
        public static string? GetAttribute(this XmlNode? @XmlNode, string? name)
        {
            if (name!=null && @XmlNode!=null && @XmlNode.Attributes!=null && @XmlNode.Attributes[name] != null)
            {
                var attribute = @XmlNode.Attributes[name];

                if(attribute != null) 
                {  
                    return attribute.Value; 
                }
            }
         
            return string.Empty;
        }

        /// <summary>
        /// TODO: COMENTAR
        /// </summary>
        public static XmlNode? GetNodes(this XmlNode @object, string name)
        {
            XmlNode? Aux = null;

            foreach (XmlNode oNode in @object.ChildNodes)
            {
                if (oNode.Name.IsEqual(name))
                {
                    Aux = oNode;
                }
            }

            return Aux;
        }

        /// <summary>
        /// TODO: COMENTAR
        /// </summary>
        public static XmlNode? GetNode(this XmlDocument @object, string name)
        {
            if (name.IsNull() || @object.IsNull() || @object.GetElementsByTagName(name).IsNull())
            {
                return null;
            }
            else
            {
                return @object.GetElementsByTagName(name)[0];
            }
        }

        /// <summary>
        /// TODO: COMENTAR
        /// </summary>
        public static string GetNodeText(this System.Xml.XmlNode @object, string name)
        {
            string Aux = string.Empty;

            foreach (XmlNode oChild in @object.ChildNodes)
            {
                if (oChild.Name.IsEqual(name))
                {
                    Aux = oChild.InnerText;
                    break;
                }
            }

            return Aux;
        }


        /// <summary>
        ///  This method validates that an System.Xml.Linq.XDocument conforms to an XSD in an System.Xml.Schema.XmlSchemaSet.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="XML_Path">The System.Xml.Linq.XDocument to validate</param>
        /// <param name="XSD_Path">An System.Xml.Schema.XmlSchemaSet to validate against</param>
        /// <returns></returns>
        public static bool ValidateSchema(this object @sender, string XML_Path, string XSD_Path)
        {
            try
            {
                bool HasErrors = false;

                var oSchema = new XmlSchemaSet();
                oSchema.Add("", XSD_Path);

                var oXDocument = XDocument.Load(XML_Path);

                if (oXDocument != null)
                {
                    oXDocument.Validate(oSchema, (o, e) =>
                    {
                        HasErrors = true;
                    });
                }

                oSchema = null;
                oXDocument = null;

                if (HasErrors)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
