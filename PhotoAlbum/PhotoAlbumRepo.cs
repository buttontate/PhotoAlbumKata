namespace PhotoAlbum;

public interface IPhotoAlbumRepo
{
    IEnumerable<PhotoAlbumResponse> GetAll();
    IEnumerable<PhotoAlbumResponse> GetByAlbumId(int albumId);
}

public class PhotoAlbumRepo : IPhotoAlbumRepo
{
    public IEnumerable<PhotoAlbumResponse> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PhotoAlbumResponse> GetByAlbumId(int albumId)
    {
        throw new NotImplementedException();
    }
}