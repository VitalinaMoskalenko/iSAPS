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
	public partial class ClassSchedulePage : ContentPage
	{
        ObservableCollection<ScheduleItemList> scheduleList = new ObservableCollection<ScheduleItemList>();
        string dateNow = DateTime.Now.ToShortDateString();

        public ClassSchedulePage ()
		{
            InitializeComponent();

            string idGroup = iSAPS.Settings.IdGroupSetting;
            string html = String.Empty;
            string url = String.Format(@"http://{0}:3000/schedule/groupId={1}", Globals.CheckOS(), idGroup);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();

                var schedule = JsonConvert.DeserializeObject<List<ScheduleItemList>>(html);
                foreach (var item in schedule)
                {
                    scheduleList.Add(item);
                }
                ObservableCollection<ScheduleItemList> scheduleListSelect = new ObservableCollection<ScheduleItemList>();

                lblMathYear.Text = string.Format("{0} {1}", DateTime.Now.ToString("MMMM"), DateTime.Now.Date.ToString("yyyy"));
                foreach (var item in scheduleList)
                {
                    if (DateTime.Parse(item.time_start).ToShortDateString() == dateNow)
                    {
                        scheduleListSelect.Add(item);
                    }
                }
                ScheduleView.ItemsSource = scheduleListSelect;
            }

            #region test data WCF
            //scheduleItem.Add(new ScheduleItemList() { Id = 1, IsapsGroupId = 1, Room = "C125", Lector = "mg.inz.Joe Doe", LectorId = 1, Type = "dzienne", Group = "4 1 INŻ SD BYD 2L", Title = "Programowanie", Description = "dodatkowow", IsAllDay = false, Start = DateTime.Now, End = DateTime.Now.AddHours(1) });
            //scheduleItem.Add(new ScheduleItemList() { Id = 2, IsapsGroupId = 1, Room = "B120", Lector = "mg.inz.Joe Doe", LectorId = 1, Type = "dzienne", Group = "4 1 INŻ SD BYD 2L", Title = "Informatyka", Description = "dodatkowow", IsAllDay = false, Start = DateTime.Now.AddHours(2), End = DateTime.Now.AddHours(3) });
            //scheduleItem.Add(new ScheduleItemList() { Id = 3, IsapsGroupId = 1, Room = "K101", Lector = "mg.inz.Joe Doe", LectorId = 1, Type = "dzienne", Group = "4 1 INŻ SD BYD 2L", Title = "Zarządzanie projektami informatycznymi", Description = "dodatkowow", IsAllDay = false, Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1).AddHours(1) });
            //scheduleItem.Add(new ScheduleItemList() { Id = 4, IsapsGroupId = 1, Room = "C125", Lector = "mg.inz.Joe Doe", LectorId = 1, Type = "dzienne", Group = "4 1 INŻ SD BYD 2L", Title = "Zespołowe przedsięwzięcie inżynierskie", Description = "dodatkowow", IsAllDay = false, Start = DateTime.Now.AddDays(1).AddHours(2), End = DateTime.Now.AddDays(1).AddHours(3) });
            //scheduleItem.Add(new ScheduleItemList() { Id = 5, IsapsGroupId = 1, Room = "C220", Lector = "mg.inz.Joe Doe", LectorId = 1, Type = "dzienne", Group = "4 1 INŻ SD BYD 2L", Title = "Programowanie", Description = "dodatkowow", IsAllDay = false, Start = DateTime.Now.AddDays(2), End = DateTime.Now.AddDays(2).AddHours(1) });
            //scheduleItem.Add(new ScheduleItemList() { Id = 6, IsapsGroupId = 1, Room = "F125", Lector = "mg.inz.Joe Doe", LectorId = 1, Type = "dzienne", Group = "4 1 INŻ SD BYD 2L", Title = "Informatyka", Description = "dodatkowow", IsAllDay = false, Start = DateTime.Now.AddDays(2).AddHours(2), End = DateTime.Now.AddDays(2).AddHours(3) });
            #endregion
            //ObservableCollection<ScheduleItemList> scheduleItemSelect = new ObservableCollection<ScheduleItemList>();

            //ScheduleView.ItemsSource = scheduleItemSelect;
            //lblMathYear.Text = string.Format("{0} {1}", DateTime.Now.ToString("MMMM"), DateTime.Now.Date.ToString("yyyy"));

            //foreach (var item in scheduleItem)
            //{

            //    if (item.Start.ToShortDateString() == dateNow)
            //    {
            //        scheduleItemSelect.Add(new ScheduleItemList() { Id = item.Id, IsapsGroupId = item.IsapsGroupId, Room = item.Room, Lector = item.Lector, LectorId = item.LectorId, Type = item.Type, Group = item.Group, Title = item.Title, Description = item.Description, IsAllDay = item.IsAllDay, Start = item.Start, End = item.End });
            //    }
            //}
        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            ObservableCollection<ScheduleItemList> scheduleItemSelect = new ObservableCollection<ScheduleItemList>();

            ScheduleView.ItemsSource = scheduleItemSelect;

            foreach (var item in scheduleList)
            {

                if (DateTime.Parse(item.time_start).ToShortDateString() == dtpDate.Date.ToShortDateString())
                {
                    scheduleItemSelect.Add(item);
                }
            }
            lblMathYear.Text = string.Format("{0} {1}", dtpDate.Date.ToString("MMMM"), dtpDate.Date.ToString("yyyy"));
        }
    }
}