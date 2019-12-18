using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.Specification.Specifications
{
    public class FilterSongSpecification : ISpecification<Song>
    {
        public List<int> GenreIdsToInclude { get; set; } = new List<int>();
        public List<int> AlbumIdsToinclude { get; set; } = new List<int>();
        public List<string> ArtistsToInclude { get; set; } = new List<string>();
        public string? TitleFilter { get; set; }
        public int MinRating { get; set; }

        public Expression<Func<Song, bool>> Criteria =>
            s =>
                (!GenreIdsToInclude.Any() || s.Genres.Any(g => GenreIdsToInclude.Any(gid => gid == g))) &&
                (!AlbumIdsToinclude.Any() || AlbumIdsToinclude.Contains(s.AlbumId)) &&
                (!ArtistsToInclude.Any() || ArtistsToInclude.Contains(s.Artist)) &&
                (string.IsNullOrWhiteSpace(TitleFilter) || s.Title.Contains(TitleFilter)) &&
                s.Rating >= MinRating;
    }
}
