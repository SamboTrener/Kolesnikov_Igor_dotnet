using System;
using Xunit;
using Hw1;

namespace Hw1Tests
{
    public class Tests
    {
        [Theory]
        [InlineData("1", "+", "x")]
        [InlineData("1", "-", "x")]
        [InlineData("1", "*", "x")]
        [InlineData("1", "/", "x")]
        public void WrongArgFormatEveryOperation(string arg1, string arg2, string arg3)
        {
            var args = new[] {arg1, arg2, arg3};
            var result = Program.Main(args);
            Assert.True(result == 1);
        } 

        [Fact]
        public void WrongArgLen()
        {
            var args = new[] {"11", "11", "11", "11",};
            var result = Program.Main(args);
            Assert.True(result == 2);
        }

        [Fact]
        public void WrongOperationFormat()
        {
            var args = new[] {"1", "i am not operation u know", "3"};
            var result = Program.Main(args);
            Assert.True(result == 3);
        }

        [Fact]
        public void EverythingAlrightWithAdd()
        {
            var args = new[] {"1", "+", "3"};
            var result = Program.Main(args);
            Assert.True(result == 0);
        }

        [Fact]
        public void EverythingAlrightWithSubtract()
        {
            var args = new[] {"1", "-", "3"};
            var result = Program.Main(args);
            Assert.True(result == 0);
        }

        [Fact]
        public void EverythingAlrightWithMultiply()
        {
            var args = new[] {"1", "*", "3"};
            var result = Program.Main(args);
            Assert.True(result == 0);
        }

        [Fact]
        public void EverythingAlrightWithDivide()
        {
            var args = new[] {"1", "/", "3"};
            var result = Program.Main(args);
            Assert.True(result == 0);
        }
    }
}