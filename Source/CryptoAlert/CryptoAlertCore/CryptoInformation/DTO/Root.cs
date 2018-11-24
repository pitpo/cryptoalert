namespace CryptoAlertCore.CryptoInformation.DTO
{

    public class AllCryptoCurrenciesRootObject
    {
        public string status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Stats stats { get; set; }
        public Base _base { get; set; }
        public Coin[] coins { get; set; }
    }

    public class Stats
    {
        public int total { get; set; }
    }

    public class Base
    {
        public string symbol { get; set; }
        public string sign { get; set; }
    }

    public class Coin
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public long circulatingSupply { get; set; }
        public long totalSupply { get; set; }
        public bool exchangeable { get; set; }
        public bool exchangeAvailable { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public string iconType { get; set; }
        public string iconUrl { get; set; }
        public string websiteUrl { get; set; }
        public long marketCap { get; set; }
        public long volume { get; set; }
        public bool penalty { get; set; }
        public string price { get; set; }
        public Alltimehigh allTimeHigh { get; set; }
        public int rank { get; set; }
        public string[] history { get; set; }
        public float change { get; set; }
    }

    public class Alltimehigh
    {
        public string price { get; set; }
        public long timestamp { get; set; }
    }

}