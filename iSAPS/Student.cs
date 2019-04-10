using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iSAPS
{
    public class Student : ViewCell
    {
        public int student_id { get; set; }
        public string student_first_name { get; set; }
        public string student_last_name { get; set; }
        public string student_email { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string birth_date { get; set; }
        public string place_of_birth { get; set; }
        public string mother_name { get; set; }
        public string father_name { get; set; }
        public string phone_number { get; set; }
        public string nationality { get; set; }
        public string passport_number { get; set; }
        public int group_id { get; set; }
        public string image_url { get; set; }

        public string DateShortTimeShort
        {
            get
            {
                return string.Format("{0}", DateTime.Parse(birth_date).ToShortDateString());
            }
        }

    }
}
