using ATG.Data.Repositories.Interfaces;
using ATG.Domain.Models;
using ATG.Services.Services;
using ATG.Tests.TestData;
using Moq;
using NUnit.Framework;

namespace ATG.Tests.Services
{
    [TestFixture]
    public class LotServiceTests
    {
        private MockRepository _mockRepository;

        private Mock<IFailoverLotRepository> _mockFailoverLotRepository;
        private Mock<IArchivedRepository> _mockArchivedRepository;
        private Mock<ILotRepository> _mockLotRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockFailoverLotRepository = _mockRepository.Create<IFailoverLotRepository>();
            _mockArchivedRepository = _mockRepository.Create<IArchivedRepository>();
            _mockLotRepository = _mockRepository.Create<ILotRepository>();

            _mockFailoverLotRepository.Setup(x => x.GetFailOverLotEntries()).Returns(MockUpData.FailoverLots(50, false));
            _mockFailoverLotRepository.Setup(x => x.GetLot(It.IsAny<int>())).Returns(new Lot());
            _mockArchivedRepository.Setup(x => x.GetLot(It.IsAny<int>())).Returns(new Lot());
            _mockLotRepository.Setup(x => x.LoadCustomer()).Returns(MockUpData.LoadCustomer());
        }

        private LotService CreateService()
        {
            return new LotService(
                _mockFailoverLotRepository.Object,
                _mockArchivedRepository.Object,
                _mockLotRepository.Object);
        }


        [TestCase(1, false)]
        public void GetLot_With_Less_Than_Fifty_FailoverLots_StateUnderTest_ExpectedBehavior(int id, bool isLotArchived)
        {
            // Arrange
            _mockFailoverLotRepository.Setup(x => x.GetFailOverLotEntries()).Returns(MockUpData.FailoverLots(50, true));
            var service = CreateService();

            // Act
            var result = service.GetLot(id, 50, isLotArchived, true);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase(1, true)]
        public void GetLot_With_Over_Fifty_FailoverLots_StateUnderTest_ExpectedBehavior(int id, bool isLotArchived)
        {
            // Arrange
            var service = CreateService();

            // Act
            var result = service.GetLot(id, 50, isLotArchived, true);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
