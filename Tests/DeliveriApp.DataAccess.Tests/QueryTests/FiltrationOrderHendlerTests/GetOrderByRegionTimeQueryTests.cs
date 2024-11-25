using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriApp.DataAccess.Tests.QueryTests.FiltrationOrderHendlerTests
{
    public class GetOrderByRegionTimeQueryTests
    {
        [Fact]
        public async Task HendlerAsync_ShouldReturnFilteredOrders_WhenRegionIdIsValid()
        {
            /*// Arrange
            var mockDeliveryContext = new Mock<DeliveryContext>();
            var mockQuery = new Mock<IQueryHandler>();
            var mockLogger = new Mock<ILogger<OrderService>>();

            var orders = new List<Order>
        {
            new Order { RegionId = 1 },
            new Order { RegionId = 1 },
            new Order { RegionId = 2 }
        }.AsQueryable();

            var regionId = 1;

            var expectedResponse = new ResponsFirstThityMinutesOrders();

            mockDeliveryContext.Setup(dc => dc.Orders)
                .Returns(orders.AsQueryable().BuildMockDbSet().Object); // Используем Mock для EF DbSet

            mockQuery.Setup(q => q.HendlerAsync(
                It.Is<GetByIdRegionQuery>(query => query.Id == regionId),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            var service = new OrderService(mockDeliveryContext.Object, mockQuery.Object, mockLogger.Object);

            // Act
            var result = await service.HendlerAsync(CancellationToken.None);

            // Assert
            Assert.Equal(expectedResponse, result);
            mockQuery.Verify(q => q.HendlerAsync(It.IsAny<GetByIdRegionQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            mockLogger.Verify(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.Exactly(2));*/
        }

        [Fact]
        public async Task HendlerAsync_ShouldThrowException_WhenRegionIdIsNull()
        {
           /* // Arrange
            var mockDeliveryContext = new Mock<IDeliveryContext>();
            var mockQuery = new Mock<IQueryHandler>();
            var mockLogger = new Mock<ILogger<OrderService>>();

            var orders = new List<Order>().AsQueryable(); // Нет заказов => regionId будет null

            mockDeliveryContext.Setup(dc => dc.Orders)
                .Returns(orders.AsQueryable().BuildMockDbSet().Object); // Используем Mock для EF DbSet

            var service = new OrderService(mockDeliveryContext.Object, mockQuery.Object, mockLogger.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => service.HendlerAsync(CancellationToken.None));
            mockLogger.Verify(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);*/
        }
    }
}
