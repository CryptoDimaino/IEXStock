namespace IEXStock.Helpers
{
    public class IEXOfficalOpenAndClose
    {
        public Open open { get; set; }
        public Close close { get; set; }
        public double high { get; set; }
        public double low { get; set; }
    }

    public class Open
    {
        public double price { get; set; }
        public long time { get; set; }
    }

    public class Close
    {
        public double price { get; set; }
        public long time { get; set; }
    }
}