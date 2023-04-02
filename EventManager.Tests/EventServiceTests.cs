using AutoMapper;
using EventManager.BLL.DTOs.Events;
using EventManager.BLL.Services;
using EventManager.DAL.Entities;
using EventManager.DAL.UnitOfWork;
using Moq;

namespace EventManager.Tests
{
    public class EventServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly EventService _eventService;

        public EventServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _eventService = new EventService(_mockMapper.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task UpdateAsync_WhenEventExists_ShouldUpdateAndSaveChanges()
        {
            // Arrange
            var requestDTO = new UpdateEventRequestDTO { UserId = 1, Id = 2 };
            var eventEntity = new Event();
            _mockUnitOfWork.Setup(uow => uow.EventRepository.GetByUserIdAndEventIdAsync(requestDTO.UserId, requestDTO.Id, true)).ReturnsAsync(eventEntity);

            // Act
            await _eventService.UpdateAsync(requestDTO);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.EventRepository.Update(eventEntity), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.SaveChangesAsync(), Times.Once);
        }
    }
}