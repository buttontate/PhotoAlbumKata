using Microsoft.Extensions.Logging;

namespace PhotoAlbum;

public interface IPhotoAlbumService
{
    Task Run();
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

    public async Task Run()
    {
        var request = _photoAlbumInterface.GetUserInput();
        _logger.LogInformation("User has requested album Id: {albumId}", request.AlbumId);
        var photoAlbums = request.AlbumId.HasValue ? await _photoAlbumRepo.GetByAlbumId((int)request.AlbumId) : await _photoAlbumRepo.GetAll();
        _photoAlbumInterface.DisplayPhotoAlbums(photoAlbums);
    }
}