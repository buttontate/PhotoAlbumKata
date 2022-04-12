using System.Net.Http.Json;
using System.Text.Json;

namespace PhotoAlbum;

public interface IPhotoAlbumRepo
{
    Task<IEnumerable<PhotoAlbumResponse>> GetAll();
    Task<IEnumerable<PhotoAlbumResponse>> GetByAlbumId(int albumId);
}

public class PhotoAlbumRepo : IPhotoAlbumRepo
{
    private readonly HttpClient _httpClient;
    private readonly AppSettings _appSettings;

    public PhotoAlbumRepo(HttpClient httpClient, AppSettings appSettings)
    {
        _httpClient = httpClient;
        _appSettings = appSettings;
    }
    public async Task<IEnumerable<PhotoAlbumResponse>> GetAll()
    {
        var response = await _httpClient.GetAsync(_appSettings.PhotoAlbumServiceUrl);
        var result = JsonSerializer.Deserialize<IEnumerable<PhotoAlbumResponse>>(await response.Content.ReadAsStringAsync());
        return result;
    }

    public async Task<IEnumerable<PhotoAlbumResponse>>  GetByAlbumId(int albumId)
    {
        var url = $"{_appSettings.PhotoAlbumServiceUrl}?albumId={albumId}";
        var response = await _httpClient.GetAsync(url);
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<PhotoAlbumResponse>>();
        
        return result;
    }
}