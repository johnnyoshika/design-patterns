using System.Collections.Generic;

namespace DesignPatterns.Mvp
{
    public interface IManufacturerReader
    {
        IEnumerable<string> ReadAll();
    }
}