using System;
namespace yoreparoApp.Models
{
    public class Store
    {
        public int storeId { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string storeAddres { get; set; }
        public string logo { get; set; }
        public string scheduleStartDay { get; set; }
        public string scheduleStartHour { get; set; }
        public string scheduleEndDay { get; set; }
        public string scheduleEndHour { get; set; }
        public string services { get; set; }

    }
}
