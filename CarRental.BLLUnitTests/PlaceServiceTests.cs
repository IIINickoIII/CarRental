using System;
using AutoMapper;
using CarRental.BLL.Dto;
using CarRental.BLL.Interfaces;
using CarRental.BLL.Services;
using CarRental.DAL.Entities;
using CarRental.DAL.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarRental.BLLUnitTests
{
    [TestClass]
    public class PlaceServiceTests
    {
       // naming: MethodName_Scenario_ExpectedBehavior
       [TestMethod]
        public void PlaceServiceGet_PlaceId_ReturnsPlaceDto()
        {
            // Arrange
            int placeId = 1;

            //var mapperMock = new Mock<IMappingAction<Place,PlaceDto>>();
            //var mapperMock2 = new Mock<IObjectMapper>();
            //var mapperMock2 = new Mock<IMapper>();
            //    mapperMock2.Setup(m => m.Map<Place, PlaceDto>(It.IsAny<Place>())).Returns(new PlaceDto());


            var uowMock = new Mock<IUnitOfWork>();
                uowMock.Setup(u => u.Places.Add(new Place { Id = 1, Name = "Kharkiv railway station" }));
                uowMock.Setup(u => u.Places.Get(placeId)).Returns(new Place { Name = "Kharkiv railway station" });

            var placeService = new PlaceService(uowMock.Object);
                

            // Act
            var placeDto = placeService.Get(placeId);

            // Assert
            //Assert.IsNotNull(placeDto);
            //uowMock.Verify(a => a.Places.Get(placeId), Times.Exactly(2));
            Assert.AreEqual("Kharkiv railway station", placeDto.Name);
        }

        [TestMethod]
        public void PlaceServiceDelete_PlaceId_ReturnsExceptionNotFound()
        {
            // Arrange
            int placeId = 100;

            var uowMock = new Mock<IUnitOfWork>();
                uowMock.Setup(u => u.Places.Add(new Place { Id = 1, Name = "Kharkiv railway station" }));
                //uowMock.Setup(u => u.Places.Get(placeId)).Returns(new Place { Name = "Kharkiv railway station" });

            var placeService = new PlaceService(uowMock.Object);


            // Act
            Action deletingPlace = () => placeService.Delete(placeId);

            // Assert
            Assert.ThrowsException<Exception>(deletingPlace);
            
        }
    }
}
