using Microsoft.Extensions.Logging;

namespace PhotoAlbum;

public interface IPhotoAlbumService
{
    void Run();
}

public class PhotoAlbumService : IPhotoAlbumService
{
    private readonly IPhotoAlbumInterface _photoAlbumInterface;
    private readonly IPhotoAlbumRepo _photoAlbumRepo;
    private readonly ILogger<PhotoAlbumService> _logger;

    public PhotoAlbumService(IPhotoAlbumInterface photoAlbumInterface, IPhotoAlbumRepo photoAlbumRepo, ILogger<PhotoAlbumService> logger)
    {
        _photoAlbumInterface = photoAlbumInterface;
        _photoAlbumRepo = photoAlbumRepo;
        _logger = logger;
    }

    public void Run()
    {
        var request = _photoAlbumInterface.GetUserInput();
        _logger.LogInformation("User has requested album Id: {albumId}", request.AlbumId);
        var photoAlbums = request.AlbumId.HasValue ? _photoAlbumRepo.GetByAlbumId((int)request.AlbumId) : _photoAlbumRepo.GetAll();
        _photoAlbumInterface.DisplayPhotoAlbums(photoAlbums);
    }
}