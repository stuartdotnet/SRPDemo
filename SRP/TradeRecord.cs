namespace SRP
{
	public class TradeRecord
	{
		public string SourceCurrency { get; set; }
		public string DestinationCurrency { get; set; }
		public float Lots { get; set; }
		public decimal Price { get; set; }
	}
}
