using DesignPatterns.Prototype;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Prototype
{
    public class WebPageScraper_Should
    {
        [Fact]
        public void Clone()
        {
            var scraper = new WebPageScraper("http://www.example.com");
            var scraper2 = (WebPageScraper)scraper.Clone(); // instead of new'ing up an object with expensive contructor, clone instead

            Assert.Equal("My Page", scraper.Title);
            Assert.Equal("My Page", scraper2.Title);
        }
    }
}
