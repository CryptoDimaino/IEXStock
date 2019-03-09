namespace IEXStock.Helpers
{
    public class IEXMarkets
    {
        public string mic { get; set; }
        public string tapeId { get; set; }
        public string venueName { get; set; }
        public long volume { get; set; }
        public int tapeA { get; set; }
        public int tapeB { get; set; }
        public int tapeC { get; set; }
        public double marketPercent { get; set; }
        public object lastUpdated { get; set; }

        public string marketPercentageString
        {
            get
            {
                return marketPercent.ToString("P");
            }
        }
    }
}