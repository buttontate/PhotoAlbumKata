using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhotoAlbum;

CreateHostBuilder(args).Build().Run();

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddSingleton<IPhotoAlbumService, PhotoAlbumService>();
            services.AddSingleton<IPhotoAlbumInterface, PhotoAlbumInterface>();
            services.AddSingleton<IPhotoAlbumRepo, PhotoAlbumRepo>();
            services.AddHostedService<PhotoAlbumHostService>();
            services.AddLogging();
        });