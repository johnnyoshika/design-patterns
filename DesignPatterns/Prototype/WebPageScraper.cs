using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Prototype
{
    public class WebPageScraper : ICloneable // implementing ICloneable is enough to implement the prototype pattern
    {
        public WebPageScraper(string url)
        {
            var client = new FakeHttpClient();
            Scrape(client.Download(url));
        }

        public string? Title { get; private set; }
        public string? Header { get; private set; }

        void Scrape(string page)
        {
            Title = page.InnerText("title");
            Header = page.InnerText("h1");
        }

        public object Clone() => MemberwiseClone(); // this only does a shallow clone
    }

    static class HtmlFormatter
    {
        public static string InnerText(this string page, string tag) => page.Substring(page.StartIndex(tag), page.InnerTextLength(tag));
        static string OpeningTag(this string tag) => $"<{tag}>";
        static string ClosingTag(this string tag) => $"</{tag}>";
        static int StartIndex(this string s, string tag) => s.IndexOf(tag.OpeningTag()) + tag.OpeningTag().Length;
        static int InnerTextLength(this string s, string tag) => s.IndexOf(tag.ClosingTag()) - StartIndex(s, tag);
    }

    class FakeHttpClient
    {
        public string Download(string url)
        {
            // simulate network latency
            System.Threading.Thread.Sleep(2000);
            return "<html><title>My Page</title><body><h1>New World</h1></body></html>";
        }
    }
}
