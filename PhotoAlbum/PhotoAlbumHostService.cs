using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PhotoAlbum;

public class PhotoAlbumHostService : IHostedService
{
    private readonly IPhotoAlbumService _photoAlbumService;
    private readonly ILogger _logger;

    public PhotoAlbumHostService(
        IPhotoAlbumService photoAlbumService,
        ILogger<PhotoAlbumHostService> logger)
    {
        _photoAlbumService = photoAlbumService;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("1. StartAsync has been called.");
        Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    _photoAlbumService.Run();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }
                
            }
        }, cancellationToken);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Exiting Photo Album.");

        return Task.CompletedTask;
    }
    
}