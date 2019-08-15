using AutoMapper;

namespace FinancialControl.BL.Infrastructure
{
    public static class Mapper
    {
        private static readonly MapperConfiguration _config;
        public static IMapper Get() => _config.CreateMapper();
        
        static Mapper()
        {
            _config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
        }

    }
}
