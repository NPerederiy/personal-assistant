using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface ICurrencyService
    {
        Task GetCurrencyInfo(string currencyCode);
        Task AddCurrencyAsync();
    }
}
