using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System.ServiceModel;
using System.Runtime.Serialization;

//using iSAPS_WCF_Client.IsapsReference;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Net;

namespace iSAPS
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProffesorPage : ContentPage
	{
        ObservableCollection<ProffesorsList> proffwssorsList = new ObservableCollection<ProffesorsList>();
        List<string> ProffesorsListName = new List<string>();
        string dateNow = DateTime.Now.ToShortDateString();

        public ProffesorPage()
        {
            InitializeComponent();
           
            string html = string.Empty;
            string url = String.Format(@"http://{0}:3000/lecturers", Globals.CheckOS());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))

            {
                html = reader.ReadToEnd();

                var proffesors = JsonConvert.DeserializeObject<List<ProffesorsList>>(html);
                foreach (var item in proffesors)
                {
                    proffwssorsList.Add(item);
                }
            }

            string urlProf = String.Format(@"http://{0}:3000/lecturerslist", Globals.CheckOS());
            HttpWebRequest requestProf = (HttpWebRequest)WebRequest.Create(urlProf);
            requestProf.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)requestProf.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))

            {
                html = reader.ReadToEnd();

                var proffesorsname = JsonConvert.DeserializeObject<List<ProffesorsListName>>(html);
                foreach (var item in proffesorsname)
                {
                    ProffesorsListName.Add(item.lecturers_title + item.full_name);
                }
            }
            loadPickerData();
        }

        private void loadPickerData()
        {
            ProffesorsNameView.ItemsSource = ProffesorsListName;
            ProffesorsNameView.SelectedIndexChanged += this.ProffesorsNameViewSelectedIndexChanged;
        }
        public void ProffesorsNameViewSelectedIndexChanged(object sender, EventArgs e)
        {
            //Method call every time when picker selection changed.
            var selectedValue = ProffesorsNameView.Items[ProffesorsNameView.SelectedIndex];

            ObservableCollection<ProffesorsList> proffwessorsListSelect = new ObservableCollection<ProffesorsList>();

            foreach (var item in proffwssorsList)
            {
                if (selectedValue == String.Format("{0}{1} {2}", item.lecturers_title, item.lecturers_first_name, item.lecturers_last_name) )
                {
                    proffwessorsListSelect.Add(item);
                }
            }
            ProffesorsView.ItemsSource = proffwessorsListSelect;
        }
    }
}