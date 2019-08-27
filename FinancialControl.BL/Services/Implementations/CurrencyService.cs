using AutoMapper;
using FinancialControl.BL.BO;
using FinancialControl.BL.Services.Abstractions;
using FinancialControl.DAL.Entities;
using FinancialControl.DAL.Repositories.Abstractions;
using System.Threading.Tasks;

namespace FinancialControl.BL.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CurrencyService(
            IUnitOfWork uow, 
            IMapper mapper
        )
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<CurrencyBO> AddCurrencyAsync(string ISO_4217_Code, string ISO_4217_Number, string name)
        {
            var currency = new Currency
            {
                ISO_4217_Code = ISO_4217_Code,
                ISO_4217_Number = ISO_4217_Number,
                Name = name
            };

            await _uow.CurrencyRepository.CreateAsync(currency);
            return _mapper.Map<CurrencyBO>(currency);
        }

        public async Task<CurrencyBO> GetCurrencyInfo(string ISO_4217_Code)
        {
            var currency = await _uow.CurrencyRepository.GetByConditionAsync(x => x.ISO_4217_Code == ISO_4217_Code);
            return currency != null ? _mapper.Map<CurrencyBO>(currency) : null;
        }
    }
}
