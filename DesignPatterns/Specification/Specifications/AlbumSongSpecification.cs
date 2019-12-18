using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.Specification.Specifications
{
    public class AlbumSongSpecification : ISpecification<Song>
    {
        public AlbumSongSpecification(int albumId) => AlbumId = albumId;
        int AlbumId { get; }

        public Expression<Func<Song, bool>> Criteria => s => s.AlbumId == AlbumId;
    }
}
