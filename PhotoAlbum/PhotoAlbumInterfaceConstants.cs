namespace PhotoAlbum;

public static class PhotoAlbumInterfaceConstants
{
    public static string DisplayRequest = "enter album Id to request or enter for all";

    public static string DisplayAlbum(PhotoAlbumResponse albumResponse)
    {
        return
            $"AlbumId: {albumResponse.AlbumId}| Id: {albumResponse.Id}| Url: {albumResponse.Url}| ThumbnailUrl: {albumResponse.ThumbnailUrl}";
    }

    public static string DisplayBadRequest(string albumRequest)
    {
        return $"album {albumRequest} is not valid";
    }
}