using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesignPatterns.Specification.Specifications
{
    public class AllSongSpecification : ISpecification<Song>
    {
        public Expression<Func<Song, bool>> Criteria => s => true;
    }
}
