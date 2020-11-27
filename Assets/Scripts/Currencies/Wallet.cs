using System.Collections.Generic;

namespace Currencies {
	public class Wallet : IMoney {
		// readonly Money a;
		// readonly Money b;
		private readonly List<Money> monies;

		// public Wallet(Money a, Money b) {
		// 	this.a = a;
		// 	this.b = b;
		// }
		//
		public Wallet(List<Money> monies)
		{
			this.monies = monies;
		}

		// public Money ConvertToDollar(Bank bank)
		// {
		// 	var aDollar = bank.ExchangeToDollar(this.monies[0]);
		// 	var bDollar = bank.ExchangeToDollar(this.monies[1]);
		// 	return bank.ExchangeToDollar(aDollar.Add(bDollar));
		// }

		public Money ConvertTo(Bank bank, string to)
		{
			var newMoney = new Money(0,"");
			foreach (var money in monies)
			{
				if (newMoney.currency == "")
				{
					newMoney = bank.ExchangeTo(money, to);
				}

				newMoney.Add(bank.ExchangeTo(money, to));
			}
			return bank.ExchangeTo(newMoney, to);
		}
		
		public IMoney Add(Money addend) {
			this.monies.Add(addend);
			return new Wallet(monies);
		}
	}
}