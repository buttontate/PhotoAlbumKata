namespace PhotoAlbum;

public static class PhotoAlbumInterfaceConstants
{
    public static string DisplayRequest = "enter album Id to request or enter for all";
    public static string DisplayBadRequest = "something woops";

    public static string DisplayAlbum(PhotoAlbumResponse albumResponse)
    {
        return $"AlbumId: {albumResponse.AlbumId}| Id: {albumResponse.Id}| Url: {albumResponse.Url}| ThumbnailUrl: {albumResponse.ThumbnailUrl}";
    }
}