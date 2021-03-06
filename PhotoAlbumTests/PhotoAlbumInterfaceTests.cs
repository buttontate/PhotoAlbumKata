using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using PhotoAlbum;
using Xunit;

namespace PhotoAlbumTests;

public class PhotoAlbumInterfaceTests
{
    private readonly PhotoAlbumInterface _photoAlbumInterface;
    private readonly Mock<IConsoleWrapper> _consoleWrapper;
    
    public PhotoAlbumInterfaceTests()
    {
        _consoleWrapper = new Mock<IConsoleWrapper>();
        _consoleWrapper.Setup(x => x.ReadLine()).Returns("");
        _photoAlbumInterface = new PhotoAlbumInterface(_consoleWrapper.Object);
    }

    [Fact]
    public void ShouldGetAlbumRequestFromConsole()
    {
        _photoAlbumInterface.GetUserInput();
        _consoleWrapper.Verify(x => x.DisplayLine("Please enter the album Id you wish to retrieve.  Leave blank to retrieve all."));
    }
    
    [Fact]
    public void ShouldCallToReadAlbumId()
    {
        _photoAlbumInterface.GetUserInput();
        _consoleWrapper.Verify(x => x.ReadLine(), Times.Once);
    }

    [Fact]
    public void ShouldReturnNullAlbumIdIfEmptyRead()
    {
        var result = _photoAlbumInterface.GetUserInput();
        result.AlbumId.Should().BeNull();
    }

    [Fact]
    public void ShouldReturnAlbumIdWhenAlbumIdEntered()
    {
        const int expected = 5;
        _consoleWrapper.Setup(x => x.ReadLine()).Returns(expected.ToString);
        var result = _photoAlbumInterface.GetUserInput();
        result.AlbumId.Should().Be(expected);
    }
    
    [Fact]
    public void ShouldThrowExceptionIfBadAlbumId()
    {
        var enteredAlbum = "random-data-sucks";
        _consoleWrapper.Setup(x => x.ReadLine()).Returns(enteredAlbum);
        var func = () =>  _photoAlbumInterface.GetUserInput();
        
        func.Should().Throw<Exception>(PhotoAlbumInterfaceConstants.DisplayBadRequest(enteredAlbum));
        _consoleWrapper.Verify(x => x.DisplayLine($"Album {enteredAlbum} is not valid."));
    }

    [Fact]
    public void GivenAlbumShouldDisplayAlbum()
    {
        var photoAlbums = new List<PhotoAlbumResponse>()
        {
            new()
            {
                AlbumId = 1,
                Id = 1,
                ThumbnailUrl = "thumbnailUrl2",
                Title = "Title",
                Url = "url2"
            },
            new()
            {
                AlbumId = 1,
                Id = 2,
                ThumbnailUrl = "thumbnailUrl2",
                Title = "Title",
                Url = "url2"
            }
        };
        _photoAlbumInterface.DisplayPhotoAlbums(photoAlbums);
        foreach (var album in photoAlbums)
        {
            _consoleWrapper.Verify(x => x.DisplayLine($"AlbumId: {album.AlbumId}| Id: {album.Id}| Url: {album.Url}| ThumbnailUrl: {album.ThumbnailUrl}"));
        }
    }
}