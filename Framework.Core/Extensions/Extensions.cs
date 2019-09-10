using System;
using System.IO;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Framework.Core
{
    /// <summary>
    /// Providers Extension Methods that are a special kind of static method, 
    /// but they are called as if they were instance methods on the extended type. 
    /// </summary>
    public static partial class Extensions
    {
        #region| Methods |

        /// <summary>
        ///  Attempts to send an Internet Control Message Protocol (ICMP) echo message to the specified computer, and receive a corresponding ICMP echo reply message  from that computer.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="nameOrAddress">Name or IP Address</param>
        /// <returns>true if the Ping Reply is equal success</returns>
        public static bool PingHost(this object sender, string nameOrAddress)
        {

            bool IsOnline = false;

            Ping oPing = new Ping();


            try
            {

                var oPingReply = oPing.Send(nameOrAddress);


                IsOnline = oPingReply.Status == IPStatus.Success;

            }

            catch (PingException)
            {

                // Discard PingExceptions and return false;
                IsOnline = false;

            }


            return IsOnline;

        }

        /// <summary>
        /// Returns an object of the specified type and whose value is equivalent to the specified object.
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="sender">An object that implements the System.IConvertible interface.</param>
        /// <param name="CanRaiseException">if true, the return will be default(T), otherwise will be null</param>
        /// <returns> 
        /// An object whose type is conversionType and whose value is equivalent to value.
        /// A null reference (Nothing in Visual Basic), if value is null and conversionType is not a value type.
        /// </returns>
        public static T CastTo<T>(this object @sender, bool CanRaiseException = true)// where T: IConvertible
        {
            if (@sender.IsNull())
            {
                return default(T);
            }
            else
            {
                if (CanRaiseException)
                {
                    return (T)Convert.ChangeType(@sender, typeof(T));
                }
                else
                {
                    try
                    {
                        return CastTo<T>(@sender);
                    }
                    catch
                    {
                        return default(T);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Try/Catch to any methods
        /// </summary>
        /// <example>
        /// <code>
        ///  this.TryCatch(() => 
        ///  {
        ///        Metodo1();
        ///        Metodo2();
        ///  });
        /// </code>
        /// </example>
        /// <param name="object"></param>
        /// <param name="oMethod"></param>
        public static void TryCatch(this object @object, Action oMethod)
        {
            try
            {
                //code to call before each methods
                oMethod();
                //code to call after each methods success
            }
            catch (ThreadAbortException)
            {
                //Do nothing due to redirect
            }
            catch (IOException)
            {
                //TODO: Implement SEH here
            }
        }

        /// <summary>
        /// Returns the second parameter if the object is null, otherwise return the object
        /// </summary>
        /// <typeparam name="T">paramtype</typeparam>
        /// <param name="object">sender</param>
        /// <param name="value">value that will be applied if the sender is null</param>
        /// <returns>value</returns>
        public static T IfIsNull<T>(this T @object, T value)
        {
            if (@object.IsNull())
            {
                return value;
            }
            else
            {
                return @object;
            }
        }

        /// <summary>
        /// The miss the Visual Basic's With statement method
        /// </summary>
        /// <typeparam name="T">paramtype</typeparam>
        /// <param name="object">sender</param>
        /// <example>
        /// <code>
        /// LongVariableName.With(x => 
        /// {
        ///     x.ID            = 123;
        ///     x.Name          = "Junior";
        ///     x.Description   = "Framework";
        /// });
        /// 
        /// </code>
        /// </example>
        /// <param name="oAction"></param>
        public static void With<T>(this T @object, Action<T> oAction)
        {
            oAction(@object);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="object"></param>
        /// <param name="expression"></param>
        /// <example>
        /// <code>
        ///   var Nome = oUsuario.Property(o=> o.Nome);
        /// </code>
        /// </example>
        /// <returns></returns>
        public static string Property<T, TResult>(this T @object, Expression<Func<T, TResult>> expression) where T : class, new()
        {
            return ((MemberExpression)expression.Body).Member.Name;
        }

        /// <summary>
        ///  Gets a value that indicates whether a debugger is attached to the process.
        /// </summary>
        /// <param name="object">sender</param>
        /// <returns>true if a debugger is attached; otherwise, false.</returns>
        public static bool IsDebug(this object @object)
        {
            return System.Diagnostics.Debugger.IsAttached;
        }

        
        /// <summary>
        /// A T extension method that makes a deep copy of '@this' object.
        /// </summary>
        /// <typeparam name="T">Generic type parameter</typeparam>
        /// <param name="this">The @this to act on</param>
        /// <returns>The copied object</returns>
        public static T DeepClone<T>(this T @this)
        {
            var oFormatter = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                oFormatter.Serialize(stream, @this);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)oFormatter.Deserialize(stream);
            }
        }

        /// <summary>
        ///  A T extension method that that return the first not null value (including the @this).
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="values">A variable-length parameters list containing values.</param>
        /// <returns>The first not null value.</returns>

        public static T Coalesce<T>(this T @this, params T[] values) where T : class
        {
            if (@this != null)
            {
                return @this;
            }

            foreach (T value in values)
            {
                if (value != null)
                {
                    return value;
                }
            }

            return null;
        }

        #endregion

        #region| Comparison |

        /// <summary>
        /// Determines whether the specified value is null or empty.
        /// </summary>
        /// <param name="object">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNull(this object @object)
        {
            return @object == null ? true : false;                    
        }

        /// <summary>
        /// Determines whether the specified value is not null and not empty.
        /// </summary>
        /// <param name="object">The value.</param>
        /// <returns>
        /// 	true if the specified value is null; otherwise, false.
        /// </returns>
        public static bool IsNotNull(this object @object)
        {
            return !@object.IsNull();
        }

        /// <summary>
        ///     Returns an indication whether the specified object is of type .
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="value">An object.</param>
        /// <returns>true if  is of type ; otherwise, false.</returns>
        public static Boolean IsDBNull<T>(this T value) where T : class
        {
            return Convert.IsDBNull(value);
        }

        /// <summary>
        /// Throws an exception whether the incoming parameter is null
        /// </summary>
        /// <param name="object"></param>
        public static void ThrowIfNull(this object @object)
        {
            if (@object.IsNull())
            {
                
                throw new ArgumentNullException("the given parameter cannot be empty or null");
            }
        }

        /// <summary>
        /// Throws an exception whether the incoming parameter is null
        /// and raises an exception with a custom error message
        /// </summary>
        /// <param name="object"></param>
        /// <param name="message">error message</param>
        public static void ThrowIfNull(this object @object, string message)
        {
            if (@object.IsNull())
            {
                throw new ArgumentNullException(message);
            }
        }

        #endregion
    }
}
