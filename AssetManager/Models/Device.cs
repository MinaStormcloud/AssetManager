using System.ComponentModel.DataAnnotations;

namespace AssetManager.Models
{
    public class Device
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }        
        public DateTime PurchaseDate { get; set; }
        public int PriceCrowns { get; set; }
        public float PriceEuros { get; set; }
        public float PriceDollars { get; set; }
        public float PricePounds { get; set; }
        public string Type { get; set; }
        public string Office { get; set; }
    }
}
