using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core
{
    /// <summary>
    /// Enum that represents the Serialization Type that will be applied in the serialization process
    /// </summary>
    public enum SerializationType
    {
        /// <summary>
        /// XmlSerializer: Useful to work when the application has no limit to store the XML Data
        /// </summary>
        XmlSerializer,
        
        /// <summary>
        /// JavascriptSerializar: Useful to work with cookies and JSON
        /// </summary>
        JavaScriptSerializer

        
    }
}
