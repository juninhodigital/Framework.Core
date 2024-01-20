using System;
using System.ComponentModel;
using System.Reflection;

namespace Framework.Core
{
    /// <summary>
    /// Contains Enums Extension Methods
    /// </summary>
    public static partial class Extensions
	{
        #region| Methods |

        /// <summary>
        /// Check if a specific value is in the param collection
        /// </summary>
        /// <param name="enum">Input</param>
        /// <param name="values"></param>
        /// <returns>bool</returns>
        public static bool In(this Enum @enum, params Enum[] values)
        {
            var Has = false;

            for (int i = 0; i < values.Length; i++)
            {
                var item = values[i];

                if (item.Equals(@enum))
                {
                    Has = true;
                    break;
                }
            }

            return Has;
        } 

        /// <summary>
        /// Check if a specific value is not in the param collection
        /// </summary>
        /// <param name="enum">Input</param>
        /// <param name="values"></param>
        /// <returns>bool</returns>
        public static bool NotIn(this Enum @enum, params Enum[] values)
        {
            return !In(@enum, values);
        }

        /// <summary>
        /// Get the enum description
        /// </summary>    
        /// <param name="EnumValue"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum EnumValue)
        {
            return GetEnumDescription(EnumValue);
        }

        /// <summary>
        /// Get Enum Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetEnumDescription(Enum value)
        {
            var output = string.Empty;

            var fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    output = attributes[0].Description;
                }
                else
                {
                    output = value.ToString();
                }

                fi = null;
                attributes = null;
            }

            return output;
        }

        #endregion
    }
}
