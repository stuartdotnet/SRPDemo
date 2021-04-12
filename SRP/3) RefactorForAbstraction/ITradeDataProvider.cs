using System.Collections.Generic;

namespace SRP1._3__RefactorForAbstraction
{
	/// <summary>
	/// Provides an abstract way of retrieving the trade data
	/// </summary>
	/// <remarks>
	/// Note that this does not depend on the Stream class. Which means the 
	/// consuming client doesn't need to either.
	/// 
	/// If we were using the Starway pattern and keeping the interfaces in a
	/// separate assembly this would avoid our client needing to have add 
	/// appropriate references.
	/// </remarks>
	public interface ITradeDataProvider
	{
		IEnumerable<string> GetTradeData();
	}
}
