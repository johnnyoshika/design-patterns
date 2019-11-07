using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mvp
{
    public class Page : IManufacturerListView
    {
        public Page(IManufacturerReader manufacturerReader)
        {
            ManufacturerReader = manufacturerReader;
        }

        IManufacturerReader ManufacturerReader { get; }
        ManufacturerListPresenter? Presenter { get; set; }
        ManufacturerListViewModel ViewModel { get; set; } = new ManufacturerListViewModel();

        // If instead we wanted to use a passive view variation of hte MVP pattern (which means the View knows nothing about the model),
        // then instead of passing a model from the presenter to the view, have the presenter call methods that sets display properties in the view.
        public void Show(ManufacturerListViewModel vm)
        {
            ViewModel = vm;
        }

        public void Page_Load()
        {
            Presenter = new ManufacturerListPresenter(this, ManufacturerReader);
            Presenter.Init();
        }

        public void Sort_Click()
        {
            Presenter?.Sort(!(ViewModel.Ascending ?? false));
        }

        // This is an implementation of the supervising controller variation of the MVP pattern b/c the View knows about the Model.
        public string Render() =>
            $"<h1>{ViewModel.Title}</h1><div>Ascending:{ViewModel.Ascending}</div><ul>{RenderItems()}</ul>";

        string RenderItems() => string.Join("", ViewModel.Manufacturers.Select(m => RenderItem(m)));

        string RenderItem(string item) => $"<li>{item}</li>";
    }
}
