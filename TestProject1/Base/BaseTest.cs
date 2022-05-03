using Xunit.Abstractions;

namespace Framework.Core.Tests
{
    public abstract class BaseTest
    {
        #region| Fields |

        protected ITestOutputHelper output;

        #endregion

        #region| Constructor |

        public BaseTest(ITestOutputHelper testOutputHelper)
        {
            this.output = testOutputHelper;
        }
        #endregion
    }
}
