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
    }
}
