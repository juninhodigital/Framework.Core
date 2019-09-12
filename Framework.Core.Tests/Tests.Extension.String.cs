using Xunit;
using Xunit.Abstractions;

namespace Framework.Core.Tests
{
    [Trait("Category", "String")]
    public partial class Tests : BaseTest
    {
        #region| Constructor |

        public Tests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion

        #region| Tests |

        [Fact]
        public void ToInt()
        {
            output.WriteLine("The method will start");

            var result = "10".ToInt();

            output.WriteLine("The method finished");

            Assert.Equal(10, result);
        }

        [Fact]
        public void IsNotNull()
        {
            var result = "".IsNotNull();

            Assert.False(result);
        }

        [Theory]
        [InlineData("John")]
        [InlineData("Mary")]
        [InlineData("junior")]
        [InlineData("Joe")]
        [InlineData("Junior")]
        public void Test(string input)
        {
            Assert.Equal("Junior", input, false);
        }

        #endregion
               
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
