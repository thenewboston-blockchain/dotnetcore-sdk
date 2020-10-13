using System;
using Xunit;

namespace Thenewboston.Tests
{
    public class Test
    {
        /// <summary>
        /// Just a simple test to prove the CI pipeline works.
        /// </summary>
        [Fact]
        public void JustATest()
        {
            int I = 2;
            int you = 3;

            Assert.True(I < 3 * you);
        }
    }
}
