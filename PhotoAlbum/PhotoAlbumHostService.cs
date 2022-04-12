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
        _logger.LogInformation("Starting photo album.");
        Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    await _photoAlbumService.Run();
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
        _logger.LogInformation("Exiting photo album");

        return Task.CompletedTask;
    }
    
}