using System;
using System.IO;

using Newtonsoft.Json;

//using iSAPS_WCF_Client.IsapsReference;

using Xamarin.Forms;
using System.Net;

namespace iSAPS
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            string idStudent = iSAPS.Settings.IdStudentSetting;
            string html = string.Empty;
            string url = String.Format(@"http://{0}:3000/student/id={1}", Globals.CheckOS(), idStudent);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();

                var user = JsonConvert.DeserializeObject<Student>(html);

                lblFirstName.Text = user.student_first_name;
                lblLastName.Text = user.student_last_name;
                lblEmail.Text = user.student_email;
                lblGender.Text = user.gender;
                lblBirthDate.Text = user.DateShortTimeShort;
                lblPlaseOfBirth.Text = user.place_of_birth;
                lblMotherName.Text = user.mother_name;
                lblFatherName.Text = user.father_name;
                lblPhoneNumber.Text = user.phone_number;
                lblNationality.Text = user.nationality;
                lblPassportNumber.Text = user.passport_number;
                imgAvatar.Source = user.image_url;
            }
        }
    }
}
