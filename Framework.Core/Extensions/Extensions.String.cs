using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml.Serialization;
using System.Linq;
using System.Security;
using Newtonsoft.Json;

namespace Framework.Core
{
    /// <summary>
    /// Contains String Extension Methods
    /// </summary>
    public static partial class Extensions
    {
        #region| Conversion |

        /// <summary>
        ///  Converts the string representation of a number to its 32-bit signed integer equivalent. 
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <returns>int</returns>
        public static int ToInt(this string @string)
        {
            return int.Parse(@string);
        }

        /// <summary>
        /// Converts any type in to an Int32 but if null then returns the default
        /// </summary>
        /// <param name="string">Value to convert</param>
        /// <typeparam name="T">Any Object</typeparam>
        /// <param name="defaultValue">Default to use in case of fail in the conversion process</param>
        /// <returns>int</returns>
        /// <example>
        /// <code>
        ///     int badNumber = "a".ToInt32(100); // Returns 100 since a is nan
        /// </code>
        /// </example>
        public static int ToInt32<T>(this string @string, int defaultValue)
        {
            int result;

            if (int.TryParse(@string.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        ///  Converts the string representation of a boolean
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <returns>bool</returns>
        public static bool ToBool(this string @string)
        {
            return bool.Parse(@string);
        }

        /// <summary>
        ///  Converts the string representation of a boolean
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <param name="defaultValue">Default to use in case of fail in the conversion process</param>
        /// <returns>bool</returns>
        public static bool ToBool(this string @string, bool defaultValue)
        {
            bool result;

            if (bool.TryParse(@string.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        ///  Converts the string representation of a DateTime
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this string @string)
        {
            return DateTime.Parse(@string);
        }

        /// <summary>
        /// Converts the string representation of a DateTime
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <param name="defaultValue">Default to use in case of fail in the conversion process</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this string @string, DateTime defaultValue)
        {
            DateTime result;

            if (DateTime.TryParse(@string.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        ///  Converts the string representation of a float
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <returns>float</returns>
        public static float ToFloat(this string @string)
        {
            return float.Parse(@string);
        }

        /// <summary>
        /// Converts the string representation of a float
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <param name="defaultValue">Default to use in case of fail in the conversion process</param>
        /// <returns>float</returns>
        public static float ToFloat(this string @string, float defaultValue)
        {
            float result;

            if (float.TryParse(@string.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        ///  Converts the string representation of a double
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <returns>double</returns>
        public static double ToDouble(this string @string)
        {
            return double.Parse(@string);
        }

        /// <summary>
        /// Converts the string representation of a double
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <param name="defaultValue">Default to use in case of fail in the conversion process</param>
        /// <returns>double</returns>
        public static double ToDouble(this string @string, double defaultValue)
        {
            double result;

            if (double.TryParse(@string.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        ///  Converts the string representation of a decimal
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this string @string)
        {
            return decimal.Parse(@string);
        }

        /// <summary>
        /// Converts the string representation of a decimal
        /// </summary>
        /// <param name="string">A string containing a value to be convert.</param>
        /// <param name="defaultValue">Default to use in case of fail in the conversion process</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(this string @string, decimal defaultValue)
        {
            decimal result;

            if (decimal.TryParse(@string.ToString(), out result))
            {
                return result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Returns a generic list that contains the substrings in this instance that are delimited by elements of a specified Unicode character array.
        /// </summary>
        /// <param name="string">string</param>
        /// <param name="separator">separator</param>
        /// <returns>List of String</returns>
        public static List<string> Split(this string @string, char separator)
        {
            List<string> oList = new List<string>();

            if (@string.IsNull())
            {
                return oList;
            }
            else
            {
                var Itens = @string.Split(separator);

                for (int i = 0; i < Itens.Length; i++)
                {
                    var Item = Itens[i];

                    oList.Add(Item);
                }
            }

            return oList;
        }

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits.
        /// </summary>
        /// <param name="string">input</param>
        /// <returns>The string representation, in base 64, of the contents of inArray.</returns>
        public static string EncodeBase64(this string @string)
        {
            return Convert.ToBase64String(@string.ToByteArray<ASCIIEncoding>());
        }

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-64 digits to string
        /// </summary>
        /// <param name="string">input</param>
        /// <returns>string</returns>
        public static string DecodeBase64(this string @string)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(@string));
        }

        /// <summary>
        /// Encodes all the characters in the specified System.String into a sequence of bytes.
        /// </summary>
        /// <typeparam name="T">Encoding</typeparam>
        /// <param name="string">input</param>
        /// <returns> The string representation, in base 64, of the contents of inArray.</returns>
        public static byte[] ToByteArray<T>(this string @string) where T : Encoding
        {
            return Activator.CreateInstance<T>().GetBytes(@string);
        }

        /// <summary>
        /// Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.
        /// </summary>
        /// <param name="string">The string to decode.</param>
        /// <returns>A decoded string</returns>
        public static string HtmlDecode(this string @string)
        {
            return HttpUtility.HtmlDecode(@string);
        }

        /// <summary>
        /// Converts a string to an HTML-encoded string.
        /// </summary>
        /// <param name="string">The string to encode.</param>
        /// <returns>An encoded string.</returns>
        public static string HtmlEncode(this string @string)
        {
            return HttpUtility.HtmlEncode(@string);
        }

        /// <summary>
        /// Converts a string into an enum structurue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="string"></param>
        /// <returns>An Enum element</returns>
        public static T ToEnum<T>(this string @string) where T : struct
        {
            if (Enum.IsDefined(typeof(T), @string))
            {
                return (T)Enum.Parse(typeof(T), @string, true);
            }
            else
            {
                foreach (string value in Enum.GetNames(typeof(T)))
                {
                    if (value.Equals(@string, StringComparison.OrdinalIgnoreCase))
                    {
                        return (T)Enum.Parse(typeof(T), value);
                    }
                }

                return default(T);
            }

        }

        /// <summary>
        ///     A String extension method that converts the @this to a secure string.
        /// </summary>
        /// <param name="string">The @this to act on.</param>
        /// <returns>@this as a SecureString.</returns>
        public static SecureString ToSecureString(this string @string)
        {
            var secureString = new SecureString();

            foreach (Char c in @string)
            {
                secureString.AppendChar(c);
            }

            return secureString;
        }

        #endregion

        #region| Validation |

        /// <summary>
        /// Throws an exception whether the incoming parameter is null
        /// </summary>
        /// <param name="string"></param>
        public static void ThrowIfNull(this string @string)
        {
            if (@string.IsNull())
            {
                throw new ArgumentNullException("the given parameter cannot be empty or null.");
            }
        }

        /// <summary>
        /// Throws an exception whether the incoming parameter is null
        /// and raises an exception with a custom error message
        /// </summary>
        /// <param name="string"></param>
        /// <param name="message">error message</param>
        public static void ThrowIfNull(this string @string, string message)
        {
            if (@string.IsNull())
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Determines whether this string and a specified System.String object have
        /// the same value. A parameter specifies the culture, case, and sort rules used
        /// in the comparison.
        /// </summary>
        /// <param name="string">The string to compare to this instance</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEqual(this string @string, string input)
        {
            if (@string.IsNull())
            {
                @string = string.Empty;
            }
            
            return @string.Trim().Equals(input.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines whether this string and a specified System.String object don't have
        /// the same value. A parameter specifies the culture, case, and sort rules used
        /// in the comparison.
        /// </summary>
        /// <param name="string">The string to compare to this instance</param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotEqual(this string @string, string input)
        {
            return !@string.IsEqual(input);
        }

        /// <summary>
        /// Check if the input value is int
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsInt(this string @string)
        {
            if (@string.IsNull())
            {
                return false;
            }

            var Number = 0;

            try
            {
                return int.TryParse(@string, out Number);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the input value is double
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsDouble(this string @string)
        {
            if(@string.IsNull())
            {
                return false;
            }

            var Number = 0.0;

            try
            {
                return double.TryParse(@string, out Number);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the input value is float
        /// </summary>
        /// <param name="string">Input</param>
        /// <returns>bool</returns>
        public static bool IsFloat(this string @string)
        {
            if (@string.IsNull())
            {
                return false;
            }

            try
            {
                Convert.ToSingle("0" + @string);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if the input value is DateTime
        /// </summary>
        /// <param name="string">Input</param>
        /// <returns>bool</returns>
        public static bool IsDateTime(this string @string)
        {
            if (@string.IsNull())
            {
                return false;
            }

            try
            {
                Convert.ToDateTime(@string);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     A string extension method that query if '@this' is Alpha.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if Alpha, false if not.</returns>
        public static bool IsAlpha(this string @this)
        {
            return !Regex.IsMatch(@this, "[^a-zA-Z]");
        }

        /// <summary>
        /// Check if the input value is an AlhpaNumeric string
        /// </summary>
        /// <param name="string">Input</param>
        /// <returns>bool</returns>
        public static bool IsAlphaNumeric(this string @string)
        {
            try
            {
                string pattern = @"([a-zA-Z0-9])";
                return Regex.IsMatch(@string, pattern);
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Check if the input value is a valid e-mail address format
        /// </summary>
        /// <param name="string">Input</param>
        /// <returns>bool</returns>
        public static bool IsEmail(this string @string)
        {
            try
            {
                string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                return Regex.IsMatch(@string, pattern);
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Validate id CPF is valid.
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsCPF(this string @string)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            @string = @string.Trim();
            @string = @string.Replace(".", "").Replace("-", "");

            if (@string.Length != 11)
            {
                return false;
            }

            tempCpf = @string.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }


            digito  = resto.ToString();
            tempCpf = tempCpf + digito;
            soma    = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;

            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();

            return @string.EndsWith(digito);
        }

        /// <summary>
        /// Validate if CNPJ is valid.
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsCNPJ(this string @string)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma, resto;

            string digito, tempCnpj;

            @string = @string.Trim();
            @string = @string.Replace(".", "").Replace("-", "").Replace("/", "");

            if (@string.Length != 14)
                return false;

            tempCnpj = @string.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];


            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;

            soma = 0;


            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];


            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return @string.EndsWith(digito);
        }
        
        #endregion

        #region| Search |

        /// <summary>
        /// Check if a specific value is in the param collection
        /// </summary>
        /// <param name="string">Input</param>
        /// <param name="values"></param>
        /// <returns>bool</returns>
        public static bool In(this string @string, params string[] values)
        {
            if (values.IsNull())
            {
                return false;
            }
            else
            {
                var Has = false;

                for (int i = 0; i < values.Length; i++)
                {
                    var item = values[i];

                    if (item.IsEqual(@string))
                    {
                        Has = true;
                        break;
                    }
                }

                return Has;
            }
        }

        /// <summary>
        /// Check if a specific value is not in the param collection
        /// </summary>
        /// <param name="string">Input</param>
        /// <param name="values"></param>
        /// <returns>bool</returns>
        public static bool NotIn(this string @string, params string[] values)
        {
            return !In(@string, values);
        }

        /// <summary>
        /// Check if the string constains the param collection values
        /// </summary>
        /// <param name="string">Input String</param>
        /// <param name="input">input</param>
        /// <param name="IgnoreCase">Indicates whether the StringComparison.InvariantCultureIgnoreCase will be used to search the string</param>
        /// <returns>bool</returns>
        public static bool Contains(this string @string, string input, bool IgnoreCase)
        {
            if (input.IsNull())
            { 
                return false;
            }

            if(IgnoreCase)
            {
                return @string.IndexOf(input, StringComparison.InvariantCultureIgnoreCase) >= 0;
            }
            else
	        {
                return @string.IndexOf(input) >= 0;
	        }
        }

        /// <summary>
        /// Check if the string contains all the param collection values
        /// </summary>
        /// <param name="string">Input String</param>
        /// <param name="IgnoreCase">Use comparison like StringComparison.InvariantCultureIgnoreCase</param>
        /// <param name="values">param collection</param>
        /// <returns>bool</returns>
        public static bool ContainsAll(this string @string, bool IgnoreCase, params string[] values)
        {
            var Has = true;

            for (int i = 0; i < values.Length; i++)
            {
                var item = values[i];

                if (@string.Contains(item, true) == false)
                {
                    Has = false;
                    break;
                }
            }

            return Has;
        }

        /// <summary>
        /// <para>Determines whether the beginning of this string instance matches</para>
        /// <para>one of the specified strings.</para>
        /// </summary>
        /// <param name="string">The string</param>
        /// <param name="values">The param collection</param>
        /// <returns>true if any value matches the beginning of this string; otherwise, false.</returns>
        public static bool StartsWithAny(this string @string, params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];

                if (@string.StartsWith(value))
                { 
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check if a char exists in the string
        /// </summary>
        /// <param name="string">The string</param>
        /// <param name="oChar">char</param>
        /// <returns></returns>
        public static bool HasChar(this string @string, char oChar)
        {
            if (@string.IsNull())
            {
                return false;
            }
            else
            {
                if (@string.IndexOf(oChar) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="string">Input String</param>
        /// <param name="value">string to search the index</param>
        /// <returns>string</returns>
        public static string Substring(this string @string, string value)
        {
            if (@string.IsNull())
            {
                return string.Empty;
            }
            else
            {
                if (@string.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    return @string.Substring(0, @string.IndexOf(value));
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        ///     A string extension method that get the string after the specified string.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="value">The value to search.</param>
        /// <returns>The string after the specified value.</returns>
        public static string GetAfter(this string @this, string value)
        {
            if (@this.IndexOf(value) == -1)
            {
                return "";
            }
            return @this.Substring(@this.IndexOf(value) + value.Length);
        }

        /// <summary>
        ///     A string extension method that get the string before the specified string.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="value">The value to search.</param>
        /// <returns>The string before the specified value.</returns>
        public static string GetBefore(this string @this, string value)
        {
            if (@this.IndexOf(value) == -1)
            {
                return "";
            }
            return @this.Substring(0, @this.IndexOf(value));
        }

        /// <summary>
        ///     A string extension method that get the string between the two specified string.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="before">The string before to search.</param>
        /// <param name="after">The string after to search.</param>
        /// <returns>The string between the two specified string.</returns>
        public static string GetBetween(this string @this, string before, string after)
        {
            int beforeStartIndex = @this.IndexOf(before);
            int startIndex = beforeStartIndex + before.Length;
            int afterStartIndex = @this.IndexOf(after, startIndex);

            if (beforeStartIndex == -1 || afterStartIndex == -1)
            {
                return "";
            }

            return @this.Substring(startIndex, afterStartIndex - startIndex);
        }

        /// <summary>
        ///     A string extension method that if empty.
        /// </summary>
        /// <param name="string">the string to act on</param>
        /// <param name="value">The default value.</param>
        /// <returns>.</returns>
        public static string IfNull(this string @string, string value)
        {
            return (@string.IsNotNull() ? @string : value);
        }

        /// <summary>
        /// If the string is null or empty, returns DBNull.Value
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static object IfNullToDBNull(this string @string)
        {
            return (@string.IsNotNull() ? (object)@string : DBNull.Value);
        }

        /// <summary>
        ///     A string extension method that query if '@this' satisfy the specified pattern.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="pattern">The pattern to use. Use '*' as wildcard string.</param>
        /// <returns>true if '@this' satisfy the specified pattern, false if not.</returns>
        /// <example>
        ///     <code>
        ///        var @sample = "FizzBuzz3";
        ///
        ///        bool value1 = @sample.IsLike("Fizz*"); // return true;
        ///        bool value2 = @sample.IsLike("*zzB*"); // return true;
        ///        bool value3 = @sample.IsLike("*Buzz#"); // return true;
        ///        bool value4 = @sample.IsLike("*zz?u*"); // return true;     
        ///     </code>
        /// </example>
        public static bool IsLike(this string @this, string pattern)
        {
            // Turn the pattern into regex pattern, and match the whole string with ^$
            string regexPattern = "^" + Regex.Escape(pattern) + "$";

            // Escape special character ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            return Regex.IsMatch(@this, regexPattern);
        }

        #endregion

        #region| General |

        /// <summary>
        /// Execute the Substring method to retrieve the Left portion of the string
        /// </summary>
        /// <param name="string">string</param>
        /// <param name="length">length</param>
        /// <returns>string</returns>
        public static string Left(this string @string, int length)
        {
            if (@string.IsNotNull() && length <= @string.Length && length >= 0)
            {
                return @string.Substring(0, length);
            }

            return @string;
        }

        /// <summary>
        /// Execute the Substring method to retrieve the Right portion of the string
        /// </summary>
        /// <param name="string">string</param>
        /// <param name="length">length</param>
        /// <returns>string</returns>
        public static string Right(this string @string, int length)
        {
            if (@string.IsNotNull() && length <= @string.Length && length >= 0)
            {
                return @string.Substring(@string.Length - length);
            }

            return @string;
        }

        /// <summary>
        /// Convert the First Letter to UpperCase
        /// </summary>
        /// <param name="string">Input</param>
        /// <returns>string</returns>
        public static string FirstToUpper(this string @string)
        {
            if (string.IsNullOrEmpty(@string)) return string.Empty;

            string Aux = @string.ToLower();

            var item = Aux[0].ToString().ToUpper();

            Aux = Aux.Substring(1);
            Aux = Aux.Insert(0, item);

            return Aux;
        }

        /// <summary>
        /// Capitalize All
        /// </summary>
        /// <param name="string">text</param>
        /// <returns>string</returns>
        public static string CapitalizeAll(this string @string)
        {
            var oCultureInfo = Thread.CurrentThread.CurrentCulture;
            var oTextInfo = oCultureInfo.TextInfo;

            return oTextInfo.ToTitleCase(@string.ToLower());
        }

        /// <summary>
        /// Removes special characters (Diacritics) from the string
        /// </summary>
        /// <param name="string">String to strip</param>
        /// <returns>Stripped string</returns>
        private static string RemoveDiacritics(this string @string)
        {
            var oNormalized = @string.Normalize(NormalizationForm.FormD);
            var oStringBuilder = new StringBuilder();

            for (int i = 0; i < oNormalized.Length; i++)
            {
                Char TempChar = oNormalized[i];

                if (CharUnicodeInfo.GetUnicodeCategory(TempChar) != UnicodeCategory.NonSpacingMark)
                {
                    oStringBuilder.Append(TempChar);
                }
            }

            return oStringBuilder.ToString();
        }

        /// <summary>
        /// Remove Illegal Characters
        /// </summary>
        /// <param name="string">Text to clean</param>
        /// <returns>String</returns>
        public static string RemoveIllegalCharacters(this string @string)
        {
            string Aux = @string;

            char[] Specials = new char[27];

            Specials[0]  = char.Parse("=");
            Specials[1]  = char.Parse(@"\");
            Specials[2]  = char.Parse(";");
            Specials[3]  = char.Parse(".");
            Specials[4]  = char.Parse(":");
            Specials[5]  = char.Parse(",");
            Specials[6]  = char.Parse("+");
            Specials[7]  = char.Parse("*");
            Specials[8]  = char.Parse("<");
            Specials[9]  = char.Parse(">");
            Specials[10] = char.Parse("?");
            Specials[11] = char.Parse("'");
            Specials[12] = char.Parse("/");
            Specials[13] = char.Parse("#");
            Specials[14] = char.Parse("]");
            Specials[15] = char.Parse("[");
            Specials[16] = char.Parse("@");
            Specials[17] = char.Parse("&");
            Specials[18] = char.Parse("-");
            Specials[19] = char.Parse("%");
            Specials[20] = char.Parse("(");
            Specials[21] = char.Parse(")");
            Specials[22] = char.Parse("$");
            Specials[23] = char.Parse("!");
            Specials[24] = char.Parse("_");
            Specials[25] = char.Parse("¨");
            Specials[26] = char.Parse("\"");

            int pos;

            while ((pos = Aux.IndexOfAny(Specials)) >= 0)
            {
                Aux = Aux.Remove(pos, 1);
            }

            if (Aux.IndexOf('\n') > 0)
            {
                Aux = Aux.Remove(Aux.IndexOf('\n'), 1);
            }

            if (Aux.IndexOf(@"\t") > 0)
            {
                Aux = Aux.Remove(Aux.IndexOf('\n'), 1);
            }

            if (Aux.IndexOf('\r') > 0)
            {
                Aux = Aux.Remove(Aux.IndexOf('\r'), 1);
            }

            Aux = RemoveDiacritics(Aux);
            Aux = Aux.Replace(@"\n", " ");

            return Aux;
        }

        /// <summary>
        ///  Reverse the order of a string
        /// </summary>
        /// <param name="string">input</param>
        /// <returns>string</returns>
        public static string Reverse(this string @string)
        {
            var reversed = @string.ToCharArray();
            
            Array.Reverse(reversed);

            return new string(reversed);
        }

        /// <summary>
        /// Writes the instance of System.String to a new file or overwrites the existing file.
        /// </summary>
        /// <param name="string">The string to write to file</param>
        /// <param name="FilePath">The file to write the string to</param>
        /// <param name="Encoding">Encoding to write the file</param>
        public static void ToFile(this string @string, string FilePath, Encoding @Encoding = null)
        {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
            {
                Directory.CreateDirectory(FilePath);
            }

            if (@Encoding.IsNull())
            {
                @Encoding = Encoding.GetEncoding("ISO-8859-1");
            }

            var oStreamWriter = new StreamWriter(File.Open(FilePath, FileMode.OpenOrCreate), @Encoding);

            using (oStreamWriter)
            {
                oStreamWriter.Write(@string);
            }

            oStreamWriter.Flush();
            oStreamWriter.Dispose();

        }

        /// <summary>
        /// Replaces the format item in a specified string with the string representation of a corresponding object in a specified array.
        /// </summary>
        /// <param name="string">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format</param>
        /// <returns> A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string Format(this string @string, params object[] args)
        {
            return string.Format(@string, args);
        }

        /// <summary>
        /// TODO: COMENTAR
        /// </summary>
        public static string AddSingleQuotes(this string @string)
        {
            return string.Concat("'", @string, "'");
        }

        /// <summary>
        /// TODO: COMENTAR
        /// </summary>
        public static string AddDoubleQuotes(this string @string)
        {
            return string.Concat("\"", @string, "\"");
        }

        /// <summary>
        /// Encapsulate the string into the CDATA
        /// </summary>
        /// <param name="string">A composite format string</param>
        public static string ToCDATA(this string @string)
        {
            return string.Concat("<![CDATA[", @string, "]]>");
        }

        /// <summary>
        ///     A string extension method that removes the number described by @this.
        /// </summary>
        /// <param name="string">The @this to act on.</param>
        /// <returns>.</returns>
        /// <example>
        ///     <code>
        ///       string @sample = "Jun1or1979";    
        ///           
        ///       string result = @sample.RemoveNumber(); // return "Junior";    
        ///           
        ///     </code>
        /// </example>
        public static string RemoveNumber(this string @string)
        {
            return new string(@string.ToCharArray().Where(x => !Char.IsNumber(x)).ToArray());
        }

        /// <summary>
        ///  A string extension method that repeats the string a specified number of times.
        /// </summary>
        /// <param name="string">The @this to act on.</param>
        /// <param name="repeatCount">Number of repeats.</param>
        /// <returns>The repeated string.</returns>
        /// <example>
        ///     <code>
        ///           string @sample = "Sample";
        ///           
        ///           string value = @sample.Repeat(3); // return "SampleSampleSample";
        ///     </code>
        /// </example>
        public static string Repeat(this string @string, int repeatCount)
        {
            if (@string.Length == 1)
            {
                return new string(@string[0], repeatCount);
            }

            var oSB = new StringBuilder(repeatCount * @string.Length);

            while (repeatCount-- > 0)
            {
                oSB.Append(@string);
            }

            return oSB.ToString();
        }

        /// <summary>
        ///     A string extension method that save the string into a file.
        /// </summary>
        /// <param name="string">The @this to act on.</param>
        /// <param name="fileName">Filename of the file.</param>
        /// <param name="append">(Optional) if the text should be appended to file file if it's exists.</param>
        public static void SaveAs(this string @string, string fileName, bool append = false)
        {
            using (TextWriter tw = new StreamWriter(fileName, append))
            {
                tw.Write(@string);
            }
        }

        /// <summary>
        ///     A string extension method that save the string into a file.
        /// </summary>
        /// <param name="string">The @this to act on.</param>
        /// <param name="file">The FileInfo.</param>
        /// <param name="append">(Optional) if the text should be appended to file file if it's exists.</param>
        public static void SaveAs(this string @string, FileInfo file, bool append = false)
        {
            using (TextWriter tw = new StreamWriter(file.FullName, append))
            {
                tw.Write(@string);
            }
        }

        #endregion

        #region| Serialization |

        /// <summary>
        /// Serialize objects of the specified type into XML documents
        /// </summary>
        /// <typeparam name="T">typeof</typeparam>
        /// <param name="Entity">Entity</param>
        /// <param name="SerializationType">SerializationType can be XmlSerializer or JavaScriptSerializer</param>
        /// <returns>XML</returns>
        public static string Serialize<T>(this T Entity, SerializationType SerializationType = SerializationType.XmlSerializer)// where T: class, new()
        {
            
            var XML = string.Empty;

            if (SerializationType == SerializationType.XmlSerializer)
            {
                var oSerializer = new XmlSerializer(typeof(T));
                var oStringWriter = new StringWriter();

                oSerializer.Serialize(oStringWriter, Entity);

                string SerializedXML = oStringWriter.ToString();

                oStringWriter.Close();
                oStringWriter.Dispose();

                oSerializer = null;

                XML = SerializedXML.Replace("utf-16", "iso-8859-1"); ;
            }
            else
            {
                XML = JsonConvert.SerializeObject(Entity);
            }

            return XML;
        }

        /// <summary>
        /// Serialize objects of the specified type into XML documents
        /// </summary>
        /// <typeparam name="T">typeof</typeparam>
        /// <param name="string">Entity representation in XML format</param>
        /// <param name="SerializationType">SerializationType can be XmlSerializer or JavaScriptSerializer</param>
        /// <returns>T</returns>
        public static T Deserialize<T>(this string @string, SerializationType SerializationType) where T: class, new()
        {
            var oEntity = Activator.CreateInstance<T>();

            if (SerializationType == SerializationType.XmlSerializer)
            {
                var oSerializer = new XmlSerializer(typeof(T));

                using (var oReader = new StringReader(@string))
                {
                    oEntity = (T)oSerializer.Deserialize(oReader);
                }
            }
            else
            {
                oEntity = JsonConvert.DeserializeObject<T>(@string);
            }

            return oEntity;

        }
        
        #endregion
      
    }
}
