using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SRP1._3__RefactorForAbstraction;

namespace SRP.Tests
{
	[TestClass]
	public class SimpleTradeValidatorTests
	{
		private ITradeValidator _tradeValidator;

		[TestInitialize]
		public void Setup()
		{
			var mockLogger = new Mock<ILogger>();
			_tradeValidator = new SimpleTradeValidator(mockLogger.Object);
		}

		[TestMethod]
		public void Validate_WhenEverythingValid_ReturnsTrue()
		{
			string validCurrency = "USDAUD";
			int validTradeAmount = 10;
			decimal validTradePrice = 39m;
			var data = new string[] { $"{validCurrency}",$"{validTradeAmount}",$"{validTradePrice}" };

			var result = _tradeValidator.Validate(data);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Validate_WhenTradeParameterCountNot3_ReturnsFalse()
		{
			var data = new string[] { "test","test","test","test" };

			var result = _tradeValidator.Validate(data);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Validate_WhenTradeCurrencyMalformed_ReturnsFalse()
		{
			int validTradeAmount = 10;
			decimal validTradePrice = 39m;
			string badCurrency = "ABCDEFG";
			var data = new string[] { $"{badCurrency}", $"{validTradeAmount}", $"{validTradePrice}" };

			var result = _tradeValidator.Validate(data);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Validate_WhenTradeAmountInvalid_ReturnsFalse()
		{
			string validCurrency = "USDAUD";
			string notAnInteger = "ten";
			decimal validTradePrice = 39m;
			var data = new string[] { $"{validCurrency}",$"{notAnInteger}",$"{validTradePrice}" };

			var result = _tradeValidator.Validate(data);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Validate_WhenTradePriceInvalid_ReturnsFalse()
		{
			string validCurrency = "USDAUD";
			int validTradeAmount = 10;
			string invalidTradePrice = "10.nine";
			var data = new string[] { $"{validCurrency},{validTradeAmount},{invalidTradePrice}" };

			var result = _tradeValidator.Validate(data);

			Assert.IsFalse(result);
		}
	}
}
