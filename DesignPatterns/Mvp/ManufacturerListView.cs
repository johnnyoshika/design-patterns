using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Mvp
{
    public interface IManufacturerListView
    {
        void Show(ManufacturerListViewModel vm);
    }
}
