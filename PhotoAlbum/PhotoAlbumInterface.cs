namespace PhotoAlbum;

public interface IPhotoAlbumInterface
{
    PhotoAlbumRequest GetUserInput();
    void DisplayPhotoAlbums(IEnumerable<PhotoAlbumResponse> photoAlbums);
}

public class PhotoAlbumInterface : IPhotoAlbumInterface
{
    private readonly IConsoleWrapper _consoleWrapper;

    public PhotoAlbumInterface(IConsoleWrapper consoleWrapper)
    {
        _consoleWrapper = consoleWrapper;
    }

    public PhotoAlbumRequest GetUserInput()
    {
        _consoleWrapper.DisplayLine(PhotoAlbumInterfaceConstants.DisplayRequest);
        var userInput = _consoleWrapper.ReadLine();
        var request = new PhotoAlbumRequest();

        if (string.IsNullOrEmpty(userInput)) return request;
        var isNumeric = int.TryParse(userInput, out var albumId);
        if (!isNumeric)
        {
            _consoleWrapper.DisplayLine(PhotoAlbumInterfaceConstants.DisplayBadRequest(userInput));
            throw new Exception(PhotoAlbumInterfaceConstants.DisplayBadRequest(userInput));
        }

        request.AlbumId = albumId;

        return request;
    }

    public void DisplayPhotoAlbums(IEnumerable<PhotoAlbumResponse> photoAlbums)
    {
        foreach (var album in photoAlbums)
        {
            _consoleWrapper.DisplayLine(PhotoAlbumInterfaceConstants.DisplayAlbum(album));
        }
    }
}