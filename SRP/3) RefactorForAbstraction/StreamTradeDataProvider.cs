using System.Collections.Generic;
using System.IO;

namespace SRP1._3__RefactorForAbstraction
{
	public class StreamTradeDataProvider : ITradeDataProvider
	{
		// Context can be passed into classes via constructor parameters, keeping the interface clean.
		public StreamTradeDataProvider(Stream stream)
		{
			this.stream = stream;
		}

		public IEnumerable<string> GetTradeData()
		{
			var tradeData = new List<string>();
			using (var reader = new StreamReader(stream))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					tradeData.Add(line);
				}
			}

			return tradeData;
		}

		private Stream stream;
	}
}
