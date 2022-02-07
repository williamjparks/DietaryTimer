using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _3390Timer
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Setup();
        }

        private List<Event> AllEvents { get; set; }

        private List<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event{ EventTitle = "Drink Water", BgColor = "#EB9999", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 15, 0).Ticks)},
                new Event{ EventTitle = "Before Eating", BgColor = "#96338F", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 30, 0).Ticks)},
                new Event{ EventTitle = "Meal Timer", BgColor = "#8251AE", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 0, 45, 0).Ticks)},
                new Event{ EventTitle = "Wake Up", BgColor = "#6787FF", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(0, 24, 0, 0).Ticks)},
            };
        }

        private void Setup()
        {
            AllEvents = GetEvents();
            eventList.ItemsSource = AllEvents;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (var evt in AllEvents)
                {
                    var timespan = evt.Date - DateTime.Now;
                    evt.Timespan = timespan;
                }

                eventList.ItemsSource = null;
                eventList.ItemsSource = AllEvents;

                return true;
            });
        }
    }

    public class Event
    {
        public DateTime Date { get; set; }
        public string EventTitle { get; set; }
        public TimeSpan Timespan { get; set; }
        public string Days => Timespan.Days.ToString("00");
        public string Hours => Timespan.Hours.ToString("00");
        public string Minutes => Timespan.Minutes.ToString("00");
        public string Seconds => Timespan.Seconds.ToString("00");
        public string BgColor { get; set; }
    }
}


