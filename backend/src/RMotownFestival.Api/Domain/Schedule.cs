using System.Collections.Generic;

namespace RMotownFestival.Api.Domain
{
    public class Schedule
    {
        public List<ScheduleItem> Items { get; set; }

        public Schedule()
        {
            Items = new List<ScheduleItem>();
        }
    }
}
