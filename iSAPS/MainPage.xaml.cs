using System;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

//using iSAPS_WCF_Client.IsapsReference;

using Xamarin.Forms;
using System.Net;
using System.Security.Cryptography;

namespace iSAPS
{
    public partial class MainPage : ContentPage
	{
        #region WCF variables
        //EndpointAddress EndPoint = Globals.EndPoint;
        //public static readonly EndpointAddress EndPoint = new EndpointAddress("https://wcf.isaps.pl/IsapsService.svc");
        //private IsapsServiceClient _client = new IsapsServiceClient();
        #endregion

        public MainPage()
		{
            
            InitializeComponent();
            RemeberMe();

            #region WCF StudentSchedule 
            //InitializeIsapsServiceClient();
            //(_client.Endpoint.Binding as BasicHttpBinding).MaxReceivedMessageSize = 20_000_000;

            //IEnumerable<WcfScheduleItem> scheduleItems = _client.MobileStudentSchedule("245EE6FC-396C-4956-9E84-25558724E65A", 121243, 1);
            //foreach (WcfScheduleItem item in scheduleItems)
            //{
            //}
            #endregion

            entryLogin.Text = iSAPS.Settings.LastUsedEmail;
            entryPassword.Text = iSAPS.Settings.LastPasswordSettings;
        }
        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            string login = entryLogin.Text;
            string passwordEntry = entryPassword.Text;

            var password = Hash(passwordEntry);

            string html = string.Empty;
            string url = String.Format(@"http://{0}:3000/login/email={1}&password={2}", Globals.CheckOS(), login, password);


                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();

                    var user = JsonConvert.DeserializeObject<Student>(html);

                if (user != null)
                {
                    if (sthRememberMe.IsToggled == true)
                    {
                        iSAPS.Settings.LastUsedEmail = login;
                        iSAPS.Settings.LastPasswordSettings = passwordEntry;
                    }
                    Application.Current.MainPage = new MenuPage();
                    Settings.IdStudentSetting = user.student_id.ToString();
                    Settings.IdGroupSetting = user.group_id.ToString();
                }
                    else
                    {
                        //DependencyService.Get<Toast>().Show("Niepoprawny login albo hasło!");

                        //if (Device.OS == TargetPlatform.iOS)
                        //{
                            DisplayAlert("Błąd", "Niepoprawny login albo hasło!", "OK");
                        //}
                    }

                }
            }
        public void RemeberMe()
        {
            lblRememberMe.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    if (sthRememberMe.IsToggled == true)
                    {
                        sthRememberMe.IsToggled = false;
                    }
                    else
                    {
                        sthRememberMe.IsToggled = true;
                    }
                }
            )
            });
        }

        static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

#region WCF InitializeIsapsServiceClient

        //private void InitializeIsapsServiceClient()
        //{
        //    BasicHttpBinding binding = CreateBasicHttp();
        //    _client = new IsapsServiceClient(binding, EndPoint);

        //}
        //private static BasicHttpBinding CreateBasicHttp()
        //{
        //    BasicHttpBinding binding = new BasicHttpBinding
        //    {
        //        Name = "basicHttpBinding",
        //        MaxBufferSize = 2147483647,
        //        MaxReceivedMessageSize = 2147483647
        //    };
        //    TimeSpan timeout = new TimeSpan(0, 0, 30);
        //    binding.SendTimeout = timeout;
        //    binding.OpenTimeout = timeout;
        //    binding.ReceiveTimeout = timeout;
        //    return binding;
        //}
#endregion
    }
}
