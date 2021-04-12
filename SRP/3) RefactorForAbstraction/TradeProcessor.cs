using SRP1._3__RefactorForAbstraction;

namespace SRP3
{
	/// <summary>
	/// Trade Processor
	/// </summary>
	/// <remarks>
	/// * Refactored for abstraction. *
	///
	/// This class no longer contains the implementation details for the whole process
	/// but instead contains the blueprint for the process. The class models the process of
	/// transferring trade data from one format to another. This is its only responsibility,
	/// its only concern, and the only reason that this class should change. If the process
	/// itself changes, this class will change to reflect it. But if you decide you no longer
	/// want to retrieve data from a Stream , log on to the console, or store the trades in a
	/// database, this class remains as is.
	/// 
	/// Note that in a real application the interfaces should live in a separate assemby to the
	/// classes as per the Starway pattern. This ensures that neither the client nor the
	/// implementation assemblies reference each other.
	/// 
	/// May seem a little contrived as it's a small program, but it's easy for programs like
	/// this to grow and when they do this kind of architecture makes them very adaptable
	/// </remarks>
	public class TradeProcessor
	{
		public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
		{
			this.tradeDataProvider = tradeDataProvider;
			this.tradeParser = tradeParser;
			this.tradeStorage = tradeStorage;
		}

		public void ProcessTrades()
		{
			var lines = tradeDataProvider.GetTradeData();
			var trades = tradeParser.Parse(lines);
			tradeStorage.Persist(trades);
		}

		private readonly ITradeDataProvider tradeDataProvider;
		private readonly ITradeParser tradeParser;
		private readonly ITradeStorage tradeStorage;
	}
}
