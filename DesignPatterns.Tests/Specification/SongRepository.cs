using DesignPatterns.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Tests.Specification
{
    public class SongRepository : ISongRepository
    {
        public List<Song> Read(ISpecification<Song> specification) =>
            Songs.Where(specification.Criteria.Compile()).ToList();

        List<Song> Songs => new List<Song>
        {
            new Song(new List<int>{ 1, 2 }, 1, "Eagles", "Hotel California",            5),
            new Song(new List<int>{ 1, 2 }, 1, "Eagles", "Take it Easy",                3),
            new Song(new List<int>{ 1, 2 }, 1, "Eagles", "New Kid in Town",             4),
            new Song(new List<int>{ 1, 2 }, 1, "Eagles", "Life In The Fast Lane",       5),
            new Song(new List<int>{ 2, 3 }, 2, "Michael Jackson", "Thriller",           4),
            new Song(new List<int>{ 2, 3 }, 2, "Michael Jackson", "Billie Jean",        5),
            new Song(new List<int>{ 4, 5 }, 3, "Billy Joel", "Piano Man",               4),
            new Song(new List<int>{ 3, 4 }, 4, "Led Zeppin", "Stairway to Heaven",      5),
            new Song(new List<int>{ 2, 3 }, 5, "Pink Floyd", "Leaning to Fly",          4),
            new Song(new List<int>{ 6 },    6, "Garth Brooks", "Friends in Low Places", 3),
        };
    }
}
