
using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Mvc;

using WebApi_Template.Models;
using System.Collections.Generic;
using WebApplication4.Models;
using WebApplication4.ViewModels;

namespace WebApi_Template.Controllers
{
  
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext { get; set; }

        // constructor function containing the dbContext initialize
        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        // all albums
        public IEnumerable<Album> GetAllOriginal()
        {
            var products = dbContext.Album.ToList();
            return products;
        }

        // top 100 artists ordered by name
        public IEnumerable<Artist> GetAllArtists()
        {
            var artists = dbContext.Artist.Take(100).OrderBy(a => a.Name).ToList();
            return artists;
        }

        // List all the artist on a particular album you like(hint, will need to pass an album id in the calling url to the action)
        public IEnumerable<ArtistAlbum> GetAllArtistsOnAlbum(int albumIdArg)
        {
            var artistsOnAlbum = (from selectedArtists in dbContext.Artist
                                  join selectedAlbum in dbContext.Album on selectedArtists.ArtistId equals selectedAlbum.ArtistId
                                  where (selectedAlbum.AlbumId == 5)
                                  select new ArtistAlbum
                                  {
                                      ArtistName = selectedArtists.Name,
                                      ArtistId = selectedArtists.ArtistId,
                                      AlbumName = selectedAlbum.Title,
                                      AlbumId = selectedAlbum.AlbumId

                                   }).ToList();
            return artistsOnAlbum;
        }

        // List all of the albums by your favorite artist.
        public IEnumerable<ArtistAlbum> GetAll(string favArtist)
        {
            var albumsByArtist = (from albums in dbContext.Album
                                  join selectedArtist in dbContext.Artist on albums.ArtistId equals selectedArtist.ArtistId
                                  where (selectedArtist.ArtistId == 1)
                                  select new ArtistAlbum
                                  {
                                      AlbumName = albums.Title,
                                      ArtistName = selectedArtist.Name,
                                      ArtistId = selectedArtist.ArtistId,
                                      AlbumId = albums.AlbumId
                                  }).ToList();
            return albumsByArtist;
        }

        // Create a class that will hold information regarding concerts you would like to attend. Create a list containing your concerts of choice. 
        //Set up several properties. 
        //Query your favorite concert list.
        public IEnumerable<Concert> GetAll()
        {

        }
    }
}
