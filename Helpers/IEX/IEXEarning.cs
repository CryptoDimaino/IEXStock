using System.Collections.Generic;

namespace IEXStock.Helpers
{
    public class IEXEarning
    {
        public string symbol { get; set; }
        public List<Earning> earnings { get; set; }
    }

    public class Earning
    {
        public double actualEPS { get; set; }
        public double consensusEPS { get; set; }
        public double estimatedEPS { get; set; }
        public string announceTime { get; set; }
        public int numberOfEstimates { get; set; }
        public double EPSSurpriseDollar { get; set; }
        public string EPSReportDate { get; set; }
        public string fiscalPeriod { get; set; }
        public string fiscalEndDate { get; set; }
        public double yearAgo { get; set; }
        public double yearAgoChangePercent { get; set; }
        public double estimatedChangePercent { get; set; }
        public int symbolId { get; set; }
    }
}