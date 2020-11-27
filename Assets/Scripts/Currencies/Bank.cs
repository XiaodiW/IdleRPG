using System.Collections.Generic;

namespace Currencies {
	public class Bank
	{
		public Bank(float exchangeRate)
		{
		}

		public Money ExchangeToDollar(IMoney money)
		{
			return money.ConvertToDollar(this);
		}

		public Money ExchangeTo(IMoney money, string to)
		{
			return money.ConvertTo(this, to);
		}
		public float GetDollarExchangeRate(string from) {
			if (from == "Dollar")
				return 1f;
			if (from == "SEK")
				return 0.1f;
			if (from == "EUR")
				return 1.2f;
			throw new System.Exception($"Can not convert {from} to Dollar.");
		}
		// TODO 3 extended version: multiply the exchangeRate from->USD with USD->to (e.g.: SEK->USD & USD->EUR ==> SEK->EUR
		
		Dictionary<string, float> exchangeRate = new Dictionary<string, float>(){{"Dollar",1f},{"SEK",0.1f},{"EUR",1.2f}};
		public float GetExchangeRate(string from, string to) {
			return exchangeRate[from] / exchangeRate[to];
			// throw new System.NotImplementedException();
		}
	}
}