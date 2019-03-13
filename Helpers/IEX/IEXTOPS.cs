namespace IEXStock.Helpers
{
    public class IEXTOPS
    {
        public string symbol { get; set; }
        public string sector { get; set; }
        public string securityType { get; set; }
        public double? bidPrice { get; set; }
        public double? bidSize { get; set; }
        public double? askPrice { get; set; }
        public double? askSize { get; set; }
        public object lastUpdated { get; set; }
        public double? lastSalePrice { get; set; }
        public double? lastSaleSize { get; set; }
        public object lastSaleTime { get; set; }
        public double? volume { get; set; }
        public double? marketPercent { get; set; }
    }
}