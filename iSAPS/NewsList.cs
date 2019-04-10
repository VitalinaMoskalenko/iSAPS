using System;
using Xamarin.Forms;

namespace iSAPS
{
    public class NewsList : ViewCell
    {
        public string news_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string date { get; set; }
        public string text { get; set; }

        public string Date
        {
            get {
                return DateTime.Parse(date).ToShortDateString();
            }
        }
    }
}
