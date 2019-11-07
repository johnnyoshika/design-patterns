using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Mvp
{
    public class ManufacturerListViewModel
    {
        public string Title { get; set; } = "";

        public bool? Ascending { get; set; }

        public IEnumerable<string> Manufacturers { get; set; } = new List<string>();
    }
}
