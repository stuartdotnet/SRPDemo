using SRP;
using System.Collections.Generic;

namespace SRP1._3__RefactorForAbstraction
{
	public interface ITradeParser
	{
		IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
	}
}
