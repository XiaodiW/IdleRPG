using System.Collections.Generic;
using UnityEngine;

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

		public Money ConvertToDollar(Bank bank)
		{
			var newMoney = new Money(0,"");
			foreach (var money in monies)
			{
				if (newMoney.currency == "")
					newMoney = bank.ExchangeToDollar(money);
				else
					newMoney = (Money)newMoney.Add(bank.ExchangeToDollar(money));
			}
			return newMoney;
			// var aDollar = bank.ExchangeToDollar(this.monies[0]);
			// var bDollar = bank.ExchangeToDollar(this.monies[1]);
			// return bank.ExchangeToDollar(aDollar.Add(bDollar));
		}

		public Money ConvertTo(Bank bank, string to)
		{
			var newMoney = new Money(0,"");
			foreach (var money in monies)
			{
				if (newMoney.currency == "")
					newMoney = bank.ExchangeTo(money, to);
				else
					newMoney = (Money)newMoney.Add(bank.ExchangeTo(money, to));
			}
			return newMoney;
		}
		
		public IMoney Add(Money addend) {
			this.monies.Add(addend);
			return new Wallet(monies);
		}
		
		public IMoney Times(int factor) {
			for (int i = 0; i < monies.Count; i++)
			{
				monies[i] = (Money)monies[i].Times(factor);
			}
			return this;
		}
	}
}