namespace Assets.Scripts.Currency
{
	public interface ICurrencyService
	{
		void AddCurrency(int amount);
		void SubtractCurrency(int amount);
		int GetCurrentBalance();
	}
}