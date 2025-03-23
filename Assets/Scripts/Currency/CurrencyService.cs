namespace Assets.Scripts.Currency
{
	public class CurrencyService
	{
		public Dollar dollar { get; set; }

		public CurrencyService() { 
			dollar =  new Dollar();
		}
	}
}