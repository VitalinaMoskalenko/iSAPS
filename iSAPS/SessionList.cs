using System;
using Xamarin.Forms;

namespace iSAPS
{
    public class SessionList : ViewCell
    {
        public string student_id { get; set; }
        public string lecturers_first_name { get; set; }
        public string lecturers_last_name { get; set; }
        public string lecturers_title { get; set; }
        public string course { get; set; }
        public string course_date { get; set; }
        public string first_grade { get; set; }
        public string second_grade { get; set; }

        public string ShowSessionTitle
        {
            get 
            {
                return string.Format(
                                "Przedmiot:\n" + 
                                "Wykladowca: \n"  +
                                "Data: \n" +
                                "W terminie: \n" +
                                "Poprawka:" +
                                ""
                    );
            }
        }
        public string ShowSessionValue
        {
            get
            {
                return string.Format(
                                "{0}\n" +
                                "{1}{2} {3}\n" +
                                "{4} {5}\n" +
                                "{6}\n" +
                                "{7}" +
                                "", course, 
                                    lecturers_title, 
                                    lecturers_first_name, 
                                    lecturers_last_name, 
                                    DateTime.Parse(course_date).ToShortDateString(), DateTime.Parse(course_date).ToShortTimeString(), 
                                    first_grade, 
                                    second_grade
                    );
            }
        }
    }
}
