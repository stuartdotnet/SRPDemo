using System.Collections.Generic;
using SRP;

namespace SRP1._3__RefactorForAbstraction
{
	public class SqlTradeStorage : ITradeStorage
	{
		public void Persist(IEnumerable<TradeRecord> trades)
		{
			using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True"))
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					foreach (var trade in trades)
					{
						var command = connection.CreateCommand();
						command.Transaction = transaction;
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.CommandText = "dbo.insert_trade"; command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
						command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
						command.Parameters.AddWithValue("@lots", trade.Lots);
						command.Parameters.AddWithValue("@price", trade.Price);
						command.ExecuteNonQuery();
					}
					transaction.Commit();
				}

				connection.Close();
			}
		}
	}
}
