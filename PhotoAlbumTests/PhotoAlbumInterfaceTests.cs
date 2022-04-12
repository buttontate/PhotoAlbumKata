using Moq;
using PhotoAlbum;
using Xunit;

namespace PhotoAlbumTests;

public class PhotoAlbumInterfaceTests
{
    private readonly PhotoAlbumInterface _photoAlbumInterface;
    private readonly Mock<ConsoleWrapper> _consoleWrapper;
    
    public PhotoAlbumInterfaceTests()
    {
        _consoleWrapper = new Mock<ConsoleWrapper>();
        _photoAlbumInterface = new PhotoAlbumInterface();
    }

    [Fact]
    public void ShouldGetAlbumRequestFromConsole()
    {
        
    }
}