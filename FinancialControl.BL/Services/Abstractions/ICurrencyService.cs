using FinancialControl.BL.BO;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Abstractions
{
    public interface ICurrencyService
    {
        Task<CurrencyBO> GetCurrencyInfo(string ISO_4217_Code);
        Task<CurrencyBO> AddCurrencyAsync(string ISO_4217_Code, string ISO_4217_Number, string name);
    }
}
