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
	public partial class FinancePage : ContentPage
	{
		public FinancePage ()
		{
			InitializeComponent ();

            string idStudent = iSAPS.Settings.IdStudentSetting;
            string html = String.Empty;
            string url = String.Format(@"http://{0}:3000/finance/studentId={1}", Globals.CheckOS(), idStudent);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();

                var finance = JsonConvert.DeserializeObject<List<FinanceList>>(html);

                lblBankAccount.Text = finance[0].bank_account;
                FinanceView.ItemsSource = finance;
            }
        }
	}
}