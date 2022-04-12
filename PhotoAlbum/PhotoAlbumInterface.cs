namespace PhotoAlbum;

public interface IPhotoAlbumInterface
{
    PhotoAlbumRequest GetUserInput();
    void DisplayPhotoAlbums(IEnumerable<PhotoAlbumResponse> photoAlbums);
}

public class PhotoAlbumInterface : IPhotoAlbumInterface
{
    public PhotoAlbumRequest GetUserInput()
    {
        throw new NotImplementedException();
    }

    public void DisplayPhotoAlbums(IEnumerable<PhotoAlbumResponse> photoAlbums)
    {
        throw new NotImplementedException();
    }
}