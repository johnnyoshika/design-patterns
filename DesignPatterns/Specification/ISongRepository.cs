using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Specification
{
    public interface ISongRepository
    {
        List<Song> Read(ISpecification<Song> specification);
    }
}
