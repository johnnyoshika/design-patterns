using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Specification
{
    public class Song
    {
        public Song(List<int> genres, int albumId, string artist, string title, int rating)
        {
            Genres = genres;
            AlbumId = albumId;
            Artist = artist;
            Title = title;
            Rating = rating;
        }

        public List<int> Genres { get; set; } = new List<int>();
        public int AlbumId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
    }
}
