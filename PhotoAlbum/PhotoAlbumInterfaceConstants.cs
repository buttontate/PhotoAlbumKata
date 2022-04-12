namespace PhotoAlbum;

public static class PhotoAlbumInterfaceConstants
{
    public static string DisplayRequest = "Please enter the album Id you wish to retrieve.  Leave blank to retrieve all.";

    public static string DisplayAlbum(PhotoAlbumResponse albumResponse)
    {
        return
            $"AlbumId: {albumResponse.AlbumId}| Id: {albumResponse.Id}| Url: {albumResponse.Url}| ThumbnailUrl: {albumResponse.ThumbnailUrl}";
    }

    public static string DisplayBadRequest(string albumRequest)
    {
        return $"Album {albumRequest} is not valid.";
    }
}