using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iSAPS
{
    public class ProffesorsList : ViewCell
    {
        public string lecturers_id { get; set; }
        public string lecturers_first_name { get; set; }
        public string lecturers_last_name { get; set; }
        public string lecturers_title { get; set; }
        public string lecturers_room { get; set; }
        public string lecturers_email { get; set; }
        public string lecturers_start_date { get; set; }
        public string lecturers_end_date { get; set; }
        public string DateStartEnd
        {
            get
            {
                return string.Format("{0} \n{1} - {2}", DateTime.Parse(lecturers_start_date).ToString("yyyy-MM-dd"), DateTime.Parse(lecturers_start_date).ToShortTimeString(), DateTime.Parse(lecturers_end_date).ToShortTimeString());
            }
        }
        public string TitleLector
        {
            get
            {
                return string.Format("{0}{1} {2} \n{3}", lecturers_title, lecturers_first_name, lecturers_last_name, lecturers_email);
            }
        }
    }
    public class ProffesorsListName
    {
        public string full_name { get; set; }
        public string lecturers_title { get; set; }
    }
}
