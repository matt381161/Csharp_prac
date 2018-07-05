using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace json_prac
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
            //將要取得HTML原如碼的網頁放在WebRequest.Create(@”網址” )
            WebRequest myRequest = WebRequest.Create
                (@"http://www.ambassador.com.tw/ambassadorsite.webapi/api/Movies/GetMovieContent/?movieid=8bc2bdb5-f29b-446c-bd2d-4fe8abe89ce4");

            //Method選擇GET
            myRequest.Method = "GET";

            //取得WebRequest的回覆
            WebResponse myResponse = myRequest.GetResponse();

            //Streamreader讀取回覆
            StreamReader sr = new StreamReader(myResponse.GetResponseStream());

            //將全文轉成string
            string result = sr.ReadToEnd();

            //關掉StreamReader
            sr.Close();

            //關掉WebResponse
            myResponse.Close();

            //textBox1.Text += result;
            result = "{'results': [" + result + "]}";

            JObject jo = JObject.Parse(result);

            // get JSON result objects into a list
            List<JToken> results = jo["results"].Children().ToList();

            // serialize JSON results into .NET objects
            List<Movie> searchResults = new List<Movie>();
            foreach (JToken resulta in results)
            {
                Movie m = resulta.ToObject<Movie>();
                searchResults.Add(m);
            }
            //textBox1.Text += step2[0];
            textBox1.Text += searchResults[0].Name;
        }
    }
    public class Movie
    {
        public string Name { get; set; }
        public string ForeignName { get; set; }
        public string Rated { get; set; }
        public object RatedCode { get; set; }
        public string RunningTime { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string AllCasts { get; set; }
        public object Director { get; set; }
        public object Issuer { get; set; }
        public int RecommendGrade { get; set; }
        public string Synopsis { get; set; }
        public string PosterFilename { get; set; }
        public int PosterImageSource { get; set; }
        public List<string> GalleryImages { get; set; }
        public string Trailer_SourceLinker { get; set; }
        public List<string> ScreeningTheaters { get; set; }
        public bool IsNowPlaying { get; set; }
        public string MovieId { get; set; }
    }
}
