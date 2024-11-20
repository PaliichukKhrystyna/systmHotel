//using Moq;
//using Xunit;

//uusing Moq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using systmHotel.BLL.Services;
//using systmHotel.DAL.Entities;
//using systmHotel.DAL.IRepository;
//using Xunit;

//public class ClientServiceTest
//{
//    private readonly Mock<IClientRepository> _mockClientRepository;
//    private readonly ClientService _clientService;

//    public ClientServiceTest()
//    {
//        _mockClientRepository = new Mock<IClientRepository>();
//        _clientService = new ClientService(_mockClientRepository.Object);
//    }

//    [Fact]
//    public async Task GetAllClientsAsync_ReturnsAllClients()
//    {
//        // Arrange
//        var clients = new List<Client>
//        {
//            new Client { ClientID = 1 },
//            new Client { ClientID = 2 }
//        };
//        _mockClientRepository.Setup(repo => repo.GetAllClientsAsync()).ReturnsAsync(clients);

//        // Act
//        var result = await _clientService.GetAllClientsAsync();

//        // Assert
//        Assert.Equal(2, result.Count());
//        _mockClientRepository.Verify(repo => repo.GetAllClientsAsync(), Times.Once);
//    }

//    [Fact]
//    public async Task AddClientAsync_AddsClient()
//    {
//        // Arrange
//        var client = new Client { ClientID = 1 };

//        // Act
//        await _clientService.AddClientAsync(client);

//        // Assert
//        _mockClientRepository.Verify(repo => repo.AddClientAsync(client), Times.Once);
//    }

//    [Fact]
//    public async Task DeleteClientAsync_DeletesClient()
//    {
//        // Arrange
//        var clientId = 1;
//        var client = new Client { ClientID = clientId };
//        _mockClientRepository.Setup(repo => repo.GetClientByIdAsync(clientId)).ReturnsAsync(client);

//        // Act
//        await _clientService.DeleteClientAsync(clientId);

//        // Assert
//        _mockClientRepository.Verify(repo => repo.DeleteClientAsync(clientId), Times.Once);
//    }
//}
