using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mvp
{
    public class ManufacturerListPresenter
    {
        public ManufacturerListPresenter(IManufacturerListView listView, IManufacturerReader manufacturerReader)
        {
            ListView = listView;
            ManufacturerReader = manufacturerReader;
        }

        IManufacturerListView ListView { get; }
        IManufacturerReader ManufacturerReader { get; }

        public void Init() => ListView.Show(GetViewModel());

        public void Sort(bool ascending)
        {
            var vm = GetViewModel();
            vm.Manufacturers = ascending ? vm.Manufacturers.OrderBy(m => m) : vm.Manufacturers.OrderByDescending(m => m);
            vm.Ascending = ascending;
            ListView.Show(vm);
        }

        ManufacturerListViewModel GetViewModel() =>
            new ManufacturerListViewModel
            {
                Title = "Manufacturers",
                Manufacturers = ManufacturerReader.ReadAll()
            };
    }
}
