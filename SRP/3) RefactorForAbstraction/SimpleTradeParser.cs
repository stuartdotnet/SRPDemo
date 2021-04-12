using SRP;
using System.Collections.Generic;
using System;

namespace SRP1._3__RefactorForAbstraction
{
	public class SimpleTradeParser: ITradeParser
	{
		public SimpleTradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
		{
			this.tradeValidator = tradeValidator;
			this.tradeMapper = tradeMapper;
		}

		public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData)
		{
			var trades = new List<TradeRecord>();
			var lineCount = 1;
			foreach (var line in tradeData)
			{
				var fields = line.Split(new char[] { ',' });
				if (!tradeValidator.Validate(fields))
				{
					continue;
				}

				var trade = tradeMapper.Map(fields);
				trades.Add(trade); lineCount++;
			}

			return trades;
		}

		private readonly ITradeValidator tradeValidator;
		private readonly ITradeMapper tradeMapper;
		
	}
}
