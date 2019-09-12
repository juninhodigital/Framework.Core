using System;
using Xunit;

namespace Framework.Core.Tests
{
    public partial class Tests
    {
        [Fact]
        public void ToInt()
        {
            var result = "10".ToInt();

            Assert.Equal(10, result);
        }

        [Fact]
        public void IsNotNull()
        {
            var result = "".IsNotNull();

            Assert.False(result);
        }

        // ThrowIfNull
        // ThrowIfNull (overload)
        // IsEqual
        // IsNotEqual
        // IsInt
        // IsDouble
        // IsFloat
        // IsDateTime
        // IsAlpha
        // IsAlphaNumeric
        // IsEmail
        // IsCPF
        // IsCNPJ
        // In
        // NotIn
        // Contains
        // ContainsAll
        // StartsWithAny
        // HasChar
        // Substring
        // GetAfter
        // GetBefore
        // GetBetween
        // IfNull
        // IfNullToDBNull
        // IsLike
        // Left
        // Right
        // FirstToUpper
        // CapitalizeAll
        // RemoveDiacritics
        // RemoveIllegalCharacters
        // Reverse
        // ToFile
        // Format
        // AddSingleQuotes
        // AddDoubleQuotes
        // ToCDATA
        // RemoveNumber
        // Repeat
        // SaveAs
        // Serialize
        // Deserialize
    }
}
