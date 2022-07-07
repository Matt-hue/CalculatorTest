using CalculatorCommands.Calculator;
using CalculatorCommands.Tests.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculatorCommands.Tests.Calculator
{
    public class SimpleCalculatorTests
    {
        private readonly ISimpleCalculator _sut;
        private readonly Mock<ILogger<SimpleCalculator>> _loggerMock;

        public SimpleCalculatorTests()
        {
            _loggerMock = new Mock<ILogger<SimpleCalculator>>();
            _sut = new SimpleCalculator(_loggerMock.Object);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 1)]
        [InlineData(0, -1, -1)]
        public void Add_ShouldAddTwoIntegers(int start, int amount, int expected)
        {
            //Arrange
            //Act
            int result = _sut.Add(start, amount);

            //Assert
            result.ShouldBe(expected);

            _loggerMock.VerifyLogExtensionWasCalled<SimpleCalculator>(LogLevel.Information);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(2, 1, 1)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, -1)]
        [InlineData(0, -1, +1)]
        [InlineData(-1, -1, 0)]
        [InlineData(-1, 0, -1)]
        public void Subtract_ShouldSubtractTwoIntegers(int start, int amount, int expected)
        {
            //Arrange
            //Act
            int result = _sut.Subtract(start, amount);

            //Assert
            result.ShouldBe(expected);

            _loggerMock.VerifyLogExtensionWasCalled<SimpleCalculator>(LogLevel.Information);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 6)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(1, -1, -1)]
        [InlineData(-1, -1, 1)]
        public void Multiply_ShouldMultiplyTwoIntegers(int start, int by, int expected)
        {
            //Arrange
            //Act
            int result = _sut.Multiply(start, by);

            //Assert
            result.ShouldBe(expected);

            _loggerMock.VerifyLogExtensionWasCalled<SimpleCalculator>(LogLevel.Information);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(6, 2, 3)]
        [InlineData(9, 2, 4.5)]
        [InlineData(0, -1, 0)]
        [InlineData(-6, 2, -3)]
        public void Divide_ShouldDivideTwoIntegers(int start, int by, float expected)
        {
            //Arrange
            //Act
            float result = _sut.Divide(start, by);

            //Assert
            result.ShouldBe(expected);

            _loggerMock.VerifyLogExtensionWasCalled<SimpleCalculator>(LogLevel.Information);
        }

        [Fact]
        public void Divide_DividingByZeroShouldThrow()
        {
            //Arrange
            //Act
            //Assert
            Should.Throw<ArithmeticException>(() => _sut.Divide(1, 0));
        }
    }
}
