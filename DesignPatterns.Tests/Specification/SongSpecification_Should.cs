using DesignPatterns.Specification;
using DesignPatterns.Specification.Specifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Specification
{
    public class SongSpecification_Should
    {
        [Fact]
        public void Filter_Based_On_AllSongSpecification()
        {
            var specification = new AllSongSpecification();

            var songs = new SongRepository().Read(specification);

            Assert.Equal(10, songs.Count);
        }

        [Fact]
        public void Filter_Based_On_AlbumSongSpecification()
        {
            var specification = new AlbumSongSpecification(2);

            var songs = new SongRepository().Read(specification);

            Assert.Equal(2, songs.Count);
            Assert.Equal("Thriller", songs.First().Title);
            Assert.Equal("Billie Jean", songs.ElementAt(1).Title);
        }

        [Fact]
        public void Filter_Based_On_FilterSongSpecification()
        {
            var specification = new FilterSongSpecification
            {
                GenreIdsToInclude = new List<int> { 1, 2, 3 },
                AlbumIdsToinclude = new List<int> { 1, 2, 3, 5 },
                ArtistsToInclude = new List<string> { "Eagles", "Michael Jackson", "Pink Floyd" },
                TitleFilter = "Th",
                MinRating = 4
            };

            var songs = new SongRepository().Read(specification);

            Assert.Equal(2, songs.Count);
            Assert.Equal("Life In The Fast Lane", songs.First().Title);
            Assert.Equal("Thriller", songs.ElementAt(1).Title);
        }

        [Fact]
        public void Filter_Based_On_AlbumSongSpecification_And_FilterSongSpecification()
        {
            var specification = new AndSpecification<Song>(new AlbumSongSpecification(2), new FilterSongSpecification
            {
                GenreIdsToInclude = new List<int> { 1, 2, 3 },
                AlbumIdsToinclude = new List<int> { 1, 2, 3, 5 },
                ArtistsToInclude = new List<string> { "Eagles", "Michael Jackson", "Pink Floyd" },
                TitleFilter = "Th",
                MinRating = 4
            });

            var songs = new SongRepository().Read(specification);

            Assert.Single(songs);
            Assert.Equal("Thriller", songs.First().Title);
        }
    }
}
