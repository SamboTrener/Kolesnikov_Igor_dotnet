using Xunit;
using hw8;

namespace hw8Tests
{
    public class UnitTest1
    {
        private static readonly Calculator calculator = new();

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(-4, 4, 0)]
        [InlineData(3, -2.5, 0.5)]
        public void Add_Works(
            double a, double b, double expected)
        {
            var result = calculator.Calculate(a,Operation.Add, b);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(2, 2, 0)]
        [InlineData(0, 3, -3)]
        [InlineData(4, -4.5, 8.5)]
        [InlineData(2, -3, 5)]
        public void Subtract_Works(
            double a, double b, double expected)
        {
            var result = calculator.Calculate(a, Operation.Subtract, b);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(0, 3, 0)]
        [InlineData(4, -4, -16)]
        [InlineData(2.5, -3, -7.5)]
        public void Multiply_Works(
            double a, double b, double expected)
        {
            var result = calculator.Calculate(a, Operation.Multiply, b);
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(0, 3, 0)]
        [InlineData(4, -4, -1)]
        [InlineData(5, 2, 2.5)]
        public void Divide_Works(
            double a, double b, double expected)
        {
            var result = calculator.Calculate(a, Operation.Divide, b);
            Assert.Equal(expected, result);
        }
    }
}