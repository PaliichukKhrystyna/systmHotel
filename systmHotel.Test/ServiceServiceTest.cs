//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using systmHotel.BLL.Services;
//using systmHotel.DAL.Entities;
//using systmHotel.DAL.IRepository;
//using Xunit;

//public class ServiceServiceTest
//{
//    private readonly Mock<IServiceRepository> _mockServiceRepository;
//    private readonly ServiceService _serviceService;

//    public ServiceServiceTest()
//    {
//        _mockServiceRepository = new Mock<IServiceRepository>();
//        _serviceService = new ServiceService(_mockServiceRepository.Object);
//    }

//    [Fact]
//    public async Task GetServicesAsync_ReturnsAllServices()
//    {
//        // Arrange
//        var services = new List<Service>
//        {
//            new Service { ServiceID = 1 },
//            new Service { ServiceID = 2 }
//        };
//        _mockServiceRepository.Setup(repo => repo.GetAllServicesAsync()).ReturnsAsync(services);

//        // Act
//        var result = await _serviceService.GetServicesAsync();

//        // Assert
//        Assert.Equal(2, result.Count());
//        _mockServiceRepository.Verify(repo => repo.GetAllServicesAsync(), Times.Once);
//    }

//    [Fact]
//    public async Task AddServiceAsync_AddsService()
//    {
//        // Arrange
//        var service = new Service { ServiceID = 1 };

//        // Act
//        await _serviceService.AddServiceAsync(service);

//        // Assert
//        _mockServiceRepository.Verify(repo => repo.AddServiceAsync(service), Times.Once);
//    }

//    [Fact]
//    public async Task DeleteServiceAsync_DeletesService()
//    {
//        // Arrange
//        var serviceId = 1;

//        // Act
//        await _serviceService.DeleteServiceAsync(serviceId);

//        // Assert
//        _mockServiceRepository.Verify(repo => repo.DeleteServiceAsync(serviceId), Times.Once);
//    }
//}
