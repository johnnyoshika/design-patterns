using DesignPatterns.Mvp;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Mvp
{
    public class Page_Should
    {
        [Fact]
        public void Render_Unsorted_List()
        {
            var reader = new Mock<IManufacturerReader>();
            reader.Setup(x => x.ReadAll()).Returns(new[] { "Toyota", "Ford", "Nissan" });

            var page = new Page(reader.Object);
            page.Page_Load();

            Assert.Equal("<h1>Manufacturers</h1><div>Ascending:</div><ul><li>Toyota</li><li>Ford</li><li>Nissan</li></ul>", page.Render());
        }

        [Fact]
        public void Render_Ascending_List()
        {
            var reader = new Mock<IManufacturerReader>();
            reader.Setup(x => x.ReadAll()).Returns(new[] { "Toyota", "Ford", "Nissan" });

            var page = new Page(reader.Object);
            page.Page_Load();
            page.Sort_Click();

            Assert.Equal("<h1>Manufacturers</h1><div>Ascending:True</div><ul><li>Ford</li><li>Nissan</li><li>Toyota</li></ul>", page.Render());
        }

        [Fact]
        public void Render_Descending_List()
        {
            var reader = new Mock<IManufacturerReader>();
            reader.Setup(x => x.ReadAll()).Returns(new[] { "Toyota", "Ford", "Nissan" });

            var page = new Page(reader.Object);
            page.Page_Load();
            page.Sort_Click();
            page.Sort_Click();

            Assert.Equal("<h1>Manufacturers</h1><div>Ascending:False</div><ul><li>Toyota</li><li>Nissan</li><li>Ford</li></ul>", page.Render());
        }
    }
}
