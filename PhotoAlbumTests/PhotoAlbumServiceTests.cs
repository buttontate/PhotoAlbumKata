using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using PhotoAlbum;
using Xunit;

namespace PhotoAlbumTests;

public class PhotoAlbumServiceTests
{
    private readonly PhotoAlbumService _photoAlbumService;
    private readonly Mock<IPhotoAlbumInterface> _photoAlbumInterface;
    private readonly Mock<IPhotoAlbumRepo> _photoAlbumRepo;

    public PhotoAlbumServiceTests()
    {
        _photoAlbumInterface = new Mock<IPhotoAlbumInterface>();
        _photoAlbumRepo = new Mock<IPhotoAlbumRepo>();
        
        var logger = new Mock<ILogger<PhotoAlbumService>>();
        var photoAlbumRequest = new PhotoAlbumRequest()
        {
            AlbumId = null
        };
        _photoAlbumInterface.Setup(x => x.GetUserInput()).Returns(photoAlbumRequest);
        _photoAlbumService = new PhotoAlbumService(_photoAlbumInterface.Object, _photoAlbumRepo.Object, logger.Object);

    }
    
    [Fact]
    public void ShouldCallToGetUserInput()
    {
        _photoAlbumService.Run();
        _photoAlbumInterface.Verify(x => x.GetUserInput(), Times.Once);
    }

    [Fact]
    public void GivenNoAlbumIdFromUserShouldGetAllAlbums()
    {
        _photoAlbumService.Run();
        _photoAlbumRepo.Verify(x => x.GetAll(), Times.Once);
    }

    [Fact]
    public void GivenAlbumIdFromUserShouldGetAlbumById()
    {
        var photoAlbumRequest = new PhotoAlbumRequest()
        {
            AlbumId = 5
        };
        _photoAlbumInterface.Setup(x => x.GetUserInput()).Returns(photoAlbumRequest);
        
        _photoAlbumService.Run();
        
        _photoAlbumRepo.Verify(x => x.GetByAlbumId((int)photoAlbumRequest.AlbumId), Times.Once);
    }

    [Fact]
    public void GivenPhotoAlbumsShouldCallToDisplayAlbums()
    {
        var photoAlbums = new List<PhotoAlbumResponse>()
        {
            new()
            {
                AlbumId = 1,
                Id = 1,
            },
            new()
            {
                AlbumId = 1,
                Id = 2,
            },
        };

        _photoAlbumRepo.Setup(x => x.GetAll()).Returns(photoAlbums);
        
        _photoAlbumService.Run();
        
        _photoAlbumInterface.Verify(x => x.DisplayPhotoAlbums(photoAlbums), Times.Once);
    }
}