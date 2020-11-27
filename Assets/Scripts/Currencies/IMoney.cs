namespace Currencies {
	public interface IMoney {
		// easy version (only Dollar):
		Money ConvertToDollar(Bank bank);
		Money ConvertTo(Bank bank, string currency);

		IMoney Add(Money added);
	}
}