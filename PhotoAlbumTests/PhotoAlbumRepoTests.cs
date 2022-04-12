using System.Collections.Generic;
using System.Text.Json;
using FluentAssertions;
using PhotoAlbum;
using RichardSzalay.MockHttp;
using Xunit;

namespace PhotoAlbumTests;

public class PhotoAlbumRepoTests
{
    private readonly PhotoAlbumRepo _photoAlbumRepo;
    private MockHttpMessageHandler _mockHttpMessageHandler;
    private AppSettings _appSettings;

    public PhotoAlbumRepoTests()
    {
        _appSettings = new AppSettings()
        {
            PhotoAlbumServiceUrl = "https://jsonplaceholder.typicode.com/photos"
        };
        _mockHttpMessageHandler = new MockHttpMessageHandler();
        var response = CreatePhotoAlbumResponses();
        _mockHttpMessageHandler.When(_appSettings.PhotoAlbumServiceUrl)
            .Respond("application/json", JsonSerializer.Serialize(response));
        _photoAlbumRepo = new PhotoAlbumRepo(_mockHttpMessageHandler.ToHttpClient(), _appSettings);
    }

    private static List<PhotoAlbumResponse> CreatePhotoAlbumResponses()
    {
        var response = new List<PhotoAlbumResponse>()
        {
            new()
            {
                AlbumId = 1,
                Id = 1,
                ThumbnailUrl = "thumbnailUrl",
                Title = "Title",
                Url = "url"
            }
        };
        return response;
    }

    [Fact]
    public async void ShouldGetAll()
    {
        var result = await _photoAlbumRepo.GetAll();
        result.Should().BeEquivalentTo(CreatePhotoAlbumResponses());
    }

    [Fact]
    public async void ShouldGetByAlbumId()
    {
        const int albumId = 3;
        var expected = new List<PhotoAlbumResponse>()
        {
            new()
            {
                AlbumId = albumId,
                Id = 2,
                ThumbnailUrl = "thumbnailUrl2",
                Title = "Title",
                Url = "url2"
            }
        };

        _mockHttpMessageHandler.Clear();

        _mockHttpMessageHandler.When(_appSettings.PhotoAlbumServiceUrl)
            .WithQueryString("albumId", albumId.ToString())
            .Respond("application/json", JsonSerializer.Serialize(expected));
        var result = await _photoAlbumRepo.GetByAlbumId(albumId);

        result.Should().BeEquivalentTo(expected);
    }
}