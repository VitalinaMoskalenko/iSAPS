using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iSAPS
{
    public class ScheduleItemList : ViewCell
    {
        #region for WCF
        //public string DisplayName { get; set; }
        //public int Id { get; set; }
        //public int IsapsGroupId { get; set; }
        //public string Room { get; set; }
        //public string Lector { get; set; }
        //public int LectorId { get; set; }
        //public string Type { get; set; }
        //public string Group { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public bool IsAllDay { get; set; }
        //public DateTime Start { get; set; }
        //public DateTime End { get; set; }

        //public string DateStartEnd
        //{
        //    get
        //    {
        //        return string.Format("{0} - {1}", Start.ToShortTimeString(), End.ToShortTimeString());
        //    }
        //}
        //public string TitleLector
        //{
        //    get
        //    {
        //        return string.Format("{0} \n{1}", Title, Lector);
        //    }
        //}
        #endregion

        public string schedule_id { get; set; }
        public string group_id { get; set; }
        public string schedule_room { get; set; }
        public string lecturers_title { get; set; }
        public string lecturers_first_name { get; set; }
        public string lecturers_last_name { get; set; }
        public string type { get; set; }
        public string schedule_title { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }

        public string DateStartEnd
        {
            get
            {
                return string.Format("{0} - {1}", DateTime.Parse(time_start).ToShortTimeString(), DateTime.Parse(time_end).ToShortTimeString());
            }
        }
        public string TitleLector
        {
            get
            {
                return string.Format("{0} \n{1}{2} {3}", schedule_title, lecturers_title, lecturers_first_name, lecturers_last_name);
            }
        }
    }
}
