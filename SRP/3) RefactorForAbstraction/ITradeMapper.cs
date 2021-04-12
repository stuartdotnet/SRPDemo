using SRP;

namespace SRP1._3__RefactorForAbstraction
{
	public interface ITradeMapper
	{
		TradeRecord Map(string[] fields);
	}
}