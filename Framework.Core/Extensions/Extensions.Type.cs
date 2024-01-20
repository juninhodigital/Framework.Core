namespace Framework.Core
{
    /// <summary>
    /// Contains Type Extension Methods
    /// </summary>
    public static partial class Extensions
	{
        #region| Methods |

        /// <summary>
        /// Check whether the given type is a .NET native element
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNative(this Type @type)
        {
            var name = @type.Assembly.GetName();

            if (name != null && name.Name!=null)
            {
                return name.Name.IsEqual("mscorlib");
            }

            return false;
        }

        /// <summary>
        /// Check if the  underlying value type is of the System.Nullable generic type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>true/false</returns>
        public static bool IsNullableType(this Type @type)
        {
            if (@type == null)
            {
                return false;
            }
            else
            {
                return @type.IsGenericType && @type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
            }
        }

        #endregion
	}
}
