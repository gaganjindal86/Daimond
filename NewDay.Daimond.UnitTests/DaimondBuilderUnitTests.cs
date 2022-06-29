using System;
using Xunit;

namespace NewDayDaimond.Tests
{
    public class DaimondBuilderUnitTests
    {
        [Fact]
        public void Edge_Case()
        {
            Assert.Equal("A", new DiamondBuilder('A').GetDaimond());
        }

        [Theory]
        [InlineData('B', " A \r\nB B\r\n A")]
        [InlineData('C', "  A  \r\n B B \r\nC   C\r\n B B \r\n  A  ")]
        [InlineData('D', "   A   \r\n  B B  \r\n C   C \r\nD     D\r\n C   C \r\n  B B  \r\n   A   ")]
        public void Happy_Path(Char inputChar, String result)
        {   
            Assert.Equal(result.Trim(), new DiamondBuilder(inputChar).GetDaimond().Trim());
        }

        [Theory]
        [InlineData('C', 5)]
        public void Ensure_Line_Count(Char inputChar, Int32 result)
        {
            Assert.Equal(result, new DiamondBuilder(inputChar).GetDaimond().Split(Environment.NewLine).Length - 1);
        }

    }
}