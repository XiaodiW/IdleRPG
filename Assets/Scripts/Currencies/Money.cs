using System.Collections.Generic;

namespace Currencies {
	public class Money : IMoney {
		readonly int amount;
		public readonly string currency;

		public Money(int amount, string currency) {
			this.amount = amount;
			this.currency = currency;
		}
		
		public override string ToString() {
			return $"{this.amount} {this.currency}";
		}

		public Money ConvertToDollar(Bank bank) {
			return new Money((int)(this.amount * bank.GetDollarExchangeRate(this.currency)), "Dollar");
		}

		public Money ConvertTo(Bank bank, string currency)
		{
			return new Money((int)(this.amount * bank.GetExchangeRate(this.currency,currency)), currency);
		}

		public override bool Equals(object obj) {
			if (GetType() != obj?.GetType()) {
				return false;
			}
			var money = (Money) obj;
			if (this.currency != money.currency)
				return false;
			return money.amount == this.amount;
		}

		public static Money Dollar(int amount) {
			return new Money(amount, "Dollar");
		}

		public static Money SEK(int amount) {
			return new Money(amount, "SEK");
		}
		
		public static Money EUR(int amount) {
			return new Money(amount, "EUR");
		}
		
		public Money Times(int factor) {
			return new Money(this.amount * factor, this.currency);
		}

		public IMoney Add(Money addend) {
			if(addend.currency == this.currency)
				return new Money(this.amount + addend.amount, this.currency);
			List<Money> monies =new List<Money>{addend,this};
			return new Wallet(monies);
		}
	}
}