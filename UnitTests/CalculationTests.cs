using DemoApp;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class CalculationTests
    {
        private Mock<ICalculationRepository> CalculationRepositoryMock;
        private CalculationLogic logic;

        public CalculationTests()
        {
            CalculationRepositoryMock = new Mock<ICalculationRepository>();
            logic = new CalculationLogic(CalculationRepositoryMock.Object);
        }

        [Fact]
        public void TestGetCalculation()
        {
            CalculationRepositoryMock.Setup(t => t.GetCalculationById(It.IsAny<Guid>())).Returns(3);

            var result = logic.GetSingleCalculation(Guid.NewGuid());

            Assert.Equal(6, result);
            CalculationRepositoryMock.Verify(t => t.GetCalculationById(It.IsAny<Guid>()), Times.Once);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        public void CreateNewCalculation_DivideByZeroException_Expected(int x, int y)
		{
            Assert.Throws<DivideByZeroException>(() => logic.CreateNewCalculation(x, y));
        }

        [Fact]
        public void CreateNewCalculation_ArgumentException_Expected()
        {
            CalculationRepositoryMock.Setup(t => t.GetallCalculations()).Returns(new int[] { 2 });

            Assert.Throws<ArgumentException>(() => logic.CreateNewCalculation(8, 4));
        }

        [Fact]
        public void CreateNewCalculation_Exception_Expected()
        {
            CalculationRepositoryMock.Setup(t => t.GetallCalculations()).Returns(new int[] { 1 });
            CalculationRepositoryMock.Setup(t => t.SaveCalculation(It.IsAny<int>())).Returns(false);

            var exception = Assert.Throws<Exception>(() => logic.CreateNewCalculation(8, 4));
            Assert.Equal("Something went wrong with the database!", exception.Message);
        }

        [Theory]
        [InlineData(8, 4, 2)]
        [InlineData(6, 3, 2)]
        [InlineData(5, 2, 2)]
        public void CreateNewCalculation_Success(int x, int y, int result)
        {
            CalculationRepositoryMock.Setup(t => t.GetallCalculations()).Returns(new int[] { });
            CalculationRepositoryMock.Setup(t => t.SaveCalculation(It.IsAny<int>())).Returns(true);

            var actual = logic.CreateNewCalculation(x, y);
            Assert.Equal(actual, result);
        }
    }
}
