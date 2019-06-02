namespace SRP1._3__RefactorForAbstraction
{
	// Note no dependency on the Console
	public class SimpleTradeValidator : ITradeValidator
	{
		private readonly ILogger logger;

		public SimpleTradeValidator(ILogger logger)
		{
			this.logger = logger;
		}

		public bool Validate(string[] tradeData, int count)
		{
			if (tradeData.Length != 3)
			{
				logger.LogWarning($"Line malformed. Only {tradeData.Length} field(s) found.");
				return false;
			}

			if (tradeData[0].Length != 6)
			{
				logger.LogWarning($"Trade currencies malformed: '{tradeData[0]}'");
				return false;
			}

			int tradeAmount;
			if (!int.TryParse(tradeData[1], out tradeAmount))
			{
				logger.LogWarning($"Trade amount not a valid integer: '{tradeData[1]}'");
				return false;
			}

			decimal tradePrice;
			if (!decimal.TryParse(tradeData[2], out tradePrice))
			{
				logger.LogWarning($"WARN: Trade price not a valid decimal: '{tradeData[2]}'");
				return false;
			}
			return true;
		}
	}
}
