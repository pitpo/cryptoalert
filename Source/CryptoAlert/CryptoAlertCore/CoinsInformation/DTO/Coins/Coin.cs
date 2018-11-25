namespace CryptoAlertCore.CoinsInformation.DTO.Coins
{
    public class Coin
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public long CirculatingSupply { get; set; }
        public long TotalSupply { get; set; }
        public bool Exchangeable { get; set; }
        public bool ExchangeAvailable { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string IconType { get; set; }
        public string IconUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public long MarketCap { get; set; }
        public long Volume { get; set; }
        public bool Penalty { get; set; }
        public string Price { get; set; }
        public Alltimehigh AllTimeHigh { get; set; }
        public int Rank { get; set; }
        public string[] History { get; set; }
        public float Change { get; set; }
    }
}