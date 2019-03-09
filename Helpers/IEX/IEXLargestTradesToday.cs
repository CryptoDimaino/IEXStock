using System;

namespace IEXStock.Helpers
{
    public class IEXLargestTradesToday
    {
        public double price { get; set; }
        public int size { get; set; }
        public object time { get; set; }
        public string timeLabel { get; set; }
        public string venue { get; set; }
        public string venueName { get; set; }

        public string TotalPrice
        {
            get
            {
                return (price *  Convert.ToDouble(size)).ToString("C");
            }
        }
    }
}