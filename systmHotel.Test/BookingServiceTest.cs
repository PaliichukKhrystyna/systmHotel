//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using systmHotel.BLL.Services;
//using systmHotel.DAL.Entities;
//using systmHotel.DAL.IRepository;
//using Xunit;

//public class BookingServiceTest
//{
//    private readonly Mock<IBookingRepository> _mockBookingRepository;
//    private readonly BookingService _bookingService;

//    public BookingServiceTest()
//    {
//        _mockBookingRepository = new Mock<IBookingRepository>();
//        _bookingService = new BookingService(_mockBookingRepository.Object);
//    }

//    [Fact]
//    public async Task GetBookingsAsync_ReturnsAllBookings()
//    {
//        // Arrange
//        var bookings = new List<Booking>
//        {
//            new Booking { BookingID = 1 },
//            new Booking { BookingID = 2 }
//        };
//        _mockBookingRepository.Setup(repo => repo.GetAllBookingsAsync()).ReturnsAsync(bookings);

//        // Act
//        var result = await _bookingService.GetBookingsAsync();

//        // Assert
//        Assert.Equal(2, result.Count());
//        _mockBookingRepository.Verify(repo => repo.GetAllBookingsAsync(), Times.Once);
//    }

//    [Fact]
//    public async Task AddBookingAsync_AddsBooking()
//    {
//        // Arrange
//        var booking = new Booking { BookingID = 1 };

//        // Act
//        await _bookingService.AddBookingAsync(booking);

//        // Assert
//        _mockBookingRepository.Verify(repo => repo.AddBookingAsync(booking), Times.Once);
//    }

//    [Fact]
//    public async Task DeleteBookingAsync_DeletesBooking()
//    {
//        // Arrange
//        var bookingId = 1;

//        // Act
//        await _bookingService.DeleteBookingAsync(bookingId);

//        // Assert
//        _mockBookingRepository.Verify(repo => repo.DeleteBookingAsync(bookingId), Times.Once);
//    }
//}
