using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhotoAlbum;

CreateHostBuilder(args).Build().Run();

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {

            var appSettings = hostContext.Configuration.Get<AppSettings>();
            
            services.AddSingleton(appSettings);
            services.AddSingleton<IPhotoAlbumService, PhotoAlbumService>();
            services.AddSingleton<IPhotoAlbumInterface, PhotoAlbumInterface>();
            services.AddSingleton<IPhotoAlbumRepo, PhotoAlbumRepo>();
            services.AddSingleton<IConsoleWrapper, ConsoleWrapper>();
            services.AddSingleton(new HttpClient());
            services.AddHostedService<PhotoAlbumHostService>();
            services.AddLogging();
            
        });