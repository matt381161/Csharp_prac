using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            run();
        }

        public void run()
        {
            string googleSearchText = @"{
    'results': [
      {
        'GsearchResultClass': 'GwebSearch',
        'unescapedUrl': 'http://en.wikipedia.org/wiki/Paris_Hilton',
        'url': 'http://en.wikipedia.org/wiki/Paris_Hilton',
        'visibleUrl': 'en.wikipedia.org',
        'cacheUrl': 'http://www.google.com/search?q=cache:TwrPfhd22hYJ:en.wikipedia.org',
        'title': '<b>Paris Hilton</b> - Wikipedia, the free encyclopedia',
        'titleNoFormatting': 'Paris Hilton - Wikipedia, the free encyclopedia',
        'content': '[1] In 2006, she released her debut album...'
      },
      {
        'GsearchResultClass': 'GwebSearch',
        'unescapedUrl': 'http://www.imdb.com/name/nm0385296/',
        'url': 'http://www.imdb.com/name/nm0385296/',
        'visibleUrl': 'www.imdb.com',
        'cacheUrl': 'http://www.google.com/search?q=cache:1i34KkqnsooJ:www.imdb.com',
        'title': '<b>Paris Hilton</b>',
        'titleNoFormatting': 'Paris Hilton',
        'content': 'Self: Zoolander. Socialite <b>Paris Hilton</b>...'
      }
    ]
}";

            JObject googleSearch = JObject.Parse(googleSearchText);

            // get JSON result objects into a list
            IList<JToken> results = googleSearch["results"].Children().ToList();

            // serialize JSON results into .NET objects
            IList<SearchResult> searchResults = new List<SearchResult>();
            foreach (JToken result in results)
            {
                // JToken.ToObject is a helper method that uses JsonSerializer internally
                SearchResult searchResult = result.ToObject<SearchResult>();
                searchResults.Add(searchResult);
            }
            MessageBox.Show(searchResults.First().Title.ToString());
        }

        public class SearchResult
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Url { get; set; }
        }
    }
}
