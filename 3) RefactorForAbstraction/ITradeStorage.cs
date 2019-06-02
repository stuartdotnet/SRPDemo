using SRP;
using System.Collections.Generic;

namespace SRP1._3__RefactorForAbstraction
{
	public interface ITradeStorage
	{
		void Persist(IEnumerable<TradeRecord> trades);
	}
}
